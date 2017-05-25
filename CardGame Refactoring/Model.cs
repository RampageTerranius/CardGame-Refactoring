//Stores all the data to do with game state and the like 
using Shared;

namespace Client
{
    public class ClientModel : Model
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