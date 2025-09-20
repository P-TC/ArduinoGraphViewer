using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArduinoGraphViewer
{
    public partial class ComPortSelectorForm : Form
    {
        public string SelectedPort
        {
            get
            {
                return comboBoxPorts.SelectedItem?.ToString() ?? string.Empty;
            }
            set
            {
                comboBoxPorts.SelectedItem = value;
            }
        }

        public int SelectedBaudRate
        {
            get
            {
                int.TryParse(comboBoxBaudRates.SelectedItem?.ToString(), out int baud);
                return baud;
            }
            set
            {
                comboBoxBaudRates.SelectedItem = value.ToString();
            }
        }

        public ComPortSelectorForm()
        {
            InitializeComponent();
            LoadComPorts();
            LoadBaudRates();
        }

        private void LoadComPorts()
        {
            string[] ports = SerialPort.GetPortNames();
            Array.Sort(ports);
            comboBoxPorts.Items.AddRange(ports);

            if (ports.Length > 0)
                comboBoxPorts.SelectedIndex = 0;
        }

        private void LoadBaudRates()
        {
            int[] baudRates = new int[]
            {
        300, 1200, 2400, 4800, 9600, 14400, 19200,
        28800, 38400, 57600, 115200, 230400, 250000
            };

            foreach (int rate in baudRates)
                comboBoxBaudRates.Items.Add(rate.ToString());

            comboBoxBaudRates.SelectedItem = "9600"; // Default
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

    }
}
