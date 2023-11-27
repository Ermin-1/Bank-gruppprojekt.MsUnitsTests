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
        public string Username { get; set; }
        public int Pin { get; set; }
        public List<Account> Accounts { get; set; }
        //public List<User> Users { get; set; }

        public User(string username, int pin)
        {
            Username = username;
            Pin = pin;
            Accounts = new List<Account>();
            //Users = new List<User>();

            //Users = new List<User>
            //{
            //    new User("Ermin", 1111),
            //    new User("Oskar", 1234),
            //    new User("Ludde", 3545),
            //    new User("Isac", 4355)
            //};

            //Users[0].AddAccount("Savings", 2000);
            //Users[0].AddAccount("Checking", 1000);

            //Users[1].AddAccount("Savings", 1500);
            //Users[1].AddAccount("Checking", 500);

            //Users[2].AddAccount("Savings", 3000);
            //Users[2].AddAccount("Checking", 2000);

            //Users[3].AddAccount("Savings", 2500);
            //Users[3].AddAccount("Checking", 1200);
        }
        

        public void AddAccount(string accountType, double initialBalance)
        {
            Accounts.Add(new Account(accountType, initialBalance));
        }
        public void DisplayAccounts(User user)
        {
            Console.WriteLine("Accounts:");
            for (int i = 0; i < user.Accounts.Count; i++)
            {
                Console.WriteLine($"{i}. {user.Accounts[i].Accounttype}");
            }
        }
      
    }
}
