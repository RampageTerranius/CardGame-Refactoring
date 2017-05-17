//Stores all the data to do with game state and the like 
using Shared;

namespace CardGame_Refactoring
{
    public class Model
    {
        Viewer view;
        Deck deck;

        public Viewer View
        {
            get
            {
                return view;
            }

            set
            {
                view = value;
            }
        }
    }
}