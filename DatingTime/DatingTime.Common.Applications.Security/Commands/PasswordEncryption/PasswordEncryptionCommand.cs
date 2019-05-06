using DatingTime.Common.Applications.Security.Models;
using MediatR;

namespace DatingTime.Common.Applications.Security.Commands.PasswordEncryption
{
    public class PasswordEncryptionCommand : IRequest<PasswordEncryptionDto>
    {
        public PasswordEncryptionDto PasswordEncryptionDto { get; set; }

        public PasswordEncryptionCommand(PasswordEncryptionDto passwordEncryptionDto)
        {
            PasswordEncryptionDto = passwordEncryptionDto;
        }
    }
}