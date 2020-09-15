using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Comun;

namespace Datos
{
    public class Usuario
    {

        MySqlConnection cn;

        public bool validarUsuario(string user, string pass)
        {
            try
            {

                using (cn = new Conexion().IniciarConexion())
                {
                    MySqlCommand comando = new MySqlCommand($"SELECT * FROM usuario where usuario='{user}' and contraseña='{pass}' ", cn);
                    MySqlDataReader reader = comando.ExecuteReader();

                    if (reader.HasRows)
                    {

                        while (reader.Read())
                        {
                            info_usuario.idUsuario = reader.GetString(0);
                            info_usuario.nombre = reader.GetString(1);
                            info_usuario.apellido =  reader.GetString(2);
                            info_usuario.idTipoUsuario = reader.GetString(5);

                        }

                        reader.Close();


                        return true;

                    }
                    else
                    {
                        Console.WriteLine("no devolvio nada el where");
                        return false;
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        public String recuperarContraseña(string correo)
        {
            using (cn = new Conexion().IniciarConexion())
            {
                MySqlCommand comando = new MySqlCommand($"SELECT * FROM usuario WHERE correo='{correo}' ", cn);
                MySqlDataReader datos = comando.ExecuteReader();

                if (datos.HasRows)
                {
                    string correoUsuario = "";
                    string nombreUsuario = "";
                    string contraseñaUsuario = "";

                    if (datos.Read())
                    {
                        nombreUsuario = datos.GetString(1);
                        correoUsuario = datos.GetString(2);
                        contraseñaUsuario = datos.GetString(4);


                        var servicio = new ServicioCorreo.configuracionCorreo();

                        servicio.EnviarMensaje("Recuperacion Contraseña - TECNO GUATE", $"Estimado {nombreUsuario}, su solicitud para recuperar su contraseña ha sido procesada. Su Contraseña es: {contraseñaUsuario}", correoUsuario);


                    }

                    return $"Te hemos enviado un mensaje, chequea tu correo electronico {correoUsuario}";


                }
                else
                {
                    return "Correo Incorrecto o no registrado";
                }

            }
        }


    }
}
