using DatingTime.Accounts.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DatingTime.Accounts.Domain.Interfaces.Services
{
    public interface IAccountService
    {
        Task<Account> Register(Account account);

        Task<Account> Update(Account account);

        Task<Account> Delete(int accountId);

        Task<Account> Login(string username, string password);

        Task<bool> Exists(int accountId);

        Task<Account> GetById(int accountId);

        Task<List<Account>> GetAll();
    }
}