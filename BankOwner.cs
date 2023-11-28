using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_gruppprojekt
{
    public class BankOwner
    {
        public BankOwner()
        {

        }
        public void SetLoanLimit(Customer currentUser)
        {
            if (currentUser != null)
            {
                double totalBalance = currentUser.Accounts.Sum(account => account.Balance);
                double maxLoan = totalBalance * 5;

                currentUser.MaxLoan = maxLoan;

                Console.WriteLine($"Loan limit set for {currentUser.Username}: {maxLoan:C2}");
            }
            else
            {
                Console.WriteLine("Invalid user.");
            }
        }
    }
}

