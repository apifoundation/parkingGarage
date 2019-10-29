using System.Threading.Tasks;

namespace GarageApp
{
    public sealed class Device: IDevice
    {

        public Task PrintAsync(string content) => Task.FromResult(true);

    }
}