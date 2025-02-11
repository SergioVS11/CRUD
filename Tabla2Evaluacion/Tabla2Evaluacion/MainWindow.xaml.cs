using System.Text;
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
    
    public partial class MainWindow : Window
    {

        Conexion conexion= new Conexion();
        public MainWindow()
        {

            InitializeComponent();
        }
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsuario.Text;
            string password = txtContraseña.Password; 

            if (conexion.ValidarUsuario(username, password))
            {
                MessageBox.Show("Inicio de sesión exitoso");

               
                Window2 window2 = new Window2();
                window2.Show();

                this.Close(); 
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos");
            }
        }
        private void Cerrar_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void Minimizar_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
    }
   
}