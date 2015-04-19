namespace RPG
{
    partial class UseDefault
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
            this.Prompt = new System.Windows.Forms.Label();
            this.Default = new System.Windows.Forms.Label();
            this.Yes = new System.Windows.Forms.Button();
            this.No = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Prompt
            // 
            this.Prompt.AutoSize = true;
            this.Prompt.Location = new System.Drawing.Point(39, 28);
            this.Prompt.Name = "Prompt";
            this.Prompt.Size = new System.Drawing.Size(278, 20);
            this.Prompt.TabIndex = 0;
            this.Prompt.Text = "Would you like to use Default Set-Up?";
            // 
            // Default
            // 
            this.Default.AutoSize = true;
            this.Default.Location = new System.Drawing.Point(39, 59);
            this.Default.Name = "Default";
            this.Default.Size = new System.Drawing.Size(0, 20);
            this.Default.TabIndex = 1;
            // 
            // Yes
            // 
            this.Yes.Location = new System.Drawing.Point(288, 516);
            this.Yes.Name = "Yes";
            this.Yes.Size = new System.Drawing.Size(99, 58);
            this.Yes.TabIndex = 2;
            this.Yes.Text = "Yes";
            this.Yes.UseVisualStyleBackColor = true;
            this.Yes.Click += new System.EventHandler(this.Yes_Click);
            // 
            // No
            // 
            this.No.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.No.Location = new System.Drawing.Point(420, 516);
            this.No.Name = "No";
            this.No.Size = new System.Drawing.Size(99, 58);
            this.No.TabIndex = 3;
            this.No.Text = "No";
            this.No.UseVisualStyleBackColor = true;
            this.No.Click += new System.EventHandler(this.No_Click);
            // 
            // UseDefault
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 586);
            this.Controls.Add(this.No);
            this.Controls.Add(this.Yes);
            this.Controls.Add(this.Default);
            this.Controls.Add(this.Prompt);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "UseDefault";
            this.Text = "Default";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UseDefault_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Prompt;
        private System.Windows.Forms.Label Default;
        private System.Windows.Forms.Button Yes;
        private System.Windows.Forms.Button No;
    }
}