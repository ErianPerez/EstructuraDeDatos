using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryEstructuraDeDatos
{
    public partial class frm03Pila : Form
    {
        public frm03Pila()
        {
            InitializeComponent();
        }
        private void ControlCajasDeTexto()
        {
            if (txtCodigo.Text != "" && txtNombre.Text != "" && txtTramite.Text != "")
            {
                btnAgregar.Enabled = true;
            }
            else
            {
                btnAgregar.Enabled = false;
            }
        }
        Pila FilaDePersonas = new Pila();

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Nodo ObjNodo = new Nodo();
            ObjNodo.Codigo = Convert.ToInt32(txtCodigo.Text);
            ObjNodo.Nombre = txtNombre.Text;
            ObjNodo.Tramite = txtTramite.Text;
            FilaDePersonas  .Agregar(ObjNodo);
            FilaDePersonas.Recorrer(lstPila);
            FilaDePersonas.Recorrer(dgvPila);
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtTramite.Text = "";
            txtCodigo.Select();
            txtCodigo.Focus();
        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            if (FilaDePersonas.Primero != null)
            {
                lblCodigo.Text = FilaDePersonas.Primero.Codigo.ToString();
                lblNombre.Text = FilaDePersonas.Primero.Nombre;
                lblTramite.Text = FilaDePersonas.Primero.Tramite;
                FilaDePersonas.Eliminar();
                FilaDePersonas.Recorrer(dgvPila);
                FilaDePersonas.Recorrer(lstPila);
            }
            else
            {
                MessageBox.Show("No hay Personas en la fila");
            }
        }

        private void frm03Pila_Load(object sender, EventArgs e)
        {
            ControlCajasDeTexto();
            txtCodigo.Select();
            txtCodigo.Focus();
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            ControlCajasDeTexto();
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            ControlCajasDeTexto();
        }

        private void txtTramite_TextChanged(object sender, EventArgs e)
        {
            ControlCajasDeTexto();
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            Char pressedKey = e.KeyChar;
            if (Char.IsDigit(pressedKey) || char.IsControl(pressedKey))
                e.Handled = false;
            else e.Handled = true;
        }
    }
}

