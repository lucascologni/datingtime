using System.Collections.Generic;
using System.Threading.Tasks;
using DatingTime.Accounts.Domain.Entities;
using DatingTime.Accounts.Domain.Interfaces.Services;

namespace DatingTime.Accounts.Domain.Services
{
    public class AccountService : IAccountService
    {
        public Task<Account> Register(Account account)
        {
            throw new System.NotImplementedException();
        }

        public Task<Account> Update(Account account)
        {
            throw new System.NotImplementedException();
        }

        public Task<Account> Delete(int accountId)
        {
            throw new System.NotImplementedException();
        }

        public Task<Account> Login(string username, string password)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Exists(int accountId)
        {
            throw new System.NotImplementedException();
        }

        public Task<Account> GetById(int accountId)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<Account>> GetAll()
        {
            throw new System.NotImplementedException();
        }
    }
}