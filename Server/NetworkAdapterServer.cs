﻿using System;
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
        public ManualResetEvent pauser = new ManualResetEvent(false);
        private Controller controller;

        public NetworkAdapterServer(Controller controller)
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
            throw new NotImplementedException();            
        }

        public override void Pause()
        {
            if (paused)
            {
                pauser.Set();
                paused = false;
            }
            else
            {
                pauser.Reset();
                paused = true;
            }
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

                // Create the state object.  
                StateObject state = new StateObject();
                state.workSocket = handler;
                handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                    new AsyncCallback(ReadCallback), state);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }

        public void ReadCallback(IAsyncResult ar)
        {
            String content = String.Empty;

            // Retrieve the state object and the handler socket  
            // from the asynchronous state object.  
            StateObject state = (StateObject)ar.AsyncState;
            Socket handler = state.workSocket;
            int bytesRead = 0;
            try
            {
                // Read data from the client socket.   
                bytesRead = handler.EndReceive(ar);
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: " + e.Message);
                return;
            }

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
                    Console.WriteLine("Read {0} bytes from socket. \n Data : {1}",
                        content.Length, content);
                    // Echo the data back to the client.  
                    Send(handler, content);

                    controller.receiveCMD(content.Substring(0, content.Length - 5));           
                }
                else
                {
                    // Not all data received. Get more.  
                    handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                    new AsyncCallback(ReadCallback), state);
                }
            }
        }
    }
}