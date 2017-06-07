using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Shared
{
    public abstract class NetworkAdapter
    {
        protected class StateObject
        {
            // Client socket.  
            public Socket workSocket = null;
            // Size of receive buffer.  
            public const int BufferSize = 256;
            // Receive buffer.  
            public byte[] buffer = new byte[BufferSize];
            // Received data string.  
            public StringBuilder sb = new StringBuilder();
        }
            
        //if the networking thread has been paused or not
        protected bool paused = false;
        //if the network adapter has been started
        protected bool running = false;

        //thread stopper for pausing
        public ManualResetEvent pauser = new ManualResetEvent(false);

        //properties
        public bool isPaused { get { return paused; } }
        public bool isRunning { get { return running; } }
         
        //abstract methods  
        public abstract void Start();
        public abstract void Stop();
        public void Pause()
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

        public void Send(Socket handler, String data)
        {
            if (handler != null)
            {
                // Convert the string data to byte data using ASCII encoding.  
                byte[] byteData = Encoding.ASCII.GetBytes(data);

                // Begin sending the data to the remote device.  
                handler.BeginSend(byteData, 0, byteData.Length, 0,
                    new AsyncCallback(SendCallback), handler);

                Console.WriteLine("Data sent: " + data);
            }
            else
                Console.WriteLine("Null socket");

        }

        private void SendCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the socket from the state object.  
                Socket handler = (Socket)ar.AsyncState;

                // Complete sending the data to the remote device.  
                int bytesSent = handler.EndSend(ar);
                Console.WriteLine("Sent {0} bytes.", bytesSent);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
