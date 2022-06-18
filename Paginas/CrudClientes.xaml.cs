using System;
using System.Collections.Generic;
using System.Configuration;
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
    /// Lógica de interacción para CrudClientes.xaml
    /// </summary>
    public partial class CrudClientes : Page
    {
        /// <summary>
        /// Ventana para insertar clientes
        /// </summary>
        public CrudClientes()
        {
            InitializeComponent();
        }

        private void BtnVolver_Click(object sender, RoutedEventArgs e)
        {
            Content=new Clientes();
        }
       
         SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["bdd"].ConnectionString);

        private void BtnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if(CampoDni.Text ==""||CampoNombre.Text =="" ||CampoZona.Text ==""||CampoEmail.Text =="" ||CampoTelefono.Text=="" ||CampoPresupuesto.Text==""|| cbOperacion.Text == "")
            {
                MessageBox.Show("Algún campo vacio",
          "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else {
                con.Open();
                string sqlString = "Insert into  clientes (dni,nombre,zona,email,telefono,presupuesto,operacion) Values(@dni,@nombre,@zona,@email,@telefono,@presupuesto,@operacion)";
                using (SqlCommand cm = new SqlCommand(sqlString, con))
                {
                    cm.Parameters.AddWithValue("@dni", CampoDni.Text);
                    cm.Parameters.AddWithValue("@nombre", CampoNombre.Text);
                    cm.Parameters.AddWithValue("@zona", CampoZona.Text);
                    cm.Parameters.AddWithValue("@email", CampoEmail.Text);
                    cm.Parameters.AddWithValue("@telefono", CampoTelefono.Text);
                    cm.Parameters.AddWithValue("@presupuesto", CampoPresupuesto.Text);
                    cm.Parameters.AddWithValue("@operacion", cbOperacion.Text);
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Cliente creado","Exito",MessageBoxButton.OK,MessageBoxImage.Information);
                    Content = new Clientes();

                }
                
                
            }

        }

    }
}