using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_gruppprojekt
{
    internal class AviciiBank
    {
        public AviciiBank()
        {

        }
        public void PaintBank()
        {                      
            Console.WriteLine("         _._._                       _._._");
            Console.WriteLine("        _|   |_                     _|   |_");
            Console.WriteLine("        | ... |_._._._._._._._._._._| ... |");
            Console.WriteLine("        | ||| |  o MEGA BANKEN o  | ||| |");
            Console.WriteLine("        | \"\"\" |  \"\"\"    \"\"\"    \"\"\"  | \"\"\" |");
            Console.WriteLine("   ())  |[-|-]| [-|-]  [-|-]  [-|-] |[-|-]|  ())");
            Console.WriteLine("  (())) |     |---------------------|     | (()))");
            Console.WriteLine(" (())())| \"\"\" |  \"\"\"    \"\"\"    \"\"\"  | \"\"\" |(())())");
            Console.WriteLine(" (()))()|[-|-]|  :::   .-\"-.   :::  |[-|-]|(()))()");
            Console.WriteLine(" ()))(()|     | |~|~|  |_|_|  |~|~| |     |()))(()");
            Console.WriteLine("    ||  |_____|_|_|_|__|_|_|__|_|_|_|_____|  ||");
            Console.WriteLine(" ~ ~^^ @@@@@@@@@@@@@@/=======\\@@@@@@@@@@@@@@ ^^~ ~");
            Console.WriteLine("      ^~^~                                ~^~^");
        }
        public static void BankArt()
        {
            AviciiBank art = new AviciiBank();
            art.PaintBank();
        }
    }   
}
