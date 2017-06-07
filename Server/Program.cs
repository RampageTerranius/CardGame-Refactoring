using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Program
    {
        public static ServerModel m = new ServerModel();
        public static ServerController c = new ServerController();

        static void Main(string[] args)
        {
            c.Model = m;
            m.Controller = c;

            Console.WriteLine("Server starting...");
            StartServer();
            Console.WriteLine("Shutting down...");
        }

        static public void StartServer()
        {
            c.NtAdapter.Start();
        }
    }
}
