using DatingTime.Common.Domain.Entities;
using System.Threading.Tasks;

namespace DatingTime.Common.Domain.Interfaces.Generators
{
    public interface IPasswordHashGenerator
    {
        Task<Password> Generate(Password password);

        Task<bool> Verify(Password password);
    }
}