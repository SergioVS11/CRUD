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
   
    public partial class Agregar : Page
    {
        Conexion conexion = new Conexion();
        public Agregar()
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
        private void AgregarProducto_Click(object sender, RoutedEventArgs e)
        {
            string nombreProducto = txtProducto.Text;
            string categoriaSeleccionada = (txtCategoria.SelectedItem as ComboBoxItem)?.Content.ToString();

            if (string.IsNullOrEmpty(nombreProducto) || string.IsNullOrEmpty(categoriaSeleccionada))
            {
                MessageBox.Show("Por favor, ingrese el nombre del producto y seleccione una categoría.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

           
            bool productoAgregado = conexion.AgregarProducto(nombreProducto, categoriaSeleccionada);

            if (productoAgregado)
            {
                MessageBox.Show("Producto agregado correctamente.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                CargarDatos();
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("Error al agregar el producto.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void LimpiarCampos()
        {
            txtProducto.Clear();
            txtCategoria.SelectedIndex = -1; 
        }
        private void CargarDatos()
        {
            dgProductos.ItemsSource = conexion.ObtenerProductos().DefaultView;


            dgCategorias.ItemsSource = conexion.ObtenerCategorias().DefaultView;
        }
    }
}
