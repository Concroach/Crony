using System;
using System.Diagnostics;
using System.Windows.Forms;
using CircularProgressBar;
using Timer = System.Windows.Forms.Timer;

namespace Crony
{
    public partial class MainForm : Form
    {
        private readonly PerformanceCounter _cpuCounter;
        private readonly PerformanceCounter _ramCounter;
        private readonly PerformanceCounter _diskCounter;
        private readonly Timer _updateTimer;
        
        private float _previousCpuUsage;
        private float _previousRamUsage;
        
        private bool _isWindowOpen = false;

        private Label _lblCpuUsage;
        private Label _lblRamUsage;
        private Label _lblDiskUsage;
        private readonly HotkeyManager _keyboardHook;

        public MainForm()
        {
            InitializeComponent();
            
            _cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            _ramCounter = new PerformanceCounter("Memory", "Available MBytes");
            _diskCounter = new PerformanceCounter("LogicalDisk", "% Disk Time", "_Total");

            _updateTimer = new Timer();
            _updateTimer.Interval = 1000; // Секунда
            _updateTimer.Tick += UpdateResourceUsage;
            _updateTimer.Start();
            
            _keyboardHook = new HotkeyManager();
            _keyboardHook.OnHotkeyPressed += OnHotkeyPressed;

            this.FormBorderStyle = FormBorderStyle.None;
            this.ShowInTaskbar = false;
            this.StartPosition = FormStartPosition.Manual;
            this.TopMost = true;

            this.Location = new System.Drawing.Point(
                Screen.PrimaryScreen.WorkingArea.Width - this.Width * 3 / 2,
                Screen.PrimaryScreen.WorkingArea.Height - this.Height - 1);

            this.Deactivate += MainForm_Deactivate;

            UpdateToggleButtonText();
        }

        private void UpdateResourceUsage(object sender, EventArgs e)
        {
            float cpuUsage = _cpuCounter.NextValue();
            float ramUsage = 100 - ((_ramCounter.NextValue() / (float)GetTotalMemoryInMb()) * 100);
            float diskUsage = _diskCounter.NextValue();
    
            if (Math.Abs(cpuUsage - _previousCpuUsage) >= 5)
            {
                cpuProgressBar.Value = (int)cpuUsage;
                _lblCpuUsage.Text = $"CPU: {cpuUsage:F1}%";
                UpdateProgressBarColor(cpuProgressBar, cpuUsage);
                _previousCpuUsage = cpuUsage;
            }
    
            if (Math.Abs(ramUsage - _previousRamUsage) >= 5)
            {
                ramProgressBar.Value = (int)ramUsage;
                _lblRamUsage.Text = $"RAM: {ramUsage:F1}%";
                UpdateProgressBarColor(ramProgressBar, ramUsage);
                _previousRamUsage = ramUsage;
            }
    
            diskProgressBar.Value = (int)diskUsage;
            _lblDiskUsage.Text = $"Disk: {diskUsage:F1}%";
            UpdateProgressBarColor(diskProgressBar, diskUsage);
        }
        
        private void UpdateProgressBarColor(CircularProgressBar.CircularProgressBar progressBar, float value)
        {
            if (value < 65)
            {
                progressBar.ProgressColor = Color.Green;
            }
            else if (value < 90)
            {
                progressBar.ProgressColor = Color.Orange;
            }
            else
            {
                progressBar.ProgressColor = Color.Red;
            }
        }

        private static float GetTotalMemoryInMb()
        {
            return new Microsoft.VisualBasic.Devices.ComputerInfo().TotalPhysicalMemory / (1024 * 1024);
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
                btnToggleKeyboard.Text = "Выключить клавиатуру";
            }
            else
            {
                btnToggleKeyboard.Text = "Включить клавиатуру";
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
                this.Hide();
                _isWindowOpen = false;
            }
            else
            {
                this.Show();
                this.BringToFront();
                this.Activate();
                _isWindowOpen = true;
            }
        }

        private void MainForm_Deactivate(object sender, EventArgs e)
        {
            if (_isWindowOpen)
            {
                this.Hide();
                _isWindowOpen = false;
            }
        }
    }
}
