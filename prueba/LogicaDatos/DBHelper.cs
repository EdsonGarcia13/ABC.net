using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;



namespace prueba.LogicaDatos
{
    
        public class DBHelper
        {
        private static string ObtenerConexion()
        {
            return ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
        }


        protected static void EjecutarSP(string pNombreSP, SqlParameter[] pParametros)
            {
                
                SqlConnection cnn = null;
                SqlCommand cmd = null;

                try
                {
                    cnn = new SqlConnection(ObtenerConexion());
                    cnn.Open();

                    cmd = cnn.CreateCommand();
                    cmd.CommandText = pNombreSP;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandTimeout = 1000;

                    if (pParametros != null)
                    {
                        cmd.Parameters.AddRange(pParametros);
                    }

                    int resultado = cmd.ExecuteNonQuery();
                }
                catch (Exception ex) { throw ex; }
                finally
                {

                    if (cnn.State == System.Data.ConnectionState.Open) { cnn.Close(); }
                    if (cnn != null) { cnn.Dispose(); cnn = null; }
                    if (cmd != null) { cmd.Dispose(); cmd = null; }
                }
            }
            protected static DataTable EjecutarQuery(string pQuery, SqlParameter[] pParametros)
            {
                DataTable dt = new DataTable();
                SqlConnection cnn = null;
                SqlCommand cmd = null;
                SqlDataAdapter adapter = null;

                try
                {
                    cnn = new SqlConnection(ObtenerConexion());
                    cnn.Open();

                    cmd = cnn.CreateCommand();
                    cmd.CommandText = pQuery;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandTimeout = 1000;

                    if (pParametros != null)
                    {
                        cmd.Parameters.AddRange(pParametros);
                    }

                    adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);

                }
                catch (Exception ex) { throw ex; }
                finally
                {

                    if (cnn.State == System.Data.ConnectionState.Open) { cnn.Close(); }
                    if (cnn != null) { cnn.Dispose(); cnn = null; }
                    if (cmd != null) { cmd.Dispose(); cmd = null; }
                }

                return dt;

            }
            protected static DataTable EjecutarSPConResultados(string pNombreSP, SqlParameter[] pParametros)
            {

                DataTable dt = new DataTable();
                SqlConnection cnn = null;
                SqlCommand cmd = null;
                SqlDataReader reader = null;

                try
                {
                    cnn = new SqlConnection(ObtenerConexion());
                    cnn.Open();

                    cmd = cnn.CreateCommand();

                    cmd.CommandText = pNombreSP;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 1000;

                    if (pParametros != null)
                    {
                        cmd.Parameters.AddRange(pParametros);
                    }


                    reader = cmd.ExecuteReader();

                    dt.Load(reader);


                }
                catch (Exception ex) { throw ex; }
                finally
                {

                    if (cnn.State == System.Data.ConnectionState.Open) { cnn.Close(); }
                    if (cnn != null) { cnn.Dispose(); cnn = null; }
                    if (cmd != null) { cmd.Dispose(); cmd = null; }
                }

                return dt;
            }
            //protected static DataTable EjecutarSPConBMS(string pNombreSP, SqlParameter[] pParametros)
            //{

            //    DataTable dt = new DataTable();
            //    SqlConnection cnn = null;
            //    SqlCommand cmd = null;
            //    SqlDataReader reader = null;

            //    try
            //    {
            //        cnn = new SqlConnection(ObtenerConexionBMS());
            //        cnn.Open();

            //        cmd = cnn.CreateCommand();

            //        cmd.CommandText = pNombreSP;
            //        cmd.CommandType = CommandType.StoredProcedure;
            //        cmd.CommandTimeout = 1000;

            //        if (pParametros != null)
            //        {
            //            cmd.Parameters.AddRange(pParametros);
            //        }


            //        reader = cmd.ExecuteReader();

            //        dt.Load(reader);


            //    }
            //    catch (Exception ex) { throw ex; }
            //    finally
            //    {

            //        if (cnn.State == System.Data.ConnectionState.Open) { cnn.Close(); }
            //        if (cnn != null) { cnn.Dispose(); cnn = null; }
            //        if (cmd != null) { cmd.Dispose(); cmd = null; }
            //    }

            //    return dt;
            //}
            //protected static DataTable EjecutarSPConWinHost(string pNombreSP, SqlParameter[] pParametros)
            //{

            //    DataTable dt = new DataTable();
            //    SqlConnection cnn = null;
            //    SqlCommand cmd = null;
            //    SqlDataReader reader = null;

            //    try
            //    {
            //        cnn = new SqlConnection(ObtenerConexionWinHost());
            //        cnn.Open();

            //        cmd = cnn.CreateCommand();

            //        cmd.CommandText = pNombreSP;
            //        cmd.CommandType = CommandType.StoredProcedure;
            //        cmd.CommandTimeout = 1000;

            //        if (pParametros != null)
            //        {
            //            cmd.Parameters.AddRange(pParametros);
            //        }


            //        reader = cmd.ExecuteReader();

            //        dt.Load(reader);


            //    }
            //    catch (Exception ex) { throw ex; }
            //    finally
            //    {

            //        if (cnn.State == System.Data.ConnectionState.Open) { cnn.Close(); }
            //        if (cnn != null) { cnn.Dispose(); cnn = null; }
            //        if (cmd != null) { cmd.Dispose(); cmd = null; }
            //    }

            //    return dt;
            //}
            protected static SqlParameter CrearSqlParametro(String pName, SqlDbType pDbType, int pTamaño, ParameterDirection pParameterDirection, Object pValor)
            {

                SqlParameter resultado = null;

                resultado = new SqlParameter();

                resultado.ParameterName = pName;
                resultado.DbType = (DbType)pDbType;

                if (pTamaño > 0) { resultado.Size = pTamaño; }

                resultado.Direction = pParameterDirection;

                if (pValor != null) { resultado.Value = pValor; }

                return resultado;
            }

            protected static SqlParameter CrearSqlParametro(String pName, DbType pDbType, Object pValor)
            {

                SqlParameter resultado = null;

                resultado = new SqlParameter();

                resultado.ParameterName = pName;
                resultado.DbType = pDbType;

                if (pValor != null) { resultado.Value = pValor; }

                return resultado;
            }

            protected static SqlParameter CrearSqlParametro(String pName, DbType pDbType, int pTamaño, Object pValor)
            {

                SqlParameter resultado = null;

                resultado = new SqlParameter();

                resultado.ParameterName = pName;
                resultado.DbType = pDbType;

                if (pTamaño > 0) { resultado.Size = pTamaño; }

                if (pValor != null) { resultado.Value = pValor; }

                return resultado;
            }
        }

    }