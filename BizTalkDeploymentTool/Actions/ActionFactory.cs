using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BizTalkDeploymentTool.Wmi;
using BizTalkDeploymentTool.Helpers;
using System.Diagnostics;
using System.Linq;
using System.Collections;
using BizTalkDeploymentTool.Global;
namespace BizTalkDeploymentTool.Actions
{
    public static class ActionFactory
    {

        public struct ActionParameters
        {
            public string TargetEnvironment;
            public string PackageLocation;
            public string SSOConfigLocation;
            public string SSOAppname;
            public string SSOKey;
            public string SSOCompanyName;
            public string TargetDir;
            public string AppPoolName;
            public string AppPoolCLRVersion;
            public string AppPoolPipelineMode;
            public string AppPoolUserName;
            public string AppPoolPassword;
            public string Enable32Bit;
            public string IdentityType;
            public string PhysicalPath;
            public string AppName;
            public string SiteName;
            public string UnDeployExistingApplication;
            public string BTDFProjFileDirectory;
            public Dictionary<string, string> Configurations;
        }

        public static List<BaseAction> CreateActions(string applicationName, string msiLocation, List<string> webDirectories)
        {
            //OurStopWatch.Enter("CreateActions");
            List<string> messagingServers = GlobalProperties.MessagingServers;

            List<BaseAction> baseActions = new List<BaseAction>();
            BizTalkInfo bizTalkInfo = new BizTalkInfo();
            bool applicationExists = bizTalkInfo.CatalogExplorer.ApplicationExists(applicationName);

            ApplicationInfo appInfo = new ApplicationInfo();
            appInfo.ApplicationName = applicationName;

            if (applicationExists)
            {
                baseActions.Add(new CheckForInProgressInstancesAction(appInfo));
                baseActions.Add(new StopApplicationAction(appInfo, bizTalkInfo));
                baseActions.AddRange(CreateRestartHostInstancesActions(applicationName));
                /* Dictionary<string, bool> hostCollection = new Dictionary<string, bool>();

                 //OurStopWatch.Enter("GetHostNamesWithAsAResultOfDynamicPort");
                 hostCollection = bizTalkInfo.CatalogExplorer.Applications[applicationName].GetHostNamesWithAsAResultOfDynamicPort();

                 HostInstance.HostInstanceCollection hostInstances = HostInstance.GetInstances();

                 // Loop through all hosts of the application
                 //KeyValuePair<"HostInstance display name", "If the hostinstance was because app had dynamic ports"> 
                 foreach (KeyValuePair<string, bool> host in hostCollection)
                 {
                     // Loop through all host instances of a particular host
                     //OurStopWatch.Enter("GetEnabledHostInstanceName:"+host.Key);

                     var query = from HostInstance hi in hostInstances
                                 where !hi.IsDisabled & hi.HostName == host.Key
                                 select hi;

                     //foreach (string hostInstance in MSBTS_HostInstance.GetEnabledHostInstanceName(host.Key))

                     foreach (HostInstance hostInstance in query)
                     {
                         baseActions.Add(new RestartHostInstanceAction(host.Value, hostInstance));
                     }
                     //OurStopWatch.Exit();
                 }*/
                //OurStopWatch.Exit();
                baseActions.Add(new DeleteApplicationAction(appInfo, bizTalkInfo));
            }


            //OurStopWatch.Enter("UnInstallApplicationAction");
            foreach (string serverName in messagingServers)
            {
                if (GenericHelper.PingServer(serverName))
                {
                    try
                    {
                        string UninstallGuid = RegistryHelper.GetUninstallGuid(appInfo.ApplicationName, serverName);
                        if (!String.IsNullOrEmpty(UninstallGuid))
                        {
                            baseActions.Add(new UnInstallApplicationAction(appInfo, serverName));
                        }
                    }
                    catch (Exception)
                    {
                        baseActions.Add(new UnInstallApplicationAction(appInfo, serverName));
                    }
                }
                else
                {
                    baseActions.Add(new UnInstallApplicationAction(appInfo, serverName));
                }

            }
            //OurStopWatch.Exit();

            //OurStopWatch.Enter("InstallApplicationAction");
            foreach (string serverName in messagingServers)
            {
                baseActions.Add(new InstallApplicationAction(serverName, msiLocation, null));
            }
            //OurStopWatch.Exit();
            baseActions.Add(new ImportApplicationAction(appInfo, msiLocation));

            //baseActions.Add(new DeploySsoAction());

            if (webDirectories.Count > 0)
            {
                foreach (var item in webDirectories)
                {
                    foreach (string serverName in messagingServers)
                    {
                        if (GenericHelper.PingServer(serverName))
                        {
                            try
                            {
                                string applicationPool = IISHelper.GetApplicationPoolOfApplication(serverName, item);
                                if (!string.IsNullOrEmpty(applicationPool))
                                {
                                    baseActions.Add(new RecycleApplicationPool(serverName, applicationPool));
                                }
                            }
                            catch (Exception)
                            {
                            }
                        }

                    }
                }
            }
            baseActions.Add(new StartApplicationAction(appInfo, bizTalkInfo));
            baseActions.Add(new ValidateStartApplicationAction(appInfo, bizTalkInfo));
            //OurStopWatch.Exit();
            return baseActions;
        }


        public static List<BaseAction> CreateBTDFActions(string applicationName, string resourceName, string productName, string productCode)
        {
            List<string> messagingServers = GlobalProperties.MessagingServers;

            List<BaseAction> baseActions = new List<BaseAction>();
            BizTalkInfo bizTalkInfo = new BizTalkInfo();
            bool applicationExists = bizTalkInfo.CatalogExplorer.ApplicationExists(applicationName);

            ApplicationInfo appInfo = new ApplicationInfo();
            appInfo.ApplicationName = applicationName;
            if (applicationExists)
            {
                baseActions.Add(new CheckForInProgressInstancesAction(appInfo));
            }

            foreach (string serverName in messagingServers)
            {
                string uninstallString = RegistryHelper.GetUninstallCommandFor(productCode, serverName);
                if (!string.IsNullOrEmpty(uninstallString))
                {
                    baseActions.Add(new UnInstallBTDFMsiAction(uninstallString, serverName, applicationName));
                }
            }

            foreach (string serverName in messagingServers)
            {
                ResourceInfo resourceInfo = new ResourceInfo();
                resourceInfo.ServerName = serverName;
                resourceInfo.ResourceName = resourceName;
                baseActions.Add(new InstallBTDFMsiAction(resourceInfo));
            }

            for (int i = 0; i < messagingServers.Count; i++)
            {
                if (!messagingServers[i].Equals(Environment.MachineName))
                {
                    baseActions.Add(new DeployBTDFMsiAction(messagingServers[i]));
                }
            }
            for (int i = 0; i < messagingServers.Count; i++)
            {
                if (messagingServers[i].Equals(Environment.MachineName))
                {
                    baseActions.Add(new DeployBTDFMsiLastServerAction(messagingServers[i]));
                }
            }
            baseActions.Add(new ValidateStartApplicationAction(appInfo, bizTalkInfo));
            

            return baseActions;

        }

        public static void UpdateActions(List<BaseAction> actions, ActionParameters parameters)
        {
            foreach (BaseAction action in actions)
            {
                UpdateAction(action, parameters);
            }
        }

        public static BaseAction CreateResourceGacedAction(string serverName, string resourceName)
        {
            ResourceInfo resourceInfo = new ResourceInfo();
            resourceInfo.ServerName = serverName;
            resourceInfo.ResourceName = resourceName;
            return new ResourceGacedAction(resourceInfo);
        }

        public static BaseAction CreateGacAssemblyAction(string serverName, string resourceName)
        {
            ResourceInfo resourceInfo = new ResourceInfo();
            resourceInfo.ServerName = serverName;
            resourceInfo.ResourceName = resourceName;
            return new GacAssemblyAction(resourceInfo);
        }

        public static List<BaseAction> CreateRestartHostInstancesActions()
        {
            List<BaseAction> baseActions = new List<BaseAction>();
            HostInstance.HostInstanceCollection hostInstances = HostInstance.GetInstances();
            var query = from HostInstance hi in hostInstances
                        where !hi.IsDisabled && hi.HostType != HostInstance.HostTypeValues.Isolated
                        select hi;

            //foreach (string hostInstance in MSBTS_HostInstance.GetEnabledHostInstanceName(host.Key))

            foreach (HostInstance hostInstance in query)
            {
                baseActions.Add(new RestartHostInstanceAction(false, hostInstance));
            }
            return baseActions;
        }



        public static List<BaseAction> CreateRestartHostInstancesActions(string applicationName)
        {
            List<BaseAction> baseActions = new List<BaseAction>();
            Dictionary<string, bool> hostCollection = new Dictionary<string, bool>();
            BizTalkInfo bizTalkInfo = new BizTalkInfo();
            hostCollection = bizTalkInfo.CatalogExplorer.Applications[applicationName].GetHostNamesWithAsAResultOfDynamicPort();

            HostInstance.HostInstanceCollection hostInstances = HostInstance.GetInstances();

            // Loop through all hosts of the application
            //KeyValuePair<"HostInstance display name", "If the hostinstance was because app had dynamic ports"> 
            foreach (KeyValuePair<string, bool> host in hostCollection)
            {
                // Loop through all host instances of a particular host
                //OurStopWatch.Enter("GetEnabledHostInstanceName:"+host.Key);

                var query = from HostInstance hi in hostInstances
                            where !hi.IsDisabled & hi.HostName == host.Key
                            select hi;

                //foreach (string hostInstance in MSBTS_HostInstance.GetEnabledHostInstanceName(host.Key))

                foreach (HostInstance hostInstance in query)
                {
                    baseActions.Add(new RestartHostInstanceAction(host.Value, hostInstance));
                }
                //OurStopWatch.Exit();
            }
            return baseActions;
        }


        public static void UpdateAction(BaseAction action, ActionParameters parameters)
        {
            if (action is DeploySsoAction)
            {
                DeploySsoAction deploySsoAction = (DeploySsoAction)action;
                deploySsoAction.SsoConfigApplicationName = parameters.SSOAppname;
                deploySsoAction.SsoConfigLocation = parameters.SSOConfigLocation;
                deploySsoAction.SsoKey = parameters.SSOKey;
                deploySsoAction.SSOCompanyName = parameters.SSOCompanyName;
            }
            if (action is ImportApplicationAction)
            {
                ImportApplicationAction importApplicationAction = (ImportApplicationAction)action;
                importApplicationAction.TargetEnvironment = parameters.TargetEnvironment;
            }


            if (action is InstallApplicationAction)
            {
                InstallApplicationAction installApplicationAction = (InstallApplicationAction)action;
                installApplicationAction.TargetDir = parameters.TargetDir;
            }

            if (action is CreateIISAppAction)
            {
                CreateIISAppAction createIISAppAction = (CreateIISAppAction)action;
                createIISAppAction.AppName = parameters.AppName;
                createIISAppAction.AppPoolName = parameters.AppPoolName;
                createIISAppAction.SiteName = parameters.SiteName;
                createIISAppAction.PhysicalPath = parameters.PhysicalPath;
            }
            if (action is CreateAppPoolAction)
            {
                CreateAppPoolAction createAppPoolAction = (CreateAppPoolAction)action;
                createAppPoolAction.AppPoolName = parameters.AppPoolName;
                createAppPoolAction.AppPoolCLRVersion = parameters.AppPoolCLRVersion;
                createAppPoolAction.AppPoolPipelineMode = parameters.AppPoolPipelineMode;
                createAppPoolAction.Enable32Bit = parameters.Enable32Bit;
                createAppPoolAction.IdentityType = parameters.IdentityType;
                createAppPoolAction.AppPoolUserName = parameters.AppPoolUserName;
                createAppPoolAction.AppPoolPassword = parameters.AppPoolPassword;
            }
            if (action is ChangeWebAppPool)
            {
                ChangeWebAppPool changeWebAppPool = (ChangeWebAppPool)action;
                changeWebAppPool.ApplicationPool = parameters.AppPoolName;
            }
            if (action is DeployBTDFMsiAction)
            {
                DeployBTDFMsiAction DeployBTDFMsiAction = (DeployBTDFMsiAction)action;
                DeployBTDFMsiAction.TargetEnvironment = parameters.TargetEnvironment;
                DeployBTDFMsiAction.SkipUndeploy = (!Convert.ToBoolean(parameters.UnDeployExistingApplication)).ToString();
                DeployBTDFMsiAction.Configurations = parameters.Configurations;
                DeployBTDFMsiAction.BTDFProjFileDirectory = parameters.BTDFProjFileDirectory;
            }
            if (action is DeployBTDFMsiLastServerAction)
            {
                DeployBTDFMsiLastServerAction DeployBTDFMsiLastServerAction = (DeployBTDFMsiLastServerAction)action;
                DeployBTDFMsiLastServerAction.TargetEnvironment = parameters.TargetEnvironment;
                DeployBTDFMsiLastServerAction.SkipUndeploy = (!Convert.ToBoolean(parameters.UnDeployExistingApplication)).ToString();
                DeployBTDFMsiLastServerAction.Configurations = parameters.Configurations;
                DeployBTDFMsiLastServerAction.BTDFProjFileDirectory = parameters.BTDFProjFileDirectory;
            }
            if (action is InstallBTDFMsiAction)
            {
                InstallBTDFMsiAction InstallBTDFMsiAction = (InstallBTDFMsiAction)action;
                InstallBTDFMsiAction.TargetDir = parameters.TargetDir;
            }
        }

        public static List<BaseAction> CreateUnDeployActions(string applicationName)
        {
            //OurStopWatch.Enter("CreateActions");
            List<string> messagingServers = GlobalProperties.MessagingServers;

            List<BaseAction> baseActions = new List<BaseAction>();
            BizTalkInfo bizTalkInfo = new BizTalkInfo();
            bool applicationExists = bizTalkInfo.CatalogExplorer.ApplicationExists(applicationName);

            ApplicationInfo appInfo = new ApplicationInfo();
            appInfo.ApplicationName = applicationName;

            if (applicationExists)
            {
                baseActions.Add(new CheckForInProgressInstancesAction(appInfo));
                baseActions.Add(new StopApplicationAction(appInfo, bizTalkInfo));
                baseActions.Add(new DeleteApplicationAction(appInfo, bizTalkInfo));
            }
            //OurStopWatch.Enter("UnInstallApplicationAction");
            foreach (string serverName in messagingServers)
            {
                if (GenericHelper.PingServer(serverName))
                {
                    try
                    {
                        string UninstallGuid = RegistryHelper.GetUninstallGuid(appInfo.ApplicationName, serverName);
                        if (!String.IsNullOrEmpty(UninstallGuid))
                        {
                            baseActions.Add(new UnInstallApplicationAction(appInfo, serverName));
                        }
                    }
                    catch (Exception)
                    {
                        baseActions.Add(new UnInstallApplicationAction(appInfo, serverName));
                    }
                }
            }
            //OurStopWatch.Exit();
            return baseActions;
        }

        public static List<BaseAction> CreateDeployDependentAppsActions(string applicationName, string msiLocation, string targetEnv)
        {
            //OurStopWatch.Enter("CreateActions");
            List<string> messagingServers = GlobalProperties.MessagingServers;

            List<BaseAction> baseActions = new List<BaseAction>();
            BizTalkInfo bizTalkInfo = new BizTalkInfo();
            bool applicationExists = bizTalkInfo.CatalogExplorer.ApplicationExists(applicationName);

            ApplicationInfo appInfo = new ApplicationInfo();
            appInfo.ApplicationName = applicationName;

            if (applicationExists)
            {

                foreach (string serverName in messagingServers)
                {
                    baseActions.Add(new InstallApplicationAction(serverName, msiLocation, null));
                }
                ImportDependentApplicationAction importAppAction = new ImportDependentApplicationAction(appInfo, msiLocation, targetEnv);
                importAppAction.TargetEnvironment = targetEnv;
                baseActions.Add(importAppAction);

                //baseActions.Add(new DeploySsoAction());

                baseActions.Add(new StartApplicationAction(appInfo, bizTalkInfo));
                baseActions.Add(new ValidateStartApplicationAction(appInfo, bizTalkInfo));
            }
            //OurStopWatch.Exit();
            return baseActions;
        }

        public static List<BaseAction> CreateUnDeployDependentAppsActions(string applicationName, string msiLocation)
        {
            //OurStopWatch.Enter("CreateActions");
            List<string> messagingServers = GlobalProperties.MessagingServers;

            List<BaseAction> baseActions = new List<BaseAction>();
            BizTalkInfo bizTalkInfo = new BizTalkInfo();
            bool applicationExists = bizTalkInfo.CatalogExplorer.ApplicationExists(applicationName);

            ApplicationInfo appInfo = new ApplicationInfo();
            appInfo.ApplicationName = applicationName;

            if (applicationExists)
            {
                baseActions.Add(new StopApplicationAction(appInfo, bizTalkInfo));
                baseActions.Add(new DeleteApplicationAction(appInfo, bizTalkInfo));
                foreach (string serverName in messagingServers)
                {
                    if (GenericHelper.PingServer(serverName))
                    {
                        try
                        {
                            string UninstallGuid = RegistryHelper.GetUninstallGuid(appInfo.ApplicationName, serverName);
                            if (!String.IsNullOrEmpty(UninstallGuid))
                            {
                                baseActions.Add(new UnInstallApplicationAction(appInfo, serverName));
                            }
                        }
                        catch (Exception)
                        {
                            baseActions.Add(new UnInstallApplicationAction(appInfo, serverName));
                        }
                    }
                    else
                    {
                        baseActions.Add(new UnInstallApplicationAction(appInfo, serverName));
                    }

                }
            }


            return baseActions;
        }
    }
}
