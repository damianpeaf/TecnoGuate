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
    public partial class Buscar : Form
    {
        public Buscar()
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
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DominioTelefono telefono = new DominioTelefono();

            try
            {
                String[] datos = telefono.BuscarTelefono(textBox4.Text);

                if (datos[0] != null)
                {
                    MessageBox.Show("Telefono encontrado");


                    textBox4.Text = datos[0];
                    textBox1.Text = datos[1];
                    textBox2.Text = datos[3];
                    textBox3.Text = datos[4];


                    int indiceCombo = int.Parse(datos[2]);

                    comboBox1.SelectedIndex = indiceCombo - 1;
                }
                else
                {
                    MessageBox.Show("Telefono NO encontrado");

                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("ERROR");
            }
        }
    }
}
