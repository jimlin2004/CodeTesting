using System;
using System.Diagnostics;

namespace CodeTesting
{
    public partial class Form1 : Form
    {
        private string[] files;

        // 因為async的process output不會包含\n
        // 為了保持\n所以用此變數紀錄是否為第一筆輸出
        // 否則需要換行
        private bool isNotFirstOutput;

        private bool isHappenedError;

        private delegate void DelPrintOutput(string output);
        private delegate void DelPrintError(string error);

        public Form1()
        {
            InitializeComponent();
            this.files = new string[] { };
            this.comboBox_langSelector.SelectedIndex = 0;
        }

        private void button_loadfiles_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = true;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                this.files = dialog.FileNames;
            }
            if (this.files.Length == 0)
                return;
            string filePath = Path.Combine(Path.GetDirectoryName(this.files[0]), "input.txt");
            if (File.Exists(filePath))
            {
                StreamReader sr = new StreamReader(filePath);
                string input = sr.ReadToEnd();
                this.richTextBox_input.Text = input;
                sr.Close();
            }
        }

        public void printOutput(string output)
        {
            if (this.InvokeRequired)
            {
                DelPrintOutput del = new DelPrintOutput(this.printOutput);
                this.Invoke(del, output);
            }
            else
            {
                if (this.isNotFirstOutput)
                    this.richTextBox_output.AppendText("\n");
                else
                    this.isNotFirstOutput = true;
                this.richTextBox_output.AppendText(output);
            }
                
        }

        public void setOutput(String output) 
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate
                {
                    this.richTextBox_output.Text = output;
                }));
            }
            else
            {
                this.richTextBox_output.Text = output;
            }
        }

        public void printError(string error)
        {
            if (error == null)
                return;
            this.isHappenedError = true;
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate
                {
                    this.console_log(Color.Red, error + "\n");
                }));
            }
            else
            {
                this.clearConsoleBox();
                this.console_log(Color.Red, error + "\n");
            }
        }

        private string getRichTextBoxText(RichTextBox richTextBox)
        {
            if (this.InvokeRequired)
            {
                string text = "";
                this.Invoke(new MethodInvoker(delegate
                {
                    text = richTextBox.Text;
                }));
                return text;
            }
            else
                return richTextBox.Text;
        }

        private void clearConsoleBox()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate 
                { 
                    this.richTextBox_console.Clear();
                }));
            }
            else
                this.richTextBox_console.Clear();
        }

        // richTextBox_console的log功能
        private void console_log(Color color, string message) 
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate
                {
                    this.richTextBox_console.SelectionColor = color;
                    this.richTextBox_console.AppendText(message);
                }));
            }
            else
            {
                this.richTextBox_console.SelectionColor = color;
                this.richTextBox_console.AppendText(message);
            }   
        }

        private Task cppProcess()
        {
            return Task.Run(() =>
            {
                string exePath = Path.Combine(Path.GetDirectoryName(this.files[0]), "main.exe").Replace("\\", "/");
                string command = "g++ -g -o " + exePath;
                for (int i = 0; i < this.files.Length; ++i)
                {
                    command += " " + this.files[i];
                }
                Process cmd = new Process();

                cmd.StartInfo.FileName = "cmd.exe";
                cmd.StartInfo.UseShellExecute = false;
                cmd.StartInfo.RedirectStandardError = true;
                cmd.StartInfo.RedirectStandardInput = true;
                cmd.StartInfo.CreateNoWindow = true;
                cmd.StartInfo.RedirectStandardOutput = true;

                cmd.Start();
                    cmd.StandardInput.WriteLine(command);
                    cmd.StandardInput.AutoFlush = true;
                    cmd.StandardInput.WriteLine("exit");
                    string error = cmd.StandardError.ReadToEnd();
                cmd.Close();

                this.clearConsoleBox();
                if (error.Length != 0)
                {
                    this.console_log(Color.Red, error);
                    return;
                }
                else
                {
                    this.console_log(Color.GreenYellow, "建置成功\n");
                }

                string inputPath = Path.Combine(Path.GetDirectoryName(this.files[0]), "input.txt").Replace("\\", "/");
                string outputPath = Path.Combine(Path.GetDirectoryName(this.files[0]), "output.txt").Replace("\\", "/");

                // 將rictTextBox中的text寫入input.txt
                StreamWriter sw = new StreamWriter(inputPath);
                sw.Write(getRichTextBoxText(this.richTextBox_input));
                sw.Close();

                string pythonModulePath = Path.Combine(Directory.GetCurrentDirectory(), "python/GDBApi.py").Replace("\\", "/");

                Process debugProcess = new Process();
                debugProcess.StartInfo.FileName = Path.Combine(Directory.GetCurrentDirectory(), "tool/python/python.exe");
                debugProcess.StartInfo.ArgumentList.Add(pythonModulePath);
                debugProcess.StartInfo.ArgumentList.Add(exePath);
                debugProcess.StartInfo.ArgumentList.Add(inputPath);
                debugProcess.StartInfo.ArgumentList.Add(outputPath);
                debugProcess.StartInfo.RedirectStandardOutput = true;
                debugProcess.StartInfo.RedirectStandardError = true;
                debugProcess.StartInfo.CreateNoWindow = true;
                debugProcess.StartInfo.WorkingDirectory = Path.GetDirectoryName(pythonModulePath);

                debugProcess.ErrorDataReceived += (sender, args) =>
                {
                    this.printError(args.Data);
                };

                // 初始化isNotFirstOutput
                this.isNotFirstOutput = false;
                this.isHappenedError = false;

                debugProcess.Start();
                    debugProcess.BeginOutputReadLine();
                    debugProcess.BeginErrorReadLine();

                    debugProcess.WaitForExit();
                debugProcess.Close();

                if (this.isHappenedError)
                {
                    return;
                }
                else
                {
                    this.console_log(Color.GreenYellow, "Debug結束，無runtime error\n");
                }

                Process cppRunProcess = new Process();
                cppRunProcess.StartInfo.FileName = "cmd.exe";
                cppRunProcess.StartInfo.ArgumentList.Add(string.Format("/c {0} < {1}", exePath, inputPath));
                cppRunProcess.StartInfo.CreateNoWindow = true;

                // 初始化isNotFirstOutput
                this.isNotFirstOutput = false;

                this.isHappenedError = false;

                cppRunProcess.Start();
                    int startTime = Environment.TickCount;
                    cppRunProcess.WaitForExit();
                    int executionTime = Environment.TickCount - startTime;
                cppRunProcess.Close();

                if (!this.isHappenedError)
                {
                    StreamReader sr = new StreamReader(outputPath);
                    this.setOutput(sr.ReadToEnd());
                    sr.Close();

                    this.console_log(Color.GreenYellow, "程式運行成功\n");
                    this.console_log(Color.GreenYellow, "程式執行時間: ");
                    this.console_log(Color.GreenYellow, (executionTime / 1000.0).ToString() + " s\n");
                }
            });
        }

        private Task pythonProcess()
        {
            return Task.Run(() => { 
                string inputPath = Path.Combine(Path.GetDirectoryName(this.files[0]), "input.txt");

                // 將rictTextBox中的text寫入input.txt
                StreamWriter sw = new StreamWriter(inputPath);
                sw.Write(getRichTextBoxText(this.richTextBox_input));
                sw.Close();

                this.clearConsoleBox();

                string pythonPath = Path.Combine(Directory.GetCurrentDirectory(), "tool/python/python.exe");
                Process process = new Process();
                process.StartInfo.FileName = "cmd.exe";
                process.StartInfo.ArgumentList.Add(string.Format("/c {0} {1} < {2}", pythonPath, this.files[0], inputPath));
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true;
                process.StartInfo.CreateNoWindow = true;
                //process.StartInfo.RedirectStandardInput = true;

                process.OutputDataReceived += (sender, args) =>
                {
                    this.printOutput(args.Data);
                };
                process.ErrorDataReceived += (sender, args) =>
                {
                    this.printError(args.Data);
                };

                // 初始化isNotFirstOutput
                this.isNotFirstOutput = false;

                this.isHappenedError = false;

                this.clearConsoleBox();
                this.console_log(Color.GreenYellow, "開始運行程式\n");

                process.Start();   
                    process.BeginOutputReadLine();
                    process.BeginErrorReadLine();

                    int startTime = Environment.TickCount; 

                    process.WaitForExit();
                    int executionTime = Environment.TickCount - startTime;
                process.Close();

                if (!this.isHappenedError)
                {
                    this.console_log(Color.GreenYellow, "程式運行成功\n");
                    this.console_log(Color.GreenYellow, "程式執行時間: ");
                    this.console_log(Color.GreenYellow, (executionTime / 1000.0f).ToString() + " s\n");
                }
            });
        }

        private async void button_build_Click(object sender, EventArgs e)
        {
            if (this.files.Length != 0)
            {
                this.richTextBox_output.Text = "";
                switch (this.comboBox_langSelector.Text)
                {
                    case "cpp":
                        await this.cppProcess();
                        break;
                    case "python 3":
                        await this.pythonProcess();
                        break;
                    default:
                        break;
                }
            }
            else
                MessageBox.Show("請選擇檔案");
        }
    }
}