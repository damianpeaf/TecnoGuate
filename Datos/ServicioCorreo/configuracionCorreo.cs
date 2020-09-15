using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.ServicioCorreo
{
    class configuracionCorreo:Correo
    {
        public configuracionCorreo()
        {
            correo = "tecnoguate26@gmail.com";
            pass = "tecno123";
            host = "smtp.gmail.com";
            puerto = 587;
            ssl = true;
            InicioCliente();

        }
    }
}
