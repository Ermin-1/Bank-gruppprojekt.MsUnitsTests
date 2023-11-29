using BankApplication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_gruppprojekt
{
    public class LogIn : CustomerAccountManager , ICustomerBank , IMenuServices
    {
        public const int MaxLoginAttempts = 3;

        private static int GetPin()
        {
            Console.WriteLine("Enter PIN");
            return int.Parse(Console.ReadLine());
        }
        public static Customer LoginIn(ILog log, List<Customer> allUsers)
        {
            Console.Clear();
            GetCustomerWithAccounts();
            Console.WriteLine("Welcome to the bank");
            string username = "";
            Customer currentUser = null;
            int loginAttempts = 0;

            while (loginAttempts < MaxLoginAttempts)
            {
                try
                {
                    Console.WriteLine("Enter username: ");
                    username = Console.ReadLine();
                    currentUser = AuthenticateCustomer(username, GetPin());
                    if (currentUser != null)
                    {

                        Customer.Menu(currentUser, log, allUsers);
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"User not found or incorrect PIN. Attempts left: {MaxLoginAttempts - loginAttempts - 1}");
                        loginAttempts++;
                    } 
                }
                catch
                {
                    Console.WriteLine($"User not found or incorrect PIN. Attempts left: {MaxLoginAttempts - loginAttempts - 1}");
                    loginAttempts++;
                }
                if (loginAttempts == 3) 
                {
                    Console.WriteLine("Too many unsuccessful login attempts. You are now locked out");
                    Thread.Sleep(2000);
                }
            }

            return currentUser;
        }
    }    
}
