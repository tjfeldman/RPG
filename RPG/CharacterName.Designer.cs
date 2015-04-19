namespace RPG
{
    partial class CharacterName
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
            this.CharName = new System.Windows.Forms.TextBox();
            this.Accept = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Prompt
            // 
            this.Prompt.AutoSize = true;
            this.Prompt.Location = new System.Drawing.Point(36, 20);
            this.Prompt.Name = "Prompt";
            this.Prompt.Size = new System.Drawing.Size(0, 20);
            this.Prompt.TabIndex = 0;
            // 
            // CharName
            // 
            this.CharName.Location = new System.Drawing.Point(40, 95);
            this.CharName.Name = "CharName";
            this.CharName.Size = new System.Drawing.Size(315, 26);
            this.CharName.TabIndex = 1;
            // 
            // Accept
            // 
            this.Accept.Location = new System.Drawing.Point(40, 127);
            this.Accept.Name = "Accept";
            this.Accept.Size = new System.Drawing.Size(315, 48);
            this.Accept.TabIndex = 2;
            this.Accept.Text = "Accept";
            this.Accept.UseVisualStyleBackColor = true;
            this.Accept.Click += new System.EventHandler(this.Accept_Click);
            // 
            // CharacterName
            // 
            this.AcceptButton = this.Accept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 193);
            this.Controls.Add(this.Accept);
            this.Controls.Add(this.CharName);
            this.Controls.Add(this.Prompt);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "CharacterName";
            this.Text = "Character Name";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CharacterName_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Prompt;
        private System.Windows.Forms.TextBox CharName;
        private System.Windows.Forms.Button Accept;
    }
}