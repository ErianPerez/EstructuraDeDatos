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
    public partial class frm00Principal : Form
    {
        public frm00Principal()
        {
            InitializeComponent();
        }

        private void linealesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void noLinealesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void grafoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void acercaDeEsteProyectoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm01AcercaDe ventana = new frm01AcercaDe();
            ventana.ShowDialog();

        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void colaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm02Cola ventana = new frm02Cola();
            ventana.ShowDialog();
        }

        private void pilaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm03Pila ventana = new frm03Pila();
            ventana.ShowDialog();
        }

        private void listaSimpleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm04ListaSimple ventana = new frm04ListaSimple();
            ventana.ShowDialog();
        }

        private void listaDobleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm05ListaDLigada ventana = new frm05ListaDLigada();
            ventana.ShowDialog();
        }

        private void árbolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm06ArbolBinario ventana = new frm06ArbolBinario();
            ventana.ShowDialog();
        }
    }
}
