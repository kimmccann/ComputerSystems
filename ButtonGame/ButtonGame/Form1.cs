using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ButtonGame
{
    public partial class Form1 : Form
    {
        Button[,] buttons = new Button[3, 3];
        Random r = new Random();

        public Form1()
        {
            InitializeComponent();
            //Creates our 3 by 3 grid off buttons
            for (int i = 0; i < buttons.GetLength(0); i++){
                for (int j = 0; j < buttons.GetLength(1); j++)
                {
                    buttons[i,j] = new Button();
                    buttons[i,j].Name = "button" + (i + 1) + "," + (j + 1);
                    buttons[i,j].Height = 100;
                    buttons[i,j].Width = 100;
                    buttons[i,j].Location = new Point(105 * (i + 1), 105 * (j + 1));
                    //buttons[i,j].Text = "button " + (i + 1) + "," + (j + 1);
                    buttons[i,j].Text = Convert.ToString((i + 1) + "," + (j + 1));
                    buttons[i,j].Click += new EventHandler(this.butt_Click);
                    buttons[i,j].BackColor = Color.MediumTurquoise;
                    this.Controls.Add(buttons[i,j]);
                }
            }

            buttons[r.Next(3), r.Next(3)].BackColor = Color.Red;
        }

        void butt_Click(object sender, EventArgs e)
        {
            Console.WriteLine(((Button)sender).Text);

            if (((Button)sender).BackColor == Color.Red)
            {
                ((Button)sender).BackColor = Color.MediumTurquoise;
                buttons[r.Next(3), r.Next(3)].BackColor = Color.Red;
                Console.WriteLine("HIT!");
            }
            else
                Console.WriteLine("MISSED!");
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
