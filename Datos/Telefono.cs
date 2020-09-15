using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Telefono
    {

        MySqlConnection cn;
        DataSet ds;

        public DataSet Mostrar()
        {
            try
            {
                using (cn = new Conexion().IniciarConexion()) 
                { 

                MySqlCommand datos = new MySqlCommand("SELECT * FROM telefono", cn);

                MySqlDataAdapter m_datos = new MySqlDataAdapter(datos);
                ds = new DataSet();
                m_datos.Fill(ds);
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("" + ex);
                return null;
            }
            finally
            {
                cn.Close();
            }

            return ds;

        }

        public void Insertar(string modelo, int marca, string stock, string precio)
        {
            try
            {
                using (cn = new Conexion().IniciarConexion())
                {
                    MySqlCommand comando = new MySqlCommand($"INSERT INTO telefono VALUES(null,'{modelo}' , {marca}, {stock}, {precio})", cn);
                    comando.ExecuteNonQuery();
                }

            }
            catch (MySqlException ex)
            {
                Console.WriteLine("" + ex);
            }
            finally
            {
                cn.Close();
            }
        }

        public void Actualizar(string id, string modelo, int marca, string stock, string precio)
        {
            try
            {
                using (cn = new Conexion().IniciarConexion())
                {
                    MySqlCommand comando = new MySqlCommand($"UPDATE telefono set modelo='{modelo}', marca={marca}, stock={stock}, precio={precio} WHERE idTelefono='{id}' ", cn);

                    comando.ExecuteNonQuery();
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("" + ex);

            }
            finally
            {
                cn.Close();
            }
        }

        public String[] Buscar(string id)
        {
            try
            {

                using (cn = new Conexion().IniciarConexion())
                {


                    string query = $"SELECT * FROM telefono WHERE idTelefono='{id}' ";

                    MySqlCommand comando = new MySqlCommand(query, cn);
                    MySqlDataReader reader = comando.ExecuteReader();

                    String[] datos = new string[5];

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            datos[0] = reader.GetString(0);
                            datos[1] = reader.GetString(1);
                            datos[2] = reader.GetString(2);
                            datos[3] = reader.GetString(3);
                            datos[4] = reader.GetString(4);
                        }

                        reader.Close();
                    }

                    return datos;

                }

            }
            catch (MySqlException ex)
            {
                Console.WriteLine("" + ex);
                return null;
            }
            finally
            {
                cn.Close();
            }
        }

        public void Eliminar(string id)
        {
            try
            {
                using (cn = new Conexion().IniciarConexion())
                {
                    MySqlCommand comando = new MySqlCommand($"Delete From telefono where idTelefono='{id}' ", cn);

                    comando.ExecuteNonQuery();
                }

            }
            catch (MySqlException ex)
            {
                Console.WriteLine("" + ex);

            }
            finally
            {
                cn.Close();
            }
        }

        public DataTable Informe()
        {

            try
            {
                using (cn = new Conexion().IniciarConexion())
                {
                    string query = "SELECT T.idTelefono, T.modelo, M.nombre as 'marca', T.stock, T.precio, (T.stock * T.precio) as 'total' From telefono T inner join marca M on T.marca = M.idMarca";

                    MySqlCommand comando = new MySqlCommand(query, cn);

                    MySqlDataAdapter datos = new MySqlDataAdapter(comando);
                    DataTable dt = new DataTable();
                    datos.Fill(dt);

                    return dt;

                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("" + ex);
                return null;
            }
            finally
            {
                cn.Close();
            }


        }



        ////////////// marca /////////////

        public List<string> obtenerMarca()
        {
            try
            {

                using (cn = new Conexion().IniciarConexion())
                {

                    List<string> marca = new List<string>();

                    MySqlCommand comando = new MySqlCommand("SELECT nombre, idMarca From marca order by idMarca asc", cn);
                    MySqlDataReader reader = comando.ExecuteReader();

                    while (reader.Read())
                    {
                        marca.Add(reader.GetString(0).ToString());
                    }

                    reader.Close();

                    return marca;

                }
            }
            catch (MySqlException ex)
            {

                return null;
                Console.WriteLine("NI");
            }

        }

    }
}
