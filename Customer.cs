using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Bank_gruppprojekt
{
    public class Customer : User, ICustomerBank, IMenuServices
    {
        public const int MaxLoginAttempts = 3;
        public List<Account> Accounts { get; set; }

        private static List<Customer> Customers;



        static Customer()
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
            Customers[3].Accounts.Add(new Account("USA-account", 1000, "USD"));
            Customers[3].Accounts.Add(new Account("Household", 50000, "SEK"));
            Customers[3].Accounts.Add(new Account("Gym", 300, "SEK"));
            Customers[3].Accounts.Add(new Account("Cs skins", 25000, "SEK"));
        }

        public Customer (string userName, int pin) : base (userName, pin)
        {
            Username = userName;
            Pin = pin;
            Accounts = new List<Account>();
        }

        public static void Deposit(Customer currentCustomer, ILog log)
        {
            Console.WriteLine("Which account do you want to deposit into?");
            currentCustomer.DisplayAccounts(currentCustomer);

            if (int.TryParse(Console.ReadLine(), out int accountIndex) && accountIndex >= 0 && accountIndex < currentCustomer.Accounts.Count)
            {
                Console.WriteLine("How much money do you want to deposit?");
                if (double.TryParse(Console.ReadLine(), out double deposit))
                {

                    currentCustomer.Accounts[accountIndex].Balance += deposit;
                    Console.WriteLine($"Your new balance for {currentCustomer.Accounts[accountIndex].Accounttype} account is {currentCustomer.Accounts[accountIndex].Balance}");

                    log.LogDeposit(deposit, currentCustomer.Accounts[accountIndex].Currency);
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
            }
            else
            {
                Console.WriteLine("Invalid account selection.");
            }
        }

        public void CreateAccount(string accountType, double initialBalance, string currency)
        {
            Accounts.Add(new Account(accountType, initialBalance, currency));
        }

        public void DisplayAccounts(Customer customer)
        {
            Console.WriteLine("Accounts:");
            for (int i = 0; i < customer.Accounts.Count; i++)
            {
                Console.WriteLine($"{i +1}. {customer.Accounts[i].Accounttype}");
            }
        }

        public static void Withdraw(Customer currentCustomer, ILog log)
        {
            Console.WriteLine("Which account do you want to withdraw from?");
            currentCustomer.DisplayAccounts(currentCustomer);

            if (int.TryParse(Console.ReadLine(), out int accountIndex) && accountIndex >= 0 && accountIndex < currentCustomer.Accounts.Count)
            {
                Console.WriteLine("How much do you want to withdraw?");
                if (double.TryParse(Console.ReadLine(), out double withdrawal))
                {
                    if (currentCustomer.Accounts[accountIndex].Balance < withdrawal)
                    {
                        Console.WriteLine("Insufficient funds");
                    }
                    else
                    {
                        currentCustomer.Accounts[accountIndex].Balance -= withdrawal;
                        Console.WriteLine($"Thank you for the withdrawal. Your new balance for {currentCustomer.Accounts[accountIndex].Accounttype} account is {currentCustomer.Accounts[accountIndex].Balance}");

                        log.LogWithdraw(withdrawal, currentCustomer.Accounts[accountIndex].Currency);
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
            }
            else
            {
                Console.WriteLine("Invalid account selection.");
            }
        }

        public static void ShowBalance(Customer currentCustomer)
        {
            Console.WriteLine("Which account balance do you want to check?");
            currentCustomer.DisplayAccounts(currentCustomer);

            if (int.TryParse(Console.ReadLine(), out int accountIndex) && accountIndex >= 0 && accountIndex < currentCustomer.Accounts.Count)
            {
                Console.WriteLine($"Your balance for {currentCustomer.Accounts[accountIndex].Accounttype} account is {currentCustomer.Accounts[accountIndex].Balance} {currentCustomer.Accounts[accountIndex].Currency}");
            }
            else
            {
                Console.WriteLine("Invalid account selection.");
            }
        }

        public static List<Customer> GetCustomerWithAccounts()
        {
            return Customers;
        }

        public static Customer AuthenticateCustomer(string username, int pin)
        {
            return Customers.FirstOrDefault(u => u.Username == username && u.Pin == pin);
        }

        public static Customer LoginIn(ILog log, List<Customer> allUsers)
        {
            Console.Clear();
            GetCustomerWithAccounts();
            Console.WriteLine("Welcome to the bank");
            string username = "";
            Customer currentCustomer = null;
            int loginAttempts = 0;

            while (loginAttempts < MaxLoginAttempts)
            {
                try
                {
                    Console.WriteLine("Enter username: ");
                    username = Console.ReadLine();
                    currentCustomer = AuthenticateCustomer(username, GetPin());
                    if (currentCustomer != null)
                    {

                        Customer.Menu(currentCustomer, log, allUsers);
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

            return currentCustomer;
        }

        public static void Menu(Customer currentCustomer, ILog log, List<Customer> allCustomers)
        {
            Console.Clear();
            Console.WriteLine($"Welcome {currentCustomer.Username}");
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
                                Deposit(currentCustomer, log);
                                break;
                            case 2:
                                Withdraw(currentCustomer, log);
                                break;
                            case 3:
                                ShowBalance(currentCustomer);
                                break;
                            case 4:
                                AddNewAccount(currentCustomer);
                                break;
                            case 5:
                                TransferMoney(currentCustomer);
                                break;
                            case 6:
                                PrintLogBois(log);
                                break;                          
                            case 7:
                                Console.WriteLine("Exiting...");
                                LogIn.LoginIn(log, allCustomers);
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

        public static void AddNewAccount(Customer currentCustomer)
        {
            Console.WriteLine("Enter the type of the new account:");
            string accountType = Console.ReadLine();

            Console.WriteLine("Enter the initial balance:");
            if (double.TryParse(Console.ReadLine(), out double initialBalance))
            {
                Console.WriteLine("Enter the currency (e.g., SEK, USD):");
                string currency = Console.ReadLine();

                currentCustomer.CreateAccount(accountType, initialBalance, currency);
                Console.WriteLine($"New {accountType} account added with an initial balance of {initialBalance} {currency}");
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }

        public static void TransferMoney(Customer currentCustomer)
        {
            Console.WriteLine("Do you want to transfer money between your own accounts or to another user?");
            Console.WriteLine("1. Own accounts");
            Console.WriteLine("2. Another user");

            if (int.TryParse(Console.ReadLine(), out int transferChoice) && (transferChoice == 1 || transferChoice == 2))
            {
                if (transferChoice == 1)
                {
                    TransferBetweenOwnAccounts(currentCustomer);
                }
                else
                {
                    TransferToAnotherUser(currentCustomer);
                }
            }
            else
            {
                Console.WriteLine("Invalid choice. Please enter 1 or 2.");
            }
        }

        private static void TransferBetweenOwnAccounts(Customer currentCustomer)
        {
            Console.WriteLine("Which account do you want to transfer money from?");
            currentCustomer.DisplayAccounts(currentCustomer);

            if (int.TryParse(Console.ReadLine(), out int fromAccountIndex) && fromAccountIndex > 0 && fromAccountIndex <= currentCustomer.Accounts.Count)
            {
                Console.WriteLine("How much money do you want to transfer?");

                if (double.TryParse(Console.ReadLine(), out double transferAmount))
                {
                    if (currentCustomer.Accounts[fromAccountIndex - 1].Balance < transferAmount)
                    {
                        Console.WriteLine("Insufficient funds for the selected account.");
                    }
                    else
                    {
                        Console.WriteLine("Which account do you want to transfer money to?");
                        currentCustomer.DisplayAccounts(currentCustomer);

                        if (int.TryParse(Console.ReadLine(), out int toAccountIndex) && toAccountIndex > 0 && toAccountIndex <= currentCustomer.Accounts.Count)
                        {
                            currentCustomer.Accounts[fromAccountIndex - 1].Balance -= transferAmount;
                            currentCustomer.Accounts[toAccountIndex - 1].Balance += transferAmount;

                            Console.WriteLine($"Thank you for the transfer. Your new balance for {currentCustomer.Accounts[fromAccountIndex - 1].Accounttype} account is {currentCustomer.Accounts[fromAccountIndex - 1].Balance} {currentCustomer.Accounts[fromAccountIndex - 1].Currency}");
                            Console.WriteLine($"New balance for {currentCustomer.Accounts[toAccountIndex - 1].Accounttype} account is {currentCustomer.Accounts[toAccountIndex - 1].Balance} {currentCustomer.Accounts[toAccountIndex - 1].Currency}");
                            
                        }
                        else
                        {
                            Console.WriteLine("Invalid account selection for receiving money.");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
            }
            else
            {
                Console.WriteLine("Invalid account selection for transferring money.");
            }
        }


        private static void TransferToAnotherUser(Customer currentCustomer)
        {
            Console.WriteLine("Which user do you want to transfer money to?");
            DisplayCustomer(Customers, currentCustomer);

            if (int.TryParse(Console.ReadLine(), out int toCustomerIndex) && toCustomerIndex > 0 && toCustomerIndex <= Customers.Count)
            {
                Customer receiver = Customers[toCustomerIndex - 1];

                Console.WriteLine("Which account do you want to transfer money from?");
                currentCustomer.DisplayAccounts(currentCustomer);

                if (int.TryParse(Console.ReadLine(), out int fromAccountIndex) && fromAccountIndex > 0 && fromAccountIndex <= currentCustomer.Accounts.Count)
                {
                    Console.WriteLine($"How much money do you want to transfer from {currentCustomer.Accounts[fromAccountIndex - 1].Accounttype}?");
                    if (double.TryParse(Console.ReadLine(), out double transferAmount))
                    {
                        if (currentCustomer.Accounts[fromAccountIndex - 1].Balance < transferAmount)
                        {
                            Console.WriteLine("Insufficient funds for the selected account.");
                        }
                        else
                        {
                            Console.WriteLine("Which account do you want to transfer money to?");
                            currentCustomer.DisplayAccounts(receiver);

                            if (int.TryParse(Console.ReadLine(), out int toAccountIndex) && toAccountIndex > 0 && toAccountIndex <= receiver.Accounts.Count)
                            {
                                currentCustomer.Accounts[fromAccountIndex - 1].Balance -= transferAmount;
                                receiver.Accounts[toAccountIndex - 1].Balance += transferAmount;

                                Console.WriteLine($"Thank you for the transfer. Your new balance for {currentCustomer.Accounts[fromAccountIndex - 1].Accounttype} account is {currentCustomer.Accounts[fromAccountIndex - 1].Balance:C2}");
                                Console.WriteLine($"New balance for {receiver.Accounts[toAccountIndex - 1].Accounttype} account is {receiver.Accounts[toAccountIndex - 1].Balance:2}");
                            }
                            else
                            {
                                Console.WriteLine("Invalid account selection for receiving money.");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a valid number.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid account selection for transferring money.");
                }
            }
            else
            {
                Console.WriteLine("Invalid user selection for transferring money.");
            }
        }

        public static void DisplayCustomer(List<Customer> customers, Customer currentCustomer)
        {
            var otherCustomer = customers.Where(customer => customer.Username != currentCustomer.Username).ToList();
            foreach (var customer in otherCustomer)
            {
                var index = customers.IndexOf(customer);
                Console.WriteLine($"{index + 1}. {customers[index].Username}");
            }
        }

        public static void PrintLogBois(ILog log)
        {
            List<string> loggersPoggers = log.GetLogBois();
            foreach (var logboi in loggersPoggers)
            {
                Console.WriteLine(logboi);
            }
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
            Console.WriteLine("7. Exit");
        }        

        private static int GetPin()
        {
            Console.WriteLine("Enter PIN");
            return int.Parse(Console.ReadLine());
        }
    }

}
        

    


