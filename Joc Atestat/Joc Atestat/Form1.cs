using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IOStream = System.IO.Stream;
using System.Media;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        int pipeSpeed = 8;
        int gravity = 15;
        int score = 0;
        int maxi = 0;

        public Form1()
        {
            InitializeComponent();
            meniu_joc.Hide();

        }
        private void playaudio1()
        {
            SoundPlayer audio = new SoundPlayer(WindowsFormsApplication1.Properties.Resources.bonus);
            audio.Play();
        }
        private void playaudio2()
        {
            SoundPlayer audio = new SoundPlayer(WindowsFormsApplication1.Properties.Resources.uhhh);
            audio.Play();
        }


        private void endGame()
        {
            if (maxi < score)
                maxi = score;
            label5.Text = "Scor maxim:" + maxi.ToString();
            gameTimer.Stop();
            p1.Image = Properties.Resources.E_editat;
            playaudio2();
            p1.BackColor = Color.Transparent;
            meniu_joc.Show();


        }


        private void keydown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {

                gravity = -30;
            }
        }

        private void keyup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {

                gravity = 15;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            gameTimer.Start();
            meniu_joc.Hide();
            p1.Location = new Point(76, 218);
            p2.Location = new Point(480, -25);
            p3.Location = new Point(480, 338);
            label4.Text = "Scor: 0";
            score = 0;
            p1.Image = Properties.Resources.A;

        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void gameTimer_Tick_1(object sender, EventArgs e)
        {
            p1.Top += gravity;
            p3.Left -= pipeSpeed;
            p2.Left -= pipeSpeed;
            label4.Text = "Scor: " + score;
            if (p2.Left < -50)
            {

                p2.Left = 200;
                score++;
                playaudio1();
            }
            if (p3.Left < -100)
            {

                p3.Left = 300;
            }
            if (p1.Bounds.IntersectsWith(p3.Bounds) ||
              p1.Bounds.IntersectsWith(p2.Bounds) ||
              p1.Bounds.IntersectsWith(p4.Bounds) || p1.Top < -25
              )
            {

                endGame();

            }



            if (score > 5)
            {
                pipeSpeed = 15;
            }

        }
    }
}
