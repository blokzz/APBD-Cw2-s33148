namespace PracaDomowa2;

public interface IDeivceRepository
{
    void Add(Device device);
    Device GetById(int id);
    IEnumerable<Device> GetAll();
}