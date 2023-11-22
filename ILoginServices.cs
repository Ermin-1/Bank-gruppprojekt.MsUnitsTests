using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_gruppprojekt
{
    internal interface ILoginServices 
    {
        void CreateNewCustomer(string userName, int pin);
        bool LogIn(string userName, int pin);
    }
}
