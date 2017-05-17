//controls all the data to do with game state and the like

namespace CardGame_Refactoring
{
    public class Controller
    {
        Model model;
        NetworkAdapter networkAdapter;

        public Model Model
        {
            get
            {
                return model;
            }

            set
            {
                model = value;
            }
        }
        public Controller ()
        {
            networkAdapter = new NetworkAdapter();

        }
    }
}