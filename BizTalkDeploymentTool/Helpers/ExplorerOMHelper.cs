using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.BizTalk.ExplorerOM;

namespace BizTalkDeploymentTool
{
    /// <summary>
    /// ExplorerOM helper class.
    /// Contains list of methods that uses Microsoft.BizTalk.ExplorerOM for execution.
    /// </summary>    
    public class ExplorerOMHelper
    {
        public BtsCatalogExplorer CatalogExplorer
        {
            get;
            set;
        }

        private string DbServerName
        {
            get;
            set;
        }
        private string MgmtDBName
        {
            get;
            set;
        }

        public ExplorerOMHelper(string dbServerName, string mgmtDBName)
        {
            this.DbServerName = dbServerName;
            this.MgmtDBName = mgmtDBName;
            this.CatalogExplorer = CreateCatalogExplorer();
        }

        private BtsCatalogExplorer CreateCatalogExplorer()
        {
            BtsCatalogExplorer catalogExploerer = new BtsCatalogExplorer();
            catalogExploerer.ConnectionString = String.Format(Constants._DB_CONN_STRING, this.DbServerName, this.MgmtDBName);
            return catalogExploerer;
        }

        //private IEnumerable<Host> GetDistinctSendHandlerHosts(string applicationName)
        //{
        //    CatalogExplorer.Refresh();
        //    Application app = CatalogExplorer.Applications[applicationName];

        //    var query = (from SendPort sp in app.SendPorts
        //                 select sp.PrimaryTransport.SendHandler.Host).Union(
        //                from SendPort sp in app.SendPorts
        //                where sp.SecondaryTransport != null
        //                select sp.SecondaryTransport.SendHandler.Host).Distinct();




        //}

        ///// <summary>
        ///// Starts specified BizTalk application.
        ///// </summary>
        ///// <param name="applicationName">The application name to start.</param>
        //public void StartApplication(string applicationName)
        //{
        //    CatalogExplorer.Refresh();

        //    Application app = CatalogExplorer.Applications[applicationName];
        //    app.Start(Microsoft.BizTalk.ExplorerOM.ApplicationStartOption.StartAll);

        //    CatalogExplorer.SaveChanges();
        //    CatalogExplorer.Refresh();
        //}

        /////// <summary>
        ///// Stops specified BizTalk application.
        ///// </summary>
        ///// <param name="applicationName">The application name to stop.</param>   
        //public void StopApplication(string applicationName)
        //{
        //    CatalogExplorer.Refresh();

        //    Application app = CatalogExplorer.Applications[applicationName];
        //    app.Stop(Microsoft.BizTalk.ExplorerOM.ApplicationStopOption.StopAll);

        //    CatalogExplorer.SaveChanges();
        //    CatalogExplorer.Refresh();
        //}

        /// <summary>
        /// Gets HostNames associated with specified application.
        /// </summary>
        /// <param name="applicationName">The application name to check.</param>
        /// <returns>Returns Dictionary (string, bool),(HostName, Whether the host is associated with a dynamic send port)</returns>  
        public Dictionary<string, bool> GetHostNamesWithAsAResultOfDynamicPort(string applicationName)
        {
            CatalogExplorer.Refresh();

            Application app = CatalogExplorer.Applications[applicationName];
            Dictionary<string, bool> result = app.GetHostNamesWithAsAResultOfDynamicPort();
            return result;
        }

        /// <summary>
        /// Checks if the application exists in BizTalk Database.
        /// </summary>
        /// <param name="applicationName">The application name to check.</param>
        /// <returns>Returns true/false</returns>  
        /// 
        public bool DoesApplicationExists(string applicationName)
        {
            return GetApplication(applicationName) != null;
        }

        public void RemoveApplication(string applicationName)
        {
            BtsCatalogExplorer catalogExplorer = CreateCatalogExplorer();
            Application appToRemove = catalogExplorer.Applications[applicationName];
            catalogExplorer.RemoveApplication(appToRemove);
        }

        public Application GetApplication(string applicationName)
        {
            return CreateCatalogExplorer().Applications[applicationName];
        }

        public List<string> GetApplicationList(ApplicationCollection appCollection)
        {
            List<string> applicationNameList = new List<string>();
            for (int i = 0; i < appCollection.Count; i++)
            {
                applicationNameList.Add(appCollection[i].Name);
            }
            return applicationNameList;
        }

        public ApplicationCollection GetApplicationCollection()
        {
            List<string> applicationNameList = new List<string>();
            return CreateCatalogExplorer().Applications;
        }

        public Status GetApplicationStatus(string applicationName)
        {
            return CreateCatalogExplorer().Applications[applicationName].Status;
        }

        public List<string> GetAllReceiveLocations()
        {
            List<string> rcvLocList = new List<string>();
            ApplicationCollection appCollection = CreateCatalogExplorer().Applications;

            foreach (Application application in appCollection)
            {
                foreach (ReceivePort item in application.ReceivePorts)
                {
                    foreach (ReceiveLocation itemLoc in item.ReceiveLocations)
                    {

                        rcvLocList.Add(itemLoc.Address);
                    }
                }
            }
            return rcvLocList;

        }

        public ProtocolTypeCollection GetAdapters()
        {
            List<string> adapters = new List<string>();
            BtsCatalogExplorer catalogExplorer = CreateCatalogExplorer();
            return catalogExplorer.ProtocolTypes;
           
        }
    }
}
