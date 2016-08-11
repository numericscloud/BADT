using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BizTalkDeploymentTool.Report
{
    public partial class BTDTReportOptions : Form
    {
        public BTDTReportOptions()
        {
            InitializeComponent();
            SetValues();
        }
       
        private void SetValues()
        {
            if (rBtnAuto.Checked)
            {
                BTDTFormProperties.Algorithm = rBtnAuto.Text;
            }
            else if (rBtnPrecise.Checked)
            {
                BTDTFormProperties.Algorithm = rBtnPrecise.Text;
            }
            else if (rBtnFast.Checked)
            {
                BTDTFormProperties.Algorithm = rBtnFast.Text;
            }
            List<string> optionsList = new List<string>();
            foreach (ListViewItem item in listViewOptions.Items)
            {
                if (item.Checked)
                {
                    item.Checked = true; ;
                    optionsList.Add(item.Text);
                }
            }
            BTDTFormProperties.OptionsListView = optionsList;           
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            SetValues();
            this.Close();
        }
    }
}
