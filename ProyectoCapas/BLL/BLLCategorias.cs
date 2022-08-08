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
    public class BLLCategorias
    {
        public static DataTable ListarCategorias(string strCatt)
        {
            return ClaseCategorias.ListarCategorias(strCatt);
        }

        //public static bool InsertarCategorias(categorias categoria)
        //{
        //    return ClaseCategorias.InsertaCategoria(categoria);
        //}

        public static bool InsertarCategoriasFotos(categorias categoria)
        {
            return ClaseCategorias.InsertaCategoriaFoto(categoria);
        }

        public static bool EliminarCategoria(int CatID)
        {
            return ClaseCategorias.EliminaCategoria(CatID);
        }
    }
}
