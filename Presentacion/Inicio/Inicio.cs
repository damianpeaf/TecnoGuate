using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;
using Comun;
using MySql.Data.MySqlClient;

namespace Presentacion.Inicio
{
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            RecuperacionContraseña frm = new RecuperacionContraseña();
            frm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DominioUsuario usuario = new DominioUsuario();
                bool datosUsuario = usuario.validarUsuario(txtUsuario.Text, txtContraseña.Text);

                if (datosUsuario != false)
                {
                    if (info_usuario.idTipoUsuario == "1" || info_usuario.idTipoUsuario == "2" || info_usuario.idTipoUsuario == "3" || info_usuario.idTipoUsuario == "4" || info_usuario.idTipoUsuario == "5")
                    {
                        Aplicacion.Principal frm = new Aplicacion.Principal();
                        frm.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("NO SE ENCUENTRA EL ROL");
                    }
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrecta");
                }

            }
            catch (MySqlException ex)
            {
            }
        }
    }
}
