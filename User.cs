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
        public int maxAttempts;
        public int Attempts;
        public string UserName;
        public Dictionary<string, int> userInfo = new Dictionary<string, int>
        {
            {"Ermin", 1},
            {"Ludwig", 2},
            {"Oskar", 3},
            {"Isak", 4}
        };

        public User()
        {
            UserName = "";
            maxAttempts = 3;
            Attempts = 0;
        }
    }
}
