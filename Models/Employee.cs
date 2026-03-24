namespace PracaDomowa2;

public class Employee : User
{
    public override int MaxRentals => BusinessRules.EmployeeRentalLimit;
    public Employee(string name, string surname, string email) : base(name, surname, email)
    {
    }
}
