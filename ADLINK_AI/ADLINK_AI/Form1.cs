using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace ADLINK_AI
{   
    public partial class Form1 : Form
    {
        //-------------共用變數----------------------//
        public int Fun_Num; //波形產生器cardID
        public ushort CardName; //測試卡片名稱           
        //-------------------------------------------//

        public Initial_Card F2 = new Initial_Card();    //關鍵

       public static ushort cardID;
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

        public ushort carda//Form2 to Form1 暫時存放的變數
        {            
            set { cardID = value; }
        }

        public int ReadRow { get; private set; }

        public void log_show(int err, string pass_word, string err_word)
        {
            if (err < 0)                
                logbox1.Items.Add(err_word + err);
            else
                logbox1.Items.Add(pass_word);

        }

        private void 版本資訊ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string Log_History;
            Log_History = @"
作者:Sky
版本 : 0.0    修改日期: 2019/11/30    修改紀錄 : 初版
版本 : 0.1    修改日期: 2019/12/10    修改紀錄 : 新增9113, 9114, 9111 card
版本 : 0.2    修改日期: 2019/12/11    修改紀錄 : 新增DASK.CS中AI_ContReadChannel將Buffer修改為uint[]
版本 : 0.3    修改日期: 2019/12/11    修改紀錄 : 新增9113, 9114 data_buf為U32, 9111, 9112為U16
版本 : 0.4    修改日期: 2021/10/06    修改紀錄 : 新增9524

                            ";


            MessageBox.Show(Log_History);
            
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

        private void button1_Click(object sender, EventArgs e)  //SYSTEM NOISE測試
        {
            ushort AI_CH = Convert.ToUInt16(tB_AI_CH.Text);

            ushort ADCRange = Convert.ToUInt16(tB_AI_GAIN.Text);
            string[] ADCRange_r = new string[listBox1.SelectedItems.Count];
            listBox1.SelectedItems.CopyTo(ADCRange_r, 0);

            logbox1.Items.Add(listBox1.SelectedItems.Count);   //新增項目

            //foreach (string s_val in ADCRange_r)    MessageBox.Show(s_val); //顯示選擇的GAIN


            string[] ADC_SampRate_r;
            //double ADC_SampRate = Convert.ToDouble(tB_ADC_SampleRate.Text);

            uint READCOUNT = Convert.ToUInt32(tB_TestCount.Text);

            //ushort AI_CH = 1;
            //ushort ADCRange = 1;
            //double ADC_SampRate = 100000;
            //uint READCOUNT = 32768;

            if (checkBox1.Checked)
            { 
                ADC_SampRate_r = new string[list_AD_Sample_Rate.SelectedItems.Count];
                list_AD_Sample_Rate.SelectedItems.CopyTo(ADC_SampRate_r, 0);
            }
            else
                ADC_SampRate_r = new string[] { tB_ADC_SampleRate.Text };
            

            foreach (string ADC_SampRate in ADC_SampRate_r)  //測試不同Gain
            {
                String File_Name = "1";

                //----------------卡片資訊---------------------------------*
                String cardSN = tB_SN.Text;
                String TestDate = string.Format("{0:yyyyMMdd}", dT_TestDate.Value);
                //---------------------------------------------------------*


                File_Name = "SYSNO_SKY_" + cardSN + "_" + TestDate;

                //----------------測試程式---------------------------------*
                //SKY_FUN_QC.qcSYS_NOISE(cardID, CardName, AI_CH, ADCRange, ADC_SampRate, READCOUNT, File_Name);   //開始測試SystemNoise
                SKY_FUN_QC.qcSYS_NOISE(cardID, CardName, AI_CH, ADCRange_r, Convert.ToDouble(ADC_SampRate), READCOUNT, File_Name, TestDate, cardSN);   //開始測試SystemNoise
            }
            MessageBox.Show("完成");
            //---------------------------------------------------------*
        }   

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
            ushort dd = 0xA0A;
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
            ushort AI_CH = Convert.ToUInt16(tB_AI_CH.Text);

            ushort ADCRange = Convert.ToUInt16(tB_AI_GAIN.Text);

            double ADC_SampRate = Convert.ToUInt16(tB_ADC_SampleRate.Text);

            uint READCOUNT = Convert.ToUInt32(tB_TestCount.Text);

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

        private void button5_Click(object sender, EventArgs e)  //AI初始化設定
        {
            string[] err_log = new string[7];

            //---------------------設定Gain清單-------------------------------//
            CardName = SKY_FUN_QC.switchCardName(textBox2_F1.Text);
            string[] card_gain = SKY_FUN_QC.cardGain(textBox2_F1.Text);

                foreach (string list_item in card_gain)
                    listBox1.Items.Add(list_item);
            //------------------------------------------------------------//

            //---------------------設定Sample清單-------------------------------//

            if (textBox2_F1.Text == "PCI-9524")
            {
                list_AD_Sample_Rate.Visible = true;
                checkBox1.Visible = true;
            }
            //------------------------------------------------------------//


            err_log = SKY_FUN_QC.sAICard(cardID, CardName);  //初始化

            


            for (int i =0; i<Convert.ToInt16(err_log[0]); i++)
                log_show(Convert.ToInt16(err_log[3*i+1]), err_log[3 * i + 2], err_log[3 * i + 3]);            //回傳初始化錯誤代碼

            button1.Enabled = true; //啟用SystemNoise按鈕
            
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

        private void button7_Click(object sender, EventArgs e)
        {
            int L_Num = listBox4.SelectedItems.Count;
            MessageBox.Show("選擇比數 = " + L_Num);

            string [] AA = new string [listBox4.SelectedItems.Count];
            listBox4.SelectedItems.CopyTo(AA,0);

            foreach(string s_val in AA)
            MessageBox.Show(s_val);



        }

        private void button8_Click(object sender, EventArgs e)
        {
            ushort AI_CH = Convert.ToUInt16(tB_AI_CH.Text);

            ushort ADCRange = Convert.ToUInt16(tB_AI_GAIN.Text);
            string[] ADCRange_r = new string[listBox1.SelectedItems.Count];
            listBox1.SelectedItems.CopyTo(ADCRange_r, 0);
            /*
            foreach (string s_val in ADCRange_r)
                MessageBox.Show(s_val);
            */
            double ADC_SampRate = Convert.ToDouble(tB_ADC_SampleRate.Text);

            uint READCOUNT = Convert.ToUInt32(tB_TestCount.Text);
            

            //ushort AI_CH = 1;
            //ushort ADCRange = 1;
            //double ADC_SampRate = 100000;
            //uint READCOUNT = 32768;

            String File_Name = "1";

            //----------------卡片資訊---------------------------------*
            String cardSN = tB_SN.Text;
            String TestDate = string.Format("{0:yyyyMMdd}", dT_TestDate.Value);
            //---------------------------------------------------------*


            File_Name = "SYSNO_SKY_" + cardSN + "_" + TestDate;

            //----------------測試程式---------------------------------*

            Int16 err = 0;
            ushort CH = AI_CH;
            
            String SaveName;

            foreach (string s_ADCRANGE in ADCRange_r)  //測試不同Gain
            {
                ushort i = SKY_FUN_QC.ADCGAIN(s_ADCRANGE);
                //printf("\n$[TEST]4.5  AI Group #%d Range #%d ADC_SampRate #%0.0f System Noise Check ... ", Group, ADCGAIN[i], ADC_SampRate);
                for (CH = 0; CH <= AI_CH; CH++)
                {
                    //sprintf(File_Name, "SYSNO_SKY_%d_%d_G%d_CH%d.txt", test_date1, test_date2, i, CH);                
                    //err = DASK.AI_ContReadChannel(cardID, CH, ADCGAIN(i), TEST, READCOUNT, ADC_SampRate, 1); //CH

                    //TEST = SKY_FUN_QC.qc_AIContRead(cardID, CH, i, ADC_SampRate, READCOUNT, CardName); //抓取資料並轉換完畢

                    //------Create Save File-------------------------------------------------*
                    SaveName = File_Name + "_G" + i + "_CH" + CH + ".txt";  //建立檔案名稱
                    String wDate = "\nGroup \t#" + CH + "\tRange \t#" + i + " \tADC_SampRate \t#" + ADC_SampRate;
                    SKY_FUN.cFile(SaveName, wDate);

                    //for (int j = 0; j < AI_CH; j++)
                    SKY_FUN.cFile(SaveName, "CH" + CH);

                    byte stopped;
                    uint access_cnt;

                    ushort[] TEST = new ushort[READCOUNT];

                    MessageBox.Show("START AI_AI_ContReadChannel");
                    //err = DASK.AI_ContReadChannel(cardID, CH, DASK.AD_B_1_V, TEST, READCOUNT, ADC_SampRate, DASK.ASYNCH_OP);
                    err = DASK.AI_ContReadChannel((ushort)cardID, CH, i, TEST, READCOUNT, ADC_SampRate, DASK.ASYNCH_OP); //CH
                    if (err < 0) { MessageBox.Show("AI_AI_ContReadChannel Error = " + err); }  //由系統通知錯誤的視窗
                    MessageBox.Show("Finish AI_AI_ContReadChannel");

                    do
                    {
                        err = DASK.AI_AsyncCheck((ushort)cardID, out stopped, out access_cnt);
                        if (err < 0)
                            throw new Exception("AI_AsyncCheck Error = " + err);
                    } while (stopped == 0);

                    MessageBox.Show("Finish AI_AsyncCheck");
                    err = DASK.AI_AsyncClear((ushort)cardID, out access_cnt);

                    MessageBox.Show("Finish AI_AsyncClear");

                    //------Create Data Value-------------------------------------------------*	
                    for (int j = 0; j < READCOUNT; j++)
                    {
                        TEST[j] = Convert.ToUInt16(TEST[j] & (0x0FFF)); //9113 
                    }
                    //----------------------------------------------------------------*

                    MessageBox.Show("Finish data_trans");

                    //------Create Data Value-------------------------------------------------*	
                    /*for (int j = 0; j < READCOUNT; j++)
                    {
                        MessageBox.Show("start save = "+j);
                        dataa = TEST[j];
                        SKY_FUN.cFile(SaveName, Convert.ToString(dataa));
                        MessageBox.Show("done save = " + j);
                    }*/

                    //Array.ConvertAll(TEST, x => x.ToString());

                    //SKY_FUN.cFile(SaveName, Array.ConvertAll(TEST, x => x.ToString()));
                    SKY_FUN.cFile(SaveName, TEST);
                    //----------------------------------------------------------------*
                }
            }

            MessageBox.Show("完成");
            //---------------------------------------------------------*
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                foreach (string di in openFileDialog1.SafeFileNames)
                {
                    lB_File_Name.Items.Add(di); //取得檔案名稱                    
                }

                tB_File_Path.Text = System.IO.Path.GetDirectoryName(openFileDialog1.FileName);

                //button20.Enabled = true;
                //                MessageBox.Show("Select Path: " + folderBrowserDialog1.SelectedPath);
            }
        }

        

        private void button12_Click(object sender, EventArgs e)
        {
            button12.Enabled = false;    //停用避免Double click
            foreach (string phrase in lB_File_Name.Items)   //重複執行，直到text檔案完成
            {

                //string[] aword = phrase.Split('\\');


                //---------------------檔名拆解-------------------------------------------------------//
                //string phrase = listBox1.Items[0].ToString();
                string[] words = phrase.Split('\\');    //拆解含完整路徑"\"

                string txt_file_path = tB_File_Path.Text + "/" + phrase; //txt完整路徑

                //foreach (var word in words)   MessageBox.Show(word);

                //MessageBox.Show(words.Length.ToString());

                //MessageBox.Show(words[words.Length - 1]); //顯示最後一個資料

                string afile_txt = words[words.Length - 1];

                string[] a_Word = afile_txt.Split('.'); //去除副檔名取得檔名
                string afile_name = a_Word[0];
                string[] a_AI_Array = afile_name.Split('_');    //取得類比相關資訊

                string AI_SN = a_AI_Array[2];
                string AI_CH = a_AI_Array[5];
                //string AI_Freq;
                string AI_Gain = a_AI_Array[4];


                //MessageBox.Show("SN=" + AI_SN + "\nCH=" + AI_CH + "\nGain=" + AI_Gain);
                //----------------------------------------------------------------------------------//

                String TestDate = string.Format("{0:yyyyMMdd}", dT_TestDate.Value);
                //MessageBox.Show( listBox1.Items[0].ToString());
                string filePath = System.IO.Directory.GetCurrentDirectory() + "/" + "AI_SysNoise_"+ TestDate;  //設定Excel報告儲存路徑
                Sky_Excel.txtToexcel(filePath, txt_file_path, "SN=" + AI_SN + "\nCH=" + AI_CH + "\nGain=" + AI_Gain);

                int ADCBIT = Convert.ToInt16(tBADC_Bit.Text);

                int twosCoding = Convert.ToInt16(Data_Transfer_compensate.Checked);
                //string filePath = System.IO.Directory.GetCurrentDirectory() + "/" + textBox2.Text;
                Sky_Excel.AI_Systemnoise_Excel(filePath, ADCBIT, twosCoding);

            }

            MessageBox.Show("完成");
            button12.Enabled = true;    //恢復啟用
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {            
            tB_ADC_SampleRate.Enabled = !checkBox1.Checked;
            list_AD_Sample_Rate.Enabled = checkBox1.Checked;
        }
    }
}
