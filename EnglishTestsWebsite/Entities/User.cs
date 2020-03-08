using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class User
    {
        public int UserId { get; set; }

        // Username must be unique
        public string Username { get; set; }
        public string Password { get; set; }
        
        // Key - id of the test, value - maximum amount of correct answers for this test 
        public Dictionary<int?, int?> Scores { get; set; }

        public User(string username, string password)
        {
            Username = username;
            Password = password;
            Scores = new Dictionary<int?, int?>();
        }

        public User()
        {
            Scores = new Dictionary<int?, int?>();
        }
    }
}
