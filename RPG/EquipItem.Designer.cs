namespace RPG
{
    partial class EquipItem
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
            this.Item = new System.Windows.Forms.Label();
            this.Ally1Item = new System.Windows.Forms.Label();
            this.YourItem = new System.Windows.Forms.Label();
            this.Ally2Item = new System.Windows.Forms.Label();
            this.Confirm = new System.Windows.Forms.Button();
            this.EquipAlly1 = new System.Windows.Forms.RadioButton();
            this.EquipYou = new System.Windows.Forms.RadioButton();
            this.EquipAlly2 = new System.Windows.Forms.RadioButton();
            this.Toss = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // Item
            // 
            this.Item.AutoSize = true;
            this.Item.Location = new System.Drawing.Point(8, 29);
            this.Item.Name = "Item";
            this.Item.Size = new System.Drawing.Size(100, 20);
            this.Item.TabIndex = 0;
            this.Item.Text = "You Looted: ";
            // 
            // Ally1Item
            // 
            this.Ally1Item.AutoSize = true;
            this.Ally1Item.Location = new System.Drawing.Point(8, 110);
            this.Ally1Item.Name = "Ally1Item";
            this.Ally1Item.Size = new System.Drawing.Size(79, 20);
            this.Ally1Item.TabIndex = 1;
            this.Ally1Item.Text = "Ally1 Has:";
            // 
            // YourItem
            // 
            this.YourItem.AutoSize = true;
            this.YourItem.Location = new System.Drawing.Point(8, 206);
            this.YourItem.Name = "YourItem";
            this.YourItem.Size = new System.Drawing.Size(83, 20);
            this.YourItem.TabIndex = 2;
            this.YourItem.Text = "You Have:";
            // 
            // Ally2Item
            // 
            this.Ally2Item.AutoSize = true;
            this.Ally2Item.Location = new System.Drawing.Point(8, 305);
            this.Ally2Item.Name = "Ally2Item";
            this.Ally2Item.Size = new System.Drawing.Size(79, 20);
            this.Ally2Item.TabIndex = 3;
            this.Ally2Item.Text = "Ally2 Has:";
            // 
            // Confirm
            // 
            this.Confirm.Location = new System.Drawing.Point(381, 335);
            this.Confirm.Name = "Confirm";
            this.Confirm.Size = new System.Drawing.Size(228, 40);
            this.Confirm.TabIndex = 4;
            this.Confirm.Text = "Confirm Action";
            this.Confirm.UseVisualStyleBackColor = true;
            this.Confirm.Click += new System.EventHandler(this.Confirm_Click);
            // 
            // EquipAlly1
            // 
            this.EquipAlly1.AutoSize = true;
            this.EquipAlly1.Location = new System.Drawing.Point(381, 110);
            this.EquipAlly1.Name = "EquipAlly1";
            this.EquipAlly1.Size = new System.Drawing.Size(123, 24);
            this.EquipAlly1.TabIndex = 5;
            this.EquipAlly1.Text = "Equip to Ally1";
            this.EquipAlly1.UseVisualStyleBackColor = true;
            this.EquipAlly1.CheckedChanged += new System.EventHandler(this.EquipAlly1_CheckedChanged);
            // 
            // EquipYou
            // 
            this.EquipYou.AutoSize = true;
            this.EquipYou.Location = new System.Drawing.Point(381, 206);
            this.EquipYou.Name = "EquipYou";
            this.EquipYou.Size = new System.Drawing.Size(149, 24);
            this.EquipYou.TabIndex = 6;
            this.EquipYou.Text = "Equip to Yourself";
            this.EquipYou.UseVisualStyleBackColor = true;
            this.EquipYou.CheckedChanged += new System.EventHandler(this.EquipYou_CheckedChanged);
            // 
            // EquipAlly2
            // 
            this.EquipAlly2.AutoSize = true;
            this.EquipAlly2.Location = new System.Drawing.Point(381, 305);
            this.EquipAlly2.Name = "EquipAlly2";
            this.EquipAlly2.Size = new System.Drawing.Size(123, 24);
            this.EquipAlly2.TabIndex = 7;
            this.EquipAlly2.Text = "Equip to Ally2";
            this.EquipAlly2.UseVisualStyleBackColor = true;
            this.EquipAlly2.CheckedChanged += new System.EventHandler(this.EquipAlly2_CheckedChanged);
            // 
            // Toss
            // 
            this.Toss.AutoSize = true;
            this.Toss.Checked = true;
            this.Toss.Location = new System.Drawing.Point(381, 29);
            this.Toss.Name = "Toss";
            this.Toss.Size = new System.Drawing.Size(97, 24);
            this.Toss.TabIndex = 8;
            this.Toss.TabStop = true;
            this.Toss.Text = "Toss Item";
            this.Toss.UseVisualStyleBackColor = true;
            this.Toss.CheckedChanged += new System.EventHandler(this.Toss_CheckedChanged);
            // 
            // EquipItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 387);
            this.Controls.Add(this.Toss);
            this.Controls.Add(this.EquipAlly2);
            this.Controls.Add(this.EquipYou);
            this.Controls.Add(this.EquipAlly1);
            this.Controls.Add(this.Confirm);
            this.Controls.Add(this.Ally2Item);
            this.Controls.Add(this.YourItem);
            this.Controls.Add(this.Ally1Item);
            this.Controls.Add(this.Item);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "EquipItem";
            this.Text = "Equip?";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Item;
        private System.Windows.Forms.Label Ally1Item;
        private System.Windows.Forms.Label YourItem;
        private System.Windows.Forms.Label Ally2Item;
        private System.Windows.Forms.Button Confirm;
        private System.Windows.Forms.RadioButton EquipAlly1;
        private System.Windows.Forms.RadioButton EquipYou;
        private System.Windows.Forms.RadioButton EquipAlly2;
        private System.Windows.Forms.RadioButton Toss;
    }
}