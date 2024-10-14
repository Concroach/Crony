using System;
using System.Windows.Forms;

namespace Crony
{
    class TrayApplication
    {
        private NotifyIcon _trayIcon;
        private MainForm _mainForm;

        public TrayApplication()
        {
            _mainForm = new MainForm();

            _trayIcon = new NotifyIcon()
            {
                Icon = new System.Drawing.Icon("resources/icon.ico"),
                Visible = true,
                Text = "Crony Tray App"
            };

            _trayIcon.Click += TrayIcon_Click;
        }

        private void TrayIcon_Click(object sender, EventArgs e)
        {
            _mainForm.ToggleWindow();
        }
    }
}