using BankApplication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_gruppprojekt
{
    public class LogIn : UserAccountManager , IBankServices , IMenuServices
    {
        public const int MaxLoginAttempts = 3;

        private static int GetPin()
        {
            Console.WriteLine("Enter PIN");
            return int.Parse(Console.ReadLine());
        }
        public static User LoginIn()
        {
            Console.Clear();
            GetUsersWithAccounts();
            Console.WriteLine("Welcome to the bank");
            string username = "";
            User currentUser = null;
            int loginAttempts = 0;

            while (loginAttempts < MaxLoginAttempts)
            {
                try
                {
                    Console.WriteLine("Enter username: ");
                    username = Console.ReadLine();
                    currentUser = AuthenticateUser(username, GetPin());
                    if (currentUser != null)
                    {
                        IMenuServices.Menu(currentUser);
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
