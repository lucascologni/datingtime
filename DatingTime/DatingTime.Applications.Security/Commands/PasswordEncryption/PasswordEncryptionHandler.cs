using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DatingTime.Applications.Security.Models;
using DatingTime.Applications.Security.Requests.Commands.PasswordEncryption;
using DatingTime.Domain.Entities;
using DatingTime.Domain.Interfaces.Generators;
using MediatR;

namespace DatingTime.Applications.Security.Commands.PasswordEncryption
{
    public class PasswordEncryptionHandler : IRequestHandler<PasswordEncryptionCommand, PasswordEncryptionDto>
    {
        private readonly IPasswordHashGenerator _passwordHashGenerator;
        private readonly IMapper _mapper;

        public PasswordEncryptionHandler(IPasswordHashGenerator passwordHashGenerator, IMapper mapper)
        {
            _passwordHashGenerator = passwordHashGenerator;
            _mapper = mapper;
        }

        public async Task<PasswordEncryptionDto> Handle(PasswordEncryptionCommand request, CancellationToken cancellationToken)
        {
            var password = new Password(request.PasswordEncryptionDTO.PasswordString);

            var encryptedPassword = await _passwordHashGenerator.Generate(password);
            
            return _mapper.Map<PasswordEncryptionDto>(encryptedPassword);
        }
    }
}