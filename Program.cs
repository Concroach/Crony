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

            // Создаем экземпляр приложения с треем
            TrayApplication trayApp = new TrayApplication();
            
            // Ожидание работы приложения
            Application.Run(); // Просто ждем событий от системы
        }
    }
}
