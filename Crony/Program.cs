using System;
using System.Reflection;
using System.Windows.Forms;

namespace Crony
{
    static class Program
    {

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            TrayApplication.TrayApplication trayApp = new TrayApplication.TrayApplication();

            Application.Run();
        }
    }
}