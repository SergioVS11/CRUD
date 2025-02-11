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

namespace Tabla2Evaluacion
{
   
    public partial class Inicio : Page
    {
        private Conexion conexion = new Conexion();
        public Inicio()
        {
            InitializeComponent();
            CargarDatos();
        }
        private void Cerrar_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void MinimizarVentana_Click(object sender, RoutedEventArgs e)
        {
           
            Window ventanaPrincipal = Window.GetWindow(this);
            if (ventanaPrincipal != null)
            {
                ventanaPrincipal.WindowState = WindowState.Minimized;
            }
        }
        private void CargarDatos()
        {
            dgProductos.ItemsSource = conexion.ObtenerProductos().DefaultView;

         
            dgCategorias.ItemsSource = conexion.ObtenerCategorias().DefaultView;
        }
    }
}
