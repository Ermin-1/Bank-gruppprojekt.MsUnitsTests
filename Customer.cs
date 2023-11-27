//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Channels;
//using System.Threading.Tasks;

//namespace Bank_gruppprojekt
//{
//    public class Customer : User
//    {

//        public Customer(string userName, string passWord, string accountOwner, List<List<string>> accountName) : base(userName, passWord, accountOwner, accountName)
//        {
//            if (userList == null)
//            {
//                userList = new List<User>();
//            }
//        }

//        public void Withdrawal()
//        {
//            // Search the list for the user to get the index number
//            int userIndex = userList.FindIndex(user => user.Username == this.Username);

//            Console.WriteLine("Your accounts:");
//            for (int i = 0; i < ACCOUNTNAME[userIndex].Count; i++)
//            {
//                Console.WriteLine($"{i + 1}. {ACCOUNTNAME[userIndex][i]}");
//            }

//            Console.WriteLine("Choose an account to make a withdrawal:");
//            int accChoice = int.Parse(Console.ReadLine());

//            if (accChoice >= 1 && accChoice <= ACCOUNTNAME[userIndex].Count)
//            {
//                int accIndex = accChoice - 1;

//                Console.Write("How much money do you want to withdraw?: ");
//                decimal moneyToWithdraw = decimal.Parse(Console.ReadLine());

//                if (moneyToWithdraw > 0)
//                {
//                    if (ACCOUNTBALANCE[userIndex][accIndex] >= moneyToWithdraw)
//                    {
//                        ACCOUNTBALANCE[userIndex][accIndex] -= moneyToWithdraw;
//                        Console.WriteLine($"{moneyToWithdraw:C} has been withdrawn from {ACCOUNTNAME[userIndex][accIndex]}.");
//                        Console.WriteLine($"New balance for {ACCOUNTNAME[userIndex][accIndex]}: {ACCOUNTBALANCE[userIndex][accIndex]:C}");
//                    }
//                    else
//                    {
//                        Console.WriteLine("Insufficient funds.");
//                    }
//                }
//                else
//                {
//                    Console.WriteLine("Minimum withdrawal is 1kr. Try again.");
//                }
//            }
//            else
//            {
//                Console.WriteLine("Account doesn't exist. Please choose a number of accounts that match the list.");
//            }
//        }

//        static void TransferMoneyToOtherUsers() // Funktion för att överföra pengar till ANDRA användare
//        {

//        }


//        static void CurrencyConvertion() // Funktion för att konvertera valutor på olika konton till ett och samma
//        {

//        }
//    }
//}





    //        static void TransferMoney()
    //        {
    //            // Get the index of the currently logged-in user
    //            int userIndex = .IndexOf(UserList);

    //            // Display the user's accounts
    //            Console.WriteLine("Your accounts:");
    //            for (int i = 0; i < ACCOUNTNAME[userIndex].Count; i++)
    //            {
    //                Console.WriteLine($"{i + 1}. {ACCOUNTNAME[userIndex][i]}");
    //            }

    //            Console.Write("Choose the account to transfer money from (enter the number): ");
    //            int fromAccount = int.Parse(Console.ReadLine());

    //            if (fromAccount >= 1 && fromAccount <= ACCOUNTNAME[userIndex].Count)
    //            {
    //                int fromAccountIndex = fromAccount - 1;

    //                Console.Write("Choose the account to transfer money to (enter the number): ");
    //                int toAccount = int.Parse(Console.ReadLine());

    //                if (toAccount >= 1 && toAccount <= ACCOUNTNAME[userIndex].Count)
    //                {
    //                    int toAccountIndex = toAccount - 1;

    //                    Console.Write("Enter the amount to transfer: ");
    //                    decimal transferAmount = decimal.Parse(Console.ReadLine());

    //                    if (transferAmount > 0)
    //                    {
    //                        if (ACCOUNTBALANCE[userIndex][fromAccountIndex] >= transferAmount)
    //                        {
    //                            ACCOUNTBALANCE[userIndex][fromAccountIndex] -= transferAmount;
    //                            ACCOUNTBALANCE[userIndex][toAccountIndex] += transferAmount;

    //                            Console.WriteLine("");
    //                            Console.WriteLine($"{transferAmount:C} has been transferred from {ACCOUNTNAME[userIndex][fromAccountIndex]} to {ACCOUNTNAME[userIndex][toAccountIndex]}.");
    //                            Console.WriteLine($"New balance for {ACCOUNTNAME[userIndex][fromAccountIndex]}: {ACCOUNTBALANCE[userIndex][fromAccountIndex]:C}");
    //                            Console.WriteLine($"New balance for {ACCOUNTNAME[userIndex][toAccountIndex]}: {ACCOUNTBALANCE[userIndex][toAccountIndex]:C}");
    //                        }
    //                        else
    //                        {
    //                            Console.WriteLine("Insufficient funds in the selected account to complete the transfer.");
    //                        }
    //                    }
    //                    else
    //                    {
    //                        Console.WriteLine("Invalid amount. Please enter a positive decimal value.");
    //                    }
    //                }
    //                else
    //                {
    //                    Console.WriteLine("Invalid selection for the receiving account. Please enter a number corresponding to one of your accounts.");
    //                }
    //            }
    //            else
    //            {
    //                Console.WriteLine("Invalid selection for the sending account. Please enter a number corresponding to one of your accounts.");
    //            }

    //            Console.WriteLine("");
    //        }

    //        static void ShowAccounts()
    //        {

    //            // Hitta användarens index baserat på inloggadSom i arrayen KontoÄgare.
    //            int AnvändarIndex = Array.LastIndexOf(KontoÄgare, inloggadSom);


    //            Console.WriteLine($"Konton och saldo för {inloggadSom}:");
    //            Console.WriteLine("");

    //            // Loopar igenom användarens konton genom ovan angivet AnvändarIndex och skriver ut kontonamn och saldo.
    //            // :C tillagt för att skriva ut som valuta kr.
    //            for (int i = 0; i < KontoNamn[AnvändarIndex].Length; i++)
    //            {

    //                Console.WriteLine($"{KontoNamn[AnvändarIndex][i]}: {KontoSaldo[AnvändarIndex][i]:C}");
    //            }


    //            static void TransferToOthers() // Funktion för att överföra pengar till ANDRA användare
    //            {

    //            }

    //            static void HistoryTransfers()
    //            {

    //            }

    //            static void OpenNewIntrestAccount()
    //            {

    //            }

    //            static void OpenNewAccount()
    //            {

    //            }

    //            static void CurrencyConvertion()
    //            {

    //            }

    //        }
    //    }

    //}


