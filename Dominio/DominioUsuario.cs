using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Dominio
{
    public class DominioUsuario
    {

        Usuario usuario = new Usuario();


        public bool validarUsuario(string user, string pass)
        {
            return usuario.validarUsuario(user, pass);
        }

        public string recuperarContraseña(string correo)
        {
            return usuario.recuperarContraseña(correo);
        }
    }
}
