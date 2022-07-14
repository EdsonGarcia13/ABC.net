using prueba.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace prueba.LogicaDatos
{
    public class Catalogos : DBHelper
    {

        private static string SP_CapturarUsuarios = "dbo.CapturarUsuarios";
        private static string SP_MostrarUsuarios = "dbo.MostrarUsuarios";
        private static string SP_editarUsuarios = "dbo.editarUsuarios";
        private static string SP_eliminarUsuarios = "dbo.eliminarUsuarios";
        public static DataTable GuardarUsuarios(UsuarioModel model)
        {
            DataTable dt = null;
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>();
                parametros.Add(new SqlParameter("@Nombre", model.Nombre != null ? model.Nombre : ""));
                parametros.Add(new SqlParameter("@FirstName", model.FirstName != null ? model.FirstName : ""));
                parametros.Add(new SqlParameter("@LastName", model.LastName != null ? model.LastName : ""));
                parametros.Add(new SqlParameter("@Fecha_de_Nacimiento", model.Fecha_de_Nacimiento != null ? model.Fecha_de_Nacimiento : ""));
                parametros.Add(new SqlParameter("@Estado", model.Estado != null ? model.Estado : ""));
                parametros.Add(new SqlParameter("@Municipio", model.Municipio != null ? model.Municipio : ""));
                parametros.Add(new SqlParameter("@CodigoPostal", model.CodigoPostal != null ? model.CodigoPostal : ""));
                parametros.Add(new SqlParameter("@Correo", model.Correo != null ? model.Correo : ""));
                parametros.Add(new SqlParameter("@Domicilio", model.Domicilio != null ? model.Domicilio : ""));
                parametros.Add(new SqlParameter("@Colonia", model.Colonia != null ? model.Colonia : ""));
                parametros.Add(new SqlParameter("@Telefono", model.Telefono != null ? model.Telefono : ""));
                dt = EjecutarSPConResultados(SP_CapturarUsuarios, parametros.ToArray());
            }
            catch (Exception error)
            {

            }
            return dt;
        }


        public static DataTable ObtenerUsuarios(UsuarioModel model)
        {
            DataTable dt = null;
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>();
                parametros.Add(new SqlParameter("@Nombre", model.Nombre != null ? model.Nombre : ""));
            
                dt = EjecutarSPConResultados(SP_MostrarUsuarios, parametros.ToArray());
            }
            catch (Exception error)
            {

            }
            return dt;
        }
        public static DataTable editarUsuarios(UsuarioModel model)
        {
            DataTable dt = null;
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>();
                parametros.Add(new SqlParameter("@PersonId", model.PersonId));
                parametros.Add(new SqlParameter("@Nombre", model.Nombre != null ? model.Nombre : ""));
                parametros.Add(new SqlParameter("@FirstName", model.FirstName != null ? model.FirstName : ""));
                parametros.Add(new SqlParameter("@LastName", model.LastName != null ? model.LastName : ""));
                parametros.Add(new SqlParameter("@Fecha_de_Nacimiento", model.Fecha_de_Nacimiento != null ? model.Fecha_de_Nacimiento : ""));
                parametros.Add(new SqlParameter("@Estado", model.Estado != null ? model.Estado : ""));
                parametros.Add(new SqlParameter("@Municipio", model.Municipio != null ? model.Municipio : ""));
                parametros.Add(new SqlParameter("@CodigoPostal", model.CodigoPostal != null ? model.CodigoPostal : ""));
                parametros.Add(new SqlParameter("@Correo", model.Correo != null ? model.Correo : ""));
                parametros.Add(new SqlParameter("@Domicilio", model.Domicilio != null ? model.Domicilio : ""));
                parametros.Add(new SqlParameter("@Colonia", model.Colonia != null ? model.Colonia : ""));
                parametros.Add(new SqlParameter("@Telefono", model.Telefono != null ? model.Telefono : ""));
                dt = EjecutarSPConResultados(SP_editarUsuarios, parametros.ToArray());
            }
            catch (Exception error)
            {

            }
            return dt;
        }

        public static DataTable eliminarUsuarios(UsuarioModel model)
        {
            DataTable dt = null;
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>();
                parametros.Add(new SqlParameter("@PersonId", model.PersonId));

                dt = EjecutarSPConResultados(SP_eliminarUsuarios, parametros.ToArray());
            }
            catch (Exception error)
            {

            }
            return dt;
        }



    }
}
