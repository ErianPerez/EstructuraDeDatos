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
    public partial class frm06ArbolBinario : Form
    {
        public frm06ArbolBinario()
        {
            InitializeComponent();
        }

        ArbolBinario ObjArbol = new ArbolBinario();

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            dgvArbol.Rows.Clear();
            Nodo Persona = new Nodo();
            Persona.Codigo = Convert.ToInt32(txtCodigo.Text);
            Persona.Nombre = txtNombre.Text;
            Persona.Tramite = txtTramite.Text;

            ObjArbol.Agregar(Persona);
            Listar();
            ControlOptsYChk();
            ObjArbol.Recorrer(cmbEliminar);
            ObjArbol.Recorrer(lst1);
            ObjArbol.RecorrerDes(lst2);
            ObjArbol.RecorrerPre(lst3);
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtTramite.Text = "";
            txtCodigo.Select();
            txtCodigo.Focus();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (cmbEliminar.Text != "")
            {
                dgvArbol.Rows.Clear();
                lst1.Items.Clear();
                lst2.Items.Clear();
                lst3.Items.Clear();
                int cod = Convert.ToInt32(cmbEliminar.Text);
                cmbEliminar.Items.Clear();
                ObjArbol.Eliminar(cod);
                Listar();
                ControlOptsYChk();
                ObjArbol.Recorrer(cmbEliminar);
                ObjArbol.Recorrer(lst1);
                ObjArbol.RecorrerDes(lst2);
                ObjArbol.RecorrerPre(lst3);
                dgvArbol.CurrentCell = null;
                cmbEliminar.Text = "";
                btnEliminar.Enabled = false;
                btnBuscar.Enabled = false;
            }
            else
            {
                MessageBox.Show("No hay Personas en la fila");
            }
        }
        private void Listar()
        {
            dgvArbol.Rows.Clear();
            if (chkDesc.Checked == true)
            {
                if (optInOrden.Checked == true)
                {
                    ObjArbol.RecorrerDes(dgvArbol, 1);
                }
                if (optPostOrden.Checked == true)
                {
                    ObjArbol.RecorrerDes(dgvArbol, 3);
                }
                if (optPreOrden.Checked == true)
                {
                    ObjArbol.RecorrerDes(dgvArbol, 2);
                }
            }
            if (chkDesc.Checked == false)
            {
                if (optInOrden.Checked == true)
                {
                    ObjArbol.Recorrer(dgvArbol, 1);
                }
                if (optPostOrden.Checked == true)
                {
                    ObjArbol.Recorrer(dgvArbol, 3);
                }
                if (optPreOrden.Checked == true)
                {
                    ObjArbol.Recorrer(dgvArbol, 2);
                }

            }
        }
        private void ControlOptsYChk()
        {
            if (ObjArbol.Raiz != null)
            {
                optInOrden.Enabled = true; optPreOrden.Enabled = true; optPostOrden.Enabled = true;
                chkDesc.Enabled = true;
            }
            else
            {
                optInOrden.Enabled = false; optPreOrden.Enabled = false; optPostOrden.Enabled = false;
                chkDesc.Enabled = false;
            }
        }

        private void btnEquilibrar_Click(object sender, EventArgs e)
        {
            ObjArbol.Equilibrar();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cmbEliminar.Text != "")
            {
                int codi = Convert.ToInt32(cmbEliminar.Text);
                foreach (DataGridViewRow row in dgvArbol.Rows)
                {
                    if (Convert.ToInt32(row.Cells["Codigo"].Value) == codi)
                    {
                        codi = row.Index;
                        //dgvArbol.Rows[codi].Selected = true;
                        dgvArbol.CurrentCell = dgvArbol.Rows[codi].Cells[0];
                        //TESTEO DEL IF
                        //MessageBox.Show(row.Cells["Codigo"].Value.ToString());
                        //MessageBox.Show(row.Cells["Nombre"].Value.ToString());
                        //MessageBox.Show(row.Cells["Tramite"].Value.ToString());
                    }

                }
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

        private void frm06ArbolBinario_Load(object sender, EventArgs e)
        {
            txtCodigo.Select();
            txtCodigo.Focus();
            ControlCajasDeTexto();
            btnEliminar.Enabled = false;
            btnBuscar.Enabled = false;
            optInOrden.Checked = true;
        }

        private void cmbEliminar_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnEliminar.Enabled = true;
            btnBuscar.Enabled = true;
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            Char pressedKey = e.KeyChar;
            if (Char.IsDigit(pressedKey) || char.IsControl(pressedKey))
                e.Handled = false;
            else e.Handled = true;
        }

        private void dgvArbol_DoubleClick(object sender, EventArgs e)
        {

            string codigo = dgvArbol.CurrentRow.Cells[0].Value.ToString();
            cmbEliminar.Text = codigo;
            dgvArbol.CurrentCell = null;
        }

        private void optInOrden_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDesc.Checked == true)
            {
                dgvArbol.Rows.Clear();
                ObjArbol.RecorrerDes(dgvArbol, 1);
            }
            else
            {
                dgvArbol.Rows.Clear();
                ObjArbol.Recorrer(dgvArbol, 1);
            }
            
        }

        private void optPreOrden_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDesc.Checked == true)
            {
                dgvArbol.Rows.Clear();
                ObjArbol.RecorrerDes(dgvArbol, 2);
            }
            else
            {
                dgvArbol.Rows.Clear();
                ObjArbol.Recorrer(dgvArbol, 2);
            }
        }

        private void optPostOrden_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDesc.Checked == true)
            {
                dgvArbol.Rows.Clear();
                ObjArbol.RecorrerDes(dgvArbol, 3);
            }
            else
            {
                dgvArbol.Rows.Clear();
                ObjArbol.Recorrer(dgvArbol, 3);
            }
        }

        private void chkDesc_CheckedChanged(object sender, EventArgs e)
        {
            Listar();
        }

        private void cmbEliminar_KeyPress(object sender, KeyPressEventArgs e)
        {
            Char pressedKey = e.KeyChar;
            if (Char.IsDigit(pressedKey) || char.IsControl(pressedKey))
                e.Handled = false;
            else e.Handled = true;
        }
    }
}
