using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Captcha
{
    public partial class CaptchaForm : Form
    {
        CAPTCHA captcha;
        public CaptchaForm()
        {
            InitializeComponent();
            captcha = new CAPTCHA(pctCaptcha.Size);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pctCaptcha.Image = captcha.Next();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pctCaptcha.Image = captcha.Next();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ValidatE();

        }

        private void ValidatE()
        {
            if (captcha.ValidResult(tbResult.Text))
            {
                MessageBox.Show("Ответ верный", "Проверка подлинности");
                pctCaptcha.Image = captcha.Next();
                tbResult.Text = string.Empty;
            }
            else
                tbResult.Text = string.Empty;
        }

        private void tbResult_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                ValidatE();
            }
        }
    }
}
