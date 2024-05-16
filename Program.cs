using System;
using System.Windows.Forms;

namespace LumberjackGame
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1()); // Create and run the main form (Form1)
        }
    }
}
