using System.Runtime.InteropServices;

namespace ArduinoGraphViewer
{
    internal static class Program
    {


        public static class DpiHelper
        {
            [DllImport("user32.dll")]
            private static extern bool SetProcessDpiAwarenessContext(int dpiFlag);

            // DPI_AWARENESS_CONTEXT_PER_MONITOR_AWARE_V2 = -4
            public static void EnablePerMonitorV2Awareness()
            {
                const int DPI_AWARENESS_CONTEXT_PER_MONITOR_AWARE_V2 = -4;
                SetProcessDpiAwarenessContext(DPI_AWARENESS_CONTEXT_PER_MONITOR_AWARE_V2);
            }
        }

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //********************************************************************
            //Enable per-monitor DPI awareness (scaling) for Windows 10 and later
            //********************************************************************
            // Set DPI awareness before anything else
            DpiHelper.EnablePerMonitorV2Awareness(); 
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //********************************************************************




            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new MainWindow());
        }
    }
}