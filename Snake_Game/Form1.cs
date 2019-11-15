using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake_Game
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int x;
        int y;
        static int GSize = 35;
        grid[,] grid = new grid[GSize, GSize];
        const int tick = 100;
        int length = 0;

        List<Point> points = new List<Point>();
        int posY = 10;
        int posX = 19;
        string direction = "Left";

        Random ran = new Random();
        int locX;
        int locY;
        bool deadGame = true;
        bool firsttime = true;
        bool pause = false;

        List<grid> location = new List<grid>();

        private void Form1_Load(object sender, EventArgs e)
        {
            deadGame = false;
            points.Add(new Point(posX, posY));

            time_Movement.Interval = tick;
            for (int o = 0; o < GSize; o++)
            {
                x = 0;
                for (int i = 0; i < GSize; i++)
                {
                    grid[o, i] = new grid(x, y);
                    //this finally adds each of the squares in to the panel - therefore displaying them on the screen.
                    this.panel1.Controls.Add(grid[o, i]);
                    x = x + 15;
                }
                y = y + 15;

            }
            fruit();
            time_Movement.Start();
            firsttime = false;

        }


        private void update()
        {
            for(int i = points.Count - 1; i > 0; i--)
            {
                points[i] = points[i - 1];
            }
        }

        private void hide()
        {
            foreach(Point p in points)
            {
                grid[p.X, p.Y].BackColor = Color.Orange;
            }
        }

        private void show()
        {
            foreach(Point p in points)
            {
                grid[p.X, p.Y].BackColor = Color.Black;
            }
        }

        private void loop()
        {
            if (posX == -1) posX = GSize - 1; //Loop from top to bottom
            if (posX == GSize) posX = 0; //Loop from bottom to top
            if (posY == -1)posY = GSize - 1; //Loop from Left to Right
            if (posY == GSize) posY = 0; //Lopp from Right to Left
        }

        private void fruit()
        {
            locX = ran.Next(0, GSize - 1);
            locY = ran.Next(0, GSize - 1);

            grid[locX, locY].BackColor = Color.Red;
            if(firsttime != true)
            {
                points.Add(new Point(points[0].X, points[0].Y + length));
            }

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case (Keys.W):
                    if(direction != "Down")direction = "Up";
                    break;
                case (Keys.D):
                    if(direction != "Left")direction = "Right";
                    break;
                case (Keys.S):
                    if(direction != "Up")direction = "Down";
                    break;
                case (Keys.A):
                    if(direction != "Right")direction = "Left";
                    break;
            }
        }

        private void detect()
        {
            for (int i = 1; i < points.Count; i++)
            {
                if (points[0] == points[i])
                {
                    dead();
                }
            }
        }

        private void dead()
        {
            time_Movement.Stop();
            MessageBox.Show("You're dead");
            points.Clear();
            btnResetPause.Text = "Restart";
            deadGame = true;
        }

        private void Time_Movement_Tick(object sender, EventArgs e)
        {
            posX = points[0].X;
            posY = points[0].Y;

            hide();
            if (direction == "Up")
            {
                posX--;
            }
            else if (direction == "Down")
            {
                posX++;
            }
            else if (direction == "Left")
            {
                posY--;
            }
            else if (direction == "Right")
            {
                posY++;
            }

            if (posX == locX)
            {
                if (posY == locY)
                {
                    fruit();
                }
            }
            loop();
            update();
            points[0] = new Point(posX, posY);
            detect();
            show();
            label1.Text = pointvalue();
        }

        private void BtnResetPause_Click(object sender, EventArgs e)
        {
            
            if(deadGame == true)
            {
                time_Movement.Start();
                points.Add(new Point(posX, posY));
                btnResetPause.Text = "Pause";
                deadGame = false;
                pause = true;
            }
            else if(pause == false)
            {
                pause = true;
                btnResetPause.Text = "Resume";
                time_Movement.Stop();
            }

            else if(pause == true)
            {
                time_Movement.Start();
                pause = false;
                btnResetPause.Text = "Pause";
            }
        }

        private string pointvalue()
        {
            return points.Count.ToString();
        }
    }
}
