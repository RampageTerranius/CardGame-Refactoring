using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace Shared
{
    public abstract class Controller
    {       
        private Model model;

        public abstract void receiveCMD(String cmd);

        public Model Model
        {
            get
            { return model; }

            set
            { model = value; }
        }

        public Controller()
        {
            model = null;
        }

        public void logCMD(int type, string cmd)
        {
            for (int i = 0; i < 9; i++)
            {
                model.cmdLog[type, i] = model.cmdLog[type, i + 1];
            }

            model.cmdLog[type, 9] = cmd;
        }
    }
}