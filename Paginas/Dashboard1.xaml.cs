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

namespace InmoTools.Paginas
{
    /// <summary>
    /// Lógica de interacción para Dashboard1.xaml
    /// </summary>
    public partial class Dashboard1 : Page
    {
        public Dashboard1()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Content =new Propiedades();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Content = new Propiedades();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Content = new Clientes();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Content = new Propiedades();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Content = new Clientes();
        }
    }
}
