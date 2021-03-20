using System;
using System.Windows.Forms;

namespace Putty_starter 
{
    public partial class NewForm : Form
    {

        public NewForm(bool Top_Most)
        {
            InitializeComponent();
            TopMost = Top_Most;
        }
        string label;
        string Host;
        string password_SSH;
        string password_VipNet;
        private void button1_Click(object sender, EventArgs e)
        {
            label = textBox1.Text;
            Host = textBox2.Text;
            password_SSH = textBox3.Text;
            password_VipNet = textBox4.Text;
            this.DialogResult = DialogResult.OK;
        }
        public string Return_new_host()
        {
            return label+"\t"+ Host + "\t"+ password_SSH + "\t"+ password_VipNet+ "\t"+ReturnIsNotificate()+"\t" + DateTime.Now.ToString();
        }
        private void button2_Click(object sender, EventArgs e)
        {

        }
        public string ReturnIsNotificate()
        {
            if (comboBox1.SelectedIndex == 0)
                return "0";//не уведомлять
            else return "1";//уведомлять
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
