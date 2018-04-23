using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using EventLibrary;

namespace ClientLibrary
{
    public class ClientManager
    {
        private IPAddress _ipAddress;
        public ushort Port { get; set; }
        private TcpClient _tcpClient;

        public EventHandler<MessageReceivedEventArgs> MessageReceived;

        public ClientManager()
        {
            _ipAddress = null;
            _tcpClient = null;
        }

        public bool SetServerIpAddress(string ipAddress)
        {
            if (!IPAddress.TryParse(ipAddress, out var ipaddr))
            {
                if (ipAddress.Equals("localhost", StringComparison.OrdinalIgnoreCase))
                {
                    ipaddr = IPAddress.Parse("127.0.0.1");
                }
                else
                {
                    Console.WriteLine("IP address is incorrect.");
                    return false;
                }
            }

            _ipAddress = ipaddr;
            return true;
        }

        public IPAddress ServerIpAddress => _ipAddress;

        public async Task ConnectToServer()
        {
            if (_tcpClient == null) _tcpClient = new TcpClient();

            try
            {
                await _tcpClient.ConnectAsync(_ipAddress, Port);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }

            Console.WriteLine("Connected to server: {0}:{1}", _ipAddress, Port);

            await ReadDataAsync();
        }

        public void DisconnectFromServer()
        {
            _tcpClient?.Close();
            Console.WriteLine("Disconnected from server.");
        }

        private async Task ReadDataAsync()
        {
            var streamReader = new StreamReader(_tcpClient.GetStream());
            var buff = new char[64];

            while (_tcpClient.Connected)
            {
                int length;

                try
                {
                    length = await streamReader.ReadAsync(buff, 0, buff.Length);
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e);
                    return;
                }

                if (length <= 0)
                {
                    DisconnectFromServer();
                    return;
                }

                MessageReceived?.Invoke(this,
                    new MessageReceivedEventArgs(_tcpClient.Client.RemoteEndPoint.ToString(),
                        new string(buff, 0, length)));

                buff[0] = (char) 0;
            }
        }

        public async Task SendToServer(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("Empty input was made to send.");
                return;
            }

            if (_tcpClient == null) return;

            if (!_tcpClient.Connected) return;

            var streamWriter = new StreamWriter(_tcpClient.GetStream()) {AutoFlush = true};

            await streamWriter.WriteAsync(input);
            Console.WriteLine("The input was sent.");
        }

        public void CloseAndDisconnect()
        {
            if (_tcpClient == null) return;

            if (_tcpClient.Connected) _tcpClient.Close();
        }
    }
}