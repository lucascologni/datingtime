namespace DatingTime.Common.Security.Models
{
    public class PasswordEncryptionDto
    {
        public PasswordEncryptionDto(string passwordString)
        {
            PasswordString = passwordString;
        }
        
        public string PasswordString { get; set; }

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }
    }
}