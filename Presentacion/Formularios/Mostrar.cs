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
    public partial class Mostrar : Form
    {
        public Mostrar()
        {
            InitializeComponent();
            mostrar();

        }



        private void button4_Click(object sender, EventArgs e)
        {
            mostrar();
        }


        void mostrar()
        {
            DominioTelefono telefono = new DominioTelefono();

            try
            {
                DataSet ds = telefono.mostrarTelefono();

                dataGridView1.DataSource = ds.Tables[0];
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("ERROR");
            }
        }
    }
}
