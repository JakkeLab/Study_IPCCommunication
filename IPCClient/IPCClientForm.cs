using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Ipc;
using IPCSharedMemory;

namespace IPCClient
{
    public partial class IPCClientForm : Form
    {
        SharedMemory _mySharedMemory;
        IpcClientChannel _clientChannel;
        public IPCClientForm()
        {
            InitializeComponent();
            InitClient();
        }

        void InitClient()
        {
            _clientChannel = new IpcClientChannel();
            ChannelServices.RegisterChannel(_clientChannel, false);
            RemotingConfiguration.RegisterWellKnownClientType(typeof(SharedMemory), "ipc://IPCServer/ServerMemory");
            _mySharedMemory = new SharedMemory();
        }

        private void btSendMsg_Click(object sender, EventArgs e)
        {
            string strSendMsg = tbMsg.Text;
            bool bSend = _mySharedMemory.SetSharedMemoryValue("FromClient", strSendMsg);
            if (bSend) tbMsg.Clear();
        }
    }
}
