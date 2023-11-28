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
            List<User> allUsers = new List<User>();
            LogIn.LoginIn(log, allUsers);           
        }        
    }
}
