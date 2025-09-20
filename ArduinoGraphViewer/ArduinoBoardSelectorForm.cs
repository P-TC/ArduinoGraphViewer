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
    public partial class ArduinoBoardSelectorForm : Form
    {
        #region PROPERTIES

        private ArduinoUploader.ArduinoBoardFqbn _selectedArduinoBoard = ArduinoUploader.ArduinoBoardFqbn.ArduinoUno;
        public ArduinoUploader.ArduinoBoardFqbn SelectedArduinoBoard
        {
            get
            {
                var selected = cbBoard.SelectedItem as ArduinoUploader.ArduinoBoardFqbn?;
                return selected ?? _selectedArduinoBoard;
            }
            set
            {
                cbBoard.SelectedItem = value;
                _selectedArduinoBoard = value;
            }
        }


        public string SelectedPort
        {
            get
            {
                return cbCOMPort.SelectedItem?.ToString() ?? string.Empty;
            }
            set
            {
                cbCOMPort.SelectedItem = value;
            }
        }

        #endregion

        #region CONSTRUCTOR
        public ArduinoBoardSelectorForm()
        {
            InitializeComponent();
            Init();
        }

        #endregion

        #region FUNCTIONS
        private void Init()
        {
            try
            {
                LoadComPorts();
                LoadBoards();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during initialization: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void LoadComPorts()
        {
            try
            {
                string[] ports = SerialPort.GetPortNames();
                Array.Sort(ports);
                cbCOMPort.Items.AddRange(ports);

                if (ports.Length > 0)
                    cbCOMPort.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading COM ports: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadBoards()
        {
            try
            {
                cbBoard.Items.AddRange(
                    Enum.GetValues(typeof(ArduinoUploader.ArduinoBoardFqbn))
                        .Cast<object>()
                        .ToArray()
                );
                cbBoard.SelectedItem = ArduinoUploader.ArduinoBoardFqbn.ArduinoUno;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading boards: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region BUTTONS

        private void BtnOK_Click(object sender, EventArgs e)
        {
            try
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error selecting board: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error cancelling selection: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

    }
}
