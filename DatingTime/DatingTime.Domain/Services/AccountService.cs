using System.Threading.Tasks;
using DatingTime.Domain.Entities;
using DatingTime.Domain.Interfaces.Repositories;
using DatingTime.Domain.Interfaces.Services;

namespace DatingTime.Domain.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public Task<User> Login(string username, string password)
        {
            throw new System.NotImplementedException();
        }

        public async Task<User> Register(User user)
        {
            return await _accountRepository.Register(user);
        }

        public Task<bool> UserExists(string username)
        {
            throw new System.NotImplementedException();
        }
    }
}