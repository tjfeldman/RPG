using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace RPG
{
    public partial class Cutscene : Form, Confirmation
    {
        private bool skip;
        private bool start;
        private Program game;
        public Cutscene(string cutscene, bool start, Program game)
        {
            InitializeComponent();
            Prompt.Text = cutscene;
            this.start = start;
            this.game = game;
        }

        public bool sure
        {
            get { return skip; }
            set { skip = value; }
        }

        public Cutscene(string[] cutscene)
        {
            new Confirm(this, "Skip Cutscene?").ShowDialog();
            InitializeComponent();
            Prompt.Text = "";
            createCutscene(cutscene);
        }

        /// <summary>
        /// creates a time delay between the text appearing
        /// </summary>
        /// <param name="cutscene"></param>
        public void createCutscene(string[] cutscene)
        {
            for (int x = 0; x < cutscene.Length; x++)
            {
                Prompt.Text += cutscene[x] + "\r\n";
            }
        }

        private void Done_Click(object sender, EventArgs e)
        {
               this.Close();
        }

        private void Cutscene_Load(object sender, EventArgs e)
        {
            if (sure)
                this.Close();
        }

        private void Cutscene_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (start)
                game.nextStep();
        }
    }
}
