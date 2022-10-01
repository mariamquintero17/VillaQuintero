using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class RepositorioClientes
    {
        string ruta = "Clientes.txt";
        public string Guardar(Cliente cliente)
        {
            try
            {
                StreamWriter escritor = new StreamWriter(ruta, true);
                escritor.WriteLine(cliente.Linea());
                escritor.Close();
                return "Se guardaron los datos satisfactoriamente";
            }
            catch (Exception)
            {
                return "NO se guardaron los datos";
            }  
        }
        public Cliente Buscar(string identificacion)
        {
            List<Cliente> clientes = ConsultarTodos();
            foreach (var item in clientes)
            {
                if (Encontrado(item.IdCliente, identificacion))
                {
                    return item;
                }
            }
            return null;
        }
        private bool Encontrado(string IdClienteRegistrado, string IdClienteBuscado)
        {
            return IdClienteRegistrado == IdClienteBuscado;
        }
        public List<Cliente> ConsultarTodos()
        {
            List<Cliente> clientes = new List<Cliente>();
            StreamReader lector = new StreamReader(ruta);
            string linea = string;
            while (lector.EndOfStream)
            {
                linea = lector.ReadLine();
                Cliente cliente = new Cliente(linea);
                clientes.Add(cliente);
            }
            lector.Close();
            return clientes;
        }
        public void Eliminar(String identificacion)
        {
            List<Cliente> clientes = new List<Cliente>();
            clientes = ConsultarTodos();
            FileStream archivo = new FileStream(ruta, FileMode.Create);
            archivo.Close();
            foreach (var item in clientes)
            {
                if (!Encontrado(item.IdCliente, identificacion))
                {
                    Guardar(item);
                }
            }
        }
        public void Modificar(List<Cliente> clientes) 
        {
            try
            {
                StreamWriter escritor = new StreamWriter("tmp.txt");// sobreescribe
                foreach (var item in clientes)
                {
                    escritor.WriteLine(item.Linea());
                }
                escritor.Close();
                File.Delete(ruta);  // elimina
                File.Move("tmp.txt", ruta);// renombrar
            }
            catch (Exception)
            {

            }
        }
        public Cliente BuscarId(string id)
        {
            foreach (var item in ConsultarTodos())
            {
                if (item.IdCliente == id)
                {
                    return item;
                }
            }
            return null;
        }
    }
}

