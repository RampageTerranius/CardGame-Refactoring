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

        NetworkAdapter networkAdapter;
        Model model;

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
    }
}