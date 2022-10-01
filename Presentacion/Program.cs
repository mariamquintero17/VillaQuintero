using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;
using Logica;
using static Logica.ServicioClientes;
using static Logica.ServiciosCuentas;

namespace Presentacion
{
    static class Program
    {
        static int opcion;
        static void Main(string[] args)
        {
            do
            {
                Console.Clear();
                Console.WriteLine("******************************* BANCO *********************************");
                Console.WriteLine("*                                                                     *");
                Console.WriteLine("*        1. CLIENTE                                                   *");
                Console.WriteLine("*        2. CUENTA                                                    *");
                Console.WriteLine("*        3. SALIR                                                     *");
                Console.WriteLine("*                                                                     *");
                Console.WriteLine("***********************************************************************");
                Console.Write("Digite una opcion:  ");
                opcion = Convert.ToInt32(Console.ReadLine());
                switch (opcion)
                {
                    case 1:
                        MenuCliente.Menu();
                        break;
                    case 2: 
                        MenuCuenta.Menu();
                        break;
                    case 3:
                        Environment.Exit(3);
                        break;
                }
            } while (opcion != 3);
        }
    }
}
