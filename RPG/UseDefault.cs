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
    
    public partial class UseDefault : Form
    {
        private Program game;
        public UseDefault(Program game)
        {
            InitializeComponent();
            this.game = game;
            Default.Text = "Ally:\r\n" + new Healer(game.world).displayStat() + "\r\n\r\n" + new Warrior(game.world).displayStat() + "\r\n\r\n" + new Scout(game.world).displayStat();
        }

        /// <summary>
        /// if hit, tell game that user wants to use default class
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Yes_Click(object sender, EventArgs e)
        {
            game.yes = true;
            this.Close();
        }

        /// <summary>
        /// if hit, tell game that the user doesn't want to use the default class
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void No_Click(object sender, EventArgs e)
        {
            game.yes = false;
            this.Close();
        }

        private void UseDefault_FormClosing(object sender, FormClosingEventArgs e)
        {
            game.nextStep();
        }
    }
}
