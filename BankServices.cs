using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_gruppprojekt
{
    public interface IBankServices
    {        

        public static void Deposit(User currentUser)
        {
            Console.WriteLine("Which account do you want to deposit into?");
            currentUser.DisplayAccounts(currentUser);

            if (int.TryParse(Console.ReadLine(), out int accountIndex) && accountIndex >= 0 && accountIndex < currentUser.Accounts.Count)
            {
                Console.WriteLine("How much money do you want to deposit?");
                if (double.TryParse(Console.ReadLine(), out double deposit))
                {
                    currentUser.Accounts[accountIndex].Balance += deposit;
                    Console.WriteLine($"Your new balance for {currentUser.Accounts[accountIndex].Accounttype} account is {currentUser.Accounts[accountIndex].Balance:C2}");
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

        public static void Withdraw(User currentUser)
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
                        Console.WriteLine($"Thank you for the withdrawal. Your new balance for {currentUser.Accounts[accountIndex].Accounttype} account is {currentUser.Accounts[accountIndex].Balance:C2}");
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
                Console.WriteLine($"Your balance for {currentUser.Accounts[accountIndex].Accounttype} account is {currentUser.Accounts[accountIndex].Balance:C2}");
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
                currentUser.AddAccount(accountType, initialBalance);
                Console.WriteLine($"New {accountType} account added with an initial balance of {initialBalance:C2}");
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }
        public static void TransferMoney(User currentUser)

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

                        Console.WriteLine("Insufficient funds");

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
    }
}

