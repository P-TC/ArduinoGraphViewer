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
            LblState = new Label();
            progressBar = new ProgressBar();
            BtnMeasure = new Button();
            BtnCalibration = new Button();
            BtnReset = new Button();
            LblMaxConsoleLines = new Label();
            TXTMaxConsoleLines = new TextBox();
            chAddTimestamp = new CheckBox();
            chAutoScrollConsole = new CheckBox();
            BtnClearConsoleOut = new Button();
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
            BtnClear = new Button();
            BtnAddGraph = new Button();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripSeparator();
            saveToolStripMenuItem = new ToolStripMenuItem();
            arduinoToolStripMenuItem = new ToolStripMenuItem();
            connectToolStripMenuItem = new ToolStripMenuItem();
            disconnectToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem2 = new ToolStripSeparator();
            viewUploadExampleToolStripMenuItem = new ToolStripMenuItem();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
            splitContainer6 = new SplitContainer();
            TXTOutput = new TextBox();
            LblMaxLines = new Label();
            TXTMaxLines = new TextBox();
            chAutoScroll = new CheckBox();
            BtnClearOutput = new Button();
            statusStrip = new StatusStrip();
            tsslStatus = new ToolStripStatusLabel();
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
            ((System.ComponentModel.ISupportInitialize)splitContainer6).BeginInit();
            splitContainer6.Panel1.SuspendLayout();
            splitContainer6.Panel2.SuspendLayout();
            splitContainer6.SuspendLayout();
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
            splitContainer1.Size = new Size(976, 648);
            splitContainer1.SplitterDistance = 267;
            splitContainer1.TabIndex = 0;
            // 
            // splitContainer3
            // 
            splitContainer3.BorderStyle = BorderStyle.Fixed3D;
            splitContainer3.Dock = DockStyle.Fill;
            splitContainer3.FixedPanel = FixedPanel.Panel1;
            splitContainer3.IsSplitterFixed = true;
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
            splitContainer3.Panel2.Controls.Add(LblMaxConsoleLines);
            splitContainer3.Panel2.Controls.Add(TXTMaxConsoleLines);
            splitContainer3.Panel2.Controls.Add(chAddTimestamp);
            splitContainer3.Panel2.Controls.Add(chAutoScrollConsole);
            splitContainer3.Panel2.Controls.Add(BtnClearConsoleOut);
            splitContainer3.Panel2.Controls.Add(BtnConsoleSend);
            splitContainer3.Panel2.Controls.Add(TXTConsoleIn);
            splitContainer3.Panel2.Controls.Add(TXTConsoleOut);
            splitContainer3.Size = new Size(267, 648);
            splitContainer3.SplitterDistance = 115;
            splitContainer3.TabIndex = 0;
            // 
            // gbControl
            // 
            gbControl.Controls.Add(LblState);
            gbControl.Controls.Add(progressBar);
            gbControl.Controls.Add(BtnMeasure);
            gbControl.Controls.Add(BtnCalibration);
            gbControl.Controls.Add(BtnReset);
            gbControl.Dock = DockStyle.Fill;
            gbControl.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gbControl.Location = new Point(0, 0);
            gbControl.Name = "gbControl";
            gbControl.Size = new Size(263, 111);
            gbControl.TabIndex = 0;
            gbControl.TabStop = false;
            gbControl.Text = "Control";
            // 
            // LblState
            // 
            LblState.BorderStyle = BorderStyle.Fixed3D;
            LblState.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LblState.Location = new Point(6, 79);
            LblState.Name = "LblState";
            LblState.Size = new Size(133, 26);
            LblState.TabIndex = 3;
            LblState.Text = "State";
            // 
            // progressBar
            // 
            progressBar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            progressBar.Location = new Point(145, 80);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(112, 23);
            progressBar.TabIndex = 2;
            // 
            // BtnMeasure
            // 
            BtnMeasure.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            BtnMeasure.Location = new Point(184, 21);
            BtnMeasure.Name = "BtnMeasure";
            BtnMeasure.Size = new Size(73, 55);
            BtnMeasure.TabIndex = 1;
            BtnMeasure.Text = "MEASURE";
            BtnMeasure.UseVisualStyleBackColor = true;
            BtnMeasure.Click += BtnMeasure_Click;
            // 
            // BtnCalibration
            // 
            BtnCalibration.Location = new Point(6, 20);
            BtnCalibration.Name = "BtnCalibration";
            BtnCalibration.Size = new Size(96, 55);
            BtnCalibration.TabIndex = 0;
            BtnCalibration.Text = "CALIBRATION";
            BtnCalibration.UseVisualStyleBackColor = true;
            BtnCalibration.Click += BtnCalibration_Click;
            // 
            // BtnReset
            // 
            BtnReset.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            BtnReset.Location = new Point(105, 20);
            BtnReset.Name = "BtnReset";
            BtnReset.Size = new Size(73, 55);
            BtnReset.TabIndex = 0;
            BtnReset.Text = "RESET";
            BtnReset.UseVisualStyleBackColor = true;
            BtnReset.Click += BtnReset_Click;
            // 
            // LblMaxConsoleLines
            // 
            LblMaxConsoleLines.AutoSize = true;
            LblMaxConsoleLines.Location = new Point(3, 7);
            LblMaxConsoleLines.Name = "LblMaxConsoleLines";
            LblMaxConsoleLines.Size = new Size(37, 15);
            LblMaxConsoleLines.TabIndex = 3;
            LblMaxConsoleLines.Text = "Lines:";
            // 
            // TXTMaxConsoleLines
            // 
            TXTMaxConsoleLines.Location = new Point(43, 2);
            TXTMaxConsoleLines.Name = "TXTMaxConsoleLines";
            TXTMaxConsoleLines.Size = new Size(33, 23);
            TXTMaxConsoleLines.TabIndex = 2;
            TXTMaxConsoleLines.Text = "200";
            TXTMaxConsoleLines.TextAlign = HorizontalAlignment.Right;
            // 
            // chAddTimestamp
            // 
            chAddTimestamp.AutoSize = true;
            chAddTimestamp.Checked = true;
            chAddTimestamp.CheckState = CheckState.Checked;
            chAddTimestamp.Location = new Point(92, 25);
            chAddTimestamp.Name = "chAddTimestamp";
            chAddTimestamp.Size = new Size(78, 19);
            chAddTimestamp.TabIndex = 1;
            chAddTimestamp.Text = "Add Time";
            chAddTimestamp.UseVisualStyleBackColor = true;
            // 
            // chAutoScrollConsole
            // 
            chAutoScrollConsole.AutoSize = true;
            chAutoScrollConsole.Checked = true;
            chAutoScrollConsole.CheckState = CheckState.Checked;
            chAutoScrollConsole.Location = new Point(92, 6);
            chAutoScrollConsole.Name = "chAutoScrollConsole";
            chAutoScrollConsole.Size = new Size(84, 19);
            chAutoScrollConsole.TabIndex = 1;
            chAutoScrollConsole.Text = "Auto Scroll";
            chAutoScrollConsole.UseVisualStyleBackColor = true;
            // 
            // BtnClearConsoleOut
            // 
            BtnClearConsoleOut.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            BtnClearConsoleOut.Location = new Point(210, 3);
            BtnClearConsoleOut.Name = "BtnClearConsoleOut";
            BtnClearConsoleOut.Size = new Size(50, 34);
            BtnClearConsoleOut.TabIndex = 0;
            BtnClearConsoleOut.Text = "Clear";
            BtnClearConsoleOut.UseVisualStyleBackColor = true;
            BtnClearConsoleOut.Click += BtnClearConsoleOut_Click;
            // 
            // BtnConsoleSend
            // 
            BtnConsoleSend.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            BtnConsoleSend.Location = new Point(210, 495);
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
            TXTConsoleIn.Location = new Point(3, 495);
            TXTConsoleIn.Name = "TXTConsoleIn";
            TXTConsoleIn.PlaceholderText = "type 'help' for more info";
            TXTConsoleIn.Size = new Size(200, 23);
            TXTConsoleIn.TabIndex = 1;
            TXTConsoleIn.KeyDown += TXTConsoleIn_KeyDown;
            // 
            // TXTConsoleOut
            // 
            TXTConsoleOut.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            TXTConsoleOut.Location = new Point(3, 43);
            TXTConsoleOut.Multiline = true;
            TXTConsoleOut.Name = "TXTConsoleOut";
            TXTConsoleOut.PlaceholderText = "ConsoleOut...";
            TXTConsoleOut.ReadOnly = true;
            TXTConsoleOut.ScrollBars = ScrollBars.Both;
            TXTConsoleOut.Size = new Size(257, 447);
            TXTConsoleOut.TabIndex = 0;
            TXTConsoleOut.WordWrap = false;
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
            splitContainer2.Size = new Size(705, 648);
            splitContainer2.SplitterDistance = 350;
            splitContainer2.TabIndex = 0;
            // 
            // _chart
            // 
            _chart.Dock = DockStyle.Fill;
            _chart.Location = new Point(0, 0);
            _chart.Name = "_chart";
            _chart.Size = new Size(701, 346);
            _chart.TabIndex = 0;
            _chart.Text = "chart1";
            // 
            // _dgv
            // 
            _dgv.AllowUserToAddRows = false;
            _dgv.AllowUserToDeleteRows = false;
            _dgv.AllowUserToOrderColumns = true;
            _dgv.AllowUserToResizeRows = false;
            _dgv.BorderStyle = BorderStyle.Fixed3D;
            _dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            _dgv.Dock = DockStyle.Fill;
            _dgv.Location = new Point(0, 0);
            _dgv.Name = "_dgv";
            _dgv.RowHeadersWidth = 72;
            _dgv.Size = new Size(701, 290);
            _dgv.TabIndex = 0;
            // 
            // splitContainer4
            // 
            splitContainer4.BorderStyle = BorderStyle.Fixed3D;
            splitContainer4.Dock = DockStyle.Fill;
            splitContainer4.FixedPanel = FixedPanel.Panel2;
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
            splitContainer4.Panel2.Controls.Add(splitContainer6);
            splitContainer4.Panel2.Controls.Add(statusStrip);
            splitContainer4.Size = new Size(1065, 828);
            splitContainer4.SplitterDistance = 672;
            splitContainer4.TabIndex = 1;
            // 
            // splitContainer5
            // 
            splitContainer5.BorderStyle = BorderStyle.Fixed3D;
            splitContainer5.Dock = DockStyle.Fill;
            splitContainer5.FixedPanel = FixedPanel.Panel2;
            splitContainer5.IsSplitterFixed = true;
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
            splitContainer5.Size = new Size(1065, 648);
            splitContainer5.SplitterDistance = 976;
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
            BtnRemoveGraph.Location = new Point(3, 586);
            BtnRemoveGraph.Name = "BtnRemoveGraph";
            BtnRemoveGraph.Size = new Size(74, 55);
            BtnRemoveGraph.TabIndex = 0;
            BtnRemoveGraph.Text = "Remove Graph...";
            BtnRemoveGraph.UseVisualStyleBackColor = true;
            BtnRemoveGraph.Click += BtnRemoveGraph_Click;
            // 
            // BtnClear
            // 
            BtnClear.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            BtnClear.Location = new Point(3, 60);
            BtnClear.Name = "BtnClear";
            BtnClear.Size = new Size(74, 55);
            BtnClear.TabIndex = 0;
            BtnClear.Text = "Clear...";
            BtnClear.UseVisualStyleBackColor = true;
            BtnClear.Click += BtnClear_Click;
            // 
            // BtnAddGraph
            // 
            BtnAddGraph.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            BtnAddGraph.Location = new Point(3, 3);
            BtnAddGraph.Name = "BtnAddGraph";
            BtnAddGraph.Size = new Size(74, 55);
            BtnAddGraph.TabIndex = 0;
            BtnAddGraph.Text = "Add Graph...";
            BtnAddGraph.UseVisualStyleBackColor = true;
            BtnAddGraph.Click += BtnAddGraph_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(28, 28);
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
            exitToolStripMenuItem.Size = new Size(171, 22);
            exitToolStripMenuItem.Text = "&Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(168, 6);
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.Size = new Size(171, 22);
            saveToolStripMenuItem.Text = "&Save data as CSV...";
            saveToolStripMenuItem.Click += saveToolStripMenuItem_Click;
            // 
            // arduinoToolStripMenuItem
            // 
            arduinoToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { connectToolStripMenuItem, disconnectToolStripMenuItem, toolStripMenuItem2, viewUploadExampleToolStripMenuItem });
            arduinoToolStripMenuItem.Name = "arduinoToolStripMenuItem";
            arduinoToolStripMenuItem.Size = new Size(62, 20);
            arduinoToolStripMenuItem.Text = "&Arduino";
            // 
            // connectToolStripMenuItem
            // 
            connectToolStripMenuItem.Name = "connectToolStripMenuItem";
            connectToolStripMenuItem.Size = new Size(203, 22);
            connectToolStripMenuItem.Text = "&Connect...";
            connectToolStripMenuItem.Click += connectToolStripMenuItem_Click;
            // 
            // disconnectToolStripMenuItem
            // 
            disconnectToolStripMenuItem.Name = "disconnectToolStripMenuItem";
            disconnectToolStripMenuItem.Size = new Size(203, 22);
            disconnectToolStripMenuItem.Text = "&Disconnect";
            disconnectToolStripMenuItem.Click += disconnectToolStripMenuItem_Click;
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new Size(200, 6);
            // 
            // viewUploadExampleToolStripMenuItem
            // 
            viewUploadExampleToolStripMenuItem.Name = "viewUploadExampleToolStripMenuItem";
            viewUploadExampleToolStripMenuItem.Size = new Size(203, 22);
            viewUploadExampleToolStripMenuItem.Text = "&View&&Upload example...";
            viewUploadExampleToolStripMenuItem.Click += viewUploadExampleToolStripMenuItem_Click;
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
            // splitContainer6
            // 
            splitContainer6.BorderStyle = BorderStyle.Fixed3D;
            splitContainer6.Dock = DockStyle.Fill;
            splitContainer6.FixedPanel = FixedPanel.Panel2;
            splitContainer6.IsSplitterFixed = true;
            splitContainer6.Location = new Point(0, 0);
            splitContainer6.Name = "splitContainer6";
            // 
            // splitContainer6.Panel1
            // 
            splitContainer6.Panel1.Controls.Add(TXTOutput);
            // 
            // splitContainer6.Panel2
            // 
            splitContainer6.Panel2.Controls.Add(LblMaxLines);
            splitContainer6.Panel2.Controls.Add(TXTMaxLines);
            splitContainer6.Panel2.Controls.Add(chAutoScroll);
            splitContainer6.Panel2.Controls.Add(BtnClearOutput);
            splitContainer6.Size = new Size(1065, 130);
            splitContainer6.SplitterDistance = 976;
            splitContainer6.TabIndex = 2;
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
            TXTOutput.Size = new Size(972, 126);
            TXTOutput.TabIndex = 1;
            // 
            // LblMaxLines
            // 
            LblMaxLines.AutoSize = true;
            LblMaxLines.Location = new Point(-2, 99);
            LblMaxLines.Name = "LblMaxLines";
            LblMaxLines.Size = new Size(37, 15);
            LblMaxLines.TabIndex = 3;
            LblMaxLines.Text = "Lines:";
            // 
            // TXTMaxLines
            // 
            TXTMaxLines.Location = new Point(41, 96);
            TXTMaxLines.Name = "TXTMaxLines";
            TXTMaxLines.Size = new Size(33, 23);
            TXTMaxLines.TabIndex = 2;
            TXTMaxLines.Text = "200";
            TXTMaxLines.TextAlign = HorizontalAlignment.Right;
            // 
            // chAutoScroll
            // 
            chAutoScroll.AutoSize = true;
            chAutoScroll.Checked = true;
            chAutoScroll.CheckState = CheckState.Checked;
            chAutoScroll.Location = new Point(13, 3);
            chAutoScroll.Name = "chAutoScroll";
            chAutoScroll.Size = new Size(55, 34);
            chAutoScroll.TabIndex = 1;
            chAutoScroll.Text = "Auto\r\nScroll";
            chAutoScroll.UseVisualStyleBackColor = true;
            // 
            // BtnClearOutput
            // 
            BtnClearOutput.Location = new Point(3, 36);
            BtnClearOutput.Name = "BtnClearOutput";
            BtnClearOutput.Size = new Size(73, 55);
            BtnClearOutput.TabIndex = 0;
            BtnClearOutput.Text = "Clear";
            BtnClearOutput.UseVisualStyleBackColor = true;
            BtnClearOutput.Click += BtnClearOutput_Click;
            // 
            // statusStrip
            // 
            statusStrip.ImageScalingSize = new Size(28, 28);
            statusStrip.Items.AddRange(new ToolStripItem[] { tsslStatus });
            statusStrip.Location = new Point(0, 130);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new Size(1065, 22);
            statusStrip.TabIndex = 0;
            // 
            // tsslStatus
            // 
            tsslStatus.Name = "tsslStatus";
            tsslStatus.Size = new Size(48, 17);
            tsslStatus.Text = "Status...";
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1065, 828);
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
            splitContainer6.Panel1.ResumeLayout(false);
            splitContainer6.Panel1.PerformLayout();
            splitContainer6.Panel2.ResumeLayout(false);
            splitContainer6.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer6).EndInit();
            splitContainer6.ResumeLayout(false);
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
        private Button BtnMeasure;
        private Button BtnReset;
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
        private SplitContainer splitContainer6;
        private CheckBox chAutoScroll;
        private Button BtnClearOutput;
        private Label LblMaxLines;
        private TextBox TXTMaxLines;
        private Label LblMaxConsoleLines;
        private TextBox TXTMaxConsoleLines;
        private CheckBox chAutoScrollConsole;
        private Button BtnClearConsoleOut;
        private CheckBox chAddTimestamp;
        private Button BtnCalibration;
        private Label LblState;
        private ProgressBar progressBar;
        private ToolStripSeparator toolStripMenuItem2;
        private ToolStripMenuItem viewUploadExampleToolStripMenuItem;
    }
}
