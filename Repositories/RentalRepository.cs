namespace PracaDomowa2;
public class RentalRepository : IRentalRepository
{
    private readonly List<Rental> _rentals = new();

    public void Add(Rental rental)
    {
        _rentals.Add(rental);
    }

    public IEnumerable<Rental> GetAll() => _rentals;

    public IEnumerable<Rental> GetActiveByUserId(int userId)
    {
        return _rentals.Where(r => r.UserId == userId && r.ReturnDate == null);
    }

    public Rental GetActiveByDeviceId(int deviceId)
    {
        return _rentals.FirstOrDefault(r => r.DeviceId == deviceId && r.ReturnDate == null);
    }

    public IEnumerable<Rental> GetOverdueRentals()
    {
        return _rentals.Where(r => r.ReturnDate == null && DateTime.Now > r.DueDate);
    }
}