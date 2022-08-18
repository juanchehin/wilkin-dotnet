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
            Obj.IdCliente = IdCliente;
            return Obj.Eliminar(Obj);
        }

        // Devuelve solo un Cliente
        public DataTable MostrarCliente(int IdCliente)
        {

            DataTable tabla = new DataTable();
            tabla = objetoCD.MostrarCliente(IdCliente);
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
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarCliente(Obj);
        }
    }
}
