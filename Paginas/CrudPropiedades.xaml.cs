using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace InmoTools.Paginas
{
    /// <summary>
    /// Lógica de interacción para CrudPropiedades.xaml
    /// </summary>
    public partial class CrudPropiedades : Page
    {
        /// <summary>
        /// Ventana para insertar propiedades
        /// </summary>
        public CrudPropiedades()
        {
            InitializeComponent();
        }

        private void BtnVolver_Click(object sender, RoutedEventArgs e)
        {
            Content = new Propiedades();
        }
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["bdd"].ConnectionString);
        private void BtnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (CampoDireccion.Text == ""  || cbZona.Text == "" || CampoM2.Text == "" || CampoTipo.Text == "" || CampoPrecio.Text == "" || cbOperacion.Text == "")
            {
                MessageBox.Show("Algun campo vacío");
            }
            else
            {
                con.Open();
                string sqlString = "Insert into  propiedades (direccion,zona,m2,tipo,precio,operacion,imagen) Values(@direccion,@zona,@m2,@tipo,@precio,@operacion,@imagen)";
                using (SqlCommand cm = new SqlCommand(sqlString, con))
                {
                    cm.Parameters.AddWithValue("@direccion", CampoDireccion.Text);
                    cm.Parameters.AddWithValue("@zona", cbZona.Text);
                    cm.Parameters.AddWithValue("@m2", CampoM2.Text);
                    cm.Parameters.AddWithValue("@tipo", CampoTipo.Text);
                    cm.Parameters.AddWithValue("@precio", CampoPrecio.Text);
                    cm.Parameters.AddWithValue("@operacion", cbOperacion.Text);
                    cm.Parameters.AddWithValue("@imagen",SqlDbType.VarBinary).Value=data;
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Propiedad creada");
                    Content = new Propiedades();

                }


            }
        }
        byte[] data;
        private void CargarImagen(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == true)
            {
                FileStream fs = new FileStream(ofd.FileName,FileMode.Open,FileAccess.Read);
                data=new byte[fs.Length];
                fs.Read(data, 0, System.Convert.ToInt32(fs.Length));
                fs.Close(); 
                ImageSourceConverter imgs = new ImageSourceConverter();
                Foto1.SetValue(Image.SourceProperty, imgs.ConvertFromString(ofd.FileName.ToString()));
            }

        }


       

    }
}
