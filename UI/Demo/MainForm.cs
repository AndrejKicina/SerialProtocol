using SerialCom;
using System.IO.Ports;
using System.Text;

namespace Demo
{
    public partial class MainForm : Form
    {
        private SerialProtocol _sp = new SerialProtocol();
        public MainForm()
        {
            InitializeComponent();
            RefreshAvailableComPorts();
            if (cbComPorts.Items.Count > 0)
                cbComPorts.SelectedIndex = 0;

            _sp.MessageReceived += _sp_MessageReceived;
        }

        private void _sp_MessageReceived(byte cmd, byte[] payload)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() => _sp_MessageReceived(cmd, payload)));
                return;
            }

            tbCmdReceived.Text = cmd.ToString();
            tbDataReceived.Text = Encoding.Default.GetString(payload);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshAvailableComPorts();
        }

        private void RefreshAvailableComPorts()
        {
            cbComPorts.Items.Clear();

            string[] ports = SerialPort.GetPortNames();
            cbComPorts.Items.AddRange(ports);

            if (cbComPorts.Items.Count > 0)
                cbComPorts.SelectedIndex = 0;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (!_sp.SendCommand((byte)numCmd.Value, Encoding.ASCII.GetBytes(tbDataSend.Text), out var err))
                MessageBox.Show(err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(cbComPorts.Text))
            {
                if (_sp.Start(cbComPorts.Text, out var err))
                {
                    cbComPorts.Enabled = btnRefresh.Enabled = btnOpen.Enabled = false;
                    gbCommunication.Enabled = gbReceived.Enabled = btnClose.Enabled = true;
                }
                else
                    MessageBox.Show(err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            _sp.Stop();
            cbComPorts.Enabled = btnRefresh.Enabled = btnOpen.Enabled = true;
            gbCommunication.Enabled = gbReceived.Enabled = btnClose.Enabled = false;
        }
    }
}
