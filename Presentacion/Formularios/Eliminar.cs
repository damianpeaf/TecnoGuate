using Dominio;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.Formularios
{
    public partial class Eliminar : Form
    {
        public Eliminar()
        {
            InitializeComponent();
        }


         private void button2_Click(object sender, EventArgs e)
        {
            DominioTelefono telefono = new DominioTelefono();

            try
            {
                telefono.EliminarTelefono(textBox1.Text);
                MessageBox.Show("Eliminado Correctamente");
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("ERROR");
            }
        }
    }
}
