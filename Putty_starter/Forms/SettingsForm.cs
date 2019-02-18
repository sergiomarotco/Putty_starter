using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Putty_starter
{
    public partial class SettingsForm : Form
    {
        protected override void WndProc(ref Message m)
        {
            try
            {
                switch (m.Msg)
                {
                    case WM_NCHITTEST:
                        {
                            m.Result = (IntPtr)HTCAPTION; //теперь форму можно перетаскивать за любое место
                            return;
                        }
                }
                base.WndProc(ref m);
            }
            catch { }
        }
        bool[] b;
        string[] str2;
        private const int WM_NCHITTEST = 0x0084;
        private const int HTCAPTION = 2;
        MainForm fr;
        public SettingsForm(string data, int ping_pause, bool DontFragment, Color deniedColor, bool Notification, bool Top_Most, int Ping, bool[] b, string[] str2)
        {
            TopMost = Top_Most;
            InitializeComponent();
            this.Icon = Properties.Resources.ShareThis;
            textBox1.Text = data;
            textBox2.Text = ping_pause.ToString();
            textBox4.Text = Ping.ToString();
            checkBox1.Checked = DontFragment;
            checkBox2.Checked = Notification;
            checkBox3.Checked = Top_Most;
            this.b = b;
            this.str2 = str2;
            textBox3.ForeColor = deniedColor;
            fr = new MainForm();
            //comboBox1.ForeColor=deniedColor
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (File.Exists("Pconfig.txt"))
                File.Delete("Pconfig.txt");
            string[] towrite = new string[7];
            towrite[0] = "Allpause\tПауза между сканированиями всего листа\t" + textBox1.Text;
            towrite[1] = "ping_pause\tПауза между сканированиями хостов\t" + textBox2.Text;
            towrite[2] = "DontFragment\tНе фрагментировать данные в PING-пакете\t" + checkBox1.Checked;
            towrite[3] = "Notification\tУведомить о появлении недоступного ресурса\t" + checkBox2.Checked;
            towrite[4] = "deniedColor\tЦвет недоступного хоста в списке\t" + Convert.ToByte(textBox3.ForeColor.A) + ","
                + Convert.ToByte(textBox3.ForeColor.R) + ","
                + Convert.ToByte(textBox3.ForeColor.G) + ","
                + Convert.ToByte(textBox3.ForeColor.B);
            towrite[5] = "Top_Most\tОкно программы отображать поверх всех окон\t" + checkBox3.Checked;
            towrite[6] = "Ping\tЗначение пинга заданное по - умолчание\t" + textBox4.Text;
            File.WriteAllLines("Pconfig.txt", towrite);
            this.DialogResult = DialogResult.OK;
        }

        public bool ReturnNotification()
        {
            return checkBox2.Checked;
        }
        public bool ReturnFragmenting()
        {
            if (checkBox1.Checked == true)
                return true;
            else return false;
        }
        public Color ReturnForeColor()
        {
            return textBox3.ForeColor;
        }
        //открытый метод для доступа к текстовому полю данной формы  
        public string ReturnPause()
        {
            return (textBox1.Text);
        }
        //открытый метод для доступа к текстовому полю данной формы  
        public string ReturnPing_pause()
        {
            return (textBox2.Text);
        }
        public bool ReturnTopMost()
        {
            return (checkBox3.Checked);
        }
        public int ReturnPing()
        {
            return (Convert.ToInt32(textBox4.Text));
        }
        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            double num = 0.0;
            if (double.TryParse(textBox2.Text, out num))            
                textBox2.Text = textBox2.Text;            
            else
                textBox2.Text = "0";            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            double num = 0.0;
            if (double.TryParse(textBox1.Text, out num))
                textBox1.Text = textBox1.Text;
            else
                textBox1.Text = "250";
        }
        AboutForm aabout;
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                aabout = new AboutForm();
                aabout.ShowDialog();
                this.Show();
            }
            catch { }
        }
        
        private void button4_Click(object sender, EventArgs e)
        {
            ColorDialog vv = new ColorDialog();
            vv.ShowDialog();
            textBox3.ForeColor = vv.Color;
        }
        private void WriteToFile(string filename, string[] buckup)
        {
            string buff = "";
            for (int i = 0; i < buckup.Length; i++)
                if (i != buckup.Length - 1)
                    buff += buckup[i] + "\r\n";
                else buff += buckup[i];
            File.WriteAllText(filename, buff);
        }
        private void button5_Click(object sender, EventArgs e)
        {
            SaveFileDialog SS = new SaveFileDialog();
            SS.Filter = "CSV files (разделитель табуляция) (*.csv)|*.csv|All files (*.*)|*.*";
            SS.FileName = "Список онлайн хостов.csv";
            SS.RestoreDirectory = true;
            SS.InitialDirectory = Environment.CurrentDirectory;
            if (MessageBox.Show("Сохранить на рабочий стол?", "Сохранение списка доступных ресурсов", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string to_file = "Host Name" + Environment.NewLine;
                for (int i = 0; i < b.Length; i++)
                    if (b[i] == true)
                        if (i != (b.Length - 1))
                        {
                            string[] sss = str2[i].Split('\t');
                            to_file += sss[1] + Environment.NewLine;
                        }
                        else
                        {
                            string[] sss = str2[i].Split('\t');
                            to_file += sss[1];
                        }
                File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + @"\" + SS.FileName, to_file);
                System.Diagnostics.Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + @"\" + SS.FileName);
            }
            else
            {
                if (SS.ShowDialog() == DialogResult.OK)
                {
                    string to_file = "Host Name" + Environment.NewLine;
                    for (int i = 0; i < b.Length; i++)
                        if (b[i] == true)
                            if (i != (b.Length - 1))
                            {
                                string[] sss = str2[i].Split('\t');
                                to_file += sss[1] + Environment.NewLine;
                            }
                            else
                            {
                                string[] sss = str2[i].Split('\t');
                                to_file += sss[1];
                            }
                    File.WriteAllText(SS.FileName, to_file);
                    System.Diagnostics.Process.Start(SS.FileName);
                }
            }
        }
    }
}
