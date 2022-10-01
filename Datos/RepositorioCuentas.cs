using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Entidad;

namespace Logica
{
    public class RepositorioCuentas
    {
        string ruta = "Cuentas.txt";
        public string Guardar(Cuenta cuenta)
        {
            try
            {
                StreamWriter escritor = new StreamWriter(ruta, true);
                escritor.WriteLine(cuenta.ToString());
                escritor.Close();

                return "Se guardaron los datos satisfactoriamente";
            }
            catch (Exception)
            {
                return "NO Se guardaron los datos";
            }
        }
        public Cuenta Buscar(double cuenta)
        {
            List<Cuenta> cuentas = ConsultarTodos();
            foreach (var item in cuentas)
            {
                if (Encontrado(item.NumeroCuenta, cuenta))
                {
                    return item;
                }
            }
            return null;
        }
        public string Modificar(List<Cuenta> cuentas)
        {
            try
            {
                StreamWriter escritor = new StreamWriter(ruta, false);
                foreach (var item in cuentas)
                {
                    escritor.WriteLine(item.ToString());
                }
                escritor.Close();

                return "Se modificaron los datos";
            }
            catch (Exception)
            {
                return "NO Se guardaron los datos";
            }
        }
        private bool Encontrado(double NumeroCunetaRegistrado, double NumeroCuentaBuscado)
        {
            return NumeroCunetaRegistrado == NumeroCuentaBuscado;
        }
        public List<Cuenta> ConsultarTodos()
        {
            try
            {
                List<Cuenta> cuentas = new List<Cuenta>();
                StreamReader lector = new StreamReader(ruta);
                string linea = string.Empty;
                while (!lector.EndOfStream)
                {
                    linea = lector.ReadLine();
                    double numCuenta = double.Parse(linea.Split(';')[0]);
                    Cliente cliente = new RepositorioClientes().BuscarId(linea.Split(';')[1]);
                    double saldo = double.Parse(linea.Split(';')[2]);

                    Cuenta cuenta = new Cuenta(numCuenta, cliente, saldo);
                    cuentas.Add(cuenta);
                }
                lector.Close();
                return cuentas;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}