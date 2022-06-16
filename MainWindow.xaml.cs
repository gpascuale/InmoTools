using InmoTools.Paginas;
using System;
using System.Collections.Generic;
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

namespace InmoTools
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Clase main de todo el programa
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            frameContent.Navigate(new Dashboard1());
        }


        private void BtnDashboard_Click(object sender, RoutedEventArgs e)
        {
          

            frameContent.Navigate(new Dashboard1());
        }

        private void BtnCerrarSesion_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }

        private void BtnDashboard_GotFocus(object sender, RoutedEventArgs e)
        {
            BtnDashboard.Background = new SolidColorBrush(Colors.DarkSlateGray);
        }

        private void BtnDashboard_LostFocus(object sender, RoutedEventArgs e)
        {
            BtnDashboard.Background = new SolidColorBrush(Colors.Transparent);
        }

        private void BtnProperties_Click(object sender, RoutedEventArgs e)
        {
            frameContent.Navigate(new Propiedades());
        }

        private void BtnProperties_GotFocus(object sender, RoutedEventArgs e)
        {
            BtnProperties.Background = new SolidColorBrush(Colors.DarkSlateGray);
        }

        private void BtnProperties_LostFocus(object sender, RoutedEventArgs e)
        {
            BtnProperties.Background= new SolidColorBrush(Colors.Transparent);
        }

        private void BtnClientes_Click(object sender, RoutedEventArgs e)
        {
            frameContent.Navigate(new Clientes());
        }

        private void BtnClientes_GotFocus(object sender, RoutedEventArgs e)
        {
            BtnClientes.Background = new SolidColorBrush(Colors.DarkSlateGray);
        }

        private void BtnClientes_LostFocus(object sender, RoutedEventArgs e)
        {
            BtnClientes.Background = new SolidColorBrush(Colors.Transparent);

        }

      
      

        private void BtnValoracion_Click(object sender, RoutedEventArgs e)
        {
            frameContent.Navigate(new Valoracion());
        }

        private void BtnValoracion_GotFocus(object sender, RoutedEventArgs e)
        {
            BtnValoracion.Background = new SolidColorBrush(Colors.DarkSlateGray);
        }

        private void BtnValoracion_LostFocus(object sender, RoutedEventArgs e)
        {
            BtnValoracion.Background = new SolidColorBrush(Colors.Transparent);

        }

        private void BtnHipoteca_Click(object sender, RoutedEventArgs e)
        {
            frameContent.Navigate(new Hipoteca());
        }

        private void BtnHipoteca_GotFocus(object sender, RoutedEventArgs e)
        {
            BtnHipoteca.Background = new SolidColorBrush(Colors.DarkSlateGray);
        }

        private void BtnHipoteca_LostFocus(object sender, RoutedEventArgs e)
        {
            BtnHipoteca.Background = new SolidColorBrush(Colors.Transparent);

        }
    }
}
