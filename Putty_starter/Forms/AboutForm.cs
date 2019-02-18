using System;
using System.Windows.Forms;

namespace Putty_starter
{
    public partial class AboutForm : Form
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
        private const int WM_NCHITTEST = 0x0084;
        private const int HTCAPTION = 2;
        public AboutForm()
        {
            InitializeComponent();
            this.Icon = Putty_starter.Properties.Resources.ShareThis;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try { System.Diagnostics.Process.Start("https://github.com/sergiomarotco"); }
            catch { }
            this.DialogResult = DialogResult.OK;
        }

        private void about_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void about_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
