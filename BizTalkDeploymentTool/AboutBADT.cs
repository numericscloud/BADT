using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BizTalkDeploymentTool
{
    public partial class AboutBADT : Form
    {
        public AboutBADT()
        {
            InitializeComponent();
        }

        private void aboutText_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.LinkText);
        }

        private void richTextBox1_LinkClicked(object sender, LinkClickedEventArgs e)
        {
           // System.Diagnostics.Process.Start(e.LinkText);
        }
    }
}
