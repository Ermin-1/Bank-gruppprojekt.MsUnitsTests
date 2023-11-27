using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_gruppprojekt
{
    public interface IMenuServices : IBankServices
    {
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
        public static void Menu(User currentUser)
        {
            Console.Clear();
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
                                Deposit(currentUser);
                                break;
                            case 2:
                                Withdraw(currentUser);
                                break;
                            case 3:
                                ShowBalance(currentUser);
                                break;
                            case 4:
                                AddNewAccount(currentUser);
                                break;
                            case 5:
                                TransferMoney(currentUser);
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
            } while (option != 6);
        }
    }
}
