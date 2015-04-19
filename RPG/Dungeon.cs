using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RPG
{
    public partial class Dungeon : Form, Confirmation
    {
        private List<DungeonSetup> LastLocations = new List<DungeonSetup>();
        private List<Enemy> forwardLocation = null;
        private List<Enemy> leftLocation = null;
        private List<Enemy> rightLocation = null;
        private List<int> sections = new List<int>(-1);
        private List<Button> directions = new List<Button>();
        private Program game;
        private World world;
        private int count = 0;//how many rooms you have moved fowarded in
        private int required;//how many rooms you need to move forward in
        private int position = 0;//what room you are currently in
        public int set = 0;//current area
        private int numrooms = 0;
        private bool backtrack = false;
        private bool start = false;
        private int maxArea = 0;
        private bool saved;
        private bool quit = false;
        public Dungeon(Program game, World world)
        {
            InitializeComponent();
            this.game = game;
            this.world = world;
            Forward.Enabled = false;
            Right.Enabled = false;
            Left.Enabled = false;
            Back.Enabled = false;
            directions.Add(Left);
            directions.Add(Forward);
            directions.Add(Right);
            Respawn.Text = "";
            Location.Text = "";
            start = false;
        }

        public bool sure
        {
            get { return quit; }
            set { quit = value; }
        }


        /// <summary>
        /// when you start a new game, begin back from the beginning
        /// </summary>
        public void StartNewGame()
        {
            set = 0;
            newArea();
        }
        /// <summary>
        /// when you reach a new area, set it up
        /// </summary>
        public void newArea()
        {
            start = true;
            this.Enabled = true;
            position = 0;
            count = 0;
            LastLocations = new List<DungeonSetup>();
            required = game.getRandom().Next(5, 11);//get the number of rooms you must move foward in before you can meet the next boss
            Left.Enabled = false;
            Left.BackColor = Control.DefaultBackColor;
            Right.Enabled = false;
            Right.BackColor = Control.DefaultBackColor;
            Forward.Enabled = true;
            Forward.BackColor = Control.DefaultBackColor;
            Forward.BackColor = Color.Green;
            forwardLocation = world[sections[set] + 2].Enemies;
            getBossSection();
            Location.Text = "Current Room: " + Current();
            Respawn.Text = "Rooms Left til Boss: " + RoomsLeft();
            Back.Enabled = false;
            Back.BackColor = Control.DefaultBackColor;
        }

        /// <summary>
        /// get and set last locations
        /// </summary>
        public List<DungeonSetup> lastLocations
        {
            get { return LastLocations; }
            set { LastLocations = value; }
        }

        /// <summary>
        /// returns if player is going back through the dungeon
        /// </summary>
        public bool backtracking
        {
            get { return backtrack; }
            set { backtrack = value; }
        }

        /// <summary>
        /// returns the enemies forward of you
        /// </summary>
        public List<Enemy> forwardEnemies
        {
            get { return forwardLocation; }
            set { forwardLocation = value; }
        }

        /// <summary>
        /// returns enemies to the right of you
        /// </summary>
        public List<Enemy> rightEnemies
        {
            get { return rightLocation; }
            set { rightLocation = value; }
        }
            
        /// <summary>
        /// returns enemies to the left of you
        /// </summary>
        public List<Enemy> leftEnemies
        {
            get { return leftLocation; }
            set { leftLocation = value; }
        }
        /// <summary>
        /// return current room/position
        /// </summary>
        /// <returns></returns>
        public int Current()
        {
            return position;
        }

        /// <summary>
        /// set the position
        /// </summary>
        /// <param name="position"></param>
        public void setPosition(int position)
        {
            this.position = position;
        }

        /// <summary>
        /// move to next boss
        /// </summary>
        public void nextSet()
        {
            set++;

            if (sections[set] > world.count - 2)
            {
                new Popup("You have beat the last boss! You have beat the game,\r\nbut you are free to go back to any area and play some more").Show();
                set--;
            }
            else
            {
                new Popup("You have beat the boss, and now its time to go on to the next area").Show();
            }
            if (set > maxArea)
                maxArea = set;
        }

        /// <summary>
        /// return the max number of areas
        /// </summary>
        /// <returns></returns>
        public int getAreas()
        {
            return maxArea;
        }

        /// <summary>
        /// set the max number of areas you unlocked
        /// </summary>
        /// <param name="max"></param>
        public void newMax(int max)
        {
            maxArea = max;
        }

        /// <summary>
        /// get or set the required rooms
        /// </summary>
        public int requiredRooms
        {
            get { return required; }
            set { required = value; }
        }

        public void setArea(int area)
        {
            set = area;
            foreach (Hero x in game.PlayerTeam)
            {
                x.realhealth = x.realmaxhealth;
                x.getBoosted();
                x.energy = x.maxenergy;
            }
            newArea();
        }

        public int currentArea()
        {
            return set;
        }

        public void setCurrentArea(int area)
        {
            set = area;
        }


        /// <summary>
        /// return how many rooms are left til boss
        /// </summary>
        /// <returns></returns>
        public int RoomsLeft()
        {
            return required - position;
        }

        public List<Enemy> enemies
        {
            get { return LastLocations[position].choice; }
        }

        /// <summary>
        /// get or set the amount of rooms you have moved forwarded in
        /// </summary>
        public int amount
        {
            get { return count; }
            set { count = value; }
        }

        /// <summary>
        /// add to the stack the last location
        /// </summary>
        private void addLastLocation(List<Enemy> choice)
        {
            LastLocations.Add(new DungeonSetup(leftLocation, forwardLocation, rightLocation, choice, Left.BackColor, Forward.BackColor, Right.BackColor, Back.BackColor));
        }

       
        /// <summary>
        /// creates a random dungeon
        /// </summary>
        public void setUpRooms()
        {
            Back.Enabled = true;
            numrooms = 0;
            for (int x = (sections[set]); x < sections[set + 1] - 1; x++)//find out how many rooms exist before the next boss
            {
                numrooms++;
            }
            //make random directions
            for (int x = 0; x < directions.Count; x++)
            {
                if (game.getRandom().Next(0,2) == 1)
                {
                    directions[x].Enabled = true;
                }
                else
                {
                    directions[x].Enabled = false;
                }
            }
            //if no buttons are enabled, make the forward button enabled
            int enabled = 0;
            foreach (Button x in directions)
            {
                if (x.Enabled)
                    enabled ++;
            }
            if (enabled == 0)
            {
                Forward.Enabled = true;
            }
            //if button is enabled, then pick a random group of enemies to exist
            if (Left.Enabled)
            {
                int random = game.getRandom().Next(0, numrooms);
                if (random == 0)
                    Left.BackColor = Color.Green;
                if (random > 0 && random <= numrooms - 2)
                    Left.BackColor = Color.Gold;
                if (random > numrooms - 2)
                    Left.BackColor = Color.Orange;
                leftLocation = world[sections[set] + 2 + random].Enemies;
            }
            if (Forward.Enabled)
            {
                int random = game.getRandom().Next(0, numrooms);
                if (random == 0)
                    Forward.BackColor = Color.Green;
                if (random > 0 && random <= numrooms - 2)
                    Forward.BackColor = Color.Gold;
                if (random > numrooms - 2)
                    Forward.BackColor = Color.Orange;
                forwardLocation = world[sections[set] + 2 + random].Enemies;
            }
            if (Right.Enabled)
            {
                int random = game.getRandom().Next(0, numrooms);
                if (random == 0)
                    Right.BackColor = Color.Green;
                if (random > 0 && random <= numrooms - 1)
                    Right.BackColor = Color.Gold;
                if (random > numrooms - 1)
                    Right.BackColor = Color.Orange;
                rightLocation = world[sections[set] + 2 + random].Enemies;
            }
            foreach (Button x in directions)
                if (!x.Enabled)
                    x.BackColor = Control.DefaultBackColor;
        }


        /// <summary>
        /// recreate the area before
        /// </summary>
        public void recreateRoom()
        {
            Back.Enabled = true;
            if (position == 0)
            {
                Back.Enabled = false;
                Back.BackColor = Control.DefaultBackColor;
            }
            else
            {
                Back.BackColor = LastLocations[position].backcolor;
            }
            if (LastLocations[position].left != null)
            {
                leftLocation = LastLocations[position].left;
                Left.Enabled = true;
                Left.BackColor = LastLocations[position].leftcolor;
            }
            else
            {
                Left.Enabled = false;
                Left.BackColor = Control.DefaultBackColor;
            }
            if (LastLocations[position].forward != null)
            {
                forwardLocation = LastLocations[position].forward;
                Forward.Enabled = true;
                Forward.BackColor = LastLocations[position].forwardcolor;
            }
            else
            {
                Forward.Enabled = false;
                Forward.BackColor = Control.DefaultBackColor;
            }
            if (LastLocations[position].right != null)
            {
                rightLocation = LastLocations[position].right;
                Right.Enabled = true;
                Right.BackColor = LastLocations[position].rightcolor;
            }
            else
            {
                Right.Enabled = false;
                Right.BackColor = Control.DefaultBackColor;
            }
            if (position == count)
            {
                LastLocations.Remove(LastLocations[LastLocations.Count - 1]);
            }
        }

        /// <summary>
        /// create bosses Realm
        /// </summary>
        public void createBoss()
        {
            Right.Enabled = false;
            Left.Enabled = false;
            Forward.Enabled = true;
            forwardLocation = world[sections[set] + 5].Enemies;
            leftLocation = null;
            rightLocation = null;
            Forward.BackColor = Color.Red;
            Left.BackColor = Control.DefaultBackColor;
            Right.BackColor = Control.DefaultBackColor;
        }

        /// <summary>
        /// find out what the areas between bosses are
        /// </summary>
        public void getBossSection()
        {
            sections = new List<int>(-1);
            for (int x = 0; x < world.count - 1; x++)
            {
                for (int y = 0; y < world[x + 1].Enemies.Count; y++)
                {
                    if (world[x + 1].Enemies[y] is Boss)
                    {
                        sections.Add(x);
                        x++;
                    }
                }
            }
            sections.Add(world.count - 1);
        }

        /// <summary>
        /// move on to the next area
        /// </summary>
        public void next()
        {
            this.Enabled = true;
            if (position == required)
            {
                createBoss();
            }
            else if (count > required)
            {
                newArea();
            }
            else if (position == count && !backtrack)
                setUpRooms();
            else
            {
                recreateRoom();
                if (position == count)
                    backtrack = false;
            }
            Location.Text = "Current Room: " + Current();
            Respawn.Text = "Rooms Left til Boss: " + RoomsLeft();
        }

        #region move
        /// <summary>
        /// Click a button and move to that room
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void Forward_Click(object sender, EventArgs e)
        {
            saved = false;
            if (LastLocations.Count > 0)
            {
                if (LastLocations[position - 1].choice != forwardLocation)
                {
                    for (int z = LastLocations.Count - 1; z >= position; z--)
                        LastLocations.Remove(LastLocations[z]);
                    count = position;
                    backtrack = false;
                }
            }
            position ++;
            if (position > count)
            {
                addLastLocation(forwardLocation);
                backtrack = false;
                count++;
            }
            game.enemies = LastLocations[position - 1].choice;
            this.Enabled = false;
            Back.BackColor = Forward.BackColor;
            new BattleField(game,forwardLocation, this).Show();

        }

        private void Left_Click(object sender, EventArgs e)
        {
            saved = false;
            if (LastLocations.Count > 0)
            {
                if (LastLocations[position - 1].choice != leftLocation)
                {
                    for (int z = LastLocations.Count - 1; z >= position; z--)
                        LastLocations.Remove(LastLocations[z]);
                    count = position;
                    backtrack = false;
                }
            }
            position ++;
            if (position > count)
            {
                addLastLocation(leftLocation);
                backtrack = false;
                count++;
            }
            this.Enabled = false;
            Back.BackColor = Left.BackColor;
            game.enemies = LastLocations[position-1].choice;
            new BattleField(game,leftLocation, this).Show();
        }

        private void Right_Click(object sender, EventArgs e)
        {
            saved = false;
            if (LastLocations.Count > 0)
            {
                if (LastLocations[position - 1].choice != rightLocation)
                {
                    for (int z = LastLocations.Count - 1; z >= position; z--)
                        LastLocations.Remove(LastLocations[z]);
                    count = position;
                    backtrack = false;
                }
            }
            position ++;
            if (position > count)
            {
                addLastLocation(rightLocation);
                count++;
                backtrack = false;
            }
            this.Enabled = false;
            Back.BackColor = Right.BackColor;
            game.enemies = LastLocations[position - 1].choice;
            new BattleField(game,rightLocation, this).Show();
        }

        private void Back_Click(object sender, EventArgs e)
        {
            saved = false;
            backtrack = true;
            if (position == count)
            {
                addLastLocation(null);
            }
            position --;
            game.enemies = LastLocations[position].choice;
            this.Enabled = false;
            new BattleField(game,LastLocations[position].choice, this).Show();
        }
#endregion

        #region Menus
        private void GoToArea_Click(object sender, EventArgs e)
        {
            if (start)
            {
                new GoTo(this).Show();
            }
        }

        private void BeginNewGame_Click(object sender, EventArgs e)
        {
            start = false;
            this.Enabled = false;
            game.newGame();
        }

        #endregion

        private void SaveGame_Click(object sender, EventArgs e)
        {
            if (start)
            {
                game.getSave().save();
                saved = true;
            }
        }

        private void LoadGame_Click(object sender, EventArgs e)
        {
            game.getSave().LoadGame();
            Location.Text = "Current Room: " + Current();
            Respawn.Text = "Rooms Left til Boss: " + RoomsLeft();
            getBossSection();
            foreach (Button x in directions)
            {
                if (x.BackColor.Equals(Control.DefaultBackColor))
                    x.Enabled = false;
                else
                    x.Enabled = true;
            }
            if (Back.BackColor.Equals(Control.DefaultBackColor))
                Back.Enabled = false;
            else
                Back.Enabled = true;
            start = true;
        }

        /// <summary>
        /// if player didn't save before exiting ask them if they want to save
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Dungeon_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!saved && start)
            {
                new Confirm(this, "Do you want to save before closing?", "close").Show();
                e.Cancel = true;
            }

        }

        public void CloseSave()
        {
            saved = true;
            if (sure)
            {
                game.getSave().save();
            }
            this.Close();
        }

        private void HowToPlay_Click(object sender, EventArgs e)
        {
            new GameHelp().Show();
        }

        private void ItemInfo_Click(object sender, EventArgs e)
        {
            new ItemInfo().Show();
        }


    }
}
