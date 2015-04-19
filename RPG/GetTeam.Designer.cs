namespace RPG
{
    partial class GetTeam
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
            this.Healer = new System.Windows.Forms.Button();
            this.Guard = new System.Windows.Forms.Button();
            this.Thief = new System.Windows.Forms.Button();
            this.Rogue = new System.Windows.Forms.Button();
            this.Wizard = new System.Windows.Forms.Button();
            this.Scout = new System.Windows.Forms.Button();
            this.HealerDetails = new System.Windows.Forms.Label();
            this.GuardDetails = new System.Windows.Forms.Label();
            this.ThiefDetails = new System.Windows.Forms.Label();
            this.WizardDetails = new System.Windows.Forms.Label();
            this.RogueDetails = new System.Windows.Forms.Label();
            this.ScoutDetails = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Prompt
            // 
            this.Prompt.AutoSize = true;
            this.Prompt.Location = new System.Drawing.Point(26, 30);
            this.Prompt.Name = "Prompt";
            this.Prompt.Size = new System.Drawing.Size(165, 20);
            this.Prompt.TabIndex = 0;
            this.Prompt.Text = "Select first ally\'s class:";
            // 
            // Healer
            // 
            this.Healer.Location = new System.Drawing.Point(22, 60);
            this.Healer.Name = "Healer";
            this.Healer.Size = new System.Drawing.Size(168, 80);
            this.Healer.TabIndex = 1;
            this.Healer.Text = "Healer";
            this.Healer.UseVisualStyleBackColor = true;
            this.Healer.Click += new System.EventHandler(this.Healer_Click);
            // 
            // Guard
            // 
            this.Guard.Location = new System.Drawing.Point(385, 60);
            this.Guard.Name = "Guard";
            this.Guard.Size = new System.Drawing.Size(168, 80);
            this.Guard.TabIndex = 2;
            this.Guard.Text = "Guard";
            this.Guard.UseVisualStyleBackColor = true;
            this.Guard.Click += new System.EventHandler(this.Guard_Click);
            // 
            // Thief
            // 
            this.Thief.Location = new System.Drawing.Point(748, 60);
            this.Thief.Name = "Thief";
            this.Thief.Size = new System.Drawing.Size(168, 80);
            this.Thief.TabIndex = 3;
            this.Thief.Text = "Thief";
            this.Thief.UseVisualStyleBackColor = true;
            this.Thief.Click += new System.EventHandler(this.Thief_Click);
            // 
            // Rogue
            // 
            this.Rogue.Location = new System.Drawing.Point(385, 388);
            this.Rogue.Name = "Rogue";
            this.Rogue.Size = new System.Drawing.Size(168, 80);
            this.Rogue.TabIndex = 4;
            this.Rogue.Text = "Rogue";
            this.Rogue.UseVisualStyleBackColor = true;
            this.Rogue.Click += new System.EventHandler(this.Rogue_Click);
            // 
            // Wizard
            // 
            this.Wizard.Location = new System.Drawing.Point(22, 388);
            this.Wizard.Name = "Wizard";
            this.Wizard.Size = new System.Drawing.Size(168, 80);
            this.Wizard.TabIndex = 5;
            this.Wizard.Text = "Wizard";
            this.Wizard.UseVisualStyleBackColor = true;
            this.Wizard.Click += new System.EventHandler(this.Wizard_Click);
            // 
            // Scout
            // 
            this.Scout.Location = new System.Drawing.Point(748, 388);
            this.Scout.Name = "Scout";
            this.Scout.Size = new System.Drawing.Size(168, 80);
            this.Scout.TabIndex = 6;
            this.Scout.Text = "Scout";
            this.Scout.UseVisualStyleBackColor = true;
            this.Scout.Click += new System.EventHandler(this.Scout_Click);
            // 
            // HealerDetails
            // 
            this.HealerDetails.AutoSize = true;
            this.HealerDetails.Location = new System.Drawing.Point(23, 160);
            this.HealerDetails.Name = "HealerDetails";
            this.HealerDetails.Size = new System.Drawing.Size(0, 20);
            this.HealerDetails.TabIndex = 7;
            // 
            // GuardDetails
            // 
            this.GuardDetails.AutoSize = true;
            this.GuardDetails.Location = new System.Drawing.Point(381, 160);
            this.GuardDetails.Name = "GuardDetails";
            this.GuardDetails.Size = new System.Drawing.Size(0, 20);
            this.GuardDetails.TabIndex = 8;
            // 
            // ThiefDetails
            // 
            this.ThiefDetails.AutoSize = true;
            this.ThiefDetails.Location = new System.Drawing.Point(744, 160);
            this.ThiefDetails.Name = "ThiefDetails";
            this.ThiefDetails.Size = new System.Drawing.Size(0, 20);
            this.ThiefDetails.TabIndex = 9;
            // 
            // WizardDetails
            // 
            this.WizardDetails.AutoSize = true;
            this.WizardDetails.Location = new System.Drawing.Point(23, 496);
            this.WizardDetails.Name = "WizardDetails";
            this.WizardDetails.Size = new System.Drawing.Size(0, 20);
            this.WizardDetails.TabIndex = 10;
            // 
            // RogueDetails
            // 
            this.RogueDetails.AutoSize = true;
            this.RogueDetails.Location = new System.Drawing.Point(381, 496);
            this.RogueDetails.Name = "RogueDetails";
            this.RogueDetails.Size = new System.Drawing.Size(0, 20);
            this.RogueDetails.TabIndex = 11;
            // 
            // ScoutDetails
            // 
            this.ScoutDetails.AutoSize = true;
            this.ScoutDetails.Location = new System.Drawing.Point(744, 496);
            this.ScoutDetails.Name = "ScoutDetails";
            this.ScoutDetails.Size = new System.Drawing.Size(0, 20);
            this.ScoutDetails.TabIndex = 12;
            // 
            // GetTeam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1171, 765);
            this.Controls.Add(this.ScoutDetails);
            this.Controls.Add(this.RogueDetails);
            this.Controls.Add(this.WizardDetails);
            this.Controls.Add(this.ThiefDetails);
            this.Controls.Add(this.GuardDetails);
            this.Controls.Add(this.HealerDetails);
            this.Controls.Add(this.Scout);
            this.Controls.Add(this.Wizard);
            this.Controls.Add(this.Rogue);
            this.Controls.Add(this.Thief);
            this.Controls.Add(this.Guard);
            this.Controls.Add(this.Healer);
            this.Controls.Add(this.Prompt);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "GetTeam";
            this.Text = "Select an Ally Class";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GetTeam_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Prompt;
        private System.Windows.Forms.Button Healer;
        private System.Windows.Forms.Button Guard;
        private System.Windows.Forms.Button Thief;
        private System.Windows.Forms.Button Rogue;
        private System.Windows.Forms.Button Wizard;
        private System.Windows.Forms.Button Scout;
        private System.Windows.Forms.Label HealerDetails;
        private System.Windows.Forms.Label GuardDetails;
        private System.Windows.Forms.Label ThiefDetails;
        private System.Windows.Forms.Label WizardDetails;
        private System.Windows.Forms.Label RogueDetails;
        private System.Windows.Forms.Label ScoutDetails;
    }
}