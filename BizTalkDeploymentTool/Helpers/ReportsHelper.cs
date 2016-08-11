using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Diagnostics;
using System.Windows.Forms;

namespace BizTalkDeploymentTool.Report
{
   public class ReportsHelper
    {
        static string diffFile = null;
       public static void GenerateReport(string fileName)
       {
           Process applicationStatus = new Process();
           applicationStatus.StartInfo.FileName = "iexplore.exe";
           applicationStatus.StartInfo.Arguments = fileName;
           applicationStatus.Start();
       }     

       

       public static void CleanReport()
       {
          
       }

    }
}
