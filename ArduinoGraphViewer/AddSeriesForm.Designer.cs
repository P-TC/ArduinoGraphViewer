namespace ArduinoGraphViewer
{
    partial class AddSeriesForm
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
            textBoxSeriesName = new TextBox();
            buttonPickColor = new Button();
            panelColorPreview = new Panel();
            buttonOK = new Button();
            buttonCancel = new Button();
            LblSeriesName = new Label();
            LblColor = new Label();
            SuspendLayout();
            // 
            // textBoxSeriesName
            // 
            textBoxSeriesName.Location = new Point(60, 6);
            textBoxSeriesName.Name = "textBoxSeriesName";
            textBoxSeriesName.PlaceholderText = "MyGraphName";
            textBoxSeriesName.Size = new Size(124, 23);
            textBoxSeriesName.TabIndex = 0;
            // 
            // buttonPickColor
            // 
            buttonPickColor.Location = new Point(121, 35);
            buttonPickColor.Name = "buttonPickColor";
            buttonPickColor.Size = new Size(63, 42);
            buttonPickColor.TabIndex = 1;
            buttonPickColor.Text = "Pick Color...";
            buttonPickColor.UseVisualStyleBackColor = true;
            buttonPickColor.Click += buttonPickColor_Click;
            // 
            // panelColorPreview
            // 
            panelColorPreview.BorderStyle = BorderStyle.FixedSingle;
            panelColorPreview.Location = new Point(60, 35);
            panelColorPreview.Name = "panelColorPreview";
            panelColorPreview.Size = new Size(55, 42);
            panelColorPreview.TabIndex = 2;
            // 
            // buttonOK
            // 
            buttonOK.Location = new Point(109, 83);
            buttonOK.Name = "buttonOK";
            buttonOK.Size = new Size(75, 23);
            buttonOK.TabIndex = 3;
            buttonOK.Text = "OK";
            buttonOK.UseVisualStyleBackColor = true;
            buttonOK.Click += buttonOK_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(12, 83);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(75, 23);
            buttonCancel.TabIndex = 4;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // LblSeriesName
            // 
            LblSeriesName.AutoSize = true;
            LblSeriesName.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LblSeriesName.Location = new Point(12, 9);
            LblSeriesName.Name = "LblSeriesName";
            LblSeriesName.Size = new Size(43, 15);
            LblSeriesName.TabIndex = 5;
            LblSeriesName.Text = "Name:";
            // 
            // LblColor
            // 
            LblColor.AutoSize = true;
            LblColor.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LblColor.Location = new Point(12, 35);
            LblColor.Name = "LblColor";
            LblColor.Size = new Size(39, 15);
            LblColor.TabIndex = 5;
            LblColor.Text = "Color:";
            // 
            // AddSeriesForm
            // 
            AcceptButton = buttonOK;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = buttonCancel;
            ClientSize = new Size(199, 108);
            Controls.Add(LblColor);
            Controls.Add(LblSeriesName);
            Controls.Add(buttonCancel);
            Controls.Add(buttonOK);
            Controls.Add(panelColorPreview);
            Controls.Add(buttonPickColor);
            Controls.Add(textBoxSeriesName);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "AddSeriesForm";
            Text = "Add Graph...";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxSeriesName;
        private Button buttonPickColor;
        private Panel panelColorPreview;
        private Button buttonOK;
        private Button buttonCancel;
        private Label LblSeriesName;
        private Label LblColor;
    }
}