//controls all the data to do with game state and the like
using System;
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
            networkAdapter = new NetworkAdapterServer(this);
            deck = new Deck();
            currentPlayers = 0;
            player = new Player[TOTAL_ALLOWED_PLAYERS];
        }

        public override void receiveCMD(string CMD)
        {
            switch(CMD.ToLower())
            {
                case "draw":
                    Console.WriteLine("draw command received");
                    break;

                default:
                    Console.WriteLine("Unknown command: " + CMD);
                    break;
            }
        }
    }
}