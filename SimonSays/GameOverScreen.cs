using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SimonSays
{
    public partial class GameOverScreen : UserControl
    {
        public GameOverScreen()
        {
            InitializeComponent();
        }

        private void GameOverScreen_Load(object sender, EventArgs e)
        {
            //TODO: show the length of the pattern
            int count = Form1.pattern.Count();
            patternLabel.Text += $"{count}";
            if (count <= 4)
            {
                resultLabel.Text = "YOU ARE A GOLDFISH";
            }
            else if (count <= 8)
            {
                resultLabel.Text = "You can do better than that";
            }
            else if (count <= 12)
            {
                resultLabel.Text = "You are doing well,\n keep trying";
            }
            else if (count <= 16)
            {
                resultLabel.Text = "Good Job,\n that is pretty good";
            }
            else if (count <= 20)
            {
                resultLabel.Text = "WOW!\n you are better than\nmy Mom!";
            }
            else if (count <= 25)
            {
                resultLabel.Text = "you have an elephant brain";
            }
            else
            {
                resultLabel.Text = "You are a super genius";
            }
            if (count > Form1.highscore)
            {
                Form1.highscore = count;
            }
            highscoreLabel.Text += $"{Form1.highscore}";
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            //TODO: close this screen and open the MenuScreen
            Form f = this.FindForm();
            f.Controls.Remove(this);

            MenuScreen ms = new MenuScreen();
            f.Controls.Add(ms);
            ms.Location = new Point((f.Width - ms.Width) / 2, (f.Height - ms.Height) / 2);

        }
    }
}
