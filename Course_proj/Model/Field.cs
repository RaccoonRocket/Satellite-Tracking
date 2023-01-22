using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course_proj.Model
{
    internal class Field
    {
        List<ArrowLine> arrowLines = new List<ArrowLine>();
        PictureBox pictureBox;
        Circle[] circle;
        int virtuaCirclesSize;// total points on the field (some are invisible)
        int aliveCirclesSize;// the number of points on the real field
        int[,] matrix;
        int virtualCubeSize;// the number of points on the imaginary field
        private void initField()
        {

            int heightDelta = (pictureBox.Height - 100) / virtualCubeSize;
            int widthDelta = (pictureBox.Width - 100) / virtualCubeSize - 25;
            int k = 1;
            circle[0] = new Circle(25, pictureBox.Height / 2);
            circle[virtuaCirclesSize - 1] = new Circle(pictureBox.Width - 25, pictureBox.Height / 2);
            for (int i = 1; i <= virtualCubeSize; i++)
            {
                for (int j = 1; j <= virtualCubeSize; j++)
                {
                    circle[k] = new Circle(widthDelta * j + 45, heightDelta * i);
                    k++;
                }
            }
        }
        private void initLines()
        {
            for (int i = 0; i < aliveCirclesSize; i++)
            {
                for (int j = 0; j < aliveCirclesSize; j++)
                {
                    if (matrix[i, j] != 0 && i != j)
                    {
                        Point from = new Point(circle[i].x, circle[i].y);
                        Point to = new Point(circle[j].x, circle[j].y);
                        if (j == aliveCirclesSize - 1)
                        {
                            to = new Point(circle[virtuaCirclesSize - 1].x, circle[virtuaCirclesSize - 1].y);
                        }


                        arrowLines.Add(new ArrowLine(from, to, matrix[i, j]));
                    }
                }
            }
        }
        private void initCircles()
        {
            int k = 1;
            for (int i = 0; i < aliveCirclesSize - 1; i++)
            {
                circle[i].isAlive = true;
                circle[i].Number = k.ToString();
                k++;
            }

            circle[virtuaCirclesSize - 1].isAlive = true;
            circle[virtuaCirclesSize - 1].Number = (aliveCirclesSize).ToString();
        }
        private void setSizes(int[,] matrix)
        {
            aliveCirclesSize = matrix.GetLength(0);
            virtualCubeSize = (int)Math.Ceiling(Math.Sqrt(aliveCirclesSize - 2));
            virtuaCirclesSize = (int)(Math.Pow(virtualCubeSize, 2) + 2);
        }
        private void paintCircles(PaintEventArgs e)
        {
            for (int i = 0; i < circle.Length; i++)
            {
                if (circle[i].isAlive)
                    circle[i].Draw(e);
            }
        }
        private void paintLines(PaintEventArgs e)
        {
            for (int i = 0; i < arrowLines.Count; i++)
            {
                arrowLines[i].Draw(e);
            }
        }
        private void paintWeights(PaintEventArgs e)
        {
            for (int i = 0; i < arrowLines.Count; i++)
            {
                arrowLines[i].DrawText(e);
            }
        }
        public void Paint(PaintEventArgs e) // to draw, we call this method
        {

            paintLines(e);
            paintCircles(e);
            paintWeights(e);
        }
        public Field(PictureBox pictureBox, int[,] matrix)
        {
            this.pictureBox = pictureBox;
            this.matrix = matrix;
            setSizes(matrix);

            circle = new Circle[virtuaCirclesSize];
            initField();
            initCircles();
            initLines();

        }
    }
}
