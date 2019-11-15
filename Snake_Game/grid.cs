using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Snake_Game
{
    class grid : Label
    {
        /// <summary>
        /// Used to generate the grid
        /// </summary>
        /// <param name="x">The X position of where the sqaure is going to be placed</param>
        /// <param name="y">The Y position of where the square is going to be placed</param>
        public grid(int x, int y)
        {

            //Controls for creating the label on the display.
            //All of these are properties of a label. They're being passed to the constructor ready for form1 to build squres.
            this.AutoSize = false;
            this.Location = new System.Drawing.Point(x, y);
            this.Size = new System.Drawing.Size(15, 15);
            this.TabIndex = 0;
            this.BackColor = Color.Orange;
        }

    }
}
