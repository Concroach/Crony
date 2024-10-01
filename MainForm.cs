using System;
using System.Windows.Forms;

namespace Crony
{
    public partial class MainForm : Form
    {
        private bool isKeyboardEnabled = true;

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
                Screen.PrimaryScreen.WorkingArea.Width - this.Width * 3 / 2, 
                Screen.PrimaryScreen.WorkingArea.Height - this.Height - 1);

            // Установка события на потерю фокуса окна
            this.Deactivate += MainForm_Deactivate;

            // Обновление текста кнопки при инициализации
            UpdateButtonLabel();
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
            ToggleKeyboard();
        }

        private void ToggleKeyboard()
        {
            // Включение или отключение клавиатуры
            if (isKeyboardEnabled)
            {
                KeyboardManager.ToggleKeyboard(); // Отключение
                isKeyboardEnabled = false;
            }
            else
            {
                KeyboardManager.ToggleKeyboard(); // Включение
                isKeyboardEnabled = true;
            }

            // Обновление текста на кнопке
            UpdateButtonLabel();
        }

        private void UpdateButtonLabel()
        {
            btnToggleKeyboard.Text = isKeyboardEnabled ? "Выключить клавиатуру" : "Включить клавиатуру";
        }
    }
}
