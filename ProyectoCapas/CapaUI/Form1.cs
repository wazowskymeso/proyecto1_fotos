using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using BLL;
using Entidades;

namespace CapaUI
{
    public partial class Form1 : Form
    {
       private DataTable dtListado;
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Evento de carga del formulario, ejecuta el método de Listar que muestra las regiones
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            Listar();
        }

        /// <summary>
        /// El método Listar obtiene la data de la base de datos y la muestra através de una data grid view
        /// </summary>
        private void Listar()
        {
            dtListado = BLL.BLLRegiones.ListarRegiones("");
            dgRegiones.DataSource = dtListado;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Evento click del botón editar.
        /// Realiza la función de agregar un registro a las regiones.
        /// Implementa una instancia de la clase regiones para la asignación de atributos (RegionID y RegionDescripcion)
        /// Ejecuta método de InsertarRegiones con los parámetros previamente asigandos a la clase Regiones
        /// Verifica si la transacción resultó exitosa para mostrar un mensaje correspondiente
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            bool resultado = false;
            Regiones Region=new Regiones();
            Region.RegionID = Convert.ToInt32(txtRegionID.Text);
            Region.RegionDescripcion = txtRegionNombre.Text;
            resultado = BLL.BLLRegiones.InsertarRegiones(Region);
            if (resultado)
            {
                MessageBox.Show("Registro ingresado correctamente");
                Limpiarcontroles();
                Listar();
            }
            else
            {
                MessageBox.Show("No se pudo ingresar el registro");
            }
        }


        /// <summary>
        /// Evento de click del botón "Nuevo", ejecuta el método "Limpiarcontroles".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Limpiarcontroles();
        }

        /// <summary>
        /// El evento Limpiarcontroles borra el texto ingresado en los TextBox de regionID y regionDescription para un posterior ingreso de datos
        /// </summary>
        public void Limpiarcontroles()
        {
            txtRegionID.Text = "";
            txtRegionNombre.Text = "";
        }

        private void dgRegiones_SelectionChanged(object sender, EventArgs e)
        {
           
        }

        /// <summary>
        /// Evento que se acciona al hacer click en una celda del data grid view.
        /// Obtiene la coordenada de la fila y columna de la celda para obtener los datos deseados con el fin de aplicarle un mantenimiento posterior
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgRegiones_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Limpiarcontroles();
            int RowNo;
            RowNo = e.RowIndex;
            txtRegionID.Text = dgRegiones.Rows[RowNo].Cells[0].Value.ToString();
            txtRegionNombre.Text= dgRegiones.Rows[RowNo].Cells[1].Value.ToString();
        }

        /// <summary>
        /// Evento click del botón de eliminar.
        /// Realiza la acción de eliminar un registro de regiones.
        /// Ejecuta el método de EliminarRegiones con el ID de la region como parámetro
        /// Verifica si la transacción fué exitosa para mostrar el mensaje correspondiente
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEliminar_Click(object sender, EventArgs e)
        {           
            bool resultado = false;
            resultado = BLL.BLLRegiones.EliminaRegiones(Convert.ToInt32(txtRegionID.Text));
            if (resultado)
            {
                MessageBox.Show("Registro Eliminado correctamente");
                Limpiarcontroles();
                Listar();
            }
            else
            {
                MessageBox.Show("No se pudo Eliminar el registro");
            }
        }

        /// <summary>
        /// Evento click del botón editar.
        /// Realiza la función de modificar un registro de las regiones.
        /// Implementa una instancia de la clase regiones para la asignación de atributos (RegionID y RegionDescripcion)
        /// Ejecuta método de EditarRegiones con los parámetros previamente asigandos a la clase Regiones
        /// Verifica si la transacción resultó exitosa para mostrar un mensaje correspondiente
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEditar_Click(object sender, EventArgs e)
        {
            bool resultado = false;
            Regiones Region = new Regiones();
            Region.RegionID = Convert.ToInt32(txtRegionID.Text);
            Region.RegionDescripcion = txtRegionNombre.Text;
            resultado = BLL.BLLRegiones.EditarRegiones(Region);
            if (resultado)
            {
                MessageBox.Show("Registro editado correctamente");
                Limpiarcontroles();
                Listar();
            }
            else
            {
                MessageBox.Show("No se pudo editar el registro");
            }
        }
    }
}
