using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizTalkDeploymentTool.Actions
{
    public class BreActionFactory
    {

        public static BaseAction CreateDeployActions(string policyName, string policyMajorVersion, string policyMinorVersion)
        {
            BreInfo breInfo = new BreInfo();
            breInfo.Name = policyName;
            breInfo.MajorVersion = policyMajorVersion;
            breInfo.MinorVersion = policyMinorVersion;
            return new DeployPolicyAction(breInfo);
        }

        public static BaseAction CreateUnDeployActions(string policyName, string policyMajorVersion, string policyMinorVersion)
        {
            BreInfo breInfo = new BreInfo();
            breInfo.Name = policyName;
            breInfo.MajorVersion = policyMajorVersion;
            breInfo.MinorVersion = policyMinorVersion;
            return new UnDeployPolicyAction(breInfo);
        }

        public static BaseAction CreateDeleteVocabularyActions(string name, string majorVersion, string minorVersion)
        {
            BreInfo breInfo = new BreInfo();
            breInfo.Name = name;
            breInfo.MajorVersion = majorVersion;
            breInfo.MinorVersion = minorVersion;
            return new DeleteVocabularyAction(breInfo);
        }

        public static BaseAction CreateDeletePolicyActions(string name, string majorVersion, string minorVersion)
        {
            BreInfo breInfo = new BreInfo();
            breInfo.Name = name;
            breInfo.MajorVersion = majorVersion;
            breInfo.MinorVersion = minorVersion;
            return new DeletePolicyAction(breInfo);
        }

        public static BaseAction CreateImportPublishActions(string brlFilePath)
        {
            BreInfo breInfo = new BreInfo();
            breInfo.BrlFilePath = brlFilePath;
            return new ImportPublishBrl(breInfo);
        }

        
    }
}
