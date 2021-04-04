using SivBiblioteca;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            ConfigGlobal.inicializarConexion();
            var unidades = ConfigGlobal.conexion.UnidadesExistentesProducto(100);
            Console.WriteLine(unidades);
            Console.ReadLine();
        }
    }
}
