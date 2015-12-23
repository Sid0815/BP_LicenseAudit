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
    public partial class FormProgress : Form
    {
        public FormProgress()
        {
            InitializeComponent();
        }

        public void SetMax(int max)
        {
            this.progressBar1.Maximum = max;
        }

        public void Progress()
        {
            this.progressBar1.PerformStep();
        }
    }
}
