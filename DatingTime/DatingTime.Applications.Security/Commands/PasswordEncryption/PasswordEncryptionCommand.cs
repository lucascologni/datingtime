using System.Runtime.Serialization;
using DatingTime.Applications.Security.Models;
using MediatR;

namespace DatingTime.Applications.Security.Requests.Commands.PasswordEncryption
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