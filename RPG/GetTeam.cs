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
    /// get your ally's class and send it back to the game
    /// </summary>
    public partial class GetTeam : Form
    {
        private bool selected = false;
        private Program game;
        public GetTeam(Program game, int count)
        {
            InitializeComponent();
            this.game = game;
            if (count == 2)
                Prompt.Text = "Select second ally's class:";
            HealerDetails.Text = new Healer(game.world).displayStat();
            GuardDetails.Text = new Guard(game.world).displayStat();
            ThiefDetails.Text = new Theif(game.world).displayStat();
            WizardDetails.Text = new Wizard(game.world).displayStat();
            RogueDetails.Text = new Rogue(game.world).displayStat();
            ScoutDetails.Text = new Scout(game.world).displayStat();
        }

        private void GetTeam_FormClosing(object sender, FormClosingEventArgs e)
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

        private void Healer_Click(object sender, EventArgs e)
        {
            selected = true;
            game.classSelected = new Healer(game.world);
            this.Close();
        }

        private void Guard_Click(object sender, EventArgs e)
        {
            selected = true;
            game.classSelected = new Guard(game.world);
            this.Close();
        }

        private void Thief_Click(object sender, EventArgs e)
        {
            selected = true;
            game.classSelected = new Theif(game.world);
            this.Close();

        }

        private void Wizard_Click(object sender, EventArgs e)
        {
            selected = true;
            game.classSelected = new Wizard(game.world);
            this.Close();

        }

        private void Rogue_Click(object sender, EventArgs e)
        {
            selected = true;
            game.classSelected = new Rogue(game.world);
            this.Close();
        }

        private void Scout_Click(object sender, EventArgs e)
        {
            selected = true;
            game.classSelected = new Scout(game.world);
            this.Close();

        }

        
    }
}
