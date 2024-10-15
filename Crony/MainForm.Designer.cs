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
        
        private readonly int _circleHeight = 64;
        private readonly int _circleWidth = 64;
        private readonly int _progressWidth = 6;

        PictureBox cpuIcon = new PictureBox();
        PictureBox ramIcon = new PictureBox();
        PictureBox diskIcon = new PictureBox();

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
            cpuIcon.Location = new Point(49, 39);
            cpuIcon.Size = new Size(28, 28);
            cpuIcon.SizeMode = PictureBoxSizeMode.StretchImage;
            cpuIcon.Image = Image.FromFile("Resources/cpu.png");
            cpuIcon.BackColor = Color.White;

            // RAM Icon
            ramIcon.Location = new Point(182, 43);
            ramIcon.Size = new Size(41, 20);
            ramIcon.SizeMode = PictureBoxSizeMode.StretchImage;
            ramIcon.Image = Image.FromFile("Resources/ram.png");
            ramIcon.BackColor = Color.White;

            // Disk Icon
            diskIcon.Location = new Point(328, 38);
            diskIcon.Size = new Size(30, 30);
            diskIcon.SizeMode = PictureBoxSizeMode.StretchImage;
            diskIcon.Image = Image.FromFile("Resources/disk.png");
            diskIcon.BackColor = Color.Transparent;

            
            // CPU ProgressBar
            cpuProgressBar.Location = new Point(30, 20);
            cpuProgressBar.Name = "cpuProgressBar";
            cpuProgressBar.Size = new Size(_circleWidth, _circleHeight);
            cpuProgressBar.InternalColor = Color.White;
            cpuProgressBar.BarColor = Color.Green;
            cpuProgressBar.BarWidth = _progressWidth;

            // RAM ProgressBar
            ramProgressBar.Location = new Point(170, 20);
            ramProgressBar.Name = "ramProgressBar";
            ramProgressBar.Size = new Size(_circleWidth, _circleHeight);
            ramProgressBar.InternalColor = Color.White;
            ramProgressBar.BarColor = Color.Green;
            ramProgressBar.BarWidth = _progressWidth;

            // Disk ProgressBar
            diskProgressBar.Location = new Point(310, 20);
            diskProgressBar.Name = "diskProgressBar";
            diskProgressBar.Size = new Size(_circleWidth, _circleHeight);
            diskProgressBar.InternalColor = Color.White;
            diskProgressBar.BarColor = Color.Green;
            diskProgressBar.BarWidth = _progressWidth;

            
            // CPU Label
            _lblCpuUsage.Location = new Point(30, 110);
            _lblCpuUsage.Size = new Size(120, 23);
            _lblCpuUsage.Text = "CPU: 0%";

            // RAM Label
            _lblRamUsage.Location = new Point(170, 110);
            _lblRamUsage.Size = new Size(120, 23);
            _lblRamUsage.Text = "RAM: 0%";

            // Disk Label
            _lblDiskUsage.Location = new Point(310, 110);
            _lblDiskUsage.Size = new Size(120, 23);
            _lblDiskUsage.Text = "Disk: 0%";

            
            // btnToggleKeyboard
            btnToggleKeyboard.Location = new Point(150, 165);
            btnToggleKeyboard.Size = new Size(100, 40);
            btnToggleKeyboard.Text = "Toggle Keyboard";
            btnToggleKeyboard.Click += new System.EventHandler(btnToggleKeyboard_Click);

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
