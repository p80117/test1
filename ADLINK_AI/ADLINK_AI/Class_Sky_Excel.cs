
using System.Runtime.InteropServices;
using System.Collections.Generic;


using System;
using System.Text;
using System.IO;
using System.Threading;
using System.Linq;  //判斷陣列中的最大最小值
using Excel = Microsoft.Office.Interop.Excel;   // 切記要使用Excel Library
using System.Globalization;


public class Sky_Function
{  
    public static int GetWeekOfYear(DateTime dt)
{
        /// 取得某一日期在當年的第幾週/// 
        /// 日期
        /// 該日期在當年中的週數
        GregorianCalendar gc = new GregorianCalendar();
    return gc.GetWeekOfYear(dt, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
}
}


public class Sky_Excel
{ 
        const string PASSWORD = "12345";      // 設置的密碼
        static string tbInfo;

    //宣告名稱
    static Excel.Workbook wBook;
    static Excel.Worksheet wSheet;
    static Excel.Range wRange;
    static Excel.Application excelApp;   
        

    public static void excel_open(string filePath)
    {
        // 儲存的Excel檔案路徑與檔案名稱
        //filePath = System.IO.Directory.GetCurrentDirectory() + "/" + "第一個Excel檔案";

        excelApp = new Excel.Application();

        // 嘗試打開已經存在的workbook
        try
        {
            excelApp.Application.Workbooks.Open(filePath, Type.Missing, Type.Missing, Type.Missing, PASSWORD);
            tbInfo = tbInfo + "Excel檔案已存在，讀入Excel檔案!\r\n";
        }
        catch (Exception ex)    //若檔案不存在則加入新的workbook
        {
            excelApp.Workbooks.Add(Type.Missing);
            tbInfo = tbInfo + "新建立Excel檔案!\r\n";
        }
        /*****設定Excel檔案的屬性*****/
        // 讓Excel文件不可見 (不會顯示Application, 在背景工作)
        excelApp.Visible = true;// false;
        
        // 停用警告訊息
        excelApp.DisplayAlerts = false;

        // 取用第一個workbook
        wBook = excelApp.Workbooks[1];

        // 設定活頁簿焦點
        wBook.Activate();

        // 設定子頁焦點
        wSheet = wBook.Worksheets.Item[1];  //選擇第幾個子頁
        wSheet.Activate();
        /*
            // 設定密碼
            //wBook.Password = PASSWORD;

            try
            {
                int sheetNum = wBook.Worksheets.Count;
            tbInfo = tbInfo + string.Format(" 第{0}個Sheet\r\n", sheetNum);
            // 新增worksheet
            wSheet = (Excel.Worksheet) wBook.Worksheets.Add();

            // 設定worksheet的名稱
            wSheet.Name = string.Format("My Sheet {0}", sheetNum);

            // 設定工作表焦點
            wSheet.Activate();

            // 設定第1列資料 (從1開始，不是從0)
            excelApp.Cells[1, 1] = "序號";
            excelApp.Cells[1, 2] = "名稱";

            // 設定第Cell[1, 1]至Cell[1,2]顏色 (兩個Cell間形成的矩形都會被設置)
            wRange = wSheet.Range[wSheet.Cells[1, 1], wSheet.Cells[1, 2]];
            wRange.Select();
            //wRange.Font.Color = ColorTranslator.ToOle(System.Drawing.Color.White);
            //wRange.Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.DimGray);

            // 自動調整欄寬
            wRange = wSheet.Range[wSheet.Cells[1, 1], wSheet.Cells[1, 2]];
            wRange.Select();
            wRange.Columns.AutoFit();
            
            
            catch (Exception ex)
            {
                tbInfo = tbInfo + "生成時產生錯誤!\r\n";
            }

        */
    }

    public static void excel_save(string filePath)
    {
        
        try
        {
            // 儲存workbook
            wBook.SaveAs(filePath, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Excel.XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            tbInfo = tbInfo + "成功儲存!\r\n";
        }
        catch (Exception ex)
        {
            tbInfo = tbInfo + "儲存失敗，請關閉該Excel檔案\r\n";
        }

    }


    public static void excel_close()
    {             
            //關閉workbook
            wBook.Close(false, Type.Missing, Type.Missing);
            
            //關閉Excel
            excelApp.Quit();

            //釋放Excel資源
            System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
            wBook = null;
            wSheet = null;
            wRange = null;
            excelApp = null;
            GC.Collect();
        
    }

    public static void excel_value(int start_row, int start_col, string value)
    {
        excelApp.Cells[start_row, start_col] = value;
    }
    public static void excel_value(string value)
    {
        excelApp.Cells[1, 1] = value;
    }

    public static int excel_last_row(int start_row, int start_col)
    {
        int lastRow;       

        //wSheet = wBook.Worksheets.Item[1];   //選擇子頁        
        lastRow  = wSheet.Cells[start_row, start_col].End(Excel.XlDirection.xlDown).Row;



        string Next_Value = excel_value_read(start_row + 1, start_col);

        if ((lastRow == 1048576) || (Next_Value==""))
        {
            lastRow = start_row;
        }

        return lastRow;
    }

    public static int excel_last_row(string sheet_Name, int start_row, int start_col)
    {
        int lastRow;

        excel_sheet_select(sheet_Name);   //選擇子頁        
        lastRow = wSheet.Cells[start_row, start_col].End(Excel.XlDirection.xlDown).Row;



        string Next_Value = excel_value_read(start_row + 1, start_col);

        if ((lastRow == 1048576) || (Next_Value == ""))
        {
            lastRow = start_row;
        }

        return lastRow;
    }
    public static int excel_last_row(Excel.Worksheet excel_sheet, int start_row, int start_col)
    {
        int lastRow;
        
        //wSheet = wBook.Worksheets.Item[1];   //選擇子頁        
        lastRow = excel_sheet.Cells[start_row, start_col].End(Excel.XlDirection.xlDown).Row;
        Excel.Range excel_Range;
        excel_Range = excel_sheet.Cells[start_row + 1, start_col];
        if ((excel_Range.Text == "") && (start_row==1))
            lastRow = 2;

        return lastRow;
    }
    public static int excel_lastnc_row(Excel.Worksheet excel_sheet, int start_row, int start_col)
    {
        int lastRow;
        
        //wSheet = wBook.Worksheets.Item[1];   //選擇子頁        
        lastRow = excel_sheet.Cells[start_row, start_col].End(Excel.XlDirection.xlDown).Row;

        lastRow = lastRow + 1;
        Excel.Range excel_Range;
        excel_Range = excel_sheet.Cells[start_row + 1, start_col];
        if ((excel_Range.Text == "") && (start_row==1))
            lastRow = 2;

        return lastRow;
    }
    

    public static void excel_sheet_select(int sheet_index)  //起始為1
    { 
        wSheet = wBook.Worksheets.Item[sheet_index];
        wSheet.Activate();
    }
    public static void excel_sheet_select(string sheet_name)
    {
        wSheet = wBook.Worksheets.Item[sheet_name];
        wSheet.Activate();
    }

    public static string[] excel_value2Array(int start_row, int start_col)  //將一排資料轉換成陣列
    {
        int Date_count = Sky_Excel.excel_last_row(start_row, start_col) - start_row + 1;

        string[] Date_value = new string[Date_count];

        for (int i = 0; i < Date_count; i++)
            Date_value[i] = excelApp.Cells[start_row + i, start_col].Value.ToString();
        
        return Date_value;
    }

    public static string[] excel_value2Array(int[] start_cells)  //將一排資料轉換成陣列
    {
        int start_row = start_cells[0];
        int start_col = start_cells[1];

        int Date_count = Sky_Excel.excel_last_row(start_row, start_col) - start_row + 1;

        string[] Date_value = new string[Date_count];

        for (int i = 0; i < Date_count; i++)
            Date_value[i] = excel_value_read(start_row + i, start_col);

        return Date_value;
    }

    public static string excel_value_read(int start_row, int start_col) //讀取欄位資料
    {
        string cell_value;
        

        /*
        if (string.IsNullOrEmpty(cell_value = excelApp.Cells[start_row, start_col].Value2))
        {
            cell_value = "";
        }
        else
        {
            cell_value = excelApp.Cells[start_row, start_col].Value.ToString();
                        
        }
         */
        if (excelApp.Cells[start_row, start_col].Value2 == null)
        {
            cell_value = "";
        }
        else
        {
            cell_value = excelApp.Cells[start_row, start_col].Value.ToString();

        }

         

        return cell_value;

    }
    

    public static int[] excel_find(string sheet_index, string value)    //找出資料所在欄位
    {
        Sky_Excel.excel_sheet_select(sheet_index);

        int[] cells_range = new int[2];
        //int cells_range;
         Excel.Range fRange;

         fRange = wSheet.Cells.Find(value, /* What */
     Type.Missing, /* After */
     Excel.XlFindLookIn.xlValues, /* LookIn */
     Excel.XlLookAt.xlWhole, /* LookAt 模糊搜尋還是完全比對*/
     Excel.XlSearchOrder.xlByRows, /* SearchOrder */
     Excel.XlSearchDirection.xlNext, /* SearchDirection */
     Type.Missing, /* MatchCase */
     Type.Missing, /* MatchByte */
     Type.Missing /* SearchFormat */
     );        

        cells_range = new int[] {fRange.Row, fRange.Column};

        //cells_range = fRange.Row;

        return cells_range;
    }

    public static int[] excel_find(string sheet_index, string value, int all_col)    //找出資料所在欄位
    {
        Sky_Excel.excel_sheet_select(sheet_index);    //設定執行子頁
        //wSheet = wBook.Worksheets.Item[sheet_index];    //設定執行子頁
        
        int[] cells_range = new int[2];
        //int cells_range;
        Excel.Range fRange = wSheet.Columns[all_col];

        Excel.Range resultRange = fRange.Find(value, /* What */
    Type.Missing, /* After */
    Excel.XlFindLookIn.xlValues, /* LookIn */
    Excel.XlLookAt.xlWhole, /* LookAt 模糊搜尋還是完全比對*/
    Excel.XlSearchOrder.xlByRows, /* SearchOrder */
    Excel.XlSearchDirection.xlNext, /* SearchDirection */
    Type.Missing, /* MatchCase */
    Type.Missing, /* MatchByte */
    Type.Missing /* SearchFormat */
    );

        cells_range = new int[] { resultRange.Row, resultRange.Column };

        //cells_range = fRange.Row;

        return cells_range;
    }

    public static int[] excel_find(string value)    //找出資料所在欄位
    {
        int[] cells_range = new int[2];
        //int cells_range;
         Excel.Range fRange;

         fRange = wSheet.Cells.Find(value, /* What */
     Type.Missing, /* After */
     Excel.XlFindLookIn.xlValues, /* LookIn */
     Excel.XlLookAt.xlWhole, /* LookAt 模糊搜尋還是完全比對*/
     Excel.XlSearchOrder.xlByRows, /* SearchOrder */
     Excel.XlSearchDirection.xlNext, /* SearchDirection */
     Type.Missing, /* MatchCase */
     Type.Missing, /* MatchByte */
     Type.Missing /* SearchFormat */
     );        

        cells_range = new int[] {fRange.Row, fRange.Column};

        //cells_range = fRange.Row;

        return cells_range;
    }

    public static int[] excel_find(string value, int Find_LookAt, int Find_All_Column)    //找出資料所在欄位
    {
        int[] cells_range = new int[2];
        //int cells_range;
        

        Excel.Range fRange = wSheet.Columns[Find_All_Column];

        Excel.Range resultRange = fRange.Find(value, /* What */

        //rRange = wSheet.Cells.Find(value, /* What */
    Type.Missing, /* After */
    Excel.XlFindLookIn.xlValues, /* LookIn */
    Find_LookAt,
    /* LookAt 模糊搜尋還是完全比對*/
    //Excel.XlLookAt.xlWhole, 1完全比對
    //Excel.XlLookAt.xlPart,    2模糊
    Excel.XlSearchOrder.xlByRows, /* SearchOrder */
    Excel.XlSearchDirection.xlNext, /* SearchDirection */
    Type.Missing, /* MatchCase */
    Type.Missing, /* MatchByte */
    Type.Missing /* SearchFormat */
    );

        cells_range = new int[] { resultRange.Row, resultRange.Column };

        //cells_range = fRange.Row;

        return cells_range;
    }




    public static string[] excel_sheet_name_array()
    {
        int sheet_count = wBook.Worksheets.Count;
        string [] sheet_name = new string [sheet_count];
        for (int i = 0; i < sheet_count; i++)
        {
            wSheet = wBook.Worksheets.Item[i+1];
            sheet_name[i] = wSheet.Name;
        }
            return sheet_name;
    }

    public static string excel_create(string File_path, string file_name)
    {
        // 儲存的Excel檔案路徑與檔案名稱
        string filePath = System.IO.Directory.GetCurrentDirectory() + "/" +  file_name;
        
        //宣告名稱
        string tbInfo;
               
        excelApp = new Excel.Application();

        // 嘗試打開已經存在的workbook
        try
        {
            excelApp.Application.Workbooks.Open(filePath, Type.Missing, Type.Missing, Type.Missing, PASSWORD);
            tbInfo = "Excel檔案已存在，讀入Excel檔案!";
        }
        catch (Exception ex)    //若檔案不存在則加入新的workbook
        {
            excelApp.Workbooks.Add(Type.Missing);
            tbInfo = "新建立Excel檔案!";
        }
        /*****設定Excel檔案的屬性*****/

        // 讓Excel文件不可見 (不會顯示Application, 在背景工作)
        excelApp.Visible = false;

        // 停用警告訊息
        excelApp.DisplayAlerts = false;

        // 取用第一個workbook
        wBook = excelApp.Workbooks[1];

        // 設定活頁簿焦點
        wBook.Activate();

        // 設定密碼
        //wBook.Password = PASSWORD;

        try
        {
            // 儲存workbook
            wBook.SaveAs(filePath, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Excel.XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            //tbInfo.Text = tbInfo.Text + "成功儲存!\r\n";
        }
        catch (Exception ex)
        {
            //tbInfo.Text = tbInfo.Text + "儲存失敗，請關閉該Excel檔案\r\n";
        }        

        //關閉workbook
        wBook.Close(false, Type.Missing, Type.Missing);

        //關閉Excel
        excelApp.Quit();

        //釋放Excel資源
        System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
        wBook = null;
        wSheet = null;
        wRange = null;
        excelApp = null;
        GC.Collect();  

        return tbInfo;
    }

    public static string excel_create(string file_name)
    {
        // 儲存的Excel檔案路徑與檔案名稱
        string filePath = System.IO.Directory.GetCurrentDirectory() + "/" + file_name;

        //宣告名稱
        string tbInfo;

        excelApp = new Excel.Application();

        // 嘗試打開已經存在的workbook
        try
        {
            excelApp.Application.Workbooks.Open(filePath, Type.Missing, Type.Missing, Type.Missing, PASSWORD);

            //關閉Excel
            excelApp.Quit();

            //釋放Excel資源
            System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
            excelApp = null;

            tbInfo = "Excel檔案已存在，讀入Excel檔案!";
        }
        catch (Exception ex)    //若檔案不存在則加入新的workbook
        {
            excelApp.Workbooks.Add(Type.Missing);

            /*****設定Excel檔案的屬性*****/

            // 讓Excel文件不可見 (不會顯示Application, 在背景工作)
            excelApp.Visible = false;

            // 停用警告訊息
            //excelApp.DisplayAlerts = false;

            // 取用第一個workbook
            wBook = excelApp.Workbooks[1];

            // 設定活頁簿焦點
            //wBook.Activate();

            // 設定密碼
            //wBook.Password = PASSWORD;

            wBook.SaveAs(filePath, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Excel.XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            tbInfo = "新建立Excel檔案!";
            Sky_Excel.excel_close(); 
        }
                
         
    
        return tbInfo;
    }

    public static void excel_sheet_add(string sheet_name)
    {        
        wSheet = wBook.Worksheets.Add();
        // 設定worksheet的名稱
        wSheet.Name = sheet_name;
    }
    public static void txtToexcel(string excel_file_path, string txt_file_path, string sheet_name)
    {
        Sky_Excel.excel_open(excel_file_path);  //開啟excel

        // 讓Excel文件不可見 (不會顯示Application, 在背景工作)
        excelApp.Visible = false;

        Sky_Excel.excel_sheet_add(sheet_name);
        //Sky_Excel.excel_sheet_select(1);    //選擇子頁1

        //宣告參數
        //sheet_name = "newData";  //匯入txt子頁名稱

        //wSheet.Name = sheet_name;

        //  Range("A1").Select

        string File_Name_Loop = "TEXT;" + txt_file_path;
        /*
        wSheet.QueryTables.Add(File_Name_Loop, wSheet.Cells[1,1]);


        StreamReader str = new StreamReader(txt_file_path);                    
                
        str.read
                str.ReadToEnd();

                str.Close();
        */
        // 建立檔案串流（@ 可取消跳脫字元 escape sequence）
        int i = 1;
StreamReader sr = new StreamReader(txt_file_path);
while (!sr.EndOfStream) {				// 每次讀取一行，直到檔尾
	string line = sr.ReadLine();			// 讀取文字到 line 變數
    wSheet.Cells[i,1] = line;
    i++;
}
sr.Close();        
        Sky_Excel.excel_save(excel_file_path);
        Sky_Excel.excel_close();           

    }

    public static void AI_Systemnoise_Excel(string excel_file_path, int ADC_Bit, int twosCoding)
    {
        excel_open(excel_file_path);    //打開檔案

        // 讓Excel文件不可見 (不會顯示Application, 在背景工作)
        //excelApp.Visible = false;

        excel_sheet_select(1);  //選擇子頁
        string Data_Sheet_Name = wSheet.Name;
        //wSheet.Rows[1].Delete();

        int last_row = excel_last_row(4, 1);    //確認資料最後一欄
        { 
        /*
        wSheet.Cells[1, 1] = "Card";
        wSheet.Cells[1, 2] = "TestDate";
        wSheet.Cells[1, 3] = "Group";
        wSheet.Cells[1, 4] = "Range";
        wSheet.Cells[1, 5] = "ADC_SampRate";
        //wSheet.Cells[1, 5] = "AZMODE";
        wSheet.Cells[1, 6] = "Channel";
        wSheet.Cells[1, 7] = "CH_ST";
        wSheet.Cells[1, 8] = "CH_AV";
        */

    }
        //---------------------資料標題資訊-------------------------------------------------------//


        int[] CH_CELL = new int[2]; //找出通道所在欄位
        CH_CELL = excel_find("CH", 2, 1);

        //wSheet.Cells[1,10]
        //wSheet.Cells[1, 9] = "Group";
        //wSheet.Cells[1, 10] = "Group";  //資料位置

        wRange = wSheet.Cells[CH_CELL[0] - 1, 1];    //選擇資訊位置
                                                     //Array value = (Array)wRange.Value2;
                                                     //wRange.Text       



        //---------------------拆解資訊-------------------------------------------------------//
        //string phrase = wSheet.Cells[2, 1].TEXT;

        string phrase = wRange.Text;
        //string[] words = phrase.Split(' ');    //拆解"\"
        string[] words = phrase.Split(new char[] { ' ', '\t' }, options: StringSplitOptions.RemoveEmptyEntries);    //拆解"\"

        int Row_data_Cell = (words.Count() / 2) + 5;    //8
        wSheet.Range[wSheet.Cells[CH_CELL[0] + 1, 1], wSheet.Cells[last_row, 1]].Cut(wSheet.Cells[1, Row_data_Cell]);  //將RowData放置空白處


        int Data_Title_Count = 1;
        for (int i = 0; i < words.Count(); i = i + 2, Data_Title_Count++)
        {
            wSheet.Cells[1, Data_Title_Count] = words[i];  //標題
            wSheet.Cells[2, Data_Title_Count] = words[i + 1];    //資料
        }

        { 

        /*
        wSheet.Cells[2, 1] = "";
        wSheet.Cells[2, 2] = words[1].Substring(1,3);  //Group
        wSheet.Cells[2, 3] = words[2];  //Range
        wSheet.Cells[2, 4] = words[4];  //ADC Sample Rate
        */
        /*
        wSheet.Cells[2, 1] = words[1];  //SN
        wSheet.Cells[2, 2] = words[3];  //TestDate
        wSheet.Cells[2, 3] = words[5];  //Group
        wSheet.Cells[2, 4] = words[7];  //Range
        wSheet.Cells[2, 5] = words[9];  //ADC Sample Rate
        */
    }
        wSheet.Cells[1, Data_Title_Count] = "Channel";
        wRange = wSheet.Cells[CH_CELL[0], 1];    //Channel information
        phrase = wRange.Text;
        wSheet.Cells[2, Data_Title_Count++] = phrase.Substring(2, 1);
        //wSheet.Cells[3,1] = "";清除
        //for (int i = 0; i < words.Length; i++ )
        //    wSheet.Cells[2, i+1] = words[i];
        //----------------------------------------------------------------------------------//

        //-----------------加入公式---------------------------------------------------------//

        wSheet.Cells[1, Data_Title_Count] = "CH_ST";
        last_row = excel_last_row(1, Row_data_Cell) - 2;    //確認資料最後一欄
        wRange = wSheet.Cells[2, Data_Title_Count++];  //標準差
        wRange.Formula = "=STDEVPA(R[-1]C[3]:R[" + last_row + "]C[3])";

        wSheet.Cells[1, Data_Title_Count] = "CH_AV";
        wRange = wSheet.Cells[2, Data_Title_Count++];  //平均值
        wRange.Formula = "=AVERAGE(R[-1]C[2]:R[" + last_row + "]C[2])";

        //----------------------------------------------------------------------------------//

        //-----------------資料補償---------------------------------------------------------//

        int AI_CH = 1;
        double Data_Conv_ADCAdd;    //欄位資料
        last_row = excel_last_row(1, Row_data_Cell);    //確認資料最後一欄

        //wSheet.Cells[4, 1] = ADC_Bit;
        //wSheet.Cells[5, 1] = twosCoding;

        if (twosCoding == 1)
        {
            double FullBit = Math.Pow(2, ADC_Bit);

            //wSheet.Cells[1, 13] = FullBit;

            for (int i = 1; i <= AI_CH; i++)
            {
                for (int j = 1; j <= last_row; j++)
                {
                    wRange = wSheet.Cells[j, i + Row_data_Cell-1];
                    Data_Conv_ADCAdd = wRange.Value;
                    if (Data_Conv_ADCAdd > (FullBit / 2))
                        wRange.Value = Data_Conv_ADCAdd - FullBit;
                }
            }
        }
        //----------------------------------------------------------------------------------//


        //----------------------------主分析頁----------------------------------------------//
        string sheet_name = "Analysis";
        Excel.Worksheet main_sheet; //主分析頁

        // wSheet //資料頁
        try
        {
            main_sheet = wBook.Worksheets.Item[sheet_name];
        }
        catch
        {
            // 新增worksheet
            main_sheet = (Excel.Worksheet)wBook.Worksheets.Add();
            // 設定worksheet的名稱
            main_sheet.Name = string.Format(sheet_name);
            // 設定工作表焦點
            main_sheet.Activate();
        }


            //設定標題及資料

            int main_last_row = excel_lastnc_row(main_sheet, 1, 2); //取得分析頁面最後一行
            wRange = wSheet.Cells[2, 1];

        for (int i = Data_Title_Count; i > 0; i--)
        {
            main_sheet.Cells[1, i] = wSheet.Cells[1, i];  //標題;
            main_sheet.Cells[main_last_row, i] = wSheet.Cells[2, i];  //資料;

            { 
            /*
             * main_sheet.Cells[1, 1] = "SN";
            main_sheet.Cells[1, 2] = "TestDate";
            main_sheet.Cells[1, 3] = "Group";
            main_sheet.Cells[1, 4] = "Range";
            main_sheet.Cells[1, 5] = "ADC_SampRate";
            //main_sheet.Cells[1, 6] = "AZMODE";
            main_sheet.Cells[1, 6] = "Channel";
            main_sheet.Cells[1, 7] = "CH_ST";
            main_sheet.Cells[1, 8] = "CH_AV";


            main_sheet.Cells[1, 9] = "Vrms(noise)";
            main_sheet.Cells[1, 10] = "SNR";
            main_sheet.Cells[1, 11] = "ENOB";
            main_sheet.Cells[1, 12] = "VPP";

            */
        }
            }


        {
            //Array value = (Array)wRange.Value2;
            //wRange.Text


            //---------------------拆解資訊-------------------------------------------------------//

            //wRange = wSheet.Cells[2, 2];
            /*
            main_sheet.Cells[main_last_row, 2] = wSheet.Cells[2, 2];  //Group
            main_sheet.Cells[main_last_row, 3] = wSheet.Cells[2, 3];  //Range
            main_sheet.Cells[main_last_row, 4] = wSheet.Cells[2, 4];  //ADC Sample Rate
            main_sheet.Cells[main_last_row, 6] = wSheet.Cells[2, 6];  //Channel

            main_sheet.Cells[main_last_row, 7] = wSheet.Cells[2, 7];  //標準差
            main_sheet.Cells[main_last_row, 8] = wSheet.Cells[2, 8];  //平均值
            */



        }
        

        main_sheet.Cells[1, Data_Title_Count] = "Vrms(noise)";
        wRange = main_sheet.Cells[main_last_row, Data_Title_Count++];  //Vrms(noise)
        wRange.Formula = "=R[0]C[-2]*2*R[0]C[3]/(2^" + ADC_Bit + ")";

        main_sheet.Cells[1, Data_Title_Count] = "SNR";
        wRange = main_sheet.Cells[main_last_row, Data_Title_Count++];  //SNR
        wRange.Formula = "=20*LOG((R[0]C[2]/SQRT(2))/R[0]C[-1])";

        main_sheet.Cells[1, Data_Title_Count] = "ENOB";
        wRange = main_sheet.Cells[main_last_row, Data_Title_Count++];  //ENOB
        wRange.Formula = "=(R[0]C[-1]-1.76)/6.02";

        main_sheet.Cells[1, Data_Title_Count] = "VPP";

        CH_CELL = excel_find(Data_Sheet_Name, "Range");

        //excel_sheet_select(1);

        //int sadas = CH_CELL[1];

        //string aaa = wSheet.Cells[2, sadas].Text;


        //string[] vRANGE = words[2].Split('#');    //拆解"\"

        string[] vRANGE = wSheet.Cells[2, CH_CELL[1]].Text.Split('#');    //拆解"\"
        Double out_VP;
        SKY_FUN_QC.ADCGAIN(Convert.ToInt32(vRANGE[1]), out out_VP);
        main_sheet.Cells[main_last_row, Data_Title_Count++] = out_VP;

        //----------------------------------------------------------------------------------//


        wSheet.Delete();
        main_sheet = null;



        //----完成存檔關閉--//
        Sky_Excel.excel_save(excel_file_path);
        Sky_Excel.excel_close();
        //----完成存檔關閉--//

    }
    

}

