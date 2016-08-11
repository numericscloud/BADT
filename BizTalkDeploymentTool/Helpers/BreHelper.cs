using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.BizTalk.RuleEngineExtensions;
using Microsoft.RuleEngine;
using System.IO;
using System.Xml;
using BizTalkDeploymentTool.Extensions;

namespace BizTalkDeploymentTool.Helpers
{
    public static class BreHelper
    {
       
        public static string GetRules(RuleSetInfo ruleSetInfo)
        {
            string savedPath = Path.Combine(GenericHelper.GetTempFolder(Environment.MachineName), string.Format("{0}_{1}_{2}.xml", ruleSetInfo.Name, ruleSetInfo.MajorRevision.ToString(), ruleSetInfo.MinorRevision.ToString()));
            Microsoft.BizTalk.RuleEngineExtensions.RuleSetDeploymentDriver dd = new Microsoft.BizTalk.RuleEngineExtensions.RuleSetDeploymentDriver();
            dd.ExportRuleSetToFileRuleStore(ruleSetInfo, savedPath);
            string data = File.ReadAllText(savedPath, Encoding.UTF8);
            File.Delete(savedPath);
            XmlDocument xDoc = new XmlDocument();
            xDoc.LoadXml(data);
            return xDoc.Beautify();
        }

        public static RuleSetInfoCollection GetNamedRuleSets(string name)
        {
            RuleSetInfoCollection namedRuleCollection = new RuleSetInfoCollection();
            Microsoft.BizTalk.RuleEngineExtensions.RuleSetDeploymentDriver dd = new Microsoft.BizTalk.RuleEngineExtensions.RuleSetDeploymentDriver();
            RuleSetInfoCollection ruleCollection =  dd.GetDeployedRuleSets();
            foreach (RuleSetInfo rule in ruleCollection)
            {
                if(rule.Name == name)
                {
                    namedRuleCollection.Add(rule);
                }
            }
            return namedRuleCollection;

        }

        public static int Import(string fileName, out string message)
        {
            int result = 0;

            try
            {
               
                Microsoft.BizTalk.RuleEngineExtensions.RuleSetDeploymentDriver dd = new Microsoft.BizTalk.RuleEngineExtensions.RuleSetDeploymentDriver();               
                // SqlRuleStore - gives access t the rule engine database
                SqlRuleStore sqlRuleStore = (SqlRuleStore)dd.GetRuleStore();                    
                dd.ImportAndPublishFileRuleStore(fileName);
                message = "Successfully imported and published";
            }
            catch (Exception exe)
            {
                message = exe.Message;
                return -1;
            }

            return result;
        }

        public static RuleSetInfoCollection GetPublishedUndeployedRuleSets()
        {
            Microsoft.BizTalk.RuleEngineExtensions.RuleSetDeploymentDriver dd = new Microsoft.BizTalk.RuleEngineExtensions.RuleSetDeploymentDriver();
            return dd.GetPublishedUndeployedRuleSets();    
        }

        public static VocabularyInfoCollection GetPublishedVocabularies()
        {
            Microsoft.BizTalk.RuleEngineExtensions.RuleSetDeploymentDriver dd = new Microsoft.BizTalk.RuleEngineExtensions.RuleSetDeploymentDriver();                
            SqlRuleStore ruleStore = (SqlRuleStore)dd.GetRuleStore();
            return ruleStore.GetVocabularies(RuleStore.Filter.Published);            
        }

        public static RuleSetInfoCollection GetDeployedRuleSets()
        {
            Microsoft.BizTalk.RuleEngineExtensions.RuleSetDeploymentDriver dd = new Microsoft.BizTalk.RuleEngineExtensions.RuleSetDeploymentDriver();
            return dd.GetDeployedRuleSets();
        }

        public static int DeleteVocabulary(string name, int majorVersion, int minorVersion, out string message)
        {
            int result = 0;
            try
            {
                VocabularyInfo vInfo = new VocabularyInfo(name, majorVersion, minorVersion);
                Microsoft.BizTalk.RuleEngineExtensions.RuleSetDeploymentDriver rdd = new Microsoft.BizTalk.RuleEngineExtensions.RuleSetDeploymentDriver();
                SqlRuleStore ruleStore = (SqlRuleStore)rdd.GetRuleStore();
                ruleStore.Remove(vInfo);              
                message = "Successfully Deleted";

            }
            catch (Exception exe)
            {
                message = exe.Message;
                return -1;
            }

            return result;
        }

        public static int DeletePolicy(string name, int majorVersion, int minorVersion, out string message)
        {
            int result = 0;
            try
            {
                RuleSetInfo rInfo = new RuleSetInfo(name, majorVersion, minorVersion);
                Microsoft.BizTalk.RuleEngineExtensions.RuleSetDeploymentDriver rdd = new Microsoft.BizTalk.RuleEngineExtensions.RuleSetDeploymentDriver();
                SqlRuleStore ruleStore = (SqlRuleStore)rdd.GetRuleStore();
                ruleStore.Remove(rInfo);
                message = "Successfully Deleted";

            }
            catch (Exception exe)
            {
                message = exe.Message;
                return -1;
            }

            return result;
        }

       /* public static int ExportPolicy(string name, int majorVersion, int minorVersion,string filepath, out string message)
        {
            RuleSetInfo rInfo = new RuleSetInfo(name, majorVersion, minorVersion);
            Microsoft.BizTalk.RuleEngineExtensions.RuleSetDeploymentDriver rdd = new Microsoft.BizTalk.RuleEngineExtensions.RuleSetDeploymentDriver();
            rdd.ExportRuleSetToFileRuleStore(rInfo, filepath);
            RuleStore store = rdd.GetRuleStore();
          
        }*/


        public static int DeployPolicy(string policyName, int majorVersion, int minorVersion, out string message)
        {
            int result = 0;
            try
            {
                Microsoft.BizTalk.RuleEngineExtensions.RuleSetDeploymentDriver rdd = new Microsoft.BizTalk.RuleEngineExtensions.RuleSetDeploymentDriver();
                RuleSetInfo rsi = new RuleSetInfo(policyName, majorVersion, minorVersion);
                rdd.Deploy(rsi);
                message = "Successfully Deployed";
           
            }
            catch (Exception exe)
            {
                message = exe.Message;
                return -1;
            }
           
            return result;
        }

        public static int UnDeployPolicy(string policyName, int majorVersion, int minorVersion, out string message)
        {
            int result = 0;
            try
            {
                Microsoft.BizTalk.RuleEngineExtensions.RuleSetDeploymentDriver rdd = new Microsoft.BizTalk.RuleEngineExtensions.RuleSetDeploymentDriver();
                RuleSetInfo rsi = new RuleSetInfo(policyName, majorVersion, minorVersion);
                rdd.Undeploy(rsi);
                message = "Successfully Un-Deployed";

            }
            catch (Exception exe)
            {
                message = exe.Message;
                return -1;
            }

            return result;
        }

        private static List<VocabularyInfoCollection> GetDependentVocabulariesOnVocabulary(string brlFileName)
        {
            List<VocabularyInfoCollection> list = new List<VocabularyInfoCollection>();
            FileRuleStore frs = new FileRuleStore(brlFileName);
            VocabularyInfoCollection coll = frs.GetVocabularies(RuleStore.Filter.All);
            foreach (VocabularyInfo item in coll)
            {
                list.Add(frs.GetDependentVocabularies(item));
            }
            return list;
        }

        private static List<RuleSetInfoCollection> GetDependentRuleSetsOnVocabulary(string brlFileName)
        {
            List<RuleSetInfoCollection> list = new List<RuleSetInfoCollection>();
            FileRuleStore frs = new FileRuleStore(brlFileName);
            VocabularyInfoCollection coll = frs.GetVocabularies(RuleStore.Filter.All);
            foreach (VocabularyInfo item in coll)
            {
                list.Add(frs.GetDependentRuleSets(item));
            }
            return list;
        }
    }
}
