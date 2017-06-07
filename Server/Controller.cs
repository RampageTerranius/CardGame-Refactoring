//controls all the data to do with game state and the like
using System;
using Shared;
using System.Net.Sockets;

namespace Server
{
    public class ServerController : Controller
    {
        public Socket socket;
        public NetworkAdapterServer NtAdapter;

        public ServerController()
        {
            NtAdapter = new NetworkAdapterServer(this);            
        }

        public override void receiveCMD(string CMD)
        {
            logCMD(1, CMD);
            switch (CMD.ToLower())
            {
                case "draw":
                    Console.WriteLine("draw command received: ");
                    
                    Deck deck = Model.CardDeck;
                    if (deck.CardDeck.GetLength() > 1)
                    {
                        Card card = Model.player.Draw(deck);
                        
                        NtAdapter.Send(socket, "draw " + card.ToString() + "<EOF>");
                        logCMD(0, "draw " + card.ToString() + "<EOF>");
                    }
                    else if (deck.CardDeck.GetLength() == 1)
                    {
                        
                        Card card = Model.player.Draw(deck);
                        NtAdapter.Send(socket, "draw " + card.ToString() + "<EOF>");
                        logCMD(0, "empty<EOF>");
                        Console.WriteLine("last card, sending disable command");
                        NtAdapter.Send(socket, "empty<EOF>");
                        logCMD(0, "empty<EOF>");
                    }
                    break;

                default:
                    Console.WriteLine("Unknown command: " + CMD);
                    break;
            }
        }
    }
}