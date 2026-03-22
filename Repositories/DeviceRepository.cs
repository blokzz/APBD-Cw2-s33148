namespace PracaDomowa2;

public class InMemoryDeviceRepository : IDeviceRepository
{
    private readonly Dictionary<int, Device> _devices = new();
    public void Add(Device device) => _devices[device.Id] = device;
    public Device GetById(int id) => _devices[id];
    public IEnumerable<Device> GetAll() => _devices.Values;
}