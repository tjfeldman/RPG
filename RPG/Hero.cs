using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG
{
    public interface Good<T>
    {
        int health { get; }//check for deaths
        int attack { get;}//use for damage calcs
        int defense { get; }//use for damage calcs
        int level {get;}//get level
        double critial { get; }//use for damage calcs
        string LevelUp();//hero levels up and stats increase.
        string ability();//returns ability name
        string ToString();//prints name and health
        void Heal(int heal);//heal hero
        bool danger();//checks to see if hero is below 40%
        void takeDamage(double damage);//takes damage
        string name();//returns name of hero
        string exp();//get xp
     }

    public abstract partial class Hero:Good<Hero>//A hero is good and is the base class for your character and teammates
    {
        protected int maxhp;
        protected int hp;
        protected int boostedhp;
        protected int atk;
        protected int def;
        protected double crit;
        protected int lvl = 1;
        protected int xp = 0;
        protected int maxxp = 0;
        protected double spd;
        protected int mana = 0;
        protected int maxmana = 0;
        protected string title;
        private bool hide = false;
        protected Weapon currentWeapon;
        protected Armor currentArmor;
        private string output;
        public Hero()
        {
        }

        public Hero(World world)
        {
            
        }

        public void setStats(World world)
        {
            CharacterInfo info = world.charInfo(title);
            atk = info.atk();
            def = info.def();
            hp = info.hp();
            maxhp = hp;
            crit = info.crit();
            spd = info.spd();
            mana = info.energy();
            maxmana = mana;
        }

        /// <summary>
        /// Use for picking characters, by displaying the stats underneath the button choice
        /// </summary>
        /// <returns></returns>
        public string displayStat()
        {
            if (this is Healer)
                return name() + ":\r\nAbility: Can Heal Teammates\r\nHealth: " + maxhp + "\r\nAttack: " + atk + "\r\nDefense: " + def + "\r\nCritial Chance " + crit + "%\r\nSpeed: " + speed;
            else if (this is Scout)
                return name() + ":\r\nAbility: 25% Chance to do a Peircing Shot Through Defense\r\nHealth: " + maxhp + "\r\nAttack: " + atk + "\r\nDefense: " + def + "\r\nCritial Chance " + crit + "%\r\nSpeed: " + speed;
            else if (this is Guard)
                return name() + ":\r\nAbility: 25% Chance to Block Incoming Attacks\r\nHealth: " + maxhp + "\r\nAttack: " + atk + "\r\nDefense: " + def + "\r\nCritial Chance " + crit + "%\r\nSpeed: " + speed;
            else if (this is Rogue)
                return name() + ":\r\nAbility: 25% Chance to Perform a Second Strike\r\nHealth: " + maxhp + "\r\nAttack: " + atk + "\r\nDefense: " + def + "\r\nCritial Chance " + crit + "%\r\nSpeed: " + speed;
            else if (this is Theif)
                return name() + ":\r\nAbility: NOT STACKABLE:\r\nIncreases the Chance for Better Loot\r\nHealth: " + maxhp + "\r\nAttack: " + atk + "\r\nDefense: " + def + "\r\nCritial Chance " + crit + "%\r\nSpeed: " + speed;
            else if (this is Wizard)
                return name() + ":\r\nAbility: Strikes at 50% Power\r\nWith 20% Accucary Loss\r\nHealth: " + maxhp + "\r\nAttack: " + atk + "\r\nDefense: " + def + "\r\nCritial Chance " + crit + "%\r\nSpeed: " + speed;
            else if (this is Warrior)
                return name() + ":\r\nAbility: 25% Chance to Block Incoming Attacks\r\nHealth: " + maxhp + " Energy: " + maxenergy + "\r\nAttack: " + atk + "\r\nDefense: " + def + "\r\nCritial Chance " + crit + "%\r\nSpeed: " + speed;
            else if (this is Archer)
                return name() + ":\r\nAbility: 20% Damage Reduction, 10% Accucary Gain \r\nHealth: " + maxhp + " Energy: " + maxenergy + "\r\nAttack: " + atk + "\r\nDefense: " + def + "\r\nCritial Chance " + crit + "%\r\nSpeed: " + speed;
            else if (this is Mage)
                return name() + ":\r\nAbility: 50% Damage Boost, 10% Accucary Loss \r\nHealth: " + maxhp + " Energy: " + maxenergy + "\r\nAttack: " + atk + "\r\nDefense: " + def + "\r\nCritial Chance " + crit + "%\r\nSpeed: " + speed;
            return "";

        }

        /// <summary>
        /// have hero regen health if the armor has that bonus
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public string regen(int x)
        {
            if (x + boostedhp >= maxhealth)
                x = maxhealth - boostedhp;
            Heal(x);
            if (x > 0)
                return name() + " regenerated " + x + " health this turn";
            return "";
        }

        /// <summary>
        /// equip the new piece of armor to this character
        /// </summary>
        /// <param name="x"></param>
        public void equipArm(Armor x)
        {
            currentArmor = x;
            getBoosted();
        }

        /// <summary>
        /// equip new weapon to this character
        /// </summary>
        /// <param name="x"></param>
        public void equipWep(Weapon x)
        {   
            currentWeapon = x;
        }

        /// <summary>
        /// get your first armor
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public string AquireArmor(Hero x)
        {
            currentArmor = new Armor(x);
            getBoosted();
            return output;
        }

        /// <summary>
        /// get your first weapon
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public string AquireWeapon(Hero x)
        {
            currentWeapon = new Weapon(x);
            return output;
        }

        /// <summary>
        /// hero takes x damage
        /// </summary>
        /// <param name="damage"></param>
        public void takeDamage(double damage)
        {
            hp -= (int)damage;
            if (hp < -currentArmor.hpbonus)
                hp = -currentArmor.hpbonus;
            getBoosted();
        }

        /// <summary>
        /// calculate percentage of maxium health
        /// </summary>
        /// <param name="percent"></param>
        /// <returns></returns>
        public int calcPercent(double percent)
        {
            return (int)(maxhealth * (percent / 100.0));
        }

        /// <summary>
        /// if hero has 25% or less total health return true
        /// </summary>
        /// <returns></returns>
        public bool danger()
        {
            if ((boostedhp / (maxhealth * 1.0) < .40))
                return true;
            return false;
        }

        /// <summary>
        /// displays hp with armor bonus added
        /// </summary>
        public void getBoosted()
        {
            boostedhp = hp + getArmor().hpbonus;
        }

        /// <summary>
        /// heal hero by x amount
        /// </summary>
        /// <param name="heal"></param>
        public virtual void Heal(int heal)
        {
            if (hp < -getArmor().hpbonus)
                hp = -getArmor().hpbonus;
            hp += heal;
            if (hp > maxhp)
                hp = maxhp;
            getBoosted();
        }

        /// <summary>
        /// hero got enough xp to level up
        /// </summary>
        /// <returns></returns>
        public virtual string LevelUp()
        {
            
            lvl++;
            return ("\r\n" + name() + " gained a level");
        }

        /// <summary>
        /// have hero gain xp
        /// </summary>
        /// <param name="xp"></param>
        /// <returns></returns>
        public virtual string gainXP(int xp)
        {
            this.xp += xp;
            return "";
        }

        /// <summary>
        /// print out hero's exp
        /// </summary>
        /// <returns></returns>
        public virtual string exp()
        {
        
            return (xp + "/" + maxxp); 
        }

       
    }
}
