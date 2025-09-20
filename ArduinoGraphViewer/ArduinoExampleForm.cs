using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArduinoGraphViewer
{
    public partial class ArduinoExampleForm : Form
    {
        #region VARS


        #endregion

        #region MENU

        #region FILE
        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using OpenFileDialog ofd = new OpenFileDialog
                {
                    Filter = "Arduino Files (*.ino)|*.ino|All Files (*.*)|*.*",
                    Title = "Load Arduino Example Code"
                };
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    ExampleCode = System.IO.File.ReadAllText(ofd.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using SaveFileDialog sfd = new SaveFileDialog
                {
                    Filter = "Arduino Files (*.ino)|*.ino|All Files (*.*)|*.*",
                    Title = "Save Arduino Example Code"
                };
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    string dir = Path.GetDirectoryName(sfd.FileName);
                    string finalFileName = Path.Combine(dir, Path.GetFileNameWithoutExtension(sfd.FileName), Path.GetFileNameWithoutExtension(sfd.FileName) + ".ino");
                    if(!Directory.Exists(Path.GetDirectoryName(finalFileName)))
                    {
                        Directory.CreateDirectory(Path.GetDirectoryName(finalFileName)!);
                    }
                    System.IO.File.WriteAllText(finalFileName, ExampleCode);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region CODE
        private void uploadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using (ArduinoBoardSelectorForm boardSelector = new ArduinoBoardSelectorForm())
                {
                    if (boardSelector.ShowDialog() == DialogResult.OK)
                    {
                        if (boardSelector.SelectedBoard != null && boardSelector.SelectedPort != null)
                        {
                            string output = "";
                            if (ArduinoUploader.CompileAndUploadSketch(txtExampleCode.Text, boardSelector.SelectedPort, boardSelector.SelectedBoard, out output))
                            {
                                txtOutput.Text = output;
                                txtOutput.SelectionStart = txtOutput.Text.Length;
                                txtOutput.ScrollToCaret();
                                MessageBox.Show("Code uploaded successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                txtOutput.Text = output;
                                txtOutput.SelectionStart = txtOutput.Text.Length;
                                txtOutput.ScrollToCaret();
                                MessageBox.Show("Failed to upload code. See output for details.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please select a valid board and COM port.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error uploading code: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #endregion

        #region PROPERTIES

        public string ExampleCode
        {
            get => txtExampleCode.Text;
            set => txtExampleCode.Text = value;
        }

        #endregion

        #region CONSTRUCTORS
        public ArduinoExampleForm(string? arduinoCode)
        {
            InitializeComponent();
            ExampleCode = arduinoCode ?? "";
        }

        #endregion

    }
}
