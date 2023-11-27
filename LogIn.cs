using BankApplication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_gruppprojekt
{
    public class LogIn : UserAccountManager , IBankServices
    {
        private const int MaxLoginAttempts = 3;
        public static void Menu(User currentUser)
        {
            
            Console.WriteLine($"Welcome {currentUser.Username}");
            int option = 0;

            do
            {
                PrintOptions();
                try
                {
                    if (int.TryParse(Console.ReadLine(), out option))
                    {
                        switch (option)
                        {
                            case 1:
                                IBankServices.Deposit(currentUser);
                                break;
                            case 2:
                                IBankServices.Withdraw(currentUser);
                                break;
                            case 3:
                                IBankServices.ShowBalance(currentUser);
                                break;
                            case 4:
                                IBankServices.AddNewAccount(currentUser);
                                break;
                            case 5:
                                IBankServices.TransferMoney(currentUser);
                                break;
                            case 6:
                                Console.WriteLine("Exiting...");
                                break;
                            default:
                                Console.WriteLine("Invalid option. Try again.");
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a valid number.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            } while (option != 5);
        }
        private static int GetPin()
        {
            Console.WriteLine("Enter PIN");
            return int.Parse(Console.ReadLine());
        }
        public static User LoginIn()
        {
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
                        Menu(currentUser);
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
            }
            Console.WriteLine("Too many unsuccessful login attempts. You are now locked out");
            Thread.Sleep(2000);
            return currentUser;
        }
        public static void PrintOptions()
        {
            Console.WriteLine("Choose from the menu");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdrawal");
            Console.WriteLine("3. Show balance");
            Console.WriteLine("4. Add new account");
            Console.WriteLine("5. Transfer money");
            Console.WriteLine("6. Exit");
        }

    }
    
}
