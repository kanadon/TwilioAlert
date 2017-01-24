using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Twilio;

namespace TwilioAlert
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Ping pingSender = new Ping();
            int timeout = 5000;
            var ip = IPAddress.Parse(textBox1.Text);
            //2607:fea8:3c60:a19:6565:b86a:209c:7b86
            //99.250.110.191
            //192.168.0.18
            PingReply reply = pingSender.Send(ip, timeout);
            string msg = "";

            if (reply.Status == IPStatus.Success)
                msg = $"{ip.ToString()} - online";
            else
                msg = $"{ip.ToString()} - borked";

            textBox2.Text = msg;
            SendMsg(msg);
        }

        private void SendMsg(string text)
        {
            // Find your Account Sid and Auth Token at twilio.com/user/account
            string AccountSid = "ACb66c246f17d9a88fc14d1cc79b3089e9";
            string AuthToken = "d7bf12aa7c41b88679eede0eb7402410";
            var twilio = new TwilioRestClient(AccountSid, AuthToken);

            var message = twilio.SendMessage(
                "+16475572157", "+14162721382",
                text
            );
        }
    }
}
