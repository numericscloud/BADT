using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BizTalkDeploymentTool.Helpers;

namespace BizTalkDeploymentTool.Actions
{
    public class ImportPublishBrl: BreBaseAction
    {
         public override string DisplayName
        {
            get 
            {
                return this.BreInfo.BrlFilePath;
            }
        }

         public override bool IsAdminOnly
         {
             get
             {
                 return false;
             }
         }

         public ImportPublishBrl(BreInfo breInfo)
            : base(breInfo)
        {           
        }

        public override bool Execute(out string message)
        {
            bool result = false;
            string exceptionMessage;

            int iresult = BreHelper.Import(this.BreInfo.BrlFilePath , out exceptionMessage);
            result = iresult == 0 ? true : false;
            message = result ? "Brl successfully imported and published." : exceptionMessage;           
            return result;
        }
    }
}
