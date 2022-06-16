using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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
    /// Lógica de interacción para Propiedades.xaml
    /// </summary>
    public partial class Propiedades : UserControl
    {
        /// <summary>
        /// Clase para mostrar,borrar e insertar propiedades
        /// </summary>
        public Propiedades()
        {
            InitializeComponent();
            CargarPropiedades();
        }

        private void BtnCrearPropiedad_Click(object sender, RoutedEventArgs e)
        {
            CrudPropiedades crudPropiedades = new CrudPropiedades();
            FramePropiedades.Content = crudPropiedades; 
        }
        SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["bdd"].ConnectionString);
        void CargarPropiedades()
        {
            conexion.Open();
            SqlCommand comandos = new SqlCommand("Select * from  propiedades order by id", conexion);
            SqlDataAdapter adapter = new SqlDataAdapter(comandos);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            GridDatos.ItemsSource = dt.DefaultView;
            conexion.Close();
        }

        private void BtnBorrarCliente_Click(object sender, RoutedEventArgs e)
        {
            if (GridDatos.SelectedItem != null)
            {

                conexion.Open();
                int i = GridDatos.SelectedIndex;
                DataRowView v = (DataRowView)GridDatos.Items[i];  // this give you access to the row
                int s = (int)v[0];  // this gives you the value in column 0

                SqlCommand comandos = new SqlCommand("Delete from propiedades WHERE id=@ID", conexion);
                comandos.Parameters.AddWithValue("@ID", s);
                comandos.ExecuteNonQuery();
                conexion.Close();
                //volvemos a motrar la tabla de clientes
                Content = new Propiedades();
                MessageBox.Show("Propiedad borrada",
                    "Exito", MessageBoxButton.OK
                     );



            }
            else
            {
                MessageBox.Show("Selecciona un cliente para borrar",
                   "Error", MessageBoxButton.OK
                    );
            }

        }

        private void BtnBuscarPropiedad_Click(object sender, RoutedEventArgs e)
        {
            conexion.Open();
            SqlCommand comandos = new SqlCommand("Select * from  propiedades where direccion=@DIRECCION", conexion);
            comandos.Parameters.AddWithValue("@DIRECCION", CampoBusqueda.Text);
            SqlDataAdapter adapter = new SqlDataAdapter(comandos);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            GridDatos.ItemsSource = dt.DefaultView;
            conexion.Close();
        }

        private void BtnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            CampoBusqueda.Text = "";
            conexion.Open();
            SqlCommand comandos = new SqlCommand("Select * from  propiedades order by id", conexion);
            SqlDataAdapter adapter = new SqlDataAdapter(comandos);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            GridDatos.ItemsSource = dt.DefaultView;
            conexion.Close();
        }
    }
}
