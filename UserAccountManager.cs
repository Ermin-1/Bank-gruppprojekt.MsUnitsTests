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
           
            users[0].Accounts.Add(new Account("Savings", 2000));
            users[1].Accounts.Add(new Account("Checking", 1500));
            users[2].Accounts.Add(new Account("Savings", 3000));
            users[3].Accounts.Add(new Account("Checking", 2500));
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
