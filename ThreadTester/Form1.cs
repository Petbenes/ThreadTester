using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace ThreadTester
{
    public partial class Form1 : Form
    {
        // nový timer
        clsTimer mobjTimer;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // start timeru
            mobjTimer = new clsTimer(1000);
            mobjTimer.Tick += clsTimer_tick;
            mobjTimer.mobjForm = this;
            mobjTimer.Start();
        }


        //-------------------------------------
        // tick timeru
        //-------------------------------------
        void clsTimer_tick()
        {
            textBox1.Text = "hi :)";
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            mobjTimer.Stop();
        }
    }
}
