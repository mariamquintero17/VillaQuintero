using Entidad;
using Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Logica.ServiciosCuentas;

namespace Presentacion
{
    public class MenuCuenta
    {
        static double saldo, opcion = 0, consignar = 0, retirar = 0;
        static ServiciosCuentas servicioCuentas = new ServiciosCuentas();
        static ServicioClientes servicio = new ServicioClientes();
        public static void Menu()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("******************************* CUENTA *******************************");
                Console.WriteLine("*                                                                     *");
                Console.WriteLine("*        1. CREAR                                                     *");
                Console.WriteLine("*        2. LISTADO                                                   *");
                Console.WriteLine("*        3. CONSIGNAR                                                 *");
                Console.WriteLine("*        4. RETIRAR                                                   *");
                Console.WriteLine("*        5. REGRESAR                                                  *");
                Console.WriteLine("*                                                                     *");
                Console.WriteLine("***********************************************************************");
                Console.Write("Digite una opcion:  ");
                opcion = Convert.ToInt32(Console.ReadLine());
                switch (opcion)
                {
                    case 1:
                        Crear();
                        break;
                    case 2:
                       // servicioCuentas.Actualizar();
                        Consultar();
                        break;
                    case 3:
                        Consignar();
                        break;
                    case 4:
                        Retirar();
                        break;
                    default:
                        break;
                }
            } while (opcion != 5);
        }
        public static void Crear()
        {
            ServiciosCuentas servicioCuentas = new ServiciosCuentas();
            Console.Clear();
            Cliente cliente;
            string cc;
            double saldo, numeroCuenta;
            Console.WriteLine("--- CREAR CUENTA ---");
            Console.WriteLine("");
            Console.Write("Digite la cedula: ");
            cc = Console.ReadLine();
            cliente = new ServicioClientes().BuscarId(cc);
            if (cliente == null)
            {
                //Console.Clear();
                Console.WriteLine("");
                Console.WriteLine("El cliente no existe... debe crearlo primero");
                Console.WriteLine("");
                Console.Write("Digite cualquier tecla para regresar al menu...");
                Console.ReadKey();
            }
            else
            {
                Console.Write("Numero de cuenta : "); numeroCuenta = double.Parse(Console.ReadLine());
                Console.Write("saldo inicial : "); saldo = double.Parse(Console.ReadLine());
                Cuenta cuenta = new Cuenta(numeroCuenta, cliente, saldo);
                Console.WriteLine("");
                Console.WriteLine(servicioCuentas.Guardar(cuenta));
                Console.WriteLine("");
                Console.Write("Digite cualquier tecla para regresar al menu...");
                Console.ReadKey();
            }
        }
        public static void Consultar()
        {
            Console.Clear();
            ServiciosCuentas servicioCuentas = new ServiciosCuentas();
            Console.WriteLine("--- LISTADO DE CUENTAS ---");
            Console.WriteLine(" cuenta - cliente - saldo  ");
            Console.WriteLine("");
            foreach (var item in servicioCuentas.Listado())
            {
                Console.WriteLine("" + item.NumeroCuenta + " --> " + item.Cliente.Nombre + " --> " + item.getSaldo());
            }
            Console.WriteLine("");
            Console.Write("digite cualquier tecla para regresar al menu...");
            Console.ReadKey();
        }
        public static void Consignar()
        {
            Console.Clear();
            double numCuenta, valorConsignar; Cuenta cuenta;
            ServiciosCuentas servicioCuentas = new ServiciosCuentas();
            Console.WriteLine("--- CONSIGNAR ---");
            Console.WriteLine("");
            Console.Write("Numero de cuenta: ");
            numCuenta = double.Parse(Console.ReadLine());
            var lista = new ServiciosCuentas();
            cuenta = lista.BuscarCuenta(numCuenta);
            if (cuenta == null)
            {
                Console.WriteLine("");
                Console.WriteLine("El numero de cuenta no existe");
                Console.WriteLine("");
                Console.Write("Digite cualquier tecla para regresar al menu...");
                Console.ReadKey();
            }
            else
            {
                Console.Write("Valor a consignar: ");
                valorConsignar = double.Parse(Console.ReadLine());     
                cuenta.Consignar(valorConsignar);
                Console.WriteLine("Consignacion Exitosa");
                servicioCuentas.Modificar(lista.Listado());
                Console.WriteLine("");
                Console.Write("Digite cualquier tecla para regresar al menu...");
                Console.ReadKey();
            }
        }
        public static void Retirar()
        {
            Console.Clear();
            double numCuenta, valorConsignar; Cuenta cuenta;
            ServiciosCuentas servicioCuentas = new ServiciosCuentas();
            Console.WriteLine("--- RETIRAR ---");
            Console.WriteLine("");
            Console.Write("Numero de cuenta: ");
            numCuenta = double.Parse(Console.ReadLine());
            var lista = new ServiciosCuentas();
            cuenta = lista.BuscarCuenta(numCuenta);
            if (cuenta == null)
            {
                Console.WriteLine("");
                Console.WriteLine("El numero de cuenta no existe");
                Console.WriteLine("");
                Console.Write("Digite cualquier tecla para regresar al menu...");
                Console.ReadKey();
            }
            else
            {
                Console.Write("Valor a retirar: ");
                valorConsignar = double.Parse(Console.ReadLine());
                if (cuenta.Saldo < valorConsignar)
                {
                    Console.WriteLine("Saldo insuficiente");
                    Console.Write("Digite cualquier tecla para regresar al menu...");
                    Console.ReadKey();
                }
                else
                {
                    cuenta.Retirar(valorConsignar);
                    Console.WriteLine("Retiro Exitoso");
                    servicioCuentas.Modificar(lista.Listado());
                    Console.WriteLine("");
                    Console.Write("Digite cualquier tecla para regresar al menu...");
                    Console.ReadKey();
                }
                
            }
        }
    }
}
