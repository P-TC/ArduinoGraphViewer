namespace ArduinoGraphViewer
{
    partial class FritzingSchematic
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
            LblSchematic = new Label();
            pbSchematic = new PictureBox();
            BtnGetFritzingFile = new Button();
            BtnNext = new Button();
            BtnPrev = new Button();
            ((System.ComponentModel.ISupportInitialize)pbSchematic).BeginInit();
            SuspendLayout();
            // 
            // LblSchematic
            // 
            LblSchematic.AutoSize = true;
            LblSchematic.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LblSchematic.Location = new Point(12, 9);
            LblSchematic.Name = "LblSchematic";
            LblSchematic.Size = new Size(68, 15);
            LblSchematic.TabIndex = 0;
            LblSchematic.Text = "Schematic:";
            // 
            // pbSchematic
            // 
            pbSchematic.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pbSchematic.BorderStyle = BorderStyle.Fixed3D;
            pbSchematic.Location = new Point(12, 34);
            pbSchematic.Name = "pbSchematic";
            pbSchematic.Size = new Size(776, 382);
            pbSchematic.SizeMode = PictureBoxSizeMode.Zoom;
            pbSchematic.TabIndex = 1;
            pbSchematic.TabStop = false;
            // 
            // BtnGetFritzingFile
            // 
            BtnGetFritzingFile.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            BtnGetFritzingFile.Location = new Point(667, 5);
            BtnGetFritzingFile.Name = "BtnGetFritzingFile";
            BtnGetFritzingFile.Size = new Size(121, 23);
            BtnGetFritzingFile.TabIndex = 2;
            BtnGetFritzingFile.Text = "Get Fritzing File...";
            BtnGetFritzingFile.UseVisualStyleBackColor = true;
            BtnGetFritzingFile.Click += BtnGetFritzingFile_Click;
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
            // FritzingSchematic
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(BtnPrev);
            Controls.Add(BtnNext);
            Controls.Add(BtnGetFritzingFile);
            Controls.Add(pbSchematic);
            Controls.Add(LblSchematic);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Name = "FritzingSchematic";
            Text = "Fritzing schematic";
            ((System.ComponentModel.ISupportInitialize)pbSchematic).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label LblSchematic;
        private PictureBox pbSchematic;
        private Button BtnGetFritzingFile;
        private Button BtnNext;
        private Button BtnPrev;
    }
}