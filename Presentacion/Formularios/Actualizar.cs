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
    public partial class Actualizar : Form
    {
        public Actualizar()
        {
            InitializeComponent();
            marcaTelefono();
        }


        private void marcaTelefono()
        {
            try
            {
                DominioTelefono telefono = new DominioTelefono();

                comboBox1.DataSource = telefono.marcaTelefonos();

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("error" + ex);
            }

        }

        int idMarca;

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            idMarca = comboBox1.SelectedIndex + 1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DominioTelefono telefono = new DominioTelefono();

            try
            {
                telefono.ActualizarTelefono(textBox4.Text,textBox1.Text, idMarca, textBox2.Text, textBox3.Text);
                MessageBox.Show("Actualizado Correctamente");
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("ERROR");
            }
        }
    }
}
