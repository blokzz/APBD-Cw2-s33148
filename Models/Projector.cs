namespace pracaDomowa2;

public class Projector : Device
{

    public int Resolution { get; private set; }
    public int Brightness { get; private set; }
    
    public Projector(string name, string model, int resolution, int brightness) : base(name, model)
    {
        Resolution = resolution;
        Brightness = brightness;
    }
}