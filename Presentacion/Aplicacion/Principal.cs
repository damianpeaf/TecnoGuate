using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Comun;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.Aplicacion
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Inicio.Inicio frm = new Inicio.Inicio();
            frm.Show();
            this.Hide();
        }

        private void panelCheto1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Principal_Load(object sender, EventArgs e)
        {
            labelNombre.Text = info_usuario.nombre;


            if (info_usuario.idTipoUsuario == "1")
            {
                //
            }else if (info_usuario.idTipoUsuario == "2")
            {
                button2.Enabled = false;

            }
            else if (info_usuario.idTipoUsuario == "3")
            {
                button3.Enabled = false;
            }
            else if (info_usuario.idTipoUsuario == "4")
            {
                button4.Enabled = false;
            }
            else if (info_usuario.idTipoUsuario == "5")
            {
                button4.Enabled = false;
            }
            else
            {
                MessageBox.Show("error");
            }

        }


        public void AbrirForm2(object hijo)
        {

            if (this.panel2.Controls.Count > 0)
            {
                this.panel2.Controls.RemoveAt(0);
            }

                Form fh = hijo as Form;
                fh.TopLevel = false;
                fh.Dock = DockStyle.Fill;

                this.panel2.Controls.Add(fh);
                this.panel2.Tag = fh;
                fh.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AbrirForm2(new Formularios.Insertar());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AbrirForm2(new Formularios.Eliminar());

        }

        private void button3_Click(object sender, EventArgs e)
        {
            AbrirForm2(new Formularios.Actualizar());

        }

        private void button4_Click(object sender, EventArgs e)
        {
            AbrirForm2(new Formularios.Mostrar());

        }

        private void button5_Click(object sender, EventArgs e)
        {
            AbrirForm2(new Formularios.Buscar());

        }

        private void button6_Click(object sender, EventArgs e)
        {
            AbrirForm2(new Formularios.Reporte());

        }
    }
}
