﻿using System;
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
using System.Windows.Shapes;

namespace InmoTools
{
    /// <summary>
    /// Lógica de interacción para Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["bdd"].ConnectionString);
        public Login()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            /*conexion.Open();
            SqlCommand comandos = new SqlCommand("Select contrasenia from  usuarios where nombre="+ campoUsuario.Text, conexion);
            muestra.Text = comandos.ToString();
            if (campoContrasenia.Password.ToString() == comandos.Parameters.ToString())
            {
                MessageBox.Show("Bienvenido"+""+campoUsuario.Text);
                comandos.ExecuteNonQuery();
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
            else
            {
               // MessageBox.Show("Campos incorrectos");
            }
            conexion.Close();*/

            try
            {
                {
                    conexion.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT nombre, contrasenia FROM usuarios WHERE nombre='" + campoUsuario.Text + "' AND contrasenia='" + campoContrasenia.Password.ToString() + "'", conexion))
                    {
                        SqlDataReader dr = cmd.ExecuteReader();
                        if (dr.Read())
                        {
                            MessageBox.Show("Login exitoso.");
                            MainWindow mainWindow = new MainWindow();
                            mainWindow.Show();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Datos incorrectos.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }


        }

        private void BtnRegistro_Click(object sender, RoutedEventArgs e)
        {
            Registro r = new Registro();
            r.Show();
            this.Close();
        }



    }
}
