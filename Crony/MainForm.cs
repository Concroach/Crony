using System;
using System.Windows.Forms;

namespace Crony
{
    public partial class MainForm : Form
    {
        private bool isWindowOpen = false; // Флаг состояния окна

        private GlobalHotKey globalHotKey; // Переменная для глобальной горячей клавиши

        public MainForm()
        {
            InitializeComponent();

            // Регистрация горячей клавиши Ctrl + Shift + K
            globalHotKey = new GlobalHotKey((int)GlobalHotKey.KeyModifiers.Ctrl | (int)GlobalHotKey.KeyModifiers.Shift, Keys.K, this);

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

            // Устанавливаем начальное состояние кнопки
            UpdateToggleButtonText();
        }

        // Метод для открытия/закрытия окна
        public void ToggleWindow()
        {
            if (isWindowOpen)
            {
                this.Hide();  // Скрываем окно, если оно было открыто
                isWindowOpen = false;  // Обновляем флаг
            }
            else
            {
                this.Show();  // Показываем окно, если оно было скрыто
                this.BringToFront();  // Делаем окно на переднем плане
                this.Activate();  // Программно активируем окно
                isWindowOpen = true;  // Обновляем флаг
            }
        }

        // Метод для обработки сообщений Windows (для горячей клавиши)
        protected override void WndProc(ref Message m)
        {
            const int WM_HOTKEY = 0x0312;
            if (m.Msg == WM_HOTKEY)
            {
                // Если горячая клавиша сработала, меняем состояние клавиатуры
                KeyboardManager.ToggleKeyboard();
                UpdateToggleButtonText();  // Обновляем текст на кнопке
            }
            base.WndProc(ref m);
        }

        // Обработчик для сворачивания окна при потере фокуса
        private void MainForm_Deactivate(object sender, EventArgs e)
        {
            this.Hide(); // Скрываем окно при потере фокуса
            isWindowOpen = false;  // Обновляем флаг
        }

        // Метод для изменения текста на кнопке в зависимости от состояния клавиатуры
        private void UpdateToggleButtonText()
        {
            if (KeyboardManager.IsKeyboardEnabled())
            {
                btnToggleKeyboard.Text = "Выключить клавиатуру";
            }
            else
            {
                btnToggleKeyboard.Text = "Включить клавиатуру";
            }
        }

        // Обработчик события кнопки ToggleKeyboard
        private void btnToggleKeyboard_Click(object sender, EventArgs e)
        {
            // Переключаем состояние клавиатуры
            KeyboardManager.ToggleKeyboard();

            // Обновляем текст на кнопке после изменения состояния клавиатуры
            UpdateToggleButtonText();
        }

        // Метод для освобождения ресурсов (отписка от горячих клавиш)
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            globalHotKey?.Dispose(); // Отписываемся от горячей клавиши
            base.OnFormClosing(e);
        }
    }
}
