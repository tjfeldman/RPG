using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.IO;

namespace RPG
{
    public class Room
    {
        /// <summary>
        /// store the enemies in the private List
        /// </summary>
        private List<Enemy> enemies;
        public Room(List<Enemy> enemies, Program y, World w)
        {
            int count = 0;
            this.enemies = enemies;
            foreach (Enemy x in enemies)
                if (x is Boss)
                {
                    count++;
                }
            if (count > 1)
            {
                new Popup("Error, there was two bosses found in this room file, please make corrections and give us the right file").Show();
                Thread.Sleep(5000);//give user time to read popup
                OpenFileDialog dlg = new OpenFileDialog(); // prompt for file
                dlg.Filter = "txt files (*.txt)|*.txt";    // just text
                dlg.FilterIndex = 1;                       // only one option           
                dlg.RestoreDirectory = false;              // let player keep opening same directory
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    using (TextReader reader = File.OpenText(dlg.FileName))
                        w.createRooms(reader, y);
                }
            }

        }

        public int Count
        {
            get { return enemies.Count; }
        }

        /// <summary>
        /// allow other classes to read the private list
        /// </summary>
        public List<Enemy> Enemies
        {
            get { return enemies; }
        }
    }
}
