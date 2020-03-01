using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project2
{
    public partial class Form1 : Form
    {
        int i = 0;
        string file;
        string target;
        char guess;
        int tries;
        bool hit;
        public Form1()
        {
            InitializeComponent();
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void RandomWordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WordList w1 = new WordList();
            if (w1.ShowDialog() == DialogResult.OK)
                file = WordList.path;
            StreamReader sr = new StreamReader(file);
            while (sr.ReadLine() != null)
                i++;
            sr.Dispose();
            sr = new StreamReader(file);
            Random r = new Random();
            for (int k = 0; k < r.Next(1, i-1); k++)
                target = sr.ReadLine();
            sr.Dispose();
            //  Displays the word that is to be guessed for debugging purposes
            //  MessageBox.Show(target);  
            Setting();
        }

        private void Setting()
        {
            label1.Text = "";
            for (i = 0; i < target.Length; i++)
                label1.Text = label1.Text.Insert(i, "*");
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            guess = textBox1.Text[0];
            

            for (i=0; i < target.Length; i++)
            {
                if (Char.ToUpper(target[i]) == Char.ToUpper(guess))
                {
                    hit = true;
                    label1.Text = label1.Text.Remove(i, 1);
                    label1.Text = label1.Text.Insert(i, guess.ToString());
                }
               
            }
            if (label1.Text.ToUpper() == target.ToUpper())
                WonGame();
            if(!hit)
            {
                tries++;
                label4.Text = label4.Text + ", " + guess;
                
                switch (tries)
                {
                    case 1:
                        pictureBox1.Image = Project2.Properties.Resources._1;
                        break;
                    case 2:
                        pictureBox1.Image = Project2.Properties.Resources._2;
                        break;
                    case 3:
                        pictureBox1.Image = Project2.Properties.Resources._4;
                        break;
                    case 4:
                        pictureBox1.Image = Project2.Properties.Resources._5;
                        break;
                    case 5:
                        pictureBox1.Image = Project2.Properties.Resources._6;
                        break;
                    case 6:
                        pictureBox1.Image = Project2.Properties.Resources._7;
                        break;
                    case 7:
                        pictureBox1.Image = Project2.Properties.Resources._8;
                        break;
                    case 8:
                        pictureBox1.Image = Project2.Properties.Resources._9;
                        break;
                    case 9:
                        {
                            pictureBox1.Image = Project2.Properties.Resources._10;
                            LostGame();
                        }
                        break;
                                   
                }
                if (tries == 9)
                    LostGame();
            }
            hit = false;

            textBox1.Focus();
            textBox1.SelectAll();
        }

        private void LostGame()
        {
            MessageBox.Show("You lost! The word was " + target + Environment.NewLine + "Select new game to play again.");
            ResetGame();

        }

        private void WonGame()
        {
            MessageBox.Show("You won! The word was " + target + ". It took you " + tries + " tries." + Environment.NewLine + "Select new game to play again.");
            ResetGame();
        }

        private void ResetGame()
        {
            textBox1.Text = "";
            label1.Text = "Secret Word";
            target = "";
            label4.Text = "Guessed Letters:";
            tries = 0;
            pictureBox1.Image = Project2.Properties.Resources._0;
            button1.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void MenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            pictureBox1.Image = Project2.Properties.Resources._0;
            button1.Enabled = true;
        }

        private void NewGameToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
