using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CardGame_Refactoring
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
            Model m = new Model();
            Viewer v = new Viewer();
            Controller c = new Controller();

            m.View = v;
            v.Controller = c;
            c.Model = m;


            Application.Run(v);
        }
    }
}
