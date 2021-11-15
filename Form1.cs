using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mulMat
{
  
    public partial class Form1 : Form
    {
        int size;
        int[,] mat1;
        int[,] mat2;
        int[,] mat3;
        Label l2 = new Label();
        Label l1 = new Label();
        Label l3 = new Label();

        public Form1()
        {
            InitializeComponent();
            l3.ForeColor = Color.Red;
            this.AutoSize = false;

        }
        private void button1_Click(object sender, EventArgs e)
        {
            Label l2 = new Label();
            Label l1 = new Label();
            Label l3 = new Label();
            l1.ForeColor = Color.Thistle;
            l2.ForeColor = Color.Thistle;

            size = Convert.ToInt32(numericUpDown1.Value);
            mat1 = new int[size, size];
            mat2 = new int[size, size];
            mat3 = new int[size, size];
            l3.ForeColor = Color.Red;
            Random r = new Random();
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    mat1[i, j] = r.Next(1, 10);

                    l1.Text += mat1[i, j].ToString() + "   ";
                    Point p = new Point(100, 200);
                    l1.Location = p;
                    l1.Width = 100;
                    l1.Height = 100;
                    this.Controls.Add(l1);

                    mat2[i, j] = r.Next(1, 10);
                    Point p2 = new Point(200, 200);
                    l2.Text += mat2[i, j].ToString() + "   ";
                    l2.Location = p2;
                    l2.Width = 100;
                    l2.Height = 100;
                    this.Controls.Add(l2);
                }
                l1.Text += "\n";
                l2.Text += "\n";
            }
            Stopwatch watch = new Stopwatch();
            watch.Start();
            sidarty();
            watch.Stop();
            MessageBox.Show(watch.Elapsed.ToString());
        }
    

        private void sidarty()
        {
            l3 = new Label();
            for (int i = 0; i < size; i++)
            {

                for (int j = 0; j < size; j++)
                {
                    int sum = 0;
                    for (int k = 0; k < size; k++)
                        sum += mat1[i, k] * mat2[k, j];
                    mat3[i, j] = sum;
                    Point p3 = new Point(150, 300);
                    l3.Text += mat3[i, j].ToString() + "   ";
                    l3.Location = p3;
                    l3.Width = 200;
                    l3.Height = 200;
                    this.Controls.Add(l3);
                }
                l3.Text += "\n";
            }
        }

        private void parallel()
        {
            l3 = new Label();
            l3.ForeColor = Color.Red;

            Thread[,] thread = new Thread[size, size];
            for (int i = 0; i < size; i++)
            {

                for (int j = 0; j < size; j++)
                {
                    int sum = 0;
                    Element e = new Element();
                    e.x = i;
                    e.y = j;
                    thread[i, j] = new Thread(new ParameterizedThreadStart(ComputeElements));
                    thread[i, j].Start(e);
                }
                for (int l = 0; l < size; l++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        thread[i,j].Join();
                    }
                    
                }
        }
            for (int l = 0; l < size; l++)
            {
                for (int j = 0; j < size; j++)
                {
                    Point p3 = new Point(400, 300);
                    l3.Text += mat3[l, j].ToString() + "   ";
                    l3.Location = p3;
                    l3.Width = 200;
                    l3.Height = 200;
                    this.Controls.Add(l3);
                }
                l3.Text += "\n";
            }

        }

        private void ComputeElements(object obj)
        {
            l3.ForeColor = Color.Red;
            Label l2 = new Label();
            Label l1 = new Label();
            Element e = (Element)obj;
            int sum = 0;
            for (int k = 0; k < size; k++)
                sum += mat1[e.x, k] * mat2[k, e.y];
            mat3[e.x, e.y] = sum;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            l3.ForeColor = Color.Red;
            l1 = new Label();
            l2= new Label();
            l1.AutoSize= false;
            l1.Height = 40;
            l1.Width = 30;
            l1.ForeColor = Color.Thistle;
            l2.ForeColor = Color.Thistle;
            size = Convert.ToInt32(numericUpDown1.Value);
            mat1 = new int[size, size];
            mat2 = new int[size, size];
            mat3 = new int[size, size];
            Random r = new Random();
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    mat1[i, j] = r.Next(1, 10);

                    l1.Text += mat1[i, j].ToString() + "   ";
                    Point p = new Point(350, 200);
                    l1.Location = p;
                    l1.Width = 100;
                    l1.Height = 100;
                    this.Controls.Add(l1);

                    mat2[i, j] = r.Next(1, 10);
                    Point p2 = new Point(450, 200);
                    l2.Text += mat2[i, j].ToString() + "   ";
                    l2.Location = p2;
                    l2.Width = 100;
                    l2.Height = 100;
                    this.Controls.Add(l2);
                }
                l1.Text += "\n";
                l2.Text += "\n";
            }
            Stopwatch watch2 = new Stopwatch();
            watch2.Start();
            parallel();
            watch2.Stop();
            MessageBox.Show(watch2.Elapsed.ToString());
            
        }
    }
    }

