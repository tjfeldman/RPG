using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG
{
    /// <summary>
    /// all return methods of stats
    /// </summary>
    public abstract partial class Hero : Good<Hero>//A hero is good and is the base class for your character and teammates
    {

        public void setName(string title)
        {
            if (this is Healer)
                this.title = title + " the Healer";
            else if (this is Guard)
                this.title = title + " the Guard";
            else if (this is Rogue)
                this.title = title + " the Rogue";
            else if (this is Theif)
                this.title = title + " the Theif";
            else if (this is Wizard)
                this.title = title + " the Wizard";
            else if (this is Scout)
                this.title = title + " the Scout";
            else
                this.title = title;

        }
        //set output for obtain weapons
        public void setOutput(string x)
        {
            output = x;
        }

        /// <summary>
        /// return character's stats
        /// </summary>
        /// <returns></returns>
        public string stats()
        {
            string stats;
            stats = "\r\nLevel: " + level;
            stats += "\r\nAttack: " + atk + " (+ " + currentWeapon.attackbonus + " bonus)";
            stats += "\r\nDefense: " + defense + " (+ " + currentArmor.defensebonus + " bonus)";
            stats += "\r\nCritial Chance: "  + critial + "% (+ " + currentWeapon.critbonus + "% bonus)";
            stats += "\r\nSpeed: " + speed;
            stats += "\r\nExp: " + exp();
            return stats;

        }

        /// <summary>
        /// return the hiding value
        /// </summary>
        public bool hiding
        {
            get { return hide; }
            set { hide = value; }
        }

        /// <summary>
        /// return the armor
        /// </summary>
        /// <returns></returns>
        public Armor getArmor()
        {
            return currentArmor;//.peek();
        }
        
        /// <summary>
        /// return the weapon
        /// </summary>
        /// <returns></returns>
        public Weapon getWeapon()
        {
            return currentWeapon;//.peek();
        }
        
        /// <summary>
        /// be able to read and adjus tthe energy value
        /// </summary>
        public int energy
        {
            get { return mana; }
            set { mana = value; }
        }

        /// <summary>
        /// read the max energy value
        /// </summary>
        public int maxenergy
        {
            get { return maxmana; }
            set { maxmana = value; }
        }

        /// <summary>
        /// replish energy
        /// </summary>
        /// <returns></returns>
        public virtual int replish()
        {
            return 0;
        }
        /// <summary>
        /// use x energy
        /// </summary>
        /// <param name="x"></param>
        public virtual void use(int x)
        {
        }

        /// <summary>
        /// read the current level of the character
        /// </summary>
        public int level
        {
            get { return lvl; }
            set { lvl = value; }
        }

        /// <summary>
        /// read the current boosted health
        /// </summary>
        public int health
        {
            get { return boostedhp; }
        }

        /// <summary>
        /// real the stat value of health, use for saving once implemented
        /// </summary>
        public int realhealth
        {
            get { return hp; }
            set { hp = value; }
        }

        /// <summary>
        /// read defense stat
        /// </summary>
        public int defense
        {
            get { return def; }
            set { def = value; }
        }

        /// <summary>
        /// read attack stat
        /// </summary>
        public int attack
        {
            get { return atk; }
            set { atk = value; }
        }


        /// <summary>
        /// read critial value
        /// </summary>
        public double critial
        {
            get { return crit; }
            set { crit = value; }
        }

        /// <summary>
        /// read the max health with armor bonus value
        /// </summary>
        public int maxhealth
        {
            get { return maxhp + getArmor().hpbonus; }
        }

        /// <summary>
        /// read the max health stat
        /// </summary>
        public int realmaxhealth
        {
            get { return maxhp; }
            set { maxhp = value; }
        }

        /// <summary>
        /// read the amount of xp a character has
        /// </summary>
        public int experience
        {
            get { return xp; }
            set { xp = value; }
        }

        /// <summary>
        /// read the speed stat
        /// </summary>
        public double speed
        {
            get { return spd; }
            set { spd = value; }
        }

        public override string ToString()
        {
            if (this is Warrior || this is Mage || this is Archer)
                return title + " (Hp: " + boostedhp + "/" + maxhealth + "   Energy:  " + energy + "/" + maxenergy + ")";
            return title + " (Hp: " + boostedhp + "/" + maxhealth + ")";
        }
        /// <summary>
        /// read the character's ability
        /// </summary>
        /// <returns></returns>
        public abstract string ability();
        /// <summary>
        /// read the character's name
        /// </summary>
        /// <returns></returns>
        public abstract string name();
    }
}
