using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class CN_Clientes
    {
        private CD_Clientes objetoCD = new CD_Clientes();

        //Método Insertar que llama al método Insertar de la clase DArticulo
        //de la CapaDatos
        public static string AltaCliente(string Apellidos, string Nombres, string Telefono, string Marca, string Patente, string Correo,
            string Direccion, string Modelo, string Observaciones)
        {
            CD_Clientes Obj = new CD_Clientes();

            return Obj.Insertar(Apellidos, Nombres, Telefono, Marca, Patente, Correo,
            Direccion, Modelo, Observaciones);
        }

        public DataSet ListarClientesPaginado(int desde)
        {

            DataSet tabla = new DataSet();
            tabla = objetoCD.ListarClientesPaginado(desde);
            return tabla;
        }
        public static string EliminarCliente(int IdCliente)
        {
            CD_Clientes Obj = new CD_Clientes();

            return Obj.EliminarCliente(IdCliente);
        }

        // Devuelve solo un Cliente
        public DataTable MostrarCliente(int IdCliente)
        {

            DataTable tabla = new DataTable();
            tabla = objetoCD.MostrarCliente(IdCliente);
            return tabla;
        }
        public DataSet dameHistoricoClientePaginado(int IdCliente,int desde)
        {
            DataSet tabla = new DataSet();
            tabla = objetoCD.dameHistoricoClientePaginado(IdCliente,desde);
            return tabla;
        }
        

        public static string EditarCliente(int IdCliente, string Apellidos, string Nombres, string Telefono, string Marca, string Patente, string Correo,
            string Direccion, string Modelo, string Observaciones)
        {
            
            CD_Clientes Obj = new CD_Clientes();

            return Obj.Editar(IdCliente,Apellidos, Nombres, Telefono, Marca, Patente, Correo,
            Direccion, Modelo, Observaciones);
        }

        public DataTable BuscarCliente(string apellidos,string nombres)
        {
            CD_Clientes Obj = new CD_Clientes();

            return Obj.BuscarCliente(apellidos,nombres);
        }

        public DataTable BuscarPatente(string pPatente)
        {
            CD_Clientes Obj = new CD_Clientes();

            return Obj.BuscarPatente(pPatente);
        }

        public static string NuevoTrabajo(int IdCliente,string Aceite, string Filtro, string CorreaDist, string Alternador, string TensorDist, 
            string BombaAgua,
            string PastillaFreno, string CambioRef, string CambioBujia, string CambioAceite, string CambioFiltroAceite, string CambioComb,
            string CambioAA, string Kilometros,string Observaciones)
        {

            CorreaDist = CorreaDist != "Si" ? "N" : "S";
            Alternador = Alternador != "Si" ? "N" : "S";
            TensorDist = TensorDist != "Si" ? "N" : "S";
            BombaAgua = BombaAgua != "Si" ? "N" : "S";
            PastillaFreno = PastillaFreno != "Si" ? "N" : "S";
            CambioRef = CambioRef != "Si" ? "N" : "S";
            CambioBujia = CambioBujia != "Si" ? "N" : "S";
            CambioFiltroAceite = CambioFiltroAceite != "Si" ? "N" : "S";


            if (Kilometros == "" || string.IsNullOrEmpty(Kilometros))
            {
                Kilometros = "0";
            }

            CD_Clientes Obj = new CD_Clientes();


            return Obj.NuevoTrabajo(IdCliente,Aceite, Filtro, CorreaDist, Alternador, TensorDist, BombaAgua,
            PastillaFreno, CambioRef, CambioBujia, CambioAceite, CambioFiltroAceite, CambioComb,
            CambioAA, Kilometros, Observaciones);
        }
    }
}
