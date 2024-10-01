using System;
using System.Windows.Forms;

namespace Crony
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            // Устанавливаем свойства формы для предотвращения появления иконки в панели задач
            this.FormBorderStyle = FormBorderStyle.None;
            this.ShowInTaskbar = false;
            this.StartPosition = FormStartPosition.Manual;
            this.TopMost = true;

            // Фиксированное положение окна
            this.Location = new System.Drawing.Point(
                Screen.PrimaryScreen.WorkingArea.Width - this.Width - 20, 
                Screen.PrimaryScreen.WorkingArea.Height - this.Height - 20);

            // Установка события на потерю фокуса окна
            this.Deactivate += MainForm_Deactivate;
        }

        private void MainForm_Deactivate(object sender, EventArgs e)
        {
            this.Hide(); // Скрываем окно при потере фокуса
        }

        public void ToggleWindow()
        {
            if (this.Visible)
            {
                this.Hide();
            }
            else
            {
                this.Show();
                this.BringToFront();
            }
        }

        // Обработчик события кнопки ToggleKeyboard
        private void btnToggleKeyboard_Click(object sender, EventArgs e)
        {
            KeyboardManager.ToggleKeyboard();
        }
    }
}
