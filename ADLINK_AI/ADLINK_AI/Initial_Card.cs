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
    public partial class Initial_Card : Form
    {
        public static Int16 card_ID =999;
        public static UInt16 card_Name = 999, card_Num = 999;

        public Form1 MainForm;//Form2 to Form1

        public Initial_Card()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //DialogResult == DialogResult.OK;
        }

        private void Initial_Card_Load(object sender, EventArgs e)
        {

        }

        private void Initial_Card_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void button1_Click_1(object sender, EventArgs e)    //判斷是否卡片設定正確
        {
            String cardname;
            cardname = cb_Card_Name.Text;
            card_Num = Convert.ToUInt16(cb_Card_Number.Text);

            card_Name = SKY_FUN_QC.switchCardName(cardname);

            card_ID = DASK.Register_Card(card_Name, card_Num);
            //card_ID = 0;

//            if ((cb_Card_Name.Text != "PCI_9111HR") || (cb_Card_Number.Text != "0") || card_ID < 0)
            if ((cb_Card_Name.Text == "") || (cb_Card_Number.Text != "0") || card_ID < 0)
                MessageBox.Show("輸入錯誤 \n" + Convert.ToString(card_ID));
            else
            {
                this.DialogResult = DialogResult.OK;

                MainForm.test2 = this.cb_Card_Name.Text;// "成功囉";// this.textBox1_F2.Text;//Form2 to Form1
                MainForm.test1 = this.cb_Card_Number.Text;//
                MainForm.carda = Convert.ToUInt16(card_ID);


                //Form1.label7.Text = "成功囉";
                Form1 lForm1 = (Form1)this.Owner;//把Form2的父窗口指針賦給lForm1


                //lForm1.StrValue = "子窗口Form2返回數值成功";//使用父窗口指針賦值  
                this.Close();
                

            }




            }
    }
}
