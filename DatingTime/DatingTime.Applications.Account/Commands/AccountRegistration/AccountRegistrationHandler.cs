using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DatingTime.Account.Models;
using DatingTime.Domain.Entities;
using DatingTime.Domain.Interfaces.Services;
using MediatR;

namespace DatingTime.Account.Commands.AccountRegistration
{
    public class AccountRegistrationHandler : IRequestHandler<AccountRegistrationCommand, AccountRegistrationDto>
    {
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;

        public AccountRegistrationHandler(IAccountService accountService, IMapper mapper)
        {
            _accountService = accountService;
            _mapper = mapper;
        }

        public async Task<AccountRegistrationDto> Handle(AccountRegistrationCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(request.UserAuthenticationDTO);

            var registeredUser = await _accountService.Register(user);

            return _mapper.Map<AccountRegistrationDto>(registeredUser);
        }
    }
}