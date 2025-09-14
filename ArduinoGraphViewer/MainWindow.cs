using Microsoft.VisualBasic.Logging;
using System;
using System.IO.Ports;
using System.Windows.Forms.DataVisualization.Charting;

namespace ArduinoGraphViewer
{
    public partial class MainWindow : Form
    {
        #region VARS

        private SerialPort _arduino;

        private bool _continue;
        private Thread _workerThread;
        private ManualResetEvent _workerThreadSignalEvent = new ManualResetEvent(false);

        private double _minX = double.MinValue;
        private double _maxX = double.MaxValue;

        private double _minY = double.MinValue;
        private double _maxY = double.MaxValue;

        private DateTime _earliestTime = DateTime.MinValue;
        private DateTime _latestTime = DateTime.MinValue;

        #endregion

        #region ENUMS

        private enum LogType
        {
            Info,
            Warning,
            Error
        }

        #endregion

        #region PROPERTIES

        #endregion

        #region CONSTRUCTORS

        public MainWindow()
        {
            InitializeComponent();
            Init();
        }

        #endregion

        #region FUNCTIONS

        #region INIT

        private void Init()
        {
            try
            {   //Dispose when closing window
                this.FormClosed += MainWindow_FormClosed;

                //Init chart
                _chart.Series.Clear();
                _chart.Legends.Clear();
                _chart.CustomizeLegend += _chart_CustomizeLegend;
                _chart.MouseDoubleClick += _chart_MouseDoubleClick;
                _chart.Legends.Add(new Legend("Legend")
                {
                    Docking = Docking.Top,
                    Alignment = StringAlignment.Far,
                    LegendStyle = LegendStyle.Table,
                    TableStyle = LegendTableStyle.Auto,
                    Font = new Font("Segoe UI", 9),
                    IsTextAutoFit = true,
                    Enabled = true,
                    Title = "Legend"
                });

                rbTimeSeries_CheckedChanged(null, null);

                //Init worker thread
                _workerThread = new Thread(new ThreadStart(TWorker));
                _continue = true;
                _workerThread.IsBackground = true;
                _workerThread.Start();

            }
            catch (Exception ex)
            {
                AddOutputLog($"{ex.Message}", LogType.Error);
            }

        }

        #endregion

        #region GRAPH

        private int FindInsertIndex(DataPointCollection points, double xValue)
        {
            try
            {
                int low = 0;
                int high = points.Count - 1;

                while (low <= high)
                {
                    int mid = (low + high) / 2;
                    double midX = points[mid].XValue;

                    if (midX < xValue)
                        low = mid + 1;
                    else
                        high = mid - 1;
                }

                return low; // This is the correct insert index
            }
            catch (Exception ex)
            {
                AddOutputLog($"{ex.Message}", LogType.Error);
            }
            return -1;

        }

        private void UpdateXAxisTimeSeriesRange()
        {
            try
            {
                var axisX = _chart.ChartAreas["chartArea"].AxisX;
                axisX.Minimum = _earliestTime.AddMinutes(-1).ToOADate();
                axisX.Maximum = _latestTime.AddMinutes(1).ToOADate();

            }
            catch (Exception ex)
            {
                AddOutputLog($"{ex.Message}", LogType.Error);
            }
        }

        private void AddTimeSeriesPoint(string seriesName, DateTime? time, double? value)
        {
            try
            {
                _chart.Invoke(new Action(() =>
                {
                    if (time.HasValue && value.HasValue)
                    {
                        var series = _chart.Series[seriesName];
                        double xValue = time.Value.ToOADate();

                        int index = FindInsertIndex(series.Points, xValue);

                        var point = new DataPoint(xValue, value.Value)
                        {
                            ToolTip = $"Name: {seriesName}\nDate: {time:dd-MM-yyyy}\nTime: {time:HH:mm:ss.fff}\nValue: {value:0.000}"
                        };

                        series.Points.Insert(index, point);

                        bool bUpdateXAxis = false;
                        if (time < _earliestTime || _earliestTime == DateTime.MinValue)
                        {
                            _earliestTime = time.Value;
                            bUpdateXAxis = true;
                        }
                        if (time > _latestTime || _latestTime == DateTime.MinValue)
                        {
                            _latestTime = time.Value;
                            bUpdateXAxis = true;
                        }
                        if (bUpdateXAxis)
                            UpdateXAxisTimeSeriesRange();

                    }
                }));
            }
            catch (Exception ex)
            {
                AddOutputLog($"{ex.Message}", LogType.Error);
            }
        }




        private void AddXYPoint(string seriesName, double? x, double? y)
        {
            try
            {
                _chart.Invoke(new Action(() =>
                {
                    var series = _chart.Series[seriesName];
                    if (x.HasValue && y.HasValue)
                    {
                        var point = new DataPoint(x.Value, y.Value)
                        {
                            ToolTip = $"X: {x.Value:0.000}\nY: {y.Value:0.000}"
                        };
                        series.Points.AddXY(x.Value, y.Value);

                        bool bUpdateXRange = false;
                        if (x.Value < _minX || _minX == double.MinValue)
                        {
                            _minX = x.Value;
                            bUpdateXRange = true;
                        }
                        if (x.Value > _maxX || _maxX == double.MaxValue)
                        {
                            _maxX = x.Value;
                            bUpdateXRange = true;
                        }
                        if (bUpdateXRange)
                            UpdateXAxisRange();

                        bool bUpdateYRange = false;
                        if (y.Value < _minY || _minY == double.MinValue)
                        {
                            _minY = y.Value;
                            bUpdateYRange = true;
                        }
                        if (y.Value > _maxY || _maxY == double.MaxValue)
                        {
                            _maxY = y.Value;
                            bUpdateYRange = true;
                        }
                        if (bUpdateYRange)
                            UpdateYAxisRange();
                    }
                }));
            }
            catch (Exception ex)
            {
                AddOutputLog($"{ex.Message}", LogType.Error);
            }
        }

        private void UpdateXAxisRange()
        {
            try
            {
                var axisX = _chart.ChartAreas["chartArea"].AxisX;
                axisX.Minimum = _minX;
                axisX.Maximum = _maxX;

            }
            catch (Exception ex)
            {
                AddOutputLog($"{ex.Message}", LogType.Error);
            }
        }

        private void UpdateYAxisRange()
        {
            try
            {
                var axisY = _chart.ChartAreas["chartArea"].AxisY;
                axisY.Minimum = _minY;
                axisY.Maximum = _maxY;

            }
            catch (Exception ex)
            {
                AddOutputLog($"{ex.Message}", LogType.Error);
            }
        }


        #endregion


        #endregion

        #region MENU

        #region FILE
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Application.Exit();
            }
            catch (Exception ex)
            {
                AddOutputLog($"{ex.Message}", LogType.Error);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // Implement save functionality here
                AddOutputLog($"Save functionality not implemented yet", LogType.Warning);
            }
            catch (Exception ex)
            {
                AddOutputLog($"{ex.Message}", LogType.Error);
            }
        }

        #endregion

        #region ARDUINO

        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (_arduino == null || !_arduino.IsOpen)
                {
                    var selector = new ComPortSelectorForm();
                    if (selector.ShowDialog() == DialogResult.OK)
                    {
                        _arduino = new SerialPort(selector.SelectedPort, selector.SelectedBaudRate);
                        _arduino.DataReceived += _arduino_DataReceived;
                        _arduino.Open();
                        AddOutputLog($"Connected to Arduino on {selector.SelectedPort}, with baudrate {selector.SelectedBaudRate}", LogType.Info);
                    }
                }
                else
                {
                    AddOutputLog($"Already connected to Arduino", LogType.Warning);
                }
            }
            catch (Exception ex)
            {
                AddOutputLog($"{ex.Message}", LogType.Error);
            }
        }


        private void disconnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (_arduino != null && _arduino.IsOpen)
                {
                    _arduino.Close();
                    AddOutputLog($"Disconnected from Arduino", LogType.Info);
                }
                else
                {
                    AddOutputLog($"Not connected to Arduino", LogType.Warning);
                }
            }
            catch (Exception ex)
            {
                AddOutputLog($"{ex.Message}", LogType.Error);
            }
        }

        #endregion

        #region HELP

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("Arduino Graph Viewer\n\nDeveloped by Steven Persyn\n\nFor more information, visit https://p-tc.be", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                AddOutputLog($"{ex.Message}", LogType.Error);
            }
        }
        #endregion

        #endregion

        #region BUTTONS

        #region CONTROL
        private void BtnStop_Click(object sender, EventArgs e)
        {
            try
            {
                if (_arduino != null && _arduino.IsOpen)
                {
                    _arduino.WriteLine($"stop");
                    AddOutputLog($"Disconnected from Arduino", LogType.Info);
                }
                else
                {
                    AddOutputLog($"Not connected to Arduino", LogType.Warning);
                }
            }
            catch (Exception ex)
            {
                AddOutputLog($"{ex.Message}", LogType.Error);
            }
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            try
            {
                if (_arduino != null && _arduino.IsOpen)
                {
                    _arduino.WriteLine($"start");
                    AddOutputLog($"Disconnected from Arduino", LogType.Info);
                }
                else
                {
                    AddOutputLog($"Not connected to Arduino", LogType.Warning);
                }
            }
            catch (Exception ex)
            {
                AddOutputLog($"{ex.Message}", LogType.Error);
            }
        }

        #endregion

        #region CONSOLE

        private void BtnConsoleSend_Click(object sender, EventArgs e)
        {
            try
            {
                string command = TXTConsoleIn.Text.Trim();
                if (!string.IsNullOrEmpty(command))
                {
                    if (_arduino != null && _arduino.IsOpen)
                    {
                        _arduino.WriteLine(command);
                        AddOutputLog($"Command sent: {command}", LogType.Info);
                    }
                    else
                    {
                        AddOutputLog($"Not connected to Arduino", LogType.Warning);
                    }
                    TXTConsoleIn.Clear();
                }
            }
            catch (Exception ex)
            {
                AddOutputLog($"{ex.Message}", LogType.Error);
            }
        }

        #endregion

        #region GRAPH

        private void BtnAddGraph_Click(object sender, EventArgs e)
        {
            try
            {
                using (var addSeries = new AddSeriesForm())
                {
                    if (addSeries.ShowDialog() == DialogResult.OK)
                    {
                        if (_chart.Series.FindByName(addSeries.SeriesName) == null)
                        {
                            Series series = _chart.Series.Add(addSeries.SeriesName);

                            series.Color = addSeries.SeriesColor;
                            series.ChartType = SeriesChartType.Line;
                            series.MarkerStyle = MarkerStyle.Circle;
                            series.MarkerSize = 6;
                            series.MarkerColor = series.Color;
                            series.Enabled = true;

                            series.ToolTip = "Value: #VAL at #VALX";

                            if (rbTimeSeries.Checked)
                            {
                                series.XValueType = ChartValueType.DateTime;
                                series.YValueType = ChartValueType.Single;
                                AddTimeSeriesPoint(series.Name, DateTime.Now, 10);
                                AddTimeSeriesPoint(series.Name, DateTime.Now.AddSeconds(1), 30);
                                AddTimeSeriesPoint(series.Name, DateTime.Now.AddSeconds(3), 20);
                                AddTimeSeriesPoint(series.Name, DateTime.Now.AddSeconds(8), 50);
                            }
                            else
                            {
                                series.XValueType = ChartValueType.Single;
                                series.YValueType = ChartValueType.Single;
                                AddXYPoint(series.Name, 10, 10);
                                AddXYPoint(series.Name, 20, 30);
                                AddXYPoint(series.Name, 15, 80);
                                AddXYPoint(series.Name, 10, 50);
                            }


                            // Add graph to UI here
                            AddOutputLog($"Graph '{addSeries.SeriesName}' added", LogType.Info);
                        }
                        else
                        {
                            AddOutputLog($"Graph '{addSeries.SeriesName}' already exists", LogType.Warning);
                        }

                    }
                }

            }
            catch (Exception ex)
            {
                AddOutputLog($"{ex.Message}", LogType.Error);
            }
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to clear all data from the graph?", "Clear graph", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    _chart.Series.Clear();
                    if (rbTimeSeries.Checked)
                    {
                        _latestTime = DateTime.MinValue;
                        _earliestTime = DateTime.MinValue;
                    }
                    else
                    {
                        _minX = double.MinValue;
                        _maxX = double.MinValue;
                        _minY = double.MinValue;
                        _maxY = double.MinValue;
                    }
                    AddOutputLog($"Graph cleared", LogType.Info);
                }
            }
            catch (Exception ex)
            {
                AddOutputLog($"{ex.Message}", LogType.Error);
            }
        }

        private void BtnRemoveGraph_Click(object sender, EventArgs e)
        {
            try
            {
                using (var removeSeries = new RemoveSeriesForm(_chart.Series.Select(s => s.Name).ToList()))
                {
                    if (removeSeries.ShowDialog() == DialogResult.OK)
                    {
                        var series = _chart.Series.FindByName(removeSeries.SelectedSeries);
                        if (series != null)
                        {
                            _chart.Series.Remove(series);
                            AddOutputLog($"Graph '{removeSeries.SelectedSeries}' removed", LogType.Info);
                        }
                        else
                        {
                            AddOutputLog($"Graph '{removeSeries.SelectedSeries}' not found", LogType.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                AddOutputLog($"{ex.Message}", LogType.Error);
            }
        }

        #endregion


        #endregion

        #region EVENTHANDLERS

        #region WINDOW

        private void MainWindow_FormClosed(object? sender, FormClosedEventArgs e)
        {
            try
            {
                _continue = false;
                _workerThreadSignalEvent.Set();
                if (_workerThread != null && _workerThread.IsAlive)
                {
                    _workerThread.Join(1000);
                    if (_workerThread.IsAlive)
                    {
                        _workerThread.Abort();
                    }
                }
                if (_arduino != null && _arduino.IsOpen)
                {
                    _arduino.Close();
                }
            }
            catch (Exception ex)
            {
                AddOutputLog($"{ex.Message}", LogType.Error);
            }

        }

        private void TXTConsoleIn_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true; // Prevent ding sound
                    string command = TXTConsoleIn.Text.Trim();
                    if (!string.IsNullOrEmpty(command))
                    {
                        if (_arduino != null && _arduino.IsOpen)
                        {
                            _arduino.WriteLine(command);
                            AddOutputLog($"Command sent: {command}", LogType.Info);
                        }
                        else
                        {
                            AddOutputLog($"Not connected to Arduino", LogType.Warning);
                        }
                        TXTConsoleIn.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                AddOutputLog($"{ex.Message}", LogType.Error);
            }
        }

        private void rbTimeSeries_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rbTimeSeries.Checked)
                {
                    _chart.Series.Clear();
                    _latestTime = DateTime.MinValue;
                    _earliestTime = DateTime.MinValue;

                    _chart.ChartAreas.Clear();
                    _chart.ChartAreas.Add("chartArea");
                    _chart.ChartAreas["chartArea"].AxisX.LabelStyle.Format = "dd-MM-yyyy HH:mm:ss";
                    _chart.ChartAreas["chartArea"].AxisX.IntervalType = DateTimeIntervalType.Auto;
                    _chart.ChartAreas["chartArea"].AxisX.MajorGrid.LineColor = Color.LightGray;
                    _chart.ChartAreas["chartArea"].AxisX.LabelStyle.Angle = -45; // Optional: rotate labels
                    _chart.ChartAreas["chartArea"].AxisX.Enabled = AxisEnabled.True;
                    _chart.ChartAreas["chartArea"].AxisX.Title = "Time";

                    _chart.ChartAreas["chartArea"].AxisY.Title = "Number";
                    _chart.ChartAreas["chartArea"].AxisY.LabelStyle.Format = "0.000";
                    _chart.ChartAreas["chartArea"].AxisY.IntervalAutoMode = IntervalAutoMode.VariableCount;
                    _chart.ChartAreas["chartArea"].AxisY.MajorGrid.LineColor = Color.LightGray;
                    _chart.ChartAreas["chartArea"].AxisY.Enabled = AxisEnabled.True;
                }
            }
            catch (Exception ex)
            {
                AddOutputLog($"{ex.Message}", LogType.Error);
            }
        }

        private void rbXy_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rbXy.Checked)
                {
                    _chart.Series.Clear();
                    _minX = double.MinValue;
                    _maxX = double.MaxValue;
                    _minY = double.MinValue;
                    _maxY = double.MaxValue;

                    _chart.ChartAreas.Clear();
                    _chart.ChartAreas.Add("chartArea");
                    _chart.ChartAreas["chartArea"].AxisX.LabelStyle.Format = "0.000";
                    _chart.ChartAreas["chartArea"].AxisX.IntervalAutoMode = IntervalAutoMode.VariableCount;
                    _chart.ChartAreas["chartArea"].AxisX.MajorGrid.LineColor = Color.LightGray;
                    _chart.ChartAreas["chartArea"].AxisX.LabelStyle.Angle = -45; // Optional: rotate labels
                    _chart.ChartAreas["chartArea"].AxisX.Enabled = AxisEnabled.True;
                    _chart.ChartAreas["chartArea"].AxisX.Title = "Number";

                    _chart.ChartAreas["chartArea"].AxisY.Title = "Number";
                    _chart.ChartAreas["chartArea"].AxisY.LabelStyle.Format = "0.000";
                    _chart.ChartAreas["chartArea"].AxisY.IntervalAutoMode = IntervalAutoMode.VariableCount;
                    _chart.ChartAreas["chartArea"].AxisY.MajorGrid.LineColor = Color.LightGray;
                    _chart.ChartAreas["chartArea"].AxisY.Enabled = AxisEnabled.True;
                }
            }
            catch (Exception ex)
            {
                AddOutputLog($"{ex.Message}", LogType.Error);
            }
        }

        private void _chart_CustomizeLegend(object? sender, CustomizeLegendEventArgs e)
        {
            try
            {
                e.LegendItems.Clear();

                foreach (var series in _chart.Series)
                {
                    var legendItem = new LegendItem
                    {
                        SeriesName = series.Name,
                        Name = series.Name,
                        Color = series.Enabled ? series.Color : Color.Gray,
                        ImageStyle = LegendImageStyle.Line,
                        MarkerStyle = series.MarkerStyle,
                        MarkerColor = series.Enabled ? series.MarkerColor : Color.Gray,
                        MarkerSize = series.MarkerSize
                    };

                    legendItem.Cells.Add(new LegendCell(LegendCellType.SeriesSymbol, "", ContentAlignment.MiddleCenter));
                    legendItem.Cells.Add(new LegendCell(LegendCellType.Text, series.Name, ContentAlignment.MiddleLeft));

                    e.LegendItems.Add(legendItem);
                }

            }
            catch (Exception ex)
            {
                AddOutputLog($"{ex.Message}", LogType.Error);
            }
        }

        private void _chart_MouseDoubleClick(object? sender, MouseEventArgs e)
        {
            try
            {
                HitTestResult result = _chart.HitTest(e.X, e.Y);

                if (result.ChartElementType == ChartElementType.LegendItem)
                {
                    string seriesName = result.Series?.Name ?? result.Object?.ToString();
                    var series = _chart.Series.FindByName(seriesName);

                    if (series != null)
                    {
                        series.Enabled = !series.Enabled;
                        _chart.Invalidate(); // Refresh chart
                    }
                }

            }
            catch (Exception ex)
            {
                AddOutputLog($"{ex.Message}", LogType.Error);
            }
        }

        #endregion

        #region SERIALPORT

        private void _arduino_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                string data = _arduino.ReadLine();
                AddOutputLog($"Data received: {data}", LogType.Info);
                // Process data here


            }
            catch (Exception ex)
            {
                AddOutputLog($"{ex.Message}", LogType.Error);
            }
        }

        #endregion

        #endregion

        #region THREADS


        private void TWorker()
        {
            try
            {
                while (_continue)
                {

                    //Do thread stuff here

                    _workerThreadSignalEvent.WaitOne(100);
                    _workerThreadSignalEvent.Reset();
                }
            }
            catch (Exception ex)
            {
                AddOutputLog($"{ex.Message}", LogType.Error);
            }
        }

        #endregion

        #region CROSS-THREADING

        private void SetText(Control c, string text)
        {
            if (c.InvokeRequired)
            {
                c.Invoke(new Action<Control, string>(SetText), text);
            }
            else
            {
                c.Text = text;
            }
        }

        private void AppendText(Control c, string text)
        {
            if (c.InvokeRequired)
            {
                c.Invoke(new Action<Control, string>(AppendText), text);
            }
            else
            {
                c.Text += text;
            }
        }

        private void AddOutputLog(string log, LogType logType)
        {
            if (TXTOutput.InvokeRequired)
            {
                TXTOutput.Invoke(new Action<string, LogType>(AddOutputLog), log, logType);
            }
            else
            {
                TXTOutput.AppendText($"{DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss.fff")} | {Enum.GetName(typeof(LogType), logType)} | {log}" + Environment.NewLine);
            }
        }

        #endregion



    }
}
