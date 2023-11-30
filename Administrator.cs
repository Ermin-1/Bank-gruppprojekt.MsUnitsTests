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
            new Administrator("Admin", 7777)

            };
        }
        public void AdminCreateUser(Administrator adminUser)
        {
            if (adminUser == null || !Administrators.Contains(adminUser))
            {
                Console.WriteLine("Insufficient privileges. Only admins can create users.");
                return;
            }

            Console.WriteLine("Admin Console - Create New User");
            Console.WriteLine("-------------------------------");

            Console.Write("Enter username of new User (letters only): ");
            string username = Console.ReadLine();

            Console.Write("Enter four-digit PIN: ");
            if (!int.TryParse(Console.ReadLine(), out int pin))
            {
                Console.WriteLine("Invalid PIN format. Please enter a valid four-digit PIN.");
                return;
            }

            Customer newUser = CreateUser(username, pin);

            if (newUser != null)
            {
                Customer.AddUser(newUser); // Add the new user to the Customers list
                Console.WriteLine($"User created successfully: {newUser.Username}, PIN: {newUser.Pin}");
            }
            else
            {
                Console.WriteLine("User creation failed. Please check the input and try again.");
            }
        }


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
            Console.WriteLine($"Welcome {currentAdmin.Username}, you are in the Admin Menu.");
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
                              
                                break;
                           
                            case 2:
                                currentAdmin.AdminCreateUser(currentAdmin);
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
            } while (option != 3);
        }

        public static void PrintOptions()
        {
            Console.WriteLine("Choose from the menu");
            Console.WriteLine("1. ");
            Console.WriteLine("2. Create User");
            Console.WriteLine("3. Exit");
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
