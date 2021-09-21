using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;
using System.Drawing.Drawing2D;
using System.Threading;

namespace SimonSays
{
    public partial class GameScreen : UserControl
    {
        //TODO: create guess variable to track what part of the pattern the user is at
        Random Random = new Random();
        int guess;
        int index;
        int downtime = 350;
        int timer = 25;
        Boolean playerTurn = false;
        SoundPlayer greenSound = new SoundPlayer(Properties.Resources.green);
        SoundPlayer redSound = new SoundPlayer(Properties.Resources.red);
        SoundPlayer yellowSound = new SoundPlayer(Properties.Resources.yellow);
        SoundPlayer blueSound = new SoundPlayer(Properties.Resources.blue);
        SoundPlayer gameoverSound = new SoundPlayer(Properties.Resources.mistake);
        public GameScreen()
        {
            InitializeComponent();
        }

        private void GameScreen_Load(object sender, EventArgs e)
        {
            //TODO: clear the pattern list from form1, refresh, pause for a bit, and run ComputerTurn()
            Form1.pattern.Clear();
            Refresh();
            Thread.Sleep(1000);
            downtime = 350;
            ComputerTurn();
        }

        private void ComputerTurn()
        {
            //TODO: get rand num between 0 and 4 (0, 1, 2, 3) and add to pattern list
            guess = Random.Next(0,4);
            Form1.pattern.Add(guess);
            timer = 10;
            Refresh();
            Thread.Sleep(1000);
            //TODO: create a for loop that shows each value in the pattern by lighting up approriate button
            for (int i = 0; i < Form1.pattern.Count; i++)
            {
               if (Form1.pattern[i] == 0)
                {
                    greenButton.BackColor = Color.LimeGreen;
                    greenSound.Play();
                    Refresh();
                    Thread.Sleep(downtime);
                    greenButton.BackColor = Color.ForestGreen;
                    Refresh();
                    Thread.Sleep(downtime);
                }
               else if (Form1.pattern[i] == 1)
                {
                    redButton.BackColor = Color.Red;
                    redSound.Play();
                    Refresh();
                    Thread.Sleep(downtime);
                    redButton.BackColor = Color.DarkRed;
                    Refresh();
                    Thread.Sleep(downtime);
                }
               else if (Form1.pattern[i] == 2)
                {
                    yellowButton.BackColor = Color.Yellow;
                    yellowSound.Play();
                    Refresh();
                    Thread.Sleep(downtime);
                    yellowButton.BackColor = Color.Goldenrod;
                    Refresh();
                    Thread.Sleep(downtime);
                }
               else if (Form1.pattern[i] == 3)
                {
                    blueButton.BackColor = Color.RoyalBlue;
                    blueSound.Play();
                    Refresh();
                    Thread.Sleep(downtime);
                    blueButton.BackColor = Color.DarkBlue;
                    Refresh();
                    Thread.Sleep(downtime);
                }
            }
            //TODO: get guess index value back to 0
            index = 0;
            if (downtime >= 110) downtime -= 10;
            playerTurn = true;
        }

        public void GameOver()
        {
            //TODO: Play a game over sound
            gameoverSound.Play();
            Thread.Sleep(downtime);
            gameLoop.Enabled = false;
            //TODO: close this screen and open the GameOverScreen
            Form f = this.FindForm();
            f.Controls.Remove(this);

            GameOverScreen gos = new GameOverScreen();
            f.Controls.Add(gos);
            gos.Location = new Point((f.Width - gos.Width) / 2, (f.Height - gos.Height) / 2);
        }

        //TODO: create one of these event methods for each button
        private void greenButton_Click(object sender, EventArgs e)
        {
            /*TODO: is the value at current guess index equal to a green. If so:
            * light up button, play sound, and pause
            * set button colour back to original
            * add one to the guess index
            * check to see if we are at the end of the pattern. If so:
            * call ComputerTurn() method
            * else call GameOver method*/
            if (Form1.pattern[index] == 0)
            {
                greenButton.BackColor = Color.LimeGreen;
                greenSound.Play();
                Refresh();
                Thread.Sleep(downtime);
                greenButton.BackColor = Color.ForestGreen;
                index++;
                playerTurn = false;
                if (index >= Form1.pattern.Count) ComputerTurn();
            } else GameOver();
        }

        private void redButton_Click(object sender, EventArgs e)
        {
            if (Form1.pattern[index] == 1)
            {
                redButton.BackColor = Color.Red;
                redSound.Play();
                Refresh();
                Thread.Sleep(downtime);
                redButton.BackColor = Color.DarkRed;
                index++;
                playerTurn = false;
                if (index >= Form1.pattern.Count) ComputerTurn();
            } else GameOver();
        }

        private void yellowButton_Click(object sender, EventArgs e)
        {
            if (Form1.pattern[index] == 2)
            {
                yellowButton.BackColor = Color.Yellow;
                yellowSound.Play();
                Refresh();
                Thread.Sleep(downtime);
                yellowButton.BackColor = Color.Goldenrod;
                index++;
                playerTurn = false;
                if (index >= Form1.pattern.Count) ComputerTurn();
            } else GameOver();
        }

        private void blueButton_Click(object sender, EventArgs e)
        {
            if (Form1.pattern[index] == 3)
            {
                blueButton.BackColor = Color.RoyalBlue;
                blueSound.Play();
                Refresh();
                Thread.Sleep(downtime);
                blueButton.BackColor = Color.DarkBlue;
                index++;
                playerTurn = false;
                if (index >= Form1.pattern.Count) ComputerTurn();
            } else GameOver();
        }

        private void gameLoop_Tick(object sender, EventArgs e)
        {
            if (playerTurn)
            {
                timer--;
                if (timer <= 0)
                {
                    gameLoop.Enabled = false;
                    GameOver();
                }
            }
        }
    }
}
