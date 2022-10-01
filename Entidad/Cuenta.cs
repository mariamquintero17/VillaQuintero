using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class Cuenta
    {
        public double NumeroCuenta { get; set; }
        public Cliente Cliente { get; set; }
        public double Saldo;
        public Cuenta(double numeroCuenta, Cliente cliente, double saldo)
        {
            NumeroCuenta = numeroCuenta;
            Cliente = cliente;
            Saldo = saldo;
        }

        public Cuenta()
        {

        }

        public double getSaldo()
        {
            return Saldo;
        }
        public void Consignar(double valor)
        {
            Saldo += valor;
            //Console.WriteLine("Su nuevo saldo es: "+ Saldo);
        }
        public void Retirar(double valor)
        {
            Saldo -= valor;
        }
        public override string ToString()
        {
            return NumeroCuenta.ToString() + ";" + Cliente.IdCliente + ";" + Saldo.ToString();
        }
    }
}
