using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Drawing;

namespace RPG
{
    public class SaveLoad
    {
        private Program game;
        private Dungeon dungeon;
        private World world;
        private Room[] room;
        private string saveFileName;
        public SaveLoad(Program game, Dungeon dungeon, World world, Room[] room)
        {
            this.game = game;
            this.dungeon = dungeon;
            this.world = world;
            this.room = room;
        }

        #region Saving
        /// <summary>
        /// save the game
        /// </summary>
        public void save()
        {
            Stream myStream;
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "txt files (*.txt)|*.txt"; // just text
            saveFileDialog.FilterIndex = 1;                    // only one option           
            saveFileDialog.RestoreDirectory = false;           // let player keep opening same directory

            // prompt user:
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = saveFileDialog.OpenFile()) != null)
                {
                    StreamWriter writer = new StreamWriter(myStream);


                    // open stream and write data (if possible):
                    try
                    {
                        // if file is OK, continue with saving:


                        // create save file:
                        saveFileName = saveFileDialog.FileName;

                        writeSaveFile(writer);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Something went wrong in creating save file. Please try again.");
                    }
                    writer.Close();
                } // end writing stream
            }
        }

        /// <summary>
        /// writes save file
        /// </summary>
        /// <param name="writer"></param>
        private void writeSaveFile(StreamWriter writer)
        {
            //Writes your team
            writer.WriteLine(Program.DELAY);
            writer.WriteLine(game.PlayerTeam.Count);
            foreach (Hero x in game.PlayerTeam)
            {
                bool you = (x is Warrior || x is Archer || x is Mage);
                writer.WriteLine(you);
                writer.WriteLine(x.GetType());
                writer.WriteLine(x.name());
                writer.WriteLine(x.level);
                writer.WriteLine(x.realhealth);
                writer.WriteLine(x.realmaxhealth);
                writer.WriteLine(x.experience);
                if (you)
                {
                    writer.WriteLine(x.energy);
                    writer.WriteLine(x.maxenergy);
                }
                writer.WriteLine(x.attack);
                writer.WriteLine(x.defense);
                writer.WriteLine(x.speed);
                writer.WriteLine(x.critial);
                writer.WriteLine(x.getWeapon().attackbonus);
                writer.WriteLine(x.getWeapon().critbonus);
                writer.WriteLine(x.getWeapon().canPoison());
                writer.WriteLine(x.getWeapon().poisondamage);
                writer.WriteLine(x.getWeapon().deduction);
                writer.WriteLine(x.getArmor().hpbonus);
                writer.WriteLine(x.getArmor().defensebonus);
                writer.WriteLine(x.getArmor().canRegen());
                writer.WriteLine(x.getArmor().regenhealth);
            }
            writer.WriteLine(game.learnA);
            writer.WriteLine(game.learnH);
            //Writes your potions
            writer.WriteLine(game.BasicPotions().Length);
            writer.WriteLine(game.AdvancedPotions().Length);
            writer.WriteLine(game.SuperPotions().Length);
            writer.WriteLine(game.MegaPotions().Length);
            writer.WriteLine(game.RevivePotions().Length);
            writer.WriteLine(game.MaxRevivePotions().Length);
            //writes the locations you have gone to
            writer.WriteLine(world.getFileLocation());
            writer.WriteLine(dungeon.lastLocations.Count);
            //writes the enemies found and the color of the buttons
            foreach (DungeonSetup x in dungeon.lastLocations)
            {
                if (x.left != null)
                {
                    writer.WriteLine(x.left.Count);
                    foreach (Enemy y in x.left)
                    {
                        writer.WriteLine(y.GetType());
                    }
                }
                else
                    writer.WriteLine("none");
                if (x.forward != null)
                {
                    writer.WriteLine(x.forward.Count);
                    foreach (Enemy y in x.forward)
                    {
                        writer.WriteLine(y.GetType());
                    }
                }
                else
                    writer.WriteLine("none");
                if (x.right != null)
                {
                    writer.WriteLine(x.right.Count);
                    foreach (Enemy y in x.right)
                    {
                        writer.WriteLine(y.GetType());
                    }
                }
                else
                    writer.WriteLine("none");
                if (x.choice.Count > 0)
                {
                    writer.WriteLine(x.choice.Count);
                    foreach (Enemy y in x.choice)
                    {
                        writer.WriteLine(y.GetType());
                    }
                }
                else
                    writer.WriteLine("none");
                writer.WriteLine(x.leftcolor);
                writer.WriteLine(x.forwardcolor);
                writer.WriteLine(x.rightcolor);
                writer.WriteLine(x.backcolor);
            }
            //writes whether you are backtracking and then info about your current location
            writer.WriteLine(dungeon.backtracking);
            if (dungeon.forwardEnemies != null)
            {
                writer.WriteLine(dungeon.forwardEnemies.Count);
                foreach (Enemy x in dungeon.forwardEnemies)
                {
                    writer.WriteLine(x.GetType());
                }
            }
            else
            {
                writer.WriteLine("no enemies");
            }
            writer.WriteLine(dungeon.Forward.BackColor);
            if (dungeon.leftEnemies != null)
            {
                writer.WriteLine(dungeon.leftEnemies.Count);
                foreach (Enemy x in dungeon.leftEnemies)
                {
                    writer.WriteLine(x.GetType());
                }
            }
            else
                writer.WriteLine("no enemies");
            writer.WriteLine(dungeon.Left.BackColor);
            if (dungeon.rightEnemies != null)
            {
                writer.WriteLine(dungeon.rightEnemies.Count);
                foreach (Enemy x in dungeon.rightEnemies)
                {
                    writer.WriteLine(x.GetType());
                }
            }
            else
                writer.WriteLine("no enemies");
            writer.WriteLine(dungeon.Right.BackColor);
            writer.WriteLine(dungeon.Back.BackColor);
            //writes the positions, count, required til boss, the current area, the max area you can go to
            writer.WriteLine(dungeon.Current());
            writer.WriteLine(dungeon.amount);
            writer.WriteLine(dungeon.requiredRooms);
            writer.WriteLine(dungeon.currentArea());
            writer.WriteLine(dungeon.getAreas());
            new Popup("Game Saved!").Show();
        }
        #endregion

        #region Loading
        public void LoadGame()
        {
            OpenFileDialog dlg = new OpenFileDialog(); // prompt for file
                dlg.Filter = "txt files (*.txt)|*.txt";    // just text
                dlg.FilterIndex = 1;                       // only one option           
                dlg.RestoreDirectory = false;              // let player keep opening same directory
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    using (TextReader reader = File.OpenText(dlg.FileName))
                    {
                        try
                        {
                            Program.DELAY = int.Parse(reader.ReadLine());
                            #region create your team
                            Hero you = null;
                            List<Hero> team = new List<Hero>();
                            int number = int.Parse(reader.ReadLine());
                            for (int x = 0; x < number; x++)
                            {
                                Hero hero;
                                string isYou = reader.ReadLine();
                                if (isYou.Equals("False"))
                                {
                                    string type = reader.ReadLine();
                                    if (type.Equals("RPG.Healer"))
                                    {
                                        hero = new Healer(world);
                                    }
                                    else if (type.Equals("RPG.Guard"))
                                    {
                                        hero = new Guard(world);
                                    }
                                    else if (type.Equals("RPG.Theif"))
                                    {
                                        hero = new Theif(world);
                                    }
                                    else if (type.Equals("RPG.Wizard"))
                                    {
                                        hero = new Wizard(world);
                                    }
                                    else if (type.Equals("RPG.Rogue"))
                                    {
                                        hero = new Rogue(world);
                                    }
                                    else
                                    {
                                        hero = new Scout(world);
                                    }
                                    string name = reader.ReadLine();
                                    int end = name.IndexOf(" the");
                                    name = name.Remove(end);
                                    hero.setName(name);
                                    hero.level = int.Parse(reader.ReadLine());
                                    hero.realhealth = int.Parse(reader.ReadLine());
                                    hero.realmaxhealth = int.Parse(reader.ReadLine());
                                    hero.experience = int.Parse(reader.ReadLine());
                                }
                                else
                                {
                                    string type = reader.ReadLine();
                                    if (type.Equals("RPG.Warrior"))
                                    {
                                        hero = new Warrior(world);
                                    }
                                    else if (type.Equals("RPG.Mage"))
                                    {
                                        hero = new Mage(world);
                                    }
                                    else
                                    {
                                        hero = new Archer(world);
                                    }
                                    you = hero;
                                    hero.setName(reader.ReadLine());
                                    hero.level = int.Parse(reader.ReadLine());
                                    hero.realhealth = int.Parse(reader.ReadLine());
                                    hero.realmaxhealth = int.Parse(reader.ReadLine());
                                    hero.experience = int.Parse(reader.ReadLine());
                                    hero.energy = int.Parse(reader.ReadLine());
                                    hero.maxenergy = int.Parse(reader.ReadLine());
                                }
                                hero.attack = int.Parse(reader.ReadLine());
                                hero.defense = int.Parse(reader.ReadLine());
                                hero.speed = double.Parse(reader.ReadLine());
                                hero.critial = double.Parse(reader.ReadLine());
                                int attack = int.Parse(reader.ReadLine());
                                double crit = double.Parse(reader.ReadLine());
                                bool poison = reader.ReadLine().Equals("True");
                                int damage = int.Parse(reader.ReadLine());
                                int deduct = int.Parse(reader.ReadLine());
                                hero.equipWep(new Weapon(attack, crit, poison, damage, deduct));
                                int hp = int.Parse(reader.ReadLine());
                                int def = int.Parse(reader.ReadLine());
                                bool heal = reader.ReadLine().Equals("True");
                                int regen = int.Parse(reader.ReadLine());
                                hero.equipArm(new Armor(hp, def, heal, regen));
                                team.Add(hero);
                            }
                            game.setTeam(team, you);
                            game.learnA = reader.ReadLine().Equals("True");
                            game.learnH = reader.ReadLine().Equals("True");
                            #endregion
                            #region create the potions
                            Stack<Basic> basic = new Stack<Basic>();
                            Stack<Advanced> advanced = new Stack<Advanced>();
                            Stack<Super> super = new Stack<Super>();
                            Stack<Revive> revive = new Stack<Revive>();
                            Stack<MaxRevive> max = new Stack<MaxRevive>();
                            Stack<Mega> mega = new Stack<Mega>();
                            int amount = int.Parse(reader.ReadLine());
                            for (int x = 0; x < amount; x++)
                            {
                                basic.enqueue(new Basic());
                            }
                            amount = int.Parse(reader.ReadLine());
                            for (int x = 0; x < amount; x++)
                            {
                                advanced.enqueue(new Advanced());
                            }
                            amount = int.Parse(reader.ReadLine());
                            for (int x = 0; x < amount; x++)
                            {
                                super.enqueue(new Super());
                            }
                            amount = int.Parse(reader.ReadLine());
                            for (int x = 0; x < amount; x++)
                            {
                                mega.enqueue(new Mega());
                            }
                            amount = int.Parse(reader.ReadLine());
                            for (int x = 0; x < amount; x++)
                            {
                                revive.enqueue(new Revive());
                            }
                            amount = int.Parse(reader.ReadLine());
                            for (int x = 0; x < amount; x++)
                            {
                                max.enqueue(new MaxRevive());
                            }
                            game.setPotions(basic, advanced, super, mega, revive, max);
                            #endregion
                            //set up World
                            game.world = new World(game, reader.ReadLine());
                            #region Set up Dungeon
                            int locations = int.Parse(reader.ReadLine());
                            #region Past Locations
                            List<DungeonSetup> pastLocations = new List<DungeonSetup>();
                            List<Enemy> LeftEnemies;
                            List<Enemy> RightEnemies;
                            List<Enemy> ForwardEnemies;
                            List<Enemy> Choice;
                            for (int x = 0; x < locations; x++)
                            {
                                LeftEnemies = new List<Enemy>();
                                RightEnemies = new List<Enemy>();
                                ForwardEnemies = new List<Enemy>();
                                Choice = new List<Enemy>();
                                string read = reader.ReadLine();
                                if (!read.Equals("none"))
                                {
                                    int enemies = int.Parse(read);
                                    for (int y = 0; y < enemies; y++)
                                    {
                                        string enemy = reader.ReadLine();
                                        if (enemy.Equals("RPG.Minor"))
                                            LeftEnemies.Add(new Minor());
                                        else if (enemy.Equals("RPG.Normal"))
                                            LeftEnemies.Add(new Normal());
                                        else if (enemy.Equals("RPG.Shadow"))
                                            LeftEnemies.Add(new Shadow());
                                        else if (enemy.Equals("RPG.Greater"))
                                            LeftEnemies.Add(new Greater());
                                        else if (enemy.Equals("RPG.Sniper"))
                                            LeftEnemies.Add(new Sniper());
                                        else if (enemy.Equals("RPG.Ninja"))
                                            LeftEnemies.Add(new Ninja());
                                        else if (enemy.Equals("RPG.Crowman"))
                                            LeftEnemies.Add(new Crowman());
                                    }
                                }
                                else { LeftEnemies = null; }
                                read = reader.ReadLine();
                                if (!read.Equals("none"))
                                {
                                    int enemies = int.Parse(read);
                                    for (int y = 0; y < enemies; y++)
                                    {
                                        string enemy = reader.ReadLine();
                                        if (enemy.Equals("RPG.Minor"))
                                            ForwardEnemies.Add(new Minor());
                                        else if (enemy.Equals("RPG.Normal"))
                                            ForwardEnemies.Add(new Normal());
                                        else if (enemy.Equals("RPG.Shadow"))
                                            ForwardEnemies.Add(new Shadow());
                                        else if (enemy.Equals("RPG.Greater"))
                                            ForwardEnemies.Add(new Greater());
                                        else if (enemy.Equals("RPG.Sniper"))
                                            ForwardEnemies.Add(new Sniper());
                                        else if (enemy.Equals("RPG.Ninja"))
                                            ForwardEnemies.Add(new Ninja());
                                        else if (enemy.Equals("RPG.Crowman"))
                                            ForwardEnemies.Add(new Crowman());
                                    }
                                }
                                else { ForwardEnemies = null; }
                                read = reader.ReadLine();
                                if (!read.Equals("none"))
                                {
                                    int enemies = int.Parse(read);
                                    for (int y = 0; y < enemies; y++)
                                    {
                                        string enemy = reader.ReadLine();
                                        if (enemy.Equals("RPG.Minor"))
                                            RightEnemies.Add(new Minor());
                                        else if (enemy.Equals("RPG.Normal"))
                                            RightEnemies.Add(new Normal());
                                        else if (enemy.Equals("RPG.Shadow"))
                                            RightEnemies.Add(new Shadow());
                                        else if (enemy.Equals("RPG.Greater"))
                                            RightEnemies.Add(new Greater());
                                        else if (enemy.Equals("RPG.Sniper"))
                                            RightEnemies.Add(new Sniper());
                                        else if (enemy.Equals("RPG.Ninja"))
                                            RightEnemies.Add(new Ninja());
                                        else if (enemy.Equals("RPG.Crowman"))
                                            RightEnemies.Add(new Crowman());
                                    }
                                }
                                else { RightEnemies = null; }
                                read = reader.ReadLine();
                                if (!read.Equals("none"))
                                {
                                    int enemies = int.Parse(read);
                                    for (int y = 0; y < enemies; y++)
                                    {
                                        string enemy = reader.ReadLine();
                                        if (enemy.Equals("RPG.Minor"))
                                            Choice.Add(new Minor());
                                        else if (enemy.Equals("RPG.Normal"))
                                            Choice.Add(new Normal());
                                        else if (enemy.Equals("RPG.Shadow"))
                                            Choice.Add(new Shadow());
                                        else if (enemy.Equals("RPG.Greater"))
                                            Choice.Add(new Greater());
                                        else if (enemy.Equals("RPG.Sniper"))
                                            Choice.Add(new Sniper());
                                        else if (enemy.Equals("RPG.Ninja"))
                                            Choice.Add(new Ninja());
                                        else if (enemy.Equals("RPG.Crowman"))
                                            Choice.Add(new Crowman());
                                    }
                                }
                                else { Choice = null; }
                                Color left = Control.DefaultBackColor;
                                Color right= Control.DefaultBackColor;
                                Color forward= Control.DefaultBackColor;
                                Color back= Control.DefaultBackColor;
                                string color = reader.ReadLine();
                                if (color.Equals("Color [Green]"))
                                    left = Color.Green;
                                if (color.Equals("Color [Gold]"))
                                    left = Color.Gold;
                                if (color.Equals("Color [Orange]"))
                                    left = Color.Orange;
                                color = reader.ReadLine();
                                if (color.Equals("Color [Green]"))
                                    forward = Color.Green;
                                if (color.Equals("Color [Gold]"))
                                    forward = Color.Gold;
                                if (color.Equals("Color [Orange]"))
                                    forward = Color.Orange;
                                if (color.Equals("Color [Red]"))
                                    forward = Color.Red;
                                color = reader.ReadLine();
                                if (color.Equals("Color [Green]"))
                                    right = Color.Green;
                                if (color.Equals("Color [Gold]"))
                                    right = Color.Gold;
                                if (color.Equals("Color [Orange]"))
                                    right = Color.Orange;
                                color = reader.ReadLine();
                                if (color.Equals("Color [Green]"))
                                    back = Color.Green;
                                if (color.Equals("Color [Gold]"))
                                    back = Color.Gold;
                                if (color.Equals("Color [Orange]"))
                                    back = Color.Orange;
                                pastLocations.Add(new DungeonSetup(LeftEnemies, ForwardEnemies, RightEnemies, Choice, left, forward, right, back));
                            }
                            dungeon.lastLocations = pastLocations;
                            #endregion
                            #region current choices
                            string backtracking = reader.ReadLine();
                            bool backtrack = backtracking.Equals("True");
                            dungeon.backtracking = backtrack;
                            ForwardEnemies = new List<Enemy>();
                            LeftEnemies = new List<Enemy>();
                            RightEnemies = new List<Enemy>();
                            string enemynum = reader.ReadLine();
                            if (!enemynum.Equals("no enemies"))
                            {
                                int enemies = int.Parse(enemynum);
                                for (int y = 0; y < enemies; y++)
                                {
                                    string enemy = reader.ReadLine();
                                    if (enemy.Equals("RPG.Minor"))
                                        ForwardEnemies.Add(new Minor());
                                    else if (enemy.Equals("RPG.Normal"))
                                        ForwardEnemies.Add(new Normal());
                                    else if (enemy.Equals("RPG.Shadow"))
                                        ForwardEnemies.Add(new Shadow());
                                    else if (enemy.Equals("RPG.Greater"))
                                        ForwardEnemies.Add(new Greater());
                                    else if (enemy.Equals("RPG.Sniper"))
                                        ForwardEnemies.Add(new Sniper());
                                    else if (enemy.Equals("RPG.Ninja"))
                                        ForwardEnemies.Add(new Ninja());
                                    else if (enemy.Equals("RPG.Crowman"))
                                        ForwardEnemies.Add(new Crowman());
                                }
                            }
                            else { ForwardEnemies = null; }
                            string danger = reader.ReadLine();
                            if (danger.Equals("Color [Green]"))
                                dungeon.Forward.BackColor = Color.Green;
                            else if (danger.Equals("Color [Gold]"))
                                dungeon.Forward.BackColor = Color.Gold;
                            else if (danger.Equals("Color [Orange]"))
                                dungeon.Forward.BackColor = Color.Orange;
                            else if (danger.Equals("Color [Red]"))
                                dungeon.Forward.BackColor = Color.Red;
                            else
                                dungeon.Forward.BackColor = Control.DefaultBackColor;
                            enemynum = reader.ReadLine();
                            if (!enemynum.Equals("no enemies"))
                            {
                                int enemies = int.Parse(enemynum);
                                for (int y = 0; y < enemies; y++)
                                {
                                    string enemy = reader.ReadLine();
                                    if (enemy.Equals("RPG.Minor"))
                                        LeftEnemies.Add(new Minor());
                                    else if (enemy.Equals("RPG.Normal"))
                                        LeftEnemies.Add(new Normal());
                                    else if (enemy.Equals("RPG.Shadow"))
                                        LeftEnemies.Add(new Shadow());
                                    else if (enemy.Equals("RPG.Greater"))
                                        LeftEnemies.Add(new Greater());
                                    else if (enemy.Equals("RPG.Sniper"))
                                        LeftEnemies.Add(new Sniper());
                                    else if (enemy.Equals("RPG.Ninja"))
                                        LeftEnemies.Add(new Ninja());
                                    else if (enemy.Equals("RPG.Crowman"))
                                        LeftEnemies.Add(new Crowman());
                                }
                            }
                            else { LeftEnemies = null; }
                            danger = reader.ReadLine();
                            if (danger.Equals("Color [Green]"))
                                dungeon.Left.BackColor = Color.Green;
                            else if (danger.Equals("Color [Gold]"))
                                dungeon.Left.BackColor = Color.Gold;
                            else if (danger.Equals("Color [Orange]"))
                                dungeon.Left.BackColor = Color.Orange;
                            else
                                dungeon.Left.BackColor = Control.DefaultBackColor;
                            enemynum = reader.ReadLine();
                            if (!enemynum.Equals("no enemies"))
                            {
                                int enemies = int.Parse(enemynum);
                                for (int y = 0; y < enemies; y++)
                                {
                                    string enemy = reader.ReadLine();
                                    if (enemy.Equals("RPG.Minor"))
                                        RightEnemies.Add(new Minor());
                                    else if (enemy.Equals("RPG.Normal"))
                                        RightEnemies.Add(new Normal());
                                    else if (enemy.Equals("RPG.Shadow"))
                                        RightEnemies.Add(new Shadow());
                                    else if (enemy.Equals("RPG.Greater"))
                                        RightEnemies.Add(new Greater());
                                    else if (enemy.Equals("RPG.Sniper"))
                                        RightEnemies.Add(new Sniper());
                                    else if (enemy.Equals("RPG.Ninja"))
                                        RightEnemies.Add(new Ninja());
                                    else if (enemy.Equals("RPG.Crowman"))
                                        RightEnemies.Add(new Crowman());
                                }
                            }
                            else { RightEnemies = null; }
                            danger = reader.ReadLine();
                            if (danger.Equals("Color [Green]"))
                                dungeon.Right.BackColor = Color.Green;
                            else if (danger.Equals("Color [Gold]"))
                                dungeon.Right.BackColor = Color.Gold;
                            else if (danger.Equals("Color [Orange]"))
                                dungeon.Right.BackColor = Color.Orange;
                            else
                                dungeon.Right.BackColor = Control.DefaultBackColor;
                            dungeon.leftEnemies = LeftEnemies;
                            dungeon.forwardEnemies = ForwardEnemies;
                            dungeon.rightEnemies = RightEnemies;
                            danger = reader.ReadLine();
                            if (danger.Equals("Color [Green]"))
                                dungeon.Back.BackColor = Color.Green;
                            else if (danger.Equals("Color [Gold]"))
                                dungeon.Back.BackColor = Color.Gold;
                            else if (danger.Equals("Color [Orange]"))
                                dungeon.Back.BackColor = Color.Orange;
                            else
                                dungeon.Back.BackColor = Control.DefaultBackColor;
                            #endregion
                            dungeon.setPosition(int.Parse(reader.ReadLine()));
                            dungeon.amount = int.Parse(reader.ReadLine());
                            dungeon.requiredRooms = int.Parse(reader.ReadLine());
                            dungeon.setCurrentArea(int.Parse(reader.ReadLine()));
                            dungeon.newMax(int.Parse(reader.ReadLine()));
                            #endregion
                            new Popup("Game Loaded!").Show();
                            
                        }
                        catch (Exception)
                        {
                            new Popup("Something went wrong, the file is missing info or is incorrect\r\neither start a new game or try a different file").Show();
                        }
                        reader.Close();
                    }

                }
        }

        #endregion
    }
}
