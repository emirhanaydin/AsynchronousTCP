using System;

namespace ServerLibrary
{
    public class ClientConnectedEventArgs : EventArgs
    {
        public string Client { get; }

        public ClientConnectedEventArgs(string client)
        {
            Client = client;
        }
    }
}