using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course_proj.Model
{
    internal class Circle
    {
        private Font textFont = new Font("Arial", 10);
        private int diametr = 25;
        public int x;
        public int y;
        public bool isAlive = false;
        public string Number = "";
        public Circle(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public void Draw(PaintEventArgs e)
        {
            e.Graphics.FillEllipse(Brushes.White, x - diametr / 2, y - diametr / 2, diametr, diametr);
            e.Graphics.DrawEllipse(new Pen(Brushes.Black), x - diametr / 2, y - diametr / 2, diametr, diametr);
            e.Graphics.DrawString(Number, textFont, Brushes.Black, x - 6, y - diametr / 3);
        }
    }
}
