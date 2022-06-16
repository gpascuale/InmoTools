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
    /// Lógica de interacción para Valoracion.xaml
    /// </summary>

    public partial class Valoracion : Page
    {
        /// <summary>
        /// Algoritmo  que valora los inmuebles
        /// </summary>
        /// <returns>Retorna los precios de valoracion </returns>
        public Valoracion()
        {
            InitializeComponent();
        }

        double contador = 0;
        double metrosZonaMax;
        double metrosZonaMin;
        double metrosZonaMed;
        double dormitorios;
        double d10;
        double obra;
        double o10;
        double baños;
        double b10;
        double terraza;
        double t10;
        double piscina;
        double p10;
        double med;
        double min;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (cbZona.Text == "" || CampoM2.Text == "" || CampoUtiles.Text == "" || cbObra.Text == "" || cbJardin.Text == "" || cbEf.Text == "" || cbDormitorios.Text == "" || cbBaños.Text == "" || cbPiscina.Text == "" )
            {
                MessageBox.Show("Algun campo vacío");
            }
            else///M2/zona
            {
                int m2= Int32.Parse(CampoM2.Text);
                contador = m2;
                 if(cbZona.SelectedItem.ToString().Contains("Málaga centro"))
                {
                    metrosZonaMax = contador * 2854;
                }
                if (cbZona.SelectedItem.ToString().Contains("Carretera Cadiz"))
                {
                    metrosZonaMax = contador * 2139;
                }
                if (cbZona.SelectedItem.ToString().Contains("Ciudad Jardin"))
                {
                    metrosZonaMax = contador * 1429;
                }
                if (cbZona.SelectedItem.ToString().Contains("Puerto la Torre"))
                {
                    metrosZonaMax = contador * 1907;
                }
                if (cbZona.SelectedItem.ToString().Contains("Miraflores"))
                {
                    metrosZonaMax = contador * 1678;
                }
                if (cbZona.SelectedItem.ToString().Contains("Teatinos"))
                {
                    metrosZonaMax = contador * 2439;
                }
                if (cbZona.SelectedItem.ToString().Contains("Pedregalejo"))
                {
                    metrosZonaMax = contador * 3028;
                }
                if (cbZona.SelectedItem.ToString().Contains("El Limonar"))
                {
                    metrosZonaMax = contador * 2997;
                }
                if (cbZona.SelectedItem.ToString().Contains("Campanillas"))
                {
                    metrosZonaMax = contador * 1587;
                }
                if (cbZona.SelectedItem.ToString().Contains("Alhaurin de la torre"))
                {
                    metrosZonaMax = contador * 1631;
                }
                if (cbZona.SelectedItem.ToString().Contains("Torremolinos"))
                {
                    metrosZonaMax = contador * 2190;
                }
                if (cbZona.SelectedItem.ToString().Contains("Benalmadena"))
                {
                    metrosZonaMax = contador * 2412;
                }
                if (cbZona.SelectedItem.ToString().Contains("Fuengirola"))
                {
                    metrosZonaMax = contador * 2572;
                }
                if (cbZona.SelectedItem.ToString().Contains("Marbella"))
                {
                    metrosZonaMax = contador * 3500;
                }
            
            ///Dormitorios
            if (cbDormitorios.SelectedItem.ToString().Contains("0"))
            {
                d10 = metrosZonaMax * 0.1;
                dormitorios = metrosZonaMax - d10;

            }
            if (cbDormitorios.SelectedItem.ToString().Contains("1"))
            {
                dormitorios = metrosZonaMax;
            }
            if (cbDormitorios.SelectedItem.ToString().Contains("2"))
            {
                dormitorios = metrosZonaMax;
            }
            if (cbDormitorios.SelectedItem.ToString().Contains("3"))
            {
                d10= metrosZonaMax * 0.15;
                dormitorios = metrosZonaMax + d10; 
            }
            if (cbDormitorios.SelectedItem.ToString().Contains("4"))
            {
                d10 = metrosZonaMax *0.17;
                dormitorios = metrosZonaMax + d10;
            }
            if (cbDormitorios.SelectedItem.ToString().Contains("5"))
            {
                d10 = metrosZonaMax * 0.18;
                dormitorios = metrosZonaMax + d10;
            }

            ///obra nueva
            if (cbObra.SelectedItem.ToString().Contains("Si")){
                o10 = dormitorios * 0.2;
                obra = o10 + dormitorios;
            }
            if (cbObra.SelectedItem.ToString().Contains("No"))
            {
                obra = dormitorios;
            }

            ///baños
             if (cbBaños.SelectedItem.ToString().Contains("1"))
            {
                baños = obra;
            }
             if (cbBaños.SelectedItem.ToString().Contains("2"))
            {
                d10 = obra * 0.05;
                baños = obra + d10;
            }
             if (cbBaños.SelectedItem.ToString().Contains("3"))
            {
                d10 = obra * 0.1;
                baños = obra + d10;
            }

            ///Terraza
            if (cbTerraza.SelectedItem.ToString().Contains("Si"))
            {
                t10 = baños * 0.1;
                terraza=baños + d10;
            }
            if (cbTerraza.SelectedItem.ToString().Contains("Si"))
            {
                terraza = baños;
            }

            ///Piscina
            if (cbPiscina.SelectedItem.ToString().Contains("Si"))
            {
                p10= baños * 0.1;
                piscina=baños+p10;
            }
            if (cbPiscina.SelectedItem.ToString().Contains("No"))
            {
                piscina = baños;
            }
            if (cbPiscina.SelectedItem.ToString().Contains("Comunitario"))
            {
                piscina = baños;
            }

            med = piscina -(piscina * 0.12);
            min = piscina - (piscina * 0.20);

            PrecioMax.Text = piscina + " Euros";
            PrecioMed.Text = med + " Euros";
            PrecioMin.Text = min + " Euros";
            }
        }

        private void vaciar_Click(object sender, RoutedEventArgs e)
        {
            PrecioMax.Text = "";
            PrecioMed.Text = "";
            PrecioMin.Text = "";
            CampoM2.Text = "";
            CampoUtiles.Text = "";
            cbBaños.Text = "";
            cbDormitorios.Text = "";
            cbEf.Text = "";
            cbJardin.Text = "";
            cbObra.Text = "";
            cbPiscina.Text = "";
            cbTerraza.Text = "";
            cbZona.Text = "";

        }
    }
}
