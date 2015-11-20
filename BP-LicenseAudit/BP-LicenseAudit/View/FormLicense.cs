using System;
using System.Windows.Forms;

namespace BP_LicenseAudit.View
{
    public partial class FormLicense : FormParent
    {
        public FormLicense()
        {
            InitializeComponent();
        }

        private void FormLicense_Load(object sender, EventArgs e)
        {

        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
