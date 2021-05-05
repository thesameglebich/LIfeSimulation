using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ooptry3
{

    public partial class Form1 : Form
    {
        private Graphics graphics;
        private int resolution;
       
        public int rows;
        public int columns;
        public int sch = 1;
        bool haveinfo = false;
        int curind;
        bool haveinfo2 = false;
        int curind2;
        house curhouse;
        organismwithouttfood curog;
        public float[,] heights;
        public int width, height;
        public int iterations = 8;
        public double board = 0.5;
        //private static Image human = Image.FromFile(@"D:\forlinux2\rgr\ooptry3\ooptry3\imageforOOP\human.png");
        public int changebiom = 10;
        public double sand = 0.05;

        public Form1()
        {
            InitializeComponent();
            run = new Runner(this);
           // icon = new IconsClass();
        }

        Runner run;
        IconsClass icon =  new IconsClass();
        

        public void InicializeValue()
        {
            resolution = (int)nudResolution.Value;
            // rows = pictureBox1.Height / resolution;
            //columns = pictureBox1.Width / resolution;
            rows = 1000;
            columns = 1000;
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            graphics = Graphics.FromImage(pictureBox1.Image);
            height = rows;
            width = columns;
            
        }
        public void StartGame()
        {
            if (timer1.Enabled)
                return;
            nudResolution.Enabled = false;
            nudDensity.Enabled = false;
            run.CreateMyWorld();
            timer1.Start();
            
        }
        public void NoiseFun()
        {
            heights = new float[width, height];
            int seed = 1000;
            Random rand = new Random(seed);
            int scale = 10;
            for (int k = 0; k < iterations; k++)
            {

                float[,] heightsT = new float[width / scale, height / scale];
                for (int y = 0; y < height / scale; y++)
                {
                    for (int x = 0; x < width / scale; x++)
                    {
                        heightsT[x, y] = (float)rand.NextDouble();
                    }
                }
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        float z0 = heightsT[x / scale, y / scale];
                        float z1 = heightsT[(x / scale + 1) % (width / scale), y / scale];
                        float z2 = heightsT[x / scale, (y / scale + 1) % (width / scale)];
                        float z3 = heightsT[(x / scale + 1) % (width / scale), (y / scale + 1) % (width / scale)];
                        float fx = ((float)x / scale) % 1;
                        float fy = ((float)y / scale) % 1;
                        float ux = fx * fx * (3f - 2f * fx);
                        float uy = fy * fy * (3f - 2f * fy);
                        float z = z0 * (1 - ux) + z1 * ux + (z2 - z0) * uy * (1f - ux) + (z3 - z1) * ux * uy;
                        heights[x, y] += z / iterations;
                    }
                }
            }

        }
        public void DrawMap2()
        {
            if(sch % changebiom == 0)
            {
                board -= 0.01;
                sand += 0.01;
            }
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (heights[x, y] > board)
                    {
                        graphics.FillRectangle(Brushes.LimeGreen, x* resolution, y* resolution, resolution, resolution);
                    }
                    else
                    {
                        if (heights[x, y] > (board - sand))
                            graphics.FillRectangle(Brushes.PapayaWhip, x*resolution, y* resolution, resolution, resolution);
                        else
                        {
                            graphics.FillRectangle(Brushes.SkyBlue, x* resolution, y* resolution, resolution, resolution);
                        }
                    }
                }
            }
            //pictureBox1.Refresh();
        }


        public void DrawMap(List<entity> popul, List<house> houses, List<house> barns)
        {
            /*
            if ((sch / 500) % 2 == 0)
            {
                graphics.Clear(Color.Green);
            }//tut white
            else graphics.Clear(Color.Green);*/
            DrawMap2();

            for (int i = 0; i < popul.Count; i++)
            {
                if (popul[i] is eat)
                {
                    int myfoodtype = ((eat)popul[i]).typeoffood;
                    if (myfoodtype == 10)
                        graphics.DrawImage(icon.GetIcon(10), new RectangleF(popul[i].spot.x * resolution, popul[i].spot.y * resolution, resolution * 10, resolution * 10));
                    if (myfoodtype == 11)
                        graphics.DrawImage(icon.GetIcon(11), new RectangleF(popul[i].spot.x * resolution, popul[i].spot.y * resolution, resolution * 10, resolution * 10));
                    if (myfoodtype == 12)
                        graphics.DrawImage(icon.GetIcon(12), new RectangleF(popul[i].spot.x * resolution, popul[i].spot.y * resolution, resolution * 10, resolution * 10));
                }
                else
                {
                    int mytype = ((organismwithouttfood)popul[i]).typeofunit;
                    if (mytype == 0)
                        graphics.DrawImage(icon.GetIcon(0), new RectangleF(popul[i].spot.x * resolution, popul[i].spot.y * resolution, resolution * 10, resolution * 10));
                    if (mytype == 1)
                        graphics.DrawImage(icon.GetIcon(1), new RectangleF(popul[i].spot.x * resolution, popul[i].spot.y * resolution, resolution * 10, resolution * 10));
                    if (mytype == 2)
                        graphics.DrawImage(icon.GetIcon(2), new RectangleF(popul[i].spot.x * resolution, popul[i].spot.y * resolution, resolution * 10, resolution * 10));
                    if (mytype == 3)
                        graphics.DrawImage(icon.GetIcon(3), new RectangleF(popul[i].spot.x * resolution, popul[i].spot.y * resolution, resolution * 10, resolution * 10));
                    if (mytype == 4)
                        graphics.DrawImage(icon.GetIcon(4), new RectangleF(popul[i].spot.x * resolution, popul[i].spot.y * resolution, resolution * 10, resolution * 10));
                    if (mytype == 5)
                        graphics.DrawImage(icon.GetIcon(5), new RectangleF(popul[i].spot.x * resolution, popul[i].spot.y * resolution, resolution * 10, resolution * 10));
                    if (mytype == 6)
                        graphics.DrawImage(icon.GetIcon(6), new RectangleF(popul[i].spot.x * resolution, popul[i].spot.y * resolution, resolution * 10, resolution * 10));
                    if (mytype == 7)
                        graphics.DrawImage(icon.GetIcon(7), new RectangleF(popul[i].spot.x * resolution, popul[i].spot.y * resolution, resolution * 10, resolution * 10));
                    if (mytype == 8)
                        graphics.DrawImage(icon.GetIcon(8), new RectangleF(popul[i].spot.x * resolution, popul[i].spot.y * resolution, resolution * 10, resolution * 10));
                    if (mytype == 9)
                        graphics.DrawImage(icon.GetIcon(9), new RectangleF(popul[i].spot.x * resolution, popul[i].spot.y * resolution, resolution * 10, resolution * 10));
                }
      
            }
            for(int j = 0; j < houses.Count; j++)
            {
                graphics.DrawImage(icon.GetIcon(13), new RectangleF(houses[j].place.x * resolution, houses[j].place.y * resolution, resolution*10, resolution*10));//graphics.FillRectangle(Brushes.Black, houses[j].place.x * resolution, houses[j].place.y * resolution, resolution, resolution);
            }
            for(int j = 0; j < barns.Count; j++)
            {
                graphics.DrawImage(icon.GetIcon(13), new RectangleF(houses[j].place.x * resolution, houses[j].place.y * resolution, resolution * 10, resolution * 10));//graphics.FillRectangle(Brushes.Black, houses[j].place.x * resolution, houses[j].place.y * resolution, resolution, resolution);
            }
            if (haveinfo == true)
                label3.Text = curog.Information();
            if (haveinfo2 == true)
                label6.Text = run.population.houses[curind2].Information();

            pictureBox1.Refresh();
        }

   

        private void timer1_Tick(object sender, EventArgs e)
        {
            run.CreateNewWorld();
            label4.Text = $"{sch++}";
        }

        private void strartb_Click(object sender, EventArgs e)
        {
            StartGame();
        }

        private void stopb_Click(object sender, EventArgs e)
        {
            if (!timer1.Enabled)
                return;
            timer1.Stop();
            nudDensity.Enabled = true;
            nudResolution.Enabled = true;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (!timer1.Enabled)
                return;
            if (e.Button == MouseButtons.Left)
            {   
                var x2 = e.Location.X / resolution;
                var y2 = e.Location.Y / resolution;
                for (int i = 0; i < run.population.popul.Count; i++)
                {
                    if (x2 == run.population.popul[i].spot.x && y2 == run.population.popul[i].spot.y)
                    {
                        // label3.Text = $"health:{run.population.popul[i].health} Pair:{run.population.popul[i].pair}";
                        //label5.Text = $"timer:{run.population.popul[i].timer}";
                        if (run.population.popul[i] is organismwithouttfood)
                        {
                            label3.Text = ((organismwithouttfood)run.population.popul[i]).Information();
                            //curind = i;
                            //haveinfo = true;
                            curog = (organismwithouttfood)run.population.popul[i];
                        }
                    }
                }
                //new
                for (int j = 0; j < run.population.houses.Count; j++)
                {
                    if (x2 == run.population.houses[j].place.x && y2 == run.population.houses[j].place.y)
                    {
                        label6.Text = run.population.houses[j].Information();
                        curind2 = j;
                        haveinfo2 = true;

                    }
                }
            }

            if (e.Button == MouseButtons.Right)
            {
                var x2 = e.Location.X / resolution;
                var y2 = e.Location.Y / resolution;
                timer1.Stop();
                run.population.DeleteLocation(x2, y2);
                for (int i =x2-run.population.deadradius;i<x2+ run.population.deadradius; i++)
                    for(int j = y2- run.population.deadradius; j <  y2+ run.population.deadradius; j++)
                    {
                        graphics.FillRectangle(Brushes.Orange, i * resolution, j * resolution, resolution, resolution);
                    }
                pictureBox1.Refresh();

                timer1.Start();
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }


}
