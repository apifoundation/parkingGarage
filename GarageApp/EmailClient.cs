using System.Threading.Tasks;

namespace GarageApp
{
    public sealed class EmailClient : IEmailClient
    {

        public Task EmailAsync(string email, string content) => Task.FromResult(true);

    }
}