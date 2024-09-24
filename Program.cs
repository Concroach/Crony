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

            // Создаем иконку в трее и запускаем без окна
            TrayApplication trayApp = new TrayApplication();
            
            // Запускаем приложение без открытия формы
            Application.Run();
        }
    }
}