using System;
using System.Collections.Generic;
using System.Security;

namespace captura
{
    class captura
    {
        static void Main(string[] args)
        {
            Console.WriteLine("");
            Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-");
            Console.WriteLine(" MY SBOOKGRAM REGISTER");
            Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-");
            //
            Console.Write("Escriba su nombre: ");
            string nom = "a";
            nom = CatchLetters();
            Console.WriteLine("");
            Console.WriteLine(nom);
            Console.WriteLine("");
            //
            Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-");
            //
            Console.Write("Escriba su apellido: ");
            string ape = CatchLetters();
            Console.WriteLine("");
            Console.WriteLine(ape);
            Console.WriteLine("");
            //
            Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-");
            //
            Console.Write("Escriba su edad: ");
            string eda = CatchNUM();
            Console.WriteLine("");
            Console.WriteLine(eda);
            Console.WriteLine("");
            //
            Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-");
            //
            Console.Write("Escriba su monto: ");
            string mon = CatchDEC();
            Console.WriteLine("");
            Console.WriteLine(mon);
            Console.WriteLine("");
            //
            Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-");
            //
            Console.WriteLine("Escribe tu clave: ");
            Console.WriteLine("");
            var pass = Clave();
            string LACLAVE = new System.Net.NetworkCredential(string.Empty, pass).Password;
            Console.WriteLine("");
            //
            Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-");
            //
            string CONFIRMACION = "a";
            do{
                Console.WriteLine("");
                Console.WriteLine("Confirma tu clave: ");
                var confirma = Clave();
                CONFIRMACION = new System.Net.NetworkCredential(string.Empty, confirma).Password;
            }while(LACLAVE != CONFIRMACION);
            //
            Console.WriteLine("");
            Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-");
            Console.WriteLine("");
            Console.WriteLine("Sus credenciales han sido registradas exitosamente!\n\nBienvenido a MY SBOOKGRAM!");
            Console.Beep(450, 100);
            Console.WriteLine("");
        }
        //
        public static string CatchLetters()
        {
            //
            int Charnum;
            //
            List<int> CharN = new List<int>();
            List<char> CharS = new List<char>();
            //
            do
            {
                Charnum = Console.Read();
                if(Charnum != 13){
                    CharN.Add(Charnum);
                }
            }while(Charnum != 13);
            //
            foreach(int gg in CharN)
            {
                char JesusEstaPasandoPorAqui = (char)gg;
                CharS.Add(JesusEstaPasandoPorAqui);
            }
            //
            string res = string.Join(null,CharS);
            res = res.Replace(System.Environment.NewLine, "");
            return res;
        }
        //
        public static string CatchNUM()
        {
            //
            int Charnum;
            char[] CONST = {'0', '1', '2', '3', '4', '5', '6', '7', '8', '9'};
            //
            List<char> CharS = new List<char>();
            //
            do
            {
                Charnum = Console.Read();
                char numeroh = (char)Charnum;
                foreach(char ykc in CONST){
                        if (numeroh == ykc){
                            CharS.Add(numeroh);
                        }
                }
            }while(Charnum != 13);
            //
            string res = string.Join(null,CharS);
            return res;
        }
        //
        public static string CatchDEC()
        {
            //
            int Charnum;
            char[] CONST = {'0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '.'};
            //
            List<char> CharS = new List<char>();
            //
            do
            {
                Charnum = Console.Read();
                char numeroh = (char)Charnum;
                foreach(char ykc in CONST){
                        if (numeroh == ykc){
                            CharS.Add(numeroh);
                        }
                }
            }while(Charnum != 13);
            //
            string res = string.Join(null,CharS);
            return res;
        }
        //
        public static SecureString Clave()
        {
            //
            SecureString pass = new SecureString();
            ConsoleKeyInfo keyInfo;
            //
            do
            {
                keyInfo = Console.ReadKey(true);
                if(!char.IsControl(keyInfo.KeyChar))
                {
                    pass.AppendChar(keyInfo.KeyChar);
                    Console.Write("*");
                }
                else if(keyInfo.Key == ConsoleKey.Backspace && pass.Length > 0)
                {
                    pass.RemoveAt(pass.Length - 1);
                    Console.Write("\b \b");
                }
            }while(keyInfo.Key != ConsoleKey.Enter);
            {
                return pass;
            }
            //
        }
    }
}
