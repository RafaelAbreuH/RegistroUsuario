using RegistroUsuario.Entidades;
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

namespace RegistroUsuario.UI.Registro
{
    public partial class rUsuario : Form
    {
        public rUsuario()
        {
            InitializeComponent();
        }

        //todo: Programar los botones

            //Limpiar Campos
         private void Limpiar()
         {
            IdnumericUpDown.Value = 0;
            NombretextBox.Text = string.Empty;
            EmailtextBox.Text = string.Empty;
            UsuariotextBox.Text = string.Empty;
            ClavemaskedTextBox.Text = string.Empty;
            ConfirmarmaskedTextBox.Text = string.Empty;
            NivelUsuariocomboBox.SelectedIndex = 0;
            FechadateTimePicker.Value = DateTime.Now;
            
         }

        private bool ExisteEnLaBaseDeDatos()
        {
            Usuarios usuario = UsuariosBLL.Buscar((int)IdnumericUpDown.Value);
            return (usuario != null);
        }

        //Llena campos
        private Usuarios LlenaClase()
        {
            Usuarios usuario = new Usuarios();
            usuario.UsuarioId = Convert.ToInt32(IdnumericUpDown.Value);
            usuario.Usuario = UsuariotextBox.Text;
            usuario.Nombre = NombretextBox.Text;
            usuario.Email = EmailtextBox.Text;
            usuario.Clave = ClavemaskedTextBox.Text;
            usuario.NivelUsuario = NivelUsuariocomboBox.Text;
            usuario.FechaIngreso = FechadateTimePicker.Value;

            return usuario;
        }

        private void LlenaCampo(Usuarios usuario)
        {
            IdnumericUpDown.Value = usuario.UsuarioId;
            NombretextBox.Text = usuario.Nombre;
            UsuariotextBox.Text = usuario.Usuario;
            EmailtextBox.Text = usuario.Email;
            ClavemaskedTextBox.Text = usuario.Clave;
            NivelUsuariocomboBox.Text = usuario.NivelUsuario;
            FechadateTimePicker.Value = usuario.FechaIngreso;
        }

        private bool validar()
        {
            bool paso = true;
            MyerrorProvider.Clear();

            if(NombretextBox.Text == String.Empty)
            {
                MyerrorProvider.SetError(NombretextBox, "El campo Nombre no puede estar vacio");
                NombretextBox.Focus();
                paso = false;
            }

            if(EmailtextBox.Text == String.Empty)
            {
                MyerrorProvider.SetError(EmailtextBox, "El campo Email no puede estar vacio");
                EmailtextBox.Focus();
                paso = false;
            }
            if (UsuariotextBox.Text == String.Empty)
            {
                MyerrorProvider.SetError(UsuariotextBox, "El campo usuario no puede estar vacio");
                UsuariotextBox.Focus();
                paso = false;
            }

            if (ClavemaskedTextBox.Text == String.Empty)
            {
                MyerrorProvider.SetError(ClavemaskedTextBox, "El campo Clave no puede estar vacio");
                ClavemaskedTextBox.Focus();
                paso = false;
            }

            if(ConfirmarmaskedTextBox.Text != ClavemaskedTextBox.Text)
            {
                MyerrorProvider.SetError(ConfirmarmaskedTextBox, "La clave no coincide");
                ConfirmarmaskedTextBox.Focus();
                paso = false;
            }

            if(NivelUsuariocomboBox.SelectedIndex == 0)
            {
                MyerrorProvider.SetError(NivelUsuariocomboBox, "Debes elegir que nivel es el usuario");
                NivelUsuariocomboBox.Focus();
                paso = false;
            }
            return paso;
        }



      
        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            int id;
            Usuarios usuario = new Usuarios();
            int.TryParse(IdnumericUpDown.Text, out id);

            Limpiar();

            usuario = UsuariosBLL.Buscar(id);

            if(usuario != null)
            {
                MessageBox.Show("Persona Encontrada");
                LlenaCampo(usuario);
            }
            else
            {
                MessageBox.Show("Persona no encontrada");
            }
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            Usuarios usuario;
            bool paso = false;

            if (!validar())
                return;

            usuario = LlenaClase();
            Limpiar();

            //determinar si es guardar o modificar
            if (IdnumericUpDown.Value == 0)
                paso = UsuariosBLL.Guardar(usuario);
            else
            {
                if(!ExisteEnLaBaseDeDatos())
                {
                    MessageBox.Show("No se peude modificar un Usuario que no existe", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                paso = UsuariosBLL.Modificar(usuario);
            }
            //informar el resultado
            if (paso)
                MessageBox.Show("Guardado!!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No fue posible guardar!!", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void EliminarButton_Click(object sender, EventArgs e)
        {
            MyerrorProvider.Clear();
            int id;
            int.TryParse(IdnumericUpDown.Text, out id);

            Limpiar();

            if (UsuariosBLL.Eliminar(id))
                MessageBox.Show("Eliminado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                MyerrorProvider.SetError(IdnumericUpDown, "No se puede eliminar un usuario que no existe");
        }
    }
}
