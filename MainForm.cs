using System;
using System.Windows.Forms;

namespace Crony
{
    public partial class MainForm : Form
    {
        private bool isWindowOpen = false; // Флаг состояния окна

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

        // Метод для открытия и закрытия окна
        public void ToggleWindow()
        {
            if (isWindowOpen)
            {
                Console.WriteLine(2);
                this.Hide();  // Скрываем окно, если оно было открыто
                isWindowOpen = false;  // Обновляем флаг
            }
            else
            {
                Console.WriteLine(1);
                this.Show();  // Показываем окно, если оно было скрыто
                this.BringToFront();  // Делаем окно на переднем плане
                this.Activate();  // Программно активируем окно
                isWindowOpen = true;  // Обновляем флаг
            }
        }

        // Обработчик для сворачивания окна при потере фокуса
        private void MainForm_Deactivate(object sender, EventArgs e)
        {
            if (isWindowOpen)
            {
                this.Hide();  // Скрываем окно при потере фокуса
                isWindowOpen = false;  // Обновляем флаг
            }
        }

        // Обработчик события кнопки ToggleKeyboard
        
    }
}
