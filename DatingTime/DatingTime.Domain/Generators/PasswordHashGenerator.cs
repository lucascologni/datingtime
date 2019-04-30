using static System.Text.Encoding;

using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using DatingTime.Domain.Entities;
using DatingTime.Domain.Interfaces.Generators;

namespace DatingTime.Domain.Generators
{
    public class PasswordHashGenerator : IPasswordHashGenerator
    {
        public async Task<Password> Generate(Password password)
        {
            /*
             * A classe 'HMACSHA512" possui o método "Dispose()", então é possível criar o ojeto somente num escopo específico.
             * Após o término da execução desse escopo, o objeto "hmac" é descartado.
             */

            using (var hmac = new HMACSHA512()) // Essa classe gera uma chave 'Random' do tipo HMACSHA512 para criptografia.
            {
                password.PasswordSalt = hmac.Key;
                password.PasswordHash = hmac.ComputeHash(UTF8.GetBytes(password.PasswordString));
            }

            return await Task.FromResult(password);
        }

        public Task<bool> Verify(Password password)
        {
            using (var hmac = new HMACSHA512(password.PasswordSalt))
            {
                var computedHash = hmac.ComputeHash(UTF8.GetBytes(password.PasswordString));

                // Vai comparar cada posição do byte "computedHash" verificando se é igual ao "passwordHash" do usuário.
                if (computedHash.Where((c, i) => c != password.PasswordHash[i]).Any())
                    return Task.FromResult(false);
            }

            return Task.FromResult(true);
        }
    }
}