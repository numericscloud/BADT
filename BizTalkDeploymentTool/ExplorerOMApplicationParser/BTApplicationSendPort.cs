using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BizTalkDeploymentTool.Report
{
    public class BTApplicationSendPort
    {
        public string Name
        {
            get;
            set;
        }
        public string CustomData
        {
            get;
            set;
        }
        public string Description
        {
            get;
            set;
        }
        public string Filter
        {
            get;
            set;
        }
        public bool IsDynamic
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
        public bool OrderedDelivery
        {
            get;
            set;
        }
        public string ReceivePipelineFullName
        {
            get;
            set;
        }
        public string ReceivePipelineTracking
        {
            get;
            set;
        }
        public string ReceivePipelineData
        {
            get;
            set;
        }
        public string SendPipelineFullName
        {
            get;
            set;
        }
        public string SendPipelineTracking
        {
            get;
            set;
        }
        public string SendPipelineData
        {
            get;
            set;
        }
        public string Status
        {
            get;
            set;
        }
        public bool StopSendingOnFailure
        {
            get;
            set;
        }
        public string Tracking
        {
            get;
            set;
        }
        public string PrimaryAddress
        {
            get;
            set;
        }
        public string SendHandlerName
        {
            get;
            set;
        }
    }
}
