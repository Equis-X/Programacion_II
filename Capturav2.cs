using System;
using System.Collections.Generic;
using System.Security;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Collections;

namespace captura
{
    class captura
    {
        static void Main(string[] args)
        {
            CSV("data.csv");
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
            char usucon = 'a';
            int lol = 0;
            do{
                if(lol == 0){
                    Console.WriteLine("Confirma tu clave: ");
                    Console.WriteLine("");
                    var confirma = Clave();
                    CONFIRMACION = new System.Net.NetworkCredential(string.Empty, confirma).Password;
                    lol++;
                }
                else{
                    Console.WriteLine("");
                    Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-");
                    Console.WriteLine("!!!ERROR!!!\nDATOS ERRONEOS!\nDesea continuar?\n(1)si (0)no");
                    usucon = LOVE();
                    if(usucon == '1'){
                        Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-");
                        Console.WriteLine("Confirma tu clave: ");
                        Console.WriteLine("");
                        var confirma = Clave();
                        CONFIRMACION = new System.Net.NetworkCredential(string.Empty, confirma).Password;
                    }
                }
            }while(LACLAVE != CONFIRMACION && usucon != '0');

            if(LACLAVE == CONFIRMACION){
                Console.WriteLine("");
                Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-");
                Console.WriteLine("");
                Console.WriteLine("Sus credenciales han sido registradas exitosamente!\n\nBienvenido a MY SBOOKGRAM!");
                Console.Beep(450, 100);
                Console.WriteLine("");
                CSV1(nom,ape,eda,mon,LACLAVE,"data.csv");
            }
        }
        //
        public static string CatchLetters()
        {
            //
            int Charnum;
            char[] CONST = {'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z',
            'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', ' ', 'z'};
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
        //
        public static void CSV(string path){
            StringBuilder csv = new StringBuilder();

            if(!File.Exists(path)){
                csv.AppendLine("Nombre,Apellido,Edad,Monto,Clave");
                File.AppendAllText(path, csv.ToString());
            }
        }
        //
        public static void CSV1(string nom, string ape, string eda, string mon, string cla ,string path){
            StringBuilder csv = new StringBuilder();
            csv.AppendLine(nom+","+ape+","+eda+","+mon+","+cla);
            File.AppendAllText(path, csv.ToString());
        }
        //
        public static char LOVE()
        {
            ConsoleKeyInfo keyInfo;
            keyInfo = Console.ReadKey(true);
            return keyInfo.KeyChar;
            // int Charnum = Console.Read();
            // char numeroh = (char)Charnum;
            // return numeroh;
        }
        //
        //         public static string CatchLetters()
        // {
        //     //
        //     int Charnum;
        //     //
        //     List<int> CharN = new List<int>();
        //     List<char> CharS = new List<char>();
        //     //
        //     do
        //     {
        //         Charnum = Console.Read();
        //         if(Charnum != 13){
        //             CharN.Add(Charnum);
        //         }
        //     }while(Charnum != 13);
        //     //
        //     foreach(int gg in CharN)
        //     {
        //         char JesusEstaPasandoPorAqui = (char)gg;
        //         CharS.Add(JesusEstaPasandoPorAqui);
        //     }
        //     //
        //     string res = string.Join(null,CharS);
        //     res = res.Replace(System.Environment.NewLine, "");
        //     return res;
        // }
    }
}
