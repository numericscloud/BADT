using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BizTalkDeploymentTool.Report
{
    public class BTApplicationReceiveLocation
    {

        public string Name
        {
            get;
            set;
        }
        public string PublicAddress
        {
            get;
            set;
        }
        public string Address
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
        public bool Enable
        {
            get;
            set;
        }
        public DateTime StartDate
        {
            get;
            set;
        }
        public DateTime EndDate
        {
            get;
            set;
        }
        public bool StartDateEnabled
        {
            get;
            set;
        }
        public bool EndDateEnabled
        {
            get;
            set;
        }
        public DateTime FromTime
        {
            get;
            set;
        }
        public DateTime ToTime
        {
            get;
            set;
        }
        public bool IsPrimary
        {
            get;
            set;
        }
        public bool ServiceWindowEnabled
        {
            get;
            set;
        }
        public string ReceivePipelineData
        {
            get;
            set;
        }
        public string SendPipelineData
        {
            get;
            set;
        }
        public string TransportTypeData
        {
            get;
            set;
        }
        public string TransportTypeName
        {
            get;
            set;
        }
        public string ReceiveHandlerHostName
        {
            get;
            set;
        }
        public string ReceiveHandlerName
        {
            get;
            set;
        }
        public string ReceivePipelineTracking
        {
            get;
            set;
        }
        public string ReceivePipelineFullName
        {
            get;
            set;
        }
    }
}
