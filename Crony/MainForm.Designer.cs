namespace Crony
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private CircularProgressBar cpuProgressBar;
        private CircularProgressBar ramProgressBar;
        private CircularProgressBar diskProgressBar;
        private Button btnToggleKeyboard;

        private readonly int _windowWidth = 400;
        private readonly int _windowHeight = 220;
        
        private readonly int _circleHeight = 80;
        private readonly int _circleWidth = 80;
        private readonly int _progressWidth = 6;

        PictureBox cpuIcon = new PictureBox();
        PictureBox ramIcon = new PictureBox();
        PictureBox diskIcon = new PictureBox();

        private readonly int _btnToggleKeyboardHeight = 40;
        private readonly int _btnToggleKeyboardWidth = 140;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            _lblCpuUsage = new Label();
            _lblRamUsage = new Label();
            _lblDiskUsage = new Label();

            cpuProgressBar = new CircularProgressBar();
            ramProgressBar = new CircularProgressBar();
            diskProgressBar = new CircularProgressBar();

            btnToggleKeyboard = new Button();

            SuspendLayout();

            // CPU Icon
            cpuIcon.Location = new Point(_windowWidth / 4 - _circleWidth / 4 + 3, _windowHeight / 4 - _circleHeight / 4 + 3);
            cpuIcon.Size = new Size(35, 35);
            cpuIcon.SizeMode = PictureBoxSizeMode.StretchImage;
            cpuIcon.Image = Image.FromFile("Resources/cpu.png");
            cpuIcon.BackColor = Color.White;

            // RAM Icon
            ramIcon.Location = new Point(_windowWidth / 2 - _circleWidth / 4 - 3, _windowHeight / 4 - _circleHeight / 4 + 6);
            ramIcon.Size = new Size(48, 28);
            ramIcon.SizeMode = PictureBoxSizeMode.StretchImage;
            ramIcon.Image = Image.FromFile("Resources/ram.png");
            ramIcon.BackColor = Color.White;

            // Disk Icon
            diskIcon.Location = new Point(_windowWidth * 3/4 - _circleWidth / 4 + 2, _windowHeight / 4 - _circleHeight / 4 + 2);
            diskIcon.Size = new Size(37, 37);
            diskIcon.SizeMode = PictureBoxSizeMode.StretchImage;
            diskIcon.Image = Image.FromFile("Resources/disk.png");
            diskIcon.BackColor = Color.White;

            
            // CPU ProgressBar
            cpuProgressBar.Location = new Point(_windowWidth / 4 - _circleWidth / 2, _windowHeight / 4 - _circleHeight / 2);
            cpuProgressBar.Name = "cpuProgressBar";
            cpuProgressBar.Size = new Size(_circleWidth, _circleHeight);
            cpuProgressBar.InternalColor = Color.White;
            cpuProgressBar.BarColor = Color.LightGreen;
            cpuProgressBar.BarWidth = _progressWidth;

            // RAM ProgressBar
            ramProgressBar.Location = new Point(_windowWidth / 2 - _circleWidth / 2, _windowHeight / 4 - _circleHeight / 2);
            ramProgressBar.Name = "ramProgressBar";
            ramProgressBar.Size = new Size(_circleWidth, _circleHeight);
            ramProgressBar.InternalColor = Color.White;
            ramProgressBar.BarColor = Color.LightGreen;
            ramProgressBar.BarWidth = _progressWidth;

            // Disk ProgressBar
            diskProgressBar.Location = new Point(_windowWidth * 3/4 - _circleWidth / 2, _windowHeight / 4 - _circleHeight / 2);
            diskProgressBar.Name = "diskProgressBar";
            diskProgressBar.Size = new Size(_circleWidth, _circleHeight);
            diskProgressBar.InternalColor = Color.White;
            diskProgressBar.BarColor = Color.LightGreen;
            diskProgressBar.BarWidth = _progressWidth;

            
            // CPU Label
            _lblCpuUsage.Location = new Point(_windowWidth / 4 - _circleWidth / 4 - 10, _windowHeight / 4 + 50);
            _lblCpuUsage.Size = new Size(100, 23);
            _lblCpuUsage.Text = "CPU: 0%";

            // RAM Label
            _lblRamUsage.Location = new Point(_windowWidth / 2 - _circleWidth / 4 - 12, _windowHeight / 4 + 50);
            _lblRamUsage.Size = new Size(100, 23);
            _lblRamUsage.Text = "RAM: 0%";

            // Disk Label
            _lblDiskUsage.Location = new Point(_windowWidth * 3/4 - _circleWidth / 4 - 10, _windowHeight / 4 + 50);
            _lblDiskUsage.Size = new Size(100, 23);
            _lblDiskUsage.Text = "Disk: 0%";

            
            // btnToggleKeyboard
            btnToggleKeyboard.Location = new Point(_windowWidth / 2 - _btnToggleKeyboardWidth / 2 , _windowHeight - _btnToggleKeyboardHeight * 3/2 - 8);
            btnToggleKeyboard.Size = new Size(_btnToggleKeyboardWidth, _btnToggleKeyboardHeight);
            btnToggleKeyboard.Text = "Toggle Keyboard";
            btnToggleKeyboard.Click += new System.EventHandler(btnToggleKeyboard_Click);
            btnToggleKeyboard.BackColor = Color.White;

            // MainForm Settings
            ClientSize = new Size(_windowWidth, _windowHeight);

            Controls.Add(cpuIcon);
            Controls.Add(ramIcon);
            Controls.Add(diskIcon);

            Controls.Add(cpuProgressBar);
            Controls.Add(ramProgressBar);
            Controls.Add(diskProgressBar);

            Controls.Add(_lblCpuUsage);
            Controls.Add(_lblRamUsage);
            Controls.Add(_lblDiskUsage);

            Controls.Add(btnToggleKeyboard);

            ResumeLayout(false);
        }
    }
}
