using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_gruppprojekt
{
    public interface ILog
    {
        List<string> GetLog();
        void LogDeposit(double ammount, string currency);
        void LogWithdraw(double ammount, string currency);        
    }
}
