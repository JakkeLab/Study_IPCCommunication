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
using System.Threading;

namespace IPCServer
{
    public partial class IPCServerForm : Form
    {
        SharedMemory _mySharedMemeory;
        IpcServerChannel _serverChannel;
        Thread IPCReadThread;
        bool _bIPCReadThreadRun;

        public IPCServerForm()
        {
            InitializeComponent();
            _serverChannel = new IpcServerChannel("IPCServer");
            ChannelServices.RegisterChannel(_serverChannel, false);
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(SharedMemory), "ServerMemory", 
                WellKnownObjectMode.Singleton);
            _mySharedMemeory = new SharedMemory();

            InitServer();

        }

        void InitServer()
        {
            _bIPCReadThreadRun = true;
            IPCReadThread = new Thread(IpcRead);
            IPCReadThread.Name = "IPCReadThread";
            IPCReadThread.Start();
        }

        void IpcRead()
        {
            while(_bIPCReadThreadRun)
            {
                if(_mySharedMemeory.GetSharedMemoryDic().Count > 0)
                {
                    var data = _mySharedMemeory.GetSharedMemoryValues();
                    foreach(string strValue in data)
                    {
                        lbStringsFromClient?.Invoke(new Action(() => lbStringsFromClient.Items.Add(strValue)));
                    }
                    _mySharedMemeory.MemoryClear();
                }
                Thread.Sleep(1000);
            }
        }

        private void IPCServerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _bIPCReadThreadRun = false;
            if(IPCReadThread.ThreadState == ThreadState.Running)
            {
                if(!IPCReadThread.Join(10))
                {
                    IPCReadThread.Abort();
                    IPCReadThread = null;
                }
                else
                {
                    IPCReadThread = null;
                }
            }
        }
    }
}
