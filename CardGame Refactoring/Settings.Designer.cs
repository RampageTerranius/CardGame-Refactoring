namespace Client
{
    partial class Settings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.rbtnWhite = new System.Windows.Forms.RadioButton();
            this.rbtnGrey = new System.Windows.Forms.RadioButton();
            this.rbtnYellow = new System.Windows.Forms.RadioButton();
            this.rbtnWGreen = new System.Windows.Forms.RadioButton();
            this.rbtnBlack = new System.Windows.Forms.RadioButton();
            this.gboxColor = new System.Windows.Forms.GroupBox();
            this.rbtnBlue = new System.Windows.Forms.RadioButton();
            this.gboxColor.SuspendLayout();
            this.SuspendLayout();
            // 
            // rbtnWhite
            // 
            this.rbtnWhite.AutoSize = true;
            this.rbtnWhite.Location = new System.Drawing.Point(6, 23);
            this.rbtnWhite.Name = "rbtnWhite";
            this.rbtnWhite.Size = new System.Drawing.Size(53, 17);
            this.rbtnWhite.TabIndex = 0;
            this.rbtnWhite.TabStop = true;
            this.rbtnWhite.Text = "White";
            this.rbtnWhite.UseVisualStyleBackColor = true;
            this.rbtnWhite.CheckedChanged += new System.EventHandler(this.rbtn_CheckedChanged);
            // 
            // rbtnGrey
            // 
            this.rbtnGrey.AutoSize = true;
            this.rbtnGrey.Location = new System.Drawing.Point(169, 46);
            this.rbtnGrey.Name = "rbtnGrey";
            this.rbtnGrey.Size = new System.Drawing.Size(47, 17);
            this.rbtnGrey.TabIndex = 1;
            this.rbtnGrey.TabStop = true;
            this.rbtnGrey.Text = "Grey";
            this.rbtnGrey.UseVisualStyleBackColor = true;
            this.rbtnGrey.CheckedChanged += new System.EventHandler(this.rbtn_CheckedChanged);
            // 
            // rbtnYellow
            // 
            this.rbtnYellow.AutoSize = true;
            this.rbtnYellow.Location = new System.Drawing.Point(6, 46);
            this.rbtnYellow.Name = "rbtnYellow";
            this.rbtnYellow.Size = new System.Drawing.Size(56, 17);
            this.rbtnYellow.TabIndex = 2;
            this.rbtnYellow.TabStop = true;
            this.rbtnYellow.Text = "Yellow";
            this.rbtnYellow.UseVisualStyleBackColor = true;
            this.rbtnYellow.CheckedChanged += new System.EventHandler(this.rbtn_CheckedChanged);
            // 
            // rbtnWGreen
            // 
            this.rbtnWGreen.AutoSize = true;
            this.rbtnWGreen.Location = new System.Drawing.Point(6, 69);
            this.rbtnWGreen.Name = "rbtnWGreen";
            this.rbtnWGreen.Size = new System.Drawing.Size(54, 17);
            this.rbtnWGreen.TabIndex = 3;
            this.rbtnWGreen.TabStop = true;
            this.rbtnWGreen.Text = "Green";
            this.rbtnWGreen.UseVisualStyleBackColor = true;
            this.rbtnWGreen.CheckedChanged += new System.EventHandler(this.rbtn_CheckedChanged);
            // 
            // rbtnBlack
            // 
            this.rbtnBlack.AutoSize = true;
            this.rbtnBlack.Location = new System.Drawing.Point(169, 23);
            this.rbtnBlack.Name = "rbtnBlack";
            this.rbtnBlack.Size = new System.Drawing.Size(52, 17);
            this.rbtnBlack.TabIndex = 4;
            this.rbtnBlack.TabStop = true;
            this.rbtnBlack.Text = "Black";
            this.rbtnBlack.UseVisualStyleBackColor = true;
            this.rbtnBlack.CheckedChanged += new System.EventHandler(this.rbtn_CheckedChanged);
            // 
            // gboxColor
            // 
            this.gboxColor.Controls.Add(this.rbtnBlue);
            this.gboxColor.Controls.Add(this.rbtnWhite);
            this.gboxColor.Controls.Add(this.rbtnWGreen);
            this.gboxColor.Controls.Add(this.rbtnBlack);
            this.gboxColor.Controls.Add(this.rbtnYellow);
            this.gboxColor.Controls.Add(this.rbtnGrey);
            this.gboxColor.Location = new System.Drawing.Point(12, 12);
            this.gboxColor.Name = "gboxColor";
            this.gboxColor.Size = new System.Drawing.Size(260, 107);
            this.gboxColor.TabIndex = 5;
            this.gboxColor.TabStop = false;
            this.gboxColor.Text = "Color";
            // 
            // rbtnBlue
            // 
            this.rbtnBlue.AutoSize = true;
            this.rbtnBlue.Location = new System.Drawing.Point(169, 69);
            this.rbtnBlue.Name = "rbtnBlue";
            this.rbtnBlue.Size = new System.Drawing.Size(46, 17);
            this.rbtnBlue.TabIndex = 5;
            this.rbtnBlue.TabStop = true;
            this.rbtnBlue.Text = "Blue";
            this.rbtnBlue.UseVisualStyleBackColor = true;
            this.rbtnBlue.CheckedChanged += new System.EventHandler(this.rbtn_CheckedChanged);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 131);
            this.Controls.Add(this.gboxColor);
            this.Name = "Settings";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.Settings_Load);
            this.gboxColor.ResumeLayout(false);
            this.gboxColor.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton rbtnWhite;
        private System.Windows.Forms.RadioButton rbtnGrey;
        private System.Windows.Forms.RadioButton rbtnYellow;
        private System.Windows.Forms.RadioButton rbtnWGreen;
        private System.Windows.Forms.RadioButton rbtnBlack;
        private System.Windows.Forms.GroupBox gboxColor;
        private System.Windows.Forms.RadioButton rbtnBlue;
    }
}