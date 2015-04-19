using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace RPG
{
    public interface Evil
    {
        int health { get; }//check for deaths
        int attack { get; }//use for damage calcs
        int defense { get; }//use for damage calcs
        void loot(bool x, BattleField field);//drops loot on death, if true then increase chances for better loot and increased loot.
        string name();//returns name of enemy
        void takeDamage(double damage);//takes damage
        int xp();//when defeated returns xp value for enemy
    }



    public abstract class Enemy:Evil
    {
        protected int maxhp;
        protected int hp;
        protected int atk;
        protected int def;
        protected int level;
        protected string title;
        protected double spd;
        protected double power;
        protected int acc;
        protected int poison = 0;//takes highest poison damage
        public Enemy()
        {
        }

        public double baseDamage()
        {
            return power;
        }

        public void setBaseDamage(double power)
        {
            this.power = power;
        }

        public int accucary
        {
            get { return acc; }
            set { acc = value; }
        }

        public bool getPoison(int x)
        {
            if (x > poison)
            {
                poison = x;
                return true;
            }
            return false;
        }

        public string takePoison()
        {
            takeDamage(poison);
            if (poison > 0)
                return name() + " took " + poison + " poison damage";
            return "";
        }

        public virtual void getStats(int level)
        {
            poison = 0;
            Thread.Sleep(100);//pause for .1 seconds
        }

        public bool danger()//returns true if enemy has less than 25% of their hp
        {
            return ((((hp * 1.0) / (maxhp)) * 100) <= 25.0) && (hp > 0);
        }

        public double speed
        {
            get { return spd; }
        }

        public int lvl
        {
            get { return level; }
        }

        public string enemyName
        {
            get { return title; }
        }

        public int maxhealth
        {
            get { return maxhp; }
        }

        public void takeDamage(double damage)
        {
            hp -= (int)damage;
            if (hp < 0)
                hp = 0;
        }

        public int health
        {
            get { return hp; }
            set { hp = value; }
        }

        public int attack
        {
            get { return atk; }
        }

        public int defense
        {
            get { return def; }
        }

        public override string ToString()
        {
            return title + " (Hp: " + hp + "/" + maxhp + ")";
        }

        public abstract void loot(bool x, BattleField field);
        public abstract string name();
        public abstract int xp();
  
    }
}
