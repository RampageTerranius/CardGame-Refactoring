using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public abstract class Controller
    {
        protected const int TOTAL_ALLOWED_PLAYERS = 4;

        protected Player[] player;

        private NetworkAdapter ntAdapter;
        private Model model;

        public abstract void receiveCMD(String CMD);

        public Model Model
        {
            get
            { return model; }

            set
            { model = value; }
        }

        public NetworkAdapter NtAdapter
        {
            get { return ntAdapter; }
            set { ntAdapter = value; }
        }

        public Controller()
        {
            model = null;
        }
    }
}