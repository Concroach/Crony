﻿namespace Crony
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
            
            // MainForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(200, 100);
            this.Controls.Add(this.btnToggleKeyboard);
            this.Name = "MainForm";
            this.ResumeLayout(false);
            
            // btnToggleKeyboard
            this.btnToggleKeyboard.Location = new System.Drawing.Point(25, 33);
            this.btnToggleKeyboard.Name = "btnToggleKeyboard";
            this.btnToggleKeyboard.Size = new System.Drawing.Size(150, 25);
            this.btnToggleKeyboard.TabIndex = 0;
            this.btnToggleKeyboard.UseVisualStyleBackColor = true;
            this.btnToggleKeyboard.Click += new System.EventHandler(this.btnToggleKeyboard_Click);
            
            
            
        }
    }
}