namespace PracaDomowa2;

public interface IRentalRepository
{
    void Add(Rental rental);
    IEnumerable<Rental> GetAll();
    IEnumerable<Rental> GetActiveByUserId(int userId);
    Rental GetActiveByDeviceId(int deviceId);
    IEnumerable<Rental> GetOverdueRentals();
}