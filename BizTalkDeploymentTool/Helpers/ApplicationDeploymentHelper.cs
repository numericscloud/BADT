using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BizTalkDeploymentTool.Helpers
{
    public class ApplicationDeploymentHelper
    {
        public static List<string> GetResources(string applicationName, string mgmtDBName, string dbServerName )
        {
            List<string> resourceList = new List<string>();
            Microsoft.BizTalk.ApplicationDeployment.Group grp = new Microsoft.BizTalk.ApplicationDeployment.Group { DBName = mgmtDBName, DBServer = dbServerName };
            Microsoft.BizTalk.ApplicationDeployment.Application app = grp.Applications[applicationName];            
            foreach (Microsoft.BizTalk.ApplicationDeployment.Resource item in app.ResourceCollection)
            {
                if (item.ResourceType == "System.BizTalk:Assembly" || item.ResourceType == "System.BizTalk:BizTalkAssembly")
                {
                    resourceList.Add(item.Luid);
                }
            }
            return resourceList;
        }
    }
}
