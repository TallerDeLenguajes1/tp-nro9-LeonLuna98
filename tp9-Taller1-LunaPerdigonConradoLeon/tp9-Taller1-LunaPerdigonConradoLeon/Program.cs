using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Helpers;
namespace tp9_Taller1_LunaPerdigonConradoLeon
{
    class Program
    {
        static void Main(string[] args)
        {
            string rutadelacarpeta = @"\RutaCarpeta";
            /*
             SoportesParaConfiguracion.CrearArchivoDeConfiguracion(rutadelacarpeta);
             string cad=SoportesParaConfiguracion.LeerConfiguracion();
             Console.WriteLine(cad);

             foreach(string archivo in Directory.GetFiles(Directory.GetCurrentDirectory())){
                 if(Path.GetExtension(archivo)== ".txt" || Path.GetExtension(archivo)==".mp3")
                 {
                     if (!File.Exists(rutadelacarpeta + @"\" + Path.GetFileName(archivo)))
                     {
                         File.Copy(archivo, rutadelacarpeta + @"\"+ Path.GetFileName(archivo));
                     }

                 }
             }
          */
          /*
            Console.WriteLine("Ingrese una cadena de texto");
            string textoamorse = Console.ReadLine();
            Console.WriteLine("Ingrese una cadena en morse");
            string morseatexto = Console.ReadLine();
            */
            string hola = @"hola.";
            string example = @"... --- ... .-..";
            
            //string convertidoatexto= SoportesParaConfiguracion.MorseATexto(morseatexto);
            //string convertidoamorse= SoportesParaConfiguracion.MorseATexto(textoamorse);
            //System.IO.File.WriteAllText(@"\rutadelacarpeta\ElTextoEnMorse.txt", convertidoamorse);
            //System.IO.File.WriteAllText(@"\rutadelacarpeta\LaMorseEnTexto.txt", convertidoatexto);
            SoportesParaConfiguracion.TextoAMorse(hola);


            SoportesParaConfiguracion.MorseATexto(example);
            Console.ReadKey();
        }
       /* public static void MorseATexto(string cadena)
        {
            List<char> cadenamorse = new List<char>();

            foreach (char letra in cadena)
            {
                switch (cadena)
                {
                    case "a":
                        cadenamorse.Add('.');
                        cadenamorse.Add('-');
                        cadenamorse.Add(' ');

                        ; break;


                }
            }
             StringBuilder sb = new StringBuilder(cadenamorse.ToString());
            //Console.Write(cadenamorse.ToArray().ToString());
            Console.WriteLine(sb);
           





        } */

    }
}
