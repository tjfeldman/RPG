namespace RPG
{
    partial class SelectTarget
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
            this.Ally1 = new System.Windows.Forms.Button();
            this.You = new System.Windows.Forms.Button();
            this.Ally2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Ally1
            // 
            this.Ally1.Location = new System.Drawing.Point(12, 12);
            this.Ally1.Name = "Ally1";
            this.Ally1.Size = new System.Drawing.Size(191, 92);
            this.Ally1.TabIndex = 0;
            this.Ally1.Text = "Ally1";
            this.Ally1.UseVisualStyleBackColor = true;
            this.Ally1.Click += new System.EventHandler(this.Ally1_Click);
            // 
            // You
            // 
            this.You.Location = new System.Drawing.Point(209, 12);
            this.You.Name = "You";
            this.You.Size = new System.Drawing.Size(191, 92);
            this.You.TabIndex = 1;
            this.You.Text = "You";
            this.You.UseVisualStyleBackColor = true;
            this.You.Click += new System.EventHandler(this.You_Click);
            // 
            // Ally2
            // 
            this.Ally2.Location = new System.Drawing.Point(406, 12);
            this.Ally2.Name = "Ally2";
            this.Ally2.Size = new System.Drawing.Size(191, 92);
            this.Ally2.TabIndex = 2;
            this.Ally2.Text = "Ally2";
            this.Ally2.UseVisualStyleBackColor = true;
            this.Ally2.Click += new System.EventHandler(this.Ally2_Click);
            // 
            // SelectTarget
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 112);
            this.Controls.Add(this.Ally2);
            this.Controls.Add(this.You);
            this.Controls.Add(this.Ally1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "SelectTarget";
            this.Text = "Who will use the Potion?";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Ally1;
        private System.Windows.Forms.Button You;
        private System.Windows.Forms.Button Ally2;
    }
}