using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Bank_gruppprojekt
{
    public class Administrator
    {
        public Administrator()
        {

        }

        public void AdminCreateUser(User adminUser)
        {
            if (adminUser == null || !adminUser.IsAdmin)
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

            User newUser = CreateUser(username, pin);

            if (newUser != null)
            {
                Console.WriteLine($"User created successfully: {newUser.Username}, PIN: {newUser.Pin}");
            }
            else
            {
                Console.WriteLine("User creation failed. Please check the input and try again.");
            }
        }

        public User CreateUser(string username, int pin)
        {
            if (string.IsNullOrWhiteSpace(username) || !username.All(char.IsLetter) || pin < 1000 || pin > 9999)
            {
                Console.WriteLine("Invalid input for creating a new user. Please provide a valid username and a four-digit PIN.");
                return null;
            }

            if (UserAccountManager.GetUsersWithAccounts().Any(u => u.Username == username))
            {
                Console.WriteLine($"Username '{username}' is already taken. Please choose a different username.");
                return null;
            }

            User newUser = new User(username, pin);

            Console.WriteLine($"New user created: {newUser.Username} with PIN: {pin}");

            return newUser;
        }
    }
}
