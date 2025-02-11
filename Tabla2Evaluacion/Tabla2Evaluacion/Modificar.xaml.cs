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
    
    public partial class Modificar : Page
    {
        Conexion conexion =new Conexion();
        public Modificar()
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

        private void Modificar_Click(object sender, RoutedEventArgs e)
        {
            string nombreActual = txtProducto.Text.Trim();
            string nuevaCategoria = (txtCategoria.SelectedItem as ComboBoxItem)?.Content?.ToString();
            string nuevoNombre = txtProductoNuevo.Text.Trim();

            if (string.IsNullOrEmpty(nombreActual) || string.IsNullOrEmpty(nuevaCategoria) || string.IsNullOrEmpty(nuevoNombre))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

          
            Console.WriteLine($"Producto: {nombreActual}");
            Console.WriteLine($"Categoría: {nuevaCategoria}");
            Console.WriteLine($"Nuevo nombre: {nuevoNombre}");

            bool actualizado = conexion.ActualizarProducto(nombreActual, nuevaCategoria, nuevoNombre);

            if (actualizado)
            {
                MessageBox.Show("Producto actualizado correctamente.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                txtProducto.Clear();
                txtProductoNuevo.Clear();
                CargarDatos(); 
            }
            else
            {
                MessageBox.Show("No se encontró un producto con ese nombre y categoría.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }
}
    
