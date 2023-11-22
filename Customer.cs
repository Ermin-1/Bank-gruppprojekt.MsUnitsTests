using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_gruppprojekt
{
    public class Customer : User
    {

        public class Program
        {
            static List<List<string>> ACCOUNTNAME = new List<List<string>>
        {
            new List<string> { "Lönekonto", "Sparkonto", "Privatkonto", "Huskonto", "Rainyday-fun" },
            new List<string> { "Lönekonto", "Sparkonto", "Privatkonto", "Huskonto" },
            new List<string> { "Lönekonto", "Sparkonto", "Privatkonto" },
            new List<string> { "Lönekonto", "Sparkonto" },

        };

            static List<List<decimal>> ACCOUNTBALANCE = new List<List<decimal>>
        {
            new List<decimal> { 27500.0m, 300000.0m, 50000.0m, 20000.0m, 100000.0m },
            new List<decimal> { 42000.0m, 200000.0m, 150000.0m, 60000.0m },
            new List<decimal> { 25000.0m, 46000.0m, 450000.0m },
            new List<decimal> { 15000.0m, 10000.0m },

        };

            static void Withdrawal()
            {
                // Search the list for the user to get the index number
                int userIndex = userInfo.IndexOf(CurrentlyLoggedIn);

                // Search through the list ACCOUNTNAME within userindex (CurrentLoggedIn). +1 adds to declare the first account number one and not index 0.
                Console.WriteLine("Your accounts:");
                for (int i = 0; i < ACCOUNTNAME[userIndex].Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {ACCOUNTNAME[userIndex][i]}");
                }

                Console.WriteLine("Choose an account to make a withdrawal:");
                int accChoice = int.Parse(Console.ReadLine());

                // Check if the account exists
                if (accChoice >= 1 && accChoice <= ACCOUNTNAME[userIndex].Count)
                {
                    // -1 for matching the index
                    int accIndex = accChoice - 1;

                    Console.Write("How much money do you want to withdraw?: ");
                    decimal moneyToWithdraw = decimal.Parse(Console.ReadLine());

                    if (moneyToWithdraw > 0)
                    {
                        // Check if there are enough funds in the account.
                        if (ACCOUNTBALANCE[userIndex][accIndex] >= moneyToWithdraw)
                        {
                            // Deduct the withdrawal amount from the account balance and print the confirmation.
                            ACCOUNTBALANCE[userIndex][accIndex] -= moneyToWithdraw;
                            Console.WriteLine($"{moneyToWithdraw:C} has been withdrawn from {ACCOUNTNAME[userIndex][accIndex]}.");
                            Console.WriteLine($"New balance for {ACCOUNTNAME[userIndex][accIndex]}: {ACCOUNTBALANCE[userIndex][accIndex]:C}");
                        }
                        else
                        {
                            Console.WriteLine("Insufficient funds.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Minimum withdrawal is 1kr. Try again.");
                    }
                }
                else
                {
                    Console.WriteLine("Account doesn't exist. Please choose a number of accounts that match the list.");
                }
            }

            static void TransferMoney()
            {
                // Get the index of the currently logged-in user
                int userIndex = Användare.IndexOf(CurrentlyLoggedIn);

                // Display the user's accounts
                Console.WriteLine("Your accounts:");
                for (int i = 0; i < ACCOUNTNAME[userIndex].Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {ACCOUNTNAME[userIndex][i]}");
                }

                Console.Write("Choose the account to transfer money from (enter the number): ");
                int fromAccount = int.Parse(Console.ReadLine());

                if (fromAccount >= 1 && fromAccount <= ACCOUNTNAME[userIndex].Count)
                {
                    int fromAccountIndex = fromAccount - 1;

                    Console.Write("Choose the account to transfer money to (enter the number): ");
                    int toAccount = int.Parse(Console.ReadLine());

                    if (toAccount >= 1 && toAccount <= ACCOUNTNAME[userIndex].Count)
                    {
                        int toAccountIndex = toAccount - 1;

                        Console.Write("Enter the amount to transfer: ");
                        decimal transferAmount = decimal.Parse(Console.ReadLine());

                        if (transferAmount > 0)
                        {
                            if (ACCOUNTBALANCE[userIndex][fromAccountIndex] >= transferAmount)
                            {
                                ACCOUNTBALANCE[userIndex][fromAccountIndex] -= transferAmount;
                                ACCOUNTBALANCE[userIndex][toAccountIndex] += transferAmount;

                                Console.WriteLine("");
                                Console.WriteLine($"{transferAmount:C} has been transferred from {ACCOUNTNAME[userIndex][fromAccountIndex]} to {ACCOUNTNAME[userIndex][toAccountIndex]}.");
                                Console.WriteLine($"New balance for {ACCOUNTNAME[userIndex][fromAccountIndex]}: {ACCOUNTBALANCE[userIndex][fromAccountIndex]:C}");
                                Console.WriteLine($"New balance for {ACCOUNTNAME[userIndex][toAccountIndex]}: {ACCOUNTBALANCE[userIndex][toAccountIndex]:C}");
                            }
                            else
                            {
                                Console.WriteLine("Insufficient funds in the selected account to complete the transfer.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid amount. Please enter a positive decimal value.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid selection for the receiving account. Please enter a number corresponding to one of your accounts.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid selection for the sending account. Please enter a number corresponding to one of your accounts.");
                }

                Console.WriteLine("");
            }

            static void ShowAccounts()
            {

                // Hitta användarens index baserat på inloggadSom i arrayen KontoÄgare.
                int AnvändarIndex = Array.LastIndexOf(KontoÄgare, inloggadSom);


                Console.WriteLine($"Konton och saldo för {inloggadSom}:");
                Console.WriteLine("");

                // Loopar igenom användarens konton genom ovan angivet AnvändarIndex och skriver ut kontonamn och saldo.
                // :C tillagt för att skriva ut som valuta kr.
                for (int i = 0; i < KontoNamn[AnvändarIndex].Length; i++)
                {

                    Console.WriteLine($"{KontoNamn[AnvändarIndex][i]}: {KontoSaldo[AnvändarIndex][i]:C}");
                }


                static void TransferToOthers() // Funktion för att överföra pengar till ANDRA användare
                {

                }

                static void HistoryTransfers()
                {

                }

                static void OpenNewIntrestAccount()
                {

                }

                static void OpenNewAccount()
                {

                }

                static void CurrencyConvertion()
                {

                }

            }
        }

    }
}

