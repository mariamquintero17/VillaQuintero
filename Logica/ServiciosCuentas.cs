using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;
using Datos;
namespace Logica
{
    public class ServiciosCuentas
    {
        List<Cuenta> cuentas;
        RepositorioCuentas repositorioCuentas = new RepositorioCuentas();
        public ServiciosCuentas()
        {
            cuentas = repositorioCuentas.ConsultarTodos();
        }
        public string Guardar(Cuenta cuenta)
        {
            try
            {
                if (repositorioCuentas.Buscar(cuenta.NumeroCuenta) == null)
                {
                    repositorioCuentas.Guardar(cuenta);
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
        /*  public CuentaConsultaResponse Consultar()
          {
              try
              {
                  List<Cuenta> cuentas = repositorioCuentas.ConsultarTodos();
                  var response = new CuentaConsultaResponse(cuentas);
                  return response;
              }
              catch (Exception e)
              {
                  var response = new CuentaConsultaResponse("Error:" + e.Message);
                  return response;
              }
          }*/
        public void Actualizar()
        {
            cuentas = repositorioCuentas.ConsultarTodos();
        }
        public string Modificar(List<Cuenta> cuentas)
        {
            //validar
            return repositorioCuentas.Modificar(cuentas);
        }
        public List<Cuenta> Listado()
        {
            return cuentas;
        }
        public Cuenta BuscarCuenta(double cuenta)
        {
            Actualizar();
            foreach (var item in cuentas)
            {
                if (item.NumeroCuenta == cuenta)
                {
                    return item;
                }
            }
            return null;
        }
    }
}