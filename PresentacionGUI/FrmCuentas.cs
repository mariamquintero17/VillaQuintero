using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Logica;
using Entidad;

namespace PresentacionGUI
{
    public partial class FrmCuentas : Form
    {
        public FrmCuentas()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtIdCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            ServicioClientes SC = new ServicioClientes();
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                Cliente cliente;
                cliente = SC.BuscarId(txtIdCliente.Text);
                if (cliente == null)
                {
                    MessageBox.Show("Cliente no Existe", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtIdCliente.Text = "";
                    return;
                }
                Ver(cliente);
            } 
        }

        private void Ver(Cliente cliente)
        {
            txtIdCliente.Text = cliente.IdCliente;
            txtNombre.Text = cliente.Nombre;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtIdCliente.Enabled = true;
            txtNombre.Enabled = true;
            ClearText();
        }

        private void ClearText()
        {
            txtIdCliente.Text = "";
            txtNombre.Text = "";
            txtNumCuenta.Text = "";
            txtSaldo.Text = "";
        }

        private void FrmCuentas_Load(object sender, EventArgs e)
        {
            txtIdCliente.Enabled = false;
            txtNombre.Enabled = false;
            CargarGrilla1();
        }

        private void CargarGrilla1()
        {
            Cuenta cuenta = new Cuenta();
            ServiciosCuentas servicio = new ServiciosCuentas();
            dgCuentas.Rows.Clear();
            foreach (var item in servicio.Listado())
            {
                dgCuentas.Rows.Add(item.NumeroCuenta, item.Cliente.Nombre.ToUpper(), item.getSaldo());
            }
        }
        private void CargarGrilla(string filtro)
        {
            Cuenta cuenta = new Cuenta();
            ServiciosCuentas servicio = new ServiciosCuentas();
            dgCuentas.Rows.Clear();
            foreach (var item in servicio.Listado())
            {
                if (item.Cliente.Nombre.StartsWith(filtro.ToUpper()))
                {
                    dgCuentas.Rows.Add(item.NumeroCuenta, item.Cliente.Nombre.ToUpper(), item.getSaldo());
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Cliente cliente;
            ServiciosCuentas scuenttas = new ServiciosCuentas();
            //ServicioClientes SC = new ServicioClientes();
            cliente = new ServicioClientes().BuscarId(txtIdCliente.Text);
          //  if(cliente )
            Guardar(new Cuenta(Convert.ToDouble(txtNumCuenta.Text), cliente, Convert.ToDouble(txtSaldo.Text)));
            ClearText();
        }

        private void Guardar(Cuenta cuenta)
        {
            ServiciosCuentas SC = new ServiciosCuentas();
            string mensaje = SC.Guardar(cuenta);
            MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dgCuentas.Rows.Clear();
            CargarGrilla("");
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            CargarGrilla("");
        }

        private void Consignar()
        {
            Cuenta cuenta;
            cuenta = new ServiciosCuentas().BuscarCuenta(Convert.ToDouble(txtNumCuenta.Text));
            if (cuenta == null)
            {
                MessageBox.Show("El numero de cuenta no existe");
            }
        }
        private void dgCuentas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtIdCliente.Enabled = true;
            txtNombre.Enabled = true;
            var fila = e.RowIndex;
            if (dgCuentas.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                dgCuentas.CurrentRow.Selected = true;
                //txtIdCliente.Text = dgCuentas.Rows[fila].Cells[0].Value.ToString();      
                txtNumCuenta.Text = dgCuentas.Rows[fila].Cells[0].Value.ToString();
                txtNombre.Text = dgCuentas.Rows[fila].Cells[1].Value.ToString();
                txtSaldo.Text = dgCuentas.Rows[fila].Cells[2].Value.ToString();
            }
        }
    }
}
