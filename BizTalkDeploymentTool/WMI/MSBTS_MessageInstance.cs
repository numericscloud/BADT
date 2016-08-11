using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management;

namespace BizTalkDeploymentTool.Wmi
{
    public static class MSBTS_MessageInstance
    {
        private static List<string> GetMessageInstanceID(string serviceInstanceID)
        {
            List<string> _messageInstanceID = new List<string>();
            try
            {
                string query = string.Format("SELECT * FROM MSBTS_MessageInstance WHERE ServiceInstanceID = '{0}{1}{2}'", '{',serviceInstanceID,'}');
                
                foreach (ManagementObject queryObj in WMICommon.CreateSearcher(Constants._BIZTALK_WMI_ROOT, query).Get())
                {
                    _messageInstanceID.Add(queryObj["MessageInstanceID"].ToString());
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return _messageInstanceID;
        }

        public static string SaveToFile(string serviceInstanceID, string outputFolder)
        {
            StringBuilder outMessage = new StringBuilder();
            foreach (string messageInstanceID in GetMessageInstanceID(serviceInstanceID))
            {
                try
                {
                    string query = string.Format("MSBTS_MessageInstance.MessageInstanceID='{0}',MgmtDbNameOverride='',MgmtDbServerOverride='',ServiceInstanceID='{1}{2}{3}'",messageInstanceID,'{',serviceInstanceID,'}');
                    ManagementObject classInstance =
                             new ManagementObject(Constants._BIZTALK_WMI_ROOT, query, null);

                    // Obtain in-parameters for the method
                    ManagementBaseObject inParams = classInstance.GetMethodParameters("SaveToFile");

                    // Add the input parameters.
                    inParams["OutputFolderFullPath"] = outputFolder;

                    // Execute the method and obtain the return values.
                    ManagementBaseObject outParams = classInstance.InvokeMethod("SaveToFile", inParams, null);
                }
                catch (Exception e)
                {
                    outMessage.AppendLine(e.Message);
                }
            }
            return outMessage.ToString();
        }

    }
}
