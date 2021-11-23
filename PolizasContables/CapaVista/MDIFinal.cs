using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaVista
{
    public partial class MDIFinal : Form
    {
        public MDIFinal()
        {
            InitializeComponent();
        }

        private void mantenimientoCuentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCuentas form3 = new frmCuentas();
            form3.MdiParent = this;
            form3.Show();
        }

        private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void polizasContablesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPolizaContable form3 = new frmPolizaContable();
            form3.MdiParent = this;
            form3.Show();
        }
    }
}
