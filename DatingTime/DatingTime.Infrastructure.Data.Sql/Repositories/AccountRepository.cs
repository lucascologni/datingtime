using System;
using System.Threading.Tasks;
using DatingTime.Domain.Entities;
using DatingTime.Domain.Interfaces.Repositories;

namespace DatingTime.Infrastructure.Data.Sql.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        public Task<User> Register(User user)
        {
            throw new NotImplementedException();
        }

        public Task<User> Login(string username, string password)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UserExists(string username)
        {
            throw new NotImplementedException();
        }
    }
}