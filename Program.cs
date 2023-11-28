using Bank_gruppprojekt;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BankApplication
{
    public class Program
    {
        static void Main(string[] args)
        {
            LogClass log = new LogClass();
            List<Customer> allUsers = new List<Customer>();
            LogIn.LoginIn(log, allUsers);           
        }        
    }
}
