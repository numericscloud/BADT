using BizTalkDeploymentTool.Global;
using Microsoft.BizTalk.Deployment;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizTalkDeploymentTool.DependencyDeployment
{
    public class DependencyResolver
    {
        ExplorerOMHelper explorerHelper = new ExplorerOMHelper(GlobalProperties.MgmtDBServer, GlobalProperties.MgmtDBName);

        List<string> dependentAssemblies = new List<string>();
        public List<string> GetDependentAssemblies(AssemblyInfo assembly)
        {
            SqlConnection conn = new SqlConnection(string.Format("Data Source={0};Initial Catalog={1};Integrated Security=SSPI;", GlobalProperties.DatabaseServer, GlobalProperties.MgmtDBName));

            DependencyInfo di = new DependencyInfo();
            BizTalkAssemblyName btsAssName = new BizTalkAssemblyName(assembly.Name, assembly.Version, assembly.Culture, assembly.PublicKeyToken);
            List<BizTalkAssemblyName> list = di.GetUsedBy(conn, btsAssName);
            foreach (BizTalkAssemblyName assn in di.GetDependencyOrderedAssemblyNames(conn, list))
            {
                dependentAssemblies.Add(assn.FullName);
            }
            return dependentAssemblies;

        }


        public Dictionary<string, string> ResolveDependency(string applicationName)
        {
            Dictionary<string, string> dependency = new Dictionary<string, string>();
            List<string> depe = new List<string>();
            Microsoft.BizTalk.ExplorerOM.Application application = explorerHelper.GetApplication(applicationName);
            if (application != null)
            {
                var qassembly = from assembly in explorerHelper.GetApplication(applicationName).Assemblies.Cast<Microsoft.BizTalk.ExplorerOM.BtsAssembly>()
                                orderby assembly.DisplayName
                                select assembly;

                foreach (Microsoft.BizTalk.ExplorerOM.BtsAssembly assembly in qassembly.ToList())
                {
                    AssemblyInfo assemblyInfo = new AssemblyInfo();
                    assemblyInfo.Name = assembly.Name;
                    assemblyInfo.Version = assembly.Version;
                    assemblyInfo.Culture = assembly.Culture;
                    assemblyInfo.PublicKeyToken = assembly.PublicKeyToken;
                    depe.AddRange(GetDependentAssemblies(assemblyInfo));
                }
            }
            foreach (var item in depe)
            {
                foreach (Microsoft.BizTalk.ExplorerOM.BtsAssembly item2 in explorerHelper.CatalogExplorer.Assemblies)
                {
                    if (item == item2.DisplayName && item2.Application.Name != applicationName)
                    {
                        if (!dependency.ContainsKey(item))
                        {
                            dependency.Add(item, item2.Application.Name);
                        }
                    }
                }
            }

            // List referenced application
            if (application != null)
            {
                foreach (Microsoft.BizTalk.ExplorerOM.Application item in application.BackReferences)
                {
                    dependency.Add(item.Name + ": Referenced Application", item.Name);
                }
            }

            return dependency;
        }
    }
}
