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
    public partial class SelectTarget : Form
    {
        BattleField field;
        Program game;
        Inventory inventory;
        Potion potion;
        public SelectTarget(BattleField field, Program game, Inventory inventory)
        {
            InitializeComponent();
            this.field = field;
            this.game = game;
            this.inventory = inventory;
            Button[] buttons = { Ally1, You, Ally2 };
            for (int x = 0;x < 3; x ++)
            {
                buttons[x].Text = game.PlayerTeam[x] + "";
                if (inventory.type >= 5)
                    if (game.PlayerTeam[x].health > 0)
                        buttons[x].Enabled = false;
                    else
                        buttons[x].Enabled = true;
                else
                    if (game.PlayerTeam[x].health > 0 && game.PlayerTeam[x].health < game.PlayerTeam[x].maxhealth)
                        buttons[x].Enabled = true;
                    else
                        buttons[x].Enabled = false;
            }
            int count = 0;
            foreach (Button x in buttons)
                if (!x.Enabled)
                    count++;
            if (count == 3)
            {
                new Popup("You cannot use that potion");
                inventory.use = false;
                this.Close();
            }
            if (inventory.type == 1)
                potion = new Basic();
            else if (inventory.type == 2)
                potion = new Advanced();
            else if (inventory.type == 3)
                potion = new Super();
            else if (inventory.type == 4)
                potion = new Mega();
            else if (inventory.type == 5)
                potion = new Revive();
            else
                potion = new MaxRevive();

        }

        private void You_Click(object sender, EventArgs e)
        {
            this.Close();
            field.Human = false;
            inventory.use = true;
            field.Output.Text = "";
            game.use(potion, game.PlayerTeam[1],field);
            inventory.checkUse();
        }

        private void Ally1_Click(object sender, EventArgs e)
        {
            this.Close();
            field.Human = false;
            inventory.use = true;
            field.Output.Text = "";
            game.use(potion, game.PlayerTeam[0], field);
            inventory.checkUse();
            
        }

        private void Ally2_Click(object sender, EventArgs e)
        {
            this.Close();
            field.Human = false;
            inventory.use = true;
            field.Output.Text = "";
            game.use(potion, game.PlayerTeam[2], field);
            inventory.checkUse();
           
        }
    }
}
