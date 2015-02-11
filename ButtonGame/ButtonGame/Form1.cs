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
        System.Timers.Timer timer1 = new System.Timers.Timer();

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
                    buttons[i, j].BackColor = Color.MediumTurquoise;
                    this.Controls.Add(buttons[i, j]);
                }
            }
            sequenceButtons();
        }

        public void sequenceButtons()
        {
            sequence.Add(new Tuple<int, int>(r.Next(3), r.Next(3)));
            Console.WriteLine("bla");
            //Creats our timers and it's events
            timer1.Interval = 5000;
            timer1.Enabled = true;
            timer1.Elapsed += TimerEvent;
        }

            

        void butt_Click(object sender, EventArgs e)
        {
            Console.WriteLine(((Button)sender).Text);

            for (int i = 0; i < sequence.Count; i++)
            {
                Console.Write(sequence.Count);
                if (((Button)sender) == buttons[sequence[i].Item1, sequence[i].Item2])
                {
                    //If the user is right, add another item to the sequence.
                    Console.WriteLine("HIT!");
                    sequenceButtons();
                }
                else
                    Console.WriteLine("MISSED!");
            }
        }

        private void TimerEvent(object sender, EventArgs e)
        {
            for (int k = 0; k < sequence.Count; k++)
            {
                Console.Write(sequence.Count);
                Console.Write("sequence is " + sequence[k]);
                buttons[sequence[k].Item1, sequence[k].Item2].BackColor = Color.Red;
                Thread.Sleep(5000);
                buttons[sequence[k].Item1, sequence[k].Item2].BackColor = Color.MediumTurquoise;
            }
            //Stops our button from repeatedly turning Red by ending the timer.
            timer1.Enabled = false;
        }



        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
