namespace CodeTesting
{
    partial class Form1
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
            richTextBox_output = new RichTextBox();
            richTextBox_input = new RichTextBox();
            richTextBox_console = new RichTextBox();
            button_build = new Button();
            button_loadfiles = new Button();
            splitContainer_wrap = new SplitContainer();
            splitContainer_left = new SplitContainer();
            comboBox_langSelector = new ComboBox();
            splitContainer_right = new SplitContainer();
            ((System.ComponentModel.ISupportInitialize)splitContainer_wrap).BeginInit();
            splitContainer_wrap.Panel1.SuspendLayout();
            splitContainer_wrap.Panel2.SuspendLayout();
            splitContainer_wrap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer_left).BeginInit();
            splitContainer_left.Panel1.SuspendLayout();
            splitContainer_left.Panel2.SuspendLayout();
            splitContainer_left.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer_right).BeginInit();
            splitContainer_right.Panel1.SuspendLayout();
            splitContainer_right.Panel2.SuspendLayout();
            splitContainer_right.SuspendLayout();
            SuspendLayout();
            // 
            // richTextBox_output
            // 
            richTextBox_output.BackColor = SystemColors.Window;
            richTextBox_output.Dock = DockStyle.Fill;
            richTextBox_output.Location = new Point(0, 0);
            richTextBox_output.Margin = new Padding(0);
            richTextBox_output.Name = "richTextBox_output";
            richTextBox_output.ReadOnly = true;
            richTextBox_output.Size = new Size(563, 311);
            richTextBox_output.TabIndex = 0;
            richTextBox_output.Text = "";
            // 
            // richTextBox_input
            // 
            richTextBox_input.Dock = DockStyle.Fill;
            richTextBox_input.Location = new Point(0, 0);
            richTextBox_input.Margin = new Padding(0);
            richTextBox_input.Name = "richTextBox_input";
            richTextBox_input.Size = new Size(563, 255);
            richTextBox_input.TabIndex = 0;
            richTextBox_input.Text = "";
            // 
            // richTextBox_console
            // 
            richTextBox_console.BackColor = Color.FromArgb(40, 40, 45);
            richTextBox_console.Dock = DockStyle.Fill;
            richTextBox_console.ForeColor = Color.FromArgb(203, 10, 48);
            richTextBox_console.Location = new Point(0, 0);
            richTextBox_console.Margin = new Padding(0);
            richTextBox_console.Name = "richTextBox_console";
            richTextBox_console.Size = new Size(462, 312);
            richTextBox_console.TabIndex = 0;
            richTextBox_console.Text = "";
            // 
            // button_build
            // 
            button_build.Dock = DockStyle.Bottom;
            button_build.Location = new Point(0, 225);
            button_build.Name = "button_build";
            button_build.Size = new Size(462, 29);
            button_build.TabIndex = 1;
            button_build.Text = "編譯";
            button_build.UseVisualStyleBackColor = true;
            button_build.Click += button_build_Click;
            // 
            // button_loadfiles
            // 
            button_loadfiles.Dock = DockStyle.Bottom;
            button_loadfiles.Location = new Point(0, 196);
            button_loadfiles.Name = "button_loadfiles";
            button_loadfiles.Size = new Size(462, 29);
            button_loadfiles.TabIndex = 0;
            button_loadfiles.Text = "選擇檔案";
            button_loadfiles.UseVisualStyleBackColor = true;
            button_loadfiles.Click += button_loadfiles_Click;
            // 
            // splitContainer_wrap
            // 
            splitContainer_wrap.Dock = DockStyle.Fill;
            splitContainer_wrap.Location = new Point(0, 0);
            splitContainer_wrap.Name = "splitContainer_wrap";
            // 
            // splitContainer_wrap.Panel1
            // 
            splitContainer_wrap.Panel1.Controls.Add(splitContainer_left);
            // 
            // splitContainer_wrap.Panel2
            // 
            splitContainer_wrap.Panel2.Controls.Add(splitContainer_right);
            splitContainer_wrap.Size = new Size(1029, 570);
            splitContainer_wrap.SplitterDistance = 462;
            splitContainer_wrap.TabIndex = 2;
            // 
            // splitContainer_left
            // 
            splitContainer_left.Dock = DockStyle.Fill;
            splitContainer_left.Location = new Point(0, 0);
            splitContainer_left.Name = "splitContainer_left";
            splitContainer_left.Orientation = Orientation.Horizontal;
            // 
            // splitContainer_left.Panel1
            // 
            splitContainer_left.Panel1.Controls.Add(comboBox_langSelector);
            splitContainer_left.Panel1.Controls.Add(button_loadfiles);
            splitContainer_left.Panel1.Controls.Add(button_build);
            // 
            // splitContainer_left.Panel2
            // 
            splitContainer_left.Panel2.Controls.Add(richTextBox_console);
            splitContainer_left.Size = new Size(462, 570);
            splitContainer_left.SplitterDistance = 254;
            splitContainer_left.TabIndex = 0;
            // 
            // comboBox_langSelector
            // 
            comboBox_langSelector.Dock = DockStyle.Bottom;
            comboBox_langSelector.FormattingEnabled = true;
            comboBox_langSelector.Items.AddRange(new object[] { "cpp", "python 3" });
            comboBox_langSelector.Location = new Point(0, 169);
            comboBox_langSelector.Name = "comboBox_langSelector";
            comboBox_langSelector.Size = new Size(462, 27);
            comboBox_langSelector.TabIndex = 2;
            // 
            // splitContainer_right
            // 
            splitContainer_right.Dock = DockStyle.Fill;
            splitContainer_right.Location = new Point(0, 0);
            splitContainer_right.Name = "splitContainer_right";
            splitContainer_right.Orientation = Orientation.Horizontal;
            // 
            // splitContainer_right.Panel1
            // 
            splitContainer_right.Panel1.Controls.Add(richTextBox_input);
            // 
            // splitContainer_right.Panel2
            // 
            splitContainer_right.Panel2.Controls.Add(richTextBox_output);
            splitContainer_right.Size = new Size(563, 570);
            splitContainer_right.SplitterDistance = 255;
            splitContainer_right.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1029, 570);
            Controls.Add(splitContainer_wrap);
            Margin = new Padding(4);
            Name = "Form1";
            Text = "CodeTesting";
            splitContainer_wrap.Panel1.ResumeLayout(false);
            splitContainer_wrap.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer_wrap).EndInit();
            splitContainer_wrap.ResumeLayout(false);
            splitContainer_left.Panel1.ResumeLayout(false);
            splitContainer_left.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer_left).EndInit();
            splitContainer_left.ResumeLayout(false);
            splitContainer_right.Panel1.ResumeLayout(false);
            splitContainer_right.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer_right).EndInit();
            splitContainer_right.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private RichTextBox richTextBox_output;
        private RichTextBox richTextBox_input;
        private RichTextBox richTextBox_console;
        private Button button_build;
        private Button button_loadfiles;
        private SplitContainer splitContainer_wrap;
        private SplitContainer splitContainer_left;
        private SplitContainer splitContainer_right;
        private ComboBox comboBox_langSelector;
    }
}