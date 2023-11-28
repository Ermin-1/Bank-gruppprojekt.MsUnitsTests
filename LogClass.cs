using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_gruppprojekt
{
    internal class LogClass : ILog
    {
        public void LogDeposit(double amount)
        {
            Console.WriteLine($"Deposit: {amount}");
        }

        public void LogWithdraw(double amount)
        {
            Console.WriteLine($"Withdrawal: {amount}");
        }

    }
}
