using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;
using System.Threading;


namespace ButtonGame
{
    public partial class Form1 : Form
    {
        Button[,] buttons = new Button[3, 3];
        Random r = new Random();
        List<Tuple<int, int>> sequence = new List<Tuple<int, int>>();
        Button start = new Button();
        int score = 0;

        public Form1()
        {
            InitializeComponent();
            //Creates our 3 by 3 grid off buttons
            for (int i = 0; i < buttons.GetLength(0); i++)
            {
                for (int j = 0; j < buttons.GetLength(1); j++)
                {
                    buttons[i, j] = new Button();
                    buttons[i, j].Name = "button" + (i + 1) + "," + (j + 1);
                    buttons[i, j].Height = 100;
                    buttons[i, j].Width = 100;
                    buttons[i, j].Location = new Point(105 * (i + 1), 105 * (j + 1));
                    //buttons[i,j].Text = "button " + (i + 1) + "," + (j + 1);
                    buttons[i, j].Text = Convert.ToString((i + 1) + "," + (j + 1));
                    buttons[i, j].Click += new EventHandler(this.butt_Click);
                    buttons[i, j].BackColor = Color.FromArgb(111,233,172);
                    this.Controls.Add(buttons[i, j]);    
                }
            }
            start = new Button();
            start.Location = new Point(210, 450);
            start.Height = 50;
            start.Width = 100;
            start.Text = "Start";
            start.BackColor = Color.FromArgb(111, 233, 172);
            start.Click += new EventHandler(this.Start_Game);
            this.Controls.Add(start);
        }

        public void gamePlay()
        {
            Console.WriteLine("Start of gamePlay");
            createSequence();
            flashing(sequence);
            Console.WriteLine("flashed");
        }

        public void createSequence()
        {
            sequence.Add(new Tuple<int, int>(r.Next(3), r.Next(3)));
        }

        public void flashing(List<Tuple<int, int>> sequence)
        {
            for (int i = 0; i < sequence.Count; i++)
            {
                buttons[sequence[i].Item1, sequence[i].Item2].BackColor = Color.FromArgb(240,96,96);
                Task.Delay(5000).Wait();
                buttons[sequence[i].Item1, sequence[i].Item2].BackColor = Color.FromArgb(111, 233, 172);
                Task.Delay(1000).Wait();
            }
        }

        private void Start_Game(object sender, EventArgs e)
        {
            gamePlay();
        }

        void butt_Click(object sender, EventArgs e)
        {
            Console.WriteLine(((Button)sender).Text);
            for (int i = 0; i < sequence.Count; i++)
            {
                if (((Button)sender) == buttons[sequence[(sequence.Count - 1)].Item1, sequence[(sequence.Count - 1)].Item2])
                {
                    Console.WriteLine("The last button is:" + ((Button)sender).Text);
                    Console.WriteLine("HIT!");
                    score = score + 1;
                    Console.WriteLine("Your score is " + score);
                    gamePlay();
                }
                else if (((Button)sender) == buttons[sequence[i].Item1, sequence[i].Item2])
                {
                    Console.WriteLine("The button just clicked is:" + ((Button)sender).Text);
                    Console.WriteLine("HIT!");
                }
                else
                {
                    Console.WriteLine("The wrong button was clicked:" + ((Button)sender).Text);
                    Console.WriteLine("MISS!");
                }
            }
        }


        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void howToPlayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This game does xyz", "How to Play", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}
