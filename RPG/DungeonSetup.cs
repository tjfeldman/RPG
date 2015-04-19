using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace RPG
{
    public class DungeonSetup
    {
        public List<Enemy> left;
        public List<Enemy> forward;
        public List<Enemy> right;
        public List<Enemy> choice;
        public Color leftcolor;
        public Color rightcolor;
        public Color forwardcolor;
        public Color backcolor;
        public DungeonSetup(List<Enemy> left, List<Enemy> forward, List<Enemy> right, List<Enemy> choice, Color leftcolor, Color forwardcolor, Color rightcolor, Color backcolor)
        {
            this.left = left;
            this.forward = forward;
            this.right = right;
            this.choice = choice;
            this.leftcolor = leftcolor;
            this.forwardcolor = forwardcolor;
            this.rightcolor = rightcolor;
            this.backcolor = backcolor;
        }
    }
}
