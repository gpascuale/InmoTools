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
using System.Windows.Shapes;

namespace InmoTools
{
    /// <summary>
    /// Lógica de interacción para Registro.xaml
    /// </summary>
    public partial class Registro : Window
    {
        public Registro()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["bdd"].ConnectionString);
        private object frameContent;

        private void BtnRegistro_Click(object sender, RoutedEventArgs e)
        {
            if (campoUsuario.Text == "" || campoContrasenia.ToString() == "")
            {
                MessageBox.Show("Algún campo vacio",
             "Error", MessageBoxButton.OK, MessageBoxImage.Error);
           
        }
            else
            {
                con.Open();
                string sqlString = "Insert into  usuarios (nombre,contrasenia) Values(@nombre, @contrasenia)";
                using (SqlCommand cm = new SqlCommand(sqlString, con))
                {
                    cm.Parameters.AddWithValue("@nombre", campoUsuario.Text);
                    cm.Parameters.AddWithValue("@contrasenia", campoContrasenia.Password.ToString());
                    cm.ExecuteNonQuery();
                    MessageBox.Show("Bienvenido", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);

                    con.Close();
                    campoUsuario.Text = "";
                    //campoContrasenia.Password.ToString() = "";
                    Login login = new Login();
                    login.Show();
                    this.Close();
                    
                }


            }
        }
    }
}
