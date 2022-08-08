
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using MySql.Data.MySqlClient;
        /// <summary>
namespace DAL
{
    public class Configuracion
    {
        /// Cadena de conexión
        /// </summary>
        public static string cadenaconexion = "SERVER=localhost;DATABASE=Northwind;uid=sistema; user=root; password=";
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public static DataTable GetDataTable(string strSql)
        {
            try
            {

                using (MySqlConnection cn = new MySqlConnection(cadenaconexion))
                {
                    cn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(strSql, cn))
                    {
                        using (MySqlDataReader dr = cmd.ExecuteReader())
                        {
                            DataTable dt = new DataTable();
                            dt.Load(dr);
                            return dt;
                        }

                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        //insert, update, delete
        public static bool ExecTransactionParameters(MySqlCommand comando)
        {
            bool resultado = false;
            try
            {
                using (MySqlConnection cn = new MySqlConnection(cadenaconexion))
                {
                    cn.Open();
                    using (MySqlTransaction trx = cn.BeginTransaction())
                    {
                        try
                        {
                            using (comando)
                            {
                                comando.Connection = cn;
                                comando.Transaction = trx;
                                comando.ExecuteNonQuery();
                            }
                            trx.Commit();
                            resultado = true;
                        }
                        catch (Exception)
                        {
                            trx.Rollback();
                            resultado = false;
                            throw;
                        }
                    }
                }

            }
            catch (Exception)
            {
               
            }
            return resultado;
        }
    }

}
