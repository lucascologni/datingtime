namespace DatingTime.Accounts.Domain.Entities
{
    public class Account
    {
        public Account(string username, Password password)
        {
            Username = username;
            Password = password;
        }

        public int Id { get; set; }

        public string Username { get; set; }

        public Password Password { get; set; }
    }
}