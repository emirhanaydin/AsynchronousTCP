using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace SocketsAsync
{
    public class SocketServerAsync
    {
        private IPAddress _ipAddress;
        private ushort _port;
        private TcpListener _tcpListener;

        private bool KeepRunning { get; set; }

        public async void StartListeninFromIncomingConnection(IPAddress ipAddress = null, ushort port = 23000)
        {
            if (ipAddress == null) ipAddress = IPAddress.Any;

            _ipAddress = ipAddress;
            _port = port;

            Debug.WriteLine("IP Address: {0}:{1}", _ipAddress, _port);

            _tcpListener = new TcpListener(_ipAddress, _port);
            _tcpListener.Start();

            KeepRunning = true;

            while (KeepRunning)
            {
                var client = await _tcpListener.AcceptTcpClientAsync();
                Debug.WriteLine("Client connected: " + client);
                WorkWithTcpClient(client);
            }
        }

        private async void WorkWithTcpClient(TcpClient client)
        {
            var reader = new StreamReader(client.GetStream());

            var buff = new char[64];

            while (KeepRunning)
            {
                var numRead = await reader.ReadAsync(buff, 0, buff.Length);

                Debug.WriteLine("Number readed: " + numRead);

                if (numRead == 0)
                {
                    Debug.WriteLine("Socket was disconnected.");
                    break;
                }

                var receivedText = new string(buff);
                Debug.WriteLine("Received text: " + receivedText);

                Array.Clear(buff, 0, buff.Length);
            }
        }
    }
}