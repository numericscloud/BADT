using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BizTalkDeploymentTool.Report
{
    public class BTApplicationReceivePortCollection
    {
        public List<BTApplicationReceivePort> BTApplicationReceivePorts
        { get; set; }
        public List<BTApplicationReceiveLocationCollection> BTApplicationReceiveLocationCollection
        {
            get;
            set;
        }
    }
}
