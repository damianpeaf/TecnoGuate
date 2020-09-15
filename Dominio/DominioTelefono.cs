using Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class DominioTelefono
    {
        private Telefono telefono = new Telefono();

        public DataSet mostrarTelefono()
        {
            DataSet Datos = new DataSet();
            Datos = telefono.Mostrar();
            return Datos;
        }

        public void InsertarTelefono(string modelo, int marca, string stock, string precio)
        {
            telefono.Insertar(modelo, marca, stock, precio);
        }

        public void ActualizarTelefono(string id, string modelo, int marca, string stock, string precio)
        {
            telefono.Actualizar(id, modelo,marca,stock,precio);
        }

        public String[] BuscarTelefono(string id)
        {

            return telefono.Buscar(id);

        }

        public void EliminarTelefono(string id)
        {
            telefono.Eliminar(id);
        }

        public DataTable ReporteTelefono()
        {
            return telefono.Informe();
        }

        ///

        public List<string> marcaTelefonos()
        {
            return telefono.obtenerMarca();
        }

    }
}
