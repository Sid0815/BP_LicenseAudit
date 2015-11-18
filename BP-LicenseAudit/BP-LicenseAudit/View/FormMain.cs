using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BP_LicenseAudit
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            FormCustomer fc = new FormCustomer();
            fc.ShowDialog();

        }

        private void btnNetwork_Click(object sender, EventArgs e)
        {
            FormNetwork fn = new FormNetwork();
            fn.ShowDialog();
        }

        private void btnLicense_Click(object sender, EventArgs e)
        {
            FormLicense fl = new FormLicense();
            fl.ShowDialog();
        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            FormSystemInventory fi = new FormSystemInventory();
            fi.ShowDialog();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            FormChange fc = new FormChange();
            fc.ShowDialog();
        }

        private void btnAudit_Click(object sender, EventArgs e)
        {
            FormAudit fa = new FormAudit();
            fa.ShowDialog();
        }
    }
}
