using System;
using System.Linq;
using Microsoft.BizTalk.ApplicationDeployment;
using System.Collections.Generic;

namespace BizTalkDeploymentTool
{
    /// <summary>
    /// MSI helper class.
    /// Contains list of methods that uses Microsoft.BizTalk.ApplicationDeployment.Engine to execute methods.
    /// </summary>
    public static class MsiHelper
    {
        /// <summary>
        /// Gets a list of all the target environments bundled in the specified BizTalk msi file.
        /// </summary>
        /// <param name="msiPath">The path of the BizTalk msi.</param>
        /// <returns>Returns List, with a list of all target environments.</returns>  
        public static List<string> GetTargetEnvironmentList(string msiPath)
        {
            List<string> targetEnvironmentlist = new List<string>();
            targetEnvironmentlist.Add("<Default>");
            var query = (from resource in DeploymentUnit.ScanPackage(msiPath).Resources
                         from property in resource.Properties
                         where resource.ResourceType == "System.BizTalk:BizTalkBinding"
                                && property.Key == "TargetEnvironment"
                                && (string)property.Value != string.Empty
                         orderby (string)property.Value
                         select (string)property.Value).Distinct();
            targetEnvironmentlist.AddRange(query);
            return targetEnvironmentlist;
        }
    }
}
