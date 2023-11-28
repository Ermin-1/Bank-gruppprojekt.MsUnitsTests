using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_gruppprojekt
{
    public interface IBankServices 
    {        

        public static void Deposit(User currentUser, ILog log)
        {
            Console.WriteLine("Which account do you want to deposit into?");
            currentUser.DisplayAccounts(currentUser);

            if (int.TryParse(Console.ReadLine(), out int accountIndex) && accountIndex >= 0 && accountIndex < currentUser.Accounts.Count)
            {
                Console.WriteLine("How much money do you want to deposit?");
                if (double.TryParse(Console.ReadLine(), out double deposit))
                {
                    
                    currentUser.Accounts[accountIndex].Balance += deposit;
                    Console.WriteLine($"Your new balance for {currentUser.Accounts[accountIndex].Accounttype} account is {currentUser.Accounts[accountIndex].Balance}");

                    log.LogDeposit(deposit);
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

        public static void Withdraw(User currentUser, ILog log)
        {
            Console.WriteLine("Which account do you want to withdraw from?");
            currentUser.DisplayAccounts(currentUser);

            if (int.TryParse(Console.ReadLine(), out int accountIndex) && accountIndex >= 0 && accountIndex < currentUser.Accounts.Count)
            {
                Console.WriteLine("How much do you want to withdraw?");
                if (double.TryParse(Console.ReadLine(), out double withdrawal))
                {
                    if (currentUser.Accounts[accountIndex].Balance < withdrawal)
                    {
                        Console.WriteLine("Insufficient funds");
                    }
                    else
                    {
                        currentUser.Accounts[accountIndex].Balance -= withdrawal;
                        Console.WriteLine($"Thank you for the withdrawal. Your new balance for {currentUser.Accounts[accountIndex].Accounttype} account is {currentUser.Accounts[accountIndex].Balance}");

                        log.LogWithdraw(withdrawal);
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

        public static void ShowBalance(User currentUser)
        {
            Console.WriteLine("Which account balance do you want to check?");
            currentUser.DisplayAccounts(currentUser);

            if (int.TryParse(Console.ReadLine(), out int accountIndex) && accountIndex >= 0 && accountIndex < currentUser.Accounts.Count)
            {
                Console.WriteLine($"Your balance for {currentUser.Accounts[accountIndex].Accounttype} account is {currentUser.Accounts[accountIndex].Balance} {currentUser.Accounts[accountIndex].Currency}");
            }
            else
            {
                Console.WriteLine("Invalid account selection.");
            }
        }

        public static void AddNewAccount(User currentUser)
        {
            Console.WriteLine("Enter the type of the new account:");
            string accountType = Console.ReadLine();

            Console.WriteLine("Enter the initial balance:");
            if (double.TryParse(Console.ReadLine(), out double initialBalance))
            {
                Console.WriteLine("Enter the currency (e.g., SEK, USD):");
                string currency = Console.ReadLine();

                currentUser.AddAccount(accountType, initialBalance, currency);
                Console.WriteLine($"New {accountType} account added with an initial balance of {initialBalance} {currency}");
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }

        public static void TransferMoney(User currentUser, List<User> allUsers)
        {
            Console.WriteLine("Do you want to transfer money between your own accounts or to another user?");
            Console.WriteLine("1. Own accounts");
            Console.WriteLine("2. Another user");

            if (int.TryParse(Console.ReadLine(), out int transferChoice) && (transferChoice == 1 || transferChoice == 2))
            {
                if (transferChoice == 1)
                {
                    TransferBetweenOwnAccounts(currentUser);
                }
                else
                {
                    TransferToAnotherUser(currentUser, allUsers);
                }
            }
            else
            {
                Console.WriteLine("Invalid choice. Please enter 1 or 2.");
            }
        }

        private static void TransferBetweenOwnAccounts(User currentUser)
        {
            Console.WriteLine("Which account do you want to transfer money from?");
            currentUser.DisplayAccounts(currentUser);

            if (int.TryParse(Console.ReadLine(), out int fromAccountIndex) && fromAccountIndex >= 0 && fromAccountIndex < currentUser.Accounts.Count)
            {
                Console.WriteLine("How much money do you want to transfer?");

                if (double.TryParse(Console.ReadLine(), out double transferAmount))
                {
                    if (currentUser.Accounts[fromAccountIndex].Balance < transferAmount)
                    {
                        Console.WriteLine("Insufficient funds for the selected account.");
                    }
                    else
                    {
                        Console.WriteLine("Which account do you want to transfer money to?");
                        currentUser.DisplayAccounts(currentUser);

                        if (int.TryParse(Console.ReadLine(), out int toAccountIndex) && toAccountIndex >= 0 && toAccountIndex < currentUser.Accounts.Count)
                        {
                            currentUser.Accounts[fromAccountIndex].Balance -= transferAmount;
                            currentUser.Accounts[toAccountIndex].Balance += transferAmount;

                            Console.WriteLine($"Thank you for the transfer. Your new balance for {currentUser.Accounts[fromAccountIndex].Accounttype} account is {currentUser.Accounts[fromAccountIndex].Balance:C2}");
                            Console.WriteLine($"New balance for {currentUser.Accounts[toAccountIndex].Accounttype} account is {currentUser.Accounts[toAccountIndex].Balance:C2}");
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
        private static void TransferToAnotherUser(User currentUser, List<User> allUsers)
        {
            Console.WriteLine("Which account do you want to transfer money to?");
            DisplayUsers(allUsers);
            if (int.TryParse(Console.ReadLine(), out int toUserIndex) && toUserIndex >= 0 && toUserIndex < allUsers.Count)
            {
                User receiver = allUsers[toUserIndex];

                Console.WriteLine("Which account do you want to transfer money to?");
                currentUser.DisplayAccounts(currentUser);

                if (int.TryParse(Console.ReadLine(), out int fromAccountIndex) && fromAccountIndex >= 0 && fromAccountIndex < currentUser.Accounts.Count)
                {
                    Console.WriteLine("How much money do you want to transfer?");

                    if (double.TryParse(Console.ReadLine(), out double transferAmount))
                    {
                        if (currentUser.Accounts[fromAccountIndex].Balance < transferAmount)
                        {
                            Console.WriteLine("Insufficient funds for the selected account.");
                        }
                        else
                        {
                            Console.WriteLine("Which account do you want to transfer money to?");
                            receiver.DisplayAccounts(receiver);

                            if (int.TryParse(Console.ReadLine(), out int toAccountIndex) && toAccountIndex >= 0 && toAccountIndex < receiver.Accounts.Count)
                            {
                                currentUser.Accounts[fromAccountIndex].Balance -= transferAmount;
                                receiver.Accounts[toAccountIndex].Balance += transferAmount;
                                Console.WriteLine($"Thank you for the transfer. Your new balance for {currentUser.Accounts[fromAccountIndex].Accounttype} account is {currentUser.Accounts[fromAccountIndex].Balance:C2}");
                                Console.WriteLine($"New balance for {receiver.Accounts[toAccountIndex].Accounttype} account is {receiver.Accounts[toAccountIndex].Balance:C2}");
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
        public static void DisplayUsers(List<User> users)
        {
            for (int i = 0; i < users.Count; i++)
            {
                Console.WriteLine($"{i}. {users[i].Username}");
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
    }
}

