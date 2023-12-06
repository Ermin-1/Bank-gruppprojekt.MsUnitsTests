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
            string[] asciiArt = {
            "         _._._                       _._._",
            "        _|   |_                     _|   |_",
            "        | ... |_._._._._._._._._._._| ... |",
            "        | ||| |  o THE MEGA BANK o  | ||| |", // Not colored
            "        | \"\"\" |  \"\"\"    \"\"\"    \"\"\"  | \"\"\" |",
            "   ())  |[-|-]| [-|-]  [-|-]  [-|-] |[-|-]|  ())",
            "  (())) |     |---------------------|     | (()))",
            " (())())| \"\"\" |  \"\"\"    \"\"\"    \"\"\"  | \"\"\" |(())())",
            " (()))()|[-|-]|  :::   .-\"-.   :::  |[-|-]|(()))()", // Green color for the trees
            " ()))(()|     | |-|-|  |_|_|  |-|-| |     |()))(()", // Green color for the grass
            "    ||  |_____|_|_|_|__|_|_|__|_|_|_|_____|  ||",
            " ~ ~^^ @@@@@@@@@@@@@@/=======\\@@@@@@@@@@@@@@ ^^~ ~",
            "      ^~^~                                ~^~^"
        };
            
                
                foreach (string line in asciiArt)
                {                                        
                    string coloredLine = line.Replace(")", "\u001b[32m)\u001b[0m")
                        .Replace("@", "\u001b[32m@\u001b[0m")
                        .Replace("~", "\u001b[32m~\u001b[0m")
                        .Replace("^", "\u001b[32m^\u001b[0m")
                        .Replace("(", "\u001b[32m(\u001b[0m")
                        .Replace("THE MEGA BANK", "\u001b[36mTHE MEGA BANK\u001b[0m");
                    Console.WriteLine(coloredLine);
                    Thread.Sleep(75);
                }                                      
        }
  
        public void FadeBank()
        {
            string[] asciiArt = {
            "         _._._                       _._._",
            "        _|   |_                     _|   |_",
            "        | ... |_._._._._._._._._._._| ... |",
            "        | ||| |  o THE MEGA BANK o  | ||| |",
            "        | \"\"\" |  \"\"\"    \"\"\"    \"\"\"  | \"\"\" |",
            "   ())  |[-|-]| [-|-]  [-|-]  [-|-] |[-|-]|  ())",
            "  (())) |     |---------------------|     | (()))",
            " (())())| \"\"\" |  \"\"\"    \"\"\"    \"\"\"  | \"\"\" |(())())",
            " (()))()|[-|-]|  :::   .-\"-.   :::  |[-|-]|(()))()",
            " ()))(()|     | |~|~|  |_|_|  |~|~| |     |()))(()",
            "    ||  |_____|_|_|_|__|_|_|__|_|_|_|_____|  ||",
            " ~ ~^^ @@@@@@@@@@@@@@/=======\\@@@@@@@@@@@@@@ ^^~ ~",
            "      ^~^~                                ~^~^"
        };

            for (int frame = 0; frame <= 10; frame++) // Adjust the number of frames based on the desired animation duration
            {
                foreach (string line in asciiArt)
                {
                    // Simulate fading away by adjusting opacity
                    Console.WriteLine(FadeLine(line, frame));
                }

                // Delay for a short duration between frames
                Thread.Sleep(100);

                // Clear the console to create the illusion of fading
                Console.Clear();
            }

            // Additional animation logic for trees and grass movement can be added here
        }

        static string FadeLine(string line, int frame)
        {
            // Calculate opacity based on the frame
            int opacity = 10 - frame;

            // Clamp opacity to the valid range [0, 10]
            opacity = Math.Max(0, Math.Min(10, opacity));

            // Create a faded version of the line
            string fadedLine = "";
            foreach (char c in line)
            {
                fadedLine += (c == ' ' || c == '\t') ? c : FadeCharacter(c, opacity);
            }

            return fadedLine;
        }

        static char FadeCharacter(char character, int opacity)
        {
            // Adjust the opacity of a character
            char[] opacityLevels = { ' ', '.', ':', '-', '=', '+', '*', '#', '%', '8', '@' };
            int index = (opacity * (opacityLevels.Length - 1)) / 10;
            return opacityLevels[index];
        }

        public static void BankArt()
        {
            AviciiBank art = new AviciiBank();
            art.PaintBank();
        }
    }   
}
