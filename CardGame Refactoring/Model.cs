//Stores all the data to do with game state and the like 
using Shared;

namespace Client
{
    public class ClientModel : Model
    {
        private MainWindow view;
        public MainWindow View
        {
            get { return view; }
            set { view = value; }
        }

        public ClientModel()
        {
            view = null;
        }
    }
}