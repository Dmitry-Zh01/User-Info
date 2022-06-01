using System;
using System.Windows.Forms;

namespace FormApp;

static class Program
{

    [STAThread]
    static void Main()
    {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
        ApplicationConfiguration.Initialize();
        Application.Run(new Form1());
    }    
}