using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CapaNegocio;

namespace CapaPresentacion
{
    public partial class formNuevoEditarClientes : Form
    {
        CN_Clientes objetoCN = new CN_Clientes();
        DataTable respuesta;
        // int parametroActual;
        bool bandera;
        bool IsNuevo = false;
        bool IsEditar = false;

        private int IdCliente;
        private string Transporte;
        private string Titular;
        private string Telefono;

        public formNuevoEditarClientes(int parametro, bool IsNuevoEditar)
        {
            InitializeComponent();
            this.IdCliente = parametro;
            this.bandera = IsNuevoEditar;
        }

        private void formNuevoEditarClientes_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txtApellidos;
            if (this.bandera)
            {
                lblEditarNuevo.Text = "Nuevo";
                // this.MostrarProducto(this.IdProducto);
                this.IsNuevo = true;
                this.IsEditar = false;
            }
            else
            {
                lblEditarNuevo.Text = "Ficha";
                this.IsNuevo = false;
                this.IsEditar = true;
                this.MostrarCliente(this.IdCliente);
            }
        }

        // Carga los valores en los campos de texto del formulario para que se modifiquen los que se desean
        private void MostrarCliente(int IdCliente)
        {
            respuesta = objetoCN.MostrarCliente(IdCliente);

            foreach (DataRow row in respuesta.Rows)
            {
                IdCliente = Convert.ToInt32(row["IdCliente"]);
                txtApellidos.Text = Convert.ToString(row["Apellidos"]);
                txtNombres.Text = Convert.ToString(row["Nombres"]);
                txtTelefono.Text = Convert.ToString(row["Telefono"]);

                txtMarca.Text = Convert.ToString(row["Marca"]);
                txtPatente.Text = Convert.ToString(row["Patente"]);
                txtCorreo.Text = Convert.ToString(row["Correo"]);

                txtDireccion.Text = Convert.ToString(row["Direccion"]);
                txtModelo.Text = Convert.ToString(row["Modelo"]);
                rtbObservaciones.Text = Convert.ToString(row["Observaciones"]);

            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                
                    if (this.IsNuevo)
                    {
                        rpta = CN_Clientes.AltaCliente(this.txtApellidos.Text.Trim(), this.txtNombres.Text.Trim(), this.txtTelefono.Text.Trim()
                            , this.txtMarca.Text.Trim(),  this.txtPatente.Text.Trim(), this.txtCorreo.Text.Trim()
                            , this.txtDireccion.Text.Trim(), this.txtModelo.Text.Trim(), this.rtbObservaciones.Text.Trim());
                    }
                    else
                    {
                        rpta = CN_Clientes.EditarCliente(this.IdCliente, this.txtApellidos.Text.Trim(), this.txtNombres.Text.Trim(), 
                            this.txtTelefono.Text.Trim(), this.txtMarca.Text.Trim(), this.txtPatente.Text.Trim(), this.txtCorreo.Text.Trim()
                            , this.txtDireccion.Text.Trim(), this.txtModelo.Text.Trim(), this.rtbObservaciones.Text.Trim());
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
    }
}
