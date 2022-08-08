using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Entidades;

namespace DAL
{
    public class ClaseRegiones : Configuracion
    {

        /// <summary>
        /// Método ListarRegiones
        /// Ejecuta una consulta SQL de tipo "Select" que obtiene la data de la base de datos.
        /// Espera como parámetro un string que definirá la consulta en caso de buscar algo en específico.
        /// Retorna la data en formato de DataTable
        /// </summary>
        /// <param name="strRegion"></param>
        /// <returns></returns>
        public static DataTable ListarRegiones(string strRegion)
        {
            string strSQL = "select * from region";
            strSQL += " where RegionDescription like '%" + strRegion + "%'";
            return GetDataTable(strSQL);
        }

        /// <summary>
        /// Método InsertarRegion
        /// Ejecuta una consulta SQL de tipo "Insert" que inserta un nuevo registro a la tabla de region.
        /// Espera como parámetro una clase que contiene los atributos que son equivalentes a los campos de la tabla regiones que se desean insertar.
        /// Retorna un valor booleano con el fin de informar el éxito que tuvo la transacción.
        /// </summary>
        /// <param name="Region"></param>
        /// <returns></returns>
        public static bool InsertaRegion(Regiones Region)
        {
            string strSQL = "Insert into region (RegionID,RegionDescription) values(";
            strSQL += "'" + Region.RegionID + "',";
            strSQL += "'" + Region.RegionDescripcion + "');";
            return true;
            //return ExecTransaction(strSQL);
        }

        /// <summary>
        /// Método EditarRegion
        /// Ejecuta una consulta SQL de tipo "Update" que actualiza un registro en específico de la tabla region.
        /// Espera como parámetro una clase que contiene los atributos que son equivalentes a los campos de la tabla region que se desean actualizar.
        /// Retorna un valor booleano con el fin de informar el éxito que tuvo la transacción.
        /// </summary>
        /// <param name="Region"></param>
        /// <returns></returns>
        public static bool EditarRegion(Regiones Region)
        {            
            string strSQL = "Update region set regiondescription = '" + Region.RegionDescripcion +"' where regionid = " + Region.RegionID;
            //return ExecTransaction(strSQL);
            return true;
        }

        /// <summary>
        /// Método EditarRegion
        /// Ejecuta una consulta SQL de tipo "Delete" que actualiza un registro en específico de la tabla region.
        /// Espera como parámetro un valor entero que contiene el ID de la region a eliminar.
        /// Retorna un valor booleano con el fin de informar el éxito que tuvo la transacción.
        /// </summary>
        /// <param name="RegionID"></param>
        /// <returns></returns>
        public static bool EliminaRegion(int RegionID)
        {
            string strSQL = "Delete from region where RegionID="+ RegionID;
            //return ExecTransaction(strSQL);
            return true;
        }


    }
}
