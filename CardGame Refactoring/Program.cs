using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
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
            ClientModel m = new ClientModel();
            Connect connect = new Connect();            
            MainWindow v = new MainWindow();
            connect.MainWindow = v;
            ClientController c = new ClientController(v);

            m.View = v;
            v.Controller = c;
            c.Model = m;

            Application.Run(connect);
        }
    }
}
