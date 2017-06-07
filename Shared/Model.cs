using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public abstract class Model
    {
        protected Controller controller;
        protected Deck deck;
        public Player player;

        public string[,] cmdLog;//0 is commands sent, 1 is commands received
        
        public Deck CardDeck
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
            cmdLog = new string[2, 10];
            player = new Player();
            controller = null;
            deck = new Shared.Deck();
            deck.ResetDeck();
            deck.CreateDeck();
            deck.Shuffle();
            deck.Shuffle();
            deck.Shuffle();
            deck.Shuffle();
            deck.Shuffle();
        }
    }
}
