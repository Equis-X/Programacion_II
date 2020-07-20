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
            if(args[0] == "dec"){
                            int conols = 0;
            string[] lineas = File.ReadAllLines("data.csv");
            foreach(var linea in lineas){
                if(conols > 0){
                    var valors = linea.Split(',');
                    int ade =int.Parse(valors[4]);
                    char[] ser = new char[4];
                    int aded = ade>>4;
                    if((ade&1) != 0){
                        ser[0]='s';
                    }else{ser[0]='n';}
                    //
                    if((ade&2) != 0){
                        ser[1]='s';
                    }else{ser[1]='n';}
                    //
                    if((ade&4) != 0){
                        ser[2]='s';
                    }else{ser[2]='n';}
                    //
                    if((ade&8) != 0){
                        ser[3]='s';
                    }else{ser[3]='n';}
                    //
                    Console.WriteLine("Persona: "+valors[0]+" "+valors[1]+"\nEdad: "+aded
                    +"\nHombre? "+ser[0]+"\nLicencia? "+ser[1]+"\nAuto? "+ser[2]+"\nActivo? "+ser[3]+"\n");
                }
                else{
                    conols++;
                }
            }
            }else if(args[0] == "reg"){
            int GEN;
            int in1 = 0;
            char c1;
            //
            //
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
            // Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-");
            //
            // Console.Write("Escriba su edad: ");
            // string eda = CatchNUM();
            // Console.WriteLine("");
            // Console.WriteLine(eda);
            // Console.WriteLine("");
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
            Console.WriteLine();
            do{
                if (in1==0){
                    Console.WriteLine("Es hombre? (s/n)");
                    c1 = LOVE();
                    Console.WriteLine(c1);
                    in1++;
                }
                else{
                    Console.WriteLine();
                    Console.WriteLine("Intente de nuevo!");
                    Console.WriteLine();
                    Console.WriteLine("Es hombre? (S/N)");
                    c1 = LOVE();
                    Console.WriteLine(c1);
                }
            }while(c1 != 's' && c1 != 'n');
            if (c1 == 's'){
                GEN = 1;
                in1 = 0;
            }
            else{
                GEN = 0;
                in1 = 0;
            }
            //
            do{
                if (in1==0){
                    Console.WriteLine("Tiene licencia? (s/n)");
                    c1 = LOVE();
                    Console.WriteLine(c1);
                    in1++;
                }
                else{
                    Console.WriteLine();
                    Console.WriteLine("Intente de nuevo!");
                    Console.WriteLine();
                    Console.WriteLine("Tiene licencia? (S/N)");
                    c1 = LOVE();
                    Console.WriteLine(c1);
                }
            }while(c1 != 's' && c1 != 'n');
            if (c1 == 's'){
                GEN = GEN|2;
                in1 = 0;
            }
            else{
                GEN = GEN|0;
                in1 = 0;
            }
            //
            do{
                if (in1==0){
                    Console.WriteLine("Tiene auto? (s/n)");
                    c1 = LOVE();
                    Console.WriteLine(c1);
                    in1++;
                }
                else{
                    Console.WriteLine();
                    Console.WriteLine("Intente de nuevo!");
                    Console.WriteLine();
                    Console.WriteLine("Tiene auto? (S/N)");
                    c1 = LOVE();
                    Console.WriteLine(c1);
                }
            }while(c1 != 's' && c1 != 'n');
            if (c1 == 's'){
                GEN = GEN|4;
                in1 = 0;
            }
            else{
                GEN = GEN|0;
                in1 = 0;
            }
            //
            do{
                if (in1==0){
                    Console.WriteLine("Esta activo? (s/n)");
                    c1 = LOVE();
                    Console.WriteLine(c1);
                    in1++;
                }
                else{
                    Console.WriteLine();
                    Console.WriteLine("Intente de nuevo!");
                    Console.WriteLine();
                    Console.WriteLine("Esta activo? (S/N)");
                    c1 = LOVE();
                    Console.WriteLine(c1);
                }
            }while(c1 != 's' && c1 != 'n');
            if (c1 == 's'){
                GEN = GEN|8;
                in1 = 0;
            }
            else{
                GEN = GEN|0;
                in1 = 0;
            }
            //
            Console.WriteLine("Coloque su edad: ");
            int eda = int.Parse(CatchNUM());
            bool lokm = true;
            do{
            if(eda > 127){
            Console.WriteLine("\nEl numero ingresado es demasiado grande!\nIntentelo de nuevo!");
            lokm = true;
            eda = int.Parse(CatchNUM());
            }
            else if(eda <= 127){
                eda = eda<<4;
                GEN = GEN|eda;
                lokm = false;
            }
            }while(lokm);
            //
            //
            Console.WriteLine();
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
                CSV1(nom,ape,mon,LACLAVE,GEN,"data.csv");
            }
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
                csv.AppendLine("Nombre,Apellido,Monto,Clave,INFO");
                File.AppendAllText(path, csv.ToString());
            }
        }
        //
        public static void CSV1(string nom, string ape, string mon, string cla, int GEN ,string path){
            StringBuilder csv = new StringBuilder();
            csv.AppendLine(nom+","+ape+","+mon+","+cla+","+GEN);
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
