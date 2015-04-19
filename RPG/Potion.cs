using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG
{
    public interface Consumable
    {
        void use(Hero x,BattleField field);//use consumable on hero
    }

    public abstract class Potion : Consumable//base case for all type of consumeable potions        
    {
        public Potion()
        {
        }

        public abstract void use(Hero x, BattleField field);
    }
}
