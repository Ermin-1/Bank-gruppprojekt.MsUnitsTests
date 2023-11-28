using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_gruppprojekt
{
    public class UserAccountManager 
    {
        private static List<User> users;  

        static UserAccountManager()
        {
            
            users = new List<User>
        {
            new User("Ermin", 1111),
            new User("Oskar", 1234),
            new User("Ludde", 3545),
            new User("Isac", 4355)
        };

            users[0].Accounts.Add(new Account("USA-account", 2000, "USD"));
            users[0].Accounts.Add(new Account("Household", 52000, "SEK"));
            users[0].Accounts.Add(new Account("Savings", 9000, "SEK"));

            users[1].Accounts.Add(new Account("USA-account", 1500, "USD"));
            users[1].Accounts.Add(new Account("Padel", 80000, "SEK"));

            users[2].Accounts.Add(new Account("Main", 500, "SEK"));
            users[2].Accounts.Add(new Account("Savings", 10000, "SEK"));
            users[2].Accounts.Add(new Account("USA-account", 3200, "USD"));
            users[2].Accounts.Add(new Account("Trip", 70000, "SEK"));

            users[3].Accounts.Add(new Account("Main", 2500, "SEK"));
            users[3].Accounts.Add(new Account("USA-account", 10, "USD"));
            users[3].Accounts.Add(new Account("Household", 50000, "SEK"));
            users[3].Accounts.Add(new Account("Gym", 300, "SEK"));
            users[3].Accounts.Add(new Account("Cs skins", 25000, "SEK"));
        }

        public static List<User> GetUsersWithAccounts()
        {
            return users;
        }

        public static User AuthenticateUser(string username, int pin)
        {
            return users.FirstOrDefault(u => u.Username == username && u.Pin == pin);
        }
    }
}
