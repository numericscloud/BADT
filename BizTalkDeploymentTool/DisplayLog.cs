using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BizTalkDeploymentTool
{
    public partial class DisplayLog : Form
    {
        public DisplayLog()
        {
            InitializeComponent();
        }
        public void Log(string logMessage)
        {
            richTxtBxLog.Text = logMessage;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //this.Close();
        }
    }
}
