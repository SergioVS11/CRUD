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
    public partial class Borrar : Page
    {
        Conexion conexion = new Conexion();

        public Borrar()
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

        private void EliminarProducto_Click(object sender, RoutedEventArgs e)
        {
            string nombreProducto = txtEliminarProducto.Text.Trim();

            if (string.IsNullOrEmpty(nombreProducto))
            {
                MessageBox.Show("Por favor, ingrese el nombre del producto a eliminar.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

           
            bool eliminado = conexion.EliminarProducto(nombreProducto);

            if (eliminado)
            {
                MessageBox.Show("Producto eliminado correctamente.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                txtEliminarProducto.Clear();
                CargarDatos(); 
            }
            else
            {
                MessageBox.Show("El producto no existe o no se pudo eliminar.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CargarDatos()
        {
            dgProductos.ItemsSource = conexion.ObtenerProductos().DefaultView;
            dgCategorias.ItemsSource = conexion.ObtenerCategorias().DefaultView;
        }
    }
}