using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_gruppprojekt
{
    internal class LogClass : ILog
    {
        private List<string> logActivity = new List<string>();
        public void LogDeposit(double amount)
        {
            string logBoi = $"Deposit: {amount}C2";
            logActivity.Add(logBoi);
            Console.WriteLine(logBoi);
        }

        public void LogWithdraw(double amount)
        {
            string logBoi = $"Withdrawl: {amount}C2";
            logActivity.Add(logBoi);
            Console.WriteLine(logBoi);
        }

        public List<string> GetLogBois()
        {
            return logActivity;
        }       
    }
}
