using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Shapes;
using Tabla2Evaluacion;

namespace Tabla2Evaluacion
{
    public partial class Window2 : Window
    {
        Conexion conexion = new Conexion();
        public Window2()
        {
            InitializeComponent();
            MainFrame.Navigate(new Uri("Inicio.xaml", UriKind.Relative));
        }
        private void Opcion1_Click(object sender, RoutedEventArgs e)
        {
            
            MainFrame.Navigate(new Uri("Inicio.xaml", UriKind.Relative));
        }

        private void Opcion2_Click(object sender, RoutedEventArgs e)
        {
           
            MainFrame.Navigate(new Uri("Agregar.xaml", UriKind.Relative));
        }

        private void Opcion3_Click(object sender, RoutedEventArgs e)
        {
            
            MainFrame.Navigate(new Uri("Modificar.xaml", UriKind.Relative));
        }

        private void Opcion4_Click(object sender, RoutedEventArgs e)
        {
          
            MainFrame.Navigate(new Uri("Borrar.xaml", UriKind.Relative));
        }


        private void Volver_Click(object sender, RoutedEventArgs e)
        {
            using (MySqlConnection conn = conexion.GetConnection())
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }

           
        }


    }


}

    
