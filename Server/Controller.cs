//controls all the data to do with game state and the like
using Shared;

namespace Server
{
    public class ServerController : Controller
    {
        private Deck deck;
        private Player[] player;
        private int currentPlayers;
        public NetworkAdapterServer networkAdapter;

        public ServerController()
        {
            networkAdapter = new NetworkAdapterServer();
            deck = new Deck();
            currentPlayers = 0;
            player = new Player[TOTAL_ALLOWED_PLAYERS];
        }
    }
}