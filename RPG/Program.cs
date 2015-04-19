using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.IO;
using System.Windows.Forms;
/*
 * Version 5.9
 * Updates: Created UI,delegate damage calc code,Random Dungeon Generator, can go back to areas you have unlocked
 *          You can save and load a game, File I/O for Classes and Attacks, Rewards for beating bosses
 *          Fixed Several Game-Breaking Errors
 * Next Update: 
 * Other Possible Updates: Weapons being more spefic(bows, staffs, swords) + adding class restrictions on weapons, non boss/special room
 * 
 * */
namespace RPG
{
    public class Program
    {
        private static string name;
        private static string tempname = "";
        public List<Enemy> enemies;
        private  List<Hero> team = new List<Hero>();
        private static  Stack<Basic> basic = new Stack<Basic>();
        private static Stack<Advanced> advanced = new Stack<Advanced>();
        private static Stack<Super> super = new Stack<Super>();
        private static Stack<Revive> revive = new Stack<Revive>();
        private static Stack<MaxRevive> max = new Stack<MaxRevive>();
        private static Stack<Mega> mega = new Stack<Mega>();
        public  World world;
        private  Hero you;
        private static  Hero teammate1;
        private static Hero teammate2;
        private static int lastroom;
        private static bool boss;
        public int checkpoint = 1;
        public bool learnA = false;
        public bool learnH = false;
        public const int fieldcap = 6;
        private static int room = 1;
        public int last;
        public bool yes;
        public Hero classSelected;
        public static string output = "";
        public static Random r = new Random();
        private int acc;
        private bool stop = false;
        private static List<Enemy> loot = new List<Enemy>();
        private Dungeon dungeon;
        private int steps = 0;
        private bool done = false;
        private SaveLoad information;
        public static int DELAY = 3000;
        private delegate string damage(int attack, int defense, int level, double crit, double power, object defender, object attacker);

        #region set Team

        /// <summary>
        /// set your team up
        /// </summary>
        /// <param name="team"></param>
        /// <param name="you"></param>
        public void setTeam(List<Hero> team, Hero you)
        {
            this.team = team;
            this.you = you;
        }

        /// <summary>
        /// set up your potions
        /// </summary>
        /// <param name="basics">basic potions</param>
        /// <param name="advances">advanced potions</param>
        /// <param name="supers">super potions</param>
        /// <param name="megas">mega potions</param>
        /// <param name="revives">revives</param>
        /// <param name="maxs">max revives</param>
        public void setPotions(Stack<Basic> basics, Stack<Advanced> advances, Stack<Super> supers, Stack<Mega> megas, Stack<Revive> revives, Stack<MaxRevive> maxs)
        {
            basic = basics;
            advanced = advances;
            super = supers;
            mega = megas;
            revive = revives;
            max = maxs;
        }

        #endregion

        #region Get Sides
        ///Return for Players and Enemies
        public List<Hero> PlayerTeam
        {
            get { return team; }
        }

        public List<Enemy> EnemyTeam
        {
            get { return enemies; }
        }

        public Hero player
        {
            get { return you; }
        }

        public Hero Teammate1
        {
            get { return teammate1; }
        }

        public Hero Teammate2
        {
            get { return teammate2; }
        }

        public int respawnpoint
        {
            get { return checkpoint; }
        }

        public int currentroom
        {
            get { return room; }
        }
        #endregion

        #region Get Potions
        /// <summary>
        /// allow other programs access to the stacks of potions
        /// </summary>
        /// <returns></returns>

        public Stack<Basic> BasicPotions()
        {
            return basic;
        }
        public Stack<Advanced> AdvancedPotions()
        {
            return advanced;
        }
        public Stack<Super> SuperPotions()
        {
            return super;
        }
        public Stack<Mega> MegaPotions()
        {
            return mega;
        }
        public Stack<Revive> RevivePotions()
        {
            return revive;
        }
        public Stack<MaxRevive> MaxRevivePotions()
        {
            return max;
        }
        #endregion

        public SaveLoad getSave()
        {
            return information;
        }

        /// <summary>
        /// return the random 
        /// </summary>
        /// <returns></returns>
        public Random getRandom()
        {
            return r;
        }

        /// <summary>
        /// return the fieldcap
        /// </summary>
        /// <returns></returns>
        public int cap()
        {
            return fieldcap;
        }

        /// <summary>
        /// Create Queue by putting fastest characters in first.
        /// </summary>
        public Queue<SpeedList> CreateQueue()
        {
            Queue<SpeedList> attackOrder = new Queue<SpeedList>();
            List<SpeedList> sort = new List<SpeedList>();
            foreach (Hero x in team)
                sort.Add(new SpeedList(x.speed, x));
            foreach (Enemy x in enemies)
                sort.Add(new SpeedList(x.speed, x));
            foreach (SpeedList x in sort)
                if (x.person is Hero)
                {
                    if (((Hero)x.person).health <= 0)
                        sort.Remove(x);
                }
                else
                {
                    if (((Enemy)x.person).health <= 0)
                        sort.Remove(x);
                }

            while (sort.Count > 0)
            {
                SpeedList fastest = sort[0];
                for (int x = 1; x < sort.Count; x++)
                {
                    if (fastest.spd < sort[x].spd)
                        fastest = sort[x];
                }
                sort.Remove(fastest);
                attackOrder.enqueue(fastest);
            }
            return attackOrder;
        }

        /// <summary>
        /// have character name send the name to here to be put in tempary string so that name can be sent to proper thing to be named
        /// </summary>
        /// <param name="name">a string that contains a legal name</param>
        public void setName(string name)
        {
            tempname = name;
        }

        /// <summary>
        /// Set up game window and create the game
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            new Program();
        }

        /// <summary>
        /// Creates game by getting player's name, the class of his character, the class of his allys and his ally's names
        /// </summary>
        public Program()
        {
           // for (int x = 0; x < 999; x++)
            //    max.enqueue(new MaxRevive());
            world = new World(this);
            lastroom = last;
            dungeon = new Dungeon(this, world);
            information = new SaveLoad(this, dungeon, world, world.Rooms);
            Application.Run(dungeon);
            Application.Exit();
            Environment.Exit(0);
        }

        #region New Game Set Up
        public void newGame()
        {
            output = "";
            team = new List<Hero>();
            basic.earseData();
            advanced.earseData();
            super.earseData();
            mega.earseData();
            revive.earseData();
            max.earseData();
            done = false;
            steps = 0;
            new CharacterName(this, "What is your name?", "").Show();
        }

        public void nextStep()
        {
            if (steps == 0)
            {
                if (!tempname.Equals(""))
                    name = tempname;
                else
                    name = "Hero";
                new UseDefault(this).Show();
            }
            else if (steps > 0 && !yes && !done)
            {
            #region Set up Team
                if (steps == 1)
                {
                    new YourClass(this).Show();
                }
                else if (steps == 2)
                {
                    you = classSelected;
                    you.setName(name);
                    new GetTeam(this, 1).Show();
                }
                else if (steps == 3)
                {
                    teammate1 = classSelected;
                    new CharacterName(this, "What is the " + teammate1.name() + "'s name?", teammate1.name()).Show();
                }
                else if (steps == 4)
                {
                    if (!tempname.Equals(""))
                        teammate1.setName(tempname);
                    tempname = "";
                    team.Add(teammate1);
                    team.Add(you);
                    new GetTeam(this, 1).Show();
                }
                else if (steps == 5)
                {
                    teammate2 = classSelected;
                    new CharacterName(this, "What is the " + teammate2.name() + "'s name?", teammate2.name()).Show();
                }
                else if (steps == 6)
                {
                    if (!tempname.Equals(""))
                        teammate2.setName(tempname);
                    team.Add(teammate2);
                    steps = 2;
                    done = true;
                }
            }
            else if (steps > 0 && yes && !done)//set up default style
            {
                if (steps == 1)
                {
                    you = new Warrior(world);
                    teammate1 = new Healer(world);
                    new CharacterName(this, "What is the " + teammate1.name() + "'s name?", teammate1.name()).Show();
                }
                if (steps == 2)
                {
                    if (!tempname.Equals(""))
                        teammate1.setName(tempname);
                    team.Add(teammate1);
                    tempname = "";
                    team.Add(you);
                    you.setName(name);
                    teammate2 = new Scout(world);
                    new CharacterName(this, "What is the " + teammate2.name() + "'s name?", teammate2.name()).Show();
                }
                if (steps == 3)
                {
                    if (!tempname.Equals(""))
                        teammate2.setName(tempname);
                    team.Add(teammate2);
                    steps = 2;
                    done = true;
                }
            }
            #endregion
            if (done)
            {
                if (steps == 2)
                {
                    foreach (Hero x in team)//give each character a weapon and armor
                    {

                        output += x.AquireWeapon(x);
                        output += x.AquireArmor(x);
                        output += "\r\n";
                    }
                    new Cutscene(output, true, this).Show();
                }
                else if (steps == 3)
                {
                    output += "So begins " + name + "'s Adventure:\r\n";
                    string[] temp = { "So begins " + name + "'s Adventure:", "As you enter the town just on the outskirts of the mysterious cave", "An old man approaches you and says:", "So you are planning on entering that cave?", "As you response with a yes, he says: ", "It's quite dangerous to go alone, take these potions they'll help you in a tight spot", "You got 3 potions, they may be basic but they will heal you 25 hitpoints per a consumption", "You and your team head out to the dungeons" };
                    new Cutscene(temp).Show();
                    for (int x = 0; x < 3; x++)
                        AddLoot(new Basic());
                    dungeon.StartNewGame();
                }

            }
            steps++;
        }

        #endregion
        /// <summary>
        /// when asking if a player wants to do an action or not, this class is called
        /// </summary>
        /// <returns></returns>
        public void StartGame()
        {
            dungeon.next();
        }
        #region Cutscenes
        /// <summary>
        /// cutscene for shadow
        /// </summary>
        public void ShadowBoss()
        {
            boss = true;
            string[] temp = { "You have reached a special room of the dungeon", "It is a boss room, so be careful", "The Boss: Puny adventurers, you think you're so strong to come rushing into my domain", "I am the shadow of everything and I have seen what you can do, YOU WILL NOT WIN!" };
            new Cutscene(temp).Show();
        }

        /// <summary>
        /// cutscene for sniper
        /// </summary>
        public void SniperBoss()
        {
            boss = true;
            string[] temp = { "You have reached a special room of the dungeon", "It is a boss room, so be careful", "The Boss: Puny adventurers, you think you're so strong to come rushing into my domain", "You cannot match the power of my sniper rifle", "The boss runs and hides behind one of the enemies" };
            new Cutscene(temp).Show();
            foreach (Enemy x in enemies)
            {
                if (x is Sniper)
                {
                    ((Sniper)x).hide = true;
                    ((Sniper)x).location = 0;
                }
            }
        }

        /// <summary>
        /// cutscene for crowman
        /// </summary>
        public void CrowmanBoss()
        {
            boss = true;
            string[] temp = {"You have reached a special room of the dungeon","I don't know what is in this room, I was never informed what exists here","???: Think those lame bosses were easy? Hahahaha, you won't be able to stop me, CROWMAN!","Fear the power of the creatures of the night"};
            new Cutscene(temp).Show();
        }
        #endregion

        /// <summary>
        /// ask if user would like to restart back at checkpoint
        /// </summary>
        /// <param name="field"></param>
        public void quit(BattleField field)
        {
            field.Close();
            if (field.sure)
            {
                field.emptyOrder();
                boss = false;
                foreach (Hero x in team)
                    x.Heal(x.calcPercent(100));
                you.energy = you.maxenergy;
                dungeon.newArea();
            }
            else { Application.Exit(); Environment.Exit(0); }
        }
        /// <summary>
        /// check to see if you have lost, then ask if you want to start back at the beginning or not
        /// </summary>
        public void checkLoss(BattleField field)
        {
            if (!learnA && you.level >= 5)
            {
                new Popup("Congratulations you have learned your classes Area of Effect Attack").Show();
                learnA = true;
            }
            if (!learnH && you.level >= 15)
            {
                new Popup("Congratulations you have learned how to hide,\r\nwhile hiding you take 50% damage and your next attack does 200% damage").Show();
                learnH = true;
            }
            if (you.health <= 0)//if you lost, then ask if they want to try again, if yes send them to StartGame at the first room, if no close game
            {
                field.Close();
                boss = false;
                loot = new List<Enemy>();
                new Confirm(field, "Try again?\r\n(you'll start back at room #" + checkpoint + ")","quit").Show();
            }
            else if (!enemiesAlive())
            {
                bool ability = false;
                foreach (Hero x in team)
                    if (x.ability().Equals("loot"))
                        ability = true;
                foreach (Enemy x in loot)
                {
                     x.loot(ability, field);
                }
                loot = new List<Enemy>();
                if (boss)
                {
                    dungeon.nextSet();
                    getSpecialLoot();
                }
                boss = false;
                field.Start.Text = "Exit";
                field.Start.Enabled = true;
            }
        }

        /// <summary>
        /// when you have beat a boss you get a small energy boost(10 e) and either a special weapon or armor
        /// </summary>
        public void getSpecialLoot()
        {
            int chance = r.Next(0, 101);
            you.energy += 10;
            you.maxenergy += 10;
            new Popup("You get 10 energy added to your max energy for defeating the boss").Show();
            if (chance <= 50)
            {
                Weapon x = new Weapon(true, you.level);
                new EquipItem(this, x).Show();
            }
            else
            {
                Armor x = new Armor(true, you);
                new EquipItem(this, x).Show();
            }
        }

        /// <summary>
        /// returns true if one side has no alive members
        /// </summary>
        /// <returns></returns>
        public bool Lost()
        {
            int count = 0;
            foreach (Enemy x in enemies)
                if (x.health <= 0)
                    count++;
            if (count == enemies.Count)
                return true;
            count = 0;
            foreach (Hero x in team)
                if (x.health <= 0)
                    count++;
            return count == team.Count;
        }

        #region Attacks
        /// <summary>
        /// A Player Does an Attack
        /// </summary>
        /// <param name="attack">attack</param>
        /// <param name="defense">defense</param>
        /// <param name="level">level</param>
        /// <param name="crit">crit chance</param>
        /// <param name="power">power</param>
        /// <param name="defender">attacked</param>
        /// <param name="attacker">attacking</param>
        /// <returns>string to display</returns>
        /// <param name="op">type of attack</param>
        /// <returns></returns>
        private string dealDamage(int attack, int defense, int level, double crit, double power, object defender, object attacker, damage op)
        {
            return op(attack, defense, level, crit, power, defender, attacker);
        }

        /// <summary>
        /// returns only the number of damage
        /// </summary>
        /// <param name="attack"></param>
        /// <param name="defense"></param>
        /// <param name="level"></param>
        /// <param name="crit"></param>
        /// <param name="power"></param>
        /// <param name="defender"></param>
        /// <param name="attacker"></param>
        /// <returns></returns>
        private string TakeDamage(int attack, int defense, int level, double crit, double power, object defender, object attacker)
        {

            double inflict = ((((((level * 2 / 5.0) + 2) * power * attack / 50.0) / defense) + 2) * (r.Next(85, 101) / 100.0));
            if (defender is Hero)
            {
                if (((Hero)defender).hiding)
                    inflict *= .5;
                inflict = Math.Round(inflict, 0);
                ((Hero)defender).takeDamage(inflict);
            }
            else if (defender is Enemy)
            {
                inflict = Math.Round(inflict, 0);
                ((Enemy)defender).takeDamage(inflict);
            }
            return inflict + "";
        }
        #region Enemy's Attacks

        /// <summary>
        /// Crowman's basic attack
        /// </summary>
        /// <param name="attack"></param>
        /// <param name="defense"></param>
        /// <param name="level"></param>
        /// <param name="crit"></param>
        /// <param name="power"></param>
        /// <param name="defender"></param>
        /// <param name="attacker"></param>
        /// <returns></returns>
        private string Crowbar(int attack, int defense, int level, double crit, double power, object defender, object attacker)
        {
            int inflict = int.Parse(TakeDamage(attack,defense,level,crit,power,defender,attacker));
            if (((Crowman)attacker).hide)
            {
                ((Hero)defender).Heal(inflict);
                inflict *= 5;
                ((Hero)defender).takeDamage(inflict);
            }
            return "Crowman takes out his crowbar and swings at " + ((Hero)defender).name() + " doing " + inflict + " damage\r\n";
        }

        /// <summary>
        /// Crowman has his swarm of unblockable crows attack your team
        /// </summary>
        /// <param name="attack"></param>
        /// <param name="defense"></param>
        /// <param name="level"></param>
        /// <param name="crit"></param>
        /// <param name="power"></param>
        /// <param name="defender"></param>
        /// <param name="attacker"></param>
        /// <returns></returns>
        private string MurderStorm(int attack, int defense, int level, double crit, double power, object defender, object attacker)
        {
            string output = "";
            int inflict = int.Parse(TakeDamage(attack,defense,level,crit,power,defender,attacker));
            if (((Crowman)attacker).hide)
            {
                ((Hero)defender).Heal(inflict);
                inflict *= 5;
                ((Hero)defender).takeDamage(inflict);
            }
            output += ((Hero)defender).name() + " got caught in the murder and took " + inflict + " damage\r\n";
            return output;
        }

        /// <summary>
        /// Sniper fires a shot
        /// </summary>
        /// <param name="attack"></param>
        /// <param name="defense"></param>
        /// <param name="level"></param>
        /// <param name="crit"></param>
        /// <param name="power"></param>
        /// <param name="defender"></param>
        /// <param name="attacker"></param>
        /// <returns></returns>
        private string CritialShot(int attack, int defense, int level, double crit, double power, object defender, object attacker)
        {
            string output = "";
            bool block = false;
            foreach (Hero y in team)
                if (y.ability().Equals("guard") && y.health > 0)
                    if (r.Next(101) < 25)//25% that an alive teammate with block will block the attack
                    {
                        output = (y.name() + " blocked the incoming attack\r\n");
                        block = true;
                        stop = true;
                        break;
                    }
            if (!block)
                if (r.Next(101) < crit)
                {
                    double inflict = double.Parse(TakeDamage(attack,defense,level,crit,power,defender,attacker));
                    ((Hero)defender).takeDamage(inflict);
                    output += "Sniper critially shot " + ((Hero)defender).name() + " for " + inflict + "\r\n";
                }
                else
                {
                    double inflict = double.Parse(TakeDamage(attack,defense,level,crit,power,defender,attacker));
                    output += "Sniper shot " + ((Hero)defender).name() + " for " + inflict + "\r\n";
                }
            return output;
        }

        /// <summary>
        /// The shot does a piercing shot which
        /// </summary>
        /// <param name="attack"></param>
        /// <param name="defense"></param>
        /// <param name="level"></param>
        /// <param name="crit"></param>
        /// <param name="power"></param>
        /// <param name="defender"></param>
        /// <param name="attacker"></param>
        /// <returns></returns>
        private string PiercingShot(int attack, int defense, int level, double crit, double power, object defender, object attacker)
        {
            string output = "";
            bool block = false;
            foreach (Hero y in team)
                if (y.ability().Equals("guard") && y.health > 0)
                    if (r.Next(101) < 25)//25% that an alive teammate with block will block the attack
                    {
                        output = (y.name() + " blocked the shot, stopping it in its tracks\r\n");
                        block = true;
                        stop = true;
                        break;
                    }
            if (!block) 
            {
                output = ((Sniper)attacker).name() + " shot through " + ((Hero)defender).name() + " which did " + TakeDamage(attack, defense, level, crit, power, defender, attacker) + "\r\n";
            }
            return output;
        }

        /// <summary>
        /// Shadow Enemy Attack
        /// </summary>
        /// <param name="attack"></param>
        /// <param name="defense"></param>
        /// <param name="level"></param>
        /// <param name="crit"></param>
        /// <param name="power"></param>
        /// <param name="defender"></param>
        /// <param name="attacker"></param>
        /// <returns></returns>
        private string ShadowAttack(int attack, int defense, int level, double crit, double power, object defender, object attacker)
        {
            string output = "";
            bool block = false;
            foreach (Hero y in team)
                if (y.ability().Equals("guard") && y.health > 0)
                    if (r.Next(101) < 25)//25% that an alive teammate with block will block the attack
                    {
                        output = (y.name() + " blocked the incoming attack\r\n");
                        block = true;
                        break;
                    }
            if (!block)
                output = ((Shadow)attacker).name() + " lunged at " + ((Hero)defender).name() + " and did " + TakeDamage(attack, defense, level, crit, power, defender, attacker) + "\r\n";
            return output;
        }

        /// <summary>
        /// Normal Enemy Attack
        /// </summary>
        /// <param name="attack"></param>
        /// <param name="defense"></param>
        /// <param name="level"></param>
        /// <param name="crit"></param>
        /// <param name="power"></param>
        /// <param name="defender"></param>
        /// <param name="attacker"></param>
        /// <returns></returns>
        private string EnemyAttack(int attack, int defense, int level, double crit, double power, object defender, object attacker)
        {
            string output = "";
            bool block = false;
            foreach (Hero y in team)
                if (y.ability().Equals("guard") && y.health > 0)
                    if (r.Next(101) < 25)//25% that an alive teammate with block will block the attack
                    {
                        output = (y.name() + " blocked the incoming attack\r\n");
                        block = true;
                        break;
                    }
            if (!block)
                output = EnemyBaseDamage(attack, defense, level, crit, power, defender, attacker);
            return output;
        }

        /// <summary>
        /// Shadow's void of darkness attack
        /// </summary>
        /// <param name="attack"></param>
        /// <param name="defense"></param>
        /// <param name="level"></param>
        /// <param name="crit"></param>
        /// <param name="power"></param>
        /// <param name="defender"></param>
        /// <param name="attacker"></param>
        /// <returns></returns>
        private string VoidofDarkness(int attack, int defense, int level, double crit, double power, object defender, object attacker)
        {
            string output = "";
            if (defender is Hero)
            {
                bool block = false;
                if (((Hero)defender).health > 0)
                {
                    foreach (Hero y in team)
                        if (y.ability().Equals("guard") && y.health > 0)
                            if (r.Next(101) < 25)//25% that an alive teammate with block will block the attack
                            {
                                output = (y.name() + " blocked the incoming attack\r\n");
                                block = true;
                                break;
                            }
                    if (!block)
                        output += ((Hero)defender).name() + " was engluffed in darkness for " + TakeDamage(attack, defense, level, crit, power, defender, attack) + "\r\n";
                }
            }
            else if (defender is Enemy)
                if (((Enemy)defender).health > 0)
                {
                    output += ((Enemy)defender).name() + " was engluffed in darkness for " + TakeDamage(attack, defense, level, crit, power, defender, attack) + "\r\n";
                }
            return output;

        }



        /// <summary>
        /// One Attack
        /// </summary>
        /// <param name="attack">Enemy's attack</param>
        /// <param name="defense">Hero's defense</param>
        /// <param name="level">Enemy's level</param>
        /// <param name="crit">0% crit chance</param>
        /// <param name="power">attack power</param>
        /// <param name="defender">Hero being attacked</param>
        /// <param name="attacker">Enemy attacking</param>
        /// <returns>string to display</returns>
        private string EnemyBaseDamage(int attack, int defense, int level, double crit, double power, object defender, object attacker)
        {
            double inflict = ((((((level * 2 / 5.0) + 2) * power * attack / 50.0) / defense) + 2) * (r.Next(85, 101) / 100.0));
            string output = "";
            if (((Hero)defender).hiding)
                inflict *= .5;
            inflict = Math.Round(inflict, 0);
            ((Hero)defender).takeDamage(inflict);
            return output = (((Enemy)attacker).name() + " hit " + ((Hero)defender).name() + " for " + inflict + " damage") + "\r\n";
        }

        #endregion

        #region Your Team's Attack
        /// <summary>
        /// One Attack
        /// </summary>
        /// <param name="attack">Hero's attack</param>
        /// <param name="defense">enemy defense</param>
        /// <param name="level">Hero's level</param>
        /// <param name="crit">Hero's crit chance</param>
        /// <param name="power">attack power</param>
        /// <param name="defender">enemy being attacked</param>
        /// <param name="attacker">Hero attacking</param>
        /// <returns>string to display</returns>
        private string BaseDamage(int attack, int defense, int level, double crit, double power, object defender, object attacker)
        {
            if (defense < 1)
                defense = 1;
            double inflict = ((((((level * 2 / 5.0) + 2) * power * attack / 50.0) / defense) + 2) * (r.Next(85, 101) / 100.0));
            string output = "";
            if (r.Next(101) <= crit)//if random number out of 100 is less than or equal ally's critial percent, do a critial hit
            {
                inflict *= 2.50;
                if (attacker is Hero)
                    if (((Hero)attacker).Equals(you))
                        if (you.hiding)
                            inflict *= 2;
                if (defender is Crowman)
                    if (((Crowman)defender).hide)
                        inflict *= .25;
                inflict = Math.Round(inflict, 0);
                ((Enemy)defender).takeDamage(inflict);
                return output = (((Hero)attacker).name() + " critially hit " + ((Enemy)defender).name() + " for " + inflict + " damage") + "\r\n";

            }
            else
            {
                if (attacker is Hero)
                    if (((Hero)attacker).Equals(you))
                        if (you.hiding)
                            inflict *= 2;
                if (defender is Crowman)
                    if (((Crowman)defender).hide)
                        inflict *= .25;
                inflict = Math.Round(inflict, 0);
                ((Enemy)defender).takeDamage(inflict);
                return output = (((Hero)attacker).name() + " hit " + ((Enemy)defender).name() + " for " + inflict + " damage") + "\r\n";

            }
        }

        /// <summary>
        /// find targets for an AoE
        /// 
        /// 5   1
        /// 4   2
        /// 6   3
        /// 
        /// middle first(wide slash only hits 3):
        /// 5,1,4
        /// 4,5,6,2
        /// 6,4,3
        /// 1,5,2
        /// 2,4,1,3
        /// 3,2,6
        /// 
        /// </summary>
        /// <param name="attack"></param>
        /// <param name="defense"></param>
        /// <param name="level"></param>
        /// <param name="crit"></param>
        /// <param name="power"></param>
        /// <param name="target"></param>
        /// <param name="attacker"></param>
        /// <param name="op"></param>
        /// <returns></returns>
        private string getTargets(int attack, int defense, int level, double crit, double power, int target, Hero attacker, damage op)
        {
            List<int> targets = new List<int>();
            targets.Add(target);
            string output = "";
            #region Select the Targets
            if (target == 0)
            {
                targets.Add(4);
                targets.Add(1);
            }
            else if (target == 1)
            {
                targets.Add(3);
                targets.Add(0);
                targets.Add(2);
            }
            else if (target == 2)
            {
                targets.Add(5);
                targets.Add(1);
            }
            else if (target == 3)
            {
                targets.Add(4);
                targets.Add(5);
                targets.Add(1);
            }
            else if (target == 4)
            {
                targets.Add(0);
                targets.Add(3);
            }
           
            else if (target == 5)
            {
                targets.Add(3);
                targets.Add(2);
            }
            #endregion
            if (attacker is Warrior)
            {
                output += "You run up to your target an perform an exeraged slash that sweeps across several enemies\r\n";
                foreach (int x in targets)
                {
                    try
                    {
                        output += op(attack, defense, level, crit, power, enemies[x], attacker);
                        if ((enemies[x]).health <= 0)
                        {
                            output += you.name() + " killed " + enemies[x].name() + "\r\n";
                            loot.Add(enemies[x]);
                        }
                        else if (you.getWeapon().canPoison())
                        {
                            if (((Enemy)enemies[x]).getPoison(you.getWeapon().poisondamage))
                                output += you.name() + " poisoned " + enemies[x].name() + "\r\n";
                        }
                    }
                    catch (NoTargetException)
                    {
                    }
                    
                }
            }
            else if (attacker is Mage)
            {
                targets.Remove(target);
                output += "You cast a powerful spell that also effects an area around your target\r\n";
                output += op(attack, defense, level, crit, power, enemies[target], attacker);
                if ((enemies[target]).health <= 0)
                {
                    output += you.name() + " killed " + enemies[target].name() + "\r\n";
                    loot.Add(enemies[target]);
                }
                else if (you.getWeapon().canPoison())
                {
                    if (((Enemy)enemies[target]).getPoison(you.getWeapon().poisondamage))
                        output += you.name() + " poisoned " + enemies[target].name() + "\r\n";
                }
                Attacks after = null;
                foreach (Attacks x in world.attackList())
                {
                    if (x.attackName().Equals("Splash After"))
                    {
                        after = x;
                        break;
                    }
                }
                power = after.basePower();
                acc = after.accucary();
                foreach (int x in targets)
                {
                    try
                    {
                        output += op(attack, defense, level, 0, power, enemies[x], attacker);
                        if ((enemies[x]).health <= 0)
                        {
                            output += you.name() + " killed " + enemies[x].name() + "\r\n";
                            loot.Add(enemies[x]);
                        }
                        else if (you.getWeapon().canPoison())
                        {
                            if (((Enemy)enemies[x]).getPoison(you.getWeapon().poisondamage))
                                output += you.name() + " poisoned " + enemies[x].name() + "\r\n";
                        }
                    }
                    catch (NoTargetException)
                    {
                    }
                    
                }

            }
            else if (attacker is Archer)
            {
                output += "You fire a volley of arrows that effects a wide area of targets\r\n";
                foreach (int x in targets)
                {
                    try
                    {
                        output += op(attack, defense, level, crit, power, enemies[x], attacker);
                        if ((enemies[x]).health <= 0)
                        {
                            output += you.name() + " killed " + enemies[x].name() + "\r\n";
                            loot.Add(enemies[x]);
                        }
                        else if (you.getWeapon().canPoison())
                        {
                            if (((Enemy)enemies[x]).getPoison(you.getWeapon().poisondamage))
                                output += you.name() + " poisoned " + enemies[x].name() + "\r\n";
                        }
                    }
                    catch (NoTargetException)
                    {
                    }
                    
                }
            }
            return output;
        }

        /// <summary>
        /// Scout's Special Attack, Ignores Defense.
        /// </summary>
        /// <param name="attack"></param>
        /// <param name="defense"></param>
        /// <param name="level"></param>
        /// <param name="crit"></param>
        /// <param name="power"></param>
        /// <param name="defender"></param>
        /// <param name="attacker"></param>
        /// <returns></returns>
        private string IgnoreDamage(int attack, int defense, int level, double crit, double power, object defender, object attacker)
        {
            string output = "";
            output += ((Hero)attacker).name() + " did a peircing shot at " + ((Enemy)defender).name() + "\r\n";
            output += BaseDamage(attack, defense / 10, level, crit, power, defender, attacker);
            return output;
        }

        /// <summary>
        /// Rogue's Special Attack, Hits once and may hit twice
        /// </summary>
        /// <param name="attack"></param>
        /// <param name="defense"></param>
        /// <param name="level"></param>
        /// <param name="crit"></param>
        /// <param name="power"></param>
        /// <param name="defender"></param>
        /// <param name="attacker"></param>
        /// <returns></returns>
        private string DoubleDamage(int attack, int defense, int level, double crit, double power, object defender, object attacker)
        {
            string output = "";
            output += BaseDamage(attack, defense, level, crit, power, defender, attacker);
            if (r.Next(101) <= 25)
            {
                output += "\r\n" + ((Hero)attacker).name() + " did a second swing at " + ((Enemy)defender).name() + "\r\n";
                output += BaseDamage(attack, defense, level, crit, power, defender, attacker);
            }
            return output;
        }

        /// <summary>
        /// no special, no energy loss, just returns base damage;
        /// </summary>
        /// <param name="attack"></param>
        /// <param name="defense"></param>
        /// <param name="level"></param>
        /// <param name="crit"></param>
        /// <param name="power"></param>
        /// <param name="defender"></param>
        /// <param name="attacker"></param>
        /// <returns></returns>
        private string AccurateDamage(int attack, int defense, int level, double crit, double power, object defender, object attacker)
        {
            return BaseDamage(attack, defense, level, crit, power, defender, attacker);
        }

        /// <summary>
        /// Perform a powerful attack
        /// </summary>
        /// <param name="attack"></param>
        /// <param name="defense"></param>
        /// <param name="level"></param>
        /// <param name="crit"></param>
        /// <param name="power"></param>
        /// <param name="defender"></param>
        /// <param name="attacker"></param>
        /// <returns></returns>
        private string PowerDamage(int attack, int defense, int level, double crit, double power, object defender, object attacker)
        {
            string output = "You push yourself to your limit to unleash a powerful attack\r\n";
            output += BaseDamage(attack, defense, level, crit, power, defender, attacker);
            return output;
        }

        /// <summary>
        /// Perform a rapid attack, which attacks 3 to 5 times, for every 50 speed you increase the min/max by 1.
        /// </summary>
        /// <param name="attack"></param>
        /// <param name="defense"></param>
        /// <param name="level"></param>
        /// <param name="crit"></param>
        /// <param name="power"></param>
        /// <param name="defender"></param>
        /// <param name="attack"></param>
        /// <returns></returns>
        private string RapidDamage(int attack, int defense, int level, double crit, double power, object defender, object attacker)
        {
            double spd = ((Hero)attacker).speed;
            int increase = (int)(spd/50);
            int min = 3 + increase;
            int max = 6 + increase;
            int times = r.Next(min, max);
            string output = "You quickly attack the enemy " + times + " times\r\n";
            for (int x = 0; x < times; x++)
            {
                if (r.Next(101) <= acc)
                    output += BaseDamage(attack, defense, level, crit, power, defender, attacker);
                else
                    output += "Your attacked missed\r\n";
            }
            return output;
        }
        #endregion
        #endregion

        /// <summary>
        /// Check to see if enemies are alive
        /// </summary>
        /// <returns>true if at least one is alive</returns>
        public bool enemiesAlive()
        {
            int count = 0;
            foreach (Enemy x in enemies)
                if (x.health <= 0)
                    count++;
            return count != enemies.Count;
        }

        /// <summary>
        /// ally's attacks
        /// </summary>
        /// <param name="ally"></param>
        /// <param name="field"></param>
        public void allyAttack(Hero ally, BattleField field)
        {
            Attacks attack = null;
            foreach (Attacks x in world.attackList())
            {
                if (x.attackName().Equals("Ally"))
                {
                    attack = x;
                    break;
                }

            }
            string output = "";
            int gain = 0;
            bool heal = false;
            if (enemiesAlive())
            {
                if (ally.health > 0)
                {
                    if (ally.ability().Equals("heal"))
                        for (int y = 0; y < team.Count; y++)
                            if (team[y].danger() && team[y].health > 0)
                            {
                                heal = true;
                                if (team[y].Equals(ally))
                                    output += ("Your healer healed themself") + "\r\n";
                                else
                                    output += ("Your healer healed " + team[y].name()) + "\r\n";
                                team[y].Heal(team[y].calcPercent(50));
                                break;
                            }

                    if (heal == false)
                    {
                        int target;
                        bool weak = false;
                        int omit = -1;
                        int atk = ally.attack + ally.getWeapon().attackbonus;
                        double crit = ally.critial + ally.getWeapon().critbonus;

                        double power = attack.basePower();
                        int acc = attack.accucary();
                        for (int x = 0; x < enemies.Count; x++)
                            if (enemies[x] is Sniper)
                                if (((Sniper)enemies[x]).hide)
                                    omit = x;
                        if (ally.ability().Equals("power"))
                        {
                            acc -= 20;
                            power *= 1.5;
                        }
                        for (target = 0; target < enemies.Count; target++)//if an enemy is almost dead, ally will target it
                            if (enemies[target].danger() && !(enemies[target] is Sniper))
                            {
                                weak = true;
                                break;
                            }
                            else if (enemies[target].danger() && !((Sniper)enemies[target]).hide)
                            {
                                weak = true;
                                break;
                            }
                        if (!weak)
                        {
                            target = r.Next(0, enemies.Count);
                            while (enemies[target].health <= 0 || target == omit)
                                target = r.Next(0, enemies.Count);
                        }
                        if (r.Next(101) < acc)
                        {
                            if (ally.ability().Equals("double"))
                                output += dealDamage(atk, enemies[target].defense, ally.level, ally.critial, power, enemies[target], ally, DoubleDamage);
                            else if (ally.ability().Equals("scout") && r.Next(101) < 25)
                                output += dealDamage(atk, enemies[target].defense, ally.level, ally.critial, power, enemies[target], ally, IgnoreDamage);
                            else
                                output += dealDamage(atk, enemies[target].defense, ally.level, ally.critial, power, enemies[target], ally, BaseDamage);
                        }
                        else
                        {
                            output += (ally.name() + " missed\r\n");
                        }
                        if (((Enemy)enemies[target]).health <= 0)
                        {
                            output += (ally.name() + " defeated " + enemies[target].name()) + "\r\n";
                            gain += enemies[target].xp();
                            output += ("Your team gained " + gain + "xp") + "\r\n";
                            loot.Add(enemies[target]);
                        }
                        else if (ally.getWeapon().canPoison())
                        {
                            if (((Enemy)enemies[target]).getPoison(ally.getWeapon().poisondamage))
                                output += ally.name() + " poisoned " + enemies[target].name() + "\r\n";
                        }
                        foreach (Enemy x in enemies)
                            if (x is Sniper)
                                output += checkHide((Sniper)x) + "\r\n";
                        foreach (Hero z in team)
                            output += z.gainXP(gain);//get xp from defeated monster
                        
                    }
                }
                if (ally.getArmor().canRegen())
                    output += ally.regen(ally.getArmor().regenhealth);
                field.Output.Text += "\r\n" + output;
            }
        }

        /// <summary>
        /// player's attacks
        /// </summary>
        /// <param name="field"></param>
        /// <param name="attackType"></param>
        /// <param name="target"></param>
        public void PlayerAttack(BattleField field, string attackType, int target, int mana, double extracrit, int extraacc, int extraatk)
        {
            if (mana < 0)
                mana = 0;
            you.use(mana);
            field.Output.Text = "";
            string output = "";
            int gain = 0;
            double power = 100;
            acc = 100;
            int atk = you.attack + you.getWeapon().attackbonus;
            atk = (int)Math.Round((atk * (1 + extraatk / 100.0)),0);
            int def = enemies[target].defense;
            double crit = you.critial + you.getWeapon().critbonus + extracrit;
            damage damageType = BaseDamage;
            Attacks attack = getAttack(attackType);
            if (attackType.Equals("Accurate"))
            {
                damageType = AccurateDamage;
            }
            else if (attackType.Equals("Power"))
            {
                damageType = PowerDamage;
            }
            else if (attackType.Equals("Rapid"))
            {
                damageType = RapidDamage;

            }
            power = attack.basePower();
            acc = attack.accucary();
            acc += extraacc;
            if (you.ability().Equals("power"))
            {
                acc -= 10;
                power *= 1.5;
            }
            else if (you.ability().Equals("accurate"))
            {
                acc += 10;
                power *= .8;
            }
            if (attackType.Equals("Hide"))
            {
                you.hiding = true;
            }
            else
            {
                if (you.hiding)
                {
                    output += "You came out of hiding to deal extra damage\r\n";
                }
                if (r.Next(101) < acc && (attackType.Equals("Accurate") || attackType.Equals("Power")))
                {
                    output += dealDamage(atk, def, you.level, crit, power, enemies[target], you, damageType);
                }
                else if (attackType.Equals("Rapid"))
                    output += dealDamage(atk, def, you.level, crit, power, enemies[target], you, damageType);
                else if (attackType.Equals("AOE"))
                {
                    output += getTargets(atk, def, you.level, crit, power, target, you, damageType);
                }
                else
                {
                    output += (you.name() + " missed\r\n");
                }
                if (!attackType.Equals("AOE"))
                {
                    if (((Enemy)enemies[target]).health <= 0)
                    {
                        output += (you.name() + " defeated " + enemies[target].name()) + "\r\n";
                        gain += enemies[target].xp();
                        output += ("Your team gained " + gain + "xp") + "\r\n";
                        loot.Add(enemies[target]);
                    }
                    else if (you.getWeapon().canPoison())
                    {
                        if (((Enemy)enemies[target]).getPoison(you.getWeapon().poisondamage))
                            output += you.name() + " poisoned " + enemies[target].name() + "\r\n";
                    }
                }
            }
            if (mana > 0)
            {
                output += "You used " + mana + " energy\r\n";
            }
            foreach (Enemy x in enemies)
                if (x is Sniper)
                    output += checkHide((Sniper)x) + "\r\n";
            if (you.getArmor().canRegen())
                output += you.regen(you.getArmor().regenhealth) + "\r\n";
            if (you.energy != you.maxenergy)
                output += "You replished " + you.replish() + " energy\r\n";
            foreach (Hero z in team)
                z.gainXP(gain);//get xp from defeated monster
            field.Output.Text += "\r\n" + output;
        }


        /// <summary>
        /// returns the attack of correct type
        /// </summary>
        /// <param name="attackName"></param>
        /// <returns></returns>
        public Attacks getAttack(string attackName)
        {
            if (attackName.Equals("AOE"))
            {
                if (you is Warrior)
                    attackName = "Wide Slash";
                else if (you is Archer)
                    attackName = "Volley";
                else if (you is Mage)
                    attackName = "Splash Attack";
            }
            foreach (Attacks x in world.attackList())
            {
                if (x.attackName().Equals(attackName))
                {
                    return x;
                }
            }
            return null;
        }

        /// <summary>
        /// Enemy's attack turn
        /// </summary>
        /// <param name="x"></param>
        public void enemyAttack(Enemy attacker, BattleField field)
        {
            string output = "";
            int gain = 0;
            if (attacker.health > 0)
            {
                if (!(attacker is Boss))
                {
                    int target = r.Next(0, team.Count);
                    while (team[target].health <= 0)//make sure an alive target is chosen
                        target = r.Next(0, team.Count);
                    int def = team[target].defense + team[target].getArmor().defensebonus;
                    double power = attacker.baseDamage();
                    if (r.Next(101) <= attacker.accucary)
                    {
                        output += dealDamage(attacker.attack, def, attacker.lvl, 0, power, team[target], attacker, EnemyAttack);
                    }
                    else
                    {
                        output += attacker.name() + " missed";
                    }
                    output += attacker.takePoison() + "\r\n";
                    if (attacker.health <= 0)
                    {
                        output += attacker.name() + " died from poisoning\r\n";
                        gain = attacker.xp();
                        foreach (Hero z in team)
                            z.gainXP(gain);
                    }
                    field.Output.Text += "\r\n" + output;

                }
                else
                    bossFight((Boss)attacker, field);

            }
        }

        #region Item Commands

        /// <summary>
        /// when you get an armor drop from an enemy
        /// </summary>
        public void armor()
        {
            Armor temp = new Armor(you.level);
            new EquipItem(this, temp).Show();
        }
        /// <summary>
        /// when you get a weapon drop from an enemy
        /// </summary>
        public void weapon()
        {
            Weapon temp = new Weapon(you.level);
            new EquipItem(this, temp).Show();
        }
        /// <summary>
        /// see if you want to use a revive after you have died if you have one
        /// </summary>
        /// <returns></returns>
        public void useRevive(BattleField field)
        {
            if (max.empty() && revive.empty())//if no revive items return false
                willUse(false,field);
            else
                new Confirm(field, "Will you revive yourself?", "revive").Show();
        }

        public void willUse(bool use, BattleField field)
        {
            field.revive(use);
        }
        /// <summary>
        /// return true if there is at least 1 wounded target that is not dead
        /// </summary>
        /// <returns></returns>
        public bool woundedTargets()
        {
            foreach (Hero x in team)
                if (x.health > 0 && x.health < x.maxhealth)
                    return true;
            return false;
        }
        /// <summary>
        /// return true if there is at least 1 dead target
        /// </summary>
        /// <returns></returns>
        public bool deadTargets()
        {
            foreach (Hero x in team)
                if (x.health <= 0)
                    return true;
            return false;
        }

        /// <summary>
        /// if you can't use the of potion selected, show an error as to why you can't use it
        /// </summary>
        /// <param name="type"></param>
        /// <param name="inventory"></param>
        public void CanUse(int type, Inventory inventory)
        {
            if (type == 1)
            {
                if (basic.Length == 0)
                {
                    inventory.canuse = false;
                    inventory.error = "You have no basic potions to use";
                    return;
                }
            }
            else if (type == 2)
            {
                if (advanced.Length == 0)
                {
                    inventory.canuse = false;
                    inventory.error = "You have no advanced potions to use";
                    return;
                }
            }
            else if (type == 3)
            {
                if (super.Length == 0)
                {
                    inventory.canuse = false;
                    inventory.error = "You have no super potions to use";
                    return;
                }
            }
            else if (type == 4)
            {
                if (mega.Length == 0)
                {
                    inventory.canuse = false;
                    inventory.error = "You have no mega potions to use";
                    return;
                }
            }
            else if (type == 5)
            {
                if (revive.Length == 0)
                {
                    inventory.canuse = false;
                    inventory.error = "You have no revives to use";
                    return;
                }
            }
            else if (type == 6)
            {
                if (max.Length == 0)
                {
                    inventory.canuse = false;
                    inventory.error = "You have no max revives to use";
                    return;
                }
            }
            if (type > 0 && type < 5)
            {
                if (!woundedTargets())
                {
                    inventory.canuse = false;
                    inventory.error = "There are no wounded members on your team";
                }
                else
                    inventory.canuse = true;
            }
            else if (type > 4)
            {
                if (!deadTargets())
                {
                    inventory.canuse = false;
                    inventory.error = "There are no dead members on your team";
                }
                else
                    inventory.canuse = true;
            }

        }

        /// <summary>
        /// Use the type of potion on the hero
        /// </summary>
        /// <param name="potion"></param>
        /// <param name="x"></param>
        public void use(Potion potion, Hero x, BattleField field)
        {
            if (potion is Basic)
                basic.dequeue().use(x, field);
            else if (potion is Advanced)
                advanced.dequeue().use(x, field);
            else if (potion is Super)
                super.dequeue().use(x, field);
            else if (potion is Mega)
                mega.dequeue().use(x, field);
            else if (potion is Revive)
                revive.dequeue().use(x, field);
            else
                max.dequeue().use(x, field);
            field.Output.Text += "You replished " + you.replish() + " energy\r\n";
        }

        /// <summary>
        /// use an item on you character or your teammates
        /// </summary>
        public string getPotions()
        {
            string potions = "Potions you have:\r\n";
            potions += "Basic Potions(heals 25 health): " + basic.Length + "\r\n";
            potions += "Advanced Potions(heals 100 health): " + advanced.Length + "\r\n";
            potions += "Super Potions(heals 50% of total health): " + super.Length + "\r\n";
            potions += "Mega Potions(heals health back to full): " + mega.Length + "\r\n";
            potions += "Revive Potions(revives a fallen Hero back to 50% health): " + revive.Length + "\r\n";
            potions += "Max Revive Potions(revives a fallen Hero back to 100% health): " + max.Length + "\r\n";
            return potions;
        }

        public static void AddLoot(Potion x)//have enemy add loot to your inventory
        {
            if (x is Basic) basic.enqueue((Basic)x);
            if (x is Advanced) advanced.enqueue((Advanced)x);
            if (x is Super) super.enqueue((Super)x);
            if (x is Mega) mega.enqueue((Mega)x);
            if (x is Revive) revive.enqueue((Revive)x);
            if (x is MaxRevive) max.enqueue((MaxRevive)x);
        }

        #endregion


        #region Boss Attacks

        /// <summary>
        /// boss' special attacks
        /// </summary>
        private void bossFight(Boss boss, BattleField field)
        {
            String output = boss.name() + "'s turn:\r\n";
            if (boss is Shadow) shadowAttack((Shadow)boss, output, field);
            if (boss is Sniper) sniperAttack((Sniper)boss, output, field);
            if (boss is Crowman) crowmanAttack((Crowman)boss, output, field);
        }

        /// <summary>
        /// check to see if the shadow is the only one alive 
        /// </summary>
        /// <returns></returns>
        public bool ShadowAlone()
        {
            int count = 0;
            foreach (Enemy x in enemies)
            {
                if (!(x is Shadow))
                {
                    if (x.health <= 0)
                        count++;
                }
            }
            return count == 0;
        }

        /// <summary>
        /// check to see if the sniper is the only one alive
        /// </summary>
        /// <returns></returns>
        public bool SniperAlone()
        {
            int count = 0;
            foreach (Enemy x in enemies)
            {
                if (!(x is Sniper))
                {
                    if (x.health > 0)
                        count++;
                }
            }
            return count == 0;
        }


        /// <summary>
        /// Shadow's attack
        /// </summary>
        /// <param name="shadow"></param>
        /*
         * The boss has a high damaging attack and has a 50% chance with 75% accuracy to attack another or the same target after his first hit dealing 75% of the power.
         * The boss can create a minon from the shadows instead of attacking 5% of the time, with 25% of them being normal enemies
         * if boss is only one on field, he summons a normal enemy.
         * The boss may heal himself 15% of the time when his health gets too low. **REMOVED**
         * The boss has a powerful magic spell he uses 35% of the time that will damage everything in the room except himself/
         * 
         * * */
        private void shadowAttack(Shadow shadow, string output, BattleField Field)
        {
            if (ShadowAlone())
            {
                bool nothing = true;
                double power = shadow.baseDamage();
                int chance = r.Next(101);
                if (chance <= 35)
                {
                    output += ("Shadow does Void of Darkness, Everything in the room suffered damaged") + "\r\n";
                    foreach (Hero x in team)
                    {
                        int def = x.defense + x.getArmor().defensebonus;
                        output += dealDamage(shadow.attack, def, shadow.lvl, 0, power, x, shadow, VoidofDarkness);
                    }
                    foreach (Enemy x in enemies)
                    {
                        if (!x.Equals(shadow))
                        {
                            output += dealDamage(shadow.attack, x.defense, shadow.lvl, 0, power, x, shadow, VoidofDarkness);
                        }
                    }
                    nothing = false;
                }
                else if (chance <= 40)
                {
                    foreach (Enemy x in enemies)
                        if (x.health <= 0)
                        {
                            x.health = x.maxhealth;
                            output += "Shadow revived " + x.name() + ",it will move last this turn\r\n";
                            Field.addNewEnemy(x);
                            nothing = false;
                            break;
                        }
                    if (enemies.Count < fieldcap)
                    {
                        Enemy summon = new Normal();
                        summon.getStats(shadow.lvl);
                        enemies.Add(summon);
                        output += "Shadow summoned a new enemy to his field, it will attack last this turn\r\n";
                        Field.addNewEnemy(summon);
                        nothing = false;
                    }
                }
                if (nothing)
                {
                    int target = r.Next(0, team.Count);
                    while (team[target].health <= 0)//make sure target is alive
                        target = r.Next(0, team.Count);
                    int def = team[target].defense + team[target].getArmor().defensebonus;
                    output += dealDamage(shadow.attack, def, shadow.lvl, 0, power, team[target], shadow, ShadowAttack);
                    if (r.Next(101) <= 50)//50% of the time do an extra attack
                    {
                        int count = 0;
                        foreach (Hero x in team)
                            if (x.health > 0)
                                count++;
                        if (count > 0)//if all team members are dead, don't do an extra attack
                        {
                            target = r.Next(0, team.Count);
                            while (team[target].health <= 0)//make sure target is alive
                                target = r.Next(0, team.Count);
                            def = team[target].defense + team[target].getArmor().defensebonus;
                            output += "Shadow jumped back and felt the urgue to do another attack\r\n";
                            output += dealDamage(shadow.attack, def, shadow.lvl, 0, power * .75, team[target], shadow, ShadowAttack);
                        }

                    }
                }
            }
            else
            {
                foreach (Enemy x in enemies)
                    if (x.health <= 0)
                    {
                        x.health = x.maxhealth;
                        output += "Shadow revived " + x.name() + "\r\n";
                        Field.addNewEnemy(x);
                        break;
                    }
            }
            output += shadow.takePoison() + "\r\n";
            if (shadow.health <= 0)
            {
                output += shadow.name() + " died from poisoning\r\n";
                enemies.Remove(shadow);
                int gain = shadow.xp();
                foreach (Hero z in team)
                    z.gainXP(gain);
            }
            Field.Output.Text += "\r\n" + output;
        }

        /// <summary>
        /// if hiding enemy is dead then unhide sniper.
        /// </summary>
        private string checkHide(Sniper sniper)
        {
            try
            {
                if (enemies[sniper.location].health <= 0 && sniper.hide)
                {
                    sniper.hide = false;
                    return ("The " + sniper.name() + " is no longer in hiding\r\n");
                }
                return "";
            }
            catch (Exception)
            {
                sniper.hide = false;
                return "";
            }
        }

        private bool TeamHealth()
        {
            int count = 0;
            foreach (Enemy x in enemies)
            {
                if (!(x is Sniper))
                {
                    if (x.health > 0)
                        count++;
                }
            }
            return count != enemies.Count - 1;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sniper"></param>
        /// <param name="output"></param>   
        /*
         * Sniper has 25% to hide if he is not currently hidden and has something to hide behind.
         * 
         * If not attempting to hide:
         * 25% chance to do a critial hit
         * 35% chance to do a piercing shot(hits your entire team)
         * 5% chance to repair the wall(create a greater enemy if there is less than 2)
         * if sniper is not hiding and there is another enemy he will hide behind it
         *          *
         * */
        private void sniperAttack(Sniper sniper, string output, BattleField field)
        {

            double power = sniper.baseDamage();
            int chance = r.Next(101);
            if (!(!sniper.hide && chance <= 25 && !SniperAlone()))
            {
                if (chance <= 35)
                {
                    output += "Sniper does a piercing shot that goes right through your entire team\r\n";
                    foreach (Hero x in team)
                    {
                        if (!stop)
                        {
                            if (x.health > 0)
                            {
                                int def = x.defense + x.getArmor().defensebonus;
                                output += dealDamage(sniper.attack, def, sniper.lvl, 0, power, x, sniper, PiercingShot);
                            }
                        }
                    }
                    stop = false;
                }
                else if (TeamHealth() && chance <= 40)
                {
                    foreach (Enemy x in enemies)
                    {
                        if (x.health <= 0)
                        {
                            x.health = x.maxhealth;
                            output += "Sniper repaired " + x.name();
                            break;
                        }
                    }
                }
                else
                {
                    int target = r.Next(0, team.Count);
                    while (team[target].health <= 0)//make sure target is alive
                        target = r.Next(0, team.Count);
                    int def = team[target].defense + team[target].getArmor().defensebonus;
                    output += dealDamage(sniper.attack,def, sniper.lvl, 25, power, team[target], sniper, CritialShot);
                }
            }
            else
            {
                if (!SniperAlone())
                {
                    int target = r.Next(0, enemies.Count);
                    while (enemies[target] is Boss && enemies[target].health > 0)//make sure enemy is not the boss
                        target = r.Next(0, enemies.Count);
                    output += sniper.name() + " hides behind " + enemies[target].name() + "\r\n";
                    sniper.hide = true;
                    sniper.location = target;
                }
            }
            output += sniper.takePoison() + "\r\n";
            if (sniper.health <= 0)
            {
                output += sniper.name() + " died from poisoning";
                int gain = sniper.xp();
                foreach (Hero z in team)
                    z.gainXP(gain);
            }
            field.Output.Text += "\r\n" + output;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="crow"></param>
        /// <param name="output"></param>
        /*
         * 20% chance to hide, while hiding crowman takes 75% less damage and next attack does 5x damage
         * 30% chance to use Murder Cloud, a swarm of crows come in and attack every member of team, Unblockable
         * 10% chance to heal 25% of his health while below 100 health.
         * Otherwise will use a normal attack called crowbar sweep
         * */
        private void crowmanAttack(Crowman crow, string output, BattleField field)
        {
            double power = crow.baseDamage();
            int chance = r.Next(101);
            if (crow.hide)
            {
                //don't give crowman a higher chance to do his unblockable AoE ability
                chance += 20;
            }
            if (chance <= 20 && !crow.hide)
            {
                output += crow.name() + " went into hiding, he will take 25% of all damage to him this turn and will do 5 times the amount of damage next turn\r\n";
                crow.hide = true;
            }
            else if (chance <= 50)
            {
                output += "Crowman uses Murder Cloud, a storm of crows comes down and attacks your team\r\n";
                foreach(Hero x in team)
                {
                    int def = x.defense + x.getArmor().defensebonus;
                    if (x.health > 0)
                        output += dealDamage(crow.attack, def, crow.lvl, 0, power, x, crow, MurderStorm);
                }
                if (crow.hide)//if crow was hiding unhide
                {
                    crow.hide = !crow.hide;
                    output += crow.name() + " came out of hiding, damage modifiers have disappeared\r\n";
                }
            }
            else if (chance <= 55 && crow.health < 100)
            {
                crow.heal(crow.quarter());
                output += crow.name() + " heals himself for " + crow.quarter() + " hp\r\n";
            }
            else
            {
                int target = r.Next(0, team.Count);
                while (team[target].health <= 0)//make sure target is alive
                    target = r.Next(0, team.Count);
                int def = team[target].defense + team[target].getArmor().defensebonus;
                output += dealDamage(crow.attack, def, crow.lvl, 0, power, team[target], crow, Crowbar);
                if (crow.hide)//if crow was hiding unhide
                {
                    crow.hide = !crow.hide;
                    output += crow.name() + " came out of hiding, damage modifiers have disappeared\r\n";
                }
            }
            output += crow.takePoison() + "\r\n";
            if (crow.health <= 0)
            {
                output += crow.name() + " died from poisoning";
                int gain = crow.xp();
                foreach (Hero z in team)
                    z.gainXP(gain);
            }
            field.Output.Text += (output);
        }

        #endregion


        /// <summary>
        /// return your name to the classes
        /// </summary>
        /// <returns></returns>
        public static string Name()//get name so Hero objects can access your name
        {
            return name;
        }

    }
}
