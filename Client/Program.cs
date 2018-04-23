﻿using System;
using ClientLibrary;
using EventLibrary;

namespace Client
{
    internal static class Program
    {
        public static void Main()
        {
            if (ConnectToServer()) return;

            Console.WriteLine("Unable to connect to server.");
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }

        private static bool ConnectToServer()
        {
            var clientManager = new ClientManager();

            Console.Write("IP Address: ");
            if (!clientManager.SetServerIpAddress(Console.ReadLine())) return false;

            Console.Write("Port: ");
            if (!ushort.TryParse(Console.ReadLine(), out var port))
            {
                Console.WriteLine("Port number is incorrect.");
                return false;
            }

            clientManager.Port = port;

            try
            {
                clientManager.ConnectToServer().Wait(1000);
            }
            catch (Exception)
            {
                return false;
            }

            clientManager.MessageReceived += OnMessageReceived;

            do
            {
                var input = Console.ReadLine();
                if (string.Equals("exit", input, StringComparison.OrdinalIgnoreCase))
                {
                    clientManager.CloseAndDisconnect();
                    break;
                }

                clientManager.SendToServer(input).Wait(1000);
            } while (true);

            clientManager.DisconnectFromServer();

            return true;
        }

        private static void OnMessageReceived(object sender, MessageReceivedEventArgs e)
        {
            Console.WriteLine($"{DateTime.Now} - {e.Sender}: {e.Message}");
        }
    }
}