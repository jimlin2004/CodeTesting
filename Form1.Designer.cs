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
            this.richTextBox_output = new System.Windows.Forms.RichTextBox();
            this.richTextBox_input = new System.Windows.Forms.RichTextBox();
            this.richTextBox_console = new System.Windows.Forms.RichTextBox();
            this.button_build = new System.Windows.Forms.Button();
            this.button_loadfiles = new System.Windows.Forms.Button();
            this.splitContainer_wrap = new System.Windows.Forms.SplitContainer();
            this.splitContainer_left = new System.Windows.Forms.SplitContainer();
            this.comboBox_langSelector = new System.Windows.Forms.ComboBox();
            this.splitContainer_right = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_wrap)).BeginInit();
            this.splitContainer_wrap.Panel1.SuspendLayout();
            this.splitContainer_wrap.Panel2.SuspendLayout();
            this.splitContainer_wrap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_left)).BeginInit();
            this.splitContainer_left.Panel1.SuspendLayout();
            this.splitContainer_left.Panel2.SuspendLayout();
            this.splitContainer_left.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_right)).BeginInit();
            this.splitContainer_right.Panel1.SuspendLayout();
            this.splitContainer_right.Panel2.SuspendLayout();
            this.splitContainer_right.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBox_output
            // 
            this.richTextBox_output.BackColor = System.Drawing.SystemColors.Window;
            this.richTextBox_output.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox_output.Location = new System.Drawing.Point(0, 0);
            this.richTextBox_output.Margin = new System.Windows.Forms.Padding(0);
            this.richTextBox_output.Name = "richTextBox_output";
            this.richTextBox_output.ReadOnly = true;
            this.richTextBox_output.Size = new System.Drawing.Size(563, 311);
            this.richTextBox_output.TabIndex = 0;
            this.richTextBox_output.Text = "";
            // 
            // richTextBox_input
            // 
            this.richTextBox_input.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox_input.Location = new System.Drawing.Point(0, 0);
            this.richTextBox_input.Margin = new System.Windows.Forms.Padding(0);
            this.richTextBox_input.Name = "richTextBox_input";
            this.richTextBox_input.Size = new System.Drawing.Size(563, 255);
            this.richTextBox_input.TabIndex = 0;
            this.richTextBox_input.Text = "";
            // 
            // richTextBox_console
            // 
            this.richTextBox_console.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(45)))));
            this.richTextBox_console.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox_console.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(10)))), ((int)(((byte)(48)))));
            this.richTextBox_console.Location = new System.Drawing.Point(0, 0);
            this.richTextBox_console.Margin = new System.Windows.Forms.Padding(0);
            this.richTextBox_console.Name = "richTextBox_console";
            this.richTextBox_console.Size = new System.Drawing.Size(462, 312);
            this.richTextBox_console.TabIndex = 0;
            this.richTextBox_console.Text = "";
            // 
            // button_build
            // 
            this.button_build.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button_build.Location = new System.Drawing.Point(0, 225);
            this.button_build.Name = "button_build";
            this.button_build.Size = new System.Drawing.Size(462, 29);
            this.button_build.TabIndex = 1;
            this.button_build.Text = "編譯";
            this.button_build.UseVisualStyleBackColor = true;
            this.button_build.Click += new System.EventHandler(this.button_build_Click);
            // 
            // button_loadfiles
            // 
            this.button_loadfiles.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button_loadfiles.Location = new System.Drawing.Point(0, 196);
            this.button_loadfiles.Name = "button_loadfiles";
            this.button_loadfiles.Size = new System.Drawing.Size(462, 29);
            this.button_loadfiles.TabIndex = 0;
            this.button_loadfiles.Text = "選擇檔案";
            this.button_loadfiles.UseVisualStyleBackColor = true;
            this.button_loadfiles.Click += new System.EventHandler(this.button_loadfiles_Click);
            // 
            // splitContainer_wrap
            // 
            this.splitContainer_wrap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer_wrap.Location = new System.Drawing.Point(0, 0);
            this.splitContainer_wrap.Name = "splitContainer_wrap";
            // 
            // splitContainer_wrap.Panel1
            // 
            this.splitContainer_wrap.Panel1.Controls.Add(this.splitContainer_left);
            // 
            // splitContainer_wrap.Panel2
            // 
            this.splitContainer_wrap.Panel2.Controls.Add(this.splitContainer_right);
            this.splitContainer_wrap.Size = new System.Drawing.Size(1029, 570);
            this.splitContainer_wrap.SplitterDistance = 462;
            this.splitContainer_wrap.TabIndex = 2;
            // 
            // splitContainer_left
            // 
            this.splitContainer_left.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer_left.Location = new System.Drawing.Point(0, 0);
            this.splitContainer_left.Name = "splitContainer_left";
            this.splitContainer_left.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer_left.Panel1
            // 
            this.splitContainer_left.Panel1.Controls.Add(this.comboBox_langSelector);
            this.splitContainer_left.Panel1.Controls.Add(this.button_loadfiles);
            this.splitContainer_left.Panel1.Controls.Add(this.button_build);
            // 
            // splitContainer_left.Panel2
            // 
            this.splitContainer_left.Panel2.Controls.Add(this.richTextBox_console);
            this.splitContainer_left.Size = new System.Drawing.Size(462, 570);
            this.splitContainer_left.SplitterDistance = 254;
            this.splitContainer_left.TabIndex = 0;
            // 
            // comboBox_langSelector
            // 
            this.comboBox_langSelector.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.comboBox_langSelector.FormattingEnabled = true;
            this.comboBox_langSelector.Items.AddRange(new object[] {
            "cpp",
            "python 3"});
            this.comboBox_langSelector.Location = new System.Drawing.Point(0, 169);
            this.comboBox_langSelector.Name = "comboBox_langSelector";
            this.comboBox_langSelector.Size = new System.Drawing.Size(462, 27);
            this.comboBox_langSelector.TabIndex = 2;
            // 
            // splitContainer_right
            // 
            this.splitContainer_right.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer_right.Location = new System.Drawing.Point(0, 0);
            this.splitContainer_right.Name = "splitContainer_right";
            this.splitContainer_right.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer_right.Panel1
            // 
            this.splitContainer_right.Panel1.Controls.Add(this.richTextBox_input);
            // 
            // splitContainer_right.Panel2
            // 
            this.splitContainer_right.Panel2.Controls.Add(this.richTextBox_output);
            this.splitContainer_right.Size = new System.Drawing.Size(563, 570);
            this.splitContainer_right.SplitterDistance = 255;
            this.splitContainer_right.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1029, 570);
            this.Controls.Add(this.splitContainer_wrap);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "CodeTesting";
            this.splitContainer_wrap.Panel1.ResumeLayout(false);
            this.splitContainer_wrap.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_wrap)).EndInit();
            this.splitContainer_wrap.ResumeLayout(false);
            this.splitContainer_left.Panel1.ResumeLayout(false);
            this.splitContainer_left.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_left)).EndInit();
            this.splitContainer_left.ResumeLayout(false);
            this.splitContainer_right.Panel1.ResumeLayout(false);
            this.splitContainer_right.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_right)).EndInit();
            this.splitContainer_right.ResumeLayout(false);
            this.ResumeLayout(false);

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