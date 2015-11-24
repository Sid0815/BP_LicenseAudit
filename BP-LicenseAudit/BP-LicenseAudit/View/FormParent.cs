using BP_LicenseAudit.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BP_LicenseAudit.View
{
    public partial class FormParent : Form
    {

        public FormParent()
        {
            InitializeComponent();
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void SetAllCustomersToCmbCustomer()
        {

        }

        public void SetCustomer()
        {

        }

        public void GetCustomer()
        {

        }

        private void FormParent_Load(object sender, EventArgs e)
        {

        }

        public void AddCustomer(string customer)
        {
            cmbCustomer.Items.Add(customer);
        }
    }
}
