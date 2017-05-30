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
            Viewer v = new Viewer();
            ClientController c = new ClientController();

            m.View = v;
            v.Controller = c;
            c.Model = m;

            c.networkAdapter.Start();


            Application.Run(v);
        }
    }
}
