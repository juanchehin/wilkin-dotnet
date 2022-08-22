using CapaNegocio;
using System;
using System.Data;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class formNuevoEditarTrabajo : Form
    {
        public formNuevoEditarTrabajo(int parametro, bool IsNuevoEditar)
        {
            InitializeComponent();
            this.IdCliente = parametro;
            this.bandera = IsNuevoEditar;
        }

        CN_Clientes objetoCN = new CN_Clientes();
        DataTable respuesta;
        // int parametroActual;
        bool bandera;
        bool IsNuevo = false;
        bool IsEditar = false;

        private int IdCliente;
        private int IdTrabajo;

        private void formNuevoEditarClientes_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txtKm;
            if (this.bandera)
            {
                lblEditarNuevo.Text = "Nuevo";
                // this.MostrarProducto(this.IdProducto);
                this.IsNuevo = true;
                this.IsEditar = false;
            }
            else
            {
                lblEditarNuevo.Text = "Editar";
                this.IsNuevo = false;
                this.IsEditar = true;
                this.dameCliente(this.IdCliente);
            }
        }

        private void dameCliente(int IdCliente)
        {
            respuesta = objetoCN.MostrarCliente(IdCliente);

            foreach (DataRow row in respuesta.Rows)
            {
                lblApellidosNomb.Text = Convert.ToString(row["Apellidos"]) + " " + Convert.ToString(row["Nombres"]);
            }
        }


        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";

                if (this.IsNuevo)
                {
                    rpta = CN_Clientes.NuevoTrabajo(
                   this.IdCliente, txtAceite.Text.Trim(), txtFiltroAire.Text.Trim(), txtFiltroAceite.Text.Trim(), cbCorreaDist.Text, cbAlternador.Text, cbTensorDist.Text, cbBombaAgua.Text
                   , cbPastillaFreno.Text, cbRefrigerante.Text, txtCambioBujia.Text, txtCableBujia.Text, txtComb.Text, txtAA.Text, txtKm.Text.Trim(), rtbObservaciones.Text.Trim());

                }
                else
                {
                    rpta = CN_Clientes.EditarTrabajo(this.IdTrabajo, txtAceite.Text.Trim(), txtFiltroAire.Text.Trim(), txtFiltroAceite.Text.Trim(), cbCorreaDist.Text, cbAlternador.Text, cbTensorDist.Text, cbBombaAgua.Text
                   , cbPastillaFreno.Text, cbRefrigerante.Text, txtCambioBujia.Text, txtCableBujia.Text, txtComb.Text, txtAA.Text, txtKm.Text.Trim(), rtbObservaciones.Text.Trim());
                }

                if (rpta.Equals("Ok"))
                {
                    if (this.IsNuevo)
                    {
                        this.MensajeOk("Se Insertó de forma correcta el registro");
                    }
                    else
                    {
                        this.MensajeOk("Se Actualizó de forma correcta el registro");
                    }
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
        //Mostrar Mensaje de Error
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Wilkin Lubricentro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "Wilkin Lubricentro", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtApellidos_TextChanged(object sender, EventArgs e)
        {
            if (txtApellidos.Text.Length > 30)
            {
                MensajeError("Maximo numero de caracteres");
            }
        }

        private void txtNombres_TextChanged(object sender, EventArgs e)
        {
            if (txtNombres.Text.Length > 40)
            {
                MensajeError("Maximo numero de caracteres");
            }
        }

        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {
            if (txtTelefono.Text.Length > 15)
            {
                MensajeError("Maximo numero de caracteres");
            }
        }

        private void txtCorreo_TextChanged(object sender, EventArgs e)
        {
            if (txtCorreo.Text.Length > 45)
            {
                MensajeError("Maximo numero de caracteres");
            }
        }

        private void txtMarca_TextChanged(object sender, EventArgs e)
        {
            if (txtMarca.Text.Length > 200)
            {
                MensajeError("Maximo numero de caracteres");
            }
        }

        private void txtPatente_TextChanged(object sender, EventArgs e)
        {
            if (txtPatente.Text.Length > 40)
            {
                MensajeError("Maximo numero de caracteres");
            }
        }

        private void txtDireccion_TextChanged(object sender, EventArgs e)
        {
            if (txtDireccion.Text.Length > 200)
            {
                MensajeError("Maximo numero de caracteres");
            }
        }

        private void txtModelo_TextChanged(object sender, EventArgs e)
        {
            if (txtModelo.Text.Length > 40)
            {
                MensajeError("Maximo numero de caracteres");
            }
        }

        private void rtbObservaciones_TextChanged(object sender, EventArgs e)
        {
            if (rtbObservaciones.Text.Length > 200)
            {
                MensajeError("Maximo numero de caracteres");
            }
        }
    }
}
