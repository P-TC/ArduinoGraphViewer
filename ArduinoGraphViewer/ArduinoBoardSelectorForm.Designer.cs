namespace ArduinoGraphViewer
{
    partial class ArduinoBoardSelectorForm
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
            cbCOMPort = new ComboBox();
            LblCOM = new Label();
            cbBoard = new ComboBox();
            LblBoard = new Label();
            BtnOK = new Button();
            BtnCancel = new Button();
            SuspendLayout();
            // 
            // cbCOMPort
            // 
            cbCOMPort.FormattingEnabled = true;
            cbCOMPort.Location = new Point(107, 6);
            cbCOMPort.Name = "cbCOMPort";
            cbCOMPort.Size = new Size(68, 23);
            cbCOMPort.TabIndex = 0;
            // 
            // LblCOM
            // 
            LblCOM.AutoSize = true;
            LblCOM.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LblCOM.Location = new Point(12, 9);
            LblCOM.Name = "LblCOM";
            LblCOM.Size = new Size(37, 15);
            LblCOM.TabIndex = 1;
            LblCOM.Text = "COM:";
            // 
            // cbBoard
            // 
            cbBoard.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cbBoard.FormattingEnabled = true;
            cbBoard.Location = new Point(107, 35);
            cbBoard.Name = "cbBoard";
            cbBoard.Size = new Size(183, 23);
            cbBoard.TabIndex = 0;
            // 
            // LblBoard
            // 
            LblBoard.AutoSize = true;
            LblBoard.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LblBoard.Location = new Point(12, 38);
            LblBoard.Name = "LblBoard";
            LblBoard.Size = new Size(89, 15);
            LblBoard.TabIndex = 1;
            LblBoard.Text = "Arduino board:";
            // 
            // BtnOK
            // 
            BtnOK.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            BtnOK.Location = new Point(215, 69);
            BtnOK.Name = "BtnOK";
            BtnOK.Size = new Size(75, 23);
            BtnOK.TabIndex = 2;
            BtnOK.Text = "OK";
            BtnOK.UseVisualStyleBackColor = true;
            BtnOK.Click += BtnOK_Click;
            // 
            // BtnCancel
            // 
            BtnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            BtnCancel.Location = new Point(12, 69);
            BtnCancel.Name = "BtnCancel";
            BtnCancel.Size = new Size(75, 23);
            BtnCancel.TabIndex = 3;
            BtnCancel.Text = "Cancel";
            BtnCancel.UseVisualStyleBackColor = true;
            BtnCancel.Click += BtnCancel_Click;
            // 
            // ArduinoBoardSelectorForm
            // 
            AcceptButton = BtnOK;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = BtnCancel;
            ClientSize = new Size(295, 101);
            Controls.Add(BtnCancel);
            Controls.Add(BtnOK);
            Controls.Add(LblBoard);
            Controls.Add(LblCOM);
            Controls.Add(cbBoard);
            Controls.Add(cbCOMPort);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "ArduinoBoardSelectorForm";
            Text = "ArduinoBoardSelectorForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cbCOMPort;
        private Label LblCOM;
        private ComboBox cbBoard;
        private Label LblBoard;
        private Button BtnOK;
        private Button BtnCancel;
    }
}