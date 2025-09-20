using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ArduinoGraphViewer.ArduinoUploader;

namespace ArduinoGraphViewer
{
    public static class ArduinoBoardFqbnExtensions
    {
        public static string ToFqbnString(this ArduinoBoardFqbn board)
        {
            return board switch
            {
                ArduinoBoardFqbn.ArduinoUno => "arduino:avr:uno",
                ArduinoBoardFqbn.ArduinoMega2560 => "arduino:avr:mega",
                ArduinoBoardFqbn.ArduinoNano => "arduino:avr:nano",
                ArduinoBoardFqbn.ArduinoLeonardo => "arduino:avr:leonardo",
                ArduinoBoardFqbn.ArduinoMicro => "arduino:avr:micro",
                ArduinoBoardFqbn.ArduinoDue => "arduino:sam:due",
                ArduinoBoardFqbn.ArduinoMKRZero => "arduino:samd:mkrzero",
                ArduinoBoardFqbn.ArduinoMKR1000 => "arduino:samd:mkr1000",
                ArduinoBoardFqbn.ArduinoNano33IoT => "arduino:samd:nano_33_iot",
                _ => throw new ArgumentOutOfRangeException(nameof(board), board, null)
            };
        }
    }

    public class ArduinoUploader
    {
        public enum ArduinoBoardFqbn
        {
            ArduinoUno,           // arduino:avr:uno
            ArduinoMega2560,      // arduino:avr:mega
            ArduinoNano,          // arduino:avr:nano
            ArduinoLeonardo,      // arduino:avr:leonardo
            ArduinoMicro,         // arduino:avr:micro
            ArduinoDue,           // arduino:sam:due
            ArduinoMKRZero,       // arduino:samd:mkrzero
            ArduinoMKR1000,       // arduino:samd:mkr1000
            ArduinoNano33IoT      // arduino:samd:nano_33_iot
        }

        private static bool IsArduinoCliAvailable()
        {
            try
            {
                string appFolder = AppDomain.CurrentDomain.BaseDirectory;
                string cliPath = Path.Combine(appFolder, "arduino-cli.exe");


                var process = new Process();
                process.StartInfo.FileName = cliPath;// "arduino-cli";
                process.StartInfo.Arguments = "version";
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.RedirectStandardOutput = true;
                process.Start();
                string output = process.StandardOutput.ReadToEnd();
                process.WaitForExit();
                return output.Contains("arduino-cli");
            }
            catch
            {
                return false;
            }
        }

        private static bool IsCoreInstalled(string cliPath, string fqbn, out string outputCLI)
        {
            outputCLI = "";
            try
            {
                string platform = fqbn.Split(':')[0] + ":" + fqbn.Split(':')[1]; // e.g., "arduino:avr"
                var process = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = cliPath,
                        Arguments = "core list",
                        CreateNoWindow = true,
                        UseShellExecute = false,
                        RedirectStandardOutput = true
                    }
                };

                process.Start();
                string output = process.StandardOutput.ReadToEnd();
                process.WaitForExit();

                outputCLI = "🔍 Checking installed cores..." + Environment.NewLine;
                bool result = output.Contains(platform);
                if (result)
                    outputCLI += $"✅ Core {platform} is already installed." + Environment.NewLine;
                else
                    outputCLI += $"❌ Core {platform} is not installed." + Environment.NewLine;
                return result;
            }
            catch (Exception ex)
            {
                outputCLI = $"❌ Core installation check failed: {ex.Message}" + Environment.NewLine;
                return false;
            }

        }

        private static bool InstallCore(string cliPath, string fqbn, out string outputCLI)
        {
            outputCLI = "";
            try
            {
                StringBuilder outputBuilder = new StringBuilder();

                string platform = fqbn.Split(':')[0] + ":" + fqbn.Split(':')[1]; // e.g., "arduino:avr"
                var process = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = cliPath,
                        Arguments = $"core install {platform}",
                        UseShellExecute = false,
                        CreateNoWindow = true,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true
                    }
                };

                process.Start();
                string output = process.StandardOutput.ReadToEnd();
                string error = process.StandardError.ReadToEnd();
                process.WaitForExit();

                outputBuilder.AppendLine("📦 Core Install Output:");
                outputBuilder.AppendLine(output);

                if (!string.IsNullOrWhiteSpace(error))
                {
                    outputBuilder.AppendLine("⚠️ Core Install Errors:");
                    outputBuilder.AppendLine(error);
                    outputCLI = outputBuilder.ToString();
                    return false;
                }
                else
                {
                    outputBuilder.AppendLine("✅ Core installed successfully.");
                    outputCLI = outputBuilder.ToString();
                    return true;
                }
            }
            catch (Exception ex)
            {
                outputCLI = $"❌ Core installation failed: {ex.Message}" + Environment.NewLine;
                return false;
            }

        }

        private static bool CompileSketch(string cliPath, string sketchPath, string fqbn, out string outputCLI)
        {
            outputCLI = "";
            try
            {
                StringBuilder outputBuilder = new StringBuilder();
                var process = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = cliPath,
                        Arguments = $"compile --fqbn {fqbn} \"{sketchPath}\"",
                        UseShellExecute = false,
                        CreateNoWindow = true,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true
                    }
                };

                process.Start();
                string output = process.StandardOutput.ReadToEnd();
                string error = process.StandardError.ReadToEnd();
                process.WaitForExit();

                outputBuilder.AppendLine("🛠️ Compile Output:");
                outputBuilder.AppendLine(output);
                if (!string.IsNullOrWhiteSpace(error))
                {
                    outputBuilder.AppendLine("⚠️ Compile Errors:");
                    outputBuilder.AppendLine(error);
                }

                outputCLI = outputBuilder.ToString();
                bool result = process.ExitCode == 0;
                if (result)
                    outputCLI += "✅ Compilation successful." + Environment.NewLine;
                else
                    outputCLI += "❌ Compilation failed." + Environment.NewLine;
                return result;
            }
            catch (Exception ex)
            {
                outputCLI = $"❌ Compilation failed: {ex.Message}" + Environment.NewLine;
                return false;
            }

        }

        private static bool UploadSketch(string cliPath, string sketchPath, string port, string fqbn, out string outputCLI)
        {
            outputCLI = "";
            try
            {
                StringBuilder outputBuilder = new StringBuilder();

                var process = new Process();
                process.StartInfo.FileName = cliPath;// "arduino-cli";
                process.StartInfo.Arguments = $"upload --port {port} --fqbn {fqbn} \"{sketchPath}\"";
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true;
                process.Start();
                string output = process.StandardOutput.ReadToEnd();
                string error = process.StandardError.ReadToEnd();
                process.WaitForExit();

                outputBuilder.AppendLine("📤 Upload Output:");
                outputBuilder.AppendLine(output);

                if (!string.IsNullOrWhiteSpace(error))
                {
                    outputBuilder.AppendLine("⚠️ Upload Errors:");
                    outputBuilder.AppendLine(error);
                    outputCLI = outputBuilder.ToString();
                    return false;
                }
                else
                {
                    outputBuilder.AppendLine("✅ Upload successful.");
                    outputCLI = outputBuilder.ToString();
                    return true;
                }
            }
            catch (Exception ex)
            {
                outputCLI = $"❌ Upload failed: {ex.Message}" + Environment.NewLine;
                return false;
            }

        }

        private static string GetPersistentSketchFolder()
        {
            string sketchFolder = Path.Combine(Path.GetTempPath(), "ArduinoSketch");
            Directory.CreateDirectory(sketchFolder);
            return sketchFolder;
        }

        private static string WriteSketchToFile(string code)
        {
            string sketchFolder = GetPersistentSketchFolder();
            string sketchFile = Path.Combine(sketchFolder, "ArduinoSketch.ino");
            File.WriteAllText(sketchFile, code);
            return sketchFolder;
        }




        public static bool CompileAndUploadSketch(string arduinoCode, string port, ArduinoBoardFqbn fqbn, out string outputCLI)
        {
            outputCLI = "";
            try
            {
                StringBuilder outputBuilder = new StringBuilder();

                string appFolder = AppDomain.CurrentDomain.BaseDirectory;
                string cliPath = Path.Combine(appFolder, "arduino-cli.exe");

                if (!IsArduinoCliAvailable())
                {
                    outputBuilder.AppendLine("❌ arduino - cli is not available.Please install it from https://arduino.github.io/arduino-cli/installation/");
                    outputBuilder.AppendLine("https://downloads.arduino.cc/arduino-cli/arduino-cli_latest_Windows_64bit.zip");
                    return false;
                }

                string tempOutput = "";
                if (!IsCoreInstalled(cliPath, fqbn.ToFqbnString(), out tempOutput))
                {
                    outputBuilder.AppendLine(tempOutput);
                    outputBuilder.AppendLine("🔍 Required core not found. Installing...");
                    tempOutput = "";
                    if (!InstallCore(cliPath, fqbn.ToFqbnString(), out tempOutput))
                    {
                        outputBuilder.AppendLine(tempOutput);
                        outputBuilder.AppendLine("❌ Core installation failed. Upload aborted.");
                        outputCLI = outputBuilder.ToString();
                        return false;
                    }
                    else
                    {
                        outputBuilder.AppendLine(tempOutput);
                    }

                }
                else
                {
                    outputBuilder.AppendLine("✅ Required core already installed.");
                }

                string sketchFolder = WriteSketchToFile(arduinoCode);
                if (!Directory.Exists(sketchFolder) || !File.Exists(Path.Combine(sketchFolder, "ArduinoSketch.ino")))
                {
                    outputBuilder.AppendLine("❌ Failed to write sketch to file.");
                    return false;
                }

                tempOutput = "";
                if (CompileSketch(cliPath, sketchFolder, fqbn.ToFqbnString(), out tempOutput))
                {
                    outputBuilder.AppendLine(tempOutput);
                }
                else
                {
                    outputBuilder.AppendLine(tempOutput);
                    return false;
                }


                outputBuilder.AppendLine($"🔄 Uploading sketch to {fqbn} on port {port}...");
                tempOutput = "";
                if (UploadSketch(cliPath, sketchFolder, port, fqbn.ToFqbnString(), out tempOutput))
                {
                    outputBuilder.AppendLine(tempOutput);
                    outputCLI = outputBuilder.ToString();
                    return true;
                }
                else
                {
                    outputBuilder.AppendLine(tempOutput);
                    outputCLI = outputBuilder.ToString();
                    return false;
                }
            }
            catch (Exception ex)
            {
                outputCLI += $"❌ Upload failed: {ex.Message}" + Environment.NewLine;
                Console.WriteLine($"❌ Upload failed: {ex.Message}");
            }
            return false;
        }
    }
}
