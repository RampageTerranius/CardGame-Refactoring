//Stores all the data to do with game state and the like 

namespace CardGame_Refactoring
{
    public class Model
    {
        Viewer view;
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