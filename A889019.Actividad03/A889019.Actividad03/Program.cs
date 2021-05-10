using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A889019.Actividad03
{
    class Program
    {
        private static void Main(string[] args)
        {
            //Perimitir la modificación del plan de cuentas:
            //Dar de alta. -
            //Modificar. -
            //Eliminar cuentas. -
            //Validar con los archivos:
            //Archivo punto 1 "Diario.txt" con los datos NroAsiento/Fecha/CodigoCuenta/Debe/Haber
            //Archivo punto 2 "Mayor.TXT" datos CodigoCuenta/Fecha/Debe/Haber

            bool salir = false;
            do
            {
                Console.WriteLine("MENU PRINCIPAL");


                Console.WriteLine("1- Alta.");
                Console.WriteLine("2- Modificar.");
                Console.WriteLine("3- Eliminar.");
                Console.WriteLine("0- Salir.");

                Console.WriteLine("Elija una opción: ");
                var opcion = Console.ReadLine();
                switch (opcion)
                {
                    case "1": 
                        Alta();
                        break;

                    case "2":
                        Modificar();
                        break;

                    case "3": 
                        Eliminar();
                        break;

                    case "0":
                        salir = true;
                        break;

                    default:
                        Console.WriteLine("No ha ingresado una opcion correcta.");
                        break;
                }

            } while (!salir);

        }

        private static void Alta()
        {
            var cuentas = Cuentas.IngresarNueva();
            PlanDeCuentas.Agregar(cuentas);
        }

        private static void Modificar()
        {
            var cuentas = PlanDeCuentas.SeleccionarCuenta();
            Cuentas.Mostrar();
            Cuentas.Modificar();
        }

        private static void Eliminar()
        {
            var cuentas = PlanDeCuentas.SeleccionarCuenta();
            Cuentas.Mostrar();
            PlanDeCuentas.Eliminar(cuentas);
        }
    }
}
