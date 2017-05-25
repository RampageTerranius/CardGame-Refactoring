using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public abstract class Model
    {
        Controller controller;
        Deck deck;
        public Deck Deck
        {
            get { return deck; }
            set { deck = value; }
        }

        public Controller Controller
        {
            get { return controller; }
            set { controller = value; }
        }

        public Model ()
        {
            controller = null;
            deck = null;            
        }
    }
}
