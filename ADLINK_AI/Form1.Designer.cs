namespace ADLINK_AI
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label7 = new System.Windows.Forms.Label();
            this.tB_ADC_SampleRate = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.tB_SN = new System.Windows.Forms.TextBox();
            this.dT_TestDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.tB_AI_GAIN = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tB_AI_CH = new System.Windows.Forms.TextBox();
            this.tB_TestCount = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.button5 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.初始化ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.說明ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.版本資訊ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.textBox1_F1 = new System.Windows.Forms.TextBox();
            this.textBox2_F1 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.logbox1 = new System.Windows.Forms.ListBox();
            this.button6 = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.tB_str_freq = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.AccessibleName = "";
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tabControl1.Location = new System.Drawing.Point(293, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(452, 463);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.Visible = false;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.tabPage1.Controls.Add(this.listBox1);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.tB_ADC_SampleRate);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.tB_AI_GAIN);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.tB_AI_CH);
            this.tabPage1.Controls.Add(this.tB_TestCount);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(444, 430);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "測試條件設定";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(306, 27);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 20);
            this.label7.TabIndex = 14;
            this.label7.Text = "這是測試";
            // 
            // tB_ADC_SampleRate
            // 
            this.tB_ADC_SampleRate.Location = new System.Drawing.Point(144, 142);
            this.tB_ADC_SampleRate.Name = "tB_ADC_SampleRate";
            this.tB_ADC_SampleRate.Size = new System.Drawing.Size(100, 29);
            this.tB_ADC_SampleRate.TabIndex = 13;
            this.tB_ADC_SampleRate.Text = "100000";
            this.tB_ADC_SampleRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(36, 145);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 20);
            this.label6.TabIndex = 12;
            this.label6.Text = "取樣速度";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(176, 303);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(111, 51);
            this.button2.TabIndex = 11;
            this.button2.Text = "建立檔案(測試用)";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tB_SN
            // 
            this.tB_SN.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tB_SN.Location = new System.Drawing.Point(87, 109);
            this.tB_SN.Name = "tB_SN";
            this.tB_SN.Size = new System.Drawing.Size(100, 29);
            this.tB_SN.TabIndex = 10;
            this.tB_SN.Text = "1003";
            this.tB_SN.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dT_TestDate
            // 
            this.dT_TestDate.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.dT_TestDate.Location = new System.Drawing.Point(87, 144);
            this.dT_TestDate.Name = "dT_TestDate";
            this.dT_TestDate.Size = new System.Drawing.Size(200, 29);
            this.dT_TestDate.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.Location = new System.Drawing.Point(8, 150);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "測試日期";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(8, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "卡片序號";
            // 
            // button1
            // 
            this.button1.AutoSize = true;
            this.button1.Location = new System.Drawing.Point(15, 89);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(148, 51);
            this.button1.TabIndex = 6;
            this.button1.Text = "SystemNoise測試";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tB_AI_GAIN
            // 
            this.tB_AI_GAIN.Location = new System.Drawing.Point(144, 107);
            this.tB_AI_GAIN.Name = "tB_AI_GAIN";
            this.tB_AI_GAIN.Size = new System.Drawing.Size(100, 29);
            this.tB_AI_GAIN.TabIndex = 5;
            this.tB_AI_GAIN.Text = "5";
            this.tB_AI_GAIN.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "GAIN";
            // 
            // tB_AI_CH
            // 
            this.tB_AI_CH.Location = new System.Drawing.Point(144, 74);
            this.tB_AI_CH.Name = "tB_AI_CH";
            this.tB_AI_CH.Size = new System.Drawing.Size(100, 29);
            this.tB_AI_CH.TabIndex = 3;
            this.tB_AI_CH.Text = "0";
            this.tB_AI_CH.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tB_TestCount
            // 
            this.tB_TestCount.Location = new System.Drawing.Point(144, 41);
            this.tB_TestCount.Name = "tB_TestCount";
            this.tB_TestCount.Size = new System.Drawing.Size(100, 29);
            this.tB_TestCount.TabIndex = 2;
            this.tB_TestCount.Text = "32768";
            this.tB_TestCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.tB_TestCount, "最多輸入到32768");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "測試通道";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "測試筆數";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.tabPage2.Controls.Add(this.tB_str_freq);
            this.tabPage2.Controls.Add(this.label13);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(444, 430);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "類比功能測試";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button4);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Location = new System.Drawing.Point(240, 27);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(187, 161);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "開始測試";
            // 
            // button4
            // 
            this.button4.AutoSize = true;
            this.button4.Location = new System.Drawing.Point(15, 36);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(132, 47);
            this.button4.TabIndex = 1;
            this.button4.Text = "Bandwidth測試";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Location = new System.Drawing.Point(18, 17);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(137, 68);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "GPIB";
            // 
            // button3
            // 
            this.button3.AutoSize = true;
            this.button3.Location = new System.Drawing.Point(18, 26);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 30);
            this.button3.TabIndex = 0;
            this.button3.Text = "註冊";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.tabPage3.Controls.Add(this.textBox1);
            this.tabPage3.Controls.Add(this.comboBox2);
            this.tabPage3.Controls.Add(this.comboBox1);
            this.tabPage3.Controls.Add(this.label12);
            this.tabPage3.Controls.Add(this.label11);
            this.tabPage3.Controls.Add(this.label10);
            this.tabPage3.Controls.Add(this.button5);
            this.tabPage3.Location = new System.Drawing.Point(4, 29);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(444, 430);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "設定卡片";
            // 
            // button5
            // 
            this.button5.AutoSize = true;
            this.button5.Location = new System.Drawing.Point(288, 149);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 30);
            this.button5.TabIndex = 2;
            this.button5.Text = "執行";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("標楷體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.初始化ToolStripMenuItem,
            this.說明ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(757, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 初始化ToolStripMenuItem
            // 
            this.初始化ToolStripMenuItem.Font = new System.Drawing.Font("標楷體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.初始化ToolStripMenuItem.Name = "初始化ToolStripMenuItem";
            this.初始化ToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.初始化ToolStripMenuItem.Text = "初始化";
            this.初始化ToolStripMenuItem.Click += new System.EventHandler(this.初始化ToolStripMenuItem_Click);
            // 
            // 說明ToolStripMenuItem
            // 
            this.說明ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.版本資訊ToolStripMenuItem});
            this.說明ToolStripMenuItem.Font = new System.Drawing.Font("標楷體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.說明ToolStripMenuItem.Name = "說明ToolStripMenuItem";
            this.說明ToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.說明ToolStripMenuItem.Text = "說明";
            // 
            // 版本資訊ToolStripMenuItem
            // 
            this.版本資訊ToolStripMenuItem.Font = new System.Drawing.Font("標楷體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.版本資訊ToolStripMenuItem.Name = "版本資訊ToolStripMenuItem";
            this.版本資訊ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.版本資訊ToolStripMenuItem.Text = "版本資訊";
            this.版本資訊ToolStripMenuItem.Click += new System.EventHandler(this.版本資訊ToolStripMenuItem_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.BackColor = System.Drawing.SystemColors.HotTrack;
            this.toolTip1.Tag = "";
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip1.ToolTipTitle = "資料筆數上限";
            // 
            // textBox1_F1
            // 
            this.textBox1_F1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox1_F1.Location = new System.Drawing.Point(87, 74);
            this.textBox1_F1.Name = "textBox1_F1";
            this.textBox1_F1.Size = new System.Drawing.Size(100, 29);
            this.textBox1_F1.TabIndex = 2;
            // 
            // textBox2_F1
            // 
            this.textBox2_F1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox2_F1.Location = new System.Drawing.Point(87, 39);
            this.textBox2_F1.Name = "textBox2_F1";
            this.textBox2_F1.Size = new System.Drawing.Size(100, 29);
            this.textBox2_F1.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label8.Location = new System.Drawing.Point(8, 48);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 20);
            this.label8.TabIndex = 15;
            this.label8.Text = "卡片名稱";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label9.Location = new System.Drawing.Point(8, 83);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(73, 20);
            this.label9.TabIndex = 16;
            this.label9.Text = "卡片編號";
            // 
            // logbox1
            // 
            this.logbox1.FormattingEnabled = true;
            this.logbox1.ItemHeight = 12;
            this.logbox1.Items.AddRange(new object[] {
            "This is log record..."});
            this.logbox1.Location = new System.Drawing.Point(12, 179);
            this.logbox1.Name = "logbox1";
            this.logbox1.Size = new System.Drawing.Size(275, 112);
            this.logbox1.TabIndex = 17;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(12, 303);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(111, 51);
            this.button6.TabIndex = 18;
            this.button6.Text = "建立檔案";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 30);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(90, 20);
            this.label10.TabIndex = 3;
            this.label10.Text = "TrigSource";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 66);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(82, 20);
            this.label11.TabIndex = 4;
            this.label11.Text = "TirgMode";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 103);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(77, 20);
            this.label12.TabIndex = 5;
            this.label12.Text = "TraceCnt";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "TRIG_INT_PACER",
            "TRIG_EXT_STROBE"});
            this.comboBox1.Location = new System.Drawing.Point(118, 27);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(200, 28);
            this.comboBox1.TabIndex = 9;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "P9111_TRGMOD_SOFT",
            "P9111_TRGMOD_PRE",
            "P9111_TRGMOD_POST"});
            this.comboBox2.Location = new System.Drawing.Point(118, 67);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(200, 28);
            this.comboBox2.TabIndex = 10;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(118, 103);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 29);
            this.textBox1.TabIndex = 11;
            this.textBox1.Text = "0";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 20;
            this.listBox1.Items.AddRange(new object[] {
            "        ADCGAIN[0] = DASK.AD_B_10_V;",
            "        ADCGAIN[1] = DASK.AD_B_5_V;",
            "        ADCGAIN[2] = DASK.AD_B_2_5_V;",
            "        ADCGAIN[3] = DASK.AD_B_1_25_V;",
            "        ADCGAIN[4] = DASK.AD_B_0_625_V;",
            "        ADCGAIN[5] = DASK.AD_U_10_V;",
            "        ADCGAIN[6] = DASK.AD_U_5_V;",
            "        ADCGAIN[7] = DASK.AD_U_2_5_V;",
            "        ADCGAIN[8] = DASK.AD_U_1_25_V;"});
            this.listBox1.Location = new System.Drawing.Point(40, 177);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(351, 204);
            this.listBox1.TabIndex = 15;
            // 
            // tB_str_freq
            // 
            this.tB_str_freq.Location = new System.Drawing.Point(132, 94);
            this.tB_str_freq.Name = "tB_str_freq";
            this.tB_str_freq.Size = new System.Drawing.Size(100, 29);
            this.tB_str_freq.TabIndex = 4;
            this.tB_str_freq.Text = "1";
            this.tB_str_freq.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.tB_str_freq, "最多輸入到32768");
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(14, 97);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(112, 20);
            this.label13.TabIndex = 3;
            this.label13.Text = "起始頻率(kHz)";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(757, 535);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.logbox1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tB_SN);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox2_F1);
            this.Controls.Add(this.dT_TestDate);
            this.Controls.Add(this.textBox1_F1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.tabControl1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 初始化ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 說明ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 版本資訊ToolStripMenuItem;
        private System.Windows.Forms.TextBox tB_AI_CH;
        private System.Windows.Forms.TextBox tB_TestCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tB_AI_GAIN;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker dT_TestDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tB_SN;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox tB_ADC_SampleRate;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox1_F1;
        private System.Windows.Forms.TextBox textBox2_F1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.ListBox logbox1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TextBox tB_str_freq;
        private System.Windows.Forms.Label label13;
    }
}

