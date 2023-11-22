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


            static void TransferMoney() // Funktion för att konvertera valutor på olika konton till ett och samma
            {
                    // Hämtar användarens index i arrayen Användare baserat på det inloggade användarnamnet inloggadSom. 
                    int användarIndex = Array.IndexOf(Användare, inloggadSom);

                    // går igenom arrayen KontoNamn med placering av användarIndex ( den inloggade ) och skrivs sedan ut. 
                    // i + 1 används för att tilldela första kontot värdet 1 och inte 0. 
                    Console.WriteLine("Dina konton:");
                    for (int i = 0; i < KontoNamn[användarIndex].Length; i++)
                    {
                        Console.WriteLine($"{i + 1}. {KontoNamn[användarIndex][i]}");
                    }

                    Console.Write("Välj konto att överföra pengar från (ange siffran): ");
                    int frånKonto = int.Parse(Console.ReadLine());

                    // Om frånKonto är ett giltligt heltal och inom intervallet mellan 1 och antal konto i indexet forstter den in i if-satsen
                    if (frånKonto >= 1 && frånKonto <= KontoNamn[användarIndex].Length)
                    {
                        // beräknas med minus 1 på från konto eftersom användarens val är numrerat från 1 i menyn, men array-indexeringen börjar från 0.
                        int frånKontoIndex = frånKonto - 1;

                        Console.Write("Välj konto att överföra pengar till (ange siffran): ");
                        int tillKonto = int.Parse(Console.ReadLine());

                        // Kontrollerar om tillKonto existrerar i indexet
                        if (tillKonto >= 1 && tillKonto <= KontoNamn[användarIndex].Length)
                        {
                            // Samma sätt som tidigare beräknas index för det valda mottagande kontot genom att ta bort 1 från användarens inmatning.
                            int tillKontoIndex = tillKonto - 1;

                            Console.Write("Ange belopp att överföra: ");
                            decimal överföringsBelopp = decimal.Parse(Console.ReadLine());
                            if (överföringsBelopp > 0)
                            {
                                // Kontrollerar om det finns tillräckligt med saldo på avsändande konto
                                if (KontoSaldo[användarIndex][frånKontoIndex] >= överföringsBelopp)
                                {
                                    // Utför överföringen och uppdaterar saldon
                                    KontoSaldo[användarIndex][frånKontoIndex] -= överföringsBelopp;
                                    KontoSaldo[användarIndex][tillKontoIndex] += överföringsBelopp;
                                    Console.WriteLine("");
                                    Console.WriteLine($"{överföringsBelopp:C} har överförts från {KontoNamn[användarIndex][frånKontoIndex]} till {KontoNamn[användarIndex][tillKontoIndex]}.");
                                    Console.WriteLine($"Nytt saldo för {KontoNamn[användarIndex][frånKontoIndex]}: {KontoSaldo[användarIndex][frånKontoIndex]:C}");
                                    Console.WriteLine($"Nytt saldo för {KontoNamn[användarIndex][tillKontoIndex]}: {KontoSaldo[användarIndex][tillKontoIndex]:C}");
                                }
                                else
                                {
                                    Console.WriteLine("Otillräckligt saldo på det valda kontot för att genomföra överföringen.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Ogiltigt belopp. Ange ett positivt decimaltal.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Ogiltigt kontoval för mottagande konto. Ange en siffra som motsvarar ett av dina konton.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Ogiltigt kontoval för avsändande konto. Ange en siffra som motsvarar ett av dina konton.");
                    }
                    Console.WriteLine("");
                }

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
