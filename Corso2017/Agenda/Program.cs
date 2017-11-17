using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Agenda
{
    static class Program
    {
        const string CONNECTIONSTRING_SETTINGS_NAME = "CorsoDb";
        public static string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings[CONNECTIONSTRING_SETTINGS_NAME].ConnectionString;
            }
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
