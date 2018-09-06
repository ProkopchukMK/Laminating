using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Laminatsia
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool mutexCreated;
            using (Mutex mutex = new Mutex(true, "Авторизація", out mutexCreated))
            {
                if (!mutexCreated)
                {
                    MessageBox.Show("Один екземпляр програми вже запущено!", "Програма вже запущена!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Authorization());
            }
        }
    }
}
