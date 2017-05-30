//controls all the data to do with game state and the like
using Shared;

namespace Client
{
    public class ClientController : Controller
    {
        private Player[] player;
        private int totalPlayers;
        public NetworkAdapterClient networkAdapter;

        public ClientController ()
        {
            player = new Player[TOTAL_ALLOWED_PLAYERS];
            totalPlayers = 0;
            networkAdapter = new NetworkAdapterClient(this);
        }
    }
}