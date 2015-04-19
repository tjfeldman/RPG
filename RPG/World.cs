using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace RPG
{
    public class World
    {
        private Room[] rooms;
        private List<Enemy> enemies;
        private List<Attacks> attacks = new List<Attacks>();
        private List<CharacterInfo> info = new List<CharacterInfo>();
        private string FileLocation = "Rooms.txt";
        public World(Program x)
        {
            /*
             * # of Rooms
             * Room #
             * Enemy Type 1
             * Enemy Type 2
             * Enemy Type 3
             * Room #
             * Enemy Type 1
             * etc
             * 0
             * * */
            try
            {
                using (FileStream fs = File.OpenRead(FileLocation))
                {
                using (TextReader reader = new StreamReader(fs))
                    createRooms(reader, x);
                }
                
            }
            catch (FileNotFoundException)
            {
                OpenFileDialog dlg = new OpenFileDialog(); // prompt for file
                dlg.Filter = "txt files (*.txt)|*.txt";    // just text
                dlg.FilterIndex = 1;                       // only one option           
                dlg.RestoreDirectory = false;              // let player keep opening same directory
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    FileLocation = dlg.FileName;
                    using (TextReader reader = File.OpenText(FileLocation))
                        createRooms(reader, x);
                }
            }
            readAttacks();
            readHeros();
        }

        public World(Program x, string FileLocation)
        {
            this.FileLocation = FileLocation;
            using (FileStream fs = File.OpenRead(FileLocation))
            {
                using (TextReader reader = new StreamReader(fs))
                    createRooms(reader, x);
            }
            readAttacks();
            readHeros();
        }

        /// <summary>
        /// reads the attack text file
        /// </summary>
        public void readAttacks()
        {
            try
            {
                //Get the attacks
                using (FileStream fs = File.OpenRead("Attacks.txt"))
                {
                    using (TextReader reader = new StreamReader(fs))
                    {
                        while (!reader.Peek().Equals(""))
                        {
                            string read;
                            double power;
                            int acc;
                            read = reader.ReadLine();
                            power = double.Parse(reader.ReadLine());
                            acc = int.Parse(reader.ReadLine());
                            attacks.Add(new Attacks(read, power, acc));
                        }

                        reader.Close();
                    }
                }
            }
            catch (Exception)
            {
                ///something will happen
            }
        }

        /// <summary>
        /// reads the heros text file
        /// </summary>
        public void readHeros()
        {
            try
            {
                ///get Hero base stats
                using (FileStream fs = File.OpenRead("Heros.txt"))
                {
                    using (TextReader reader = new StreamReader(fs))
                    {
                        while (!reader.Peek().Equals(""))
                        {
                            string name = reader.ReadLine();
                            reader.ReadLine();
                            int health = int.Parse(reader.ReadLine());
                            reader.ReadLine();
                            int mana = int.Parse(reader.ReadLine());
                            reader.ReadLine();
                            int attack = int.Parse(reader.ReadLine());
                            reader.ReadLine();
                            int defense = int.Parse(reader.ReadLine());
                            reader.ReadLine();
                            double crit = double.Parse(reader.ReadLine());
                            reader.ReadLine();
                            double speed = double.Parse(reader.ReadLine());
                            info.Add(new CharacterInfo(name, health, mana, attack, defense, crit, speed));

                        }
                        reader.Close();
                    }
                }
            }
            catch (Exception)
            {
                ///do a check
            }
        }

        /// <summary>
        /// take each room data and create a list of enemies that Class Room will store
        /// </summary>
        /// <param name="fs"></param>
        public void createRooms(TextReader reader, Program x)
        {
            try
            {
                int number;

                int trash;
                number = int.Parse(reader.ReadLine());//get number of rooms
                rooms = new Room[number];
                reader.ReadLine();//drop first room number
                for (int y = 0; y < number; y++)//create an array for all rooms
                {
                    enemies = new List<Enemy>();
                    string data = reader.ReadLine();
                    while (!int.TryParse(data, out trash))//cycle until the next room is reached
                    {
                        data = data.ToLower();
                        if (data.Equals("minor"))
                            enemies.Add(new Minor());
                        else if (data.Equals("normal"))
                            enemies.Add(new Normal());
                        else if (data.Equals("shadow"))
                            enemies.Add(new Shadow());
                        else if (data.Equals("greater"))
                            enemies.Add(new Greater());
                        else if (data.Equals("sniper"))
                            enemies.Add(new Sniper());
                        else if (data.Equals("crowman"))
                            enemies.Add(new Crowman());
                        else if (data.Equals("ninja"))
                            enemies.Add(new Ninja());
                        else
                            throw new MissingMemberException();
                        data = reader.ReadLine();
                    }
                    rooms[y] = new Room(enemies, x, this);
                }
                x.last = number;

            }
            catch (MissingMemberException)
            {
                new Popup("The file contained an error, there was an undeclared enemy type.\r\n Please make sure that all enemies are either minor, normal, shadow, greater, sniper, crowman, or ninja").Show();
                System.Threading.Thread.Sleep(5000);//give user time to click okay
                OpenFileDialog dlg = new OpenFileDialog(); // prompt for file
                dlg.Filter = "txt files (*.txt)|*.txt";    // just text
                dlg.FilterIndex = 1;                       // only one option           
                dlg.RestoreDirectory = false;              // let player keep opening same directory
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    using (reader = File.OpenText(dlg.FileName))
                        createRooms(reader, x);
                }
            }
            reader.Close();
        }

        /// <summary>
        /// return data about a room
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public Room this[int x]
        {
            get { return rooms[x - 1]; }
        }

        public Room[] Rooms
        {
            get { return rooms; }
            set { rooms = value; }
        }

        /// <summary>
        /// return how many possible rooms exist
        /// </summary>
        public int count
        {
            get { return rooms.Length; }
        }

        /// <summary>
        /// returns the file location
        /// </summary>
        /// <returns></returns>
        public string getFileLocation()
        {
            return FileLocation;
        }
        /// <summary>
        /// returns the list of attacks
        /// </summary>
        /// <returns></returns>
        public List<Attacks> attackList()
        {
            return attacks;
        }

        public CharacterInfo charInfo(string name)
        {
            foreach (CharacterInfo x in info)
            {
                if (x.name().Equals(name))
                    return x;
            }
            return null;
        }
    }
}

