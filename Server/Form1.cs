using System;
using System.Windows.Forms;
using EventLibrary;
using ServerLibrary;

namespace Server
{
    public partial class Form1 : Form
    {
        private readonly ServerManager _serverManager;

        public Form1()
        {
            InitializeComponent();
            _serverManager = new ServerManager();
            _serverManager.ClientConnected += OnClientConnected;
            _serverManager.MessageReceived += OnMessageReceived;
        }

        private void buttonStartServer_Click(object sender, EventArgs e)
        {
            buttonStartServer.Enabled = false;
            buttonStopServer.Enabled = true;
            textBoxSendToAll.Enabled = true;
            buttonSendToAll.Enabled = true;

            _serverManager.StartListeninFromIncomingConnection();
        }

        private void buttonSendToAll_Click(object sender, EventArgs e)
        {
            _serverManager.SendToAll(textBoxSendToAll.Text.Trim());
        }

        private void buttonStopServer_Click(object sender, EventArgs e)
        {
            _serverManager.StopServer();

            buttonStartServer.Enabled = true;
            buttonStopServer.Enabled = false;
            textBoxSendToAll.Enabled = false;
            buttonSendToAll.Enabled = false;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            _serverManager.StopServer();
        }

        private void AppendLog(string text)
        {
            textBoxLog.AppendText(text);
            textBoxLog.AppendText(Environment.NewLine);
        }

        private void OnClientConnected(object sender, ClientConnectedEventArgs args)
        {
            AppendLog($"{DateTime.Now} - Client connected: {args.Client}");
        }

        private void OnMessageReceived(object sender, MessageReceivedEventArgs args)
        {
            AppendLog($"{DateTime.Now} - {args.Sender}: {args.Message}");
        }
    }
}