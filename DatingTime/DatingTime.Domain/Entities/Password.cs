namespace DatingTime.Domain.Entities
{
    public class Password
    {
        public Password(string passwordString)
        {
            PasswordString = passwordString;
        }

        public string PasswordString { get; set; }

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }
    }
}