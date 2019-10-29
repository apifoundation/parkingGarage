using System.Threading.Tasks;

namespace GarageApp
{
    public interface IDevice
    {

        Task PrintAsync(string content);

    }
}