using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;



namespace Helpers
{

    public static class ConversorAMorse
    {

        public static void CreandoMorse(string cadena)
        {
            string larutaamorse = SoportesParaConfiguracion.LeerConfiguracion() + @"\Morse";
            Console.WriteLine(larutaamorse);
            if (!Directory.Exists(larutaamorse))
            {
                Directory.CreateDirectory(larutaamorse);



            }
                  File.WriteAllText(larutaamorse + @"\TextoAMorse.txt", SoportesParaConfiguracion.TextoAMorse(cadena));

        }


        public static void CreandoTexto(string cadena)
        {
            string larutademorseatexto = SoportesParaConfiguracion.LeerConfiguracion() + @"\TextoAMorse";
            if (!Directory.Exists(larutademorseatexto))
            {
                Directory.CreateDirectory(larutademorseatexto);

                

            }
            
          
                File.WriteAllText(larutademorseatexto + @"\MorseATexto.txt", SoportesParaConfiguracion.MorseATexto(cadena));

        }


        public static void elsonidito(){

            //Direcciones de los archivos de sonido
            string sonidopunto = SoportesParaConfiguracion.LeerConfiguracion() + @"\punto.mp3";
            string sonidoraya = SoportesParaConfiguracion.LeerConfiguracion() + @"\raya.mp3";

            //Valos en bytes para UN punto y UNA RAYA
            byte[] valoresdelarchivo_punto;
            byte[] valoresdelarchivo_raya;


            //Guardo los valores en bytes de los sonidos
            FileStream origen_punto = new FileStream(sonidopunto, FileMode.Open);//Guarda los sonidos un solo punto
            valoresdelarchivo_punto = LectorCompletoDeBinario(origen_punto);
            origen_punto.Close();

            FileStream origen_raya = new FileStream(sonidoraya, FileMode.Open);//Guarda los sonidos una sola raya
            valoresdelarchivo_raya = LectorCompletoDeBinario(origen_raya);
            origen_raya.Close();


            List<byte> lista = new List<byte>();//Para almacenarlos en una lista (ahora vacia)

            
            string laruta = SoportesParaConfiguracion.LeerConfiguracion() + @"\Morse\TextoAMorse.txt";
          
            //Contenido de todo el archivo de texto en morse
            string caracteres = File.ReadAllText(laruta);
     
            //Recorre el archivo de texto
            foreach (char car in caracteres)
            {
                if(car == '.'){
                    //Agrega los bytes del sonido de punto
                    lista.AddRange(valoresdelarchivo_punto); 
                }
                else if (car == '-')
                {
                    //Agrega los bytes del sonido de raya
                    lista.AddRange(valoresdelarchivo_raya); 
                }


            }
            //Crea y abro un nuevo archivo de audio mp3
            FileStream Destino = new FileStream(SoportesParaConfiguracion.LeerConfiguracion() + @"\audio.mp3", FileMode.Create);
            //Lo carga con los sonidos de la lista
            Destino.Write(lista.ToArray(), 0, lista.Count() );
            //Lo cierro
            Destino.Close();
        }

        public static byte[] LectorCompletoDeBinario(Stream stream)
        {
            byte[] buffer = new byte[32768];
            using (MemoryStream ms = new MemoryStream()) // creando un memory stream 
            {
                while (true)
                {
                    int read = stream.Read(buffer, 0, buffer.Length); // lee desde la última posición hasta el tamaño del buffer
                    if (read <= 0)
                        return ms.ToArray(); // convierte el stream en array 
                    ms.Write(buffer, 0, read); // graba en el stream 
                }
            }
        }
    }
}