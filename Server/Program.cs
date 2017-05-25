using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Program
    {
        
        static void Main(string[] args)
        {
            ServerModel m = new ServerModel();
            ServerController c = new ServerController();
            c.Model = m;
            m.Controller = c;

            bool loop = true;
            Console.WriteLine("Server starting...");
            StartServer();   
            Console.WriteLine("Server started.");

            while (loop)
            {
                
                
            }
        }

        static public void StartServer()
        {

        }
    }
}
