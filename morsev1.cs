using System;
using System.Collections.Generic;

namespace BULLA__RAYA_Y_PUNTO
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var w in args)
            {
                converter(w.ToUpper());
                System.Threading.Thread.Sleep(700); //len * 7
                //Console.Out.WriteLine("");
            }
        }

        public static void converter (string w)
        {
            int frq = 450;
            int len = 100;
            Dictionary<char, string> BIGM = new Dictionary<char, string>
            {
                {'A', ".-"}, {'B', "-..."}, {'C', "-.-."}, {'D', "-.."},
                {'E', "."}, {'F', "..-."}, {'G', "--."}, {'H', "...."},
                {'I', ".."}, {'J', ".---"}, {'K', "-.-"}, {'L', ".-.."},
                {'M', "--"}, {'N', "-."}, {'O', "---"}, {'P', ".--."},
                {'Q', "--.-"}, {'R', ".-."}, {'S', "..."}, {'T', "-"},
                {'U', "..-"}, {'V', "...-"}, {'W', ".--"}, {'X', "-..-"},
                {'Y', "-.--"}, {'Z', "--.."}, {'0', "-----"}, {'1', ".----"},
                {'2', "..---"}, {'3', "...--"}, {'4', "....-"}, {'5', "....."},
                {'6', "-...."},{'7', "--..."}, {'8', "---.."}, {'9', "----."}
            };

            foreach (char l in w.ToCharArray())
            {
                //Lo que esta debajo comentado lo hice tan solo para fijarme si estaba bien traducido
                //Console.Out.WriteLine(BIGM[l]);
                foreach(char s in BIGM[l])
                {
                    if (s == '.')
                    {
                        Console.Beep(frq,len);
                    }
                    else
                    {
                        Console.Beep(frq, len*3);
                    }
                    System.Threading.Thread.Sleep(len);
                }
                System.Threading.Thread.Sleep(len*3);
                //Console.Out.WriteLine("");
            }
        }
    }
}
