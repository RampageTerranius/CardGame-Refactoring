using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using Shared;

namespace Server
{
    public class NetworkAdapterServer : NetworkAdapter
    {
        // Thread signal.  
        public ManualResetEvent allDone = new ManualResetEvent(false);
        private ServerController controller;

        public NetworkAdapterServer(ServerController controller)
        {
            this.controller = controller;
        }

        override public void Start()
        {
            // Data buffer for incoming data.  
            byte[] bytes = new Byte[1024];

            // Establish the local endpoint for the socket.  
            // The DNS name of the computer  
            // running the listener is "host.contoso.com".

            IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddress = ipHostInfo.AddressList[0];
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 11000);

            // Create a TCP/IP socket.  
            Socket listener = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            // Bind the socket to the local endpoint and listen for incoming connections.  
            try
            {
                listener.Bind(localEndPoint);
                listener.Listen(100);
                running = true;

                while (true)
                {
                    // Set the event to nonsignaled state.  
                    allDone.Reset();

                    //check if we need to pause the network client
                    if (paused)
                    {
                        Console.WriteLine("Network adapter is paused.");
                        pauser.WaitOne();
                    }


                    // Start an asynchronous socket to listen for connections.  
                    Console.WriteLine("Waiting for a connection...");
                    listener.BeginAccept(
                        new AsyncCallback(AcceptCallback),
                        listener);

                    // Wait until a connection is made before continuing.  
                    allDone.WaitOne();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public override void Stop()
        {

        }

        public void AcceptCallback(IAsyncResult ar)
        {
            try
            {
                // Signal the main thread to continue.  
                allDone.Set();

                // Get the socket that handles the client request.  
                Socket listener = (Socket)ar.AsyncState;
                Socket handler = listener.EndAccept(ar);



                Console.WriteLine("client {0} connected.", handler.RemoteEndPoint.ToString());


                // Create the state object.  
                StateObject state = new StateObject();
                state.workSocket = handler;
                controller.socket = handler;
                handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                    new AsyncCallback(ReadCallback), state);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }

        private void ReadCallback(IAsyncResult ar)
        {
            String content = String.Empty;
            //Retrieve the state object and the handler socket from the asynchronous state object
            StateObject state = (StateObject)ar.AsyncState;
            Socket handler = state.workSocket;

            try
            {
                //Read data from the client socket.
                /*To detect unexpected disconnects
                 *http://stackoverflow.com/questions/11340312/detecting-unexpected-socket-disconnect*/
                int bytesRead = handler.EndReceive(ar);


                //If there are no bytes to receive, return.
                if (bytesRead < 1)
                {
                    return;
                }

                //There might be more data, so store the data received so far.
                state.sb.Append(Encoding.ASCII.GetString(state.buffer, 0, bytesRead));

                //Check for end-of-file tag. If it's not there, read more data.
                content = state.sb.ToString();

                //Console.WriteLine(content);

                if (content.IndexOf("<EOF>") > -1)
                {
                    //All the data has been read from the client. Display it on the console
                    Console.WriteLine("Read {0} bytes from socket. \n Data: {1}", content.Length, content);
                    Console.WriteLine(content);
                    //It's up to you what you do with the message sent, for example if you store a list of clients
                    //you could store a list of "commands" inside each client object which in your main loop deciphers each command.
                    controller.receiveCMD(content.Substring(0, content.Length - 5));
                    state.sb.Clear();
                }

                handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(ReadCallback), state);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        /*
        public void ReadCallback(IAsyncResult ar)
        {
            String content = String.Empty;

            // Retrieve the state object and the handler socket  
            // from the asynchronous state object.  
            StateObject state = (StateObject)ar.AsyncState;
            Socket handler = state.workSocket;
            int bytesRead = 0;
            // Read data from the client socket.   
            bytesRead = handler.EndReceive(ar);            

            if (bytesRead > 0)
            {
                // There  might be more data, so store the data received so far.
                state.sb.Append(Encoding.ASCII.GetString(
                    state.buffer, 0, bytesRead));

                // Check for end-of-file tag. If it is not there, read   
                // more data.  
                content = state.sb.ToString();
                if (content.IndexOf("<EOF>") > -1)
                {
                    // All the data has been read from the   
                    // client. Display it on the console.  
                    Console.WriteLine("Read {0} bytes from socket. \nData : {1}",
                        content.Length, content);

                    controller.receiveCMD(content.Substring(0, content.Length - 5));
                    state.sb.Clear();
                    handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                        new AsyncCallback(ReadCallback), state);
                }
                else
                {
                    // Not all data received. Get more.  
                    handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                    new AsyncCallback(ReadCallback), state);
                }
            }
        }
    */
    }
}

