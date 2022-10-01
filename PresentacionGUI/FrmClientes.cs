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
    public partial class FrmClientes : Form
    {
        public FrmClientes()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            //Buscar(txtCliente.Text);
        }

        private void Buscar(string id)
        {
            ServicioClientes sc = new ServicioClientes();
            Cliente cliente;
            cliente = sc.BuscarId(id);
            if (cliente == null)
            {
                MessageBox.Show("No Existe", "Mensaje",(MessageBoxButtons.OK),MessageBoxIcon.Warning);
                return;
            }
            Ver(cliente);
        }

        private void Ver(Cliente cliente)
        {
            txtCliente.Text = cliente.IdCliente;
            txtNombre.Text = cliente.Nombre;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtNombre.Enabled = true;
            ClearText();
        }

        private void ClearText()
        {
            txtCliente.Text = "";
            txtNombre.Text = "";
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmClientes_Load(object sender, EventArgs e)
        {
            txtNombre.Enabled = false; 
            CargarGrilla1();
        }

        private void CargarGrilla1()
        {
            Cliente cliente = new Cliente();
            ServicioClientes servicio = new ServicioClientes();
            dgClientes.Rows.Clear();
            foreach (var item in servicio.Consultar())
            {
                 dgClientes.Rows.Add(item.IdCliente, item.Nombre.ToUpper()); 
            }
        }
        private void CargarGrilla(string filtro)
        {
            Cliente cliente = new Cliente();
            ServicioClientes servicio = new ServicioClientes();
            dgClientes.Rows.Clear();
            foreach (var item in servicio.Consultar())
            {
                if (item.Nombre.StartsWith(filtro.ToUpper()))
                {
                    dgClientes.Rows.Add(item.IdCliente, item.Nombre.ToUpper());
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Guardar(new Cliente(txtCliente.Text, txtNombre.Text));
            ClearText();
        }

        private void Guardar(Cliente cliente)
        {
            ServicioClientes SC = new ServicioClientes();
            string mensaje= SC.Guardar(cliente);
            MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dgClientes.Rows.Clear();
            CargarGrilla("");
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Eliminar(new Cliente(txtCliente.Text, txtNombre.Text));
            ClearText();
        }

        private void Eliminar(Cliente cliente)
        {
            ServicioClientes SC = new ServicioClientes();
            string mensaje = SC.Eliminar(cliente.IdCliente);
            MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dgClientes.Rows.Clear();
            CargarGrilla("");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            txtNombre.Enabled = true;
            Buscar(txtCliente.Text);
        }

        private void dgClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCliente.Enabled = true;
            txtNombre.Enabled = true;
            var fila = e.RowIndex;
            if (dgClientes.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                dgClientes.CurrentRow.Selected = true;
                txtCliente.Text = dgClientes.Rows[fila].Cells[0].Value.ToString();
                txtNombre.Text = dgClientes.Rows[fila].Cells[1].Value.ToString();
            }
        }
    }
}
