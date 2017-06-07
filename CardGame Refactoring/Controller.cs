//controls all the data to do with game state and the like
using System;
using Shared;
using System.Net.Sockets;

namespace Client
{
    public class ClientController : Controller
    {
        public NetworkAdapterClient NtAdapter;
        public Socket socket;
        MainWindow view;

        public ClientController (MainWindow view)
        {
            this.view = view;
            NtAdapter = new NetworkAdapterClient(this);
        }

        override public void receiveCMD(string CMD)
        {
            logCMD(1, CMD);
            CMD = CMD.ToLower();
            string[] cmd = CMD.Split(' ');            
            switch (cmd[0])
            {
                case "draw":
                    Console.WriteLine("Draw command" );
                    string[] split = cmd[1].Split(',');
                    Card card = new Card((Suit)int.Parse(split[0]), (Value)int.Parse(split[1]));
                    Model.player.Draw(card);
                    if (Model.player.GetHandValue() > 21)
                        view.BtnDisable("Bust");
                    view.UpdateScreen();
                    break;

                case "empty":
                    Console.WriteLine("Empty deck command");
                    view.BtnDisable("Empty Deck");
                    view.UpdateScreen();
                    break;

                default:
                    Console.WriteLine("Unknown command: " + CMD);
                    break;
            }
        }
    }
}