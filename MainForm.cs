using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Crony
{
    public partial class MainForm : Form
    {
        private Label lblCpuUsage;
        private Label lblRamUsage;
        private Label lblGpuUsage;
        private Label lblSessionTime;
        private Button btnToggleKeyboard;
        private bool isKeyboardDisabled = false;
        
        // Импорт функции для блокировки клавиатуры
        [DllImport("user32.dll")]
        public static extern int BlockInput(bool fBlockIt);

        public MainForm()
        {
            InitializeComponent();

            // Настройка формы
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.Manual;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowInTaskbar = false;
            this.Size = new Size(300, 200);

            // Создание меток для отображения загруженности и времени
            lblCpuUsage = new Label() { Text = "CPU: 0%", Location = new Point(10, 10), AutoSize = true };
            lblRamUsage = new Label() { Text = "RAM: 0%", Location = new Point(10, 30), AutoSize = true };
            lblGpuUsage = new Label() { Text = "GPU: 0%", Location = new Point(10, 50), AutoSize = true };
            lblSessionTime = new Label() { Text = "Время за ПК: 0 мин", Location = new Point(10, 70), AutoSize = true };

            // Кнопка для отключения/включения клавиатуры
            btnToggleKeyboard = new Button()
            {
                Text = "Отключить клавиатуру",
                Location = new Point(10, 100),
                AutoSize = true
            };
            btnToggleKeyboard.Click += BtnToggleKeyboard_Click;

            // Добавляем элементы на форму
            this.Controls.Add(lblCpuUsage);
            this.Controls.Add(lblRamUsage);
            this.Controls.Add(lblGpuUsage);
            this.Controls.Add(lblSessionTime);
            this.Controls.Add(btnToggleKeyboard);
        }

        // Обработка нажатия на кнопку включения/отключения клавиатуры
        private void BtnToggleKeyboard_Click(object sender, EventArgs e)
        {
            if (isKeyboardDisabled)
            {
                // Включение клавиатуры
                BlockInput(false);  // Разблокируем клавиатуру
                btnToggleKeyboard.Text = "Отключить клавиатуру";
                isKeyboardDisabled = false;
            }
            else
            {
                // Отключение клавиатуры
                BlockInput(true);  // Блокируем клавиатуру
                btnToggleKeyboard.Text = "Включить клавиатуру";
                isKeyboardDisabled = true;
            }
        }

        // Метод для позиционирования формы над иконкой трея
        public void SetPositionAboveTray(Point trayIconPosition)
        {
            int formWidth = this.Width;
            int formHeight = this.Height;

            // Устанавливаем форму над иконкой трея
            this.Location = new Point(trayIconPosition.X - formWidth / 2, trayIconPosition.Y - formHeight);
        }
    }
}
