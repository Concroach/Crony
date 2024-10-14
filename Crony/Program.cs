using System;
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

            TrayApplication trayApp = new TrayApplication();
            Application.Run();
        }
    }
}