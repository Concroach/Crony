using System;
using System.Drawing;
using System.Windows.Forms;

namespace Crony.TrayApplication
{
    class TrayApplication
    {
        private static NotifyIcon _trayIcon;
        private MainForm _mainForm;
        
        private static ContextMenuStrip _trayMenu;

        public TrayApplication()
        {
            _mainForm = new MainForm();
            _trayMenu = new ContextMenuStrip();

            
            ToolStripMenuItem checkUpdatesItem = new ToolStripMenuItem("Update");
            checkUpdatesItem.Click += CheckUpdates_Click;
            _trayMenu.Items.Add(checkUpdatesItem);

            ToolStripMenuItem exitItem = new ToolStripMenuItem("Exit");
            exitItem.Click += Exit_Click;
            _trayMenu.Items.Add(exitItem);

            _trayIcon = new NotifyIcon()
            {
                Icon = new Icon("resources/icon.ico"),
                ContextMenuStrip = _trayMenu,
                Visible = true,
                Text = "Crony Tray App"
            };

            _trayIcon.MouseClick += TrayIcon_MouseClick;
        }

        private void TrayIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _mainForm.ToggleWindow();
            }
            else if (e.Button == MouseButtons.Right)
            {
                ShowTrayMenuAboveIcon();
            }
        }

        private void ShowTrayMenuAboveIcon()
        {
            var workingArea = Screen.PrimaryScreen.WorkingArea;
            int x = Cursor.Position.X;
            int y = workingArea.Bottom - _trayMenu.Size.Height;
            _trayMenu.Show(x, y);
        }

        private static void CheckUpdates_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Stable version");
        }
        
        private static void Exit_Click(object sender, EventArgs e)
        {
            _trayIcon.Visible = false;
            Application.Exit();
        }
    }
    
}
