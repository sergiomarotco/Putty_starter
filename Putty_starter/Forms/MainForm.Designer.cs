namespace Putty_starter
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.Closebutton = new System.Windows.Forms.Button();
            this.PingtextBox1 = new System.Windows.Forms.TextBox();
            this.PingBox1 = new System.Windows.Forms.CheckBox();
            this.button3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.информацияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.названиеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.адресToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.парольSSHToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.парольViPnetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.доступностьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.былВСетиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.пингToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.подключитьсядвойКликToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.изменитьЗаписьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьНовыйРесурсToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.listBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(0, 81);
            this.listBox1.Margin = new System.Windows.Forms.Padding(4);
            this.listBox1.MinimumSize = new System.Drawing.Size(0, 81);
            this.listBox1.MultiColumn = true;
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(241, 628);
            this.listBox1.TabIndex = 0;
            this.listBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ListBox1_MouseClick);
            this.listBox1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listBox1_DrawItem);
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            this.listBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox1_MouseDoubleClick);
            // 
            // Closebutton
            // 
            this.Closebutton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Closebutton.BackColor = System.Drawing.Color.Black;
            this.Closebutton.ForeColor = System.Drawing.Color.White;
            this.Closebutton.Location = new System.Drawing.Point(0, 2);
            this.Closebutton.Margin = new System.Windows.Forms.Padding(4);
            this.Closebutton.Name = "Closebutton";
            this.Closebutton.Size = new System.Drawing.Size(241, 30);
            this.Closebutton.TabIndex = 3;
            this.Closebutton.Text = "Close";
            this.Closebutton.UseVisualStyleBackColor = false;
            this.Closebutton.Click += new System.EventHandler(this.button2_Click);
            // 
            // PingtextBox1
            // 
            this.PingtextBox1.Location = new System.Drawing.Point(0, 38);
            this.PingtextBox1.Margin = new System.Windows.Forms.Padding(4);
            this.PingtextBox1.Name = "PingtextBox1";
            this.PingtextBox1.Size = new System.Drawing.Size(33, 22);
            this.PingtextBox1.TabIndex = 4;
            this.PingtextBox1.Text = "250";
            // 
            // PingBox1
            // 
            this.PingBox1.AutoSize = true;
            this.PingBox1.Checked = true;
            this.PingBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.PingBox1.ForeColor = System.Drawing.Color.White;
            this.PingBox1.Location = new System.Drawing.Point(41, 40);
            this.PingBox1.Margin = new System.Windows.Forms.Padding(4);
            this.PingBox1.Name = "PingBox1";
            this.PingBox1.Size = new System.Drawing.Size(58, 21);
            this.PingBox1.TabIndex = 5;
            this.PingBox1.Text = "Ping";
            this.PingBox1.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Black;
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(164, 38);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(77, 30);
            this.button3.TabIndex = 7;
            this.button3.Text = "Settings";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.Settings_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(2, 64);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "...";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.информацияToolStripMenuItem,
            this.пингToolStripMenuItem,
            this.подключитьсядвойКликToolStripMenuItem,
            this.изменитьЗаписьToolStripMenuItem,
            this.добавитьНовыйРесурсToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(286, 124);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // информацияToolStripMenuItem
            // 
            this.информацияToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.названиеToolStripMenuItem,
            this.адресToolStripMenuItem,
            this.парольSSHToolStripMenuItem,
            this.парольViPnetToolStripMenuItem,
            this.доступностьToolStripMenuItem,
            this.былВСетиToolStripMenuItem});
            this.информацияToolStripMenuItem.Name = "информацияToolStripMenuItem";
            this.информацияToolStripMenuItem.Size = new System.Drawing.Size(285, 24);
            this.информацияToolStripMenuItem.Text = "Информация";
            this.информацияToolStripMenuItem.MouseEnter += new System.EventHandler(this.ИнформацияToolStripMenuItem_MouseEnter);
            // 
            // названиеToolStripMenuItem
            // 
            this.названиеToolStripMenuItem.Name = "названиеToolStripMenuItem";
            this.названиеToolStripMenuItem.Size = new System.Drawing.Size(194, 26);
            this.названиеToolStripMenuItem.Text = "Название";
            // 
            // адресToolStripMenuItem
            // 
            this.адресToolStripMenuItem.Name = "адресToolStripMenuItem";
            this.адресToolStripMenuItem.Size = new System.Drawing.Size(194, 26);
            this.адресToolStripMenuItem.Text = "Адрес";
            // 
            // парольSSHToolStripMenuItem
            // 
            this.парольSSHToolStripMenuItem.Name = "парольSSHToolStripMenuItem";
            this.парольSSHToolStripMenuItem.Size = new System.Drawing.Size(194, 26);
            this.парольSSHToolStripMenuItem.Text = "Пароль SSH";
            // 
            // парольViPnetToolStripMenuItem
            // 
            this.парольViPnetToolStripMenuItem.Name = "парольViPnetToolStripMenuItem";
            this.парольViPnetToolStripMenuItem.Size = new System.Drawing.Size(194, 26);
            this.парольViPnetToolStripMenuItem.Text = "Пароль ViPNet";
            // 
            // доступностьToolStripMenuItem
            // 
            this.доступностьToolStripMenuItem.Name = "доступностьToolStripMenuItem";
            this.доступностьToolStripMenuItem.Size = new System.Drawing.Size(194, 26);
            this.доступностьToolStripMenuItem.Text = "Доступность";
            // 
            // былВСетиToolStripMenuItem
            // 
            this.былВСетиToolStripMenuItem.Name = "былВСетиToolStripMenuItem";
            this.былВСетиToolStripMenuItem.Size = new System.Drawing.Size(194, 26);
            this.былВСетиToolStripMenuItem.Text = "Был в сети";
            // 
            // пингToolStripMenuItem
            // 
            this.пингToolStripMenuItem.Name = "пингToolStripMenuItem";
            this.пингToolStripMenuItem.Size = new System.Drawing.Size(285, 24);
            this.пингToolStripMenuItem.Text = "Пинг";
            this.пингToolStripMenuItem.Click += new System.EventHandler(this.ПингToolStripMenuItem_Click);
            // 
            // подключитьсядвойКликToolStripMenuItem
            // 
            this.подключитьсядвойКликToolStripMenuItem.Name = "подключитьсядвойКликToolStripMenuItem";
            this.подключитьсядвойКликToolStripMenuItem.Size = new System.Drawing.Size(285, 24);
            this.подключитьсядвойКликToolStripMenuItem.Text = "Подключиться (двой клик)";
            this.подключитьсядвойКликToolStripMenuItem.Click += new System.EventHandler(this.ПодключитьсядвойКликToolStripMenuItem_Click);
            // 
            // изменитьЗаписьToolStripMenuItem
            // 
            this.изменитьЗаписьToolStripMenuItem.Name = "изменитьЗаписьToolStripMenuItem";
            this.изменитьЗаписьToolStripMenuItem.Size = new System.Drawing.Size(285, 24);
            this.изменитьЗаписьToolStripMenuItem.Text = "Изменить выбранный ресурс";
            this.изменитьЗаписьToolStripMenuItem.Click += new System.EventHandler(this.ИзменитьЗаписьToolStripMenuItem_Click);
            // 
            // добавитьНовыйРесурсToolStripMenuItem
            // 
            this.добавитьНовыйРесурсToolStripMenuItem.Name = "добавитьНовыйРесурсToolStripMenuItem";
            this.добавитьНовыйРесурсToolStripMenuItem.Size = new System.Drawing.Size(285, 24);
            this.добавитьНовыйРесурсToolStripMenuItem.Text = "Добавить новый ресурс";
            this.добавитьНовыйРесурсToolStripMenuItem.Click += new System.EventHandler(this.ДобавитьНовыйРесурсToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(241, 709);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.PingBox1);
            this.Controls.Add(this.PingtextBox1);
            this.Controls.Add(this.Closebutton);
            this.Controls.Add(this.listBox1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximumSize = new System.Drawing.Size(241, 709);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Пингатор + Putty starter";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button Closebutton;
        private System.Windows.Forms.TextBox PingtextBox1;
        private System.Windows.Forms.CheckBox PingBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem пингToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem подключитьсядвойКликToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem изменитьЗаписьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem информацияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem названиеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem адресToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem парольSSHToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem парольViPnetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem доступностьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem добавитьНовыйРесурсToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem былВСетиToolStripMenuItem;
    }
}

