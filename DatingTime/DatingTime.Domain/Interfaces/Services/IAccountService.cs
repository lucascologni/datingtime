using System.Threading.Tasks;
using DatingTime.Domain.Entities;

namespace DatingTime.Domain.Interfaces.Services
{
    public interface IAccountService
    {
        Task<User> Register(User user);

        Task<User> Login(string username, string password);

        Task<bool> UserExists(string username);
    }
}