namespace BuhtigIssueTracker.Models
{
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;

    public class User
    {
        public string UserName { get; set; }
        public string PasswordHash { get; set; }

        public static string HashPassword(string password)
        {
            return string.Join(string.Empty, SHA1.Create()
                .ComputeHash(Encoding.Default.GetBytes(password))
                .Select(x => x.ToString()));
        }

        public User(string username, string password)
        {
            UserName = username;
            PasswordHash = HashPassword(password);
        }
    }
}
