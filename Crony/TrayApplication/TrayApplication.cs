using System;
using System.Windows.Forms;

namespace Crony
{
    class TrayApplication
    {
        private NotifyIcon trayIcon;
        private MainForm mainForm;

        public TrayApplication()
        {
            mainForm = new MainForm();

            trayIcon = new NotifyIcon()
            {
                Icon = new System.Drawing.Icon("resources/icon.ico"), // Укажи путь к своей иконке
                Visible = true,
                Text = "Tray App"
            };

            trayIcon.Click += TrayIcon_Click;
        }

        private void TrayIcon_Click(object sender, EventArgs e)
        {
            mainForm.ToggleWindow(); // Открытие/закрытие окна
        }
    }
}