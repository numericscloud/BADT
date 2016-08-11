using System;

namespace BizTalkDeploymentTool
{   
   public static class Constants
    {              
       public const string _CHECK_INPROGRESS_INSTANCE = "Check application's All In progress instances";
       public const string _SERVICE_INSTANCE_ID = "Service Instance ID";
       public const string _STOP_APPLICATION = "Stop application";
       public const string _RESTART_HOST = "Restart host instance {0}";
       public const string _START_HOST = "Start host instance {0}";
       public const string _STOP_HOST = "Stop host instance {0}";
       public const string _DELETE_APPLICATION = "Delete application";
       public const string _UNISTALL_APPLICATION = "Uninstall application: {0} from {1}";
       public const string _INSTALL_APPLICATION = "Install application on {0}";
       public const string _IMPORT_APPLICATION = "Import application";
       public const string _IMPORT_BINDING = "Import application binding";
       public const string _UNDEPLOY_ACTION_PAGE_TEXT = "UnDeploy Actions";
       public const string _DEPLOY_ACTION_PAGE_TEXT = "Deploy Actions";
       public const string _START_APPLICATION = "Start application";
       public const string _VALIDATE_START_APPLICATION = "Validate application status";
       public const string _DEPLOY_SSO = "Redeploy SSO Configuration";
       public const string _RESTART_IIS = "Restart IIS on {0}";
       public const string _RECYCLE_APPPOOL = "Recycle application pool {0} on server {1}";
       public const string _DELETE_APPPOOL = "Delete application pool {0} on server {1}";
       public const string _BIZTALK_WMI_ROOT = "\\root\\MicrosoftBizTalkServer";
       public const string _UN_INSTALL_WMI_ROOT = "\\root\\CIMV2";
       public const string _IIS_WMI_ROOT = "\\root\\MicrosoftIISv2";

       public const string _SSO_AFFILIATE_ROOT_NODE = "Affiliate Applications";
       
       public const string _UNINSTALL_REGISTRY = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\";
       public const string _SERVICES_REGISTRY = @"SYSTEM\CurrentControlSet\Services\";
       public const string _GACINFO_REGISTRY = @"SOFTWARE\Microsoft\Fusion\GACChangeNotification\Default";
       public const string _BIZTALK_INSTALLPATH_REGISTRY = @"SOFTWARE\Microsoft\BizTalk Server\3.0";
       public const string _BIZTALK_ADMIN_REGISTRY = @"SOFTWARE\Microsoft\BizTalk Server\3.0\Administration";
       public const string _TEMP_INTERNET_FOLDER_REGISTRY = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\User Shell Folders";
       
       public const string _ENVIRONMENT_TEMP_REGISTRY = @"SYSTEM\CurrentControlSet\Control\Session Manager\Environment";
       public const string _DB_CONN_STRING = "server={0};database={1};Integrated Security=SSPI";
       public const string _INPROGRESS_INSTANCE_QUERY = "SELECT count(*) FROM {0} WITH (NOLOCK) LEFT OUTER JOIN [Services] on {0}.uidServiceID = [Services].uidServiceID LEFT OUTER JOIN Modules on Modules.nModuleID = [Services].nModuleID WHERE nvcName='{1}'";
       public const string _INPROGRESS_INSTANCE_QUERYDATA =
           "SELECT " +
            "m.nvcName as Application, " +
                   "CASE i.nState " +
                    "WHEN 4 THEN 'Suspended (resumable)' " +
                    "WHEN 32 THEN 'Suspended (not resumable)' " +
                    "WHEN 1 THEN 'Ready to run' " +
                    "WHEN 8 THEN 'Dehydrated' " +
                    "WHEN 2 THEN 'Active' " +
                    "WHEN 16 THEN 'Completed with discarded message' " +
                    "WHEN 64 THEN 'InBreakpoint'	END as Status , " +
            "i.nvcErrorProcessingServer as 'Processing Server', " +
            "i.dtCreated as 'Creation Time', i.nvcErrorID as 'Error Code', i.nvcErrorDescription as 'Error Description', " +
            "i.uidInstanceID as '{0}', i.uidServiceID as 'Service Type ID', i.uidClassID as 'Service Class ID' " +
            "FROM {1} i WITH (NOLOCK) " +
            "LEFT OUTER JOIN [Services] on i.uidServiceID = [Services].uidServiceID " +
            "LEFT OUTER JOIN [Modules] m on m.nModuleID = [Services].nModuleID " +
            "WHERE m.nvcName='{2}'";
       public const string _INSTANCE_INP_TABLE = "Instances";
       public const string _INP_INSTANCE_SPNAME = "ops_OperateOnInstances";
       public const string _INITIAL_STATUS_SUFFIX = "Initial_.xml";
       public const string _AFTER_RUN_TOBECOMPARED_STATUS_SUFFIX = "AfterRunTobeCompared_.xml";
       public const string _BTDT_COMAPRE_STATUS = "BTDTApplicationStatusDifferenceReport.html";
       public const string _AFTER_RUN_STATUS_SUFFIX = "AfterRun_.xml";


       public const string _MSI_DEPLOY_TREENODE_TEXT = "Deploy Application(.msi) on farm";
       public const string _RESOURCE_DEPLOY_TREENODE_TEXT = "Deploy from resources(.dll) on farm";
       public const string _HOST_INSTANCE_TREENODE_TEXT = "Host Instances";
    }
}
