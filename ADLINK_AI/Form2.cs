using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADLINK_AI
{
    public partial class Form2 : Form
    {

        public Form1 MainForm;//Form2 to Form1


        public Form2()
        {
            InitializeComponent();
        }

        public string test//Form1 to Form2
        {
            //get { return textBox1_F2.Text; }
            set { textBox1_F2.Text = value; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainForm.test1 = this.textBox1_F2.Text;//Form2 to Form1
        }
    }
}
