using System;
using System.Windows.Forms;

namespace Crony
{
    static class Program
    {
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var trayApp = new TrayApplication();
            
            Application.Run();
        }
    }
}