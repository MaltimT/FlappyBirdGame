using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TwoBallCollision;

namespace FlappyBird
{
    public partial class Form1 : Form
    {
        List<PictureBox> walls;
        PictureBox bird, hwall1, hwall2;
        List<int> speeds;
        Vector r, r0, gx, gy;
        double m;
        Random rnd = new Random();
        public Form1()
        {
            InitializeComponent();
            walls = new List<PictureBox>();
            speeds = new List<int>();
            m = 0.4;
            gx = new Vector(10, 0);
            gy = new Vector(0, 10);
            r = new Vector(-100, -100);
        }
        //START BUTTON

        private void button1_Click(object sender, EventArgs e)
        {           
            pnlControls.Visible = false;

            //LIMITATION OF THE COUNT OF THE DIRECTIONS

            if(rbLeft.Checked && rbRight.Checked || rbLeft.Checked && rbUp.Checked 
           || rbLeft.Checked && rbDown.Checked || rbRight.Checked && rbUp.Checked
           || rbRight.Checked && rbDown.Checked || rbUp.Checked && rbDown.Checked 
           || rbLeft.Checked && rbRight.Checked && rbUp.Checked && rbDown.Checked)
            {
                MessageBox.Show("Choose only one direction");
                Application.Exit();
            }

            //CREATE INVISIBLE WALLS AND BIRDS
            if (rbLeft.Checked)
            {
                CreateBirdLeft();
                CreateInvisibleWallsForLeftAndRight();
            }
            if (rbRight.Checked)
            {
                CreateBirdRight();
                CreateInvisibleWallsForLeftAndRight();
            }
            if (rbUp.Checked)
            {
                CreateBirdUp();
                CreateInvisibleWallsForUpAndDown();
            }
            if (rbDown.Checked)
            {
                CreateBirdDown();
                CreateInvisibleWallsForUpAndDown();
            }

            timer.Start();                     
        }       

        //TIMER

        private void timer_Tick(object sender, EventArgs e)
        {
            r0 = new Vector(bird.Location.X, bird.Location.Y);
            //CREATE WALLS
            if (rbRight.Checked)
            {
                bird.Top += (int)(gy.Y * m * 2);
                if (rnd.Next(12) == 1)
                {                    
                    CreateWallsRight();
                }
                for (int i = 0; i < walls.Count; i++)
                {
                    walls[i].Left -= speeds[i];
                }
            }
            if (rbLeft.Checked)
            {
                bird.Top += (int)(gy.Y * m * 2);
                if (rnd.Next(12) == 1)
                {
                    CreateWallsLeft();
                }
                for (int i = 0; i < walls.Count; i++)
                {
                    walls[i].Left += speeds[i];
                }
            }
            if (rbUp.Checked)
            {
                bird.Left += (int)(gx.X * m * 2);
                if (rnd.Next(12) == 1)
                {
                    CreateWallsUp();
                }
                for (int i = 0; i < walls.Count; i++)
                {
                    walls[i].Top += speeds[i];
                }
            }
            if (rbDown.Checked)
            {
                bird.Left += (int)(gx.X * m * 2);
                if (rnd.Next(12) == 1)
                {
                    CreateWallsDown();
                }
                for (int i = 0; i < walls.Count; i++)
                {
                    walls[i].Top -= speeds[i];
                }
            }
            Collision();
        }

        //COLLISION AND FINISH

        private void Collision()
        {
            for (int i = 0; i < walls.Count; i++)
            {
                if (bird.Bounds.IntersectsWith(walls[i].Bounds)|| bird.Bounds.IntersectsWith(hwall1.Bounds) 
                    || bird.Bounds.IntersectsWith(hwall2.Bounds))
                {
                    timer.Stop();

                    //FINISH MENU INFORMATION

                    Panel pnlFinish = new Panel();
                    pnlFinish.BackColor = Color.DarkOrchid;
                    pnlFinish.Size = new Size(600, 400);
                    pnlFinish.Location = new Point(this.ClientSize.Width/2-pnlFinish.Size.Width/2,this.ClientSize.Height/2-pnlFinish.Size.Height/2);
                    Controls.Add(pnlFinish);
                    pnlFinish.BringToFront();

                    Button btnExit = new Button();
                    btnExit.BackColor = Color.DarkViolet;
                    btnExit.Size = new Size(150, 100);
                    btnExit.Location = new Point(pnlFinish.Width / 2 - btnExit.Size.Width/2, pnlFinish.Height / 2 - btnExit.Size.Height/2);
                    btnExit.Click += new EventHandler(btnExit_Click);
                    btnStart.Name = "btnStart";
                    btnExit.Text = "Exit";
                    pnlFinish.Controls.Add(btnExit);
                    btnExit.BringToFront();
                }
            }            
        }

        //FINISH BUTTON

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //KEYBOARD                   

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (rbLeft.Checked || rbRight.Checked)
            {
                if (e.KeyValue == (char)Keys.Enter)
                {
                    r0.Y += r.Y / 1.25;
                    bird.Location = new Point((int)r0.X, (int)r0.Y);
                }
            }
            if (rbUp.Checked || rbDown.Checked)
            {
                if (e.KeyValue == (char)Keys.Enter)
                {
                    r0.X += r.X / 1.25;
                    bird.Location = new Point((int)r0.X, (int)r0.Y);
                }
            }
        }

        //BIRD INFORMATION

        private void CreateBirdRight()
        {
            bird = new PictureBox();
            bird.Size = new Size(70, 70);
            bird.Location = new Point(20, this.ClientSize.Height / 2 - bird.Height / 2);
            bird.ImageLocation = "Bird.png";
            bird.SizeMode = PictureBoxSizeMode.Zoom;
            Controls.Add(bird);
            bird.BringToFront();
        }
        private void CreateBirdDown()
        {
            bird = new PictureBox();
            bird.Size = new Size(70, 70);
            bird.Location = new Point(this.ClientSize.Width / 2 - bird.Width / 2, 20 );
            bird.ImageLocation = "Bird.png";
            bird.SizeMode = PictureBoxSizeMode.Zoom;
            Controls.Add(bird);
            bird.BringToFront();
        }
        private void CreateBirdUp()
        {
            bird = new PictureBox();
            bird.Size = new Size(70, 70);
            bird.Location = new Point(this.ClientSize.Width / 2 - bird.Width / 2, ClientSize.Height-bird.Size.Height);
            bird.ImageLocation = "Bird.png";
            bird.SizeMode = PictureBoxSizeMode.Zoom;
            Controls.Add(bird);
            bird.BringToFront();
        }
        private void CreateBirdLeft()
        {
            bird = new PictureBox();
            bird.Size = new Size(70, 70);
            bird.Location = new Point(ClientSize.Width - bird.Size.Width, this.ClientSize.Height / 2 - bird.Height / 2);
            bird.ImageLocation = "Bird.png";
            bird.SizeMode = PictureBoxSizeMode.Zoom;
            Controls.Add(bird);
            bird.BringToFront();
        }

        //WALLS INFORMATION

        private void CreateWallsDown()
        {
            int speedLimit = Convert.ToInt32(tbSpeed.Value);
            PictureBox wallUp = new PictureBox();
            wallUp.Size = new Size(rnd.Next(500, 550), 80);
            wallUp.Location = new Point(0, (int)(ClientSize.Height * 1.3));
            wallUp.ImageLocation = "Wall.jpg";
            wallUp.SizeMode = PictureBoxSizeMode.StretchImage;
            Controls.Add(wallUp);
            walls.Add(wallUp);
            speeds.Add(rnd.Next(tbSpeed.Minimum, speedLimit));

            PictureBox wallDown = new PictureBox();
            wallDown.Size = new Size(rnd.Next(500, 550), 80);
            wallDown.Location = new Point(ClientSize.Width - wallUp.Size.Width, (int)(ClientSize.Height * 1.3));
            wallDown.ImageLocation = "Wall.jpg";
            wallDown.SizeMode = PictureBoxSizeMode.StretchImage;
            Controls.Add(wallDown);
            walls.Add(wallDown);
            speeds.Add(rnd.Next(tbSpeed.Minimum, speedLimit));

            wallUp.BringToFront();
            wallDown.BringToFront();
        }
        private void CreateWallsUp()
        {
            int speedLimit = Convert.ToInt32(tbSpeed.Value);
            PictureBox wallUp = new PictureBox();
            wallUp.Size = new Size(rnd.Next(500, 550), 80);
            wallUp.Location = new Point(0, (int)((ClientSize.Height - ClientSize.Height) / 1.3));
            wallUp.ImageLocation = "Wall.jpg";
            wallUp.SizeMode = PictureBoxSizeMode.StretchImage;
            Controls.Add(wallUp);
            walls.Add(wallUp);
            speeds.Add(rnd.Next(tbSpeed.Minimum, speedLimit));

            PictureBox wallDown = new PictureBox();
            wallDown.Size = new Size(rnd.Next(500, 550), 80);
            wallDown.Location = new Point(ClientSize.Width - wallUp.Size.Width, (int)((ClientSize.Height - ClientSize.Height) / 1.3));
            wallDown.ImageLocation = "Wall.jpg";
            wallDown.SizeMode = PictureBoxSizeMode.StretchImage;
            Controls.Add(wallDown);
            walls.Add(wallDown);
            speeds.Add(rnd.Next(tbSpeed.Minimum, speedLimit));

            wallUp.BringToFront();
            wallDown.BringToFront();
        }
        private void CreateWallsLeft()
        {
            int speedLimit = Convert.ToInt32(tbSpeed.Value);
            PictureBox wallUp = new PictureBox();
            wallUp.Size = new Size(80, rnd.Next(200, 250));
            wallUp.Location = new Point((int)((this.ClientSize.Width - this.ClientSize.Width) / 1.3), 0);
            wallUp.ImageLocation = "Wall.jpg";
            wallUp.SizeMode = PictureBoxSizeMode.StretchImage;
            Controls.Add(wallUp);
            walls.Add(wallUp);
            speeds.Add(rnd.Next(tbSpeed.Minimum, speedLimit));

            PictureBox wallDown = new PictureBox();
            wallDown.Size = new Size(80, rnd.Next(200, 250));
            wallDown.Location = new Point((int)((this.ClientSize.Width - this.ClientSize.Width) / 1.3), ClientSize.Height - wallDown.Size.Height);
            wallDown.ImageLocation = "Wall.jpg";
            wallDown.SizeMode = PictureBoxSizeMode.StretchImage;
            Controls.Add(wallDown);
            walls.Add(wallDown);
            speeds.Add(rnd.Next(tbSpeed.Minimum, speedLimit));

            wallUp.BringToFront();
            wallDown.BringToFront();
        }
        private void CreateWallsRight()
        {
            int speedLimit = Convert.ToInt32(tbSpeed.Value);
            PictureBox wallUp = new PictureBox();
            wallUp.Size = new Size(80, rnd.Next(200, 250));
            wallUp.Location = new Point((int)(this.ClientSize.Width * 1.3), ClientSize.Height - wallUp.Size.Height);
            wallUp.ImageLocation = "Wall.jpg";
            wallUp.SizeMode = PictureBoxSizeMode.StretchImage;
            Controls.Add(wallUp);
            walls.Add(wallUp);
            speeds.Add(rnd.Next(tbSpeed.Minimum, speedLimit));

            PictureBox wallDown = new PictureBox();
            wallDown.Size = new Size(80, rnd.Next(200, 250));
            wallDown.Location = new Point((int)(this.ClientSize.Width * 1.3), 0);
            wallDown.ImageLocation = "Wall.jpg";
            wallDown.SizeMode = PictureBoxSizeMode.StretchImage;
            Controls.Add(wallDown);
            walls.Add(wallDown);
            speeds.Add(rnd.Next(tbSpeed.Minimum, speedLimit));

            wallUp.BringToFront();
            wallDown.BringToFront();
        }

        //INVISIBLE WALLS INFORMATION

        private void CreateInvisibleWallsForUpAndDown()
        {
            hwall1 = new PictureBox();
            hwall1.Size = new Size(1, ClientSize.Height);
            hwall1.Location = new Point(-1, 0);
            Controls.Add(hwall1);

            hwall2 = new PictureBox();
            hwall2.Size = new Size(1, ClientSize.Height);
            hwall2.Location = new Point(ClientSize.Width, 0);
            Controls.Add(hwall2);

            hwall1.BringToFront();
            hwall2.BringToFront();
        }
        private void CreateInvisibleWallsForLeftAndRight()
        {
            hwall1 = new PictureBox();
            hwall1.Size = new Size(ClientSize.Width, 1);
            hwall1.Location = new Point(0, -1);
            Controls.Add(hwall1);

            hwall2 = new PictureBox();
            hwall2.Size = new Size(ClientSize.Width, 1);
            hwall2.Location = new Point(0, ClientSize.Height);
            Controls.Add(hwall2);

            hwall1.BringToFront();
            hwall2.BringToFront();
        }
    }
}
