using BP_LicenseAudit.Controller;
using BP_LicenseAudit.View;
using System;
using System.Windows.Forms;

namespace BP_LicenseAudit
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Initialize Main Form Forms
            Form FMain = new FormMain();
            FMain.Visible = false;

            //Initialize Controller
            ControllerMain CMain = new ControllerMain(FMain);

            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new FormMain());
            FMain.ShowDialog();
        }

    }
}
