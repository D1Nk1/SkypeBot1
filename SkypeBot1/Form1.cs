using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SKYPE4COMLib;
using System.Threading;
using System.IO;

namespace SkypeBot1
{


    public partial class Form1 : Form
    {
        private static Skype skype = new Skype();
        string msg1 = "ewq";
        string msg2 = "hello there!"; 
        string mainmsg;


        public Form1()
        {
            InitializeComponent();
            skype.Attach(7, true);
            skype.MessageStatus += OnMessage;
            label5.Text = File.ReadLines("qwe.txt").Count().ToString();
            timer1.Interval = 5000;
            timer1.Enabled = false;
        }


        public void OnMessage(ChatMessage pMessage, TChatMessageStatus Status)
        {

            if (Status == TChatMessageStatus.cmsReceived)
            {
                switch(pMessage.Body) //set trigger messages here
                {
                    case "qwe":
                        SendMessage(pMessage.Sender.Handle, msg1);
                        break;
                    case "hello":
                        SendMessage(pMessage.Sender.Handle, msg2);
                        break;
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach(string name in File.ReadAllLines("qwe.txt"))
            {
                addFriend(name, "ono rabotaet!");
            }
        }
            
        private void addFriend(string name, string requestbody)
        {
            skype.Property["USER", name, "BUDDYSTATUS"] = string.Format("{0} {1}", (int)TBuddyStatus.budPendingAuthorization, requestbody);
        }
        private void SendMessage(string handle, string msg)
        {
            skype.SendMessage(handle, msg);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (string name in File.ReadAllLines("qwe.txt"))
            {
                mainmsg = richTextBox1.Text;
                skype.SendMessage(name, mainmsg);
                label3.Text = File.ReadLines("qwe.txt").Count().ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            skype.SendMessage("xdelierx", "fuck delier");
        }
    }
}




