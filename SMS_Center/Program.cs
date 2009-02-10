using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SMS_Center
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (Environment.Version.Major < 2)
            {
                System.Console.WriteLine(".Net(2.x) not installed!");
                return;
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new mainForm());
        }
    }
}