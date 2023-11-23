using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_gruppprojekt
{
    public class Bank : User
    {
        public int maxAttempts;
        public int Attempts;

        public Bank(string userName, string passWord, string accountOwner): base(userName, passWord, accountOwner)
        {
            Username = userName;
            Password = passWord;
            AccountOwner = accountOwner;
            maxAttempts = 3;
            Attempts = 0;            
        }

        public void Runlogin()
        {
            
            AviciiBank.BankArt();
            Console.WriteLine("Välkommen till Nordea");
            User currentUser = null;
            if (PerformLogin(userList, out currentUser))
            {
                Console.WriteLine("Inloggning lyckades! king kong!!");
                Thread.Sleep(2500);
                Console.Clear();
                Bankmeny(currentUser);
            }
            else
            {
                Console.WriteLine("Du har försökt för många gånger. Programmet kommer nu att avslutas! Noob");
                Thread.Sleep(1000);
                Environment.Exit(0);
            }
        }
        public bool PerformLogin(List<User> userList, out User authenticatedUser)
        {
            authenticatedUser = null;

            while (Attempts < maxAttempts)
            {
                Console.WriteLine("Ange användarnamn: ");
                var username = Console.ReadLine();
                Console.WriteLine("Ange pinkod: ");
                var password = Console.ReadLine();

                authenticatedUser = userList.FirstOrDefault(user => user.DoesUserMatch(username, password) != null);
                
                if (authenticatedUser!= null)
                {
                    Console.WriteLine("Du loggas nu in...");
                    Username = username;
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
        public void Bankmeny(User user)
        {
            Console.WriteLine($"Välkommen {Username}");
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

                        break;  

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
