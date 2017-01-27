using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuitarPracticeLog
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            DialogResult confirmation = MessageBox.Show("By clicking OK, you have agreed to use this program for personal use only and will not share or distribute this program without permission from Ryan Tunis.", "User Agreement", MessageBoxButtons.OKCancel);
            if (confirmation == DialogResult.OK)
                Application.Run(new MainMenu());
            else
                Application.Exit();
        }
    }
}
