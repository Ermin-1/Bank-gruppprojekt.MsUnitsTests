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
            Console.WriteLine("Enter username: ");
            string username = "";
            User currentUser = null;

            while (true)
            {
                try
                {
                    username = Console.ReadLine();
                    currentUser = AuthenticateUser(username, GetPin());
                    if (username != null)
                    {
                        Menu(currentUser);
                    }
                    else if(currentUser == null)
                    {
                        Console.WriteLine("User not found or incorrect PIN. Please try again.");
                    }
                    else
                    {
                        break;
                    }
                }
                catch
                {
                    Console.WriteLine("Error finding user");
                }
            }

            return currentUser;
        }
        public static void PrintOptions()
        {
            Console.WriteLine("Choose from the menu");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdrawal");
            Console.WriteLine("3. Show balance");
            Console.WriteLine("4. Add new account");
            Console.WriteLine("5. Exit");
        }

    }
    
}
