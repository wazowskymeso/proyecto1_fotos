using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;
using Entidades;


namespace BLL
{
    public class BLLRegiones
    {
        /// <summary>
        /// Método ListarRegiones.
        /// Ejecuta el método ListarRegiones de la clase "ClaseRegiones" en la capa DAL
        /// Espera como parámetro un string que contendrá el valor de la consulta a buscar.
        /// La data que devolverá será en formato DataTable
        /// </summary>
        /// <param name="strRegiones"></param>
        /// <returns></returns>
        public static DataTable ListarRegiones(string strRegiones)
        {
            return ClaseRegiones.ListarRegiones(strRegiones);
        }

        /// <summary>
        /// Método InsertarRegiones.
        /// Ejecuta el método InsertarRegion de la clase "ClaseRegiones" en la capa DAL
        /// Espera como parámetro una clase que contendrá como atributos los valores de los campos a insertar.
        /// Retorna un valor booleano con el fin de informar el éxito que tuvo la transacción.
        /// </summary>
        /// <param name="Region"></param>
        /// <returns></returns>
        public static bool InsertarRegiones(Regiones Region)
        {
            return ClaseRegiones.InsertaRegion(Region);
        }

        /// <summary>
        /// Método EliminaRegiones.
        /// Ejecuta el método EliminaRegion de la clase "ClaseRegiones" en la capa DAL
        /// Espera como parámetro un valor entero que tendrá el Id de la región a eliminar.
        /// Retorna un valor booleano con el fin de informar el éxito que tuvo la transacción.
        /// </summary>
        /// <param name="RegionID"></param>
        /// <returns></returns>
        public static bool EliminaRegiones(int RegionID)
        {
            return ClaseRegiones.EliminaRegion(RegionID);
        }

        /// <summary>
        /// Método EditarRegiones.
        /// Ejecuta el método EditarRegion de la clase "ClaseRegiones" en la capa DAL
        /// Espera como parámetro una clase que contendrá como atributos los valores de los campos a editar.
        /// Retorna un valor booleano con el fin de informar el éxito que tuvo la transacción.
        /// </summary>
        /// <param name="Region"></param>
        /// <returns></returns>
        public static bool EditarRegiones(Regiones Region)
        {
            return ClaseRegiones.EditarRegion(Region);
        }
    }
}
