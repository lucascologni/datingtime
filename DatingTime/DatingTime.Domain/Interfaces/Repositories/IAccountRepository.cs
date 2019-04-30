using System.Threading.Tasks;
using DatingTime.Domain.Entities;

namespace DatingTime.Domain.Interfaces.Repositories
{
    public interface IAccountRepository
    {
        Task<User> Register(User user);

        Task<User> Login(string username, string password);

        Task<bool> UserExists(string username);
    }
}