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
    public partial class frm01AcercaDe : Form
    {
        public frm01AcercaDe()
        {
            InitializeComponent();
        }
        public static void GoToSite(string url)
        {
            System.Diagnostics.Process.Start(url);
        }
        private void btnContacto_Click(object sender, EventArgs e)
        {
            GoToSite("https://api.whatsapp.com/send/?phone=5493512436583");
            
        }

        private void btnContactoLI_Click(object sender, EventArgs e)
        {
            GoToSite("https://www.linkedin.com/in/erian-perez-messa");
        }
    }
}
