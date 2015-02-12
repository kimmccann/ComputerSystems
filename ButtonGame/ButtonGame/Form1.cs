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

namespace ButtonGame
{
    public partial class Form1 : Form
    {
        Button[,] buttons = new Button[3, 3];
        Random r = new Random();
        List<Tuple<int, int>> sequence = new List<Tuple<int, int>>();
        System.Timers.Timer t = new System.Timers.Timer();
        System.Timers.Timer t2 = new System.Timers.Timer();

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
            sequence.Add(new Tuple<int, int>(r.Next(3), r.Next(3)));

            //Creats our timer and it's events
            t.Interval = 5000;
            t2.Interval = 7500;
            t.Enabled = true;
            t2.Enabled = true;
            t.Elapsed += TimerEvent;
            t2.Elapsed += TimerEvent2;

        }

            

        void butt_Click(object sender, EventArgs e)
        {
            Console.WriteLine(((Button)sender).Text);

            if (((Button)sender) == buttons[sequence[0].Item1, sequence[0].Item2])
            {
                //buttons[r.Next(3), r.Next(3)].BackColor = Color.Red;
                Console.WriteLine("HIT!");
            }
            else
                Console.WriteLine("MISSED!");
        }

        private void TimerEvent(object sender, EventArgs e)
        {
            foreach (var element in sequence)
            {
                buttons[sequence[0].Item1, sequence[0].Item2].BackColor = Color.Red;
            }
            //Stops our button from repeatedly turning Red by ending the timer.
            t.Stop();
        }

        private void TimerEvent2(object sender, EventArgs e)
        {
            foreach (var element in sequence)
            {
                buttons[sequence[0].Item1, sequence[0].Item2].BackColor = Color.MediumTurquoise;
            }
            //Stops our button from repeatedly turning turquoise by ending the timer.
            t2.Stop();
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
