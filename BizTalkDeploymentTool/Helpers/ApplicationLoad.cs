using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizTalkDeploymentTool.Helpers
{
    public class ApplicationLoad
    {
        public Microsoft.BizTalk.ExplorerOM.Application Application
        {
            get;
            set;
        }
        public bool IsArtifactsLoaded
        {
            get;
            set;
        }
        public ApplicationLoad()
        {
        }

       /* public ApplicationLoad(Microsoft.BizTalk.ExplorerOM.Application application, bool isArtifactsLoaded)
        {
            this.Application = application;
            this.IsArtifactsLoaded = isArtifactsLoaded;
        }*/

    }
}
