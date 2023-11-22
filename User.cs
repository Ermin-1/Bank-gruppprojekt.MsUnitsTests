using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Bank_gruppprojekt
{
    internal class User
    {
        private string CurrentlyLoggedIn;
        private Dictionary<string, string> logIn;
        private int maxAttempts;
        private int Attempts;
        private Dictionary<string, int> userInfo = new Dictionary<string, int>
        {
            {"Ermin", 1},
            {"Ludwig", 2},
            {"Oskar", 3},
            {"Isak", 4}
        };

        public User()
        {
            logIn = new Dictionary<string, string>
        {
            {"Oskar","1122"},
            {"sac","1133"},
            {"Ludwig","1996"},
            {"Ermin","6969"}

        };
            maxAttempts = 3;
            Attempts = 0;
        }

        public void Runlogin()
        {
            AviciiBank.BankArt();
            Console.WriteLine("Välkommen till Nordea");
            if (PerformLogin())
            {
                Console.WriteLine("Inloggning lyckades! king kong!!");
            }
            else
            {
                Console.WriteLine("Du har försökt för många gånger. Programmet kommer nu att avslutas! Noob");
                Thread.Sleep(1000);
                Environment.Exit(0);
            }
        }

        private bool PerformLogin()
        {
            while (Attempts < maxAttempts)
            {
                Console.WriteLine("Ange användarnamn: ");
                string username = Console.ReadLine();
                Console.WriteLine("Ange pinkod: ");
                int password = Convert.ToInt32(Console.ReadLine());
                if (userInfo.ContainsKey(username) && userInfo[username] == password)
                {
                    Console.WriteLine("Du loggas nu in...");
                    CurrentlyLoggedIn = username;
                    return true;
                }
                else
                {
                    Attempts++;
                    Console.WriteLine($"Antal försök kvar: {maxAttempts - Attempts}");
                     
                }
            }
            return false;
        }
    }
}
