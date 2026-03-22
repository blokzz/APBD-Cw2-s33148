namespace PracaDomowa2;

public class RentalService
{
    private readonly List<Rental> _rentals = new();
    private readonly DeviceService _deviceService;
    private readonly UserService _userService;

    public RentalService(DeviceService deviceService, UserService userService)
    {
        _deviceService = deviceService;
        _userService = userService;
    }

    public void RentDevice(int deviceId, int userId)
    {
        var device = _deviceService.GetDevice(deviceId);
        var user = _userService.GetUser(userId);

        if (device == null || !device.Available)
        {
            Console.WriteLine("Sprzęt niedostępny.");
            return;
        }

        int activeCount = _rentals.Count(r => r.UserId == userId && !r.Returned);
        if (activeCount >= user.MaxRentals) 
        {
            Console.WriteLine($"Limit przekroczony! {user.Name} może mieć max {user.MaxRentals} wypożyczenia.");
            return;
        }

        var rental = new Rental(deviceId, userId);
        _rentals.Add(rental);
        _deviceService.setStatus(deviceId, false);

        Console.WriteLine($"Wypożyczono {device.Name} użytkownikowi {user.Name}.");
    }
}