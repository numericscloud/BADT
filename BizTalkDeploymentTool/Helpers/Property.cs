using System;
using System.Windows.Forms;

namespace BizTalkDeploymentTool
{
    public static class Property
    {
        /// <summary>
        /// BizTalk environments enum list in the organization.
        /// </summary>
        public enum BizTalkEnvironmentEnum
        {
            PRD,
            ACP,
            TST,
            DEV,
        }

        /// <summary>
        /// Enum list for the various states a host instances can take in a biztalk group.
        /// </summary>
        public enum HostInstanceState
        {
            Stopped = 1,
            StartPending = 2,
            StopPending = 3,
            Running = 4,
            ContinuePending = 5,
            PausePending = 6,
            Paused = 7,
            Unknown = 8,
        }

        /// <summary>
        /// Enum list for various types of hosts that can exist in a biztalk group.
        /// </summary>
        public enum HostInstanceType
        {
            InProcess = 1,
            Isolated = 2,            
        } 
        private static BizTalkEnvironmentEnum _bizTalkEnvironment;
        private static bool _bizTalkEnvironmentInitialised = false;

        /// <summary>
        /// 
        /// </summary>
        public static BizTalkEnvironmentEnum BizTalkEnvironment
        {
            get
            {
                if (!_bizTalkEnvironmentInitialised)
                {
                    string computerName = SystemInformation.ComputerName.ToUpper();
                    if (computerName.Contains("TST"))
                    {
                        _bizTalkEnvironment = BizTalkEnvironmentEnum.TST;
                    }
                    else if (computerName.Contains("ACP"))
                    {
                        _bizTalkEnvironment = BizTalkEnvironmentEnum.ACP;
                    }
                    else if (computerName.Contains("PRD"))
                    {
                        _bizTalkEnvironment = BizTalkEnvironmentEnum.PRD;
                    }
                    else
                    {
                        _bizTalkEnvironment = BizTalkEnvironmentEnum.DEV;
                    }
                }
                return _bizTalkEnvironment;
            }
        }
    }
}
