using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_gruppprojekt
{
    public class CustomerAccountManager 
    {
        private static List<Customer> Customers;  

        static CustomerAccountManager()
        {
            
            Customers = new List<Customer>
        {
            new Customer("Ermin", 1111),
            new Customer("Oskar", 1234),
            new Customer("Ludde", 3545),
            new Customer("Isac", 4355)
        };

            Customers[0].Accounts.Add(new Account("USA-account", 2000, "USD"));
            Customers[0].Accounts.Add(new Account("Household", 52000, "SEK"));
            Customers[0].Accounts.Add(new Account("Savings", 9000, "SEK"));

            Customers[1].Accounts.Add(new Account("USA-account", 1500, "USD"));
            Customers[1].Accounts.Add(new Account("Padel", 80000, "SEK"));

            Customers[2].Accounts.Add(new Account("Main", 500, "SEK"));
            Customers[2].Accounts.Add(new Account("Savings", 10000, "SEK"));
            Customers[2].Accounts.Add(new Account("USA-account", 3200, "USD"));
            Customers[2].Accounts.Add(new Account("Trip", 70000, "SEK"));

            Customers[3].Accounts.Add(new Account("Main", 2500, "SEK"));
            Customers[3].Accounts.Add(new Account("USA-account", 10, "USD"));
            Customers[3].Accounts.Add(new Account("Household", 50000, "SEK"));
            Customers[3].Accounts.Add(new Account("Gym", 300, "SEK"));
            Customers[3].Accounts.Add(new Account("Cs skins", 25000, "SEK"));
        }

        public static List<Customer> GetCustomerWithAccounts()
        {
            return Customers;
        }

        public static Customer AuthenticateCustomer(string username, int pin)
        {
            return Customers.FirstOrDefault(u => u.Username == username && u.Pin == pin);
        }
    }
}
