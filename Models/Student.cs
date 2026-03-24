namespace PracaDomowa2
{
    public class Student : User
    {
        public override int MaxRentals => BusinessRules.StudentRentalLimit;
        public Student(string name, string surname, string email) : base(name, surname, email)
        {
        }
    }
}
