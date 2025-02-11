using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace Tabla2Evaluacion
{
    internal class Conexion
    {
        
        private string conexion = "datasource=127.0.0.1;port=3306;username=root;password=1234;database=wpflogindb";
        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(conexion);
        }

        public bool ValidarUsuario(string username, string password)
        {
            bool esValido = false;

            using (MySqlConnection conexion = GetConnection())
            {
                conexion.Open();
                string query = "SELECT COUNT(*) FROM usuarios WHERE UserName = @username AND UserID = @password";

                using (MySqlCommand cmd = new MySqlCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);  

                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    esValido = count > 0;
                }
            }

            return esValido;
        }

        public DataTable ObtenerProductos()
        {
            DataTable dataTable = new DataTable();
            using (MySqlConnection conexion = GetConnection())
            {
                conexion.Open();
                string query = "SELECT nombre_producto FROM productos"; 
                using (MySqlCommand cmd = new MySqlCommand(query, conexion))
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                {
                    adapter.Fill(dataTable);
                }
            }
            return dataTable;
        }

        
        public DataTable ObtenerCategorias()
        {
            DataTable dataTable = new DataTable();
            using (MySqlConnection conexion = GetConnection())
            {
                conexion.Open();
                string query = "SELECT  categoria FROM productos";  
                using (MySqlCommand cmd = new MySqlCommand(query, conexion))
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                {
                    adapter.Fill(dataTable);
                }
            }
            return dataTable;
        }
        public bool AgregarProducto(string nombreProducto, string categoria)
        {
            try
            {
                using (MySqlConnection conexionDB = GetConnection())
                {
                    conexionDB.Open();
                    string query = "INSERT INTO productos (nombre_producto, categoria) VALUES (@nombre, @categoria)";

                    using (MySqlCommand cmd = new MySqlCommand(query, conexionDB))
                    {
                        cmd.Parameters.AddWithValue("@nombre", nombreProducto);
                        cmd.Parameters.AddWithValue("@categoria", categoria);

                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                
                Console.WriteLine("Error al agregar el producto: " + ex.Message);
                return false;
            }
        }
        public bool EliminarProducto(string nombre)
        {
            bool eliminado = false;

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "DELETE FROM productos WHERE nombre_producto = @nombre"; 

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@nombre", nombre);

                    int filasAfectadas = cmd.ExecuteNonQuery();
                    eliminado = filasAfectadas > 0;
                }
            }

            return eliminado;
        }

        public bool ActualizarProducto(string nombreActual, string categoria, string nuevoNombre)
        {
            bool actualizado = false;

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();

              
                string verificarQuery = "SELECT COUNT(*) FROM productos WHERE nombre_producto = @nombreActual AND categoria = @categoria";
                using (MySqlCommand verificarCmd = new MySqlCommand(verificarQuery, conn))
                {
                    verificarCmd.Parameters.AddWithValue("@nombreActual", nombreActual);
                    verificarCmd.Parameters.AddWithValue("@categoria", categoria);

                    int count = Convert.ToInt32(verificarCmd.ExecuteScalar());
                    if (count == 0)
                    {
                        return false; 
                    }
                }

               
                string query = "UPDATE productos SET nombre_producto = @nuevoNombre WHERE nombre_producto = @nombreActual AND categoria = @categoria";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@nuevoNombre", nuevoNombre);
                    cmd.Parameters.AddWithValue("@nombreActual", nombreActual);
                    cmd.Parameters.AddWithValue("@categoria", categoria);

                    int filasAfectadas = cmd.ExecuteNonQuery();
                    actualizado = filasAfectadas > 0;
                }
            }

            return actualizado;
        }

        


    }
}


