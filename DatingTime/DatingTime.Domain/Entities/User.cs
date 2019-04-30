namespace DatingTime.Domain.Entities
{
    public class User
    {
        public User(string username, Password password)
        {
            Username = username;
            Password = password;
        }

        public int Id { get; set; }

        public string Username { get; set; }

        public Password Password { get; set; }
    }
}