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
        public double MaxLoan { get; set; }
        public string Username { get; set; }
        public int Pin { get; set; }
        public List<Account> Accounts { get; set; }        
        public User(string username, int pin)
        {
            Username = username;
            Pin = pin;
            Accounts = new List<Account>();          
        }
        

        public void AddAccount(string accountType, double initialBalance, string currency)
        {
            Accounts.Add(new Account(accountType, initialBalance, currency));
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
