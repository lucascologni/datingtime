using System.Threading;
using System.Threading.Tasks;
using DatingTime.Common.Security.Models;
using AutoMapper;
using MediatR;

namespace DatingTime.Common.Security.Commands.PasswordEncryption
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