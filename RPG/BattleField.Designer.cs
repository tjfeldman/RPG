namespace RPG
{
    partial class BattleField
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
            this.PlayerSide = new System.Windows.Forms.Panel();
            this.Ally2Health = new System.Windows.Forms.ProgressBar();
            this.YourHealth = new System.Windows.Forms.ProgressBar();
            this.Ally1Health = new System.Windows.Forms.ProgressBar();
            this.Ally2Image = new System.Windows.Forms.PictureBox();
            this.YouImage = new System.Windows.Forms.PictureBox();
            this.Ally1Image = new System.Windows.Forms.PictureBox();
            this.Ally2 = new System.Windows.Forms.Label();
            this.You = new System.Windows.Forms.Label();
            this.Ally1 = new System.Windows.Forms.Label();
            this.EnemySide = new System.Windows.Forms.Panel();
            this.Enemy6Health = new System.Windows.Forms.ProgressBar();
            this.Enemy4Health = new System.Windows.Forms.ProgressBar();
            this.Enemy5Health = new System.Windows.Forms.ProgressBar();
            this.Enemy3Health = new System.Windows.Forms.ProgressBar();
            this.Enemy2Health = new System.Windows.Forms.ProgressBar();
            this.Enemy1Health = new System.Windows.Forms.ProgressBar();
            this.TargetEnemy6 = new System.Windows.Forms.RadioButton();
            this.TargetEnemy5 = new System.Windows.Forms.RadioButton();
            this.TargetEnemy4 = new System.Windows.Forms.RadioButton();
            this.TargetEnemy3 = new System.Windows.Forms.RadioButton();
            this.TargetEnemy2 = new System.Windows.Forms.RadioButton();
            this.TargetEnemy1 = new System.Windows.Forms.RadioButton();
            this.Enemy3Image = new System.Windows.Forms.PictureBox();
            this.Enemy2Image = new System.Windows.Forms.PictureBox();
            this.Enemy1Image = new System.Windows.Forms.PictureBox();
            this.Enemy6Image = new System.Windows.Forms.PictureBox();
            this.Enemy5Image = new System.Windows.Forms.PictureBox();
            this.Enemy4Image = new System.Windows.Forms.PictureBox();
            this.Enemy6 = new System.Windows.Forms.Label();
            this.Enemy5 = new System.Windows.Forms.Label();
            this.Enemy4 = new System.Windows.Forms.Label();
            this.Enemy3 = new System.Windows.Forms.Label();
            this.Enemy2 = new System.Windows.Forms.Label();
            this.Enemy1 = new System.Windows.Forms.Label();
            this.Current = new System.Windows.Forms.Label();
            this.Respawn = new System.Windows.Forms.Label();
            this.Output = new System.Windows.Forms.TextBox();
            this.Accurate = new System.Windows.Forms.Button();
            this.Start = new System.Windows.Forms.Button();
            this.Inventory = new System.Windows.Forms.Button();
            this.Power = new System.Windows.Forms.Button();
            this.Rapid = new System.Windows.Forms.Button();
            this.Focus = new System.Windows.Forms.CheckBox();
            this.FocusPower = new System.Windows.Forms.TrackBar();
            this.AoE = new System.Windows.Forms.Button();
            this.Hide = new System.Windows.Forms.Button();
            this.ChangeDelay = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.PlayerSide.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Ally2Image)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.YouImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ally1Image)).BeginInit();
            this.EnemySide.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Enemy3Image)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Enemy2Image)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Enemy1Image)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Enemy6Image)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Enemy5Image)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Enemy4Image)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FocusPower)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChangeDelay)).BeginInit();
            this.SuspendLayout();
            // 
            // PlayerSide
            // 
            this.PlayerSide.Controls.Add(this.Ally2Health);
            this.PlayerSide.Controls.Add(this.YourHealth);
            this.PlayerSide.Controls.Add(this.Ally1Health);
            this.PlayerSide.Controls.Add(this.Ally2Image);
            this.PlayerSide.Controls.Add(this.YouImage);
            this.PlayerSide.Controls.Add(this.Ally1Image);
            this.PlayerSide.Controls.Add(this.Ally2);
            this.PlayerSide.Controls.Add(this.You);
            this.PlayerSide.Controls.Add(this.Ally1);
            this.PlayerSide.Location = new System.Drawing.Point(23, 16);
            this.PlayerSide.Name = "PlayerSide";
            this.PlayerSide.Size = new System.Drawing.Size(477, 657);
            this.PlayerSide.TabIndex = 0;
            // 
            // Ally2Health
            // 
            this.Ally2Health.Location = new System.Drawing.Point(31, 445);
            this.Ally2Health.Name = "Ally2Health";
            this.Ally2Health.Size = new System.Drawing.Size(276, 19);
            this.Ally2Health.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.Ally2Health.TabIndex = 23;
            this.Ally2Health.Value = 100;
            // 
            // YourHealth
            // 
            this.YourHealth.Location = new System.Drawing.Point(31, 239);
            this.YourHealth.Name = "YourHealth";
            this.YourHealth.Size = new System.Drawing.Size(276, 19);
            this.YourHealth.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.YourHealth.TabIndex = 22;
            this.YourHealth.Value = 100;
            // 
            // Ally1Health
            // 
            this.Ally1Health.Location = new System.Drawing.Point(31, 51);
            this.Ally1Health.Name = "Ally1Health";
            this.Ally1Health.Size = new System.Drawing.Size(276, 19);
            this.Ally1Health.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.Ally1Health.TabIndex = 21;
            this.Ally1Health.Value = 100;
            // 
            // Ally2Image
            // 
            this.Ally2Image.InitialImage = null;
            this.Ally2Image.Location = new System.Drawing.Point(313, 461);
            this.Ally2Image.Name = "Ally2Image";
            this.Ally2Image.Size = new System.Drawing.Size(150, 150);
            this.Ally2Image.TabIndex = 4;
            this.Ally2Image.TabStop = false;
            // 
            // YouImage
            // 
            this.YouImage.InitialImage = null;
            this.YouImage.Location = new System.Drawing.Point(313, 254);
            this.YouImage.Name = "YouImage";
            this.YouImage.Size = new System.Drawing.Size(150, 150);
            this.YouImage.TabIndex = 4;
            this.YouImage.TabStop = false;
            // 
            // Ally1Image
            // 
            this.Ally1Image.InitialImage = null;
            this.Ally1Image.Location = new System.Drawing.Point(313, 51);
            this.Ally1Image.Name = "Ally1Image";
            this.Ally1Image.Size = new System.Drawing.Size(150, 150);
            this.Ally1Image.TabIndex = 3;
            this.Ally1Image.TabStop = false;
            // 
            // Ally2
            // 
            this.Ally2.AutoSize = true;
            this.Ally2.Location = new System.Drawing.Point(27, 422);
            this.Ally2.Name = "Ally2";
            this.Ally2.Size = new System.Drawing.Size(42, 20);
            this.Ally2.TabIndex = 2;
            this.Ally2.Text = "Ally2";
            // 
            // You
            // 
            this.You.AutoSize = true;
            this.You.Location = new System.Drawing.Point(27, 216);
            this.You.Name = "You";
            this.You.Size = new System.Drawing.Size(38, 20);
            this.You.TabIndex = 1;
            this.You.Text = "You";
            // 
            // Ally1
            // 
            this.Ally1.AutoSize = true;
            this.Ally1.Location = new System.Drawing.Point(27, 28);
            this.Ally1.Name = "Ally1";
            this.Ally1.Size = new System.Drawing.Size(42, 20);
            this.Ally1.TabIndex = 0;
            this.Ally1.Text = "Ally1";
            // 
            // EnemySide
            // 
            this.EnemySide.Controls.Add(this.Enemy6Health);
            this.EnemySide.Controls.Add(this.Enemy4Health);
            this.EnemySide.Controls.Add(this.Enemy5Health);
            this.EnemySide.Controls.Add(this.Enemy3Health);
            this.EnemySide.Controls.Add(this.Enemy2Health);
            this.EnemySide.Controls.Add(this.Enemy1Health);
            this.EnemySide.Controls.Add(this.TargetEnemy6);
            this.EnemySide.Controls.Add(this.TargetEnemy5);
            this.EnemySide.Controls.Add(this.TargetEnemy4);
            this.EnemySide.Controls.Add(this.TargetEnemy3);
            this.EnemySide.Controls.Add(this.TargetEnemy2);
            this.EnemySide.Controls.Add(this.TargetEnemy1);
            this.EnemySide.Controls.Add(this.Enemy3Image);
            this.EnemySide.Controls.Add(this.Enemy2Image);
            this.EnemySide.Controls.Add(this.Enemy1Image);
            this.EnemySide.Controls.Add(this.Enemy6Image);
            this.EnemySide.Controls.Add(this.Enemy5Image);
            this.EnemySide.Controls.Add(this.Enemy4Image);
            this.EnemySide.Controls.Add(this.Enemy6);
            this.EnemySide.Controls.Add(this.Enemy5);
            this.EnemySide.Controls.Add(this.Enemy4);
            this.EnemySide.Controls.Add(this.Enemy3);
            this.EnemySide.Controls.Add(this.Enemy2);
            this.EnemySide.Controls.Add(this.Enemy1);
            this.EnemySide.Location = new System.Drawing.Point(849, 16);
            this.EnemySide.Name = "EnemySide";
            this.EnemySide.Size = new System.Drawing.Size(871, 657);
            this.EnemySide.TabIndex = 1;
            // 
            // Enemy6Health
            // 
            this.Enemy6Health.Location = new System.Drawing.Point(214, 423);
            this.Enemy6Health.Name = "Enemy6Health";
            this.Enemy6Health.Size = new System.Drawing.Size(112, 19);
            this.Enemy6Health.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.Enemy6Health.TabIndex = 24;
            this.Enemy6Health.Value = 100;
            // 
            // Enemy4Health
            // 
            this.Enemy4Health.Location = new System.Drawing.Point(214, 229);
            this.Enemy4Health.Name = "Enemy4Health";
            this.Enemy4Health.Size = new System.Drawing.Size(112, 19);
            this.Enemy4Health.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.Enemy4Health.TabIndex = 23;
            this.Enemy4Health.Value = 100;
            // 
            // Enemy5Health
            // 
            this.Enemy5Health.Location = new System.Drawing.Point(214, 29);
            this.Enemy5Health.Name = "Enemy5Health";
            this.Enemy5Health.Size = new System.Drawing.Size(112, 19);
            this.Enemy5Health.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.Enemy5Health.TabIndex = 22;
            this.Enemy5Health.Value = 100;
            // 
            // Enemy3Health
            // 
            this.Enemy3Health.Location = new System.Drawing.Point(711, 423);
            this.Enemy3Health.Name = "Enemy3Health";
            this.Enemy3Health.Size = new System.Drawing.Size(112, 19);
            this.Enemy3Health.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.Enemy3Health.TabIndex = 21;
            this.Enemy3Health.Value = 100;
            // 
            // Enemy2Health
            // 
            this.Enemy2Health.Location = new System.Drawing.Point(711, 229);
            this.Enemy2Health.Name = "Enemy2Health";
            this.Enemy2Health.Size = new System.Drawing.Size(112, 19);
            this.Enemy2Health.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.Enemy2Health.TabIndex = 20;
            this.Enemy2Health.Value = 100;
            // 
            // Enemy1Health
            // 
            this.Enemy1Health.Location = new System.Drawing.Point(711, 29);
            this.Enemy1Health.Name = "Enemy1Health";
            this.Enemy1Health.Size = new System.Drawing.Size(112, 19);
            this.Enemy1Health.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.Enemy1Health.TabIndex = 19;
            this.Enemy1Health.Value = 100;
            // 
            // TargetEnemy6
            // 
            this.TargetEnemy6.AutoSize = true;
            this.TargetEnemy6.Location = new System.Drawing.Point(214, 527);
            this.TargetEnemy6.Name = "TargetEnemy6";
            this.TargetEnemy6.Size = new System.Drawing.Size(73, 24);
            this.TargetEnemy6.TabIndex = 17;
            this.TargetEnemy6.TabStop = true;
            this.TargetEnemy6.Text = "Target";
            this.TargetEnemy6.UseVisualStyleBackColor = true;
            this.TargetEnemy6.CheckedChanged += new System.EventHandler(this.TargetEnemy6_CheckedChanged);
            // 
            // TargetEnemy5
            // 
            this.TargetEnemy5.AutoSize = true;
            this.TargetEnemy5.Location = new System.Drawing.Point(214, 110);
            this.TargetEnemy5.Name = "TargetEnemy5";
            this.TargetEnemy5.Size = new System.Drawing.Size(73, 24);
            this.TargetEnemy5.TabIndex = 16;
            this.TargetEnemy5.TabStop = true;
            this.TargetEnemy5.Text = "Target";
            this.TargetEnemy5.UseVisualStyleBackColor = true;
            this.TargetEnemy5.CheckedChanged += new System.EventHandler(this.TargetEnemy5_CheckedChanged);
            // 
            // TargetEnemy4
            // 
            this.TargetEnemy4.AutoSize = true;
            this.TargetEnemy4.Location = new System.Drawing.Point(214, 307);
            this.TargetEnemy4.Name = "TargetEnemy4";
            this.TargetEnemy4.Size = new System.Drawing.Size(73, 24);
            this.TargetEnemy4.TabIndex = 15;
            this.TargetEnemy4.TabStop = true;
            this.TargetEnemy4.Text = "Target";
            this.TargetEnemy4.UseVisualStyleBackColor = true;
            this.TargetEnemy4.CheckedChanged += new System.EventHandler(this.TargetEnemy4_CheckedChanged);
            // 
            // TargetEnemy3
            // 
            this.TargetEnemy3.AutoSize = true;
            this.TargetEnemy3.Location = new System.Drawing.Point(748, 527);
            this.TargetEnemy3.Name = "TargetEnemy3";
            this.TargetEnemy3.Size = new System.Drawing.Size(73, 24);
            this.TargetEnemy3.TabIndex = 14;
            this.TargetEnemy3.TabStop = true;
            this.TargetEnemy3.Text = "Target";
            this.TargetEnemy3.UseVisualStyleBackColor = true;
            this.TargetEnemy3.CheckedChanged += new System.EventHandler(this.TargetEnemy3_CheckedChanged);
            // 
            // TargetEnemy2
            // 
            this.TargetEnemy2.AutoSize = true;
            this.TargetEnemy2.Location = new System.Drawing.Point(748, 313);
            this.TargetEnemy2.Name = "TargetEnemy2";
            this.TargetEnemy2.Size = new System.Drawing.Size(73, 24);
            this.TargetEnemy2.TabIndex = 13;
            this.TargetEnemy2.TabStop = true;
            this.TargetEnemy2.Text = "Target";
            this.TargetEnemy2.UseVisualStyleBackColor = true;
            this.TargetEnemy2.CheckedChanged += new System.EventHandler(this.TargetEnemy2_CheckedChanged);
            // 
            // TargetEnemy1
            // 
            this.TargetEnemy1.AutoSize = true;
            this.TargetEnemy1.Location = new System.Drawing.Point(748, 104);
            this.TargetEnemy1.Name = "TargetEnemy1";
            this.TargetEnemy1.Size = new System.Drawing.Size(73, 24);
            this.TargetEnemy1.TabIndex = 12;
            this.TargetEnemy1.TabStop = true;
            this.TargetEnemy1.Text = "Target";
            this.TargetEnemy1.UseVisualStyleBackColor = true;
            this.TargetEnemy1.CheckedChanged += new System.EventHandler(this.TargetEnemy1_CheckedChanged);
            // 
            // Enemy3Image
            // 
            this.Enemy3Image.InitialImage = null;
            this.Enemy3Image.Location = new System.Drawing.Point(551, 461);
            this.Enemy3Image.Name = "Enemy3Image";
            this.Enemy3Image.Size = new System.Drawing.Size(150, 150);
            this.Enemy3Image.TabIndex = 11;
            this.Enemy3Image.TabStop = false;
            // 
            // Enemy2Image
            // 
            this.Enemy2Image.InitialImage = null;
            this.Enemy2Image.Location = new System.Drawing.Point(551, 269);
            this.Enemy2Image.Name = "Enemy2Image";
            this.Enemy2Image.Size = new System.Drawing.Size(150, 150);
            this.Enemy2Image.TabIndex = 10;
            this.Enemy2Image.TabStop = false;
            // 
            // Enemy1Image
            // 
            this.Enemy1Image.InitialImage = null;
            this.Enemy1Image.Location = new System.Drawing.Point(551, 75);
            this.Enemy1Image.Name = "Enemy1Image";
            this.Enemy1Image.Size = new System.Drawing.Size(150, 150);
            this.Enemy1Image.TabIndex = 9;
            this.Enemy1Image.TabStop = false;
            // 
            // Enemy6Image
            // 
            this.Enemy6Image.InitialImage = null;
            this.Enemy6Image.Location = new System.Drawing.Point(29, 461);
            this.Enemy6Image.Name = "Enemy6Image";
            this.Enemy6Image.Size = new System.Drawing.Size(150, 150);
            this.Enemy6Image.TabIndex = 8;
            this.Enemy6Image.TabStop = false;
            // 
            // Enemy5Image
            // 
            this.Enemy5Image.InitialImage = null;
            this.Enemy5Image.Location = new System.Drawing.Point(29, 75);
            this.Enemy5Image.Name = "Enemy5Image";
            this.Enemy5Image.Size = new System.Drawing.Size(150, 150);
            this.Enemy5Image.TabIndex = 7;
            this.Enemy5Image.TabStop = false;
            // 
            // Enemy4Image
            // 
            this.Enemy4Image.InitialImage = null;
            this.Enemy4Image.Location = new System.Drawing.Point(29, 269);
            this.Enemy4Image.Name = "Enemy4Image";
            this.Enemy4Image.Size = new System.Drawing.Size(150, 150);
            this.Enemy4Image.TabIndex = 6;
            this.Enemy4Image.TabStop = false;
            // 
            // Enemy6
            // 
            this.Enemy6.AutoSize = true;
            this.Enemy6.Location = new System.Drawing.Point(25, 422);
            this.Enemy6.Name = "Enemy6";
            this.Enemy6.Size = new System.Drawing.Size(16, 20);
            this.Enemy6.TabIndex = 5;
            this.Enemy6.Text = "x";
            // 
            // Enemy5
            // 
            this.Enemy5.AutoSize = true;
            this.Enemy5.Location = new System.Drawing.Point(25, 28);
            this.Enemy5.Name = "Enemy5";
            this.Enemy5.Size = new System.Drawing.Size(16, 20);
            this.Enemy5.TabIndex = 4;
            this.Enemy5.Text = "x";
            // 
            // Enemy4
            // 
            this.Enemy4.AutoSize = true;
            this.Enemy4.Location = new System.Drawing.Point(25, 228);
            this.Enemy4.Name = "Enemy4";
            this.Enemy4.Size = new System.Drawing.Size(16, 20);
            this.Enemy4.TabIndex = 3;
            this.Enemy4.Text = "x";
            // 
            // Enemy3
            // 
            this.Enemy3.AutoSize = true;
            this.Enemy3.Location = new System.Drawing.Point(547, 422);
            this.Enemy3.Name = "Enemy3";
            this.Enemy3.Size = new System.Drawing.Size(16, 20);
            this.Enemy3.TabIndex = 2;
            this.Enemy3.Text = "x";
            // 
            // Enemy2
            // 
            this.Enemy2.AutoSize = true;
            this.Enemy2.Location = new System.Drawing.Point(547, 228);
            this.Enemy2.Name = "Enemy2";
            this.Enemy2.Size = new System.Drawing.Size(16, 20);
            this.Enemy2.TabIndex = 1;
            this.Enemy2.Text = "x";
            // 
            // Enemy1
            // 
            this.Enemy1.AutoSize = true;
            this.Enemy1.Location = new System.Drawing.Point(547, 28);
            this.Enemy1.Name = "Enemy1";
            this.Enemy1.Size = new System.Drawing.Size(16, 20);
            this.Enemy1.TabIndex = 0;
            this.Enemy1.Text = "x";
            // 
            // Current
            // 
            this.Current.AutoSize = true;
            this.Current.Location = new System.Drawing.Point(506, 16);
            this.Current.Name = "Current";
            this.Current.Size = new System.Drawing.Size(126, 20);
            this.Current.TabIndex = 2;
            this.Current.Text = "Current Room: 1";
            // 
            // Respawn
            // 
            this.Respawn.AutoSize = true;
            this.Respawn.Location = new System.Drawing.Point(506, 36);
            this.Respawn.Name = "Respawn";
            this.Respawn.Size = new System.Drawing.Size(153, 20);
            this.Respawn.TabIndex = 3;
            this.Respawn.Text = "Checkpoint Room: 1";
            // 
            // Output
            // 
            this.Output.Location = new System.Drawing.Point(510, 70);
            this.Output.Multiline = true;
            this.Output.Name = "Output";
            this.Output.ReadOnly = true;
            this.Output.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Output.Size = new System.Drawing.Size(333, 603);
            this.Output.TabIndex = 4;
            this.Output.Text = "Battle Log:";
            // 
            // Accurate
            // 
            this.Accurate.Enabled = false;
            this.Accurate.Location = new System.Drawing.Point(23, 758);
            this.Accurate.Name = "Accurate";
            this.Accurate.Size = new System.Drawing.Size(216, 67);
            this.Accurate.TabIndex = 5;
            this.Accurate.Text = "Accurate Attack (0 Energy)";
            this.Accurate.UseVisualStyleBackColor = true;
            this.Accurate.Click += new System.EventHandler(this.Accurate_Click);
            // 
            // Start
            // 
            this.Start.Location = new System.Drawing.Point(510, 679);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(333, 56);
            this.Start.TabIndex = 6;
            this.Start.Text = "Start Battle";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // Inventory
            // 
            this.Inventory.Location = new System.Drawing.Point(23, 848);
            this.Inventory.Name = "Inventory";
            this.Inventory.Size = new System.Drawing.Size(216, 60);
            this.Inventory.TabIndex = 7;
            this.Inventory.Text = "View Inventory";
            this.Inventory.UseVisualStyleBackColor = true;
            this.Inventory.Click += new System.EventHandler(this.Inventory_Click);
            // 
            // Power
            // 
            this.Power.Enabled = false;
            this.Power.Location = new System.Drawing.Point(284, 758);
            this.Power.Name = "Power";
            this.Power.Size = new System.Drawing.Size(216, 67);
            this.Power.TabIndex = 8;
            this.Power.Text = "Power Attack (5 Energy)";
            this.Power.UseVisualStyleBackColor = true;
            this.Power.Click += new System.EventHandler(this.Power_Click);
            // 
            // Rapid
            // 
            this.Rapid.Enabled = false;
            this.Rapid.Location = new System.Drawing.Point(551, 758);
            this.Rapid.Name = "Rapid";
            this.Rapid.Size = new System.Drawing.Size(216, 67);
            this.Rapid.TabIndex = 9;
            this.Rapid.Text = "Rapid Attack (10 Energy)";
            this.Rapid.UseVisualStyleBackColor = true;
            this.Rapid.Click += new System.EventHandler(this.Rapid_Click);
            // 
            // Focus
            // 
            this.Focus.AutoSize = true;
            this.Focus.Location = new System.Drawing.Point(23, 679);
            this.Focus.Name = "Focus";
            this.Focus.Size = new System.Drawing.Size(388, 24);
            this.Focus.TabIndex = 10;
            this.Focus.Text = "Focus: 5% damage, 5% accuracy, 0% crit, 1 energy";
            this.Focus.UseVisualStyleBackColor = true;
            this.Focus.CheckedChanged += new System.EventHandler(this.Focus_CheckedChanged);
            // 
            // FocusPower
            // 
            this.FocusPower.Location = new System.Drawing.Point(12, 707);
            this.FocusPower.Maximum = 5;
            this.FocusPower.Minimum = 1;
            this.FocusPower.Name = "FocusPower";
            this.FocusPower.Size = new System.Drawing.Size(488, 45);
            this.FocusPower.TabIndex = 11;
            this.FocusPower.Value = 1;
            this.FocusPower.Scroll += new System.EventHandler(this.FocusPower_Scroll);
            // 
            // AoE
            // 
            this.AoE.Enabled = false;
            this.AoE.Location = new System.Drawing.Point(812, 758);
            this.AoE.Name = "AoE";
            this.AoE.Size = new System.Drawing.Size(216, 67);
            this.AoE.TabIndex = 12;
            this.AoE.Text = "Reach Level 5 to Unlock";
            this.AoE.UseVisualStyleBackColor = true;
            this.AoE.Click += new System.EventHandler(this.AoE_Click);
            // 
            // Hide
            // 
            this.Hide.Enabled = false;
            this.Hide.Location = new System.Drawing.Point(1076, 758);
            this.Hide.Name = "Hide";
            this.Hide.Size = new System.Drawing.Size(216, 67);
            this.Hide.TabIndex = 13;
            this.Hide.Text = "Reach Level 15 to Unlock";
            this.Hide.UseVisualStyleBackColor = true;
            this.Hide.Click += new System.EventHandler(this.Hide_Click);
            // 
            // ChangeDelay
            // 
            this.ChangeDelay.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChangeDelay.Location = new System.Drawing.Point(457, 848);
            this.ChangeDelay.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.ChangeDelay.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ChangeDelay.Name = "ChangeDelay";
            this.ChangeDelay.ReadOnly = true;
            this.ChangeDelay.Size = new System.Drawing.Size(43, 50);
            this.ChangeDelay.TabIndex = 14;
            this.ChangeDelay.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.ChangeDelay.ValueChanged += new System.EventHandler(this.ChangeDelay_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(506, 856);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(230, 37);
            this.label1.TabIndex = 15;
            this.label1.Text = "Seconds Delay";
            // 
            // BattleField
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1684, 920);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ChangeDelay);
            this.Controls.Add(this.Hide);
            this.Controls.Add(this.AoE);
            this.Controls.Add(this.FocusPower);
            this.Controls.Add(this.Focus);
            this.Controls.Add(this.Rapid);
            this.Controls.Add(this.Power);
            this.Controls.Add(this.Inventory);
            this.Controls.Add(this.Start);
            this.Controls.Add(this.Accurate);
            this.Controls.Add(this.Output);
            this.Controls.Add(this.Respawn);
            this.Controls.Add(this.Current);
            this.Controls.Add(this.EnemySide);
            this.Controls.Add(this.PlayerSide);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "BattleField";
            this.Text = "BattleField";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BattleField_FormClosing);
            this.PlayerSide.ResumeLayout(false);
            this.PlayerSide.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Ally2Image)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.YouImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ally1Image)).EndInit();
            this.EnemySide.ResumeLayout(false);
            this.EnemySide.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Enemy3Image)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Enemy2Image)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Enemy1Image)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Enemy6Image)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Enemy5Image)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Enemy4Image)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FocusPower)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChangeDelay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel PlayerSide;
        private System.Windows.Forms.Label Ally2;
        private System.Windows.Forms.Label You;
        private System.Windows.Forms.Label Ally1;
        private System.Windows.Forms.Panel EnemySide;
        private System.Windows.Forms.Label Enemy6;
        private System.Windows.Forms.Label Enemy5;
        private System.Windows.Forms.Label Enemy4;
        private System.Windows.Forms.Label Enemy3;
        private System.Windows.Forms.Label Enemy2;
        private System.Windows.Forms.Label Enemy1;
        private System.Windows.Forms.Label Current;
        private System.Windows.Forms.Label Respawn;
        public System.Windows.Forms.TextBox Output;
        private System.Windows.Forms.RadioButton TargetEnemy6;
        private System.Windows.Forms.RadioButton TargetEnemy5;
        private System.Windows.Forms.RadioButton TargetEnemy4;
        private System.Windows.Forms.RadioButton TargetEnemy3;
        private System.Windows.Forms.RadioButton TargetEnemy2;
        private System.Windows.Forms.RadioButton TargetEnemy1;
        private System.Windows.Forms.Button Accurate;
        public System.Windows.Forms.Button Start;
        private System.Windows.Forms.Button Inventory;
        private System.Windows.Forms.Button Power;
        private System.Windows.Forms.Button Rapid;
        private System.Windows.Forms.CheckBox Focus;
        private System.Windows.Forms.TrackBar FocusPower;
        private System.Windows.Forms.ProgressBar Ally2Health;
        private System.Windows.Forms.ProgressBar YourHealth;
        private System.Windows.Forms.ProgressBar Ally1Health;
        private System.Windows.Forms.ProgressBar Enemy6Health;
        private System.Windows.Forms.ProgressBar Enemy4Health;
        private System.Windows.Forms.ProgressBar Enemy5Health;
        private System.Windows.Forms.ProgressBar Enemy3Health;
        private System.Windows.Forms.ProgressBar Enemy2Health;
        private System.Windows.Forms.ProgressBar Enemy1Health;
        private System.Windows.Forms.Button AoE;
        private System.Windows.Forms.Button Hide;
        private System.Windows.Forms.PictureBox Ally2Image;
        private System.Windows.Forms.PictureBox YouImage;
        private System.Windows.Forms.PictureBox Ally1Image;
        private System.Windows.Forms.PictureBox Enemy3Image;
        private System.Windows.Forms.PictureBox Enemy2Image;
        private System.Windows.Forms.PictureBox Enemy1Image;
        private System.Windows.Forms.PictureBox Enemy6Image;
        private System.Windows.Forms.PictureBox Enemy5Image;
        private System.Windows.Forms.PictureBox Enemy4Image;
        private System.Windows.Forms.NumericUpDown ChangeDelay;
        private System.Windows.Forms.Label label1;
    }
}