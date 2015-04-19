namespace RPG
{
    partial class Cutscene
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
            this.Done = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Prompt
            // 
            this.Prompt.AutoSize = true;
            this.Prompt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Prompt.Location = new System.Drawing.Point(45, 33);
            this.Prompt.Name = "Prompt";
            this.Prompt.Size = new System.Drawing.Size(159, 20);
            this.Prompt.TabIndex = 0;
            this.Prompt.Text = "Cutscene Goes Here";
            // 
            // Done
            // 
            this.Done.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Done.Location = new System.Drawing.Point(31, 467);
            this.Done.Name = "Done";
            this.Done.Size = new System.Drawing.Size(226, 67);
            this.Done.TabIndex = 1;
            this.Done.Text = "Done!";
            this.Done.UseVisualStyleBackColor = true;
            this.Done.Click += new System.EventHandler(this.Done_Click);
            // 
            // Cutscene
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 562);
            this.Controls.Add(this.Done);
            this.Controls.Add(this.Prompt);
            this.Name = "Cutscene";
            this.Text = "Cutscene";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Cutscene_FormClosing);
            this.Load += new System.EventHandler(this.Cutscene_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Prompt;
        private System.Windows.Forms.Button Done;
    }
}