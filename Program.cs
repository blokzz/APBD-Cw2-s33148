using PracaDomowa2;

IUserRepository userRepo = new UserRepository();
IDeivceRepository deviceRepo = new DeviceRepository();
IRentalRepository rentalRepo = new RentalRepository();

var deviceService = new DeviceService(deviceRepo);
var userService = new UserService(userRepo);
var rentalService = new RentalService(rentalRepo, deviceRepo, userRepo);
var s1 = new Student("Jan", "Bogdan", "jan@edu.pl");
var e1 = new Employee("Andrzej", "Nowak", "nowak@uczelnia.pl");
userRepo.Add(s1);
userRepo.Add(e1);

var laptop = new Laptop("Dell", "XPS", 16, 15);
var proj = new Projector("Epson", "EB", 4000, 1200);
deviceRepo.Add(laptop);
deviceRepo.Add(proj);

Console.WriteLine("--- System Wypożyczalni Uruchomiony---");

try 
{
    Console.WriteLine("\nPróba wypożyczenia laptopa");
    rentalService.RentDevice(laptop.Id, s1.Id); 
            
    Console.WriteLine("\nPróba ponownego wypożyczenia tego samego laptopa");
    rentalService.RentDevice(laptop.Id, e1.Id); 
            
}
catch (Exception ex)
{
    Console.WriteLine($"BŁĄD: {ex.Message}");
}

Console.WriteLine("\n--- TEST ZWROTÓW ---");

try 
{
    Console.WriteLine($"Zwracanie urządzenia: {laptop.Name}");
    rentalService.ReturnDevice(laptop.Id); 
}
catch (Exception ex)
{
    Console.WriteLine($"BŁĄD ZWROTU: {ex.Message}");
}

Console.WriteLine($"\nAktywne wypożyczenia użytkownika {s1.Name}:");
var studentRentals = rentalRepo.GetActiveByUserId(s1.Id);
foreach (var r in studentRentals)
{
    var d = deviceRepo.GetById(r.DeviceId);
    Console.WriteLine($"- {d.Name} (Termin: {r.DueDate:d})");
}

WyswietlRaport(deviceRepo, rentalRepo);




static void WyswietlRaport(IDeivceRepository deviceRepo, IRentalRepository rentalRepo)
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