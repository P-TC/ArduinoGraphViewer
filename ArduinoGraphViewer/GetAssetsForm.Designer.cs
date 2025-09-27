namespace ArduinoGraphViewer
{
    partial class GetAssetsForm
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
            LblFileName = new Label();
            pbAsset = new PictureBox();
            BtnGetFile = new Button();
            BtnNext = new Button();
            BtnPrev = new Button();
            LblCurrentAssetAndTotal = new Label();
            ((System.ComponentModel.ISupportInitialize)pbAsset).BeginInit();
            SuspendLayout();
            // 
            // LblFileName
            // 
            LblFileName.AutoSize = true;
            LblFileName.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LblFileName.Location = new Point(12, 9);
            LblFileName.Name = "LblFileName";
            LblFileName.Size = new Size(40, 15);
            LblFileName.TabIndex = 0;
            LblFileName.Text = "Asset:";
            // 
            // pbSchematic
            // 
            pbAsset.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pbAsset.BorderStyle = BorderStyle.Fixed3D;
            pbAsset.Location = new Point(12, 34);
            pbAsset.Name = "pbSchematic";
            pbAsset.Size = new Size(776, 382);
            pbAsset.SizeMode = PictureBoxSizeMode.Zoom;
            pbAsset.TabIndex = 1;
            pbAsset.TabStop = false;
            // 
            // BtnGetFile
            // 
            BtnGetFile.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            BtnGetFile.Location = new Point(667, 5);
            BtnGetFile.Name = "BtnGetFile";
            BtnGetFile.Size = new Size(121, 23);
            BtnGetFile.TabIndex = 2;
            BtnGetFile.Text = "Get File...";
            BtnGetFile.UseVisualStyleBackColor = true;
            BtnGetFile.Click += BtnGetFile_Click;
            // 
            // BtnNext
            // 
            BtnNext.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            BtnNext.Location = new Point(713, 422);
            BtnNext.Name = "BtnNext";
            BtnNext.Size = new Size(75, 23);
            BtnNext.TabIndex = 3;
            BtnNext.Text = ">";
            BtnNext.UseVisualStyleBackColor = true;
            BtnNext.Click += BtnNext_Click;
            // 
            // BtnPrev
            // 
            BtnPrev.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            BtnPrev.Location = new Point(12, 422);
            BtnPrev.Name = "BtnPrev";
            BtnPrev.Size = new Size(75, 23);
            BtnPrev.TabIndex = 3;
            BtnPrev.Text = "<";
            BtnPrev.UseVisualStyleBackColor = true;
            BtnPrev.Click += BtnPrev_Click;
            // 
            // LblCurrentAssetAndTotal
            // 
            LblCurrentAssetAndTotal.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            LblCurrentAssetAndTotal.AutoSize = true;
            LblCurrentAssetAndTotal.BorderStyle = BorderStyle.Fixed3D;
            LblCurrentAssetAndTotal.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LblCurrentAssetAndTotal.Location = new Point(360, 426);
            LblCurrentAssetAndTotal.Name = "LblCurrentAssetAndTotal";
            LblCurrentAssetAndTotal.Size = new Size(32, 17);
            LblCurrentAssetAndTotal.TabIndex = 4;
            LblCurrentAssetAndTotal.Text = ".../...";
            // 
            // GetAssetsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(LblCurrentAssetAndTotal);
            Controls.Add(BtnPrev);
            Controls.Add(BtnNext);
            Controls.Add(BtnGetFile);
            Controls.Add(pbAsset);
            Controls.Add(LblFileName);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Name = "GetAssetsForm";
            Text = "Get assets...";
            ((System.ComponentModel.ISupportInitialize)pbAsset).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label LblFileName;
        private PictureBox pbAsset;
        private Button BtnGetFile;
        private Button BtnNext;
        private Button BtnPrev;
        private Label LblCurrentAssetAndTotal;
    }
}