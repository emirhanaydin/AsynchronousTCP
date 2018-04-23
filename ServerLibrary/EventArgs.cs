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
    
    public class MessageReceivedEventArgs : EventArgs
    {
        public string Sender { get; }
        public string Message { get; }

        public MessageReceivedEventArgs(string sender, string message)
        {
            Sender = sender;
            Message = message;
        }
    }
}