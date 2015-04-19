using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG
{
    abstract class Boss:Enemy
    {
        public Boss()
        {
            title = "Boss";
        }

        new public virtual void getStats(int level)
        {
            base.getStats(level);
        }

    new public int lvl//when boss creates minon, it becomes his level
    {
        get { return level; }
    }

    public void heal(int heal)
    {
        hp += heal;
        if (hp > maxhp)
            hp = maxhp;
    }

        public override string name()
        {
            return title;         
        }

        public override abstract int xp();
        public override abstract void loot(bool x, BattleField field);
    }
}
