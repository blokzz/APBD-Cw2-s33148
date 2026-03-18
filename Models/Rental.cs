namespace PracaDomowa2;

public class Rental
{
    private static int _nextId = 1;
    public int Id { get; private set; }
    public int DeviceId { get; private set; }
    public int UserId { get; private set; }
    public DateTime RentalDate { get; private set; }
    public DateTime ReturnDate { get; private set; }
    public bool Returned { get; set; }

    public Rental(int deviceId, int userId)
    {
        Id = _nextId++;
        DeviceId = deviceId;
        UserId = userId;
        RentalDate = DateTime.Now;
        ReturnDate = DateTime.Now.AddDays(14);
        Returned = false;
    }
}