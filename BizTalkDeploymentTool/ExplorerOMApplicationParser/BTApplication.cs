using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BizTalkDeploymentTool.Report
{
    [Serializable]
    public class BTApplication
    {
        public string Name
        {
            get;
            set;
        }
        public string Status
        {
            get;
            set;
        }
        public string Description
        {
            get;
            set;
        }
        public bool IsConfigured
        {
            get;
            set;
        }
        public bool IsDefaultApplication
        {
            get;
            set;
        }
        public bool IsSystem
        {
            get;
            set;
        }
        public BTApplicationBtsOrchestrationCollection BTApplicationBtsOrchestrationCollection
        {
            get;
            set;
        }
        public BTApplicationReceivePortCollection BTApplicationReceivePortCollection
        {
            get;
            set;
        }
        public BTApplicationSendPortCollection BTApplicationSendPortCollection
        {
            get;
            set;
        }
    }   
}
