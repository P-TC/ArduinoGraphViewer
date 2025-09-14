namespace ArduinoGraphViewer
{
    partial class MainWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            splitContainer1 = new SplitContainer();
            splitContainer3 = new SplitContainer();
            gbControl = new GroupBox();
            BtnStart = new Button();
            BtnStop = new Button();
            BtnConsoleSend = new Button();
            TXTConsoleIn = new TextBox();
            TXTConsoleOut = new TextBox();
            splitContainer2 = new SplitContainer();
            _chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            _dgv = new DataGridView();
            splitContainer4 = new SplitContainer();
            splitContainer5 = new SplitContainer();
            gbGraphType = new GroupBox();
            rbTimeSeries = new RadioButton();
            rbXy = new RadioButton();
            BtnRemoveGraph = new Button();
            BtnAddGraph = new Button();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripSeparator();
            saveToolStripMenuItem = new ToolStripMenuItem();
            arduinoToolStripMenuItem = new ToolStripMenuItem();
            connectToolStripMenuItem = new ToolStripMenuItem();
            disconnectToolStripMenuItem = new ToolStripMenuItem();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
            TXTOutput = new TextBox();
            statusStrip = new StatusStrip();
            tsslStatus = new ToolStripStatusLabel();
            BtnClear = new Button();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer3).BeginInit();
            splitContainer3.Panel1.SuspendLayout();
            splitContainer3.Panel2.SuspendLayout();
            splitContainer3.SuspendLayout();
            gbControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_chart).BeginInit();
            ((System.ComponentModel.ISupportInitialize)_dgv).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer4).BeginInit();
            splitContainer4.Panel1.SuspendLayout();
            splitContainer4.Panel2.SuspendLayout();
            splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer5).BeginInit();
            splitContainer5.Panel1.SuspendLayout();
            splitContainer5.Panel2.SuspendLayout();
            splitContainer5.SuspendLayout();
            gbGraphType.SuspendLayout();
            menuStrip1.SuspendLayout();
            statusStrip.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.BorderStyle = BorderStyle.Fixed3D;
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(splitContainer3);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(splitContainer2);
            splitContainer1.Size = new Size(980, 632);
            splitContainer1.SplitterDistance = 269;
            splitContainer1.TabIndex = 0;
            // 
            // splitContainer3
            // 
            splitContainer3.BorderStyle = BorderStyle.Fixed3D;
            splitContainer3.Dock = DockStyle.Fill;
            splitContainer3.Location = new Point(0, 0);
            splitContainer3.Name = "splitContainer3";
            splitContainer3.Orientation = Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            splitContainer3.Panel1.Controls.Add(gbControl);
            // 
            // splitContainer3.Panel2
            // 
            splitContainer3.Panel2.Controls.Add(BtnConsoleSend);
            splitContainer3.Panel2.Controls.Add(TXTConsoleIn);
            splitContainer3.Panel2.Controls.Add(TXTConsoleOut);
            splitContainer3.Size = new Size(269, 632);
            splitContainer3.SplitterDistance = 119;
            splitContainer3.TabIndex = 0;
            // 
            // gbControl
            // 
            gbControl.Controls.Add(BtnStart);
            gbControl.Controls.Add(BtnStop);
            gbControl.Dock = DockStyle.Fill;
            gbControl.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gbControl.Location = new Point(0, 0);
            gbControl.Name = "gbControl";
            gbControl.Size = new Size(265, 115);
            gbControl.TabIndex = 0;
            gbControl.TabStop = false;
            gbControl.Text = "Control";
            // 
            // BtnStart
            // 
            BtnStart.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            BtnStart.Location = new Point(186, 35);
            BtnStart.Name = "BtnStart";
            BtnStart.Size = new Size(73, 55);
            BtnStart.TabIndex = 1;
            BtnStart.Text = "START";
            BtnStart.UseVisualStyleBackColor = true;
            BtnStart.Click += BtnStart_Click;
            // 
            // BtnStop
            // 
            BtnStop.Location = new Point(10, 35);
            BtnStop.Name = "BtnStop";
            BtnStop.Size = new Size(73, 55);
            BtnStop.TabIndex = 0;
            BtnStop.Text = "STOP";
            BtnStop.UseVisualStyleBackColor = true;
            BtnStop.Click += BtnStop_Click;
            // 
            // BtnConsoleSend
            // 
            BtnConsoleSend.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            BtnConsoleSend.Location = new Point(212, 479);
            BtnConsoleSend.Name = "BtnConsoleSend";
            BtnConsoleSend.Size = new Size(50, 23);
            BtnConsoleSend.TabIndex = 2;
            BtnConsoleSend.Text = "Send";
            BtnConsoleSend.UseVisualStyleBackColor = true;
            BtnConsoleSend.Click += BtnConsoleSend_Click;
            // 
            // TXTConsoleIn
            // 
            TXTConsoleIn.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            TXTConsoleIn.Location = new Point(3, 479);
            TXTConsoleIn.Name = "TXTConsoleIn";
            TXTConsoleIn.PlaceholderText = "ConsoleIn...";
            TXTConsoleIn.Size = new Size(202, 23);
            TXTConsoleIn.TabIndex = 1;
            TXTConsoleIn.KeyDown += TXTConsoleIn_KeyDown;
            // 
            // TXTConsoleOut
            // 
            TXTConsoleOut.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            TXTConsoleOut.Location = new Point(3, 3);
            TXTConsoleOut.Multiline = true;
            TXTConsoleOut.Name = "TXTConsoleOut";
            TXTConsoleOut.PlaceholderText = "ConsoleOut...";
            TXTConsoleOut.ReadOnly = true;
            TXTConsoleOut.Size = new Size(259, 470);
            TXTConsoleOut.TabIndex = 0;
            // 
            // splitContainer2
            // 
            splitContainer2.BorderStyle = BorderStyle.Fixed3D;
            splitContainer2.Dock = DockStyle.Fill;
            splitContainer2.Location = new Point(0, 0);
            splitContainer2.Name = "splitContainer2";
            splitContainer2.Orientation = Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(_chart);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(_dgv);
            splitContainer2.Size = new Size(707, 632);
            splitContainer2.SplitterDistance = 343;
            splitContainer2.TabIndex = 0;
            // 
            // _chart
            // 
            _chart.Dock = DockStyle.Fill;
            _chart.Location = new Point(0, 0);
            _chart.Name = "_chart";
            _chart.Size = new Size(703, 339);
            _chart.TabIndex = 0;
            _chart.Text = "chart1";
            // 
            // _dgv
            // 
            _dgv.BorderStyle = BorderStyle.Fixed3D;
            _dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            _dgv.Dock = DockStyle.Fill;
            _dgv.Location = new Point(0, 0);
            _dgv.Name = "_dgv";
            _dgv.Size = new Size(703, 281);
            _dgv.TabIndex = 0;
            // 
            // splitContainer4
            // 
            splitContainer4.BorderStyle = BorderStyle.Fixed3D;
            splitContainer4.Dock = DockStyle.Fill;
            splitContainer4.IsSplitterFixed = true;
            splitContainer4.Location = new Point(0, 0);
            splitContainer4.Name = "splitContainer4";
            splitContainer4.Orientation = Orientation.Horizontal;
            // 
            // splitContainer4.Panel1
            // 
            splitContainer4.Panel1.Controls.Add(splitContainer5);
            splitContainer4.Panel1.Controls.Add(menuStrip1);
            // 
            // splitContainer4.Panel2
            // 
            splitContainer4.Panel2.Controls.Add(TXTOutput);
            splitContainer4.Panel2.Controls.Add(statusStrip);
            splitContainer4.Size = new Size(1065, 780);
            splitContainer4.SplitterDistance = 656;
            splitContainer4.TabIndex = 1;
            // 
            // splitContainer5
            // 
            splitContainer5.BorderStyle = BorderStyle.Fixed3D;
            splitContainer5.Dock = DockStyle.Fill;
            splitContainer5.FixedPanel = FixedPanel.Panel2;
            splitContainer5.Location = new Point(0, 24);
            splitContainer5.Name = "splitContainer5";
            // 
            // splitContainer5.Panel1
            // 
            splitContainer5.Panel1.Controls.Add(splitContainer1);
            // 
            // splitContainer5.Panel2
            // 
            splitContainer5.Panel2.Controls.Add(gbGraphType);
            splitContainer5.Panel2.Controls.Add(BtnRemoveGraph);
            splitContainer5.Panel2.Controls.Add(BtnClear);
            splitContainer5.Panel2.Controls.Add(BtnAddGraph);
            splitContainer5.Size = new Size(1065, 632);
            splitContainer5.SplitterDistance = 980;
            splitContainer5.TabIndex = 2;
            // 
            // gbGraphType
            // 
            gbGraphType.Controls.Add(rbTimeSeries);
            gbGraphType.Controls.Add(rbXy);
            gbGraphType.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gbGraphType.Location = new Point(3, 121);
            gbGraphType.Name = "gbGraphType";
            gbGraphType.Size = new Size(73, 98);
            gbGraphType.TabIndex = 2;
            gbGraphType.TabStop = false;
            gbGraphType.Text = "Graph Type";
            // 
            // rbTimeSeries
            // 
            rbTimeSeries.AutoSize = true;
            rbTimeSeries.Checked = true;
            rbTimeSeries.Location = new Point(6, 38);
            rbTimeSeries.Name = "rbTimeSeries";
            rbTimeSeries.Size = new Size(53, 19);
            rbTimeSeries.TabIndex = 1;
            rbTimeSeries.TabStop = true;
            rbTimeSeries.Text = "Time";
            rbTimeSeries.UseVisualStyleBackColor = true;
            rbTimeSeries.CheckedChanged += rbTimeSeries_CheckedChanged;
            // 
            // rbXy
            // 
            rbXy.AutoSize = true;
            rbXy.Location = new Point(6, 63);
            rbXy.Name = "rbXy";
            rbXy.Size = new Size(40, 19);
            rbXy.TabIndex = 1;
            rbXy.Text = "XY";
            rbXy.UseVisualStyleBackColor = true;
            rbXy.CheckedChanged += rbXy_CheckedChanged;
            // 
            // BtnRemoveGraph
            // 
            BtnRemoveGraph.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            BtnRemoveGraph.Location = new Point(3, 570);
            BtnRemoveGraph.Name = "BtnRemoveGraph";
            BtnRemoveGraph.Size = new Size(73, 55);
            BtnRemoveGraph.TabIndex = 0;
            BtnRemoveGraph.Text = "Remove Graph...";
            BtnRemoveGraph.UseVisualStyleBackColor = true;
            BtnRemoveGraph.Click += BtnRemoveGraph_Click;
            // 
            // BtnAddGraph
            // 
            BtnAddGraph.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            BtnAddGraph.Location = new Point(3, 3);
            BtnAddGraph.Name = "BtnAddGraph";
            BtnAddGraph.Size = new Size(73, 55);
            BtnAddGraph.TabIndex = 0;
            BtnAddGraph.Text = "Add Graph...";
            BtnAddGraph.UseVisualStyleBackColor = true;
            BtnAddGraph.Click += BtnAddGraph_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, arduinoToolStripMenuItem, aboutToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1065, 24);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { exitToolStripMenuItem, toolStripMenuItem1, saveToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "&File";
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(107, 22);
            exitToolStripMenuItem.Text = "&Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(104, 6);
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.Size = new Size(107, 22);
            saveToolStripMenuItem.Text = "&Save...";
            saveToolStripMenuItem.Click += saveToolStripMenuItem_Click;
            // 
            // arduinoToolStripMenuItem
            // 
            arduinoToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { connectToolStripMenuItem, disconnectToolStripMenuItem });
            arduinoToolStripMenuItem.Name = "arduinoToolStripMenuItem";
            arduinoToolStripMenuItem.Size = new Size(62, 20);
            arduinoToolStripMenuItem.Text = "&Arduino";
            // 
            // connectToolStripMenuItem
            // 
            connectToolStripMenuItem.Name = "connectToolStripMenuItem";
            connectToolStripMenuItem.Size = new Size(133, 22);
            connectToolStripMenuItem.Text = "&Connect...";
            connectToolStripMenuItem.Click += connectToolStripMenuItem_Click;
            // 
            // disconnectToolStripMenuItem
            // 
            disconnectToolStripMenuItem.Name = "disconnectToolStripMenuItem";
            disconnectToolStripMenuItem.Size = new Size(133, 22);
            disconnectToolStripMenuItem.Text = "&Disconnect";
            disconnectToolStripMenuItem.Click += disconnectToolStripMenuItem_Click;
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { helpToolStripMenuItem });
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(52, 20);
            aboutToolStripMenuItem.Text = "&About";
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(99, 22);
            helpToolStripMenuItem.Text = "&Help";
            helpToolStripMenuItem.Click += helpToolStripMenuItem_Click;
            // 
            // TXTOutput
            // 
            TXTOutput.Dock = DockStyle.Fill;
            TXTOutput.Location = new Point(0, 0);
            TXTOutput.Multiline = true;
            TXTOutput.Name = "TXTOutput";
            TXTOutput.PlaceholderText = "Application Output...";
            TXTOutput.ReadOnly = true;
            TXTOutput.ScrollBars = ScrollBars.Vertical;
            TXTOutput.Size = new Size(1061, 94);
            TXTOutput.TabIndex = 1;
            // 
            // statusStrip
            // 
            statusStrip.Items.AddRange(new ToolStripItem[] { tsslStatus });
            statusStrip.Location = new Point(0, 94);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new Size(1061, 22);
            statusStrip.TabIndex = 0;
            // 
            // tsslStatus
            // 
            tsslStatus.Name = "tsslStatus";
            tsslStatus.Size = new Size(48, 17);
            tsslStatus.Text = "Status...";
            // 
            // BtnClear
            // 
            BtnClear.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            BtnClear.Location = new Point(3, 60);
            BtnClear.Name = "BtnClear";
            BtnClear.Size = new Size(73, 55);
            BtnClear.TabIndex = 0;
            BtnClear.Text = "Clear...";
            BtnClear.UseVisualStyleBackColor = true;
            BtnClear.Click += BtnClear_Click;
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1065, 780);
            Controls.Add(splitContainer4);
            MainMenuStrip = menuStrip1;
            Name = "MainWindow";
            Text = "Arduino Graph Viewer";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            splitContainer3.Panel1.ResumeLayout(false);
            splitContainer3.Panel2.ResumeLayout(false);
            splitContainer3.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer3).EndInit();
            splitContainer3.ResumeLayout(false);
            gbControl.ResumeLayout(false);
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_chart).EndInit();
            ((System.ComponentModel.ISupportInitialize)_dgv).EndInit();
            splitContainer4.Panel1.ResumeLayout(false);
            splitContainer4.Panel1.PerformLayout();
            splitContainer4.Panel2.ResumeLayout(false);
            splitContainer4.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer4).EndInit();
            splitContainer4.ResumeLayout(false);
            splitContainer5.Panel1.ResumeLayout(false);
            splitContainer5.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer5).EndInit();
            splitContainer5.ResumeLayout(false);
            gbGraphType.ResumeLayout(false);
            gbGraphType.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private SplitContainer splitContainer2;
        private SplitContainer splitContainer3;
        private DataGridView _dgv;
        private SplitContainer splitContainer4;
        private TextBox TXTOutput;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel tsslStatus;
        private GroupBox gbControl;
        private TextBox TXTConsoleOut;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem arduinoToolStripMenuItem;
        private ToolStripMenuItem connectToolStripMenuItem;
        private ToolStripMenuItem disconnectToolStripMenuItem;
        private Button BtnConsoleSend;
        private TextBox TXTConsoleIn;
        private Button BtnStart;
        private Button BtnStop;
        private System.Windows.Forms.DataVisualization.Charting.Chart _chart;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripMenuItem saveToolStripMenuItem;
        private SplitContainer splitContainer5;
        private Button BtnRemoveGraph;
        private Button BtnAddGraph;
        private GroupBox gbGraphType;
        private RadioButton rbTimeSeries;
        private RadioButton rbXy;
        private Button BtnClear;
    }
}
