using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;
using Datos;

namespace Logica
{
    public class ServicioClientes
    {
        List<Cliente> clientes;
        RepositorioClientes repositorioClientes = new RepositorioClientes();
        public ServicioClientes()
        {
            clientes = repositorioClientes.ConsultarTodos();
        }
        public string Guardar(Cliente cliente)
        {
            try
            {
                if (repositorioClientes.Buscar(cliente.IdCliente) == null)
                {
                    repositorioClientes.Guardar(cliente);
                    Actualizar();
                    return "Se guardaron los datos de manera exitosa";
                }
                return "No es posible guardar los datos";
            }
            catch (Exception e)
            {
                return "Error:" + e.Message;
            }
        }
        public void Actualizar()
        {
            clientes = repositorioClientes.ConsultarTodos();
        }
        public List<Cliente> Consultar()
        {
            return clientes;
        }
        public string Eliminar(string identificacion)
        {
            try
            {
                if (repositorioClientes.Buscar(identificacion) != null)
                {
                    repositorioClientes.Eliminar(identificacion);
                    return ($"se han eliminado satisfactoriamente los datos del cliente con identificacion: {identificacion} ");
                }
                else
                {
                    return ($"Lo sentimos, no se encuentra registrado el cliente con identificacion {identificacion}");
                }
            }
            catch (Exception e)
            {

                return $"Error de la Aplicacion: {e.Message}";
            }
        }
        public Cliente ClienteExist(string idCliente)
        {
            if(repositorioClientes.Buscar(idCliente)!= null)
            {
                Console.WriteLine("El cliente ya existe");
            }
            return null;
        }
        
        public string Modificar(Cliente cliente_New)
        {
            Cliente cliente_actual = BuscarId(cliente_New.IdCliente);
            if (cliente_actual == null)
            {
                return Guardar(cliente_New);
            }
            else
            {
                cliente_actual.Nombre = cliente_New.Nombre;
                repositorioClientes.Modificar(clientes);
                Console.WriteLine("");
                return  ($"se han modificado satisfactoriamente los datos del cliente con identificacion {cliente_New.IdCliente} ");
            }
        }
        public Cliente BuscarId(string id)
        {
            foreach (var item in clientes)
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