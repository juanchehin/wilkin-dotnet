using CapaNegocio;
using System;
using System.Data;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class formNuevoTrabajo : Form
    {
        CN_Clientes objetoCN = new CN_Clientes();
        DataTable respuesta;
        int IdCliente;
        public formNuevoTrabajo(int IdCliente)
        {
            InitializeComponent();
            this.IdCliente = IdCliente;
            dameCliente(IdCliente);
            rellenarComboxs();
            lblFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        private void dameCliente(int IdCliente)
        {
            respuesta = objetoCN.MostrarCliente(IdCliente);

            foreach (DataRow row in respuesta.Rows)
            {
                lblApellidosNomb.Text = Convert.ToString(row["Apellidos"]) + " " + Convert.ToString(row["Nombres"]);
                //lblNombres.Text = Convert.ToString(row["Nombres"]);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";

                rpta = CN_Clientes.NuevoTrabajo(this.IdCliente,txtAceite.Text.Trim(), txtFiltro.Text.Trim(), cbCorreaDist.Text,cbAlternador.Text, cbTensorDist.Text, cbBombaAgua.Text
                    , cbPastillaFreno.Text, cbRefrigerante.Text, cbBujia.Text, cbCambioAceite.Text, cbFiltroAceite.Text, cbComb.Text, cbAA.Text, txtKm.Text.Trim(),rtbObservaciones.Text.Trim());                    
                if (rpta.Equals("Ok"))
                {
                       
                    this.MensajeOk("Se Insertó de forma correcta el registro");
                        
                }
                else
                {
                    this.MensajeError(rpta);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
            this.Close();
        }

        private void rellenarComboxs()
        {
            cbAA.Items.Add("No");
        }

        //Mostrar Mensaje de Error
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Wilkin Lubricentro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "Wilkin Lubricentro", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}
