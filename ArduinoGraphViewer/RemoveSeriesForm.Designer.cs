namespace ArduinoGraphViewer
{
    partial class RemoveSeriesForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            BtnOK = new Button();
            BtnCancel = new Button();
            cbSeries = new ComboBox();
            LblSeriesName = new Label();
            SuspendLayout();
            // 
            // BtnOK
            // 
            BtnOK.Location = new Point(150, 35);
            BtnOK.Name = "BtnOK";
            BtnOK.Size = new Size(75, 23);
            BtnOK.TabIndex = 0;
            BtnOK.Text = "OK";
            BtnOK.UseVisualStyleBackColor = true;
            BtnOK.Click += BtnOK_Click;
            // 
            // BtnCancel
            // 
            BtnCancel.Location = new Point(12, 35);
            BtnCancel.Name = "BtnCancel";
            BtnCancel.Size = new Size(75, 23);
            BtnCancel.TabIndex = 1;
            BtnCancel.Text = "Cancel";
            BtnCancel.UseVisualStyleBackColor = true;
            BtnCancel.Click += BtnCancel_Click;
            // 
            // cbSeries
            // 
            cbSeries.FormattingEnabled = true;
            cbSeries.Location = new Point(61, 6);
            cbSeries.Name = "cbSeries";
            cbSeries.Size = new Size(164, 23);
            cbSeries.TabIndex = 2;
            // 
            // LblSeriesName
            // 
            LblSeriesName.AutoSize = true;
            LblSeriesName.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LblSeriesName.Location = new Point(12, 9);
            LblSeriesName.Name = "LblSeriesName";
            LblSeriesName.Size = new Size(43, 15);
            LblSeriesName.TabIndex = 3;
            LblSeriesName.Text = "Name:";
            // 
            // RemoveSeriesForm
            // 
            AcceptButton = BtnOK;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = BtnCancel;
            ClientSize = new Size(240, 69);
            Controls.Add(LblSeriesName);
            Controls.Add(cbSeries);
            Controls.Add(BtnCancel);
            Controls.Add(BtnOK);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "RemoveSeriesForm";
            Text = "Remove Graph...";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button BtnOK;
        private Button BtnCancel;
        private ComboBox cbSeries;
        private Label LblSeriesName;
    }
}