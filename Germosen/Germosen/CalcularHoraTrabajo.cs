using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabajadoresGermosen
{
    public class CalcularSueldoTrabajadores
    {

        #region Propiedades
        public int Horas { get; set; }
        public decimal Sueldo { get; set; }
        public String Trabajador { get; set; }
        public int Tipo { get; private set; }
        public decimal SueldoTotal { get; private set; }
        public decimal Impuesto { get; private set; }
        public decimal SueldoConImp { get; private set; }
        #endregion

        private static CalcularSueldoTrabajadores Instance;
        public static CalcularSueldoTrabajadores GetInstance()
        {
            if (Instance == null)
                Instance = new CalcularSueldoTrabajadores();
            return Instance;
        }

        public void SetPromedioPonderado()
        {
            int valor;

            Console.WriteLine("¿Introduce la cantidad de trabajadores que laboraron en la Cia de Germosen?");
            int a = Convert.ToInt32(Console.ReadLine());

            var esNumero = int.TryParse(a.ToString(), out valor);
            


            var items = new List<CalcularSueldoTrabajadores>();
            int contador = 1;
            for (int i = 1; i <= a; i++)
            {
                Console.WriteLine($"¿Introduce el nombre del Trabajador {contador}?");
                Trabajador = Console.ReadLine();

                Console.WriteLine($"¿Introduce la cantidad de Horas Trabajadas {contador}?");
                Horas = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine($"¿Introduce el sueldo por Hora {contador}?");
                Sueldo = Convert.ToDecimal(Console.ReadLine());


                Console.WriteLine($"¿Selecciona el tipo de Empleado {contador}?");

                Console.WriteLine("1- Obrero 2- Empleados");
                Tipo = Convert.ToInt32(Console.ReadLine());

                items.Add(new CalcularSueldoTrabajadores
                {
                    Trabajador = Trabajador,
                    Horas = Horas,
                    Sueldo = Sueldo,
                    Tipo = Tipo
                });

                contador = contador + 1;

            }

            if (items.Any())
            {
                //var SueldoTotal = 0.0M;
                //var SueldoConImp = 0.0M;
                Impuesto = 0.0M;

                Console.WriteLine("---------------------------------------------------------------");
                contador = 1;
                foreach (var p in items)
                {
                    p.SueldoTotal = (p.Horas * p.Sueldo);

                    if (p.SueldoTotal < 100000)
                    {
                        p.SueldoConImp = p.SueldoTotal;

                    }
                    else if (p.SueldoTotal > 100000)
                    {
                        p.Impuesto = (p.SueldoTotal * 0.10M);
                        p.SueldoConImp = (p.SueldoTotal + p.Impuesto);
                    }
                    Console.WriteLine($"{contador}). Trabajador:\t{p.Trabajador}\tHoras:\t{p.Horas}\tSueldo x Hora:\t{p.Sueldo}\tSueldoTotal:\t{p.SueldoConImp}");
                    contador++;
                }

                Console.WriteLine("---------------------------------------------------------------");
                SueldoConImp = items.Sum(x => x.SueldoConImp);
      

                Console.WriteLine("Total a Pagar de Nomina: " + SueldoConImp);
                Console.WriteLine("---------------------------------------------------------------");

            }
            else
            {
                Console.WriteLine("Debe introducir al menos un empleado para generar las horas trabajadas?");
            }


        }


    }
}
