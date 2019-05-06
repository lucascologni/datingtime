namespace DatingTime.Accounts.Applications.AccountManagement.Models
{
    public class AccountRegistrationDto
    {
        public AccountRegistrationDto(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public string Username { get; set; }

        public string Password { get; set; }
    }
}