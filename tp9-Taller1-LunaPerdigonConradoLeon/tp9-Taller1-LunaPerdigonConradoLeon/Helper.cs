using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Helpers
{
    public static class  SoportesParaConfiguracion
    {
 
        static string nuevaRutaCarpeta = @"\RutaCarpeta";
        static string archivoConfig = "config.dat";
       

        public static void CrearArchivoDeConfiguracion(string rutadelarchivo)
        {

            if (!Directory.Exists(rutadelarchivo)){
                Directory.CreateDirectory(rutadelarchivo);
            }
            else {
                //File.Copy(@"\tp9-Taller1-LunaPerdigonConradoLeon\tp9-Taller1-LunaPerdigonConradoLeon\bin\Debug", rutadelarchivo); 
            }
            FileStream elarchivo = File.Create(archivoConfig);//Abro el archivo y lo mando al string
            BinaryWriter binarioescritura = new BinaryWriter(elarchivo);

            binarioescritura.Write(rutadelarchivo);
            binarioescritura.Close();

        }
        public static string LeerConfiguracion()
        {
            if (File.Exists(archivoConfig)) {
                
                BinaryReader ruta= new BinaryReader(File.Open(archivoConfig, FileMode.Open));
                string larutita = ruta.ReadString();
                ruta.Close();
                return larutita;
                
            }
            else
            {
                Console.WriteLine("El archivo no existe, ingrese un nuevo nombre para crearlo");
           
                SoportesParaConfiguracion.CrearArchivoDeConfiguracion(nuevaRutaCarpeta);
                BinaryReader ruta = new BinaryReader(File.Open(archivoConfig, FileMode.Open));
                return ruta.ReadString();

            }

        }
        public static string TextoAMorse(string cadena)
        {

            string textomorse= "";
            char[] letras = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'n', 'm', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', ' ' };
            string[] caracteres = { ".- ", "-... ", "-.-. ", "-.. ", ". ", "..-. ", "--. ", ".... ", ".. ", ".--- ", "-.- ", ".-.. ", "-- ", "-. ", "--- ", ".--. ", "--.- ", ".-. ", "... ", "- ", "..- ", "...- ", "-..- ", "-..- ", "-.-- ", "--.. ", @" / " };
            int j = 0;
            while (cadena[j] != '.')
            {
                for (int i = 0; i < 27; i++)
                {
                    if (letras[i] == cadena[j])
                    {
                        Console.Write(caracteres[i]);
                        textomorse = textomorse + caracteres[i];

                    }
                }
                j++;
            }
            return textomorse;
        }
        public static string MorseATexto(string cadena)
        {
            string morsetexto = "";
            char[] letras = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'n', 'm', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', ' ' };
            string[] caracteres = { ".-", "-...", "-.-.", "-..", ".", "..-.", "--.", "....", "..", ".---", "-.-", ".-..", "--", "-.", "---", ".--.", "--.-", ".-.", "...", "-", "..-", "...-", "-..-", "-..-", "-.--", "--..", @"/" };           
            string[] cadamorse = cadena.Split(' ');
            foreach(string linea in cadamorse)
            {
                for(int i=0; i < 27; i++)
                {
                    if (Equals(linea, caracteres[i]))
                    {
                        Console.Write(letras[i]);
                        morsetexto = morsetexto + letras[i];
                     
                    }
                }
            }
            return morsetexto;
        }


      

           /* List<string> cadenamorse = new List<string>();
           
            foreach (char letra in cadena)
            {
                switch (cadena)
                {
                    case "a": cadenamorse.Add(@".- "); Console.Write(cadena.ToString()); break;
                    case "b": cadenamorse.Add(@"-... "); break;
                    case "c": cadenamorse.Add(@"-.-. "); break;
                    case "d": cadenamorse.Add(@"-.. "); break;
                    case "e": cadenamorse.Add(@". "); break;
                    case "f": cadenamorse.Add(@"..-. "); break;
                    case "g": cadenamorse.Add(@"--. "); break;
                    case "h": cadenamorse.Add(@".... "); break;
                    case "i": cadenamorse.Add(@".. "); break;
                    case "j": cadenamorse.Add(@".--- "); break;
                    case "k": cadenamorse.Add(@"-.- "); break;
                    case "l": cadenamorse.Add(@".-.. "); break;
                    case "m": cadenamorse.Add(@"-- "); break;
                    case "n": cadenamorse.Add(@"-. "); break;
                    case "o": cadenamorse.Add(@"--- "); break;
                    case "p": cadenamorse.Add(@".--. "); break;
                    case "q": cadenamorse.Add(@"--.- "); break;
                    case "r": cadenamorse.Add(@".-. "); break;
                    case "s": cadenamorse.Add(@"... "); break;
                    case "t": cadenamorse.Add(@"- "); break;
                    case "u": cadenamorse.Add(@"..- "); break;
                    case "v": cadenamorse.Add(@"...- "); break;
                    case "w": cadenamorse.Add(@".-- "); break;
                    case "x": cadenamorse.Add(@"-..- "); break;
                    case "y": cadenamorse.Add(@"-.-- "); break;
                    case "z": cadenamorse.Add(@"--.. "); break;
                    default: cadenamorse.Add(@"     "); break;
                }
          

            }

        }*/





    }
}
