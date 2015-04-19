namespace RPG
{
    partial class Dungeon
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
            this.Left = new System.Windows.Forms.Button();
            this.Forward = new System.Windows.Forms.Button();
            this.Right = new System.Windows.Forms.Button();
            this.Back = new System.Windows.Forms.Button();
            this.Here = new System.Windows.Forms.Button();
            this.Location = new System.Windows.Forms.Label();
            this.Respawn = new System.Windows.Forms.Label();
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.gameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BeginNewGame = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveGame = new System.Windows.Forms.ToolStripMenuItem();
            this.LoadGame = new System.Windows.Forms.ToolStripMenuItem();
            this.GoToArea = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HowToPlay = new System.Windows.Forms.ToolStripMenuItem();
            this.ItemInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // Left
            // 
            this.Left.Font = new System.Drawing.Font("Microsoft Sans Serif", 32F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Left.Location = new System.Drawing.Point(12, 225);
            this.Left.Name = "Left";
            this.Left.Size = new System.Drawing.Size(318, 186);
            this.Left.TabIndex = 0;
            this.Left.Text = "Go Left";
            this.Left.UseVisualStyleBackColor = true;
            this.Left.Click += new System.EventHandler(this.Left_Click);
            // 
            // Forward
            // 
            this.Forward.Font = new System.Drawing.Font("Microsoft Sans Serif", 32F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Forward.Location = new System.Drawing.Point(459, 12);
            this.Forward.Name = "Forward";
            this.Forward.Size = new System.Drawing.Size(318, 186);
            this.Forward.TabIndex = 1;
            this.Forward.Text = "Go Forward";
            this.Forward.UseVisualStyleBackColor = true;
            this.Forward.Click += new System.EventHandler(this.Forward_Click);
            // 
            // Right
            // 
            this.Right.Font = new System.Drawing.Font("Microsoft Sans Serif", 32F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Right.Location = new System.Drawing.Point(908, 225);
            this.Right.Name = "Right";
            this.Right.Size = new System.Drawing.Size(318, 186);
            this.Right.TabIndex = 2;
            this.Right.Text = "Go Right";
            this.Right.UseVisualStyleBackColor = true;
            this.Right.Click += new System.EventHandler(this.Right_Click);
            // 
            // Back
            // 
            this.Back.Enabled = false;
            this.Back.Font = new System.Drawing.Font("Microsoft Sans Serif", 32F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Back.Location = new System.Drawing.Point(459, 437);
            this.Back.Name = "Back";
            this.Back.Size = new System.Drawing.Size(318, 186);
            this.Back.TabIndex = 3;
            this.Back.Text = "Go Back";
            this.Back.UseVisualStyleBackColor = true;
            this.Back.Click += new System.EventHandler(this.Back_Click);
            // 
            // Here
            // 
            this.Here.Enabled = false;
            this.Here.Font = new System.Drawing.Font("Microsoft Sans Serif", 32F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Here.Location = new System.Drawing.Point(459, 225);
            this.Here.Name = "Here";
            this.Here.Size = new System.Drawing.Size(318, 186);
            this.Here.TabIndex = 4;
            this.Here.Text = "You are Here";
            this.Here.UseVisualStyleBackColor = true;
            // 
            // Location
            // 
            this.Location.AutoSize = true;
            this.Location.Font = new System.Drawing.Font("Microsoft Sans Serif", 32F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Location.Location = new System.Drawing.Point(12, 61);
            this.Location.Name = "Location";
            this.Location.Size = new System.Drawing.Size(412, 51);
            this.Location.TabIndex = 6;
            this.Location.Text = "Checkpoint Room: 1";
            // 
            // Respawn
            // 
            this.Respawn.AutoSize = true;
            this.Respawn.Font = new System.Drawing.Font("Microsoft Sans Serif", 32F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Respawn.Location = new System.Drawing.Point(12, 112);
            this.Respawn.Name = "Respawn";
            this.Respawn.Size = new System.Drawing.Size(412, 51);
            this.Respawn.TabIndex = 7;
            this.Respawn.Text = "Checkpoint Room: 1";
            // 
            // MainMenu
            // 
            this.MainMenu.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gameToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(1238, 29);
            this.MainMenu.TabIndex = 8;
            this.MainMenu.Text = "menuStrip1";
            // 
            // gameToolStripMenuItem
            // 
            this.gameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BeginNewGame,
            this.SaveGame,
            this.LoadGame,
            this.GoToArea});
            this.gameToolStripMenuItem.Name = "gameToolStripMenuItem";
            this.gameToolStripMenuItem.Size = new System.Drawing.Size(63, 25);
            this.gameToolStripMenuItem.Text = "Game";
            // 
            // BeginNewGame
            // 
            this.BeginNewGame.Name = "BeginNewGame";
            this.BeginNewGame.Size = new System.Drawing.Size(162, 26);
            this.BeginNewGame.Text = "New Game";
            this.BeginNewGame.Click += new System.EventHandler(this.BeginNewGame_Click);
            // 
            // SaveGame
            // 
            this.SaveGame.Name = "SaveGame";
            this.SaveGame.Size = new System.Drawing.Size(162, 26);
            this.SaveGame.Text = "Save Game";
            this.SaveGame.Click += new System.EventHandler(this.SaveGame_Click);
            // 
            // LoadGame
            // 
            this.LoadGame.Name = "LoadGame";
            this.LoadGame.Size = new System.Drawing.Size(162, 26);
            this.LoadGame.Text = "Load Game";
            this.LoadGame.Click += new System.EventHandler(this.LoadGame_Click);
            // 
            // GoToArea
            // 
            this.GoToArea.Name = "GoToArea";
            this.GoToArea.Size = new System.Drawing.Size(162, 26);
            this.GoToArea.Text = "Got To Area";
            this.GoToArea.Click += new System.EventHandler(this.GoToArea_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.HowToPlay,
            this.ItemInfo});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(54, 25);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // HowToPlay
            // 
            this.HowToPlay.Name = "HowToPlay";
            this.HowToPlay.Size = new System.Drawing.Size(197, 26);
            this.HowToPlay.Text = "How to Play";
            this.HowToPlay.Click += new System.EventHandler(this.HowToPlay_Click);
            // 
            // ItemInfo
            // 
            this.ItemInfo.Name = "ItemInfo";
            this.ItemInfo.Size = new System.Drawing.Size(197, 26);
            this.ItemInfo.Text = "Item Information";
            this.ItemInfo.Click += new System.EventHandler(this.ItemInfo_Click);
            // 
            // Dungeon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1238, 635);
            this.Controls.Add(this.Respawn);
            this.Controls.Add(this.Location);
            this.Controls.Add(this.Here);
            this.Controls.Add(this.Back);
            this.Controls.Add(this.Right);
            this.Controls.Add(this.Forward);
            this.Controls.Add(this.Left);
            this.Controls.Add(this.MainMenu);
            this.MainMenuStrip = this.MainMenu;
            this.Name = "Dungeon";
            this.Text = "Dungeon";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Dungeon_FormClosing);
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button Left;
        public System.Windows.Forms.Button Forward;
        public System.Windows.Forms.Button Right;
        public System.Windows.Forms.Button Back;
        private System.Windows.Forms.Button Here;
        private System.Windows.Forms.Label Location;
        private System.Windows.Forms.Label Respawn;
        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem gameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem GoToArea;
        private System.Windows.Forms.ToolStripMenuItem BeginNewGame;
        private System.Windows.Forms.ToolStripMenuItem SaveGame;
        private System.Windows.Forms.ToolStripMenuItem LoadGame;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem HowToPlay;
        private System.Windows.Forms.ToolStripMenuItem ItemInfo;
    }
}