//controls all the data to do with game state and the like
using System;
using Shared;

namespace Client
{
    public class ClientController : Controller
    {
        
        private int totalPlayers;
        public NetworkAdapterClient networkAdapter;

        public ClientController ()
        {
            player = new Player[TOTAL_ALLOWED_PLAYERS];
            totalPlayers = 0;
            networkAdapter = new NetworkAdapterClient(this);
        }

        override public void receiveCMD(string CMD)
        {
            switch (CMD.ToLower())
            {
                default:
                    Console.WriteLine("Unknown command: " + CMD);
                    break;
            }
        }
    }
}