namespace Crony
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private CircularProgressBar.CircularProgressBar cpuProgressBar;
        private CircularProgressBar.CircularProgressBar ramProgressBar;
        private CircularProgressBar.CircularProgressBar diskProgressBar;
        private Button btnToggleKeyboard;
        
        private readonly int _circleHeight = 64;
        private readonly int _circleWidth = 64;
        private readonly int _progressWidth = 6;

        PictureBox cpuIcon = new System.Windows.Forms.PictureBox();
        PictureBox ramIcon = new System.Windows.Forms.PictureBox();
        PictureBox diskIcon = new System.Windows.Forms.PictureBox();

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
            this._lblCpuUsage = new System.Windows.Forms.Label();
            this._lblRamUsage = new System.Windows.Forms.Label();
            this._lblDiskUsage = new System.Windows.Forms.Label();
            
            this.cpuProgressBar = new CircularProgressBar.CircularProgressBar();
            this.ramProgressBar = new CircularProgressBar.CircularProgressBar();
            this.diskProgressBar = new CircularProgressBar.CircularProgressBar();
            
            this.btnToggleKeyboard = new System.Windows.Forms.Button();
            
            this.SuspendLayout();
        
            // CPU Icon
            cpuIcon.Location = new System.Drawing.Point(49, 39);
            cpuIcon.Size = new System.Drawing.Size(28, 28);
            cpuIcon.SizeMode = PictureBoxSizeMode.StretchImage;
            cpuIcon.Image = System.Drawing.Image.FromFile("Resources/cpu.png");
            cpuIcon.BackColor = Color.White;
        
            // RAM Icon
            ramIcon.Location = new System.Drawing.Point(182, 43);
            ramIcon.Size = new System.Drawing.Size(41, 20);
            ramIcon.SizeMode = PictureBoxSizeMode.StretchImage;
            ramIcon.Image = System.Drawing.Image.FromFile("Resources/ram.png");
            ramIcon.BackColor = Color.White;
        
            // Disk Icon
            diskIcon.Location = new System.Drawing.Point(328, 38);
            diskIcon.Size = new System.Drawing.Size(30, 30);
            diskIcon.SizeMode = PictureBoxSizeMode.StretchImage;
            diskIcon.Image = System.Drawing.Image.FromFile("Resources/disk.png");
            diskIcon.BackColor = Color.Transparent;
        
            // CPU ProgressBar
            this.cpuProgressBar.Location = new System.Drawing.Point(30, 20);
            this.cpuProgressBar.Name = "cpuProgressBar";
            this.cpuProgressBar.Size = new System.Drawing.Size(_circleWidth, _circleHeight);
            cpuProgressBar.InnerColor = Color.White;
            this.cpuProgressBar.ProgressColor = System.Drawing.Color.Green;
            this.cpuProgressBar.ProgressWidth = _progressWidth;
            this.cpuProgressBar.InnerWidth = -1;
        
            // RAM ProgressBar
            this.ramProgressBar.Location = new System.Drawing.Point(170, 20);
            this.ramProgressBar.Name = "ramProgressBar";
            this.ramProgressBar.Size = new System.Drawing.Size(_circleWidth, _circleHeight);
            ramProgressBar.InnerColor = Color.White;
            this.ramProgressBar.ProgressColor = System.Drawing.Color.Green;
            this.ramProgressBar.ProgressWidth = _progressWidth;
            this.ramProgressBar.InnerWidth = -1;
        
            // Disk ProgressBar
            this.diskProgressBar.Location = new System.Drawing.Point(310, 20);
            this.diskProgressBar.Name = "diskProgressBar";
            this.diskProgressBar.Size = new System.Drawing.Size(_circleWidth, _circleHeight);
            diskProgressBar.InnerColor = Color.White;
            this.diskProgressBar.ProgressColor = System.Drawing.Color.Green;
            this.diskProgressBar.ProgressWidth = _progressWidth;
            this.diskProgressBar.InnerWidth = -1;
        
            // CPU Label
            this._lblCpuUsage.Location = new System.Drawing.Point(30, 110);
            this._lblCpuUsage.Size = new System.Drawing.Size(120, 23);
            this._lblCpuUsage.Text = "CPU: 0%";
        
            // RAM Label
            this._lblRamUsage.Location = new System.Drawing.Point(170, 110);
            this._lblRamUsage.Size = new System.Drawing.Size(120, 23);
            this._lblRamUsage.Text = "RAM: 0%";
        
            // Disk Label
            this._lblDiskUsage.Location = new System.Drawing.Point(310, 110);
            this._lblDiskUsage.Size = new System.Drawing.Size(120, 23);
            this._lblDiskUsage.Text = "Disk: 0%";
        
            // btnToggleKeyboard
            this.btnToggleKeyboard.Location = new System.Drawing.Point(150, 165);
            this.btnToggleKeyboard.Size = new System.Drawing.Size(100, 40);
            this.btnToggleKeyboard.Text = "Toggle Keyboard";
            this.btnToggleKeyboard.Click += new System.EventHandler(this.btnToggleKeyboard_Click);
        
            // MainForm Settings
            this.ClientSize = new System.Drawing.Size(400, 220);
            
            this.Controls.Add(this.cpuIcon);
            this.Controls.Add(this.ramIcon);
            this.Controls.Add(this.diskIcon);
            
            this.Controls.Add(this.cpuProgressBar);
            this.Controls.Add(this.ramProgressBar);
            this.Controls.Add(this.diskProgressBar);
            
            this.Controls.Add(this._lblCpuUsage);
            this.Controls.Add(this._lblRamUsage);
            this.Controls.Add(this._lblDiskUsage);
            
            this.Controls.Add(this.btnToggleKeyboard);
            
            this.ResumeLayout(false);
       }
    }
}
