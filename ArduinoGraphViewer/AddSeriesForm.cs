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
    public partial class AddSeriesForm : Form
    {
        public string SeriesName => textBoxSeriesName.Text;
        public Color SeriesColor { get; private set; } = Color.Blue; // Default

        public AddSeriesForm()
        {
            InitializeComponent();
            panelColorPreview.BackColor = SeriesColor;
        }

        private void buttonPickColor_Click(object sender, EventArgs e)
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    SeriesColor = colorDialog.Color;
                    panelColorPreview.BackColor = SeriesColor;
                }
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SeriesName))
            {
                MessageBox.Show("Please enter a unique series name.");
                return;
            }

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
