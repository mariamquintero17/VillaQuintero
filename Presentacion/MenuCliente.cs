using Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;

namespace Presentacion
{
    public class MenuCliente
    {
        static double opcion = 0;
        static string nombre, cedula;
        static ServicioClientes servicio = new ServicioClientes();
        public static void Menu()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("******************************* CLIENTE *******************************");
                Console.WriteLine("*                                                                     *");
                Console.WriteLine("*        1. REGISTRAR                                                 *");
                Console.WriteLine("*        2. LISTADO                                                   *");
                Console.WriteLine("*        3. ELIMINAR                                                  *");
                Console.WriteLine("*        4. MODIFICAR                                                 *");
                Console.WriteLine("*        5. REGRESAR                                                  *");
                Console.WriteLine("*                                                                     *");
                Console.WriteLine("***********************************************************************");
                Console.Write("Digite una opcion:  ");
                opcion = Convert.ToInt32(Console.ReadLine());
                switch (opcion)
                {
                    case 1:
                        Registrar();
                        break;
                    case 2:
                        servicio.Actualizar();
                        Consultar();
                        break;
                    case 3:
                        Eliminar();
                        break;
                    case 4:
                        Modificar();
                        break;
                    default:
                        break;
                }
            } while (opcion != 5);
        }
        public static void Registrar()
        {
            Console.Clear();
            Cliente cliente = new Cliente();
            Console.WriteLine("--- REGISTRAR CLIENTE ---");
            Console.WriteLine("");
            Console.Write("Digite su nombre: ");
            cliente.Nombre = Console.ReadLine();
            Console.Write("Digite su cedula: ");
            cliente.IdCliente = Console.ReadLine();
            if ((servicio.ClienteExist(cliente.IdCliente) != null))
            {
            }
            Console.WriteLine("");
            Console.WriteLine(servicio.Guardar(cliente));
            Console.WriteLine("");
            Console.Write("digite cualquier tecla para regresar al menu...");
            Console.ReadKey();
        }
        public static void Consultar()
        {
            Console.Clear();
            List<Cliente> listaClientes = servicio.Consultar();
            Console.WriteLine("--- LISTADO DE CLIENTES ---");
            Console.WriteLine("     cedula - cliente");
            Console.WriteLine("");
            foreach (var item in listaClientes)
            {
                Console.WriteLine("        " + item.IdCliente + " - " + item.Nombre);
            }
            Console.WriteLine("");
            Console.Write("digite cualquier tecla para regresar al menu...");
            Console.ReadKey();
        }
        public static void Eliminar()
        {
            Console.Clear();
            string cc;
            Console.WriteLine("--- ELIMINAR CLIENTE ---");
            Console.WriteLine("");
            Console.Write("Digite la cedula: ");
            cc = Console.ReadLine();
            Console.WriteLine("");
            Console.WriteLine(servicio.Eliminar(cc));
            Console.WriteLine("");
            Console.Write("digite cualquier tecla para regresar al menu...");
            Console.ReadKey();
        }
        public static void Modificar()
        {
            Console.Clear();
            String cc;
            Cliente cliente = new Cliente();
            Console.WriteLine("--- MODIFICAR CLIENTE ---");
            Console.WriteLine("");
            Console.Write("Digite la cedula: ");
            cc = Console.ReadLine();
            cliente = servicio.BuscarId(cc);
            if ((cliente == null))
            {
                Console.WriteLine("");
                Console.WriteLine($"Lo sentimos, no se encuentra registrado el cliente con identificacion {cc}");
                Console.WriteLine("");
                Console.Write("digite cualquier tecla para regresar al menu...");
                Console.ReadKey();
            }
            else
            {
                Console.Write("Digite el nuevo Nombre: ");
                cliente.Nombre = Console.ReadLine();
                Console.WriteLine(servicio.Modificar(cliente));
                Console.WriteLine("");
                Console.Write("digite cualquier tecla para regresar al menu...");
                Console.ReadKey();
            }
        }
    }
}
