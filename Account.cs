using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_gruppprojekt
{
    public class Account
    {
        private readonly ILog Log;

        public string Accounttype { get; set; }
        public double Balance { get; set; }

        public Account(string accountType, double balance, ILog log)
        {
            Accounttype = accountType;
            Balance = balance;
            Log = log;
        }

    }
}