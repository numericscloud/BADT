using BizTalkDeploymentTool.Helpers;
using BizTalkDeploymentTool.Wmi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BizTalkDeploymentTool.Global
{
    public static class GlobalProperties
    {
        private static List<string> _messagingServers;
        private static string _databaseServer;

        private static string _mgmtDBServer;
        private static string _mgmtDBName;

        public static List<string> MessagingServers
        {
            get
            {
                if (_messagingServers == null)
                {
                    _messagingServers = MSBTS_Server.GetMessagingServers();
                }
                return _messagingServers;
            }
        }
        public static string DatabaseServer
        {
            get
            {
                if (_databaseServer == null)
                {
                    _databaseServer = MSBTS_MsgBoxSetting.GetDatabaseServerName();
                }
                return _databaseServer;
            }
        }

        public static string MgmtDBServer
        {
            get
            {
                if (_mgmtDBServer == null)
                {
                    _mgmtDBServer = RegistryHelper.GetRegistryEntry(Constants._BIZTALK_ADMIN_REGISTRY, "MgmtDBServer");
                }
                return _mgmtDBServer;
            }
        }

        public static string MgmtDBName
        {
            get
            {
                if (_mgmtDBName == null)
                {
                    _mgmtDBName = RegistryHelper.GetRegistryEntry(Constants._BIZTALK_ADMIN_REGISTRY, "MgmtDBName");
                }
                return _mgmtDBName;
            }
        }
    }
}
