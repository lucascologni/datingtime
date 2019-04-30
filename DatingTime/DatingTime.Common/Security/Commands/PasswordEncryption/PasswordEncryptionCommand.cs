using System.Runtime.Serialization;
using DatingTime.Common.Security.Models;
using MediatR;

namespace DatingTime.Common.Security.Commands.PasswordEncryption
{
    public class PasswordEncryptionCommand : IRequest<PasswordEncryptionDto>
    {
        [DataMember]
        public PasswordEncryptionDto PasswordEncryptionDTO { get; set; }

        public PasswordEncryptionCommand(PasswordEncryptionDto passwordEncryptionDTO)
        {
            PasswordEncryptionDTO = passwordEncryptionDTO;
        }
    }
}