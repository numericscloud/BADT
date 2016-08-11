using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BizTalkDeploymentTool.Helpers;

namespace BizTalkDeploymentTool.Actions
{
    public class DeleteVocabularyAction : BreBaseAction
    {
        public override string DisplayName
        {
            get 
            {
                return "";
            }
        }
        public override bool IsAdminOnly
        {
            get
            {
                return false;
            }
        }
        public DeleteVocabularyAction(BreInfo breInfo)
            : base(breInfo)
        {           
        }

        public override bool Execute(out string message)
        {
            bool result = false;
            string exceptionMessage;

            int iresult = BreHelper.DeleteVocabulary(this.BreInfo.Name, Convert.ToInt32(this.BreInfo.MajorVersion), Convert.ToInt32(this.BreInfo.MinorVersion), out exceptionMessage);
            result = iresult == 0 ? true : false;
            message = result ? "Vocabulary successfully deleted." : exceptionMessage;           
            return result;
        }
    }
}
