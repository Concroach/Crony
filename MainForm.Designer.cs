namespace Crony
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private Button btnToggleKeyboard;

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
            
            // btnToggleKeyboard
            
            // MainForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(200, 100);
            this.Controls.Add(this.btnToggleKeyboard);
            this.Name = "MainForm";
            this.ResumeLayout(false);
        }
    }
}