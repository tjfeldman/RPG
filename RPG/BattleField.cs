using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace RPG
{
    public partial class BattleField : Form, Confirmation
    {
        private Program game;
        private Dungeon dungeon;
        private Label[] locations;
        private PictureBox[] enemyimages;
        private RadioButton[] targetenemies;
        public bool Human = false;
        private int target = 0;
        private Queue<SpeedList> attackOrder = new Queue<SpeedList>();
        private List<Button> buttons = new List<Button>();
        private List<ProgressBar> healthbars = new List<ProgressBar>();
        private List<Enemy> enemies;
        private bool moveon = false;
        private bool canClose = false;
        int pmana;
        int rmana;
        int amana;
        int hmana;
        int extra = 0;
        int extraatk = 0;
        int extracrit = 0;
        int extramana = 0;
        int extraacc = 0;
        public BattleField(Program game, List<Enemy> enemies, Dungeon dungeon)
        {
            this.game = game;
            this.enemies = enemies;
            this.dungeon = dungeon;
            InitializeComponent();
            Label[] temp = { Enemy1, Enemy2, Enemy3, Enemy4, Enemy5, Enemy6 };
            locations = temp;
            PictureBox[] temp2 = { Enemy1Image, Enemy2Image, Enemy3Image, Enemy4Image, Enemy5Image, Enemy6Image };
            enemyimages = temp2;
            RadioButton[] temp3 = { TargetEnemy1, TargetEnemy2, TargetEnemy3, TargetEnemy4, TargetEnemy5, TargetEnemy6 };
            targetenemies = temp3;
            for (int x = 0; x < locations.Length; x++)
                locations[x].Text = " ";
            foreach (Enemy x in enemies)
            {
                x.getStats(game.player.level);
                if (x is Shadow)
                {
                    ((Shadow)x).getStats(game.player.level);
                    game.ShadowBoss();
                }
                if (x is Sniper)
                {
                    ((Sniper)x).getStats(game.player.level);
                    game.SniperBoss();
                    Output.Text += "\r\nThe Sniper is hidden behind " + enemies[((Sniper)x).location].name();
                }
                if (x is Crowman)
                {
                    ((Crowman)x).getStats(game.player.level);
                    game.CrowmanBoss();
                }
            }
            setButtons();
            setField();
            ChangeDelay.Value = (Program.DELAY / 1000);
            
        }

        /// <summary>
        /// adds new enemy to the attack order
        /// </summary>
        /// <param name="x"></param>
        public void addNewEnemy(Enemy x)
        {
            attackOrder.enqueue(new SpeedList(x.speed,x));
        }

        /// <summary>
        /// when you use an item, have player move on.
        /// </summary>
        public void playerWent()
        {
            attackOrder.dequeue();
        }

        /// <summary>
        /// Empty the attack order
        /// </summary>
        public void emptyOrder()
        {
            attackOrder.Empty();
        }

        /// <summary>
        /// return the current game
        /// </summary>
        /// <returns></returns>
        public Program currentGame()
        {
            return game;
        }

        /// <summary>
        /// use for confirmation window
        /// </summary>
        public bool sure
        {
            get { return moveon; }
            set { moveon = value; }
        }

        /// <summary>
        /// each room, re-create field
        /// </summary>
        public void setField()
        {
            refreshDisplay();
            setRoomCounters();
            attackOrder = game.CreateQueue();
            DisplayWhoIsNext();
            TargetEnemy1.Checked = true;
        }


        /// <summary>
        /// refreshes field
        /// </summary>
        public void refreshDisplay()
        {
            setFirstAlly(game.PlayerTeam[0]);
            setYou(game.PlayerTeam[1]);
            setSecondAlly(game.PlayerTeam[2]);
            setEnemies();
            pmana = 4 + 1 * game.player.level;
            rmana = 8 + 2 * game.player.level;
            amana = 12 + 3 * game.player.level;
            hmana = 16 + 4 * game.player.level;
            refreshButtons();
            changeEnergy();
            if (Start.Text.Equals("Exit"))
                Start.Enabled = true;
        }

        /// <summary>
        /// have right buttons on and right buttons off, make attack buttons have correct mana adjustments
        /// </summary>
        public void refreshButtons()
        {
            int deduct = getDeduction();
            if (Human)
            {
                foreach (Button x in buttons)
                    x.Enabled = true;
            if (game.player.energy < extramana - deduct) { Focus.Checked = false; }
            if (game.player.energy < pmana + extramana - deduct) { Power.Enabled = false; }
            else {  Power.Enabled = true; }
            if (game.player.energy < rmana + extramana - deduct) { Rapid.Enabled = false; }
            else { Rapid.Enabled = true; }
            if (game.learnA && game.player.energy < amana + extramana - deduct) { AoE.Enabled = false; }
            else { AoE.Enabled = true; }
            if (game.learnH && game.player.energy < hmana + extramana - deduct) { Hide.Enabled = false; }
            else { Hide.Enabled = true; }
            }
            else
            {
                foreach (Button x in buttons)
                    x.Enabled = false;
            }
            int extraenergy = extramana - deduct;
            if (extraenergy < 0)
                extraenergy = 0;
            Accurate.Text = "Accurate Attack(" + extraenergy + " energy)";
            extraenergy = extramana - deduct + pmana;
            if (extraenergy < 0)
                extraenergy = 0;
            Power.Text = "Power Attack(" + (extraenergy) + " energy)";
            extraenergy = extramana - deduct + rmana;
            if (extraenergy < 0)
                extraenergy = 0;
            Rapid.Text = "Rapid Attack(" + (extraenergy) + " energy)";
            if (game.learnA)
            {
                extraenergy = extramana - deduct + amana;
                if (extraenergy < 0)
                    extraenergy = 0;
                if (game.player is Warrior)
                    AoE.Text = "Wide Slash(" + (extraenergy) + " energy)";
                else if (game.player is Archer)
                    AoE.Text = "Volley(" + (extraenergy) + " energy)";
                else if (game.player is Mage)
                    AoE.Text = "Splash Attack(" + (extraenergy) + " energy)";
            }
            else
                AoE.Enabled = false;
            if (game.learnH)
            {
                extraenergy = extramana - deduct + hmana;
                if (extraenergy < 0)
                    extraenergy = 0;
                Hide.Text = "Hide(" + (extraenergy) + " energy)";
            }
            else
                Hide.Enabled = false;
            if (Start.Text.Equals("Exit"))
                Start.Enabled = false;
            if (Start.Enabled)
                foreach (Button x in buttons)
                    x.Enabled = false;

        }

        /// <summary>
        /// return the amount of energy your team loses
        /// </summary>
        /// <returns></returns>
        public int getDeduction()
        {
            int deduct = 0;
            foreach (Hero x in game.PlayerTeam)
            {
                deduct += x.getWeapon().deduction;
            }
            return deduct;
        }

        /// <summary>
        /// find the person who moves next
        /// </summary>
        public void move()
        {
            canClose = false;
            bool display = false;
            while (!display && game.enemiesAlive())
            {
                if (!attackOrder.isEmpty())
                {
                    if (attackOrder.peek().person is Warrior || attackOrder.peek().person is Mage || attackOrder.peek().person is Archer)
                    {
                        Human = true;
                        Output.Text += "\r\nYour Turn:";
                        display = true;
                    }
                    else if (attackOrder.peek().person is Hero)
                        if (((Hero)attackOrder.peek().person).health > 0)
                        {
                            Output.Text += "\r\n" + ((Hero)attackOrder.peek().person).name() + "'s turn:";
                            display = true;
                        }
                        else
                            attackOrder.dequeue();
                    else
                        if (((Enemy)attackOrder.peek().person).health > 0)
                        {
                            Output.Text += "\r\n" + ((Enemy)attackOrder.peek().person).name() + "'s turn:";
                            display = true;
                        }
                        else
                            attackOrder.dequeue();
                }
                else 
                {
                    attackOrder = game.CreateQueue();
                    DisplayWhoIsNext();
                    display = true;
                }
            }
            refreshDisplay();
        }

        /// <summary>
        /// Display what room you are in and what room you'll respawn in if you die
        /// </summary>
        public void setRoomCounters()
        {
            Current.Text = "Current Room: " +  dungeon.Current();
            Respawn.Text = "Rooms Left til Boss: " + dungeon.RoomsLeft();
        }

        /// <summary>
        /// add all buttons and enemy health bars to a list for ease of use
        /// </summary>
        public void setButtons()
        {
            buttons.Add(Accurate);
            buttons.Add(Power);
            buttons.Add(Rapid);
            buttons.Add(AoE);
            buttons.Add(Hide);
            healthbars.Add(Enemy1Health);
            healthbars.Add(Enemy2Health);
            healthbars.Add(Enemy3Health);
            healthbars.Add(Enemy4Health);
            healthbars.Add(Enemy5Health);
            healthbars.Add(Enemy6Health);
        }


        #region SetField
        /// <summary>
        /// display all enemies
        /// </summary>
        public void setEnemies()
        {
            for (int x = 0; x < game.cap() ; x++)
            {
                
                if (enemies.Count <= x)
                {
                    enemyimages[x].Image = Properties.Resources.None;
                    locations[x].Text = " ";
                    healthbars[x].Visible = false;
                }
                else
                {
                    healthbars[x].Visible = true;
                    if (enemies[x] is Crowman)
                    {
                        if (((Crowman)enemies[x]).hide)
                            healthbars[x].Visible = false;
                    }
                    if (enemies[x] is Sniper)
                    {
                        if (((Sniper)enemies[x]).hide)
                            healthbars[x].Visible = false;
                    }
                    healthbars[x].Maximum = enemies[x].maxhealth;
                    healthbars[x].Value = enemies[x].health;
                    locations[x].Text = enemies[x] + "\r\nSpeed:" + enemies[x].speed;
                    Attacks attack = null;
                    if (enemies[x].health > 0)
                    {
                        if (enemies[x] is Minor)
                        {
                            foreach (Attacks y in game.world.attackList())
                            {
                                if (y.attackName().Equals("Minor"))
                                {
                                    attack = y;
                                    break;
                                }
                            }
                            if (enemies[x].name().Equals("Inky"))
                                enemyimages[x].Image = Properties.Resources.Inky;
                            if (enemies[x].name().Equals("Pinky"))
                                enemyimages[x].Image = Properties.Resources.Pinky;
                            if (enemies[x].name().Equals("Clyde"))
                                enemyimages[x].Image = Properties.Resources.Clyde;
                            if (enemies[x].name().Equals("Blinky"))
                                enemyimages[x].Image = Properties.Resources.Blinky;
                            
                        }
                        else if (enemies[x] is Normal)
                        {
                            foreach (Attacks y in game.world.attackList())
                            {
                                if (y.attackName().Equals("Normal"))
                                {
                                    attack = y;
                                    break;
                                }
                            }
                            if (enemies[x].name().Equals("Ms. PacMan"))
                                enemyimages[x].Image = Properties.Resources.Ms__Pacman;
                            else
                                enemyimages[x].Image = Properties.Resources.Pacman;
                        }
                        else if (enemies[x] is Shadow)
                        {
                            foreach (Attacks y in game.world.attackList())
                            {
                                if (y.attackName().Equals("Shadow"))
                                {
                                    attack = y;
                                    break;
                                }
                            }
                            enemyimages[x].Image = Properties.Resources.Shadow;
                        }
                        else if (enemies[x] is Sniper)
                        {
                            foreach (Attacks y in game.world.attackList())
                            {
                                string test = y.attackName();
                                test = test.Trim();
                                if (test.Equals("Sniper"))
                                {
                                    attack = y;
                                    break;
                                }
                            }
                            enemyimages[x].Image = Properties.Resources.Sniper;
                        }
                        else if (enemies[x] is Greater)
                        {
                            foreach (Attacks y in game.world.attackList())
                            {
                                if (y.attackName().Equals("Greater"))
                                {
                                    attack = y;
                                    break;
                                }
                            }
                            enemyimages[x].Image = Properties.Resources.Greater;
                        }
                        else if (enemies[x] is Ninja)
                        {
                            foreach (Attacks y in game.world.attackList())
                            {
                                if (y.attackName().Equals("Ninja"))
                                {
                                    attack = y;
                                    break;
                                }
                            }
                            enemyimages[x].Image = Properties.Resources.Ninja;
                        }
                        else if (enemies[x] is Crowman)
                        {
                            foreach (Attacks y in game.world.attackList())
                            {
                                if (y.attackName().Equals("Crowman"))
                                {
                                    attack = y;
                                    break;
                                }
                            }
                            enemyimages[x].Image = Properties.Resources.Crowman;
                        }
                    enemies[x].setBaseDamage(attack.basePower());
                    enemies[x].accucary = attack.accucary();
                    }
                    
                }

            }
            for (int x = 0; x < game.cap(); x++)
            {
                if (enemies.Count <= x)
                {
                    targetenemies[x].Enabled = false;
                    targetenemies[x].Visible = false;
                }
                else
                {
                    targetenemies[x].Visible = true;
                    if (enemies[x].health <= 0)
                        targetenemies[x].Enabled = false;
                    else if (enemies[x] is Sniper)
                    {
                        if (((Sniper)enemies[x]).hide)
                            targetenemies[x].Enabled = false;
                        else
                            targetenemies[x].Enabled = true;
                    }
                    else
                        targetenemies[x].Enabled = true;
                       

                }
            }

        }
        /// <summary>
        /// display your first ally
        /// </summary>
        /// <param name="x"></param>
        public void setFirstAlly(Hero x)
        {
            Ally1.Text = x + "\r\n" + x.stats();
            if (x is Healer)
                Ally1Image.Image = Properties.Resources.Healer;
            if (x is Theif)
                Ally1Image.Image = Properties.Resources.Thief;
            if (x is Rogue)
                Ally1Image.Image = Properties.Resources.Rogue;
            if (x is Wizard)
                Ally1Image.Image = Properties.Resources.Wizard;
            if (x is Guard)
                Ally1Image.Image = Properties.Resources.Guard;
            if (x is Scout)
                Ally1Image.Image = Properties.Resources.Scout;
            Ally1Health.Maximum = x.maxhealth;
            Ally1Health.Value = x.health;
        }
        /// <summary>
        /// display your second ally
        /// </summary>
        /// <param name="x"></param>
        public void setSecondAlly(Hero x)
        {
            Ally2.Text = x + "\r\n" + x.stats();
            if (x is Healer)
                Ally2Image.Image = Properties.Resources.Healer;
            if (x is Theif)
                Ally2Image.Image = Properties.Resources.Thief;
            if (x is Rogue)
                Ally2Image.Image = Properties.Resources.Rogue;
            if (x is Wizard)
                Ally2Image.Image = Properties.Resources.Wizard;
            if (x is Guard)
                Ally2Image.Image = Properties.Resources.Guard;
            if (x is Scout)
                Ally2Image.Image = Properties.Resources.Scout;
            Ally2Health.Maximum = x.maxhealth;
            Ally2Health.Value = x.health;
        }
        /// <summary>
        /// display yourself
        /// </summary>
        /// <param name="x"></param>
        public void setYou(Hero x)
        {
            You.Text = x + "\r\n" + x.stats();
            if (x is Warrior)
                YouImage.Image = Properties.Resources.Warrior;
            if (x is Archer)
                YouImage.Image = Properties.Resources.Archer;
            if (x is Mage)
                YouImage.Image = Properties.Resources.Mage;
            YourHealth.Maximum = x.maxhealth;
            YourHealth.Value = x.health;
        }
        #endregion


        #region Select Target
        /// <summary>
        /// When a target enemy is selected, that spefic location will be kept and sent to the game for when you pick your attack
        /// </summary>

        private void TargetEnemy4_CheckedChanged(object sender, EventArgs e)
        {
            if (TargetEnemy4.Checked)
                target = 3;
        }

        private void TargetEnemy1_CheckedChanged(object sender, EventArgs e)
        {
            if (TargetEnemy1.Checked)
                target = 0;
        }

        private void TargetEnemy2_CheckedChanged(object sender, EventArgs e)
        {
            if (TargetEnemy2.Checked)
                target = 1;
        }

        private void TargetEnemy3_CheckedChanged(object sender, EventArgs e)
        {
            if (TargetEnemy3.Checked)
                target = 2;
        }

        private void TargetEnemy5_CheckedChanged(object sender, EventArgs e)
        {
            if (TargetEnemy5.Checked)
                target = 4;
        }

        private void TargetEnemy6_CheckedChanged(object sender, EventArgs e)
        {
            if (TargetEnemy6.Checked)
                target = 5;
        }
        #endregion

        /// <summary>
        /// Display the next fighter
        /// </summary>
        private void DisplayWhoIsNext()
        {
            if (attackOrder.peek().person is Hero && !(attackOrder.peek().person is Warrior || attackOrder.peek().person is Archer || attackOrder.peek().person is Mage))
                Output.Text += "\r\n" + ((Hero)attackOrder.peek().person).name() + "'s turn:";
            else if (attackOrder.peek().person is Enemy)
                Output.Text += "\r\n" + ((Enemy)attackOrder.peek().person).name() + "'s turn:";
            else
            {
                Human = true;
                Output.Text += "\r\nYour Turn:";
                refreshButtons();
            }
        }

        #region Attack Buttons

        /// <summary>
        /// make sure target can be attacked and have your player attack that target
        /// </summary>
        /// <param name="attack"></param>
        /// <param name="mana"></param>
        private void attack(string attack, int mana)
        {
            int deduct = getDeduction();
            bool hiding = false;
            if (!attack.Equals("Hide"))
            {
                if (!targetenemies[target].Enabled)
                {
                    Output.Text += "\r\nSorry, but you cannot attack that target";
                    hiding = true;
                }
                else if (enemies[target] is Sniper)
                {
                    if (((Sniper)enemies[target]).hide)
                    {
                        Output.Text += "\r\nSorry that enemy is in hiding, you cannot attack it";
                        hiding = true;
                    }
                }
            }
            if (!hiding)
            {
                game.PlayerAttack(this, attack, target, mana + extramana - deduct, extracrit, extraacc, extraatk);
                Human = false;
                attackOrder.dequeue();
                if (attackOrder.isEmpty())//when everyone has attacked, recreate Queue
                {
                    attackOrder = game.CreateQueue();
                }
                move();
                canClose = true;
                game.checkLoss(this);
                canClose = false;
            }
            refreshDisplay();
            this.Update();
            if (!game.Lost())
            {
                Thread.Sleep(Program.DELAY);
                Battle();
            }
            
        }

        /// <summary>
        /// perform accurate attack
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Accurate_Click(object sender, EventArgs e)
        {
            attack("Accurate",0);
        }

        /// <summary>
        /// perform power attack
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Power_Click(object sender, EventArgs e)
        {
            attack("Power",pmana);
        }
        /// <summary>
        /// perform a rapid attack
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Rapid_Click(object sender, EventArgs e)
        {
            attack("Rapid", rmana);
        }

        /// <summary>
        /// perform an Area of Effect attack
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AoE_Click(object sender, EventArgs e)
        {
            attack("AOE", amana);
        }

        /// <summary>
        /// go into hiding
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Hide_Click(object sender, EventArgs e)
        {
            attack("Hide", hmana);
        }

        #endregion

        /// <summary>
        /// if player used a revive to keep himself alive, use a revive
        /// </summary>
        /// <param name="use"></param>
        public void revive(bool use)
        {
            if (use)
            {
                if (!game.RevivePotions().empty())
                {
                    game.RevivePotions().dequeue();
                    game.player.Heal(game.player.calcPercent(50));
                    game.player.energy = game.player.maxenergy;
                }
                else
                {
                    game.MaxRevivePotions().dequeue();
                    game.player.Heal(game.player.calcPercent(100));
                    game.player.energy = game.player.maxenergy;
                }
                move();
                refreshButtons();
            }
            else
            {
                canClose = true;
                game.checkLoss(this);
                canClose = false;
            }
        }

        /// <summary>
        /// Battle, until the enemy side is dead or your side dies. The battle will continue
        /// </summary>
        public void Battle()
        {
            if (!Human)
            {
                Output.Text = "";
                if (!game.Lost())
                {
                    foreach (Hero x in game.PlayerTeam)
                        x.getBoosted();//get the new amount hp the character has
                    if (attackOrder.peek().person is Enemy)
                    {
                        game.enemyAttack((Enemy)attackOrder.peek().person, this);
                    }
                    else if (!(attackOrder.peek().person is Warrior || attackOrder.peek().person is Archer || attackOrder.peek().person is Mage))
                        game.allyAttack((Hero)attackOrder.peek().person, this);
                    attackOrder.dequeue();
                }
                setFirstAlly(game.PlayerTeam[0]);
                setYou(game.PlayerTeam[1]);
                setSecondAlly(game.PlayerTeam[2]);
                setEnemies();
                if (game.enemiesAlive() && game.player.health > 0)
                {
                    if (attackOrder.isEmpty())//when everyone has attacked, recreate Queue
                    {
                        attackOrder = game.CreateQueue();
                        DisplayWhoIsNext();
                    }
                    else if (attackOrder.peek().person is Warrior || attackOrder.peek().person is Mage || attackOrder.peek().person is Archer)
                    {
                        Human = true;
                        Output.Text += "\r\nYour Turn:";
                    }
                    else
                    {
                        move();
                    }

                }
                refreshButtons();
                refreshDisplay();
                this.Update();
                if (game.player.health <= 0)
                {
                    game.useRevive(this);
                }
                else if (!game.enemiesAlive())
                {
                    canClose = true;
                    game.checkLoss(this);
                    canClose = false;
                }
                else if (!Human)
                {
                    Thread.Sleep(Program.DELAY);
                    Battle();
                }
            }

        }

        /// <summary>
        /// do next attack or start battle
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Start_Click(object sender, EventArgs e)
        {
            if (Start.Text.Equals("Exit"))
            {
                canClose = true;
                this.Close();
                game.StartGame();//head on to next room
            }
            else
            {
                Start.Enabled = false;
                if (Human)
                    refreshButtons();
                Battle();
            }
        }

        /// <summary>
        /// check inventory
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Inventory_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            new Inventory(game,this).Show();
            this.Enabled = true;
        }


        /// <summary>
        /// whether or not to use a focused attack
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Focus_CheckedChanged(object sender, EventArgs e)
        {
            if (Focus.Checked)
            {
                extra = FocusPower.Value;
                extraacc = (5 * extra);
                extraatk = (5 * extra);
                if (extra == 3)
                {
                    extraatk = 25;
                }
                else if (extra > 3)
                {
                    extraatk = (10 * extra);
                }
                extracrit = (((extra * 5) / 5) - 1);
                extramana = (int)Math.Round(((extra * 10 / 5) - 1) * (game.player.level / 3.0),0);
                if (extramana <= 0)
                    extramana = 1;
                refreshButtons();
            }
            else
            {
                extra = 0;
                extraatk = 0;
                extracrit = 0;
                extramana = 0;
                refreshButtons();
            }
        }

        /// <summary>
        /// how much power does the focus attack have
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FocusPower_Scroll(object sender, EventArgs e)
        {
            if (Focus.Checked)
            {
                extra = FocusPower.Value;
                extraacc = (5 * extra);
                extraatk = (5 * extra);
                if (extra == 3)
                {
                    extraatk = 25;
                }
                else if (extra > 3)
                {
                    extraatk = (10 * extra);
                }
                extracrit = (((extra * 5) / 5) - 1);
                extramana = (int)Math.Round(((extra * 10 / 5) - 1) * (game.player.level / 3.0), 0);
                if (extramana <= 0)
                    extramana = 1;
                refreshButtons();
            }
            int y = (5 * FocusPower.Value);
            if (FocusPower.Value == 3)
            {
                y = 25;
            }
            else if (FocusPower.Value > 3)
            {
                y = (10 * extra);
            }
            int x = (int)Math.Round(((FocusPower.Value * 10 / 5) - 1) * (game.player.level / 3.0), 0);
            if (x <= 0)
                x = 1;
            Focus.Text = "Focus: " + y + "% damage, " + (5 * FocusPower.Value) + "% accuracy, " + (((FocusPower.Value * 5) / 5) - 1) + "% crit, " + x + " energy";
        }

        /// <summary>
        /// adjust the energy cost of Focus Power based on level
        /// </summary>
        private void changeEnergy()
        {

            extramana = (int)Math.Round(((extra * 10 / 5) - 1) * (game.player.level / 3.0), 0);
            if (extramana < 0)
                extramana = 0;
            int x = (int)Math.Round(((FocusPower.Value * 10 / 5) - 1) * (game.player.level /3.0), 0);
            if (x <= 0)
                x = 1;
            int y = (5 * FocusPower.Value);
            if (FocusPower.Value == 3)
            {
                y = 25;
            }
            else if (FocusPower.Value > 3)
            {
                y = (10 * extra);
            }
            Focus.Text = "Focus: " + y + "% damage, " + (5 * FocusPower.Value) + "% accuracy, " + (((FocusPower.Value * 5) / 5) - 1) + "% crit, " + x + " energy";
        }

        private void BattleField_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!canClose)
                e.Cancel = true;
        }

        private void ChangeDelay_ValueChanged(object sender, EventArgs e)
        {
            Program.DELAY = ((int)ChangeDelay.Value * 1000);
        }

       

    }

}

