using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.BizTalk.ExplorerOM;
using BizTalkDeploymentTool.Helpers;
using BizTalkDeploymentTool.Global;

namespace BizTalkDeploymentTool.Actions
{
    public class BizTalkInfo
    {
        #region Static Filelds and Properties
        private static string _dbServer = null;
        private static string _mgmtDbName = null;

        public static string DbServerName
        {
            get
            {
                if (_dbServer == null)
                {
                    _dbServer = GlobalProperties.MgmtDBServer;
                }
                return _dbServer;
            }
        }
        public static string MgmtDbName
        {
            get
            {
                if (_mgmtDbName == null)
                {
                    _mgmtDbName = GlobalProperties.MgmtDBName;
                }
                return _mgmtDbName;
            }
        }

        #endregion

        public BtsCatalogExplorer CatalogExplorer { get; private set; }

        public BizTalkInfo():this(BizTalkInfo.DbServerName, BizTalkInfo.MgmtDbName)
        {
 
        }

        public BizTalkInfo(string dbServerName, string mgmtDBName)
        {
            ExplorerOMHelper explorerHelper = new ExplorerOMHelper(dbServerName, mgmtDBName);
            this.CatalogExplorer = explorerHelper.CatalogExplorer;
        }
    }
}
