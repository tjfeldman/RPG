using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RPG
{
    /// <summary>
    /// Pick the class of your character and return the selected character back to the main program
    /// </summary>
    public partial class YourClass : Form
    {
        private Program game;
        bool selected = false;
        public YourClass(Program game)
        {
            InitializeComponent();
            this.game = game;
            ArcherDetails.Text = new Archer(game.world).displayStat();
            WarriorDetails.Text = new Warrior(game.world).displayStat();
            MageDetails.Text = new Mage(game.world).displayStat();
        }

        private void YourClass_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!selected)
            {
                e.Cancel = true;
                new Popup("Sorry, but you haven't selected anything").Show();
            }
            else
            {
                game.nextStep();
            }
        }

        private void Archer_Click(object sender, EventArgs e)
        {
            game.classSelected = new Archer(game.world);
            selected = true;
            this.Close();

        }

        private void Warrior_Click(object sender, EventArgs e)
        {
            selected = true;
            game.classSelected = new Warrior(game.world);
            this.Close();

        }

        private void Mage_Click(object sender, EventArgs e)
        {
            selected = true;
            game.classSelected = new Mage(game.world);
            this.Close();

        }

        
    }
}
