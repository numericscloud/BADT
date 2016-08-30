using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizTalkDeploymentTool.DependencyDeployment
{
    public class AssemblyInfo
    {
        public string Name { get; set; }
        public string Version { get; set; }
        public string Culture { get; set; }
        public string PublicKeyToken { get; set; }
    }

    public class DependentApplicationInfo
    {
        public string AssemblyName { get; set; }
        public string ApplicationName { get; set; }
    }
}
