namespace PracaDomowa2;

public class Camera : Device
{
    public int Megapixels { get; private set; }
    public string Resolution { get; private set; }
    
    public Camera(string name, string model, int megapixels, string resolution) : base(name, model)
    {
        Megapixels = megapixels;
        Resolution = resolution;
    }
}
