using System;
using System.Threading.Tasks;
using AutoMapper;
using DatingTime.Accounts.Applications.AccountManagement.Commands.AccountManagement;
using DatingTime.Accounts.Applications.AccountManagement.Models;
using DatingTime.Common.Applications.Security.Commands.PasswordEncryption;
using DatingTime.Common.Applications.Security.Models;
using DatingTime.Common.Domain.Interfaces.Generators;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DatingTime.Services.Api.Controllers
{
    // http://localhost:44312/api/account/ --> A variável [controller] recebe o primeiro nome do controller, nesse caso o nome "Account".
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        // Método assíncrono - Diferente dos métodos comuns(síncronos), um método assíncrono permite mais de uma chamada simultânea sem que ele fique travado ou esperando ele ser completado.
        // O método é executado de forma paralela.
        [HttpPost("register")]
        public async Task<IActionResult> Register(AccountRegistrationDto accountRegistrationDto)
        {
            var encryptedPassword = await EncryptPassword(accountRegistrationDto.Password);

            accountRegistrationDto.Password = encryptedPassword.PasswordHash.ToString();

            var accountManagementCommand = new AccountManagementCommand(accountRegistrationDto);


            //var registeredUser = await _mediator.Send(accountRegistrationCommand);

            // return Created(nameof(Register), registeredUser);
            return null;
        }

        private async Task<PasswordEncryptionDto> EncryptPassword(string password)
        {
            try
            {
                PasswordEncryptionDto passwordEncryptionDto = new PasswordEncryptionDto(password);
                var passwordEncryptionCommand = new PasswordEncryptionCommand(passwordEncryptionDto);

                return await _mediator.Send(passwordEncryptionCommand);
            }

            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}