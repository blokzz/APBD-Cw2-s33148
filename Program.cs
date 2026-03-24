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

var menuService = new MenuService(rentalService, deviceService, userService, deviceRepo, rentalRepo , userRepo);
menuService.ShowMainMenu();
