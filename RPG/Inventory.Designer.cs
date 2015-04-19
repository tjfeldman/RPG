namespace RPG
{
    partial class Inventory
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
            this.Close = new System.Windows.Forms.Button();
            this.Potions = new System.Windows.Forms.Label();
            this.Ally1Equipment = new System.Windows.Forms.Label();
            this.Ally2Equipment = new System.Windows.Forms.Label();
            this.YourEquipment = new System.Windows.Forms.Label();
            this.UsePotion = new System.Windows.Forms.Panel();
            this.Use = new System.Windows.Forms.Button();
            this.useMaxRevive = new System.Windows.Forms.RadioButton();
            this.useRevive = new System.Windows.Forms.RadioButton();
            this.useMega = new System.Windows.Forms.RadioButton();
            this.useSuper = new System.Windows.Forms.RadioButton();
            this.useAdvanced = new System.Windows.Forms.RadioButton();
            this.useBasic = new System.Windows.Forms.RadioButton();
            this.UsePotion.SuspendLayout();
            this.SuspendLayout();
            // 
            // Close
            // 
            this.Close.Location = new System.Drawing.Point(170, 515);
            this.Close.Name = "Close";
            this.Close.Size = new System.Drawing.Size(304, 75);
            this.Close.TabIndex = 0;
            this.Close.Text = "Close Inventory";
            this.Close.UseVisualStyleBackColor = true;
            this.Close.Click += new System.EventHandler(this.Close_Click);
            // 
            // Potions
            // 
            this.Potions.AutoSize = true;
            this.Potions.Location = new System.Drawing.Point(15, 9);
            this.Potions.Name = "Potions";
            this.Potions.Size = new System.Drawing.Size(133, 20);
            this.Potions.TabIndex = 1;
            this.Potions.Text = "Potions you have:";
            // 
            // Ally1Equipment
            // 
            this.Ally1Equipment.AutoSize = true;
            this.Ally1Equipment.Location = new System.Drawing.Point(15, 251);
            this.Ally1Equipment.Name = "Ally1Equipment";
            this.Ally1Equipment.Size = new System.Drawing.Size(79, 20);
            this.Ally1Equipment.TabIndex = 2;
            this.Ally1Equipment.Text = "Ally1 Has:";
            // 
            // Ally2Equipment
            // 
            this.Ally2Equipment.AutoSize = true;
            this.Ally2Equipment.Location = new System.Drawing.Point(504, 251);
            this.Ally2Equipment.Name = "Ally2Equipment";
            this.Ally2Equipment.Size = new System.Drawing.Size(79, 20);
            this.Ally2Equipment.TabIndex = 3;
            this.Ally2Equipment.Text = "Ally2 Has:";
            // 
            // YourEquipment
            // 
            this.YourEquipment.AutoSize = true;
            this.YourEquipment.Location = new System.Drawing.Point(254, 251);
            this.YourEquipment.Name = "YourEquipment";
            this.YourEquipment.Size = new System.Drawing.Size(83, 20);
            this.YourEquipment.TabIndex = 4;
            this.YourEquipment.Text = "You Have:";
            // 
            // UsePotion
            // 
            this.UsePotion.Controls.Add(this.Use);
            this.UsePotion.Controls.Add(this.useMaxRevive);
            this.UsePotion.Controls.Add(this.useRevive);
            this.UsePotion.Controls.Add(this.useMega);
            this.UsePotion.Controls.Add(this.useSuper);
            this.UsePotion.Controls.Add(this.useAdvanced);
            this.UsePotion.Controls.Add(this.useBasic);
            this.UsePotion.Location = new System.Drawing.Point(474, -1);
            this.UsePotion.Name = "UsePotion";
            this.UsePotion.Size = new System.Drawing.Size(373, 252);
            this.UsePotion.TabIndex = 5;
            // 
            // Use
            // 
            this.Use.Location = new System.Drawing.Point(106, 203);
            this.Use.Name = "Use";
            this.Use.Size = new System.Drawing.Size(149, 46);
            this.Use.TabIndex = 6;
            this.Use.Text = "Use Item";
            this.Use.UseVisualStyleBackColor = true;
            this.Use.Click += new System.EventHandler(this.Use_Click);
            // 
            // useMaxRevive
            // 
            this.useMaxRevive.AutoSize = true;
            this.useMaxRevive.Location = new System.Drawing.Point(4, 163);
            this.useMaxRevive.Name = "useMaxRevive";
            this.useMaxRevive.Size = new System.Drawing.Size(140, 24);
            this.useMaxRevive.TabIndex = 5;
            this.useMaxRevive.TabStop = true;
            this.useMaxRevive.Text = "Use Max Revive";
            this.useMaxRevive.UseVisualStyleBackColor = true;
            this.useMaxRevive.CheckedChanged += new System.EventHandler(this.useMaxRevive_CheckedChanged);
            // 
            // useRevive
            // 
            this.useRevive.AutoSize = true;
            this.useRevive.Location = new System.Drawing.Point(4, 133);
            this.useRevive.Name = "useRevive";
            this.useRevive.Size = new System.Drawing.Size(107, 24);
            this.useRevive.TabIndex = 4;
            this.useRevive.TabStop = true;
            this.useRevive.Text = "Use Revive";
            this.useRevive.UseVisualStyleBackColor = true;
            this.useRevive.CheckedChanged += new System.EventHandler(this.useRevive_CheckedChanged);
            // 
            // useMega
            // 
            this.useMega.AutoSize = true;
            this.useMega.Location = new System.Drawing.Point(3, 103);
            this.useMega.Name = "useMega";
            this.useMega.Size = new System.Drawing.Size(149, 24);
            this.useMega.TabIndex = 3;
            this.useMega.TabStop = true;
            this.useMega.Text = "Use Mega Potion";
            this.useMega.UseVisualStyleBackColor = true;
            this.useMega.CheckedChanged += new System.EventHandler(this.useMega_CheckedChanged);
            // 
            // useSuper
            // 
            this.useSuper.AutoSize = true;
            this.useSuper.Location = new System.Drawing.Point(3, 73);
            this.useSuper.Name = "useSuper";
            this.useSuper.Size = new System.Drawing.Size(152, 24);
            this.useSuper.TabIndex = 2;
            this.useSuper.TabStop = true;
            this.useSuper.Text = "Use Super Potion";
            this.useSuper.UseVisualStyleBackColor = true;
            this.useSuper.CheckedChanged += new System.EventHandler(this.useSuper_CheckedChanged);
            // 
            // useAdvanced
            // 
            this.useAdvanced.AutoSize = true;
            this.useAdvanced.Location = new System.Drawing.Point(3, 43);
            this.useAdvanced.Name = "useAdvanced";
            this.useAdvanced.Size = new System.Drawing.Size(180, 24);
            this.useAdvanced.TabIndex = 1;
            this.useAdvanced.TabStop = true;
            this.useAdvanced.Text = "Use Advanced Potion";
            this.useAdvanced.UseVisualStyleBackColor = true;
            this.useAdvanced.CheckedChanged += new System.EventHandler(this.useAdvanced_CheckedChanged);
            // 
            // useBasic
            // 
            this.useBasic.AutoSize = true;
            this.useBasic.Location = new System.Drawing.Point(3, 13);
            this.useBasic.Name = "useBasic";
            this.useBasic.Size = new System.Drawing.Size(148, 24);
            this.useBasic.TabIndex = 0;
            this.useBasic.TabStop = true;
            this.useBasic.Text = "Use Basic Potion";
            this.useBasic.UseVisualStyleBackColor = true;
            this.useBasic.CheckedChanged += new System.EventHandler(this.useBasic_CheckedChanged);
            // 
            // Inventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 602);
            this.Controls.Add(this.UsePotion);
            this.Controls.Add(this.YourEquipment);
            this.Controls.Add(this.Ally2Equipment);
            this.Controls.Add(this.Ally1Equipment);
            this.Controls.Add(this.Potions);
            this.Controls.Add(this.Close);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Inventory";
            this.Text = "Inventory";
            this.UsePotion.ResumeLayout(false);
            this.UsePotion.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        new private System.Windows.Forms.Button Close;
        private System.Windows.Forms.Label Potions;
        private System.Windows.Forms.Label Ally1Equipment;
        private System.Windows.Forms.Label Ally2Equipment;
        private System.Windows.Forms.Label YourEquipment;
        private System.Windows.Forms.Panel UsePotion;
        private System.Windows.Forms.Button Use;
        private System.Windows.Forms.RadioButton useMaxRevive;
        private System.Windows.Forms.RadioButton useRevive;
        private System.Windows.Forms.RadioButton useMega;
        private System.Windows.Forms.RadioButton useSuper;
        private System.Windows.Forms.RadioButton useAdvanced;
        private System.Windows.Forms.RadioButton useBasic;
    }
}