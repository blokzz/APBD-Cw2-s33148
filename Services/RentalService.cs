namespace PracaDomowa2;
public class RentalService
{
    private readonly IRentalRepository _rentalRepo;
    private readonly IDeivceRepository _deviceRepo;
    private readonly IUserRepository _userRepo;

    public RentalService(IRentalRepository rentalRepo, IDeivceRepository deviceRepo, IUserRepository userRepo)
    {
        _rentalRepo = rentalRepo;
        _deviceRepo = deviceRepo;
        _userRepo = userRepo;
    }

    public void RentDevice(int deviceId, int userId)
    {
        var device = _deviceRepo.GetById(deviceId);
        var user = _userRepo.GetById(userId);

        if (device == null) throw new Exception("Urządzenie nie istnieje.");
        if (user == null) throw new Exception("Użytkownik nie istnieje.");

        if (!device.Available)
            throw new Exception($"Sprzęt {device.Name} jest obecnie niedostępny.");

        int activeCount = _rentalRepo.GetActiveByUserId(userId).Count();
        if (activeCount >= user.MaxRentals) 
            throw new Exception($"Limit przekroczony! {user.Name} może mieć max {user.MaxRentals} wypożyczenia.");

        var rental = new Rental(deviceId, userId);
        _rentalRepo.Add(rental);
        device.Available = false; 
    }

    public void ReturnDevice(int deviceId)
    {
        var rental = _rentalRepo.GetActiveByDeviceId(deviceId);
          if (rental == null) throw new Exception("Nie znaleziono aktywnego wypożyczenia dla tego urządzenia.");
        rental.ReturnDate = DateTime.Now;
        
        decimal penaltyRate = rental.Penalty;
        decimal penalty = rental.CalculatePenalty(penaltyRate);

        rental.MarkAsReturned();
        var device = _deviceRepo.GetById(deviceId);
        if (device != null) device.Available = true;

        if (penalty > 0)
        {
            Console.WriteLine($"Nałożono karę w wysokości {penalty} PLN.");
        }
        else
        {
            Console.WriteLine("Sprzęt zwrócono w terminie.");
        }
    }
}