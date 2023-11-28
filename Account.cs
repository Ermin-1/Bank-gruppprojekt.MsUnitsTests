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
        public string Currency { get; set; }


        public Account(string accountType, double balance, string currency, ILog log = null)
        {
            Accounttype = accountType;
            Balance = balance;
            Log = log;
            Currency = currency;
        }

    }
}