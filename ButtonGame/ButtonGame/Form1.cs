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

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {

        Button[,] b = new Button[3, 3];
        Random r = new Random();
        Button start = new Button();
        List<Tuple<int, int>> sequence = new List<Tuple<int, int>>();

        public Form1()
        {
            InitializeComponent();


            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    b[i, j] = new Button();
                    b[i, j].Name = "button" + (j + 1) + "," + (i + 1);
                    b[i, j].Text = Convert.ToString((j + 1) + "," + (i + 1));
                    b[i, j].Click += new EventHandler(this.Button_Click);
                    b[i, j].Location = new Point(105 * (i + 1), 105 * (j + 1));
                    b[i, j].Height = 100;
                    b[i, j].Width = 100;
                    b[i, j].BackColor = Color.MediumTurquoise;
                    this.Controls.Add(b[i, j]);
                }
            }
            start = new Button();
            start.Location = new Point(210,450);
            start.Height = 50;
            start.Width = 100;
            start.Text = "Start";
            start.Click += new EventHandler(this.Start_Game);
            this.Controls.Add(start);
        }

        public void gamePlay()
        {
            Console.WriteLine("Start of gamePlay again");
            createSequence();
            flashing(sequence);
            Console.WriteLine("flashed");
        }

        public void createSequence()
        {
            sequence.Add(new Tuple<int, int>(r.Next(3), r.Next(3)));
        }

        public void flashing(List<Tuple<int,int>> sequence){
            for (int i = 0; i < sequence.Count;i++)
            {
                b[sequence[i].Item1, sequence[i].Item2].BackColor = Color.Red;
                Task.Delay(5000).Wait();
                b[sequence[i].Item1, sequence[i].Item2].BackColor = Color.MediumTurquoise;
            }

        }


        //public void wait(int NoSecs)
        //{
        //    DateTime timeToWait = DateTime.Now.AddSeconds(NoSecs);
        //    while (DateTime.Now < timeToWait)
        //    {
        //        Console.WriteLine("waiting..");
        //    }
        //    Console.WriteLine("done waiting");
        //}


        private void Start_Game(object sender, EventArgs e)
        {
            gamePlay();
        }
       

        private void Button_Click(object sender, EventArgs e)
        {
            Console.WriteLine(((Button)sender).Text);
            for (int i = 0; i < sequence.Count; i++)
            {
                if (((Button)sender) == b[sequence[(sequence.Count - 1)].Item1, sequence[(sequence.Count - 1)].Item2])
                {
                    Console.WriteLine("HIT!");
                    gamePlay();
                }
                else if (((Button)sender) == b[sequence[i].Item1, sequence[i].Item2])
                {
                    Console.WriteLine("HIT!");
                }
                else
                {
                    Console.WriteLine("MISS!");
                }
            }
        }

        private void TimerEvent(object sender, EventArgs e)
        {
            for (int k = 0; k < sequence.Count; k++)
            {
                b[sequence[k].Item1, sequence[k].Item2].BackColor = Color.Red;
                Thread.Sleep(5000);
                b[sequence[k].Item1, sequence[k].Item2].BackColor = Color.MediumTurquoise;
            }
        }
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //About the program
        }

        private void howToPlayToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //How to play
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }


    }
}
