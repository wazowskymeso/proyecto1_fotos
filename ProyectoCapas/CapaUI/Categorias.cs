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
using System.IO;
namespace CapaUI
{
    public partial class Categorias : Form
    {
        private DataTable dataCat;
        string nombre;
        public Categorias()
        {
            InitializeComponent();
        }

        private void Categorias_Load(object sender, EventArgs e)
        {
            cargarCategorias();
        }

        public void cargarCategorias()
        {
            dataCat = BLL.BLLCategorias.ListarCategorias("");
            dgCat.DataSource = dataCat;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            bool resultado = false;
            categorias categorias = new categorias();
            categorias.CategoriaID = Convert.ToInt32(tbCatID.Text);
            categorias.CategoryName = tbNombre.Text.ToString();
            categorias.Description = tbDescri.Text.ToString();
            MemoryStream ms = new MemoryStream();
            Image image = Image.FromFile(nombre);
            image.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            categorias.Picture = (ms.ToArray());
            resultado = BLL.BLLCategorias.InsertarCategoriasFotos(categorias);
            if (resultado)
            {
                MessageBox.Show("Registro ingresado correctamente");
                Limpiarcontroles();
                cargarCategorias();
            }
            else
            {
                MessageBox.Show("No se pudo ingresar el registro");
            }
        }

        private void Limpiarcontroles()
        {
            tbCatID.Clear();
            tbNombre.Clear();
            tbDescri.Clear();
            tbCatID.Focus();
        }

        private void btImagen_Click(object sender, EventArgs e)
        {
            int size = -1;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string file = openFileDialog1.FileName;
                nombre = openFileDialog1.FileName;
                try
                {
                    string text = File.ReadAllText(file);
                    size = text.Length;
                    pictureBox1.Image = new Bitmap(openFileDialog1.FileName);
                }
                catch (IOException)
                {
                    
                    throw;
                }

            }
        }
    }
}
