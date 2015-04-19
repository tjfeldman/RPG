namespace RPG
{
    partial class YourClass
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
            this.Archer = new System.Windows.Forms.Button();
            this.Warrior = new System.Windows.Forms.Button();
            this.Mage = new System.Windows.Forms.Button();
            this.ArcherDetails = new System.Windows.Forms.Label();
            this.WarriorDetails = new System.Windows.Forms.Label();
            this.MageDetails = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Prompt
            // 
            this.Prompt.AutoSize = true;
            this.Prompt.Location = new System.Drawing.Point(12, 30);
            this.Prompt.Name = "Prompt";
            this.Prompt.Size = new System.Drawing.Size(237, 20);
            this.Prompt.TabIndex = 0;
            this.Prompt.Text = "What class would you like to be?";
            // 
            // Archer
            // 
            this.Archer.Location = new System.Drawing.Point(14, 79);
            this.Archer.Name = "Archer";
            this.Archer.Size = new System.Drawing.Size(245, 121);
            this.Archer.TabIndex = 1;
            this.Archer.Text = "Archer";
            this.Archer.UseVisualStyleBackColor = true;
            this.Archer.Click += new System.EventHandler(this.Archer_Click);
            // 
            // Warrior
            // 
            this.Warrior.Location = new System.Drawing.Point(442, 79);
            this.Warrior.Name = "Warrior";
            this.Warrior.Size = new System.Drawing.Size(245, 121);
            this.Warrior.TabIndex = 2;
            this.Warrior.Text = "Warrior";
            this.Warrior.UseVisualStyleBackColor = true;
            this.Warrior.Click += new System.EventHandler(this.Warrior_Click);
            // 
            // Mage
            // 
            this.Mage.Location = new System.Drawing.Point(868, 79);
            this.Mage.Name = "Mage";
            this.Mage.Size = new System.Drawing.Size(245, 121);
            this.Mage.TabIndex = 3;
            this.Mage.Text = "Mage";
            this.Mage.UseVisualStyleBackColor = true;
            this.Mage.Click += new System.EventHandler(this.Mage_Click);
            // 
            // ArcherDetails
            // 
            this.ArcherDetails.AutoSize = true;
            this.ArcherDetails.Location = new System.Drawing.Point(19, 224);
            this.ArcherDetails.Name = "ArcherDetails";
            this.ArcherDetails.Size = new System.Drawing.Size(0, 20);
            this.ArcherDetails.TabIndex = 4;
            // 
            // WarriorDetails
            // 
            this.WarriorDetails.AutoSize = true;
            this.WarriorDetails.Location = new System.Drawing.Point(438, 224);
            this.WarriorDetails.Name = "WarriorDetails";
            this.WarriorDetails.Size = new System.Drawing.Size(0, 20);
            this.WarriorDetails.TabIndex = 5;
            // 
            // MageDetails
            // 
            this.MageDetails.AutoSize = true;
            this.MageDetails.Location = new System.Drawing.Point(864, 224);
            this.MageDetails.Name = "MageDetails";
            this.MageDetails.Size = new System.Drawing.Size(0, 20);
            this.MageDetails.TabIndex = 6;
            // 
            // YourClass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1224, 502);
            this.Controls.Add(this.MageDetails);
            this.Controls.Add(this.WarriorDetails);
            this.Controls.Add(this.ArcherDetails);
            this.Controls.Add(this.Mage);
            this.Controls.Add(this.Warrior);
            this.Controls.Add(this.Archer);
            this.Controls.Add(this.Prompt);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "YourClass";
            this.Text = "Class Selection";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.YourClass_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Prompt;
        private System.Windows.Forms.Button Archer;
        private System.Windows.Forms.Button Warrior;
        private System.Windows.Forms.Button Mage;
        private System.Windows.Forms.Label ArcherDetails;
        private System.Windows.Forms.Label WarriorDetails;
        private System.Windows.Forms.Label MageDetails;
    }
}