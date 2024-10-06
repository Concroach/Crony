using System;
using System.Windows.Forms;

namespace Crony
{
    public partial class MainForm : Form
    {
        private bool isWindowOpen = false; // Флаг состояния окна
        private KeyboardHook _keyboardHook;

        public MainForm()
        {
            InitializeComponent();

            // Инициализация перехвата клавиатуры
            _keyboardHook = new KeyboardHook();
            _keyboardHook.OnHotkeyPressed += OnHotkeyPressed;

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

            // Устанавливаем начальное состояние кнопки
            UpdateToggleButtonText();
        }

        // Метод, который вызывается при нажатии горячей клавиши (Shift+Shift)
        private void OnHotkeyPressed()
        {
            // Переключаем состояние клавиатуры
            KeyboardManager.ToggleKeyboard();

            // Обновляем текст на кнопке после изменения состояния клавиатуры
            UpdateToggleButtonText();
        }

        // Метод для обновления текста на кнопке в зависимости от состояния клавиатуры
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

        // Метод для открытия и закрытия окна
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

        // Обработчик для сворачивания окна при потере фокуса
        private void MainForm_Deactivate(object sender, EventArgs e)
        {
            if (isWindowOpen)
            {
                this.Hide();  // Скрываем окно при потере фокуса
                isWindowOpen = false;  // Обновляем флаг
            }
        }
    }
}