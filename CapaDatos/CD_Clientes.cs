﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Clientes
    {
        private int _IdCliente;
        private string _Transporte;
        private string _Titular;
        private string _Telefono;

        private string _TextoBuscar;


        public int IdCliente { get => _IdCliente; set => _IdCliente = value; }
        public string Transporte { get => _Transporte; set => _Transporte = value; }
        public string Titular { get => _Titular; set => _Titular = value; }
        public string Telefono { get => _Telefono; set => _Telefono = value; }
        public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }

        //Constructores
        public CD_Clientes()
        {

        }

        public CD_Clientes(int IdCliente, string Transporte, string Titular, string Telefono)
        {
            this.IdCliente = IdCliente;
            this.Transporte = Transporte;
            this.Titular = Titular;
            this.Telefono = Telefono;
        }

        // ==================================================
        //  Permite devolver todos los clientes activos de la BD
        // ==================================================
        private CD_Conexion conexion = new CD_Conexion();

        MySqlDataReader leer;
        DataTable tabla = new DataTable();
        MySqlCommand comando = new MySqlCommand();


        public DataTable ListarClientesPaginado(int desde)
        {

            comando.Connection = conexion.AbrirConexion();
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "bsp_listar_clientes";

            MySqlParameter pDesde = new MySqlParameter();
            pDesde.ParameterName = "@pDesde";
            pDesde.MySqlDbType = MySqlDbType.Int32;
            // pIdProducto.Size = 60;
            pDesde.Value = desde;
            comando.Parameters.Add(pDesde);

            tabla.Clear();
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;

        }

        // devuelve solo 1 cliente de la BD
        public DataTable MostrarCliente(int IdCliente)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "bsp_dame_cliente";

            MySqlParameter pIdCliente = new MySqlParameter();
            pIdCliente.ParameterName = "@pIdCliente";
            pIdCliente.MySqlDbType = MySqlDbType.Int32;
            // pIdProducto.Size = 60;
            pIdCliente.Value = IdCliente;
            comando.Parameters.Add(pIdCliente);

            leer = comando.ExecuteReader();
            tabla.Load(leer);
            
            comando.Parameters.Clear();
            conexion.CerrarConexion();

            return tabla;

        }

        public string Editar(int IdCliente,string Apellidos, string Nombres, string Telefono, string Marca, string Patente, string Correo,
            string Direccion, string Modelo, string Observaciones)
        {
            string rpta = "";
            comando.Parameters.Clear();
            try
            {
                MySqlParameter pIdCliente = new MySqlParameter();
                pIdCliente.ParameterName = "@pIdCliente";
                pIdCliente.MySqlDbType = MySqlDbType.Int32;
                pIdCliente.Value = IdCliente;
                comando.Parameters.Add(pIdCliente);

                MySqlParameter pApellidos = new MySqlParameter();
                pApellidos.ParameterName = "@pApellidos";
                pApellidos.MySqlDbType = MySqlDbType.VarChar;
                pApellidos.Size = 60;
                pApellidos.Value = Apellidos;
                comando.Parameters.Add(pApellidos);

                MySqlParameter pNombres = new MySqlParameter();
                pNombres.ParameterName = "@pNombres";
                pNombres.MySqlDbType = MySqlDbType.VarChar;
                pNombres.Size = 60;
                pNombres.Value = Nombres;
                comando.Parameters.Add(pNombres);

                MySqlParameter pMarca = new MySqlParameter();
                pMarca.ParameterName = "@pMarca";
                pMarca.MySqlDbType = MySqlDbType.VarChar;
                pMarca.Size = 45;
                pMarca.Value = Marca;
                comando.Parameters.Add(pMarca);

                MySqlParameter pPatente = new MySqlParameter();
                pPatente.ParameterName = "@pPatente";
                pPatente.MySqlDbType = MySqlDbType.VarChar;
                pPatente.Size = 60;
                pPatente.Value = Patente;
                comando.Parameters.Add(pPatente);

                MySqlParameter pDireccion = new MySqlParameter();
                pDireccion.ParameterName = "@pDireccion";
                pDireccion.MySqlDbType = MySqlDbType.VarChar;
                pDireccion.Size = 250;
                pDireccion.Value = Direccion;
                comando.Parameters.Add(pDireccion);

                MySqlParameter pCorreo = new MySqlParameter();
                pCorreo.ParameterName = "@pCorreo";
                pCorreo.MySqlDbType = MySqlDbType.VarChar;
                pCorreo.Size = 60;
                pCorreo.Value = Correo;
                comando.Parameters.Add(pCorreo);

                MySqlParameter pTelefono = new MySqlParameter();
                pTelefono.ParameterName = "@pTelefono";
                pTelefono.MySqlDbType = MySqlDbType.VarChar;
                pTelefono.Size = 15;
                pTelefono.Value = Telefono;
                comando.Parameters.Add(pTelefono);

                MySqlParameter pModelo = new MySqlParameter();
                pModelo.ParameterName = "@pModelo";
                pModelo.MySqlDbType = MySqlDbType.VarChar;
                pModelo.Size = 60;
                pModelo.Value = Modelo;
                comando.Parameters.Add(pModelo);

                MySqlParameter pObservaciones = new MySqlParameter();
                pObservaciones.ParameterName = "@pObservaciones";
                pObservaciones.MySqlDbType = MySqlDbType.VarChar;
                pObservaciones.Size = 250;
                pObservaciones.Value = Observaciones;
                comando.Parameters.Add(pObservaciones);

                rpta = comando.ExecuteScalar().ToString() == "Ok" ? "Ok" : "No se edito el Registro";

            }
            catch (Exception ex)
            {

                rpta = ex.Message;
            }
            finally
            {
                conexion.CerrarConexion();
            }
            comando.Parameters.Clear();
            return rpta;
        }

        //Métodos
        //Insertar
        public string Insertar(string Apellidos,string Nombres,string Telefono,string Marca,string Patente,string Correo,
            string Direccion,string Modelo,string Observaciones)
        {
            string rpta = "";
            try
            {
                comando.Connection = conexion.AbrirConexion();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "bsp_alta_cliente";

                MySqlParameter pApellidos = new MySqlParameter();
                pApellidos.ParameterName = "@pApellidos";
                pApellidos.MySqlDbType = MySqlDbType.VarChar;
                pApellidos.Size = 60;
                pApellidos.Value = Apellidos;
                comando.Parameters.Add(pApellidos);

                MySqlParameter pNombres = new MySqlParameter();
                pNombres.ParameterName = "@pNombres";
                pNombres.MySqlDbType = MySqlDbType.VarChar;
                pNombres.Size = 60;
                pNombres.Value = Nombres;
                comando.Parameters.Add(pNombres);                                

                MySqlParameter pMarca = new MySqlParameter();
                pMarca.ParameterName = "@pMarca";
                pMarca.MySqlDbType = MySqlDbType.VarChar;
                pMarca.Size = 45;
                pMarca.Value = Marca;
                comando.Parameters.Add(pMarca);

                MySqlParameter pPatente = new MySqlParameter();
                pPatente.ParameterName = "@pPatente";
                pPatente.MySqlDbType = MySqlDbType.VarChar;
                pPatente.Size = 60;
                pPatente.Value = Patente;
                comando.Parameters.Add(pPatente);

                MySqlParameter pDireccion = new MySqlParameter();
                pDireccion.ParameterName = "@pDireccion";
                pDireccion.MySqlDbType = MySqlDbType.VarChar;
                pDireccion.Size = 250;
                pDireccion.Value = Direccion;
                comando.Parameters.Add(pDireccion);

                MySqlParameter pCorreo = new MySqlParameter();
                pCorreo.ParameterName = "@pCorreo";
                pCorreo.MySqlDbType = MySqlDbType.VarChar;
                pCorreo.Size = 60;
                pCorreo.Value = Correo;
                comando.Parameters.Add(pCorreo);

                MySqlParameter pTelefono = new MySqlParameter();
                pTelefono.ParameterName = "@pTelefono";
                pTelefono.MySqlDbType = MySqlDbType.VarChar;
                pTelefono.Size = 15;
                pTelefono.Value = Telefono;
                comando.Parameters.Add(pTelefono);

                MySqlParameter pModelo = new MySqlParameter();
                pModelo.ParameterName = "@pModelo";
                pModelo.MySqlDbType = MySqlDbType.VarChar;
                pModelo.Size = 60;
                pModelo.Value = Modelo;
                comando.Parameters.Add(pModelo);

                MySqlParameter pObservaciones = new MySqlParameter();
                pObservaciones.ParameterName = "@pObservaciones";
                pObservaciones.MySqlDbType = MySqlDbType.VarChar;
                pObservaciones.Size = 250;
                pObservaciones.Value = Observaciones;
                comando.Parameters.Add(pObservaciones);

                rpta = comando.ExecuteScalar().ToString();


            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                conexion.CerrarConexion();
            }
            return rpta;

        }

        // Metodo ELIMINAR Empleado (da de baja)
        public string Eliminar(CD_Clientes Cliente)
        {
            string rpta = "";
            try
            {

                comando.Connection = conexion.AbrirConexion();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "bsp_eliminar_cliente";

                MySqlParameter pIdCliente = new MySqlParameter();
                pIdCliente.ParameterName = "@pIdCliente";
                pIdCliente.MySqlDbType = MySqlDbType.Int32;
                pIdCliente.Value = Cliente.IdCliente;
                comando.Parameters.Add(pIdCliente);

                //Ejecutamos nuestro comando

                rpta = comando.ExecuteNonQuery() == 1 ? "OK" : "NO se Elimino el Registro";


            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                //if (conexion. == ConnectionState.Open) 
                conexion.CerrarConexion();
            }
            return rpta;
        }

        public DataTable BuscarCliente(CD_Clientes Cliente)
        {
            try
            {
                comando.Connection = conexion.AbrirConexion();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "bsp_buscar_cliente";

                MySqlParameter pTextoBuscar = new MySqlParameter();
                pTextoBuscar.ParameterName = "@pTextoBuscar";
                pTextoBuscar.MySqlDbType = MySqlDbType.VarChar;
                pTextoBuscar.Size = 30;
                pTextoBuscar.Value = Cliente.TextoBuscar;
                comando.Parameters.Add(pTextoBuscar);

                leer = comando.ExecuteReader();
                tabla.Load(leer);
                comando.Parameters.Clear();
                conexion.CerrarConexion();

                // return tabla;
            }
            catch (Exception ex)
            {
                tabla = null;
            }
            return tabla;

        }

        public string NuevoTrabajo(int IdCliente,string Aceite, string Filtro, string CorreaDist, string Alternador, string TensorDist, string BombaAgua,
            string PastillaFreno, string CambioRef, string CambioBujia, string CambioAceite, string CambioFiltroAceite, string CambioComb,
            string CambioAA, string Kilometros, string Observaciones)
        {
            string rpta = "";
            try
            {
                comando.Connection = conexion.AbrirConexion();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "bsp_alta_trabajo";

                MySqlParameter pIdCliente = new MySqlParameter();
                pIdCliente.ParameterName = "@pIdCliente";
                pIdCliente .MySqlDbType = MySqlDbType.Int32;
                pIdCliente .Size = 60;
                pIdCliente.Value = IdCliente;
                comando.Parameters.Add(pIdCliente);

                MySqlParameter pAceite = new MySqlParameter();
                pAceite.ParameterName = "@pAceite";
                pAceite.MySqlDbType = MySqlDbType.VarChar;
                pAceite.Size = 60;
                pAceite.Value = Aceite;
                comando.Parameters.Add(pAceite);

                MySqlParameter pFiltro = new MySqlParameter();
                pFiltro.ParameterName = "@pFiltro";
                pFiltro.MySqlDbType = MySqlDbType.VarChar;
                pFiltro.Size = 60;
                pFiltro.Value = Filtro;
                comando.Parameters.Add(pFiltro);

                MySqlParameter pCorreaDist = new MySqlParameter();
                pCorreaDist.ParameterName = "@pCorreaDist";
                pCorreaDist.MySqlDbType = MySqlDbType.VarChar;
                pCorreaDist.Size = 1;
                pCorreaDist.Value = CorreaDist;
                comando.Parameters.Add(pCorreaDist);

                MySqlParameter pAlternador = new MySqlParameter();
                pAlternador.ParameterName = "@pAlternador";
                pAlternador.MySqlDbType = MySqlDbType.VarChar;
                pAlternador.Size = 1;
                pAlternador.Value = Alternador;
                comando.Parameters.Add(pAlternador);

                MySqlParameter pTensorDist = new MySqlParameter();
                pTensorDist.ParameterName = "@pTensorDist";
                pTensorDist.MySqlDbType = MySqlDbType.VarChar;
                pTensorDist.Size = 1;
                pTensorDist.Value = TensorDist;
                comando.Parameters.Add(pTensorDist);

                MySqlParameter pBombaAgua = new MySqlParameter();
                pBombaAgua.ParameterName = "@pBombaAgua";
                pBombaAgua.MySqlDbType = MySqlDbType.VarChar;
                pBombaAgua.Size = 1;
                pBombaAgua.Value = BombaAgua;
                comando.Parameters.Add(pBombaAgua);

                MySqlParameter pPastillaFreno = new MySqlParameter();
                pPastillaFreno.ParameterName = "@pPastillaFreno";
                pPastillaFreno.MySqlDbType = MySqlDbType.VarChar;
                pPastillaFreno.Size = 1;
                pPastillaFreno.Value = PastillaFreno;
                comando.Parameters.Add(pPastillaFreno);

                MySqlParameter pCambioRef = new MySqlParameter();
                pCambioRef.ParameterName = "@pCambioRef";
                pCambioRef.MySqlDbType = MySqlDbType.VarChar;
                pCambioRef.Size = 1;
                pCambioRef.Value = CambioRef;
                comando.Parameters.Add(pCambioRef);

                MySqlParameter pCambioBujia = new MySqlParameter();
                pCambioBujia.ParameterName = "@pCambioBujia";
                pCambioBujia.MySqlDbType = MySqlDbType.VarChar;
                pCambioBujia.Size = 1;
                pCambioBujia.Value = CambioBujia;
                comando.Parameters.Add(pCambioBujia);

                MySqlParameter pCambioAceite = new MySqlParameter();
                pCambioAceite.ParameterName = "@pCambioAceite";
                pCambioAceite.MySqlDbType = MySqlDbType.VarChar;
                pCambioAceite.Size = 1;
                pCambioAceite.Value = CambioAceite;
                comando.Parameters.Add(pCambioAceite);

                MySqlParameter pCambioFiltroAceite = new MySqlParameter();
                pCambioFiltroAceite.ParameterName = "@pCambioFiltroAceite";
                pCambioFiltroAceite.MySqlDbType = MySqlDbType.VarChar;
                pCambioFiltroAceite.Size = 1;
                pCambioFiltroAceite.Value = CambioFiltroAceite;
                comando.Parameters.Add(pCambioFiltroAceite);

                MySqlParameter pCambioComb = new MySqlParameter();
                pCambioComb.ParameterName = "@pCambioComb";
                pCambioComb.MySqlDbType = MySqlDbType.VarChar;
                pCambioComb.Size = 1;
                pCambioComb.Value = CambioComb;
                comando.Parameters.Add(pCambioComb);

                MySqlParameter pCambioAA = new MySqlParameter();
                pCambioAA.ParameterName = "@pCambioAA";
                pCambioAA.MySqlDbType = MySqlDbType.VarChar;
                pCambioAA.Size = 1;
                pCambioAA.Value = CambioAA;
                comando.Parameters.Add(pCambioAA);

                MySqlParameter pKilometros = new MySqlParameter();
                pKilometros.ParameterName = "@pKilometros";
                pKilometros.MySqlDbType = MySqlDbType.VarChar;
                pKilometros.Size = 45;
                pKilometros.Value = Kilometros;
                comando.Parameters.Add(pKilometros);

                MySqlParameter pObservaciones = new MySqlParameter();
                pObservaciones.ParameterName = "@pObservaciones";
                pObservaciones.MySqlDbType = MySqlDbType.VarChar;
                pObservaciones.Size = 250;
                pObservaciones.Value = Observaciones;
                comando.Parameters.Add(pObservaciones);

                rpta = comando.ExecuteScalar().ToString();


            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                conexion.CerrarConexion();
            }
            return rpta;

        }
    }
}
