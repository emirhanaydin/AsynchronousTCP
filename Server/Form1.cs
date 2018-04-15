using System;
using System.Windows.Forms;
using SocketsAsync;

namespace Server
{
    public partial class Form1 : Form
    {
        private readonly SocketServerAsync _socketServerAsync;

        public Form1()
        {
            InitializeComponent();
            _socketServerAsync = new SocketServerAsync();
        }

        private void buttonStartServer_Click(object sender, EventArgs e)
        {
            buttonStartServer.Enabled = false;
            buttonStopServer.Enabled = true;
            textBoxSendToAll.Enabled = true;
            buttonSendToAll.Enabled = true;

            _socketServerAsync.StartListeninFromIncomingConnection();
        }

        private void buttonSendToAll_Click(object sender, EventArgs e)
        {
            _socketServerAsync.SendToAll(textBoxSendToAll.Text.Trim());
        }

        private void buttonStopServer_Click(object sender, EventArgs e)
        {
            _socketServerAsync.StopServer();

            buttonStartServer.Enabled = true;
            buttonStopServer.Enabled = false;
            textBoxSendToAll.Enabled = false;
            buttonSendToAll.Enabled = false;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            _socketServerAsync.StopServer();
        }
    }
}