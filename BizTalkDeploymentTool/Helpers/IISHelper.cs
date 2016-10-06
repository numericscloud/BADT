using System;
using System.Text;
using BizTalkDeploymentTool.Wmi;
using System.DirectoryServices;
using Microsoft.Web.Administration;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using BizTalkDeploymentTool.Global;


namespace BizTalkDeploymentTool.Helpers
{
    public static class IISHelper
    {
        /// <summary>
        /// Restart IIS on specified machine.
        /// </summary>
        /// <param name="computerName">Server on which to restart IIS.</param>
        /// <returns>Returns the result of execution as string.</returns> 
        public static bool RestartIIS(string computerName, out string message)
        {
            bool result = false;
            try
            {
                result = IIsWebService.Restart2(computerName, out message);
            }
            catch (Exception exe)
            {
                message = (String.Format("Error for computer {0}: {1}", computerName, exe.Message) + Environment.NewLine);
            }
            return result;
        }

        /// <summary>
        /// Restart IIS on all messaging servers in BizTalk group.
        /// </summary>
        /// <returns>Returns the result of execution as string.</returns> 
        public static string RestartIIS()
        {
            StringBuilder sb = new StringBuilder();
            int result;
            foreach (string computerName in GlobalProperties.MessagingServers)
            {
                try
                {
                    result = IIsWebService.Restart(computerName);
                    if (result == 0)
                    {
                        sb.Append(String.Format("IISRestart done with code :{0} for computer {1}", result, computerName) + Environment.NewLine);
                    }
                    else
                    {
                        sb.Append(String.Format("IISRestart done with error, code :{0} for computer {1}. Please verify and restart manually if required. Or re-run the action again.", result, computerName) + Environment.NewLine);
                    }
                }
                catch (Exception exe)
                {
                    sb.Append(String.Format("WMI method error for computer {0}: {1}", computerName, exe.Message) + Environment.NewLine);
                }
            }
            return sb.ToString();
        }


        public static bool CreateAppPool(string serverName, string appPoolName, string managedRuntimeVersion, string managedPipelineMode, string enable32Bit, string identityType, string userName, string password, out string message)
        {
            try
            {
                using (ServerManager serverManager = ServerManager.OpenRemote(serverName))
                {
                    ApplicationPool newPool = serverManager.ApplicationPools.Add(appPoolName);
                    newPool.ManagedRuntimeVersion = managedRuntimeVersion;
                    newPool.Enable32BitAppOnWin64 = Convert.ToBoolean(enable32Bit);
                    newPool.ManagedPipelineMode = (ManagedPipelineMode)Enum.Parse(typeof(ManagedPipelineMode), managedPipelineMode, true);
                    newPool.ProcessModel.IdentityType = (ProcessModelIdentityType)Enum.Parse(typeof(ProcessModelIdentityType), identityType, true);
                    newPool.ProcessModel.UserName = userName;
                    newPool.ProcessModel.Password = password;
                    serverManager.CommitChanges();
                    message = "";
                    return true;
                }
            }
            catch (Exception exe)
            {
                message = exe.Message;
                return false;
            }
        }

        public static bool DeleteAppPool(string serverName, string appPoolName, out string message)
        {
            try
            {
                if (String.IsNullOrEmpty(appPoolName))
                {
                    message = "DeleteApplicationPool: applicationPoolName is null or empty.";
                    return false;
                }

                using (ServerManager mgr = ServerManager.OpenRemote(serverName))
                {
                    ApplicationPool appPool = mgr.ApplicationPools[appPoolName];
                    if (appPool == null)
                    {
                        message = "Failed to find application pool.";
                        return false;
                    }
                    StringBuilder sbAppNames = new StringBuilder();
                    foreach (Site site in mgr.Sites)
                    {
                        foreach (Application app in site.Applications)
                        {
                            if (app.ApplicationPoolName.ToString() == appPoolName)
                            {
                                sbAppNames.AppendLine(app.Path);                               
                            }
                        }
                    }
                    if(sbAppNames.Length > 0)
                    {
                        message = string.Format("Can not delete application pool as one or more applications are associated with it.\r\n{0}Please change application pools for these applications before deleting.", sbAppNames.ToString());
                        return false;
                    }
                    ApplicationPoolCollection appColl = mgr.ApplicationPools;
                    appColl.Remove(appPool);
                    mgr.CommitChanges();

                    message = string.Format("Application pool: {0}, successfully deleted.", appPoolName);
                }
                return true;
            }
            catch (Exception ex)
            {
                message = String.Format("DeleteApplicationPool Error :: {0} ", ex.Message);
                return false;
            }
        }

        public static bool DeleteApplication(string serverName, string applicationName, string siteName, out string message)
        {
            try
            {
                using (ServerManager serverManager = ServerManager.OpenRemote(serverName))
                {
                    var applications = serverManager.Sites[siteName].Applications;
                    if (applications[applicationName] != null)
                    {
                        Application app = applications[applicationName];
                        if (app != null)
                        {
                            applications.Remove(app);
                            serverManager.CommitChanges();
                            message = "Application deleted successfully";
                            return true;
                        }
                    }
                    message = "Application does not exist on this server";
                    return false;
                }
            }
            catch (Exception exe)
            {

                message = exe.Message;
                return false;
            }

        }
        public static bool CreateApplication(string serverName, string applicationName, string path, string appPoolName, string siteName, out string message)
        {
            try
            {
                using (ServerManager serverManager = ServerManager.OpenRemote(serverName))
                {
                    Site defaultSite = serverManager.Sites[siteName];
                    var applications = defaultSite.Applications;
                    if (applications["/" + applicationName] == null)
                    {
                        applications.Add("/" + applicationName, path);
                        Application app = applications["/" + applicationName];
                        app.ApplicationPoolName = appPoolName;
                        serverManager.CommitChanges();
                        message = "Application created successfully";
                        return true;
                    }
                    else
                    {
                        message = "Failed creating application. Application already exists";
                        return false;
                    }
                }

            }
            catch (Exception exe)
            {
                message = exe.Message;
                return false;
            }

        }

        public static bool ChangeApplicationPool(string serverName, string applicationName, string appPoolName, string siteName, out string message)
        {
            try
            {
                using (ServerManager serverManager = ServerManager.OpenRemote(serverName))
                {
                    Site defaultSite = serverManager.Sites[siteName];
                    var applications = defaultSite.Applications;
                    if (applications[applicationName] != null)
                    {
                        string currentAppPool = applications[applicationName].ApplicationPoolName;
                        applications[applicationName].ApplicationPoolName = appPoolName;
                        serverManager.CommitChanges();
                        message = string.Format("Application pool successfully change from {0} to {1}", currentAppPool, appPoolName);
                        return true;
                    }
                    else
                    {
                        message = "Failed changing application pool. Application does not exists.";
                        return false;
                    }
                }

            }
            catch (Exception exe)
            {
                message = exe.Message;
                return false;
            }

        }

        public static List<string> GetAppList(List<string> serverList)
        {
            List<string> webAppList = new List<string>();

            using (ServerManager manager = new ServerManager())
            {
                foreach (var item in manager.Sites)
                {
                    for (int i = 0; i < item.Applications.Count; i++)
                    {
                        webAppList.Add(item.Applications[i].Path);
                        webAppList.Remove("/");
                    }

                }
            }

            /*foreach (var server in serverList)
            {
                using (ServerManager manager = ServerManager.OpenRemote(server))
                {
                    foreach (var item in manager.Sites)
                    {
                        for (int i = 0; i < item.Applications.Count; i++)
                        {
                            webAppList.Add(item.Applications[i].Path);
                            webAppList.Remove("/");
                        }

                    }
                }
            }*/

            return webAppList = (from webApp in webAppList select webApp).Distinct().ToList();
        }

        public static List<string> GetSiteAppList(string siteName)
        {
            List<string> webAppList = new List<string>();
            using (ServerManager manager = new ServerManager())
            {
                for (int i = 0; i < manager.Sites[siteName].Applications.Count; i++)
                {
                    webAppList.Add(manager.Sites[siteName].Applications[i].Path);
                    webAppList.Remove("/");
                }
            }
            return webAppList;
        }

        public static List<string> GetSvcOrAsmxName(string serverName, string webAppName, out string appPoolName)
        {
            string appPool = "";
            List<string> svcAsmx = new List<string>();
            using (ServerManager serverManager = ServerManager.OpenRemote(serverName))
            {
                foreach (var item in serverManager.Sites)
                {
                    Application application = item.Applications[webAppName];
                    if (application != null)
                    {
                        appPool = application.ApplicationPoolName;
                        var virtualRoot = application.VirtualDirectories.Where(v => v.Path == "/").Single();
                        string physicalPath = virtualRoot.PhysicalPath;
                        physicalPath = GenericHelper.FormatPath(serverName, physicalPath);
                        if (Directory.Exists(physicalPath))
                        {
                            foreach (var name in "*.svc | *.asmx".Split('|').SelectMany(filter => Directory.GetFiles(physicalPath, filter.Trim(), SearchOption.TopDirectoryOnly)))
                            {
                                string strippedname = name.Substring(name.LastIndexOf('\\') + 1);
                                svcAsmx.Add(strippedname);
                            }
                        }
                    }
                }
            }
            appPoolName = appPool;
            return svcAsmx;
        }

        public static bool CheckWebServiceStatus(string uri, out string message)
        {

            try
            {

                var httpRequest = (HttpWebRequest)WebRequest.Create(uri);
                httpRequest.Credentials = CredentialCache.DefaultNetworkCredentials;
                httpRequest.Timeout = 10000;
                var res = (HttpWebResponse)httpRequest.GetResponse();
                /* Ping ping = new Ping();
                 PingReply reply = ping.Send(uri);
                 if (reply.Status == IPStatus.Success)
                 {
                     message = "Service is up and running.";
                     return true;
                 }
                 else
                 {
                     message = res.StatusCode.ToString();
                     return false;
                 }*/
                if (res.StatusCode == HttpStatusCode.OK)
                {
                    message = "Service is up and running.";
                    return true;
                }
                else
                {
                    message = res.StatusCode.ToString();
                    return false;
                }
            }
            catch (Exception exe)
            {
                message = exe.Message;
                return false;
            }

        }
        private static SiteCollection GetSites(string server)
        {
            ServerManager serverManager = ServerManager.OpenRemote(server);
            return serverManager.Sites;
        }

        public static List<string> GetAppPools()
        {
            List<string> appPoolsList = new List<string>();
            ServerManager serverManager = new ServerManager();
            ApplicationPoolCollection sites = serverManager.ApplicationPools;
            foreach (var item in sites)
            {
                appPoolsList.Add(item.Name);
            }
            return appPoolsList;
        }
        private static ApplicationPoolCollection GetAppPools(string server)
        {
            ServerManager serverManager = ServerManager.OpenRemote(server);
            return serverManager.ApplicationPools;
        }

        public static ServerManager GetServerManager(string server, out ApplicationPoolCollection applicationPools, out SiteCollection sites)
        {
            ServerManager serverManager = ServerManager.OpenRemote(server);
            applicationPools = serverManager.ApplicationPools;            
            sites = serverManager.Sites;
            return serverManager;

        }

        public static string GetApplicationPoolOfApplication(string server, string application)
        {
            string applicationPool = string.Empty;
            using (ServerManager serverManager = ServerManager.OpenRemote(server))
            {
                foreach (var site in serverManager.Sites)
                {
                    foreach (var app in site.Applications)
                    {
                        if (app.Path == application)
                        {
                            applicationPool = app.ApplicationPoolName;
                            break;
                        }
                    }
                }
            }
            return applicationPool;

        }
        public static Site GetWebSItes(string server, string site)
        {
            ServerManager serverManager = ServerManager.OpenRemote(server);
            var q = from website in serverManager.Sites
                    where website.Name == site
                    select website;
            return q.FirstOrDefault();
        }

        public static object GetWebApplication(string server, string site, string webapplication)
        {
            ServerManager serverManager = ServerManager.OpenRemote(server);
            var q = from website in serverManager.Sites
                    where website.Name == site
                    select website;
            Site s = q.FirstOrDefault();
            var r = from app in s.Applications
                    where app.Path == webapplication
                    select app;
            return r.FirstOrDefault();
        }

        public static void UpdateAppPoolProperty(string serverName, ApplicationPool pool)
        {
            using (ServerManager serverManager = ServerManager.OpenRemote(serverName))
            {
                // serverManager.ApplicationPools
            }
        }

        internal static bool DoesApplicationPoolExists(string server, string applicationPool)
        {
            using (ServerManager manager = ServerManager.OpenRemote(server))
            {
                ApplicationPool appPool = manager.ApplicationPools[applicationPool];
                return appPool!=null ? true : false;
            }
        }

        internal static bool RecycleApplicationPool(string server, string applicationPool, out string message)
        {
            bool result = false;
            message = "";
            using (ServerManager manager = ServerManager.OpenRemote(server))
            {
                ApplicationPool appPool = manager.ApplicationPools[applicationPool];
                if (appPool != null)
                {
                    if (appPool.State == ObjectState.Stopped)
                    {
                        ObjectState newState = appPool.Start();
                        result = newState == ObjectState.Started ? true : false;
                        message = result ? "Application pool was in stopped state. Started the application pool.": "Application pool was in stopped state. Failed while starting application pool.";
                    }
                    else
                    {
                        ObjectState newState = appPool.Recycle();
                        result = newState == ObjectState.Started ? true : false;
                        message = result ? string.Format("Application pool: {0}, successfully recycled.", applicationPool) : "Failed while recycling application pool.";
                    }
                }
                else
                {
                    result = false;
                    message = string.Format("Application pool: {0} does not exists.", applicationPool);
                }
                manager.CommitChanges();
            }
            return result;
        }
    }
}
