using System;
using System.Data;
using System.Data.SqlClient;
using BizTalkDeploymentTool.Wmi;
using BizTalkDeploymentTool.Global;

namespace BizTalkDeploymentTool.Helpers
{
    /// <summary>
    /// SQL helper class.
    /// Contains list of methods that uses SQL query and objects for execution.
    /// </summary>
    public static class SQLHelper
    {
        /// <summary>
        /// Checks if the specified application has any InProgress instance (Suspended and /or Running) in BizTalk.
        /// </summary>
        /// <param name="msiPath">The application name to check.</param>
        /// <returns>Returns true/fasle.</returns>  
        public static bool HasInProgressInstance(string applicationName, out int numberOfInstances)
        {
            return HasInProgressInstanceSQLQuery(string.Format(Constants._INPROGRESS_INSTANCE_QUERY, Constants._INSTANCE_INP_TABLE, applicationName), out numberOfInstances);
        }

        private static bool HasInProgressInstanceSQLQuery(string query, out int numberOfInstances)
        {
            bool retValue = false;
            using (SqlConnection conn = new SqlConnection(String.Format(Constants._DB_CONN_STRING, GlobalProperties.DatabaseServer, MSBTS_MsgBoxSetting.GetDatabaseName())))
            {
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Connection.Open();
                    numberOfInstances = (int)command.ExecuteScalar();
                    if (numberOfInstances > 0)
                    {
                        retValue = true;
                    }
                }
            }
            return retValue;

        }
        /// <summary>
        /// Get all InProgress instances for the given application as a DataTable
        /// </summary>
        /// <param name="applicationName">BizTalk application name for which instances status is required</param>
        /// <returns>A DataTable with deatils of each instance</returns>
        public static DataTable GetAllInProgressServiceInstances(string applicationName)
        {
            return GetAllServiceInstances(string.Format(Constants._INPROGRESS_INSTANCE_QUERYDATA, Constants._SERVICE_INSTANCE_ID, Constants._INSTANCE_INP_TABLE, applicationName));
        }

        private static DataTable GetAllServiceInstances(string query)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(String.Format(Constants._DB_CONN_STRING, GlobalProperties.DatabaseServer, MSBTS_MsgBoxSetting.GetDatabaseName())))
            {
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Connection.Open();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                    dataAdapter.Fill(dt);
                }
            }
            return dt;
        }

        private static bool HasInProgressInstanceSQLSP(string applicationName, string messageBoxDBServerName, string messageBoxDBName)
        {
            using (SqlConnection conn = new SqlConnection(String.Format(Constants._DB_CONN_STRING, messageBoxDBServerName, messageBoxDBName)))
            {
                using (SqlCommand command = new SqlCommand(Constants._INP_INSTANCE_SPNAME, conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@snOperation", SqlDbType.SmallInt).Value = 0;
                    command.Parameters.Add("@fMultiMessagebox", SqlDbType.TinyInt).Value = 0;
                    command.Parameters.Add("@uidInstanceID", SqlDbType.UniqueIdentifier).Value = Guid.Empty;
                    command.Parameters.Add("@nvcApplication", SqlDbType.NVarChar).Value = applicationName;
                    command.Parameters.Add("@snApplicationOperator", SqlDbType.SmallInt).Value = 1;
                    command.Parameters.Add("@nvcHost", SqlDbType.NVarChar).Value = string.Empty;
                    command.Parameters.Add("@snHostOperator", SqlDbType.SmallInt).Value = 0;
                    command.Parameters.Add("@nServiceClass", SqlDbType.Int).Value = 111;
                    command.Parameters.Add("@snServiceClassOperator", SqlDbType.SmallInt).Value = 0;
                    command.Parameters.Add("@uidServiceType", SqlDbType.UniqueIdentifier).Value = Guid.Empty;
                    command.Parameters.Add("@snServiceTypeOperator", SqlDbType.SmallInt).Value = 0;
                    command.Parameters.Add("@nStatus", SqlDbType.Int).Value = 495;
                    command.Parameters.Add("@snStatusOperator", SqlDbType.SmallInt).Value = 1;
                    command.Parameters.Add("@nPendingOperation", SqlDbType.Int).Value = 1;
                    command.Parameters.Add("@snPendingOperationOperator", SqlDbType.SmallInt).Value = 0;
                    command.Parameters.Add("@dtPendingOperationTimeFrom", SqlDbType.DateTime).Value = "1753-01-01 00:00:00";
                    command.Parameters.Add("@dtPendingOperationTimeUntil", SqlDbType.DateTime).Value = DateTime.MaxValue;
                    command.Parameters.Add("@dtStartFrom", SqlDbType.DateTime).Value = "1753-01-01 00:00:00";
                    command.Parameters.Add("@dtStartUntil", SqlDbType.DateTime).Value = DateTime.MaxValue;
                    command.Parameters.Add("@nvcErrorCode", SqlDbType.NVarChar).Value = string.Empty;
                    command.Parameters.Add("@snErrorCodeOperator", SqlDbType.SmallInt).Value = 0;
                    command.Parameters.Add("@nvcErrorDescription", SqlDbType.NVarChar).Value = string.Empty;
                    command.Parameters.Add("@snErrorDescriptionOperator", SqlDbType.SmallInt).Value = 0;
                    command.Parameters.Add("@nvcURI", SqlDbType.NVarChar).Value = string.Empty;
                    command.Parameters.Add("@snURIOperator", SqlDbType.SmallInt).Value = 0;
                    command.Parameters.Add("@dtStartSuspend", SqlDbType.DateTime).Value = "1753-01-01 00:00:00";
                    command.Parameters.Add("@dtEndSuspend", SqlDbType.DateTime).Value = DateTime.MaxValue;
                    command.Parameters.Add("@nvcAdapter", SqlDbType.NVarChar).Value = string.Empty;
                    command.Parameters.Add("@snAdapterOperator", SqlDbType.SmallInt).Value = 0;
                    command.Parameters.Add("@nGroupingCriteria", SqlDbType.Int).Value = 0;
                    command.Parameters.Add("@nGroupingMinCount", SqlDbType.Int).Value = 0;
                    command.Parameters.Add("@nMaxMatches", SqlDbType.Int).Value = 1;
                    command.Parameters.Add("@uidAccessorID", SqlDbType.UniqueIdentifier).Value = Guid.NewGuid();
                    command.Parameters.Add("@nIsMasterMsgBox", SqlDbType.Int).Value = 0;
                    command.Connection.Open();
                    return command.ExecuteReader(CommandBehavior.SingleResult).HasRows;
                }
            }
        }
    }
}
