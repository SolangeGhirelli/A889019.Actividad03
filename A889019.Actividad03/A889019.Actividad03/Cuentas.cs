using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A889019.Actividad03
{
    class Cuentas
    {
        public static int Codigo { get; set; }
        public static string Nombre { get; set; }
        public static string Tipo { get; set; }

        public Cuentas() { }
        public Cuentas(string linea)
        {
            var datos = linea.Split(';');
            Codigo = int.Parse(datos[0]);
            Nombre = datos[1];
            Tipo = datos[2];
        }

        public string ObtenerLineaDatos()
        {
            return $"{Codigo}; {Nombre}; {Tipo}";
        }
       
        public static Cuentas IngresarNueva()
        {
             var cuentas = new Cuentas();
        
             Codigo = IngresoCodigo();
             Nombre = Ingreso("Ingrese un nombre: ");
             Tipo = IngresoTipo("Seleccione de que tipo es la cuenta:");

            return cuentas;

        }

        public static void Modificar()
        {
            Console.WriteLine($"Código: {Codigo} - S para mdoificar / N para seguir.");

            var tecla = Console.ReadKey(intercept: true);
            if (tecla.Key == ConsoleKey.S)
            {
                Console.WriteLine("Ingrese el nuevo codigo: ");
                Codigo = IngresoCodigo();
            }

            Console.WriteLine($"Nombre: {Nombre} - S para mdoificar / N para seguir.");

            tecla = Console.ReadKey(intercept: true);
            if (tecla.Key == ConsoleKey.S)
            {
                Nombre = Ingreso("Ingrese el nuevo nombre.");
            }
            
            Console.WriteLine($"Tipo: {Tipo} - S para mdoificar / N para seguir.");

            tecla = Console.ReadKey(intercept: true);
            if (tecla.Key == ConsoleKey.S)
            {
                Tipo = IngresoTipo("Seleccione el nuevo tipo de cuenta.");
            }

            PlanDeCuentas.Grabar();


        }

        public static void Mostrar()
        {
            Console.WriteLine($"Código: {Codigo}");
            Console.WriteLine($"Nombre: {Nombre}");
            Console.WriteLine($"Tipo: {Tipo}");
        }

        public static Cuentas CrearBusqueda()
        {
            var modelo = new Cuentas();

            Console.WriteLine("Ingrese el codigo para buscar o [enter] para continuar.");

            Codigo = IngresoCodigo(obligatorio: false);
            Nombre = Ingreso("Ingrese un nombre para buscar: " , obligatorio: false);
            Tipo = IngresoTipo("Seleccione un tipo para buscar: ", obligatorio: false);

            return modelo;
        }

        public bool CoincideCon(Cuentas modelo)
        {
           if(Codigo != Codigo)
            {
                return false;

            }

           if(!string.IsNullOrWhiteSpace(Nombre) && Nombre != Nombre)
            {
                return false;
            }           
            
            if(!string.IsNullOrWhiteSpace(Tipo) && Tipo != Tipo)
            {
                return false;
            }

            return true;
        }

        private static string Ingreso(string titulo, bool permiteNumeros = false, bool obligatorio = true)
        {
            var ingreso = Console.ReadLine();
            do
            {
                Console.WriteLine(titulo);

                if(!obligatorio && string.IsNullOrEmpty(ingreso))
                {
                    return null;
                }


                if (obligatorio && string.IsNullOrWhiteSpace(ingreso))
                {
                    Console.WriteLine("Debe ingresar un nombre válido.");
                    continue;
                }

                if(!permiteNumeros && ingreso.Any(Char.IsDigit))
                {
                    Console.WriteLine("El nombre ingresado no debe contener números.");
                    continue;
                }

                break;

            } while (false);

           return Nombre;
        }
                
        private static int IngresoCodigo(bool obligatorio = true)
        {
            Console.WriteLine("Ingrese un codigo: ");
            var ingreso = Console.ReadLine();
            do
            {               
                if (!int.TryParse(ingreso, out var codigo))
                {
                    Console.WriteLine("Debe ingresar un valor.");
                    continue;
                }

                if (!ingreso.Any(Char.IsDigit))
                {
                    Console.WriteLine("El valor ingresado debe contener números.");
                    continue;
                }

                if (PlanDeCuentas.Existe(codigo))
                {
                    Console.WriteLine("El dato ingresado ya existe.");
                    continue;
                }

                break;

            } while (false);

            return Codigo;
        }

        private static string IngresoTipo(string titulo, bool obligatorio = true)
        {
            string ingreso = Console.ReadLine();
            do
            {
                Console.WriteLine("Seleccione el tipo de cuenta: ");
                Console.WriteLine("A- Activo");
                Console.WriteLine("B- Pasivo");

                var tecla = Console.ReadKey(intercept: true);

                if(!obligatorio)
                {
                    return null;
                }

                if(tecla.Key == ConsoleKey.A)
                {
                    Console.WriteLine("Su cuenta es de tipo Activo.");
                    break;
                }
                if(tecla.Key == ConsoleKey.B)
                {
                    Console.WriteLine("Su cuenta es de tipo Pasivo.");
                    break;
                }

            } while (false);

            return Tipo;
        }
    }
}
