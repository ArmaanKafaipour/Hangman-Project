using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project2
{
    public partial class WordList : Form
    {
        public static string path;
        public WordList()
        {
            InitializeComponent();
        }

        private void WordList_Load(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog opd = new OpenFileDialog();
            if (opd.ShowDialog() == DialogResult.OK)
            {
                path = opd.FileName;
                textBox1.Text = path;
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != null)
            {
                this.Close();
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
