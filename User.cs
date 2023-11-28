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
    public class User
    {
        public string Username { get; set; }
        public int Pin { get; set; }
        public double MaxLoan { get; set; }
       
        public bool IsAdmin { get; set; }

               
        public User (string userName, int pin, bool isAdmin = false)
        {
            Username = userName;
            Pin = pin;
            IsAdmin = isAdmin;
                     
        }    
    }
}
