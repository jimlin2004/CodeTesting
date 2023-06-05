using System;
using System.Diagnostics;

namespace CodeTesting
{
    public partial class Form1 : Form
    {
        private string[] files;

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
            if (dialog.ShowDialog() == DialogResult.OK ) 
            {
                this.files = dialog.FileNames;
            }
            if (this.files.Length == 0)
                return;
            if (File.Exists(Path.GetDirectoryName(this.files[0]) + "\\input.txt"))
            {
                StreamReader sr = new StreamReader(Path.GetDirectoryName(this.files[0]) + "\\input.txt");
                string input = sr.ReadToEnd();
                this.richTextBox_input.Text = input;
                sr.Close();
            }
        }

        private void cppProcess()
        {
            string command = "g++ -o " + Path.GetDirectoryName(this.files[0]) + "\\main.exe";
            for (int i = 0; i < this.files.Length; ++i)
            {
                command += " " + this.files[i];
            }
            System.Diagnostics.Process cmd = new System.Diagnostics.Process();
                
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
            if (error.Length != 0) 
            {
                this.richTextBox_console.SelectionColor = System.Drawing.Color.Red;
                this.richTextBox_console.Text = error;
                return;
            }
            StreamWriter sw = new StreamWriter(Path.GetDirectoryName(this.files[0]) + "\\input.txt");
            sw.Write(this.richTextBox_input.Text);
            sw.Close();
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.StartInfo.FileName = Path.GetDirectoryName(this.files[0]) + "\\main.exe";
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.RedirectStandardInput = true;
            string[] input = this.richTextBox_input.Text.Split("\n");
            process.Start();
            for (int i = 0; i < input.Length; ++i)
            {
                process.StandardInput.WriteLine(input[i]);
            }
            process.StandardInput.WriteLine((char)26); //EOF
            string output = process.StandardOutput.ReadToEnd();
            process.Close();
            this.richTextBox_output.Text = output;
            this.richTextBox_console.Text = "";
            this.richTextBox_console.SelectionColor = System.Drawing.Color.GreenYellow;
            this.richTextBox_console.AppendText("建置成功\n");
        }

        private void pythonProcess()
        {
            StreamWriter sw = new StreamWriter(Path.GetDirectoryName(this.files[0]) + "\\input.txt");
            sw.Write(this.richTextBox_input.Text);
            sw.Close();
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.StartInfo.FileName = "python.exe";
            process.StartInfo.Arguments = " " + this.files[0]; //python
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.RedirectStandardInput = true;
            string[] input = this.richTextBox_input.Text.Split("\n");
            process.Start();
            
            for (int i = 0; i < input.Length; ++i)
            {
                process.StandardInput.WriteLine(input[i]);
            }
            process.StandardInput.WriteLine((char)26); //EOF
            string error = process.StandardError.ReadToEnd();
            if (error.Length != 0)
            {
                this.richTextBox_console.SelectionColor = System.Drawing.Color.Red;
                this.richTextBox_console.Text = error;
                return;
            }
            string output = process.StandardOutput.ReadToEnd();
            process.Close();
            this.richTextBox_output.Text = output;
            this.richTextBox_console.Text = "";
            this.richTextBox_console.SelectionColor = System.Drawing.Color.GreenYellow;
            this.richTextBox_console.AppendText("建置成功\n");
        }

        private void button_build_Click(object sender, EventArgs e)
        {
            if (this.files.Length != 0)
            {
                this.richTextBox_output.Text = "";
                switch (this.comboBox_langSelector.Text)
                {
                    case "cpp":
                        this.cppProcess();
                        break;
                    case "python 3":
                        this.pythonProcess();
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