using System;

namespace MindfulnessApp
{
    public class User
    {
        public string Username { get; set; }
        public string Email { get; set; }

        public User(string username, string email)
        {
            Username = username;
            Email = email;
        }

        public override string ToString()
        {
            return $"{Username} - {Email}";
        }

        // Converts user to a savable text line
        public string ToFileFormat()
        {
            return $"{Username}|{Email}";
        }

        // Reads user data from file line
        public static User FromFileFormat(string line)
        {
            string[] parts = line.Split('|');
            if (parts.Length == 2)
                return new User(parts[0], parts[1]);
            return null;
        }
    }
}
