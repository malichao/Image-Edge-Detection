using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace 图像边缘检测
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form1 f1 = new Form1();
            f1.ShowDialog();
            if (f1.DialogResult==DialogResult.OK)
                Application.Run(new Form1());
            //Application.Run(f);
        }
    }
}
