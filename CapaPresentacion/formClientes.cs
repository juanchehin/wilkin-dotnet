using System;
using System.Windows.Forms;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class formClientes : Form
    {
        CN_Clientes objetoCN = new CN_Clientes();

        private int IdCliente;
        private int desde = 0;

        public formClientes()
        {
            InitializeComponent();
            ListarClientesPaginado(0);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ListarClientesPaginado(0);

        }
        public void ListarClientesPaginado(int desde)
        {
            dataListadoClientes.DataSource = objetoCN.ListarClientesPaginado(this.desde);
            dataListadoClientes.Columns[0].Visible = false;
            lblTotalClientes.Text = "Total de Registros: " + Convert.ToString(dataListadoClientes.Rows.Count);
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {

        }

        //Mostrar Mensaje de Confirmación
        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "Wilkin Lubricentro", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }


        //Mostrar Mensaje de Error
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Wilkin Lubricentro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Realmente Desea Eliminar el cliente", "Wilkin Lubricentro", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (Opcion == DialogResult.OK)
                {
                    CN_Clientes.Eliminar(this.IdCliente);
                    this.ListarClientesPaginado(0);
                }
                this.MensajeOk("Se elimino de forma correcta el registro");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
            this.Close();
        }

        private void BuscarCliente()
        {
            this.dataListadoClientes.DataSource = objetoCN.BuscarCliente(this.txtBuscarApellido.Text,this.txtBuscarNombres.Text);
            // this.OcultarColumnas();
            lblTotalClientes.Text = "Total de Registros: " + Convert.ToString(dataListadoClientes.Rows.Count);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.BuscarCliente();
        }

        private void btnNuevoCliente_Click(object sender, EventArgs e)
        {
            formNuevoEditarClientes frm = new formNuevoEditarClientes(this.IdCliente, true);
            frm.MdiParent = this.MdiParent;
            frm.Show();
            this.Close();
        }

        private void dataListadoClientes_SelectionChanged(object sender, EventArgs e)
        {
            if (dataListadoClientes.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataListadoClientes.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataListadoClientes.Rows[selectedrowindex];
                this.IdCliente = Convert.ToInt32(selectedRow.Cells["IdCliente"].Value);
            }
        }

        private void botonEditarListado_Click_1(object sender, EventArgs e)
        {
            formNuevoEditarClientes frm = new formNuevoEditarClientes(this.IdCliente, false);
            frm.MdiParent = this.MdiParent;
            frm.Show();
            this.Close();
        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Realmente Desea Eliminar el cliente", "Wilkin Lubricentro", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (Opcion == DialogResult.OK)
                {
                    CN_Clientes.Eliminar(this.IdCliente);
                    this.ListarClientesPaginado(0);
                    this.MensajeOk("Se elimino de forma correcta el registro");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
            this.Close();
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnBuscar_Click(this, new EventArgs());
            }
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            this.ListarClientesPaginado(0);
        }

        private void btnAyuda_Click(object sender, EventArgs e)
        {
            formInformacion frm = new formInformacion();
            frm.Show();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if(this.desde > Convert.ToInt32(lblTotalClientes))
            {
                return;
            }
            this.desde += 20;

            this.ListarClientesPaginado(this.desde);
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (this.desde <= 0)
            {
                return;
            }
            this.desde -= 20;

            this.ListarClientesPaginado(this.desde);
        }

        private void btnAgregarTrabajo_Click(object sender, EventArgs e)
        {
            formNuevoTrabajo frm = new formNuevoTrabajo(this.IdCliente);
            frm.Show();
        }

        private void btnHistorial_Click(object sender, EventArgs e)
        {
            formHistorial frm = new formHistorial(this.IdCliente);
            frm.Show();
        }

        private void btnBuscarPatente_Click(object sender, EventArgs e)
        {
            this.dataListadoClientes.DataSource = objetoCN.BuscarPatente(this.txtPatente.Text);
            // this.OcultarColumnas();
            lblTotalClientes.Text = "Total de Registros: " + Convert.ToString(dataListadoClientes.Rows.Count);
        }
    }

}
