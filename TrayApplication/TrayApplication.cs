using System;
using System.Windows.Forms;

namespace Crony
{
    public class TrayApplication
    {
        private NotifyIcon trayIcon;
        private MainForm mainForm;

        public TrayApplication()
        {
            // Создаем иконку для трея
            trayIcon = new NotifyIcon();
            trayIcon.Text = "Tray App";
            trayIcon.Icon = new Icon("Resources/icon.ico"); // Можно заменить на свою иконку, если нужно

            // Контекстное меню при правом клике
            var contextMenu = new ContextMenuStrip();
            var exitMenuItem = new ToolStripMenuItem("Exit", null, OnExit);
            contextMenu.Items.Add(exitMenuItem);

            trayIcon.ContextMenuStrip = contextMenu;
            trayIcon.Visible = true;

            // Обработчик кликов по иконке
            trayIcon.MouseClick += TrayIcon_MouseClick;

            // Создаем основное окно
            mainForm = new MainForm();
        }

        private void TrayIcon_MouseClick(object sender, MouseEventArgs e)
        {
            // ЛКМ - открытие/закрытие окна
            if (e.Button == MouseButtons.Left)
            {
                mainForm.ToggleWindow(); // Переключение отображения окна
            }
        }

        private void OnExit(object sender, EventArgs e)
        {
            trayIcon.Visible = false;
            Application.Exit();
        }
    }
}