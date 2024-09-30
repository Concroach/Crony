namespace Crony
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnToggleKeyboard;

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
            this.btnToggleKeyboard = new System.Windows.Forms.Button();
            this.SuspendLayout();
            
            // 
            // btnToggleKeyboard
            // 
            this.btnToggleKeyboard.Location = new System.Drawing.Point(100, 100); // Установи нужные координаты
            this.btnToggleKeyboard.Name = "btnToggleKeyboard";
            this.btnToggleKeyboard.Size = new System.Drawing.Size(100, 50); // Установи нужный размер
            this.btnToggleKeyboard.Text = "Disable Keyboard";
            this.btnToggleKeyboard.UseVisualStyleBackColor = true;
            this.btnToggleKeyboard.Click += new System.EventHandler(this.BtnToggleKeyboard_Click);
            
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(300, 200); // Размер окна
            this.Controls.Add(this.btnToggleKeyboard); // Добавляем кнопку в форму
            this.Name = "MainForm";
            this.ResumeLayout(false);
        }
    }
}