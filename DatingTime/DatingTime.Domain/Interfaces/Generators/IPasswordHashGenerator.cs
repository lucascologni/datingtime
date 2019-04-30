using System.Threading.Tasks;
using DatingTime.Domain.Entities;

namespace DatingTime.Domain.Interfaces.Generators
{
    public interface IPasswordHashGenerator
    {
        Task<Password> Generate(Password password);

        Task<bool> Verify(Password password);
    }
}