using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A889019.Actividad03
{
    static class PlanDeCuentas
    {

        private static readonly Dictionary<int, Cuentas> entradas;
        static string nombreArchivo = "planDeCuentas.txt";

        static PlanDeCuentas()
        {
            entradas = new Dictionary<int, Cuentas>();

            if (File.Exists(nombreArchivo))
            {
                using (var reader = new StreamReader(nombreArchivo))
                {
                    while (!reader.EndOfStream)
                    {
                        var linea = reader.ReadLine();
                        var cuentas = new Cuentas(linea);
                        entradas.Add(Cuentas.Codigo, cuentas);
                    }
                }

            }
        }
        public static void Agregar(Cuentas cuentas)
        {
            entradas.Add(Cuentas.Codigo, cuentas);
            Grabar();
        }

        public static Cuentas SeleccionarCuenta()
        {
            var modelo = Cuentas.CrearBusqueda();

            foreach (var cuentas in entradas.Values)
            {
                if (cuentas.CoincideCon(modelo))
                {
                    return cuentas;
                }
            }

            Console.WriteLine("No se encontro una cuenta que coincida con los datos dados.");
            return null;
        }

        public static void Eliminar(Cuentas cuentas)
        {
            entradas.Remove(Cuentas.Codigo);
            Grabar();

        }

        public static bool Existe(int codigo)
        {
            return entradas.ContainsKey(codigo);
        }

        public static void Grabar()
        {
            var writer = new StreamWriter(nombreArchivo, append: false);
            foreach(var cuentas in entradas.Values)
            {
                var lineas = cuentas.ObtenerLineaDatos();
                writer.WriteLine(lineas);
            }
        }
    }
}
