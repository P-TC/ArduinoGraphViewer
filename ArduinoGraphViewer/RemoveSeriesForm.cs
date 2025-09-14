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
    public partial class RemoveSeriesForm : Form
    {
        public string SelectedSeries
        {
            get
            {
                return cbSeries.SelectedItem?.ToString();
            }
        }

        public RemoveSeriesForm(List<string> series)
        {
            InitializeComponent();
            cbSeries.Items.AddRange(series.ToArray());
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            if(cbSeries.SelectedItem == null)
            {
                MessageBox.Show("Please select a series to remove.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.DialogResult = DialogResult.OK;
        }
    }
}
