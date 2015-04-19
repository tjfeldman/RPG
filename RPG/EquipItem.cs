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
    public partial class EquipItem : Form
    {
        Program game;
        Armor armor;
        Weapon weapon;
        int give = -1;
        bool isWeapon = false;
        public EquipItem(Program game, object x)
        {
            InitializeComponent();
            this.game = game;
            if (x is Armor)
            {
                armor = (Armor)x;
                isWeapon = false;
                Item.Text = "You Looted some Armor, It's stats:\r\n";
                Item.Text += armor;
                Ally1Item.Text = game.PlayerTeam[0].name() + " currently has this armor equipped:\r\n";
                Ally1Item.Text += game.PlayerTeam[0].getArmor();
                YourItem.Text = game.PlayerTeam[1].name() + " currently has this armor equipped:\r\n";
                YourItem.Text += game.PlayerTeam[1].getArmor();
                Ally2Item.Text = game.PlayerTeam[2].name() + " currently has this armor equipped:\r\n";
                Ally2Item.Text += game.PlayerTeam[2].getArmor();
            }
            else if (x is Weapon)
            {
                weapon = (Weapon)x;
                isWeapon = true; 
                Item.Text = "You Looted a Weapon, It's stats:\r\n";
                Item.Text += weapon;
                Ally1Item.Text = game.PlayerTeam[0].name() + " currently has this weapon equipped:\r\n";
                Ally1Item.Text += game.PlayerTeam[0].getWeapon();
                YourItem.Text = game.PlayerTeam[1].name() + " currently has this weapon equipped:\r\n";
                YourItem.Text += game.PlayerTeam[1].getWeapon();
                Ally2Item.Text = game.PlayerTeam[2].name() + " currently has this weapon equipped:\r\n";
                Ally2Item.Text += game.PlayerTeam[2].getWeapon();
            }
            
            
        }

        private void Confirm_Click(object sender, EventArgs e)
        {
            if (give >= 0)
            {
                if (isWeapon)
                    game.PlayerTeam[give].equipWep(weapon);
                else
                    game.PlayerTeam[give].equipArm(armor);
            }
            this.Close();
        }

        private void Toss_CheckedChanged(object sender, EventArgs e)
        {
            if (Toss.Checked)
                give = -1;
        }

        private void EquipAlly1_CheckedChanged(object sender, EventArgs e)
        {
            if (EquipAlly1.Checked)
                give = 0;
        }

        private void EquipYou_CheckedChanged(object sender, EventArgs e)
        {
            if (EquipYou.Checked)
                give = 1;
        }

        private void EquipAlly2_CheckedChanged(object sender, EventArgs e)
        {
            if (EquipAlly2.Checked)
                give = 2;
        }
    }
}
