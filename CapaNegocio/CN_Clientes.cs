using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class CN_Clientes
    {
        private CD_Clientes objetoCD = new CD_Clientes();

        //Método Insertar que llama al método Insertar de la clase DArticulo
        //de la CapaDatos
        public static string Insertar(string Apellidos, string Nombres, string Telefono, string Marca, string Patente, string Correo,
            string Direccion, string Modelo, string Observaciones)
        {
            CD_Clientes Obj = new CD_Clientes();

            return Obj.Insertar(Apellidos, Nombres, Telefono, Marca, Patente, Correo,
            Direccion, Modelo, Observaciones);
        }

        public DataTable ListarClientesPaginado(int desde)
        {

            DataTable tabla = new DataTable();
            tabla = objetoCD.ListarClientesPaginado(desde);
            return tabla;
        }
        public static string Eliminar(int IdCliente)
        {
            CD_Clientes Obj = new CD_Clientes();
            //Obj.IdCliente = IdCliente;
            return Obj.Eliminar(Obj);
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
        

        public static string Editar(int IdCliente, string Apellidos, string Nombres, string Telefono, string Marca, string Patente, string Correo,
            string Direccion, string Modelo, string Observaciones)
        {
            
            CD_Clientes Obj = new CD_Clientes();

            return Obj.Editar(IdCliente,Apellidos, Nombres, Telefono, Marca, Patente, Correo,
            Direccion, Modelo, Observaciones);
        }

        public DataTable BuscarCliente(string textobuscar)
        {
            CD_Clientes Obj = new CD_Clientes();
            //Obj.TextoBuscar = textobuscar;
            return Obj.BuscarCliente(Obj);
        }

        public static string NuevoTrabajo(int IdCliente,string Aceite, string Filtro, string CorreaDist, string Alternador, string TensorDist, 
            string BombaAgua,
            string PastillaFreno, string CambioRef, string CambioBujia, string CambioAceite, string CambioFiltroAceite, string CambioComb,
            string CambioAA, string Kilometros,string Observaciones)
        {

            CorreaDist = CorreaDist != "No" ? "S" : "N";
            Alternador = Alternador != "No" ? "S" : "N";
            TensorDist = TensorDist != "No" ? "S" : "N";
            BombaAgua = BombaAgua != "No" ? "S" : "N";
            PastillaFreno = PastillaFreno != "No" ? "S" : "N";
            CambioRef = CambioRef != "No" ? "S" : "N";
            CambioBujia = CambioBujia != "No" ? "S" : "N";
            CambioAceite = CambioAceite != "No" ? "S" : "N";
            CambioFiltroAceite = CambioFiltroAceite != "No" ? "S" : "N";
            CambioComb = CambioComb != "No" ? "S" : "N";
            CambioAA = CambioAA != "No" ? "S" : "N";

            CD_Clientes Obj = new CD_Clientes();


            return Obj.NuevoTrabajo(IdCliente,Aceite, Filtro, CorreaDist, Alternador, TensorDist, BombaAgua,
            PastillaFreno, CambioRef, CambioBujia, CambioAceite, CambioFiltroAceite, CambioComb,
            CambioAA, Kilometros, Observaciones);
        }
    }
}
