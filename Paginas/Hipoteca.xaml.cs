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
    /// Lógica de interacción para Hipoteca.xaml
    /// </summary>
    public partial class Hipoteca : Page
    {
        public Hipoteca()
        {
            InitializeComponent();
        }
        

        private void BtnCalcular_Click(object sender, RoutedEventArgs e)
        {
            if (CampoPrecio.Text == "" || CampoAhorro.Text == "" || CampoAños.Text == "" || cbEstado.Text == "" )
            {
                MessageBox.Show("Algun campo vacío");
            }
            else
            {
               
                double precio = Int32.Parse(CampoPrecio.Text);
                double ahorro = Int32.Parse(CampoAhorro.Text);
                double años = Int32.Parse(CampoAños.Text);
                double cuotaFinal = (precio * 0.2 )/12 ;
                double cuotaFinal2 = cuotaFinal / 5;
                double TotalFinal= (cuotaFinal * años) + precio;
                CuotaCampo.Text = cuotaFinal2.ToString()+" "+" Euros";
                TotalCampo.Text = TotalFinal.ToString()+" "+ "Euros";


            }
        }

        private void BtnVaciar_Click(object sender, RoutedEventArgs e)
        {
            CampoAhorro.Text = "";
            CampoAños.Text = "";
            CampoPrecio.Text = "";
            cbEstado.Text = "";
            CuotaCampo.Text = "";
            TotalCampo.Text = "";

        }
    }
}
