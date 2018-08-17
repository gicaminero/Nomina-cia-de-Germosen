using System;
using System.Collections.Generic;

namespace TrabajadoresGermosen
{
    class Program
    {
        static void Main(string[] args)
        {

            var volverOpcion = "";
            do
            {
                Console.Clear();
                try
                {

                    CalcularSueldoTrabajadores.GetInstance().SetPromedioPonderado();
                    var list = new List<Integrantes>();

                    //listado de los integrantes...
                    list.Add(new Integrantes { Nombres = "Gilbert Matos", Matricula = "17-EIIT-1-018", Seccion = "0463" });
                    foreach (var item in list)
                    {
                        Console.WriteLine(item.Matricula + " " + item.Nombres + " " + item.Seccion);
                    }
                  
                }
                catch (Exception ex)
                {
                    Console.WriteLine("---------------------------------------------------------------");
                    Console.WriteLine("Hubo un error al introducir los datos, favor de realizar la informacion que se le pide...");
                    Console.WriteLine("---------------------------------------------------------------");
                }

                Console.WriteLine("Presione 1 para volver a realizar la nomina?");
                volverOpcion = Console.ReadLine();

            } while (volverOpcion == "1");


            Console.Clear();


        }
    }

    public class Integrantes
    {
        public string Nombres { get; set; }
        public string Matricula { get; set; }
        public string Seccion { get; set; }
    }

}
