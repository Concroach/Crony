using System.Diagnostics;
using Microsoft.VisualBasic.Devices;
using Timer = System.Windows.Forms.Timer;

namespace Crony
{
    public partial class MainForm : Form
    {
        private readonly PerformanceCounter _cpuCounter;
        private readonly PerformanceCounter _ramCounter;
        private readonly PerformanceCounter _diskCounter;
        private readonly Timer _updateTimer;

        private bool _isWindowOpen;

        private Label _lblCpuUsage;
        private Label _lblRamUsage;
        private Label _lblDiskUsage;
        private readonly HotkeyManager _keyboardHook;

        public MainForm()
        {
            InitializeComponent();

            FormBorderStyle = FormBorderStyle.None;

            this.Paint += (s, e) =>
            {
                int cornerRadius = 20;
                var graphicsPath = new System.Drawing.Drawing2D.GraphicsPath();
                graphicsPath.AddArc(0, 0, cornerRadius, cornerRadius, 180, 90);
                graphicsPath.AddArc(Width - cornerRadius - 1, 0, cornerRadius, cornerRadius, 270, 90);
                graphicsPath.AddArc(Width - cornerRadius - 1, Height - cornerRadius - 1, cornerRadius, cornerRadius, 0, 90);
                graphicsPath.AddArc(0, Height - cornerRadius - 1, cornerRadius, cornerRadius, 90, 90);
                graphicsPath.CloseFigure();

                Region = new Region(graphicsPath);
            };
            
            _cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            _ramCounter = new PerformanceCounter("Memory", "Available MBytes");
            _diskCounter = new PerformanceCounter("LogicalDisk", "% Disk Time", "_Total");

            _updateTimer = new Timer();
            _updateTimer.Interval = 2000; // 2 seconds
            _updateTimer.Tick += UpdateResourceUsage;
            _updateTimer.Start();

            _keyboardHook = new HotkeyManager();
            _keyboardHook.OnHotkeyPressed += OnHotkeyPressed;

            FormBorderStyle = FormBorderStyle.None;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.Manual;
            TopMost = true;

            Location = new Point(
                Screen.PrimaryScreen.WorkingArea.Width - Width * 3 / 2,
                Screen.PrimaryScreen.WorkingArea.Height - Height - 1);

            Deactivate += MainForm_Deactivate;

            UpdateToggleButtonText();
        }

        private void UpdateResourceUsage(object? sender, EventArgs e)
        {
            float cpuUsage = _cpuCounter.NextValue();
            float ramUsage = 100 - ((_ramCounter.NextValue() / GetTotalMemoryInMb()) * 100);
            float diskUsage = _diskCounter.NextValue();

            cpuProgressBar.Value = (int)cpuUsage;
            _lblCpuUsage.Text = $"CPU: {cpuUsage:F1}%";
            UpdateProgressBarColor(cpuProgressBar, cpuUsage);

            ramProgressBar.Value = (int)ramUsage;
            _lblRamUsage.Text = $"RAM: {ramUsage:F1}%";
            UpdateProgressBarColor(ramProgressBar, ramUsage);

            diskProgressBar.Value = (int)diskUsage;
            _lblDiskUsage.Text = $"Disk: {diskUsage:F1}%";
            UpdateProgressBarColor(diskProgressBar, diskUsage);
        }

        private void UpdateProgressBarColor(CircularProgressBar progressBar, float value)
        {
            if (value < 65)
            {
                progressBar.BarColor = Color.ForestGreen;
            }
            else if (value < 90)
            {
                progressBar.BarColor = Color.Orange;
            }
            else
            {
                progressBar.BarColor = Color.Red;
            }
        }

        private static float GetTotalMemoryInMb()
        {
            return new ComputerInfo().TotalPhysicalMemory / (1024 * 1024);
        }

        private void OnHotkeyPressed()
        {
            KeyboardManager.ToggleKeyboard();
            UpdateToggleButtonText();
        }

        private void UpdateToggleButtonText()
        {
            if (KeyboardManager.IsKeyboardEnabled())
            {
                btnToggleKeyboard.Text = "Lock the keyboard";
            }
            else
            {
                btnToggleKeyboard.Text = "Unlock the keyboard";
            }
        }

        private void btnToggleKeyboard_Click(object sender, EventArgs e)
        {
            KeyboardManager.ToggleKeyboard();
            UpdateToggleButtonText();
        }

        public void ToggleWindow()
        {
            if (_isWindowOpen)
            {
                Hide();
                _isWindowOpen = false;
            }
            else
            {
                Show();
                BringToFront();
                Activate();
                _isWindowOpen = true;
            }
        }

        private void MainForm_Deactivate(object? sender, EventArgs e)
        {
            if (_isWindowOpen)
            {
                Hide();
                _isWindowOpen = false;
            }
        }
    }
}
