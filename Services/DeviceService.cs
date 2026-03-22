namespace PracaDomowa2;

public class DeviceService
{
    private Dictionary<int, Device> _devices = new Dictionary<int, Device>();

    public void AddDevice(Device device)
    {
        _devices.Add(device.Id, device);
    }

    public void ShowDevices()
    {
        foreach (var device in _devices)
        {
            Console.WriteLine($"Device {device.Id}: {device.Name} {device.Model} Stauts: {device.Status ? "Available" : "Unavailable"}");
        }
    }

    public void RemoveDevice(int id)
    {
        _devices.Remove(id);
    }

    public Device GetDevice(int id)
    {
        return _devices[id];
    }
    public bool isAvailable(int id)
    {
        return _devices[id].Status;
    }
    public void setStatus(int id, bool status)
    {
        _devices[id].Status = status;
    }
}