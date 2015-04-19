using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Threading;

namespace RPG
{
    public partial class CharacterName : Form, Confirmation
    {
        public bool confirm = false;
        private string name="";
        private string prompt;
        private Program game;
        public CharacterName(Program z,string prompt,string name)
        {
            InitializeComponent();
            this.prompt = prompt;
            game = z;
            Prompt.Text = prompt;
            name = name.ToLower();
            if (name.Equals("wizard"))
                CharName.Text = "Merlin";
            else if (name.Equals("scout"))
                CharName.Text = "Powell";
            else if (name.Equals("rogue"))
                CharName.Text = "Sothe";
            else if (name.Equals("guard"))
                CharName.Text = "Zack";
            else if (name.Equals("thief"))
                CharName.Text = "Volke";
            else if (name.Equals("healer"))
                CharName.Text = "Aerith";
            this.name = CharName.Text; 
        }

        public bool sure
        {
            set { confirm = value; }
            get { return confirm; }
        }


        /// <summary>
        /// if exit button was pressed, don't let the form close until a name was entered
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CharacterName_FormClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (name.Equals(""))
            {
                e.Cancel = true;
                new Popup("Sorry, but you cannot close yet\r\nbecause you have entered no data").Show();
            }
            else
            {
                game.setName(name);
                game.nextStep();
            }
        }

        /// <summary>
        /// Check to see if the name is legal, and then send it back to the main Program
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Accept_Click(object sender, EventArgs e)
        {
            name = CharName.Text;
            name = name.Trim();
            try
            {
                if (!name.Equals(""))
                {
                    Regex RgxUrl = new Regex("[^a-zA-Z]");//make sure that there are no special characters in the input
                    if (RgxUrl.IsMatch(name))
                    {
                        throw new NotImplementedException();
                    }
                    else
                    {
                            this.Close();
                    }
                }
                else
                    throw new InvalidConstraintException();
            }
            catch (NotImplementedException)
            {
                Prompt.Text = "Sorry but there was illegal characters in your name\r\nPlease enter a new name";
            }
            catch (InvalidConstraintException)
            {
                Prompt.Text = "Sorry but your name had no characters in it\r\nPlease enter at least 1 character before you press accept";
            }
           
        }

    }
}
