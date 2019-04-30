using System.Runtime.Serialization;
using DatingTime.Account.Models;
using MediatR;

namespace DatingTime.Account.Commands.AccountRegistration
{
    public class AccountRegistrationCommand : IRequest<AccountRegistrationDto>
    {
        [DataMember]
        public AccountRegistrationDto UserAuthenticationDTO { get; set; }

        public AccountRegistrationCommand(AccountRegistrationDto userAuthenticationDTO)
        {
            UserAuthenticationDTO = userAuthenticationDTO;
        }
    }
}