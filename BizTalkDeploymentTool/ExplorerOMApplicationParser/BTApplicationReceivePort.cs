using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BizTalkDeploymentTool.Report
{
    public class BTApplicationReceivePort
    {
        public string Name
        {
            get;
            set;
        }
        public bool IsTwoWay
        {
            get;
            set;
        }
        public bool RouteFailedMessage
        {
            get;
            set;
        }
        public string SendPipelineData
        {
            get;
            set;
        }
        public string Tracking
        {
            get;
            set;
        }
        public List<BTApplicationReceiveLocation> BTApplicationReceiveLocation
        {
            get;
            set;
        }
    }
}
