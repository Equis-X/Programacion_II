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
            if(args.Length != 0 && args[0] == "dec"){
                if(File.Exists("data.csv")){
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
                }
                else{
                    Console.WriteLine("No hay nada que decodificar!\nRegistra primero!");
                }
            }
            else if(args.Length != 0 && args[0] == "reg"){
                int polk = 0;
                string asj;
                //
                //
                CSV("data.csv");
                Console.WriteLine("\n-=-=-=-=-=-=-=-=-=-=-\n MY SBOOKGRAM REGISTER\n-=-=-=-=-=-=-=-=-=-=-");
                Console.Write("Escriba su nombre: ");
                string nom = "a";
                nom = CatchLetters();
                nom = nom.Replace(" ","");
                Console.WriteLine("\n"+nom+"\n-=-=-=-=-=-=-=-=-=-=-");
                //
                Console.Write("Escriba su apellido: ");
                string ape = CatchLetters();
                ape = ape.Replace(" ","");
                polk = checko(nom, ape);
                while(polk == 1){
                        Console.WriteLine("!!!ERROR!!!\nLa persona ya se encuentre ingresada!"+
                        "\nIntente otro apellido:\n");
                        ape = CatchLetters();
                        ape = ape.Replace(" ","");
                        polk = checko(nom, ape);
                }
                Console.WriteLine("\n"+ape+"\n");
                Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-");
                Console.Write("Escriba su monto: ");
                string mon = CatchDEC();
                Console.WriteLine("\n"+mon+"\n");
                Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-\n");
                //
                asj = binn().ToString();
                //
                Console.WriteLine("\n-=-=-=-=-=-=-=-=-=-=-");
                //
                Console.WriteLine("Escribe tu clave: \n");
                var pass = Clave();
                string LACLAVE = new System.Net.NetworkCredential(string.Empty, pass).Password;
                //
                Console.WriteLine("\n-=-=-=-=-=-=-=-=-=-=-");
                //
                string CONFIRMACION = "a";
                char usucon = 'a';
                int lol = 0;
                do{
                    if(lol == 0){
                        Console.WriteLine("Confirma tu clave: \n");
                        var confirma = Clave();
                        CONFIRMACION = new System.Net.NetworkCredential(string.Empty, confirma).Password;
                        lol++;
                    }
                    else{
                        Console.WriteLine("\n-=-=-=-=-=-=-=-=-=-=-\n!!!ERROR!!!\nDATOS ERRONEOS!"+
                        "\nDesea continuar?\n(1)si (0)no");
                        usucon = LOVE();
                        if(usucon == '1'){
                            Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-\nConfirma tu clave: \n");
                            var confirma = Clave();
                            CONFIRMACION = new System.Net.NetworkCredential(string.Empty, confirma).Password;
                        }
                    }
                }while(LACLAVE != CONFIRMACION && usucon != '0');

                if(LACLAVE == CONFIRMACION){
                    Console.WriteLine("\n-=-=-=-=-=-=-=-=-=-=-\n");
                    Console.WriteLine("Sus credenciales han sido registradas exitosamente!\n\nBienvenido a MY SBOOKGRAM!");
                    Console.Beep(450, 100);
                    Console.WriteLine();
                    CSV1(nom,ape,mon,LACLAVE,asj,"data.csv");
                }
            }
            else if(args.Length != 0 && args[0] == "edi"){
                if(File.Exists("data.csv")){
                    jesusestapasandoporaqui();
                }
                else{
                    Console.WriteLine("No hay nada que editar!\nRegistra primero!");
                }
            }
            else if(args.Length == 0){
                Console.WriteLine("\n!!!ERROR!!!\nSe ejecuto el programa sin parametros!\n\nPARAMETROS:\n"
                +"reg = Registro\ndec = Decodificaro\nedi = Editar\n\nEJEMPLO:\n>captura4.exe edi\n");
            }
        }
        //
        public static void jesusestapasandoporaqui(){
            string[] lineas = File.ReadAllLines("data.csv");
            int conols = 0,casf = 0;
            foreach(var linea in lineas){
                if(conols > 0){
                    casf++;
                    var valors = linea.Split(',');
                    Console.WriteLine("{0}) {1}{2}\n",casf,valors[0],valors[1]);
                }
                else{
                    Console.WriteLine("EDITAR\nA que persona desea editar?\n");
                    conols++;
                }
            }
            //
            string a = LOVE().ToString();
            int ab;
            bool plo = true;
            do{
                if(int.TryParse(a, out conols) != true){
                    Console.WriteLine("\nError!\nInserte un dato numerico!\n");
                    a = LOVE().ToString();
                }
                else{
                    plo = false;
                }
            }while(plo);
            //
            ab = int.Parse(a);
            string[] modd = lineas[ab].Split(',');
            //
            //modd[0] = "Nombre";
            //modd[1] = "Apellido";
            //modd[2] = "Monto";
            //modd[3] = "Clave";
            //modd[4] = "binn";
            //
            Console.Write("Escriba su nuevo monto: ");
            modd[2] = CatchDEC();
            Console.WriteLine("\n"+ modd[2]+"\n");
            Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-\n");
            //
            modd[4] = binn().ToString();
            //
            Console.WriteLine("\n-=-=-=-=-=-=-=-=-=-=-");
            //
            Console.WriteLine("Escribe tu clave: \n");
            var pass = Clave();
            modd[3] = new System.Net.NetworkCredential(string.Empty, pass).Password;
            //
            Console.WriteLine("\n-=-=-=-=-=-=-=-=-=-=-");
            //
            string CONFIRMACION = "a";
            char usucon = 'a';
            int lol = 0;
            do{
                if(lol == 0){
                    Console.WriteLine("Confirma tu clave: \n");
                    var confirma = Clave();
                    CONFIRMACION = new System.Net.NetworkCredential(string.Empty, confirma).Password;
                    lol++;
                }
                else{
                    Console.WriteLine("\n-=-=-=-=-=-=-=-=-=-=-\n!!!ERROR!!!\nDATOS ERRONEOS!"+
                    "\nDesea continuar?\n(1)si (0)no");
                    usucon = LOVE();
                    if(usucon == '1'){
                        Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-\nConfirma tu clave: \n");
                        var confirma = Clave();
                        CONFIRMACION = new System.Net.NetworkCredential(string.Empty, confirma).Password;
                    }
                }
            }while(modd[3] != CONFIRMACION && usucon != '0');

            if(modd[3] == CONFIRMACION){
                //
                lineas[ab] = ConvATSTI(modd);
                modilk("data.csv",lineas);
                //
                Console.WriteLine("\n-=-=-=-=-=-=-=-=-=-=-\n");
                Console.WriteLine("Sus credenciales han sido modificadas exitosamente!\n");
                Console.Beep(450, 100);
            }
        }
        //
        public static int binn(){
            int GEN;
            int in1 = 0;
            char c1;
            do{
                    if (in1==0){
                        Console.WriteLine("Es hombre? (s/n)");
                        c1 = LOVE();
                        Console.WriteLine(c1);
                        in1++;
                    }
                    else{
                        Console.WriteLine("\nIntente de nuevo!");
                        Console.WriteLine("\nEs hombre? (S/N)");
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
                        Console.WriteLine("\nIntente de nuevo!");
                        Console.WriteLine("\nTiene licencia? (S/N)");
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
                        Console.WriteLine("\nIntente de nuevo!");
                        Console.WriteLine("\nTiene auto? (S/N)");
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
                        Console.WriteLine("\nIntente de nuevo!");
                        Console.WriteLine("\nEsta activo? (S/N)");
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
                return GEN;
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
        public static void CSV1(string nom, string ape, string mon, string cla, string GEN ,string path){
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
        }
        //
        public static int checko(string nom, string ape){
            string[] lineas = File.ReadAllLines("data.csv");
            int conols = 0, popo = 0;
            foreach(var linea in lineas){
                if(conols > 0){
                    var valors = linea.Split(',');
                    if(nom.ToLower() == valors[0].ToLower().Replace(" ","") && ape.ToLower() == valors[1].ToLower().Replace(" ","")){
                        popo++;
                    }
                }
                else{
                    conols++;
                }
            }
            if(popo == 1){
                return 1;
            }
            else{
                return 0;
            }
        }
        //
        public static string ConvATSTI(string[] array){
            string res = string.Join(",", array);
            return res;
        }
        //
        public static void modilk(string dir,string[] miop){
            File.Delete(dir);
            //
            StringBuilder csv = new StringBuilder();
            for (int i = 0; i < miop.Length; i++)
            {
                csv.AppendLine(miop[i]);
            }
            File.AppendAllText(dir, csv.ToString());
        }
    }
}
