namespace PracaDomowa2;
public class MenuService
{
    private readonly RentalService _rentalService;
    private readonly DeviceService _deviceService;
    private readonly UserService _userService;
    private readonly IDeivceRepository _deviceRepo;
    private readonly IRentalRepository _rentalRepo;

    public MenuService(RentalService rentalService, DeviceService deviceService, UserService userService, IDeivceRepository deviceRepo, IRentalRepository rentalRepo)
    {
        _rentalService = rentalService;
        _deviceService = deviceService;
        _userService = userService;
        _deviceRepo = deviceRepo;
        _rentalRepo = rentalRepo;
    }

    public void ShowMainMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== SYSTEM WYPOŻYCZALNI ===");
            Console.WriteLine("1. Raport sprzętu");
            Console.WriteLine("2. Wypożycz sprzęt");
            Console.WriteLine("3. Zwróć sprzęt");
            Console.WriteLine("0. Wyjście");
            Console.Write("Wybór: ");

            var choice = Console.ReadLine();
            switch (choice)
            {
                case "1": WyswietlRaport(_deviceRepo, _rentalRepo); break;
                case "2": HandleRent(); break;
                case "3": HandleReturn(); break;
                case "0": return;
            }
            Console.WriteLine("\nNaciśnij dowolny klawisz...");
            Console.ReadKey();
        }
    }

    private void HandleRent()
    {
        try
        {
            Console.Write("Podaj ID użytkownika: ");
            int userId = int.Parse(Console.ReadLine());
            Console.Write("Podaj ID sprzętu: ");
            int deviceId = int.Parse(Console.ReadLine());

            _rentalService.RentDevice(deviceId, userId);
            Console.WriteLine("Sukces!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"BŁĄD: {ex.Message}");
        }
    }
    
    
private void WyswietlRaport(IDeivceRepository deviceRepo, IRentalRepository rentalRepo)
{;
    Console.WriteLine("      RAPORT STANU WYPOŻYCZALNI");

    var devices = deviceRepo.GetAll();
    Console.WriteLine($"Łączna liczba sprzętu: {devices.Count()}");
    
    var rentedCount = devices.Count(d => !d.Available);
    Console.WriteLine($"Wypożyczone: {rentedCount}");
    Console.WriteLine($"Dostępne: {devices.Count() - rentedCount}");

    Console.WriteLine("\nLista sprzętu:");
    foreach (var d in devices)
    {
        string status = d.Available ? "[DOSTĘPNY]" : "[WYPOŻYCZONY]";
        Console.WriteLine($"{status} ID: {d.Id} | {d.Name}");
    }
    var overdue = rentalRepo.GetOverdueRentals();
    if (overdue.Any())
    {
        Console.WriteLine("\n!!! PRZETERMINOWANE WYPOŻYCZENIA !!!");
        foreach (var o in overdue)
        {
            Console.WriteLine($"Urządzenie ID: {o.DeviceId} u Usera ID: {o.UserId}");
        }
    }
    Console.WriteLine("========================================\n");
}

private void HandleReturn()
{
    try
    {
        Console.Write("Podaj ID urządzenia: ");
        int deviceId = int.Parse(Console.ReadLine());
        _rentalService.ReturnDevice(deviceId);
        Console.WriteLine("Sukces!");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"BŁĄD: {ex.Message}");
    }
}
}