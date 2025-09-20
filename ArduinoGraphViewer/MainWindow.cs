using Microsoft.VisualBasic.Logging;
using System;
using System.Globalization;
using System.IO.Ports;
using System.Text;
using System.Windows.Forms.DataVisualization.Charting;

namespace ArduinoGraphViewer
{
    public partial class MainWindow : Form
    {
        #region VARS

        private bool _bInitBusy = true;

        private StringBuilder _serialBuffer = new StringBuilder();
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

                tsslStatus.Text = "Not connected";

            }
            catch (Exception ex)
            {
                AddOutputLog($"{ex.Message}", LogType.Error);
            }

        }

        #endregion

        #region GRAPH

        private bool AddGraph(string SeriesName, Color SeriesColor)
        {
            try
            {
                if (_chart.Series.FindByName(SeriesName) == null)
                {
                    Series series = _chart.Series.Add(SeriesName);

                    series.Color = SeriesColor;
                    series.ChartType = SeriesChartType.Line;
                    series.MarkerStyle = MarkerStyle.Circle;
                    series.MarkerSize = 6;
                    series.MarkerColor = series.Color;
                    series.Enabled = true;

                    series.ToolTip = "Value: #VAL at #VALX";

                    if (rbTimeSeries.Checked)
                    {
                        if (_dgv.Columns[series.Name + "_Time"] == null)
                        {
                            _dgv.Columns.Add(series.Name + "_Time", series.Name + "_Time");
                            _dgv.Columns[series.Name + "_Time"].Width = 150;
                            _dgv.Columns[series.Name + "_Time"].SortMode = DataGridViewColumnSortMode.NotSortable;
                            _dgv.Columns[series.Name + "_Time"].DefaultCellStyle.BackColor = series.Color;
                        }
                        if (_dgv.Columns[series.Name] == null)
                        {
                            _dgv.Columns.Add(series.Name, series.Name);
                            _dgv.Columns[series.Name].Width = 80;
                            _dgv.Columns[series.Name].SortMode = DataGridViewColumnSortMode.NotSortable;
                            _dgv.Columns[series.Name].DefaultCellStyle.BackColor = series.Color;
                        }

                        series.XValueType = ChartValueType.DateTime;
                        series.YValueType = ChartValueType.Single;

                        //Example data
                        //AddTimeSeriesPoint(series.Name, DateTime.Now, 10);
                        //AddTimeSeriesPoint(series.Name, DateTime.Now.AddSeconds(1), 30);
                        //AddTimeSeriesPoint(series.Name, DateTime.Now.AddSeconds(3), 20);
                        //AddTimeSeriesPoint(series.Name, DateTime.Now.AddSeconds(8), 50);
                    }
                    else
                    {
                        if (_dgv.Columns[series.Name + "_X"] == null)
                        {
                            _dgv.Columns.Add(series.Name + "_X", series.Name + "_X");
                            _dgv.Columns[series.Name + "_X"].Width = 80;
                            _dgv.Columns[series.Name + "_X"].SortMode = DataGridViewColumnSortMode.NotSortable;
                            _dgv.Columns[series.Name + "_X"].DefaultCellStyle.BackColor = series.Color;
                        }
                        if (_dgv.Columns[series.Name + "_Y"] == null)
                        {
                            _dgv.Columns.Add(series.Name + "_Y", series.Name + "_Y");
                            _dgv.Columns[series.Name + "_Y"].Width = 80;
                            _dgv.Columns[series.Name + "_Y"].SortMode = DataGridViewColumnSortMode.NotSortable;
                            _dgv.Columns[series.Name + "_Y"].DefaultCellStyle.BackColor = series.Color;
                        }

                        series.XValueType = ChartValueType.Single;
                        series.YValueType = ChartValueType.Single;

                        //Example data
                        //AddXYPoint(series.Name, 10, 10);
                        //AddXYPoint(series.Name, 20, 30);
                        //AddXYPoint(series.Name, 15, 80);
                        //AddXYPoint(series.Name, 10, 50);
                    }


                    // Add graph to UI here
                    AddOutputLog($"Graph '{SeriesName}' added", LogType.Info);
                    return true;
                }
                else
                {
                    AddOutputLog($"Graph '{SeriesName}' already exists", LogType.Warning);
                }
            }
            catch (Exception ex)
            {
                AddOutputLog($"{ex.Message}", LogType.Error);
            }
            return false;
        }

        private bool RemoveGraph(string SeriesName)
        {
            try
            {
                var series = _chart.Series.FindByName(SeriesName);
                if (series != null)
                {
                    _chart.Series.Remove(series);
                    if (_dgv.Columns[series.Name] != null)
                        _dgv.Columns.Remove(series.Name);
                    if (_dgv.Columns[series.Name + "_Time"] != null)
                        _dgv.Columns.Remove(series.Name + "_Time");
                    if (_dgv.Columns[series.Name + "_X"] != null)
                        _dgv.Columns.Remove(series.Name + "_X");
                    if (_dgv.Columns[series.Name + "_Y"] != null)
                        _dgv.Columns.Remove(series.Name + "_Y");
                    AddOutputLog($"Graph '{SeriesName}' removed", LogType.Info);
                    return true;
                }
                else
                {
                    AddOutputLog($"Graph '{SeriesName}' not found", LogType.Warning);
                }
            }
            catch (Exception ex)
            {
                AddOutputLog($"{ex.Message}", LogType.Error);
            }
            return false;
        }

        private bool ClearGraphs()
        {
            try
            {
                foreach (var series in _chart.Series)
                {
                    series.Points.Clear();
                }
                _dgv.Rows.Clear();
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
                return true;
            }
            catch (Exception ex)
            {
                AddOutputLog($"{ex.Message}", LogType.Error);
            }
            return false;
        }




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

                        int rowIndex = FindInsertIndex(series.Points, xValue);

                        var point = new DataPoint(xValue, value.Value)
                        {
                            ToolTip = $"Name: {seriesName}\nDate: {time:dd-MM-yyyy}\nTime: {time:HH:mm:ss.fff}\nValue: {value:0.000}"
                        };

                        series.Points.Insert(rowIndex, point);
                        while (series.Points.Count > _dgv.Rows.Count)
                        {
                            _dgv.Rows.Add();
                        }

                        if (rowIndex >= 0 && rowIndex < _dgv.Rows.Count)
                        {
                            var row = _dgv.Rows[rowIndex];
                            if (_dgv.Columns[series.Name + "_Time"] != null)
                                row.Cells[series.Name + "_Time"].Value = time.Value.ToString("dd-MM-yyyy HH:mm:ss.fff");
                            if (_dgv.Columns[series.Name] != null)
                                row.Cells[series.Name].Value = value.Value.ToString("0.000");
                        }


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
                        int rowIndex = series.Points.AddXY(x.Value, y.Value);
                        while (series.Points.Count > _dgv.Rows.Count)
                        {
                            _dgv.Rows.Add();
                        }

                        if (rowIndex >= 0 && rowIndex < _dgv.Rows.Count)
                        {
                            var row = _dgv.Rows[rowIndex];
                            if (_dgv.Columns[series.Name + "_X"] != null)
                                row.Cells[series.Name + "_X"].Value = x.Value.ToString("0.000");
                            if (_dgv.Columns[series.Name + "_Y"] != null)
                                row.Cells[series.Name + "_Y"].Value = y.Value.ToString("0.000");
                        }

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

        #region CSV

        public void ExportDataGridViewToCsv(DataGridView dgv, string filePath)
        {
            var sb = new StringBuilder();

            // Write headers
            var headers = dgv.Columns.Cast<DataGridViewColumn>()
                .Select(col => "\"" + col.HeaderText.Replace("\"", "\"\"") + "\"");
            sb.AppendLine(string.Join(";", headers));

            // Write rows
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (!row.IsNewRow)
                {
                    var cells = row.Cells.Cast<DataGridViewCell>()
                        .Select(cell => "\"" + cell.Value?.ToString().Replace("\"", "\"\"") + "\"");
                    sb.AppendLine(string.Join(";", cells));
                }
            }

            File.WriteAllText(filePath, sb.ToString(), Encoding.UTF8);
        }


        #endregion

        #region CONSOLE

        private void HandleHelp()
        {
            try
            {
                AddConsoleOut("Available commands:", true);
                AddConsoleOut("-----------------------", true);
                AddConsoleOut(" ", true);
                AddConsoleOut("help - Show this help message", true);
                AddConsoleOut("clear - Clear the console output", true);
                AddConsoleOut("example - outputs an example arduino project", true);
                AddConsoleOut("<command> - execute a specific command on the Arduino", true);
                AddConsoleOut(" ", true);
                AddConsoleOut("Possible replies:", true);
                AddConsoleOut("-----------------", true);
                AddConsoleOut("#<seriesname>|<value> - adds a point to an existing Time series matching the seriesname (PC time for timestamp)", true);
                AddConsoleOut("#<seriesname>|<datetime>|<value> - adds a point to an existing Time series matching the seriesname", true);
                AddConsoleOut("#<seriesname>|<value>|<value> - adds a point to an existing Value series matching the seriesname", true);
                AddConsoleOut("!<command>|<state>|<reply> - reply format to be handled by this application", true);
                AddConsoleOut("?<command> - command to be handled by this application", true);
            }
            catch (Exception ex)
            {
                AddOutputLog($"{ex.Message}", LogType.Error);
            }

        }

        private void HandleConsoleIn(string command)
        {
            try
            {
                if (!string.IsNullOrEmpty(command))
                {
                    switch (command.ToLower())
                    {
                        case "help":
                            HandleHelp();
                            break;
                        case "clear":
                            TXTConsoleOut.Clear();
                            break;
                        case "example":
                            AddConsoleOut("Example Arduino code:", true);
                            AddConsoleOut("---------------------", true);
                            AddConsoleOut(@"

String inputBuffer = """";
bool commandInProgress = false;
bool start = false;
unsigned long long prevTime;
unsigned long long currentTime;

void setup() {
  Serial.begin(9600);
  while (!Serial); // Wait for serial connection (optional for Leonardo/Micro)
  Serial.println(""Arduino ready."");
}

void loop() {
  //timer
  currentTime = micros();
  
  // Read incoming characters
  if(Serial.available() > 0) {
    char c = Serial.read();

    if (c == '\n' || c == '\r') {
      if (inputBuffer.length() > 0) {
        handleCommand(inputBuffer);
        inputBuffer = """";
      }
    } else {
      inputBuffer += c;
    }
  }

  //process
  if(start)
  {
    if(currentTime-prevTime > 1000000)
    {
      //update time
      prevTime = currentTime;
      float temp = analogRead(A0) * (5.0 / 1023.0) * 100; // Example conversion
      Serial.println(""#temp|"" + String(temp, 2));
    }  
  }
}

void handleCommand(String cmd) {
  cmd.trim(); // Remove whitespace
  Serial.println(""!"" + cmd +""|success|ack"");
  // Command logic
  if (cmd == ""start"") {
    Serial.println(""!start|success|started"");
    start = true;
  } else if (cmd == ""stop"") {
        Serial.println(""!stop|success|stopped"");
        start = false;
  } else {
    Serial.println(""!unknown command|fail|not a valid command"");
  }
}

", true);
                            break;
                        default:
                            if (_arduino != null && _arduino.IsOpen)
                            {
                                _arduino.WriteLine(command);
                                AddOutputLog($"Command sent: {command}", LogType.Info);
                            }
                            else
                            {
                                AddOutputLog($"Not connected to Arduino", LogType.Warning);
                            }
                            AddConsoleOut(command, false);
                            break;
                    }
                    TXTConsoleIn.Clear();
                }
                else
                {
                    AddOutputLog($"Please enter a command", LogType.Warning);
                }
            }
            catch (Exception ex)
            {
                AddOutputLog($"{ex.Message}", LogType.Error);
            }

        }

        #endregion

        #region ARDUINO

        private void HandleReceivedSerialData(string data)
        {
            try
            {
                // Process data here
                if (!string.IsNullOrEmpty(data) && data.Length > 0)
                {
                    string[] parts;
                    switch (data[0])
                    {
                        case '#':

                            //handle data points for the graph
                            //----------------------------------------
                            parts = data.Substring(1).Split('|');
                            string seriesName;
                            switch (parts.Length)
                            {
                                case 0:
                                    AddOutputLog($"No data received after #", LogType.Warning);
                                    return;
                                case 1:
                                    AddOutputLog($"Not enough data received after #, it should be: #<seriesname>|<value> or #<seriesname>|<datetime>|<value> or #<seriesname>|<value>|<value>", LogType.Warning);
                                    return;
                                case 2:
                                    //correct format
                                    seriesName = parts[0];
                                    if (_chart.Series.FindByName(seriesName) != null)
                                    {
                                        if (rbTimeSeries.Checked)
                                        {
                                            if (double.TryParse(parts[1], CultureInfo.InvariantCulture, out double value))
                                            {
                                                AddTimeSeriesPoint(seriesName, DateTime.Now, value);
                                            }
                                            else
                                            {
                                                AddOutputLog($"Value is not a valid number: '{parts[1]}'", LogType.Warning);
                                            }
                                        }
                                        else
                                        {
                                            AddOutputLog($"Not enough data received after #, it should be: #<seriesname>|<value>|<value>", LogType.Warning);
                                        }
                                    }
                                    else
                                    {
                                        AddOutputLog($"Received data for unknown series '{seriesName}'", LogType.Warning);
                                    }
                                    break;
                                case 3:
                                    //correct format
                                    seriesName = parts[0];
                                    if (_chart.Series.FindByName(seriesName) != null)
                                    {
                                        if (rbTimeSeries.Checked)
                                        {
                                            if (DateTime.TryParse(parts[1], CultureInfo.InvariantCulture, out DateTime time) && double.TryParse(parts[2], CultureInfo.InvariantCulture, out double value))
                                            {
                                                AddTimeSeriesPoint(seriesName, time, value);
                                            }
                                            else
                                            {
                                                AddOutputLog($"DateTime is not valid: '{parts[1]}' or Value is not a valid number: '{parts[2]}'", LogType.Warning);
                                            }
                                        }
                                        else
                                        {
                                            if (double.TryParse(parts[1], CultureInfo.InvariantCulture, out double x) && double.TryParse(parts[2], CultureInfo.InvariantCulture, out double y))
                                            {
                                                AddXYPoint(seriesName, x, y);
                                            }
                                            else
                                            {
                                                AddOutputLog($"X is not a valid number: '{parts[1]}' or Y is not a valid number: '{parts[2]}'", LogType.Warning);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        AddOutputLog($"Received data for unknown series '{seriesName}'", LogType.Warning);
                                    }
                                    break;
                                default:
                                    AddOutputLog($"Too much data received after #, it should be: #<seriesname>|<value> or #<seriesname>|<datetime>|<value> or #<seriesname>|<value>|<value>", LogType.Warning);
                                    return;
                            }

                            break;
                        case '!':
                            //handle reply from commands sent to the arduino
                            //----------------------------------------
                            parts = data.Substring(1).Split('|');
                            if (parts.Length == 3)
                            {
                                string? command = parts[0].ToLower();
                                string? state = parts[1];
                                string? reply = parts[2];
                                if (!string.IsNullOrWhiteSpace(state) && state == "success")
                                {
                                    AddOutputLog($"Command '{command ?? ""}' executed successfully. Reply: {reply ?? ""}", LogType.Info);
                                    //Handle specific command reply
                                    switch (command)
                                    {
                                        case "stop":
                                            // Handle stop command if needed
                                            break;
                                        case "start":
                                            // Handle start command if needed
                                            break;
                                        default:
                                            // Handle other commands if needed
                                            break;
                                    }
                                }
                                else
                                {
                                    AddOutputLog($"Command '{command ?? ""}' execution failed. Reply: {reply ?? ""}", LogType.Warning);
                                }
                            }
                            else
                            {
                                AddOutputLog($"Unexpected ! format, it should be: !<command>|<state>|<reply>, we expect the state to be success", LogType.Warning);
                            }
                            break;
                        case '?':

                            //handle commands comming from the arduino
                            //----------------------------------------
                            parts = data.Substring(1).Split('|');
                            switch (parts.Length)
                            {
                                case 0:
                                    AddOutputLog($"No command received after ?", LogType.Warning);
                                    break;
                                case 1:
                                    string? command = parts[0].ToLower();
                                    if (!string.IsNullOrWhiteSpace(command))
                                    {
                                        switch (command)
                                        {
                                            case "clear":
                                                BtnClear.Invoke(new Action(() => { ClearGraphs(); }));
                                                break;
                                            case "calib":
                                                BtnCalibration.Invoke(new Action(() => { BtnCalibration_Click(null, null); }));
                                                break;
                                            case "reset":
                                                BtnReset.Invoke(new Action(() => { BtnReset_Click(null, null); }));
                                                break;
                                            case "measure":
                                                BtnMeasure.Invoke(new Action(() => { BtnMeasure_Click(null, null); }));
                                                break;
                                            default:
                                                AddOutputLog($"Unkown command '{command ?? ""}'!", LogType.Warning);
                                                break;
                                        }
                                        AddOutputLog($"Command '{command ?? ""}' executed!", LogType.Info);
                                    }
                                    else
                                    {
                                        AddOutputLog($"Command '{command ?? ""}' execution failed. Unkown command type!", LogType.Warning);
                                    }
                                    break;
                                case 2:
                                    command = parts[0].ToLower();
                                    string? param1 = parts[1];
                                    if (!string.IsNullOrWhiteSpace(command))
                                    {
                                        switch (command)
                                        {
                                            case "switch":
                                                param1 = param1?.ToLower();
                                                if (string.IsNullOrWhiteSpace(param1))
                                                {
                                                    AddOutputLog($"Command '{command ?? ""}' execution failed. Param1 (time or xy) is required!", LogType.Warning);
                                                    break;
                                                }
                                                rbTimeSeries.Invoke(new Action(() =>
                                                {
                                                    switch (param1)
                                                    {
                                                        case "time":
                                                            if (!rbTimeSeries.Checked)
                                                                rbTimeSeries.Checked = true;
                                                            break;
                                                        case "xy":
                                                            if (!rbXy.Checked)
                                                                rbXy.Checked = true;
                                                            break;
                                                        default:
                                                            AddOutputLog($"Command '{command ?? ""}' execution failed. Param1 (time or xy) is invalid!", LogType.Warning);
                                                            break;
                                                    }
                                                }));
                                                break;
                                            case "remove":
                                                if (string.IsNullOrWhiteSpace(param1))
                                                {
                                                    AddOutputLog($"Command '{command ?? ""}' execution failed. Param1 (series name) is required!", LogType.Warning);
                                                    break;
                                                }
                                                BtnRemoveGraph.Invoke(new Action(() => { RemoveGraph(param1); }));
                                                break;
                                            default:
                                                AddOutputLog($"Unkown command '{command ?? ""}'!", LogType.Warning);
                                                break;
                                        }
                                        AddOutputLog($"Command '{command ?? ""}' executed!", LogType.Info);
                                    }
                                    else
                                    {
                                        AddOutputLog($"Command '{command ?? ""}' execution failed. Unkown command type!", LogType.Warning);
                                    }
                                    break;
                                case 3:
                                    command = parts[0].ToLower();
                                    param1 = parts[1];
                                    string? param2 = parts[2];
                                    if (!string.IsNullOrWhiteSpace(command))
                                    {
                                        switch (command)
                                        {
                                            case "add":
                                                if (string.IsNullOrWhiteSpace(param1))
                                                {
                                                    AddOutputLog($"Command '{command ?? ""}' execution failed. Param1 (series name) is required!", LogType.Warning);
                                                    break;
                                                }
                                                Color color = Enum.Equals(param2, null) || string.IsNullOrWhiteSpace(param2) ? Color.Black : Color.FromName(param2);
                                                BtnAddGraph.Invoke(new Action(() => { AddGraph(param1, color); }));
                                                break;
                                            default:
                                                AddOutputLog($"Unkown command '{command ?? ""}'!", LogType.Warning);
                                                break;
                                        }
                                        AddOutputLog($"Command '{command ?? ""}' executed!", LogType.Info);
                                    }
                                    else
                                    {
                                        AddOutputLog($"Command '{command ?? ""}' execution failed. Unkown command type!", LogType.Warning);
                                    }
                                    break;
                                default:
                                    AddOutputLog($"Unexpected ? format, it should be: ?<command>|param1|param2 to be executed - params are only needed for some commands!", LogType.Warning);
                                    break;
                            }
                            break;
                        default:
                            //regular console output
                            AddConsoleOut(data);
                            break;
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
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                    sfd.Title = "Save Data to CSV";
                    sfd.FileName = "GraphData.csv";
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        ExportDataGridViewToCsv(_dgv, sfd.FileName);
                        AddOutputLog($"Data exported to {sfd.FileName}", LogType.Info);
                    }
                }
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
                        tsslStatus.Text = $"Connected to {selector.SelectedPort} at {selector.SelectedBaudRate} baud";
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
                    tsslStatus.Text = "Not connected";
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
        private void BtnCalibration_Click(object sender, EventArgs e)
        {
            try
            {
                if (_arduino != null && _arduino.IsOpen)
                {
                    _arduino.WriteLine($"calib");
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

        private void BtnReset_Click(object sender, EventArgs e)
        {
            try
            {
                if (_arduino != null && _arduino.IsOpen)
                {
                    _arduino.WriteLine($"reset");
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

        private void BtnMeasure_Click(object sender, EventArgs e)
        {
            try
            {
                if (_arduino != null && _arduino.IsOpen)
                {
                    _arduino.WriteLine($"measure");
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
                HandleConsoleIn(command);
            }
            catch (Exception ex)
            {
                AddOutputLog($"{ex.Message}", LogType.Error);
            }
        }

        private void BtnClearConsoleOut_Click(object sender, EventArgs e)
        {
            try
            {
                TXTConsoleOut.Clear();
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
                        AddGraph(addSeries.SeriesName, addSeries.SeriesColor);
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
                    ClearGraphs();
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
                        RemoveGraph(removeSeries.SelectedSeries);
                    }
                }
            }
            catch (Exception ex)
            {
                AddOutputLog($"{ex.Message}", LogType.Error);
            }
        }

        #endregion

        #region OUTPUT

        private void BtnClearOutput_Click(object sender, EventArgs e)
        {
            try
            {
                TXTOutput.Clear();
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
                    HandleConsoleIn(command);
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
                    if (!_bInitBusy)
                    {
                        if (MessageBox.Show("Switching to Time Series mode will clear the current graph and data. Do you want to continue?", "Switch Mode", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        {
                            rbXy.CheckedChanged -= rbXy_CheckedChanged;
                            rbXy.Checked = true;
                            rbXy.CheckedChanged += rbXy_CheckedChanged;
                            return;
                        }
                    }
                    _bInitBusy = false;


                    _chart.Series.Clear();
                    _dgv.Rows.Clear();
                    _dgv.Columns.Clear();
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
                    if (MessageBox.Show("Switching to XY mode will clear the current graph and data. Do you want to continue?", "Switch Mode", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        rbTimeSeries.CheckedChanged -= rbTimeSeries_CheckedChanged;
                        rbTimeSeries.Checked = true;
                        rbTimeSeries.CheckedChanged += rbTimeSeries_CheckedChanged;
                        return;
                    }
                    _chart.Series.Clear();
                    _minX = double.MinValue;
                    _maxX = double.MaxValue;
                    _minY = double.MinValue;
                    _maxY = double.MaxValue;

                    _chart.ChartAreas.Clear();
                    _dgv.Rows.Clear();
                    _dgv.Columns.Clear();
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

                        var column = _dgv.Columns[series.Name + "_Time"];
                        if (column != null)
                            column.Visible = series.Enabled;

                        column = _dgv.Columns[series.Name];
                        if (column != null)
                            column.Visible = series.Enabled;

                        column = _dgv.Columns[series.Name + "_X"];
                        if (column != null)
                            column.Visible = series.Enabled;

                        column = _dgv.Columns[series.Name + "_Y"];
                        if (column != null)
                            column.Visible = series.Enabled;

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

                string incoming = _arduino.ReadExisting(); // Non-blocking
                _serialBuffer.Append(incoming);

                while (_serialBuffer.ToString().Contains("\n"))
                {
                    string fullBuffer = _serialBuffer.ToString();
                    int newlineIndex = fullBuffer.IndexOf('\n');

                    string line = fullBuffer.Substring(0, newlineIndex).Trim('\r', '\n');
                    _serialBuffer.Remove(0, newlineIndex + 1);

                    // Now you have a complete line — process it
                    HandleReceivedSerialData(line);
                }

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
                // Split current lines
                var lines = TXTOutput.Lines.ToList();

                // Add new line
                lines.Add($"{DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss.fff")} | {Enum.GetName(typeof(LogType), logType)} | {log}");

                // Keep only the last x lines
                int maxLines = 200;
                int.TryParse(TXTMaxLines.Text, CultureInfo.InvariantCulture, out maxLines);

                if (lines.Count > maxLines)
                    lines = lines.Skip(lines.Count - maxLines).ToList();

                // Update textbox
                TXTOutput.Lines = lines.ToArray();

                // Scroll to bottom
                if (chAutoScroll.Checked)
                {
                    TXTOutput.SelectionStart = TXTOutput.TextLength;
                    TXTOutput.ScrollToCaret();
                }

            }
        }

        private void AddConsoleOut(string data, bool dataIn = true)
        {
            if (TXTConsoleOut.InvokeRequired)
            {
                TXTConsoleOut.Invoke(new Action<string, bool>(AddConsoleOut), data, dataIn);
            }
            else
            {
                // Split current lines
                var lines = TXTConsoleOut.Lines.ToList();

                // Add new line
                StringBuilder sb = new StringBuilder();
                sb.Append(dataIn ? ">> " : "<< ");
                if (chAddTimestamp.Checked)
                    sb.Append($"{DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss.fff")} | ");
                sb.Append(data);
                lines.Add(sb.ToString());

                // Keep only the last x lines
                int maxLines = 200;
                int.TryParse(TXTMaxConsoleLines.Text, CultureInfo.InvariantCulture, out maxLines);

                if (lines.Count > maxLines)
                    lines = lines.Skip(lines.Count - maxLines).ToList();

                // Update textbox
                TXTConsoleOut.Lines = lines.ToArray();

                // Scroll to bottom
                if (chAutoScrollConsole.Checked)
                {
                    TXTConsoleOut.SelectionStart = TXTConsoleOut.TextLength;
                    TXTConsoleOut.ScrollToCaret();
                }
            }
        }


        #endregion

    }
}
