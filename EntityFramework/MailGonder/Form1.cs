using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MailGonder
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MailMessage mail = new MailMessage();
            mail.From = new System.Net.Mail.MailAddress("busraa.adaa@gmail.com");
            SmtpClient smtp = new SmtpClient();
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(mail.From.Address, "ADA.7562");
            smtp.Host = "smtp.gmail.com";

            //recipient
            //mail.To.Add(new MailAddress("***@gmail.com"));
            //alıcı
            mail.To.Add(textBox1.Text);

            mail.IsBodyHtml = true;

            mail.Body = textBox3.Text;
            smtp.Send(mail);

        }
    }
}
