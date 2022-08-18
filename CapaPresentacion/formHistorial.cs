using CapaNegocio;
using System;
using System.Data;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class formHistorial : Form
    {
        CN_Clientes objetoCN = new CN_Clientes();
        DataTable respuesta;
        int desde = 0;
        int IdCliente;
        DataSet ds = new DataSet();
        string totalHistorico;

        public formHistorial(int IdCliente)
        {
            InitializeComponent();
            dameCliente(IdCliente);
            dameHistoricoClientePaginado(IdCliente,desde);
            this.IdCliente = IdCliente;
        }
        private void dameCliente(int IdCliente)
        {
            respuesta = objetoCN.MostrarCliente(IdCliente);

            foreach (DataRow row in respuesta.Rows)
            {
                lblHistorico.Text = "Historico de : " + Convert.ToString(row["Apellidos"]) + " " + Convert.ToString(row["Nombres"]);
            }
        }

        public void dameHistoricoClientePaginado(int IdCliente,int desde)
        {
            ds = objetoCN.dameHistoricoClientePaginado(IdCliente, desde);
            dataListadoHistorico.DataSource = ds.Tables[0];
            totalHistorico = ds.Tables[1].Rows[0][0].ToString();
            lblTotalHistorico.Text = "Total de Registros: " + totalHistorico;
            dataListadoHistorico.Columns[0].Visible = false;

        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            this.desde += 15;

            if(this.desde >= Convert.ToInt32(lblTotalHistorico.Text))
            {
                this.desde -= 15;
                return;
            }

            dameHistoricoClientePaginado(IdCliente, desde);
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            this.desde -= 15;

            if (this.desde < 0)
            {
                this.desde += 15;
                return;
            }

            dameHistoricoClientePaginado(IdCliente, desde);
        }
    }
}
