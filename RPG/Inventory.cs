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
    public partial class Inventory : Form
    {
        private Program game;
        private BattleField field;
        public bool use = false;
        public int type = 1;
        public bool canuse = true;
        public string error = "";
        public Inventory(Program game, BattleField field)
        {
            InitializeComponent();
            Potions.Text = game.getPotions();
            Ally1Equipment.Text = game.PlayerTeam[0].name() + " has equipped:\r\nWeapon:\r\n" + game.PlayerTeam[0].getWeapon() + "\r\nArmor:\r\n" + game.PlayerTeam[0].getArmor();
            YourEquipment.Text = game.PlayerTeam[1].name() + " has equipped:\r\nWeapon:\r\n" + game.PlayerTeam[1].getWeapon() + "\r\nArmor:\r\n" + game.PlayerTeam[1].getArmor();
            Ally2Equipment.Text = game.PlayerTeam[2].name() + " has equipped:\r\nWeapon:\r\n" + game.PlayerTeam[2].getWeapon() + "\r\nArmor:\r\n" + game.PlayerTeam[2].getArmor();
            this.game = game;
            this.field = field;
            if (!field.Human)
                UsePotion.Visible = false;
            else
                UsePotion.Visible = true;
        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void useBasic_CheckedChanged(object sender, EventArgs e)
        {
            if (useBasic.Checked)
                type = 1;
            
        }

        private void useAdvanced_CheckedChanged(object sender, EventArgs e)
        {
            if (useAdvanced.Checked)
                type = 2;
        }

        private void useSuper_CheckedChanged(object sender, EventArgs e)
        {
            if (useSuper.Checked)
                type = 3;
        }

        private void useMega_CheckedChanged(object sender, EventArgs e)
        {
            if (useMega.Checked)
                type = 4;
        }

        private void useRevive_CheckedChanged(object sender, EventArgs e)
        {
            if (useRevive.Checked)
                type = 5;
        }

        private void useMaxRevive_CheckedChanged(object sender, EventArgs e)
        {
            if (useMaxRevive.Checked)
                type = 6;
        }

        private void Use_Click(object sender, EventArgs e)
        {
            game.CanUse(type, this);
            if (canuse)
            {
                new SelectTarget(field, game, this).Show();
            }
            else
            {
                new Popup(error).Show();
            }
        }

        public void checkUse()
        {
            if (use)
            {
                field.playerWent();
                field.move();
                field.refreshDisplay();
                field.Update();
                this.Close();
                System.Threading.Thread.Sleep(Program.DELAY);
                field.Battle();
            }
        }
    }
}
