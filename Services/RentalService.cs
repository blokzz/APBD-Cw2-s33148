namespace PracaDomowa2

public class RentalService
{
    private List<Rental> _rentals = new List<Rental>();
    private List<Device> _devices = new List<Device>();
    private List<User> _users = new List<User>();

    public void AddDevice(Device device)
    {
        _devices.Add(device);
    }

    public void AddUser(User user)
    {
        _users.Add(user);
    }

    public void RentDevice(int deviceId, int userId)
    {
        var device = _devices.Find(d => d.Id == deviceId);
        var user = _users.Find(u => u.Id == userId);

        if (device == null || user == null)
        {
            Console.WriteLine("Device or user not found.");
            return;
        }

        var rental = new Rental(deviceId, userId);
        _rentals.Add(rental);
        Console.WriteLine($"Device {device.Name} rented to {user.Name} {user.Surname}.");
    }

    public void ReturnDevice(int rentalId)
    {
        var rental = _rentals.Find(r => r.Id == rentalId);
        if (rental == null)
        {
            Console.WriteLine("Rental not found.");
            return;
        }

        rental.Returned = true;
        Console.WriteLine($"Rental {rentalId} returned.");
    }

    public void ShowRentals()
    {
        foreach (var rental in _rentals)
        {
            var device = _devices.Find(d => d.Id == rental.DeviceId);
            var user = _users.Find(u => u.Id == rental.UserId);

            Console.WriteLine($"Rental {rental.Id}: {device?.Name} to {user?.Name} {user?.Surname} - Returned: {rental.Returned}");
        }
    }
}
