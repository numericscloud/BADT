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
    public partial class Viewer : Form
    {
        public Viewer()
        {
            InitializeComponent();
        }
        public Viewer(string data)
        {
            InitializeComponent();
            webBrowser1.DocumentText = data;
        }
    }
}
