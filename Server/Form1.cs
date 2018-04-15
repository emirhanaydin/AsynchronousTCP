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

        private void buttonAcceptIncomingConnection_Click(object sender, EventArgs e)
        {
            buttonAcceptIncomingConnection.Enabled = false;
            _socketServerAsync.StartListeninFromIncomingConnection();
        }

        private void buttonSendToAll_Click(object sender, EventArgs e)
        {
            _socketServerAsync.SendToAll(textBoxSendToAll.Text.Trim());
        }
    }
}