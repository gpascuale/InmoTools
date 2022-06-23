using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Metadata.Edm;
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

    public partial class Cruces : UserControl
    {
        

        //ID variable used in Updating and Deleting Record  
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["bdd"].ConnectionString);
        public Cruces()
        {
            InitializeComponent();
            CargarCruces();
        }


        void CargarCruces()
        {
            con.Open();
            propiedad.Text = "ID PROPIEDAD=" + "" + Propiedades.id;

            SqlCommand comandos = new SqlCommand("Select * from  clientes where zona=@ZONA and presupuesto=@PRECIO  order by id", con);
            comandos.Parameters.AddWithValue("@ZONA", Propiedades.zona);
            comandos.Parameters.AddWithValue("@PRECIO", Propiedades.presupuesto);
            SqlDataAdapter adapter = new SqlDataAdapter(comandos);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            GridDatos2.ItemsSource = dt.DefaultView;
            con.Close();
        }


        private void BtnLimpia_Click(object sender, RoutedEventArgs e)
        {
            Content = new Propiedades();

        }
    }
}
