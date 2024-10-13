using System;
using System.Windows.Forms;

namespace Crony
{
    public partial class MainForm : Form
    {
        private bool _isWindowOpen = false;
        private readonly HotkeyManager _keyboardHook;

        public MainForm()
        {
            InitializeComponent();

            _keyboardHook = new HotkeyManager();
            _keyboardHook.OnHotkeyPressed += OnHotkeyPressed;

            this.FormBorderStyle = FormBorderStyle.None;
            this.ShowInTaskbar = false;
            this.StartPosition = FormStartPosition.Manual;
            this.TopMost = true;

            this.Location = new System.Drawing.Point(
                Screen.PrimaryScreen.WorkingArea.Width - this.Width * 3 / 2,
                Screen.PrimaryScreen.WorkingArea.Height - this.Height - 1);

            this.Deactivate += MainForm_Deactivate;

            UpdateToggleButtonText();
        }

        private void OnHotkeyPressed()
        {
            KeyboardManager.KeyboardManager.ToggleKeyboard();

            UpdateToggleButtonText();
        }

        private void UpdateToggleButtonText()
        {
            if (KeyboardManager.KeyboardManager.IsKeyboardEnabled())
            {
                btnToggleKeyboard.Text = "Выключить клавиатуру";
            }
            else
            {
                btnToggleKeyboard.Text = "Включить клавиатуру";
            }
        }

        private void btnToggleKeyboard_Click(object sender, EventArgs e)
        {
            KeyboardManager.KeyboardManager.ToggleKeyboard();

            UpdateToggleButtonText();
        }

        public void ToggleWindow()
        {
            if (_isWindowOpen)
            {
                this.Hide();
                _isWindowOpen = false;
            }
            else
            {
                this.Show();
                this.BringToFront();
                this.Activate();
                _isWindowOpen = true;
            }
        }

        private void MainForm_Deactivate(object sender, EventArgs e)
        {
            if (_isWindowOpen)
            {
                this.Hide();
                _isWindowOpen = false;
            }
        }
    }
}