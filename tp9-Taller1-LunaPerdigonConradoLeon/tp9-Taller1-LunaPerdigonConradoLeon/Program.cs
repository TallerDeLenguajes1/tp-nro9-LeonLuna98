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
            string rutadelacarpeta = @"C:\CarpetaMorseFuncionando";
          
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
        
          
            Console.WriteLine("Ingrese una cadena de texto");
            string textoamorse = Console.ReadLine();
            Console.WriteLine("Ingrese una cadena en morse");
            string morseatexto = Console.ReadLine();

            //string hola = @"hola.";
            //string example = @"... --- ... .-..";
            Console.WriteLine("El texto en morse es: ");
             string convertidoamorse= SoportesParaConfiguracion.TextoAMorse(textoamorse);
            Console.WriteLine("El texto morse en castellano es: ");
            string convertidoatexto= SoportesParaConfiguracion.MorseATexto(morseatexto);



            ConversorAMorse.CreandoMorse(textoamorse);
            ConversorAMorse.CreandoTexto(morseatexto);

            ConversorAMorse.elsonidito();
            //System.IO.File.WriteAllText(@"\rutadelacarpeta\ElTextoEnMorse.txt", convertidoamorse);
            //System.IO.File.WriteAllText(@"\rutadelacarpeta\LaMorseEnTexto.txt", convertidoatexto);
            //SoportesParaConfiguracion.TextoAMorse(hola);


            //SoportesParaConfiguracion.MorseATexto(example);
            Console.ReadKey();
        }
       





       

    }
}
