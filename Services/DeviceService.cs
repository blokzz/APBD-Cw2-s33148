namespace PracaDomowa2;

public class DeviceService
{
    private readonly IDeivceRepository _repository;

    public DeviceService(IDeivceRepository repository)
    {
        _repository = repository;
    }

    public void AddDevice(Device device) => _repository.Add(device);

    public Device GetDevice(int id) => _repository.GetById(id);

    public IEnumerable<Device> GetAvailableDevices() 
    {
        return _repository.GetAll().Where(d => d.Available);
    }

    public void setStatus(int id, bool status)
    {
        var device = _repository.GetById(id);
        if (device != null)
        {
            device.Available = status;
        }
    }

    public void MarkAsUnavailable(int id)
    {
        setStatus(id, false);
    }
}