using System;

namespace ClientLibrary
{
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