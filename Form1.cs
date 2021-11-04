using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace trees
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(MousePosition.X + "\n" + MousePosition.Y);
        }

        private  void button1_Click(object sender, EventArgs e)
        {
            var tre = new tree(pictureBox1 ,textBox1);
            tre.TreeMaker();






        }
    }
}
