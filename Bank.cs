using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_gruppprojekt
{
    internal class Bank : User
    {
        
        public Bank()
        {
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
                Bankmeny();

            }
            else
            {
                Console.WriteLine("Du har försökt för många gånger. Programmet kommer nu att avslutas! Noob");
                Thread.Sleep(1000);
                Environment.Exit(0);
            }
        }

        public bool PerformLogin()
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
                    UserName = username;
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
        public void Bankmeny()
        {
            Console.WriteLine($"Välkommen {UserName}");
            Console.WriteLine("[1]. Se dina konton och dess saldon\n[2]. Överföring mellan konton\n[3]. Ta ut pengar\n[4]. Logga ut");
            try
            {
                int uInput = Convert.ToInt32(Console.ReadLine());

                switch (uInput)
                {
                    case 1:

                        break;

                    case 2:

                        break;

                    case 3:

                        break;

                    case 4:

                        
                    default:

                        break;
                }
            }
            catch
            {

            }
        }
    }
}
