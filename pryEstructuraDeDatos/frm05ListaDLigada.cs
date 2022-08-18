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
    public partial class frm05ListaDLigada : Form
    {
        public frm05ListaDLigada()
        {
            InitializeComponent();
        }
        ListaDoble FilaDePersonas = new ListaDoble();

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Nodo ObjNodo = new Nodo();
            ObjNodo.Codigo = Convert.ToInt32(txtCodigo.Text);
            ObjNodo.Nombre = txtNombre.Text;
            ObjNodo.Tramite = txtTramite.Text;
            FilaDePersonas.Agregar(ObjNodo);
            FilaDePersonas.Recorrer(cmbEliminar);
            btnEliminar.Enabled = false;
            FilaDePersonas.RecorrerDes(lstListaS);
            FilaDePersonas.Recorrer(dgvListaS);
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtTramite.Text = "";
            txtCodigo.Select();
            txtCodigo.Focus();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (FilaDePersonas.Primero != null)
            {
                int cod = Convert.ToInt32(cmbEliminar.Text);
                FilaDePersonas.Eliminar(cod);
                FilaDePersonas.Recorrer(dgvListaS);
                FilaDePersonas.RecorrerDes(lstListaS);
                FilaDePersonas.Recorrer(cmbEliminar);
                cmbEliminar.Text = "";
                btnEliminar.Enabled = false;
            }
            else
            {
                MessageBox.Show("No hay Personas en la fila");
            }
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

        private void cmbEliminar_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnEliminar.Enabled = true;
        }

        private void frm05ListaDLigada_Load(object sender, EventArgs e)
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

        private void dgvListaS_DoubleClick(object sender, EventArgs e)
        {
            string codigo = dgvListaS.CurrentRow.Cells[0].Value.ToString();
            cmbEliminar.Text = codigo;
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
