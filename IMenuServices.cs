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
            Console.WriteLine("6. Check history of withdrawls and deposits");
            Console.WriteLine("7. Create User [ADMIN]");
            Console.WriteLine("8. Exit");
        }
        public static void Menu(User currentUser, ILog log, List<User> allUsers)
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
                                Deposit(currentUser, log);
                                break;
                            case 2:
                                Withdraw(currentUser, log);
                                break;
                            case 3:
                                ShowBalance(currentUser);
                                break;
                            case 4:
                                AddNewAccount(currentUser);
                                break;
                            case 5:
                                TransferMoney(currentUser, allUsers);
                                break;
                            case 6:
                                PrintLogBois(log);
                                break;
                            case 7:
                                Administrator admin = new Administrator();
                                admin.AdminCreateUser(currentUser);
                                break;
                            case 8:
                                Console.WriteLine("Exiting...");
                                LogIn.LoginIn(log, allUsers);
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
            } while (option != 8);
        }
    }
}
