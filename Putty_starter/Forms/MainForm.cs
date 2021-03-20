using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net.NetworkInformation;
using System.Threading;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Putty_starter
{
    public partial class MainForm : Form
    {
        public void NewList(int ind, int sredn, bool fromThread)
        {
            try
            {
                if (fromThread == false)
                {
                    listBox1.Items.Clear();
                    listBox1.Refresh();
                }
                else
                {
                    listBox1.Invoke(new Action(() => listBox1.Items.Clear()));
                    listBox1.Invoke(new Action(() => listBox1.Refresh()));
                }                
                string[] str3;
                if (File.Exists("Hosts.txt"))
                {
                    str = File.ReadAllText("Hosts.txt");
                    string[] str2_m = str.Split('\r');
                    str2 = new string[str2_m.Length - 1];
                    for (int i = 0; i < str2_m.Length - 1; i++)
                        str2[i] = str2_m[i + 1].Substring(1);
                    if (ind != -1)
                        for (int i = 0; i < str2.Length; i++)
                        {
                            str3 = str2[i].Split('\t');
                            if (fromThread == false)
                                listBox1.Items.Add(str3[0]);
                            else
                                listBox1.Invoke(new Action(() => listBox1.Items.Add(str3[0])));
                        }
                    else
                        for (int i = 0; i < str2.Length; i++)
                        {
                            str3 = str2[i].Split('\t');
                            if (i != ind)
                                if (fromThread == false)
                                    listBox1.Items.Add(str3[0]);
                                else listBox1.Invoke(new Action(() => listBox1.Items.Add(str3[0])));
                            else
                                  if (fromThread == false)
                                listBox1.Items.Add(str3[0] + " " + sredn + " ms");
                            else listBox1.Invoke(new Action(() => listBox1.Items.Add(str3[0] + " " + sredn + " ms")));
                        }
                    this.Size = new Size(this.Size.Width, 81+(14*listBox1.Items.Count));
                    listBox1.Location = new Point(0, 81);
                    listBox1.Size = new Size(this.Size.Width, this.Size.Height - 81);
                }
                else { MessageBox.Show("'Hosts.txt' file is missing or incorrect ... Rebooting ..."); }
            }
            catch(Exception ee) { }
        }
        public MainForm()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.ShareThis;
            NewList(-1,-1,false);
            if (File.Exists("Pconfig.txt"))
            {
                string[] buff = File.ReadAllLines("Pconfig.txt");
                for (int i = 0; i < buff.Length; i++)
                {
                    string[] W = buff[i].Split('\t');
                    switch (W[0])
                    {
                        case "Allpause":
                            PingtextBox1.Text = W[2];
                            break;
                        case "ping_pause":
                            ping_pause = Convert.ToInt32(W[2]);
                            break;
                        case "DontFragment":
                            DontFragment = Convert.ToBoolean(W[2]);
                            break;
                        case "Notification":
                            notification = Convert.ToBoolean(W[2]);
                            break;
                        case "deniedColor":
                            string[] vss = W[2].Split(',');
                            byte a = Convert.ToByte(vss[0]);
                            byte r = Convert.ToByte(vss[1]);
                            byte g = Convert.ToByte(vss[2]);
                            byte b = Convert.ToByte(vss[3]);
                            deniedColor = Color.FromArgb(a, r, g, b);
                            deniedBrush = new SolidBrush(deniedColor);
                            break;
                        case "Top_Most":
                            Top_Most = Convert.ToBoolean(W[2]);
                            TopMost = Top_Most;
                            break;
                        case "Ping":
                            PingtextBox1.Text = W[2];
                            Ping = Convert.ToInt32(W[2]);
                            break;
                    }
                }
            }
        }
        string str;
        public string[] str2;
        bool DontFragment = true;
        int Ping = 0;

        private void Form1_Load(object sender, EventArgs e)
        {
           /* try
            {*/
                //listBox1.DrawMode = DrawMode.OwnerDrawVariable;
                t = new Thread(PING); t.Start();
                b = new bool[listBox1.Items.Count];
                for (int i = 0; i < b.Length; i++)
                {
                    b[i] = false;
                }
           /* }
            catch { }*/
            deniedBrush = new SolidBrush(deniedColor);
        }
        /// <summary>
        /// Массив показывает какой из хостов онлайн, а какой нет
        /// </summary>
        public bool[] b;
        private const int WM_NCHITTEST = 0x0084;
        private const int HTCAPTION = 2;
        private void button2_Click(object sender, EventArgs e)
        {
            try { t.Abort(); Close(); }
            catch { }
        }
        [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
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

        private void ChangeText(string label1Text)
        {
            try { this.label1.Text = label1Text; } catch { }
        }
        private void Refresh1()
        {
            try { this.listBox1.Refresh(); } catch { }
        }
        public delegate void RTChangeText(string sText);
        public delegate void RTChangeText2();
        PingOptions options;
        Random rnd = new Random();
        PingReply reply;
        Thread t;
        RTChangeText rt;
        RTChangeText2 rt2;
        private void PING()
        {
            string[] str3;
            rt = new RTChangeText(ChangeText);
            rt2 = new RTChangeText2(Refresh1);
            while (true)
            {
                if (PingBox1.Checked == true) label1.BeginInvoke(rt, new object[] { "Starting ping ..." });
                if (PingBox1.Checked == true)
                    for (int i = 0; i < listBox1.Items.Count; i++)
                    {
                        try
                        {
                            Thread.Sleep(ping_pause);
                            switch (rnd.Next(4))
                            {
                                case 0: label1.BeginInvoke(rt, new object[] { "Pinging ." }); break;
                                case 1: label1.BeginInvoke(rt, new object[] { "Pinging   ." }); break;
                                case 2: label1.BeginInvoke(rt, new object[] { "Pinging     ." }); break;
                                case 3: label1.BeginInvoke(rt, new object[] { "Pinging       ." }); break;
                                default: break;
                            }
                            options = new PingOptions();
                            options.DontFragment = DontFragment;
                            byte[] buffer = System.Text.Encoding.ASCII.GetBytes("https://github.com/sergiomarotco");
                            int timeout = Convert.ToInt32(PingtextBox1.Text);
                            str3 = str2[i].Split('\t');

                            Ping pingSender = new Ping();
                            reply = pingSender.Send(
                                str3[1].ToString(),
                                timeout, buffer, options);

                            int[] pp = new int[4];
                            int count_succes = 0;
                            for (int j = 0; j < 4; j++)
                            {
                                if (reply.Status == IPStatus.Success)
                                {
                                    pp[j] = Convert.ToInt32(reply.RoundtripTime);
                                    count_succes++;
                                }
                                else pp[j] = 0;
                            }

                            if (count_succes != 0)
                            {
                                int sredn = -1;
                                if ((sredn = (pp[0] = pp[1] + pp[2] + pp[3]) / 4) <= Convert.ToInt32(PingtextBox1.Text))
                                {//если вычисленное среднее  меньше заданного значения ожидания
                                    if (b[i] == false)
                                    {
                                        if (notification == true)
                                            MessageBox.Show(str3[0] + " now available (online)!!!");//Отображение доступности \t1                                                                                                              
                                        str2[i] = str2_change_one_item(DateTime.Now.ToString(), i, 5);
                                        string[] texttowrite = new string[str2.Length + 1];
                                        texttowrite[0] = file_Hosts_zagolovok;
                                        Array.Copy(str2, 0, texttowrite, 1, str2.Length);
                                        WriteToFile("Hosts.txt", texttowrite);
                                        NewList(i, sredn, true);
                                    }
                                    b[i] = true;
                                }
                                else b[i] = false;
                                listBox1.Invoke(new Action(() => listBox1.Items[i] = str2[i].Split('\t')[0] + " \t" + sredn + " ms"));
                            }
                            else
                                b[i] = false;
                        }
                        catch { b[i] = false; }
                    }
                listBox1.BeginInvoke(rt2, new object[] { });//рефреш листа
                label1.BeginInvoke(rt, new object[] { "Ping completed, pause ..." });
                Thread.Sleep(5000);
            }
        }
        string file_Hosts_zagolovok = "Название\tЛогическое имя ПК, IP-адрес, DNS-имя\tпароль 1\tпароль 2\tУведомлять о доступности(1/0)\tДата последней активности";
        /// <summary>
        /// Заменить в строке элемент
        /// </summary>
        /// <param name="texttoput">текст для вставки в выбранный элемент str2(что вставить)</param>
        /// <param name="str2_number">Порядковый номер массива str2 (куда вставить)</param>
        /// <param name="position_in_str2">i в str3 после Split('\t') (конкретнее куда)</param>
        /// <returns></returns>
        private string str2_change_one_item(string texttoput, int str2_number, int position_in_str2_i)
        {
            string[] str3 = str2[str2_number].Split('\t');
            string to_return = "";
            for (int h = 0; h < str3.Length; h++)
            {
                if (h != position_in_str2_i)
                {
                    if (h != (str3.Length))
                        to_return += str3[h] + "\t";
                    else to_return += str3[h];
                }
                else to_return += texttoput + "\t";
            }
            string pattern = "\t\t"; string replacement = "\t"; Regex rgx = new Regex(pattern);

            to_return = rgx.Replace(to_return, replacement);
            return to_return;
        }
        private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            try
            {
                if (PingBox1.Checked)
                {// listBox1.DrawMode = DrawMode.OwnerDrawFixed;
                    e.DrawBackground();//Cтираем все перерисовкой фона	
                    Brush myBrush = Brushes.Black;
                    Graphics g = listBox1.CreateGraphics();
                    if (b[e.Index].Equals(true))
                        myBrush = Brushes.Black;
                    else myBrush = deniedBrush;

                    e.Graphics.DrawString(
                        ((ListBox)sender).Items[e.Index].ToString(),
                        e.Font, myBrush, e.Bounds,
                        StringFormat.GenericDefault);
                    e.DrawFocusRectangle();
                }
            }
            catch { }
        }
        Color deniedColor = Color.OrangeRed;
        Brush deniedBrush;
        /// <summary>
        /// Отображать окно по верх остальных окон
        /// </summary>
        bool Top_Most = false;
        int ping_pause = 0;
        /// <summary>
        /// Уведомлять о доступности недоступного ранее ресурса
        /// </summary>
        bool notification = false;
        SettingsForm fm;
        private void Settings_Click(object sender, EventArgs e)
        {
            try {
                this.Hide();
                fm = new SettingsForm(PingtextBox1.Text, ping_pause, options.DontFragment, deniedColor, notification, Top_Most, Ping, b, str2);
                fm.ShowDialog();
                if (fm.DialogResult == DialogResult.OK)
                {
                    PingtextBox1.Text = fm.ReturnPause();
                    ping_pause = Convert.ToInt32(fm.ReturnPing_pause());
                    DontFragment = fm.ReturnFragmenting();
                    deniedColor = fm.ReturnForeColor(); deniedBrush = new SolidBrush(deniedColor);
                    notification = fm.ReturnNotification();
                    Top_Most = fm.ReturnTopMost(); TopMost = Top_Most;
                    Ping = fm.ReturnPing(); PingtextBox1.Text = Ping.ToString();
                }
                this.Show();
            }
            catch (Exception ee) { MessageBox.Show("Нажатие кнопки Settings" + Environment.NewLine + ee.Message); }
        }
        private void listBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                //if (e.Button == MouseButtons.Right)
                //{
                    contextMenuStrip1.Visible = true;
                    contextMenuStrip1.Show(listBox1, new Point(e.X, e.Y));
               // }
            }
        }
        private void подключитьсядвойКликToolStripMenuItem_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.Show();
            try
            {
                if (listBox1.SelectedIndex > -1)
                {
                    string[] str3 = str2[listBox1.SelectedIndex].Split('\t');
                    if (File.Exists("putty.exe"))
                    {
                        //Process.Start("putty.exe -ssh vipnet@172.17.25.127 -pw j,tgbu[jkcfh");
                        Process.Start("putty.exe", "-ssh vipnet@" + str3[1].ToString() + " -pw " + str3[2].ToString());
                        Thread.Sleep(3000);
                        SendKeys.Send("enable");
                        SendKeys.Send("{ENTER}");
                        Thread.Sleep(500);
                        SendKeys.Send(str3[3].ToString());
                        SendKeys.Send("{ENTER}");
                    }
                    else MessageBox.Show("Please add putty.exe in programe folder");
                }
            }
            catch { }
        }
        private void пингToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                string[] s = str2[listBox1.SelectedIndex].Split('\t');
                Process.Start("cmd.exe", (@"/K ping " + s[1]));
            }
        }
        EditForm fm3;
        private void изменитьЗаписьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide();

                string[] bb = str2[listBox1.SelectedIndex].Split('\t');
                fm3 = new EditForm(listBox1.SelectedItem.ToString(), bb[1], bb[2], bb[3], Top_Most, Convert.ToInt32(bb[4]));
                fm3.ShowDialog();
                if (fm3.DialogResult == DialogResult.OK)
                {
                    b = new bool[listBox1.Items.Count];
                    for (int i = 0; i < b.Length; i++)
                        b[i] = false;
                    string[] texttowrite = new string[str2.Length + 1];
                    texttowrite[0] = file_Hosts_zagolovok;
                    Array.Copy(str2, 0, texttowrite, 1, str2.Length);
                    string[] ty = DateTime.Now.ToString().Split(' ');
                    WriteToFile("Hosts " + ty[0] + " " + ty[1].Replace(':', ' ') + ".txt", texttowrite);//делаем бэкап (без изменений)
                    texttowrite[listBox1.SelectedIndex + 1] = (fm3.ReturnName() + "\t" + fm3.ReturnIP() + "\t" + fm3.ReturnKey() + "\t" + fm3.ReturnKey2() + "\t" + fm3.ReturnIsNotificate() + "\t" + bb[5]);
                    WriteToFile("Hosts.txt", texttowrite);//записываем с изменениями
                    NewList(-1, -1, false);
                    label1.BeginInvoke(rt, new object[] { "Saved ..." });
                    t.Abort();
                    t = new Thread(PING); t.Start();
                }
                this.Show();
            }
            catch (Exception ee) { MessageBox.Show("изменитьЗаписьToolStripMenuItem_Click" + Environment.NewLine + ee.Message); }
        }
        /// <summary>
        /// Записать строковый массив в файл
        /// </summary>
        /// <param name="Куда пишем string[]"></param>
        /// <param name="Записываемый массив string[]"></param>
        private void WriteToFile(string filename, string[] buckup)
        {
            try
            {
                string buff = "";
                for (int i = 0; i < buckup.Length; i++)
                {
                    if (i != buckup.Length - 1)
                        buff += buckup[i] + "\r\n";
                    else buff += buckup[i];
                }
                string pattern = "\t\t"; string replacement = "\t"; Regex rgx = new Regex(pattern);

                buff = rgx.Replace(buff, replacement);
                File.WriteAllText(filename, buff);
            }
            catch (Exception ee) { MessageBox.Show("WriteToFile" + Environment.NewLine + ee.Message); }
        }

        private void информацияToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
           // try {
                if (listBox1.SelectedIndex != -1)
                {
                    string[] s = str2[listBox1.SelectedIndex].Split('\t');
                    названиеToolStripMenuItem.Text = "Название: " + s[0];
                    адресToolStripMenuItem.Text = "Адрес: " + s[1];
                    парольSSHToolStripMenuItem.Text = "Пароль SSH: " + s[2];
                    парольViPnetToolStripMenuItem.Text = "Пароль ViPNet: " + s[3];
                    if (Convert.ToInt32(b[listBox1.SelectedIndex]) == 1)
                    {
                        доступностьToolStripMenuItem.ForeColor = Color.DarkGreen;
                        доступностьToolStripMenuItem.Text = "Доступен";
                    }
                    else {
                        доступностьToolStripMenuItem.ForeColor = Color.Red;
                        доступностьToolStripMenuItem.Text = "Недоступен"; }
                    if (s[5] == "")
                    {
                        былВСетиToolStripMenuItem.ForeColor = Color.Red;
                        былВСетиToolStripMenuItem.Text = "Был в сети: !?";
                    }
                    else
                    {
                        string[] A = s[5].Split(' ');
                        string[] Date = A[0].Split('.');
                        string[] Time = A[1].Split(':');
                        DateTime D = new DateTime(
                            Convert.ToInt32(Date[2]),
                            Convert.ToInt32(Date[1]),
                            Convert.ToInt32(Date[0]),
                            Convert.ToInt32(Time[0]),
                            Convert.ToInt32(Time[1]),
                            Convert.ToInt32(Time[2]),
                            DateTimeKind.Local);
                        TimeSpan diff = DateTime.Now - D;
                        if (diff.TotalMinutes < 30)
                        {
                            былВСетиToolStripMenuItem.ForeColor = Color.DarkGreen;
                            былВСетиToolStripMenuItem.Text = ("Был в сети: " + s[5]);
                        }
                        else
                        {
                            былВСетиToolStripMenuItem.ForeColor = Color.Red;
                            былВСетиToolStripMenuItem.Text = ("Был в сети: " + s[5]);
                        }
                    }
                }
                else
                {
                    названиеToolStripMenuItem.Text = "Не выбран хост";
                    адресToolStripMenuItem.Text = "Не выбран хост";
                    парольSSHToolStripMenuItem.Text = "Не выбран хост";
                    парольViPnetToolStripMenuItem.Text = "Не выбран хост";
                    былВСетиToolStripMenuItem.Text = "Не выбран хост";
                    доступностьToolStripMenuItem.Text = "Не выбран хост";
                }
           // }
          //  catch (Exception ee) { MessageBox.Show("информацияToolStripMenuItem_MouseEnter" + Environment.NewLine + ee.Message); }
        }

        private void добавитьНовыйРесурсToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // try {
                NewForm fm4;
                this.Hide();
                string[] bb = str2[listBox1.SelectedIndex].Split('\t');
                fm4 = new NewForm(Top_Most);
                fm4.ShowDialog();
                if (fm4.DialogResult == DialogResult.OK)
                {
                    b = new bool[listBox1.Items.Count];
                    for (int i = 0; i < b.Length; i++)
                    {
                        b[i] = false;
                    }
                    // WriteToFile("Hosts.txt", texttowrite);//записываем с изменениями
                    NewList(-1,-1,false);
                    label1.BeginInvoke(rt, new object[] { "Saved ..." });
                    t.Abort();
                    t = new Thread(PING); t.Start();
                }
                this.Show();
           // }
            //catch (Exception ee) { MessageBox.Show("добавитьНовыйРесурсToolStripMenuItem_Click"+Environment.NewLine+ee.Message); }
        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                if (listBox1.SelectedIndex > -1)
                {
                    //Process.Start("putty.exe -ssh vipnet@172.17.25.127 -pw j,tgbu[jkcfh");
                    string[] str3 = str2[listBox1.SelectedIndex].Split('\t');
                    if (File.Exists("putty.exe"))
                    {
                        Process.Start("putty.exe", "-ssh vipnet@" + str3[1].ToString() + " -pw " + str3[2].ToString());
                        Thread.Sleep(3000);
                        SendKeys.Send("enable");
                        SendKeys.Send("{ENTER}");
                        Thread.Sleep(500);
                        SendKeys.Send(str3[3].ToString());
                        SendKeys.Send("{ENTER}");
                    }
                    else MessageBox.Show("Please add putty.exe in programe folder");
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}