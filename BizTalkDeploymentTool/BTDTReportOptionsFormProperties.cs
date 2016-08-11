using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BizTalkDeploymentTool.Report
{
    public static class BTDTFormProperties
    {
        public static string Algorithm
        {
            get;
            set;
        }
        public static List<string> OptionsListView
        {
            get;
            set;
        }

        public static string UserName
        {
            get;
            set;
        }
        public static string Password
        {
            get;
            set;
        }

        public static string ApplicationInstallGuid
        {
            get;
            set;
        }

        public static string MsiRepository
        {
            get;
            set;
        }
    }
}
