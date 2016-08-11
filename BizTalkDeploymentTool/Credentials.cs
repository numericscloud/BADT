using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BizTalkDeploymentTool.Report;

namespace BizTalkDeploymentTool
{
    public partial class Credentials : Form
    {
        public Credentials()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BTDTFormProperties.UserName = textBox1.Text;
            BTDTFormProperties.Password = textBox2.Text;
            this.Close();
        }
    }
}
