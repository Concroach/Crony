using System;
using System.Windows.Forms;

namespace Crony
{
    public partial class MainForm : Form
    {
        private bool isKeyboardDisabled = false;

        public MainForm()
        {
            InitializeComponent();

            // Фиксируем окно: нельзя передвигать, масштабировать, оно поверх других
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.Manual;
            this.TopMost = true;
            this.ShowInTaskbar = false;
            this.Size = new System.Drawing.Size(300, 200); // Компактный размер окна
            this.MouseClick += (sender, e) => { if (!this.Bounds.Contains(Cursor.Position)) this.Hide(); };
        }

        public void ToggleWindow()
        {
            if (this.Visible)
            {
                this.Hide();
            }
            else
            {
                // Позиционирование окна над треем
                var screen = Screen.FromControl(this);
                this.Location = new System.Drawing.Point(screen.Bounds.Width - this.Width, screen.Bounds.Height - this.Height - 40);
                this.Show();
                this.Activate();
            }
        }

        private void BtnToggleKeyboard_Click(object sender, EventArgs e)
        {
            if (isKeyboardDisabled)
            {
                EnableKeyboard();
                btnToggleKeyboard.Text = "Disable Keyboard";
                isKeyboardDisabled = false;
            }
            else
            {
                DisableKeyboard();
                btnToggleKeyboard.Text = "Enable Keyboard";
                isKeyboardDisabled = true;
            }
        }

        private void DisableKeyboard()
        {
            // Отключение клавиатуры
            KeyboardManager.ToggleKeyboard();
        }

        private void EnableKeyboard()
        {
            // Включение клавиатуры
            KeyboardManager.ToggleKeyboard();
        }
    }
}
