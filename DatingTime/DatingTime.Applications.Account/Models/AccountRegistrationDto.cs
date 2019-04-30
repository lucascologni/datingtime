namespace DatingTime.Account.Models
{
    public class AccountRegistrationDto
    {
        public AccountRegistrationDto(string username, string passwordString)
        {
            Username = username;
            Password = passwordString;
        }

        public string Username { get; set; }
        public string Password { get; set; }
    }
}