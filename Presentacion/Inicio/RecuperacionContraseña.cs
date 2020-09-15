using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using System.Windows.Forms;

namespace Presentacion.Inicio
{
    public partial class RecuperacionContraseña : Form
    {
        public RecuperacionContraseña()
        {
            InitializeComponent();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Inicio frm = new Inicio();
            frm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DominioUsuario usuario = new DominioUsuario();

                string msg = usuario.recuperarContraseña(txtCorreo.Text);
                MessageBox.Show(msg);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);

            }
        }
    }
}
