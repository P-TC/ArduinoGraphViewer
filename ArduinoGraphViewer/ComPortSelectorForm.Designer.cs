namespace ArduinoGraphViewer
{
    partial class ComPortSelectorForm
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
            comboBoxPorts = new ComboBox();
            buttonOK = new Button();
            buttonCancel = new Button();
            LblCOM = new Label();
            comboBoxBaudRates = new ComboBox();
            LblBaudRate = new Label();
            SuspendLayout();
            // 
            // comboBoxPorts
            // 
            comboBoxPorts.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            comboBoxPorts.FormattingEnabled = true;
            comboBoxPorts.Location = new Point(81, 12);
            comboBoxPorts.Name = "comboBoxPorts";
            comboBoxPorts.Size = new Size(56, 23);
            comboBoxPorts.TabIndex = 0;
            // 
            // buttonOK
            // 
            buttonOK.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonOK.Location = new Point(105, 75);
            buttonOK.Name = "buttonOK";
            buttonOK.Size = new Size(75, 23);
            buttonOK.TabIndex = 1;
            buttonOK.Text = "OK";
            buttonOK.UseVisualStyleBackColor = true;
            buttonOK.Click += buttonOK_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonCancel.Location = new Point(12, 75);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(75, 23);
            buttonCancel.TabIndex = 2;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // LblCOM
            // 
            LblCOM.AutoSize = true;
            LblCOM.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LblCOM.Location = new Point(13, 16);
            LblCOM.Name = "LblCOM";
            LblCOM.Size = new Size(37, 15);
            LblCOM.TabIndex = 3;
            LblCOM.Text = "COM:";
            // 
            // comboBoxBaudRates
            // 
            comboBoxBaudRates.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            comboBoxBaudRates.FormattingEnabled = true;
            comboBoxBaudRates.Location = new Point(81, 41);
            comboBoxBaudRates.Name = "comboBoxBaudRates";
            comboBoxBaudRates.Size = new Size(99, 23);
            comboBoxBaudRates.TabIndex = 0;
            // 
            // LblBaudRate
            // 
            LblBaudRate.AutoSize = true;
            LblBaudRate.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LblBaudRate.Location = new Point(14, 45);
            LblBaudRate.Name = "LblBaudRate";
            LblBaudRate.Size = new Size(61, 15);
            LblBaudRate.TabIndex = 3;
            LblBaudRate.Text = "Baudrate:";
            // 
            // ComPortSelectorForm
            // 
            AcceptButton = buttonOK;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = buttonCancel;
            ClientSize = new Size(191, 106);
            Controls.Add(LblBaudRate);
            Controls.Add(LblCOM);
            Controls.Add(buttonCancel);
            Controls.Add(buttonOK);
            Controls.Add(comboBoxBaudRates);
            Controls.Add(comboBoxPorts);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "ComPortSelectorForm";
            Text = "Arduino Serial Connection...";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBoxPorts;
        private Button buttonOK;
        private Button buttonCancel;
        private Label LblCOM;
        private ComboBox comboBoxBaudRates;
        private Label LblBaudRate;
    }
}