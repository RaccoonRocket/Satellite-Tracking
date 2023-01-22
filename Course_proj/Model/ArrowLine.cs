using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course_proj.Model
{
    internal class ArrowLine
    {
        private Font textFont = new Font("Arial", 10, System.Drawing.FontStyle.Bold);
        Point from = new Point();
        Point to = new Point();
        public int weight = 0;
        public void Draw(PaintEventArgs e)
        {
            int textX = (from.X + to.X) / 2;
            int textY = (from.Y + to.Y) / 2;
            using (Pen p = new Pen(Brushes.Black, 5f))
            {
                Pen p2 = new Pen(Brushes.Black, 1f);
                p.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;

                //Draw the arrow
                int X2 = (textX + to.X) / 2;
                int Y2 = (textY + to.Y) / 2;
                e.Graphics.DrawLine(p, new Point(textX, textY), new Point(X2, Y2));
                e.Graphics.DrawLine(p2, from, to);
                e.Graphics.DrawString(weight.ToString(), textFont, Brushes.Red, new Point(textX + 3, textY + 3));
            }

        }

        public void DrawText(PaintEventArgs e)
        {
            int textX = (from.X + to.X) / 2;
            int textY = (from.Y + to.Y) / 2;

            //Draw the arrow
            e.Graphics.DrawString(weight.ToString(), textFont, Brushes.Red, new Point(textX + 3, textY + 3));
        }

        public ArrowLine(Point from, Point to, int weight)
        {
            this.from = from;
            this.to = to;
            this.weight = weight;
        }
    }
}
