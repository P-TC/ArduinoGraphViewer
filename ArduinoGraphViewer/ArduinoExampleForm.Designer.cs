namespace ArduinoGraphViewer
{
    partial class ArduinoExampleForm
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
            txtExampleCode = new TextBox();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            loadToolStripMenuItem = new ToolStripMenuItem();
            saveToolStripMenuItem = new ToolStripMenuItem();
            codeToolStripMenuItem = new ToolStripMenuItem();
            uploadToolStripMenuItem = new ToolStripMenuItem();
            txtOutput = new TextBox();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // txtExampleCode
            // 
            txtExampleCode.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtExampleCode.Location = new Point(0, 27);
            txtExampleCode.Multiline = true;
            txtExampleCode.Name = "txtExampleCode";
            txtExampleCode.ScrollBars = ScrollBars.Both;
            txtExampleCode.Size = new Size(800, 305);
            txtExampleCode.TabIndex = 0;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, codeToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { loadToolStripMenuItem, saveToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "&File";
            // 
            // loadToolStripMenuItem
            // 
            loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            loadToolStripMenuItem.Size = new Size(109, 22);
            loadToolStripMenuItem.Text = "&Load...";
            loadToolStripMenuItem.Click += loadToolStripMenuItem_Click;
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.Size = new Size(109, 22);
            saveToolStripMenuItem.Text = "&Save...";
            saveToolStripMenuItem.Click += saveToolStripMenuItem_Click;
            // 
            // codeToolStripMenuItem
            // 
            codeToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { uploadToolStripMenuItem });
            codeToolStripMenuItem.Name = "codeToolStripMenuItem";
            codeToolStripMenuItem.Size = new Size(62, 20);
            codeToolStripMenuItem.Text = "&Arduino";
            // 
            // uploadToolStripMenuItem
            // 
            uploadToolStripMenuItem.Name = "uploadToolStripMenuItem";
            uploadToolStripMenuItem.Size = new Size(121, 22);
            uploadToolStripMenuItem.Text = "&Upload...";
            uploadToolStripMenuItem.Click += uploadToolStripMenuItem_Click;
            // 
            // txtOutput
            // 
            txtOutput.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtOutput.Location = new Point(0, 338);
            txtOutput.Multiline = true;
            txtOutput.Name = "txtOutput";
            txtOutput.ReadOnly = true;
            txtOutput.ScrollBars = ScrollBars.Vertical;
            txtOutput.Size = new Size(800, 112);
            txtOutput.TabIndex = 2;
            // 
            // ArduinoExampleForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(txtOutput);
            Controls.Add(txtExampleCode);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "ArduinoExampleForm";
            Text = "Arduino Example Code (View & Upload)";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtExampleCode;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem loadToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem codeToolStripMenuItem;
        private ToolStripMenuItem uploadToolStripMenuItem;
        private TextBox txtOutput;
    }
}