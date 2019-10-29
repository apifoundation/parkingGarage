using System.Threading.Tasks;

namespace GarageApp
{
    public interface IEmailClient
    {

        Task EmailAsync(string email, string content);

    }
}