using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;  //判斷陣列中的最大最小值

using System;
using System.Text;
using System.IO;
using System.Threading;

public class SKY_FUN_MATH
{/*
    m_shift_buffer = m_data_buffer;
                for (int i = 0; i<m_data_buffer.Length; i++)
                    m_shift_buffer[i] = (ushort) (m_shift_buffer[i] + 0x8000);

                data_max[freq] = m_shift_buffer.Max();
                data_min[freq] = m_shift_buffer.Min();
                data_vpp[freq] = data_max[freq] - data_min[freq];

                if (freq == 1)
                    volt_vpp_base = data_max[freq] - data_min[freq];


                Console.WriteLine("OUTVALUE: {0}", 18 / Math.Pow(2, (AI_RANGE - 1)));

                Console.WriteLine("Gain: {0}", AI_RANGE);

                Console.WriteLine("base vpp: {0}", volt_vpp_base);

                volt_3db = 20 * Math.Log10(data_vpp[freq] / volt_vpp_base);


                Console.WriteLine("Now frequency: {0}.113KHz", freq);
                Console.WriteLine(String.Format("3dB voltage: {0:N3} dB", volt_3db));

                Console.WriteLine("Max Code: {0}", data_max[freq]);
                Console.WriteLine("Min Code: {0}", data_min[freq]);
                */
}

public class SKY_FUN
{
    public static UInt16 cFile(String File_Name, String wData)
    {
        /*
        FileStream fs = new FileStream(File_Name + ".txt", FileMode.Create);    //建立新檔案
                
        char[] c = wData.ToCharArray();
        byte[] a = new byte[c.Length];
        for (int i = 0; i < c.Length; i++)
            a[i] = (byte)c[i];

        //------Write Data To File-------------------------------------------------*
        fs.Write(a, 0, a.Length);

        // Close File
        fs.Close();

        */

        StreamWriter sw = new StreamWriter(File_Name + ".txt", true, Encoding.Default);  //建立新檔案並將資料附加在後面
        //------Write Data To File-------------------------------------------------*
        sw.WriteLine(wData);
        // Close File
        sw.Close();

        return 1;
    }
}

public class SKY_FUN_QC
{
    
    
    /*
    enum Card_Bit {
        PCI_6208V = 1,
        PCI_6208A = 2,
        PCI_6308V = 3,
        PCI_6308A = 4,
        PCI_7200 = 5,
        PCI_7230 = 6,
        PCI_7233 = 7,
        PCI_7234 = 8,
        PCI_7248 = 9,
        PCI_7249 = 10,
        PCI_7250 = 11,
        PCI_7252 = 12,
        PCI_7296 = 13,
        PCI_7300A_RevA = 14,
        PCI_7300A_RevB = 15,
        PCI_7432 = 16,
        PCI_7433 = 17,
        PCI_7434 = 18,
        PCI_8554 = 19,
        PCI_9111DG = 20,
        PCI_9111HR = 21,
        PCI_9112 = 22,
        PCI_9113 = 23,
        PCI_9114DG = 24,
        PCI_9114HG = 25,
        PCI_9118DG = 26,
        PCI_9118HG = 27,
        PCI_9118HR = 28,
        PCI_9810 = 29,
        PCI_9812 = 30,
        PCI_7396 = 31,
        PCI_9116 = 32,
        PCI_7256 = 33,
        PCI_7258 = 34,
        PCI_7260 = 35,
        PCI_7452 = 36,
        PCI_7442 = 37,
        PCI_7443 = 38,
        PCI_7444 = 39,
        PCI_9221 = 40,
        PCI_9524 = 41,
        PCI_6202 = 42,
        PCI_9222 = 43,
        PCI_9223 = 44,
        PCI_7433C = 45,
        PCI_7434C = 46,
        PCI_922A = 47,
        PCI_7350 = 48,
        PCI_7360 = 49,
        PCI_7300A_RevC = 50};*/
        
    public static UInt16 ADCGAIN(int n)
    {
        UInt16 a = 0;

        switch (n)
        {
            case 0:
                a = DASK.AD_B_10_V;
                break;
            case 1:
                a = DASK.AD_B_5_V;
                break;
            case 2:
                a = DASK.AD_B_2_5_V;
                break;
            case 3:
                a = DASK.AD_B_1_25_V;
                break;
            case 4:
                a = DASK.AD_B_0_625_V;
                break;
            case 5:
                a = DASK.AD_U_10_V;
                break;
            case 6:
                a = DASK.AD_U_5_V;
                break;
            case 7:
                a = DASK.AD_U_2_5_V;
                break;
            case 8:
                a = DASK.AD_U_1_25_V;
                break;
        }
        return a;

        /*
        //------------ADC GAIN RANGE-------------------------*
        ADCGAIN[0] = DASK.AD_B_10_V;
        ADCGAIN[1] = DASK.AD_B_5_V;
        ADCGAIN[2] = DASK.AD_B_2_5_V;
        ADCGAIN[3] = DASK.AD_B_1_25_V;
        ADCGAIN[4] = DASK.AD_B_0_625_V;
        ADCGAIN[5] = DASK.AD_U_10_V;
        ADCGAIN[6] = DASK.AD_U_5_V;
        ADCGAIN[7] = DASK.AD_U_2_5_V;
        ADCGAIN[8] = DASK.AD_U_1_25_V;
        //---------------------------------------------------*
        */

    }
        
    /*
    public string string[] log_array(string[] a, int n, int err, int l_index, string b, string c)
    {
        a[0] = Convert.ToString(n); //有幾個err_log
        a[3 * l_index - 2] = Convert.ToString(err); //錯誤代碼
        a[3 * l_index - 1] = Convert.ToString(b); //正確字串
        a[3 * l_index] = Convert.ToString(c); //錯誤字串

        return a;
    }

    struct log_array
    {
        public string[] array_name;
        public int array_number;
        public int err_code;
        public int data_index;
        public string pass_word;
        public string err_word;
    }
    */
    public static string[] sAICard(UInt16 cardID, UInt16 cardName)
    {
        string[] log = new string[3 * 2 + 1];
        Int16 err = 0, n = 0;

        log[0] = "2";   //設定有幾個API紀錄
        switch (cardName)
        {
            case DASK.PCI_9111HR:
                err = DASK.AI_9111_Config(cardID, DASK.TRIG_INT_PACER, DASK.P9111_TRGMOD_SOFT, 0);   //PCI-9111HR AI Config
                break;
            case DASK.PCI_9112:
                err = DASK.AI_9112_Config(cardID, DASK.TRIG_INT_PACER);   //PCI-9112A AI Config
                break;
            case DASK.PCI_9113:
                err = DASK.AI_9113_Config(cardID, DASK.TRIG_INT_PACER);  //PCI-9113A AI Config
                break;
            case DASK.PCI_9114DG:
                err = DASK.AI_9114_Config(cardID, DASK.TRIG_INT_PACER); //PCI-9114 AI Config
                break;
        }   
        n = 1;

        log[3 * n - 2] = Convert.ToString(err);
        log[3 * n - 1] = "AI Config Done";
        log[3 * n] = "AI Config Fail=";

        err = DASK.AI_AsyncDblBufferMode(cardID, false); //Disable Double Buffer
        n = 2;

        log[3 * n - 2] = Convert.ToString(err);
        log[3 * n - 1] = "AI_AsyncDblBufferMode Done";
        log[3 * n] = "AI_AsyncDblBufferMode Fail=";

        return log;
    }

    public static UInt16[] qc_AIContRead(UInt16 cardID, UInt16 AI_CH, UInt16 ADCRange, Double ADC_SampRate, UInt32 READCOUNT, int Card_Bit)
    {
        UInt16[] TEST = new UInt16[READCOUNT];
          
                int err = DASK.AI_ContReadChannel(cardID, AI_CH, ADCGAIN(ADCRange), TEST, READCOUNT, ADC_SampRate, 1); //CH
                if (err < 0) throw new Exception("AI_AI_ContReadChannel Error = " + err);  //由系統通知錯誤的視窗

                //------Create Data Value-------------------------------------------------*	
                for (int j = 0; j < READCOUNT; j++)
                {
                    switch (Card_Bit)
                    {
                        case DASK.PCI_9111HR:
                            TEST[j] = Convert.ToUInt16(TEST[j] & (0xFFFF)); //9111-HR 
                            break;
                        case DASK.PCI_9112:
                            TEST[j] = Convert.ToUInt16((TEST[j] >> 4) & (0x0FFF)); //9111-HR
                            break;
                    }                
                }
                //----------------------------------------------------------------*

        return TEST;
    }

    public static Int16 qcSYS_NOISE(UInt16 cardID, UInt16 AI_CH, UInt16 ADCRange, Double ADC_SampRate, UInt32 READCOUNT, String File_Name)
    {
        Int16 err = 0;
        UInt16 CH = AI_CH;
        UInt16[] TEST = new UInt16[READCOUNT];
        UInt32 dataa;        

        for (int i = 0; i < ADCRange; i++)  //測試不同Gain
        {
            //printf("\n$[TEST]4.5  AI Group #%d Range #%d ADC_SampRate #%0.0f System Noise Check ... ", Group, ADCGAIN[i], ADC_SampRate);
            for (CH = 0; CH < AI_CH; CH++)
            {
                //sprintf(File_Name, "SYSNO_SKY_%d_%d_G%d_CH%d.txt", test_date1, test_date2, i, CH);                
                //err = DASK.AI_ContReadChannel(cardID, CH, ADCGAIN(i), TEST, READCOUNT, ADC_SampRate, 1); //CH

                TEST = SKY_FUN_QC.qc_AIContRead(cardID, AI_CH, ADCRange, ADC_SampRate, READCOUNT, DASK.PCI_9111HR); //抓取資料並轉換完畢

                //------Create Save File-------------------------------------------------*
                File_Name = File_Name + "_G" + i + "_CH" + AI_CH + ".txt";  //建立檔案名稱
                String wDate = "\nGroup \t#" + AI_CH + "\tRange \t#" + ADCGAIN(i) + " \tADC_SampRate \t#" + ADC_SampRate;
                SKY_FUN.cFile(File_Name, wDate);

                for (int j = 0; j < AI_CH; j++)
                    SKY_FUN.cFile(File_Name, "CH" + CH);

                //------Create Data Value-------------------------------------------------*	
                for (int j = 0; j < READCOUNT; j++)
                {                    
                    dataa = TEST[j];
                    SKY_FUN.cFile(File_Name, Convert.ToString(dataa));
                }
                //----------------------------------------------------------------*
            }
        }
        if (err < 1) return -1;
        else return 0;
    }

    public static Int16 qcAI_BW(int Fun_Num, UInt16 cardID, UInt16 AI_CH, UInt16 ADCRange, Double ADC_SampRate, UInt32 READCOUNT, String File_Name, int start_freq)
    {
        Int16 err;
        double volt_3db = 0;
        UInt16[] m_data_buffer = new UInt16[READCOUNT]; //資料存放的buffer

        double volt_vpp_base = 9;
        ushort[] m_shift_buffer = new ushort[READCOUNT];
        double[] data_max = new double[READCOUNT];
        double[] data_min = new double[READCOUNT];
        double[] data_vpp = new double[READCOUNT];
        double[] data_3db = new double[READCOUNT];

        byte bStopped = 0;
        uint count = 0;

        for (int AI_RANGE = 0; AI_RANGE < ADCRange; AI_RANGE++)  //測試不同Gain
        {
            File_Name = "AI_BW_G" + AI_RANGE + "_TEST.txt";
            SKY_FUN.cFile(File_Name, "freq\tdata_vpp\tdata_3db\tdata_max\tdata_min"); // 寫入標題文字     
            int freq = start_freq;   //初始化頻率
            do  //重複掃描頻率
            {
                SKY_FUN_GPIB.AFG3022B_Output(Fun_Num, freq, 18 / Math.Pow(2, (AI_RANGE - 1)));   //波形產生器輸出頻率<最大18/2^n>
                err = DASK.AI_ContReadChannel(cardID, AI_CH, ADCGAIN(AI_RANGE), m_data_buffer, READCOUNT, ADC_SampRate, DASK.ASYNCH_OP);
                if (err < 0) throw new Exception("AI_AI_ContReadChannel Error = " + err);  //由系統通知錯誤的視窗

                //---------------double buffer運作-------------------------------------------------*
                do {    //double buffer確認資料是否傳遞完畢
                    err = DASK.AI_AsyncCheck(cardID, out bStopped, out count);
                    if (err < 0) throw new Exception("AI_AsyncCheck Error = " + err);  //由系統通知錯誤的視窗                   
                } while (bStopped == 0);

                err = DASK.AI_AsyncClear(cardID, out count);
                if (err < 0) throw new Exception("AI_AsyncClear Error = " + err);  //由系統通知錯誤的視窗                                                                                 //--------------------------------------------------------------------------------*

                m_shift_buffer = m_data_buffer;
                for (int i = 0; i < m_data_buffer.Length; i++)
                    m_shift_buffer[i] = (ushort)(m_shift_buffer[i] + 0x8000);

                data_max[freq] = m_shift_buffer.Max();
                data_min[freq] = m_shift_buffer.Min();
                data_vpp[freq] = data_max[freq] - data_min[freq];

                if (freq == 1)
                    volt_vpp_base = data_max[freq] - data_min[freq];


                Console.WriteLine("OUTVALUE: {0}", 18 / Math.Pow(2, (AI_RANGE - 1)));

                Console.WriteLine("Gain: {0}", AI_RANGE);

                Console.WriteLine("base vpp: {0}", volt_vpp_base);

                volt_3db = 20 * Math.Log10(data_vpp[freq] / volt_vpp_base);


                Console.WriteLine("Now frequency: {0}.113KHz", freq);
                Console.WriteLine(String.Format("3dB voltage: {0:N3} dB", volt_3db));

                Console.WriteLine("Max Code: {0}", data_max[freq]);
                Console.WriteLine("Min Code: {0}", data_min[freq]);

                SKY_FUN_GPIB.AFG3022B_OFF(Fun_Num);  //停止波形產生器輸出
                
                SKY_FUN.cFile(File_Name, freq + "\t" + data_vpp[freq] + "\t" + volt_3db + "\t" + data_max[freq] + "\t" + data_min[freq]); // 寫入文字 

                freq++;

            } while (volt_3db >= (-4)); //停止條件
        }
        return 0;
    }

}

public class SKY_FUN_GPIB
{

    //#region GPIB function--------------------------------------------------------------------------------//
    private static void gpibClear(int dev)
    {
        int ibsta, iberr, ibcnt, ibcntl;
        GPIB.ibclr(dev);
        GPIB.gpib_get_globals(out ibsta, out iberr, out ibcnt, out ibcntl);
        if ((ibsta & (int)GPIB.ibsta_bits.ERR) != 0)
        {
            throw new Exception("Error in clearing the 33250 device.");
        }
    }

    private static int gpibIni(ushort deviceNum, ushort gpibNum)
    {
        int ibsta, iberr, ibcnt, ibcntl;
        int dev = GPIB.ibdev(deviceNum, gpibNum, 0, (int)GPIB.gpib_timeout.T10s, 1, 0);
        GPIB.gpib_get_globals(out ibsta, out iberr, out ibcnt, out ibcntl);
        if ((ibsta & (int)GPIB.ibsta_bits.ERR) != 0)
        {
            throw new Exception("Error in initializing the GPIB instrument.");  //由系統通知錯誤的視窗
        }

        return dev;
    }

    private static string gpibRead(int dev)
    {
        int ibsta, iberr, ibcnt, ibcntl;
        StringBuilder strRead = new StringBuilder(100);
        GPIB.ibrd(dev, strRead, 100);
        GPIB.gpib_get_globals(out ibsta, out iberr, out ibcnt, out ibcntl);
        if ((ibsta & (int)GPIB.ibsta_bits.ERR) != 0)
        {
            throw new Exception("Error in reading the response string from the GPIB instrument");
        }

        return strRead.ToString();
    }

    private static void gpibWrite(int dev, string strWrite)
    {
        int ibsta, iberr, ibcnt, ibcntl;
        GPIB.ibwrt(dev, strWrite, strWrite.Length);
        GPIB.gpib_get_globals(out ibsta, out iberr, out ibcnt, out ibcntl);
        if ((ibsta & (int)GPIB.ibsta_bits.ERR) != 0)
        {
            throw new Exception("Error in writing the string command to the GPIB instrument (" + strWrite + ")");
        }
    }

    public static void closeDev()
    {
        GPIB.ibonl(0, 0);
        Thread.Sleep(500);
    }
    

    public static short dev7526AOutputDC(ushort deviceNum, ushort gpibNum, double outputValue)
    {
        try
        {
            int dev = gpibIni(deviceNum, gpibNum);

            string strWrite = string.Format("OUT {0}V", outputValue.ToString());
            gpibWrite(dev, strWrite);
            Thread.Sleep(1000);
            strWrite = string.Format("OPER");
            gpibWrite(dev, strWrite);
            Thread.Sleep(1000);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return 0;
    }

    public static double dev34465AMeas(ushort deviceNum, ushort gpibNum)
    {
        double dmmRead = 0;
        string strWrite;
        int devDMM = gpibIni(deviceNum, gpibNum);

        strWrite = string.Format("CONF:VOLT 100");
        gpibWrite(devDMM, strWrite);

        strWrite = string.Format("READ?");
        gpibWrite(devDMM, strWrite); 

        string readMessage = gpibRead(devDMM);
        dmmRead = double.Parse(readMessage.ToString().Trim().Substring(0, readMessage.ToString().IndexOf("\n")));

        return dmmRead;
    }

    public static int ini33250(ushort deviceNum, ushort gpibNum)
    {
        string strWrite;

        int dev33250 = gpibIni(deviceNum, gpibNum);

        gpibClear(dev33250);

        strWrite = "*RST";
        gpibWrite(dev33250, strWrite);

        //strWrite = "OUTP:LOAD Inf";    //HZ mode
        strWrite = "OUTPut1:IMPedance INFinity";    //AFG 3022B HZ Mode
        gpibWrite(dev33250, strWrite);

        Thread.Sleep(100);

        return dev33250;
    }

    public static void dev33250Load_50ohm(ushort deviceNum, ushort gpibNum, bool LoadImped)
    {
        string strWrite = "";
        int dev33250 = gpibIni(deviceNum, gpibNum);
        if (LoadImped == true)
        {
            strWrite = "OUTP:LOAD 50";
        }
        else
        {
            strWrite = "OUTP:LOAD INF";
        }
        gpibWrite(dev33250, strWrite);

    }

    public static short dev33250OutputDC(ushort deviceNum, ushort gpibNum, double voltage)
    {
        int dev33250 = gpibIni(deviceNum, gpibNum);
        string strWrite = "APPL:DC 1HZ, 1VPP, " + voltage + " V";
        gpibWrite(dev33250, strWrite);

        Thread.Sleep(100);

        return 0;
    }

    public static int iniAFG3022B(ushort deviceNum, ushort gpibNum)
    {
        string strWrite;

        int dev33250 = gpibIni(deviceNum, gpibNum);

        gpibClear(dev33250);

        strWrite = "*RST";
        gpibWrite(dev33250, strWrite);

        //strWrite = "OUTP:LOAD Inf";    //HZ mode
        //strWrite = "OUTPut1:IMPedance INFinity";	//AFG 3022B HZ Mode
        strWrite = "OUTPut1:LOAD INFinity"; //AFG 3022B HZ Mode
        gpibWrite(dev33250, strWrite);

        Thread.Sleep(100);

        return dev33250;
    }

    public static short AFG3022B_Output(int dev33250, int freq, double volt)
    {
        //string strWrite = "APPL:DC 1HZ, 1VPP, " + voltage + " V";
        //gpibWrite(dev33250, strWrite);

        string strWrite = "SOURce1:VOLTage:LEVel:IMMediate:AMPLitude " + volt + "VPP";  //設定輸出電壓位準	//volt=9
        gpibWrite(dev33250, strWrite);

        strWrite = "SOURce1:FREQuency:FIXed " + freq + ".113kHz";   //設定輸出頻率
        gpibWrite(dev33250, strWrite);

        strWrite = "OUTPUT1:STATE ON "; //設定輸出開啟
        gpibWrite(dev33250, strWrite);


        Thread.Sleep(100);


        return 0;
    }

    public static short AFG3022B_OFF(int dev33250)
    {

        string strWrite = "OUTPUT1:STATE OFF "; //設定輸出關閉
        gpibWrite(dev33250, strWrite);

        return 0;
    }



}