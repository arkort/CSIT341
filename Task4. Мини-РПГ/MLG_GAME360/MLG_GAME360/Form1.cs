using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAO;


namespace MLG_GAME360
{
    public partial class Form1 : Form
    {
        private GameLogic gameLogic;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Step.Enabled = false;
            this.PlayerStats.Visible = false;
        }

        private void NewGame_Click(object sender, EventArgs e)
        {
            HistoryEvents.Items.Clear();
            gameLogic = new GameLogic();
            this.Step.Enabled = true;
            this.PlayerStats.Visible = true;
            gameLogic.GameStart();
            this.PlayerStats.Text = gameLogic.InfoPlayer();
        }

        private void Step_Click(object sender, EventArgs e)
        {
            HistoryEvents.Items.Add(gameLogic.GameStep());

            this.PlayerStats.Text = gameLogic.InfoPlayer();
            if (gameLogic.IsEndGame)
            {
                HistoryEvents.Items.Add(gameLogic.CheckGame());
                this.Step.Enabled = false;
            }
            HistoryEvents.SelectedIndex = HistoryEvents.Items.Count - 1; //autoscroll
            HistoryEvents.SelectedIndex = -1;
        }
    }
}
