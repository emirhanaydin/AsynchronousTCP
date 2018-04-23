using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using EventLibrary;

namespace ServerLibrary
{
    public class ServerManager
    {
        private IPAddress _ipAddress;
        private ushort _port;
        private TcpListener _tcpListener;

        public EventHandler<ClientConnectedEventArgs> ClientConnected;
        public EventHandler<MessageReceivedEventArgs> MessageReceived;

        private readonly List<TcpClient> _clients;

        private bool _running;

        public ServerManager()
        {
            _clients = new List<TcpClient>();
        }

        public async void StartListeninFromIncomingConnection(IPAddress ipAddress = null, ushort port = 23000)
        {
            if (ipAddress == null) ipAddress = IPAddress.Any;

            _ipAddress = ipAddress;
            _port = port;

            Debug.WriteLine("IP Address: {0}:{1}", _ipAddress, _port);

            _tcpListener = new TcpListener(_ipAddress, _port);
            _tcpListener.Start();

            _running = true;

            while (_running)
            {
                TcpClient client;
                try
                {
                    client = await _tcpListener.AcceptTcpClientAsync();
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e);
                    break;
                }

                _clients.Add(client);

                Debug.WriteLine("Client connected: {0} (Client count: {1})",
                    client.Client.RemoteEndPoint,
                    _clients.Count);

                ReadFromTcpClient(client);

                ClientConnected?.Invoke(this, new ClientConnectedEventArgs(client.Client.RemoteEndPoint.ToString()));
            }
        }

        private async void ReadFromTcpClient(TcpClient client)
        {
            var reader = new StreamReader(client.GetStream());

            var buff = new char[64];

            while (_running)
            {
                int numRead;

                try
                {
                    numRead = await reader.ReadAsync(buff, 0, buff.Length);
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e);
                    break;
                }

                if (numRead == 0)
                {
                    RemoteClient(client);
                    break;
                }

                var read = new string(buff);
                Debug.WriteLine("{0}: {1} (Length: {2})", client.Client.RemoteEndPoint, read, numRead);

                MessageReceived?.Invoke(this,
                    new MessageReceivedEventArgs(client.Client.RemoteEndPoint.ToString(), read));

                Array.Clear(buff, 0, buff.Length);
            }
        }

        private void RemoteClient(TcpClient client)
        {
            if (!_clients.Contains(client)) return;

            _clients.Remove(client);

            Debug.WriteLine("Client disconnected: {0} (Client count: {1})",
                client.Client.RemoteEndPoint,
                _clients.Count);
        }

        public void SendToAll(string message)
        {
            if (string.IsNullOrEmpty(message)) return;

            var buff = Encoding.ASCII.GetBytes(message);

            _clients.ForEach(client => client.GetStream().WriteAsync(buff, 0, buff.Length));
        }

        public void StopServer()
        {
            try
            {
                _tcpListener?.Stop();
            }
            catch (SocketException e)
            {
                Debug.WriteLine(e);
                return;
            }

            _running = false;

            _clients.ForEach(client => client.Close());

            _clients.Clear();
        }
    }
}