using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG
{
    sealed class Normal:Enemy
    {
        public Normal()
        {
            title = "normal";
        }

        public override void getStats(int level)
        {
            if (level == 1)
                level = 2;
            Random r = Program.r;
            atk = (int)(Math.Round((r.Next(20, 26) + (level * 4.5)), 0));
            def = (int)(Math.Round((r.Next(15, 21) + (level * 4.5)), 0));
            hp = (int)(Math.Round((r.Next(30, 46) + (level * 10.5)), 0));
            spd = (int)(Math.Round((r.Next(15, 31) + (level * 4.5)), 0));
            maxhp = hp;
            this.level = level;
            getName();
            base.getStats(level);
        }

        private void getName()
        {
            string[] names = { "Cheese", "PacMan", "Ms. PacMan", "NomNom", "Yellow Ball of Death" };
            Random r = Program.r;
            title = names[r.Next(0, names.Length)];
        }

        public override string name()
        {
            return "" + title;         
        }

        public override int xp()
        {
            int xp = (int)(Math.Round(((75 * level) / 3.25), 0));
            return xp;
        }

        public override void loot(bool x, BattleField field)
        {
            Random r = Program.r;
            int chance = r.Next(101);
            if (x)//with theif: 5% to get 2 potions based on level or higher ,50% to get an advanced potion or higher(95%),15% to get a revive or a mega revive(5%),15% to get a new weapon, 15% to get armor
            {
                if (chance <= 15)
                {
                    field.currentGame().weapon();//ask user who gets new weapon
                }
                else if (chance <= 15)
                {
                    field.currentGame().armor();
                }
                else if (chance <= 45)
                {
                    if (r.Next(101) <= 5)
                    {
                        Program.AddLoot(new MaxRevive());
                        field.Output.Text += ("You looted 2 revive potion\r\n");
                    }
                    else
                    {
                        Program.AddLoot(new Revive());
                        field.Output.Text += ("You looted 1 revive potion\r\n");
                    }
                }
                else if (chance <= 95)
                {
                    if (r.Next(101) <= 5)
                    {
                        Program.AddLoot(new MaxRevive());
                        field.Output.Text += ("You looted 1 max revive \r\n");
                    }
                    else
                    {
                        if (level >= 50)
                        {
                            Program.AddLoot(new Mega());
                            field.Output.Text += ("You looted 1 mega potion \r\n");
                        }
                        else if (level >= 20)
                        {
                            Program.AddLoot(new Super());
                            field.Output.Text += ("You looted 1 super potion \r\n");
                        }
                        else
                        {
                            Program.AddLoot(new Advanced());
                            field.Output.Text += ("You looted 1 advanced potion \r\n");
                        }
                    }
                }
                else
                {
                    if (level >= 60)
                    {
                        for (int y = 0; y < 2; y++)
                            Program.AddLoot(new Mega());
                        field.Output.Text += ("You looted 2 mega potion \r\n");
                    }
                    else if (level >= 30)
                    {
                        for (int y = 0; y < 2; y++)
                            Program.AddLoot(new Super());
                        field.Output.Text += ("You looted 2 super potion \r\n");
                    }
                    else if (level >= 10)
                    {
                        for (int y = 0; y < 2; y++)
                            Program.AddLoot(new Advanced());
                        field.Output.Text += ("You looted 2 advanced potion \r\n");
                    }
                    else
                    {
                        for (int y = 0; y < 2; y++)
                            Program.AddLoot(new Basic());
                        field.Output.Text += ("You looted 2 basic potion \r\n");
                    }
                }

            }
            else//without theif: 10% to chance 2 potions based on level ,10% chance to get a revive ,10% to get a weapon, 10% to get armor,60% to get a potion based on level
            {
                if (chance <= 60)
                {
                    if (level >= 50)
                    {
                        Program.AddLoot(new Mega());
                        field.Output.Text += ("You looted 1 mega potion \r\n");
                    }
                    else if (level >= 25)
                    {
                        Program.AddLoot(new Super());
                        field.Output.Text += ("You looted 1 super potion \r\n");
                    }
                    else if (level >= 5)
                    {
                        Program.AddLoot(new Advanced());
                        field.Output.Text += ("You looted 1 advanced potion \r\n");
                    }
                    else
                    {
                        Program.AddLoot(new Basic());
                        field.Output.Text += ("You looted 1 basic potion \r\n");
                    }
                }
                else if (chance <= 70)
                {
                    if (r.Next(101) <= 5)
                    {
                        Program.AddLoot(new MaxRevive());
                        field.Output.Text += ("You looted 1 max revive potion \r\n");
                    }
                    else
                    {
                        Program.AddLoot(new Revive());
                        field.Output.Text += ("You looted 1 revive potion \r\n");
                    }
                }
                else if (chance <= 80)
                {
                    field.currentGame().weapon();//ask user who gets new weapon
                }
                else if (chance <= 90)
                {
                    field.currentGame().armor();
                }
                else
                {
                    if (level >= 60)
                    {
                        for (int y = 0; y < 2; y++)
                            Program.AddLoot(new Mega());
                        field.Output.Text += ("You looted 2 mega potions \r\n");
                    }
                    else if (level >= 30)
                    {
                        for (int y = 0; y < 2; y++)
                            Program.AddLoot(new Super());
                        field.Output.Text += ("You looted 2 super potions \r\n");
                    }
                    else if (level >= 10)
                    {
                        for (int y = 0; y < 2; y++)
                            Program.AddLoot(new Advanced());
                        field.Output.Text += ("You looted 2 advanced potions \r\n");
                    }
                    else
                    {
                        for (int y = 0; y < 2; y++)
                            Program.AddLoot(new Basic());
                        field.Output.Text += ("You looted 2 basic potions \r\n");
                    }
                }
            }
        }
    }
}
