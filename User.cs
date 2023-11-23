using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Bank_gruppprojekt
{
    public class User
    {                      
        public string Username;
        public string Password;
        public string AccountOwner;
        
        static User Ermin = new User("Ermin", "1", "Ermin Husic");
        static User Ludwig = new User("Ludwig", "2", "Ludwig Svensson");
        static User Isak = new User("Oskar", "3", "Oskar Johansson");
        static User Oskar = new User("Isak", "4", "Isak Elfstrand");
        public List<User> userList = new List<User>() { Ermin, Ludwig, Oskar, Isak };

        public List<List<string>> ACCOUNTNAME = new List<List<string>>
        {
            new List<string> { "Lönekonto", "Sparkonto", "Privatkonto", "Huskonto", "Rainyday-fun" },
            new List<string> { "Lönekonto", "Sparkonto", "Privatkonto", "Huskonto" },
            new List<string> { "Lönekonto", "Sparkonto", "Privatkonto" },
            new List<string> { "Lönekonto", "Sparkonto" },

        };

        public List<List<decimal>> ACCOUNTBALANCE = new List<List<decimal>>
        {
            new List<decimal> { 27500.0m, 300000.0m, 50000.0m, 20000.0m, 100000.0m },
            new List<decimal> { 42000.0m, 200000.0m, 150000.0m, 60000.0m },
            new List<decimal> { 25000.0m, 46000.0m, 450000.0m },
            new List<decimal> { 15000.0m, 10000.0m },

        };

        //public Dictionary<string, int> userInfo = new Dictionary<string, int>
        //{
        //    {"Ermin", 1},
        //    {"Ludwig", 2},
        //    {"Oskar", 3},
        //    {"Isak", 4}
        //};
        
        public User(string userName, string passWord, string accountOwner)
        {
            User currentuser;
            Username = userName;
            Password = passWord;
            AccountOwner = accountOwner;
        }
        public User DoesUserMatch(string userName, string passWord)
        {           
            foreach (User user in userList)
            {
                if (user != null && user.Username == userName && user.Password == passWord)
                {
                    return user; 
                }
            }
            return null;
        }
    }
}
