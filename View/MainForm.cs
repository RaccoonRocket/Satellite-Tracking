using Course_proj.Controller;
using Course_proj.Model;
using System.Data;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Course_proj
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e) // +
        {
            if (Data.sizeOfGrid < Data.nMax)
            {
                dataGridView1.Columns.Add("", $"{Data.sizeOfGrid + 1}");
                dataGridView1.Rows.Add();
                ++Data.sizeOfGrid;
            }
            else
                MessageBox.Show("Error!\n");
        }

        private void button2_Click(object sender, EventArgs e) // -
        {
            if (Data.sizeOfGrid > 1)
            {
                dataGridView1.Columns.RemoveAt(Data.sizeOfGrid - 1);
                dataGridView1.Rows.RemoveAt(Data.sizeOfGrid - 1);
                --Data.sizeOfGrid;
            }
            else
                MessageBox.Show("Error!\n");
        }

        private void button3_Click(object sender, EventArgs e) // example 1
        {
            if (dataGridView1.ColumnCount < Data.maxExample1)
            {
                while (dataGridView1.ColumnCount != Data.maxExample1)
                {
                    button1_Click(sender, e);
                }
            }
            else if (Data.maxExample1 < dataGridView1.ColumnCount)
            {
                while (dataGridView1.ColumnCount != Data.maxExample1)
                {
                    button2_Click(sender, e);
                }
            }
            
            for (int i = 0; i < Data.maxExample1; ++i)
                for (int j = 0; j < Data.maxExample1; ++j)
                    dataGridView1.Rows[i].Cells[j].Value = Data.example1Network[i, j];

            // numericUpDown1.Value = 0;
            Data.network = Data.example1Network;
            Data.mainVertex = 0;
            Data.sizeOfGrid = Data.maxExample1;
        }

        private void button6_Click(object sender, EventArgs e) // example 2
        {
            if (dataGridView1.ColumnCount < Data.maxExample2)
            {
                while (dataGridView1.ColumnCount != Data.maxExample2)
                {
                    button1_Click(sender, e);
                }
            }
            else if (Data.maxExample2 < dataGridView1.ColumnCount)
            {
                while (dataGridView1.ColumnCount != Data.maxExample2)
                {
                    button2_Click(sender, e);
                }
            }

            for (int i = 0; i < Data.maxExample2; ++i)
                for (int j = 0; j < Data.maxExample2; ++j)
                    dataGridView1.Rows[i].Cells[j].Value = Data.example2Network[i, j];

            // numericUpDown1.Value = 0;
            Data.network = Data.example2Network;
            Data.mainVertex = 0;
            Data.sizeOfGrid = Data.maxExample2;
        }

        private void button4_Click(object sender, EventArgs e) // maxflow & cut
        {
            if (Data.network == null)
            {
                MessageBox.Show("Enter the data!");
            }
            else
            {
                //===========================================
                Data.sizeOfGrid = dataGridView1.ColumnCount;
                // Data.mainVertex = (int)numericUpDown1.Value;
                /*if (dataGridView1.ColumnCount < (int)numericUpDown1.Value)
                {
                    MessageBox.Show("Wrong data!");
                    Application.Restart();
                }*/
                Data.cluster = new int[Data.sizeOfGrid, Data.sizeOfGrid];
                for (int i = 0; i < Data.sizeOfGrid; ++i)
                {
                    for (int j = 0; j < Data.sizeOfGrid; ++j)
                    {
                        if (dataGridView1.Rows[i].Cells[j].Value != null)
                            Data.cluster[i, j] = int.Parse(dataGridView1.Rows[i].Cells[j].Value.ToString());
                        else
                            Data.cluster[i, j] = 0;
                    }
                }
                ControllerTransform.Transformation();
                //===========================================

                MessageBox.Show($"Max Flow: {ControllerMaxFlow.getMaxFlow().ToString()}\n" +
                    $"Cut: {ControllerCut.getCut().ToString()}", "Max flow & Cut");

                String? str = null;
                for (int i = 0; i < Data.sizeOfGrid + 1; ++i)
                {
                    for (int j = 0; j < Data.sizeOfGrid + 1; ++j)
                        str += Data.network[i, j].ToString() + "\t";
                    str += "\n";
                }
                MessageBox.Show($"{str}", "Flow network");

            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e) // display network
        {
            Data.sizeOfGrid = dataGridView1.ColumnCount;
            // Data.mainVertex = (int)numericUpDown1.Value;

            /*if (dataGridView1.ColumnCount < (int)numericUpDown1.Value)
            {
                MessageBox.Show("Wrong data!");
                Application.Restart();
            }*/

            Data.cluster = new int[Data.sizeOfGrid, Data.sizeOfGrid];

            // Transferring lines from a form to a Cluster 
            for (int i = 0; i < Data.sizeOfGrid; ++i)
            {
                for (int j = 0; j < Data.sizeOfGrid; ++j)
                {
                    if (dataGridView1.Rows[i].Cells[j].Value != null)
                        Data.cluster[i, j] = int.Parse(dataGridView1.Rows[i].Cells[j].Value.ToString());
                    else
                        Data.cluster[i, j] = 0;
                }
            }

            ControllerTransform.Transformation();


            // Drawing component and drawing area
            PaintEventArgs p = new PaintEventArgs(pictureBox1.CreateGraphics(), pictureBox1.Bounds);
            p.Graphics.Clear(Color.White);
            Field field = new Field(pictureBox1, Data.network);
            field.Paint(p);
        }

        private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Using \"+\" and \"-\" build a grid and enter the cluster.\n" +
                "(Select the main vertex and) click \"Display network\".\n" +
                "The cluster is converted into a streaming network and displayed on the screen.\n" +
                "By clicking on the \"Max flow and cut\" you will find out this.\n" +
                "Or don't bother and click on \"Example\", on the prepared flow network.", "INFO");
        }
    }
}