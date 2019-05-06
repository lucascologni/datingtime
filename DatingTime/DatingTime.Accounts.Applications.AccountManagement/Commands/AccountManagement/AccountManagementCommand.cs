using DatingTime.Accounts.Applications.AccountManagement.Models;
using MediatR;

namespace DatingTime.Accounts.Applications.AccountManagement.Commands.AccountManagement
{
    public class AccountManagementCommand : IRequest<AccountRegistrationDto>
    {
        public AccountRegistrationDto AccountRegistrationDto { get; set; }

        public AccountManagementCommand(AccountRegistrationDto accountRegistrationDto)
        {
            AccountRegistrationDto = accountRegistrationDto;
        }
    }
}