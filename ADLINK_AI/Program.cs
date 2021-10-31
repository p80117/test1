using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADLINK_AI
{
    static class Program
    {


        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            /*
            //新建Login視窗(Login是自己定義的Form)Login Log = new Login();
            Initial_Card Log = new Initial_Card();

            //使用模式對話方塊方法顯示Log Log.ShowDialog();
            Log.ShowDialog();

            //DialogResult就是用來判斷是否返回父窗體的

            if (Log.DialogResult == DialogResult.OK)

            {

                //線上程中開啟主窗體

                Application.Run(new Form1());

            }
            */
            

        }
    }
}
