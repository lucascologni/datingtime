using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DatingTime.Accounts.Applications.AccountManagement.Models;
using DatingTime.Accounts.Domain.Entities;
using DatingTime.Accounts.Domain.Interfaces.Services;
using MediatR;

namespace DatingTime.Accounts.Applications.AccountManagement.Commands.AccountManagement
{
    public class AccountManagementHandler : IRequestHandler<AccountManagementCommand, AccountRegistrationDto>
    {
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;

        public AccountManagementHandler(IAccountService accountService, IMapper mapper)
        {
            _accountService = accountService;
            _mapper = mapper;
        }

        public async Task<AccountRegistrationDto> Handle(AccountManagementCommand request, CancellationToken cancellationToken)
        {
            var account = _mapper.Map<Account>(request.AccountRegistrationDto);

            var registeredAccount = await _accountService.Register(account);

            return _mapper.Map<AccountRegistrationDto>(registeredAccount);
        }
    }
}