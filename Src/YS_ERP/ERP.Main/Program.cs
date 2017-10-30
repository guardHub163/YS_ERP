using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;

namespace CZZD.ERP.Main
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
            FileInfo file = new FileInfo(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log4net.cfg.xml"));
            log4net.Config.XmlConfigurator.Configure(file);
            Application.Run(new FrmLogin());
            //Application.Run(new FrmMain());
        }
    }
}
