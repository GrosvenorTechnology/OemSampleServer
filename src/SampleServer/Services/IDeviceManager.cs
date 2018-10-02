namespace SampleServer.Services
{
    public interface IDeviceManager
    {
        IDevice GetController(string serialNumber);
    }
}