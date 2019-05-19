using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RegistroUsuario.BLL;
using RegistroUsuario.Entidades;

namespace RegistroUsuario.UI.Consultas
{
    public partial class cUsuario : Form
    {
        public cUsuario()
        {
            InitializeComponent();
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            var listado = new List<Usuarios>();

            if(CriteriotextBox.Text.Trim().Length > 0)
            {
                switch(FiltrocomboBox.SelectedIndex)
                {
                    case 0: //todo
                        listado = UsuariosBLL.Getlist(u => true);
                        break;
                    case 1: // ID
                        int id = Convert.ToInt32(CriteriotextBox.Text);
                        listado = UsuariosBLL.Getlist(u => u.UsuarioId == id);
                        break;
                    case 2: //Nombre
                        listado = UsuariosBLL.Getlist(u => u.Nombre.Contains(CriteriotextBox.Text));
                        break;
                    case 3: // email
                        listado = UsuariosBLL.Getlist(u => u.Email.Contains(CriteriotextBox.Text));
                        break;
                    case 4: //Usuario
                        listado = UsuariosBLL.Getlist(u => u.Usuario.Contains(CriteriotextBox.Text));
                        break;
                }
                listado = listado.Where(c => c.FechaIngreso.Date >= DesdedateTimePicker.Value.Date && c.FechaIngreso <= HastadateTimePicker.Value.Date).ToList();
            }
            else
            {
                listado = UsuariosBLL.Getlist(u => true);
            }

            ConsultadataGridView.DataSource = null;
            ConsultadataGridView.DataSource = listado;
        }

        private void CriteriotextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
