using System;
using System.Threading.Tasks;
using AutoMapper;
using DatingTime.Applications.Account.Commands.AccountRegistration;
using DatingTime.Applications.Account.Models;
using DatingTime.Applications.Security.Models;
using DatingTime.Applications.Security.Requests.Commands.PasswordEncryption;
using DatingTime.Domain.Entities;
using DatingTime.Domain.Interfaces.Generators;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.WebEncoders.Testing;

namespace DatingTime.Services.Api.Controllers
{
    // http://localhost:44360/api/user/ --> A variável [controller] recebe o primeiro nome do controller, nesse caso o nome "User".
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IPasswordHashGenerator _passwordHashGenerator;

        public UserController(IMediator mediator, IMapper mapper, IPasswordHashGenerator passwordHashGenerator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _passwordHashGenerator = passwordHashGenerator;
        }

        // Método assíncrono - Diferente dos métodos comuns(síncronos), um método assíncrono permite mais de uma chamada simultânea sem que ele fique travado ou esperando ele ser completado.
        // O método é executado de forma paralela.
        [HttpPost("register")]
        public async Task<IActionResult> Register(AccountRegistrationDto userAuthenticationDTO)
        {
            var encryptedPassword = await EncryptPassword(userAuthenticationDTO.Password);
            //userAuthenticationDTO.PasswordDTO = encryptedPassword;

            var accountRegistrationCommand = new AccountRegistrationCommand(userAuthenticationDTO);
            var registeredUser = await _mediator.Send(accountRegistrationCommand);

            return Created(nameof(Register), registeredUser);
        }

        private async Task<PasswordEncryptionDto> EncryptPassword(string passwordDTO)
        {
            try
            {
                Password teste = new Password(passwordDTO);
                await _passwordHashGenerator.Generate(teste);

                PasswordEncryptionDto pedto = new PasswordEncryptionDto(passwordDTO);
                var passwordEncryptionCommand = new PasswordEncryptionCommand(pedto);
                await _mediator.Send(passwordEncryptionCommand);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return null;
        }
    }
}