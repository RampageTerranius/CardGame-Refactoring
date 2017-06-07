using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Shared;

namespace Client
{
    public class NetworkAdapterClient : NetworkAdapter
    {        

        // The port number for the remote device.  
        private const int port = 11000;

        // The response from the remote device.
        private String response = String.Empty;
        private ClientController controller;

        public NetworkAdapterClient(ClientController controller)
        {
            this.controller = controller;
        }        

        override public void Start()
        {
            // Connect to a remote device.
            try
            {
                // Establish the remote endpoint for the socket.
                // The name of the
                // remote device is "host.contoso.com".
                IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
                IPAddress ipAddress = ipHostInfo.AddressList[0];
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, port);

                // Create a TCP/IP socket.
                Socket client = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                client.BeginConnect(remoteEP, new AsyncCallback(ConnectCallback), client);
                controller.socket = client;                    
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public override void Stop()
        {

        }

        public void Send(string data)
        {
            Send(controller.socket, data);
        }

        private void ConnectCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the socket from the state object.  
                Socket client = (Socket)ar.AsyncState;                

                // Complete the connection.  
                client.EndConnect(ar);
                Receive(client);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private void Receive(Socket client)
        {
            try
            {
                // Create the state object.  
                StateObject state = new StateObject();
                state.workSocket = client;

                // Begin receiving the data from the remote device.  
                client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                    new AsyncCallback(ReceiveCallback), state);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private void ReceiveCallback(IAsyncResult ar)
        {
            //Retrieve the state object and the client socket
            //from the asynchronous state object.
            StateObject state = (StateObject)ar.AsyncState;
            Socket client = state.workSocket;

            try
            {
                //Read data from the remote device.
                int bytesRead = client.EndReceive(ar);

                if (bytesRead < 1)
                {
                    return;
                }

                //There might be more data, so store the data received so far.
                state.sb.Append(Encoding.ASCII.GetString(state.buffer, 0, bytesRead));

                //Check for end-of-file tag. If it's not there, read more data.
                String content = state.sb.ToString();

                if (content.IndexOf("<EOF>") > -1)
                {
                    //All the data has been read from the client. Display it on the console
                    Console.WriteLine("Read {0} bytes from socket. \n Data: {1}", content.Length, content);
                    Console.WriteLine(content);
                    controller.receiveCMD(content.Substring(0, content.Length - 5));
                    state.sb.Clear();
                    //you could store a list of "commands" inside each client object which in your main loop deciphers each command.
                }

                client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(ReceiveCallback), state);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
