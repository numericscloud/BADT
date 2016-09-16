using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizTalkDeploymentTool.DependencyDeployment
{
    public class DependentApplicationProperties
    {
        [Description("List of assemblies the needs to be resolved"), ReadOnly(false)]
        public List<string> Assemblies { get; set; }
        [Description("Location of the selected Msi file"), ReadOnly(true)]
        public string MsiLocation { get; set; }
        [Description("Target environment binding of the selected Msi file"), ReadOnly(true)]
        public string Environment { get; set; }
       // [Description("Has the Un/deploy actions for the application loaded"), ReadOnly(true)]
       // public bool ActionsLoaded { get; set; }
        [Description("Is the Msi file selected"), ReadOnly(true)]
        public bool MsiSelected { get; set; }
        [Description("Installation Guid of the application on current machine"), ReadOnly(true)]
        public string GuidInstalledApplication { get; set; }
        [Description("Installation Guid (Product code) of the selected Msi file"), ReadOnly(true)]
        public string GuidApplicationMsi { get; set; }
    }
}
