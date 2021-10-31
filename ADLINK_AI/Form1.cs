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
    public partial class Form1 : Form
    {
        //-------------共用變數----------------------//
        public int Fun_Num; //波形產生器cardID
        //-------------------------------------------//

        public Initial_Card F2 = new Initial_Card();    //關鍵

       public static UInt16 cardID;
        public Form1()
        {
            InitializeComponent();
            F2.MainForm = this;//Form2 to Form1            
        }

        public string test1//Form2 to Form1 的變數
        {
            get { return textBox1_F1.Text; }
            set { textBox1_F1.Text = value; }
        }

        public string test2//Form2 to Form1 的變數
        {
            get { return textBox2_F1.Text; }
            set { textBox2_F1.Text = value; }
        }

        public UInt16 carda//Form2 to Form1 暫時存放的變數
        {            
            set { cardID = value; }
        }

        public void log_show(int err, string pass_word, string err_word)
        {
            if (err < 0)                
                logbox1.Items.Add(err_word + err);
            else
                logbox1.Items.Add(pass_word);

        }

        private void 版本資訊ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(" 作者:Sky \n 版本: 0.0 \n 修改日期: 2019/11/30");            
        }

        private void 初始化ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            
            DialogResult dr = new DialogResult();
            F2.Owner = this;//重要的一步，主要是使Form2的Owner指標指向Form1
            dr = F2.ShowDialog();
                       
            if (dr == DialogResult.OK)
            {
                int aaa = Convert.ToInt16(cardID);
                MessageBox.Show("User clicked OK button \n card ID = "+ aaa);                
                tabControl1.Visible = true;
            }

            else if (dr == DialogResult.Cancel)
            {
                MessageBox.Show("User clicked Cancel button");
                tabControl1.Visible = false;
            }
            this.Show();


        }

        private void button1_Click(object sender, EventArgs e)
        {           
            UInt16 AI_CH = Convert.ToUInt16(tB_AI_CH.Text);

            UInt16 ADCRange =Convert.ToUInt16(tB_AI_GAIN.Text);

            Double ADC_SampRate = Convert.ToUInt16(tB_ADC_SampleRate.Text);

            UInt32 READCOUNT = Convert.ToUInt32(tB_TestCount.Text);

            String File_Name = "1";

            //----------------卡片資訊---------------------------------*
            String cardSN = tB_SN.Text;
            String TestDate = string.Format("{0:yyyyMMdd}", dT_TestDate.Value);
            //---------------------------------------------------------*


            File_Name = "SYSNO_SKY_" + cardSN + "_" + TestDate;

            //----------------測試程式---------------------------------*
            SKY_FUN_QC.qcSYS_NOISE(cardID, AI_CH, ADCRange, ADC_SampRate, READCOUNT, File_Name);   //開始測試SystemNoise
            MessageBox.Show("完成");
            //---------------------------------------------------------*
        }   //SYSTEM NOISE測試

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SKY_FUN_GPIB.closeDev();   
            DASK.Release_Card(cardID);
        }   //視窗關閉

        private void button2_Click(object sender, EventArgs e)  //驗證用
        {
            Int16 b = 15;
            double c = 1.1;
            string a = "this is test " + b;
            UInt16 dd = 0xA0A;
            String TestDate = dT_TestDate.Text;


            a = a + "\r\n" + "next row test";
            a = a + "\r\n" + "3 row test" + "\t" + "tab test";
            a = a + "\r\nNumber 0x" + Convert.ToString(b, 16);

            a = a + "\r\nFloating Number = " + String.Format("{0:00.00}", c);

            a = a + "\r\nLeft 4 bit = 0x" + (dd >> 4);
            
            a = a + "\r\nTest Date=" + string.Format("{0:yyyyMMdd}", dT_TestDate.Value);

            if (SKY_FUN.cFile("123", a) == 1)
            {
                
                MessageBox.Show("完成");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)  //GPIB 初始化
        {
            Fun_Num = SKY_FUN_GPIB.iniAFG3022B(0, 22);	//初始化波形產生器

        }

        private void button4_Click(object sender, EventArgs e)  //AI_BandWidth測試
        {
            UInt16 AI_CH = Convert.ToUInt16(tB_AI_CH.Text);

            UInt16 ADCRange = Convert.ToUInt16(tB_AI_GAIN.Text);

            Double ADC_SampRate = Convert.ToUInt16(tB_ADC_SampleRate.Text);

            UInt32 READCOUNT = Convert.ToUInt32(tB_TestCount.Text);

            String File_Name = "1";

            int start_freq = Convert.ToInt16(tB_str_freq.Text);

            int Fun_Num = 0;

            //----------------卡片資訊---------------------------------*
            String cardSN = tB_SN.Text;
            String TestDate = string.Format("{0:yyyyMMdd}", dT_TestDate.Value);
            //---------------------------------------------------------*


            File_Name = "AIBW_SKY_" + cardSN + "_" + TestDate;

            //----------------測試程式---------------------------------*
            SKY_FUN_QC.qcAI_BW(Fun_Num, cardID, AI_CH, ADCRange, ADC_SampRate, READCOUNT, File_Name, start_freq);   //開始測試AI Bandwidth
            MessageBox.Show("完成");
            //---------------------------------------------------------*
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string[] err_log = new string[7];

            err_log = SKY_FUN_QC.sAICard(cardID, DASK.PCI_9111HR);  //初始化

            for(int i =0; i<Convert.ToInt16(err_log[0]); i++)
                log_show(Convert.ToInt16(err_log[3*i+1]), err_log[3 * i + 2], err_log[3 * i + 3]);            //回傳初始化錯誤代碼
            
            MessageBox.Show("初始化完成");
        }

        private void button6_Click(object sender, EventArgs e)  //儲存測試用log
        {
           
            logbox1.Items.Add("123");   //新增項目
            string c = logbox1.Items.Count.ToString();
            MessageBox.Show("item=" + c);

            for (int b = 0; b < Convert.ToInt16(logbox1.Items.Count.ToString()); b++)
            {
                string a = logbox1.Items[b].ToString(); //取得第幾個資料
                SKY_FUN.cFile("log_" + string.Format("{0:yyyyMMdd}", dT_TestDate.Value), a);
            }
                MessageBox.Show("建立完成");
        }
    }
}
