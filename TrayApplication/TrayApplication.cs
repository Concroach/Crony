using System;
using System.Drawing;
using System.Windows.Forms;

namespace Crony
{
    public class TrayApplication
    {
        private NotifyIcon trayIcon;
        private MainForm mainForm;

        public TrayApplication()
        {
            // Создаем значок трея
            trayIcon = new NotifyIcon
            {
                Icon = SystemIcons.Application, // Устанавливаем стандартную иконку
                Visible = true
            };

            trayIcon.MouseClick += TrayIcon_MouseClick;

            // Инициализируем главную форму
            mainForm = new MainForm();
            mainForm.ShowInTaskbar = false;  // Скрываем иконку в панели задач
        }

        // Обработка клика по значку трея
        private void TrayIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                // Показываем форму только при клике левой кнопкой мыши
                if (!mainForm.Visible)
                {
                    Point trayIconPosition = Cursor.Position;
                    mainForm.SetPositionAboveTray(trayIconPosition);
                    mainForm.Show();
                    mainForm.Activate(); // Активируем форму
                }
                else
                {
                    mainForm.Hide(); // Если форма уже открыта, скрываем её при повторном клике
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                // Контекстное меню при правом клике
                ContextMenuStrip contextMenu = new ContextMenuStrip();
                contextMenu.Items.Add("Закрыть", null, (s, args) => Application.Exit());
                contextMenu.Show(Cursor.Position);
            }
        }
    }
}