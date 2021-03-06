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
        public static int presupuesto ;
        public static String zona;
        public static int id;

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
                    "Exito", MessageBoxButton.OK, MessageBoxImage.Information
                     );



            }
            else
            {
                MessageBox.Show("Selecciona una propiedad para borrar",
                   "Error", MessageBoxButton.OK, MessageBoxImage.Error
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

        public void BtnCruces_Click(object sender, RoutedEventArgs e)
        {
            if (GridDatos.SelectedItem != null)
            {

                
                conexion.Open();
                int i = GridDatos.SelectedIndex;
                DataRowView v = (DataRowView)GridDatos.Items[i];  // this give you access to the row
                var s = (double)v[5];  // this gives you the value in column 0
                DataRowView w = (DataRowView)GridDatos.Items[i];  // this give you access to the row
                var p = v[2];  // this gives you the value in column 0
                DataRowView Q = (DataRowView)GridDatos.Items[i];  // this give you access to the row
                var d = v[0];  // this gives you the value in column 0
                id=(int)d;
                presupuesto = (int)s;
                zona = p.ToString();
                Content = new Cruces();

                /*  SqlCommand comandos = new SqlCommand("Select * from  clientes where zona=@ZONA and presupuesto=@PRECIO  order by id", conexion);
                 comandos.Parameters.AddWithValue("@ZONA", p);
                 comandos.Parameters.AddWithValue("@PRECIO", s);
                 SqlDataAdapter adapter = new SqlDataAdapter(comandos);

               
                /* DataTable dt = new DataTable();
                 adapter.Fill(dt);
                 GridDatos.ItemsSource = dt.DefaultView;*/
                conexion.Close();
                //volvemos a motrar la tabla de clientes



            }
            else
            {
                MessageBox.Show("Selecciona una propiedad para cruzar",
                   "Error", MessageBoxButton.OK, MessageBoxImage.Error
                    );
            }
        }
    }
}
