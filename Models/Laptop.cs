namespace pracaDomowa2;

public class Laptop : Device
{
    public int RamGb { get; private set; }
    public int Inches { get; private set; }
    public Laptop(string name, string model, int ramGb , int inches)
        : base(name, model)
    {
        RamGb = ramGb;
        Inches = inches;
    }
}