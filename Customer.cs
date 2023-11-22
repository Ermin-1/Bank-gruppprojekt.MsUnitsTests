using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_gruppprojekt
{
    public class Customer : User
    {
        public static void TransferMoney(string username, string[] accountTypes, int currentUserIndex, double[] balances) // Funktion för att överföra pengar mellan DINA konton.
        {
            if (currentUserIndex >= 0) // Vilkor som kontrollerar om en användare är inloggad eller inte, är det större eller lika med 0 så är en giltig användare inloggad.
            {
                int userBalanceIndex = currentUserIndex * accountTypes.Length; // Beräknar indexet i användarens saldo i "balances arrayen".

                Console.WriteLine("Your accounts:");
                for (int i = 0; i < accountTypes.Length; i++) // Körs för att kolla vilka olika kontotyper användaren har.
                {
                    Console.WriteLine($"{i + 1}. {accountTypes[i]}: {balances[userBalanceIndex + i]}$"); // Loopen visar vilka konton användaren har och saldot i dem
                }

                Console.Write("Select the account to transfer from (Enter the number): ");
                int sourceAccountIndex = Convert.ToInt32(Console.ReadLine()) - 1; // Sparar ner inmatningen i "sourceAccountIndex"dvs källan, måste ta bort -1 då kontonumret är 1 men arrayer använder basindex 0.

                if (sourceAccountIndex >= 0 && sourceAccountIndex < accountTypes.Length) // Kontrollerar om det valda kontot är giltigt genom index.
                {
                    Console.Write("Enter the amount to transfer: ");
                    double amountToTransfer = Convert.ToDouble(Console.ReadLine()); // Sparar ner inmatning som ska överföras, konverteras till double för att kunna ta decimaler.

                    if (amountToTransfer <= balances[userBalanceIndex + sourceAccountIndex]) // Kontrollerar om det finns tillräckligt med saldo
                    {
                        Console.WriteLine("Your account for transfer:");
                        for (int i = 0; i < accountTypes.Length; i++) // Visar de konton som finns att överföra till.
                        {
                            if (i != sourceAccountIndex) // Villkor som kollar så inte kontoindex är samma som sourceAccountIndex.
                            {
                                Console.WriteLine($"{i + 1}. {accountTypes[i]}");
                            }
                        }
                        Console.Write("Select the account to transfer to (Enter the number): ");
                        int targetAccountIndex = Convert.ToInt32(Console.ReadLine()) - 1; // Sparar ner inmatningen i "targetAccountIndex" dvs mottagare, måste ta bort -1 då kontonumret är 1 men arrayer använder basindex 0.

                        if (targetAccountIndex >= 0 && targetAccountIndex < accountTypes.Length) // Kontrollerar om det valda kontot är giltigt, för att se om index är större eller lika med 0
                        {
                            balances[userBalanceIndex + sourceAccountIndex] -= amountToTransfer; // Här genomförs överföringen om alla villkor uppfylls.
                            balances[userBalanceIndex + targetAccountIndex] += amountToTransfer;

                            Console.WriteLine($"Transfer of {amountToTransfer}$ from {accountTypes[sourceAccountIndex]} to {accountTypes[targetAccountIndex]} completed.");

                            Console.WriteLine("Your updated balances:");
                            for (int i = 0; i < accountTypes.Length; i++)
                            {
                                Console.WriteLine($"{accountTypes[i]}: {balances[userBalanceIndex + i]}$"); // Skriver ut kontot samt saldot som användaren har och sammanfattar efter överföringen
                            }
                        }
                        else // Hela sista delen hanterar olika scenarior vid fel med källkonto, mottagarkonto eller överförningsbelopp.
                        {
                            Console.WriteLine("Invalid target account selection.");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"You do not have enough funds in your {accountTypes[sourceAccountIndex]} account.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid source account selection.");
                }
            }
            else
            {
                Console.WriteLine("No accounts found for this user.");
            }
        }
        // Behöver ändra namn på mycket beroende på lista med användarnamn/pinkoder osv samt inloggningsmetod.


        public static void TransferMoneyToOtherUsers() // Funktion för att överföra pengar till ANDRA användare
        {
            Console.WriteLine("Enter the username of the target user: ");
            string targetUsername = Console.ReadLine();
        }


        public static void CurrencyConvertion() // Funktion för att konvertera valutor på olika konton till ett och samma
        {

        }


    }
    static void Withdrawl()
        {
            static void Withdrawl()
            {
                // Search the list for the user to get the index number
                int userIndex = USER.IndexOf(CURRENTYLOGGEDIN);

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
                            Console.WriteLine($"New balance for {ACCOUNTNAME[userIndex][accIndex]}: {KontoSaldo[userIndex][accIndex]:C}");
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
        }
    }
}