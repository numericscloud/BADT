using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.BizTalk.ExplorerOM;

namespace BizTalkDeploymentTool
{
    public static class BtsCatalogExplorerExtensions
    {
        public static bool ApplicationExists(this BtsCatalogExplorer catalogExplorer, string applicationName)
        {
            return catalogExplorer.Applications[applicationName]!=null;
        }
    }
}
