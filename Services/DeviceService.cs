namespace PracaDomowa2;

public class DeviceService
{
    private readonly IDeviceRepository _repository;

    public DeviceService(IDeviceRepository repository)
    {
        _repository = repository;
    }

    public void AddDevice(Device device) => _repository.Add(device);

    public IEnumerable<Device> GetAvailableDevices() 
    {
        return _repository.GetAll().Where(d => d.Status);
    }

    public void MarkAsUnavailable(int id)
    {
        var device = _repository.GetById(id);
        device.Status = false;
    }
}