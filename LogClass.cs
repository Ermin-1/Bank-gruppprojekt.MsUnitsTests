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
        public void LogDeposit(double amount, string currency)
        {
            string logBoi = $"Deposit: {amount}{currency}";
            logActivity.Add(logBoi);
            Console.WriteLine(logBoi);
        }

        public void LogWithdraw(double amount, string currency)
        {
            string logBoi = $"Withdrawl: {amount}{currency}";
            logActivity.Add(logBoi);
            Console.WriteLine(logBoi);
        }

        public List<string> GetLogBois()
        {
            return logActivity;
        }       
    }
}
