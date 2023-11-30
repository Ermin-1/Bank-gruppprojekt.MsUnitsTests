using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Bank_gruppprojekt
{
    public class Administrator : User , ILogInServices
    {
        public const int MaxLoginAttempts = 3;
        public Administrator(string userName, int pin) : base(userName, pin)
        {

        }

        private static List<Administrator> Administrators;
        static Administrator()
        {

            Administrators = new List<Administrator>
            {
            new Administrator("Karen", 0000),

            };
        }
        //    public void AdminCreateUser(Administrator adminUser)
        //    {
        //    if (adminUser == null || !adminUser.IsAdmin)
        //    {
        //        Console.WriteLine("Insufficient privileges. Only admins can create users.");
        //        return;
        //    }

        //    Console.WriteLine("Admin Console - Create New User");
        //    Console.WriteLine("-------------------------------");

        //    Console.Write("Enter username of new User (letters only): ");
        //    string username = Console.ReadLine();

        //    Console.Write("Enter four-digit PIN: ");
        //    if (!int.TryParse(Console.ReadLine(), out int pin))
        //    {
        //        Console.WriteLine("Invalid PIN format. Please enter a valid four-digit PIN.");
        //        return;
        //    }

        //    Customer newUser = CreateUser(username, pin);

        //    if (newUser != null)
        //    {
        //        Console.WriteLine($"User created successfully: {newUser.Username}, PIN: {newUser.Pin}");
        //    }
        //    else
        //    {
        //        Console.WriteLine("User creation failed. Please check the input and try again.");
        //    }
        //}

        public Customer CreateUser(string username, int pin)
        {
            if (string.IsNullOrWhiteSpace(username) || !username.All(char.IsLetter) || pin < 1000 || pin > 9999)
            {
                Console.WriteLine("Invalid input for creating a new user. Please provide a valid username and a four-digit PIN.");
                return null;
            }

            if (CustomerAccountManager.GetCustomerWithAccounts().Any(u => u.Username == username))
            {
                Console.WriteLine($"Username '{username}' is already taken. Please choose a different username.");
                return null;
            }

            Customer newUser = new Customer(username, pin);

            Console.WriteLine($"New user created: {newUser.Username} with PIN: {pin}");

            return newUser;
        }

        public static void Menu(Administrator currentAdmin)
        {
            
            Console.Clear();
            Console.WriteLine($"Welcome King {currentAdmin.Username}");
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
                                //Deposit(currentUser, log);
                                break;
                           
                            case 2:
                                //Administrator admin = new Administrator();
                                //admin.AdminCreateUser(currentUser);
                                break;
                            case 3:
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
            } while (option != 8);
        }

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
        public static Administrator AuthenticateAdministrator(string username, int pin)
        {
            return Administrators.FirstOrDefault(u => u.Username == username && u.Pin == pin);
        }

        public static Administrator AuthenticateAdministrator(string username, string pin)
        {
            Console.WriteLine($"Attempting to authenticate administrator: {username}, PIN: {pin}");

            if (int.TryParse(pin, out int pinValue))
            {
                Console.WriteLine($"Parsed PIN as integer: {pinValue}");

                Administrator authenticatedAdministrator = Administrators.FirstOrDefault(u => u.Username.Trim().Equals(username, StringComparison.OrdinalIgnoreCase) && u.Pin == pinValue);

                if (authenticatedAdministrator != null)
                {
                    Console.WriteLine($"Authentication successful for administrator: {username}");
                }
                else
                {
                    Console.WriteLine($"Authentication failed for administrator: {username}");
                }

                return authenticatedAdministrator;
            }
            else
            {
                Console.WriteLine($"Invalid PIN format for administrator: {username}");
                return null;
            }
        }
        public static string GetPin()
        {
            Console.WriteLine("Enter PIN");
            return Console.ReadLine();
        }
    }
}
