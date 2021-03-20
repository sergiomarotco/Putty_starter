using System;
using System.Windows.Forms;

namespace Putty_starter
{
    public partial class EditForm : Form
    {
        string nameO;
        string IPO;
        string Key;
        string Key2;
        int IsNotificate=0;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name">Отображаемое имя ресурса</param>
        /// <param name="IP">Сетевое имя ресурса</param>
        /// <param name="Key">Пароль SSH</param>
        /// <param name="Key2">Пароль VipNET 2</param>
        /// <param name="Top_Most">Отобразить порму поверх всех окон</param>
        /// <param name="IsNotificate">Уведомлять о доступности (1/0) ресурса</param>
        /// <param name="LastOnline">Когда послений раз был в сети</param>
        public EditForm(string name, string IP, string Key, string Key2,bool Top_Most,int IsNotificate)
        {
            InitializeComponent();
            TopMost = Top_Most;
            textBox1.Text = name;
            textBox2.Text = IP;
            textBox3.Text = Key;
            textBox4.Text = Key2;
            nameO = name;
            IPO = IP;
            this.Key = Key;
            this.Key2 = Key2;
            comboBox1.SelectedIndex = IsNotificate;
            this.IsNotificate = IsNotificate;
        }
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
        private const int WM_NCHITTEST = 0x0084;
        private const int HTCAPTION = 2;

        private void button1_Click(object sender, EventArgs e)
        {
            if (nameO == textBox1.Text)
            {
                if (IPO == textBox2.Text)
                {
                    if (Key == textBox3.Text)
                    {
                        if (Key2 == textBox4.Text)
                        {
                            if (IsNotificate == comboBox1.SelectedIndex)
                            {
                                this.DialogResult = DialogResult.No;
                            }
                            else { this.DialogResult = DialogResult.OK; }
                        }
                        else { this.DialogResult = DialogResult.OK; }
                    }
                    else { this.DialogResult = DialogResult.OK; }
                }
                else { this.DialogResult = DialogResult.OK; }
            }
            else { this.DialogResult = DialogResult.OK; }
        }
        public string ReturnName()
        {
            return textBox1.Text;
        }
        public string ReturnIP()
        {
            return textBox2.Text;
        }
        public string ReturnKey()
        {
            return textBox3.Text;
        }
        public string ReturnKey2()
        {
            return textBox4.Text;
        }
        public int ReturnIsNotificate()
        {
            if (comboBox1.SelectedIndex == 0)
                return 0;//не уведомлять
            else return 1;//уведомлять
        }
        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
