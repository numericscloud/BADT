using System;

namespace BizTalkDeploymentTool.Wmi
{
    public static class WMIInstallErrorCodeResolver
    {
        public static string GetInstallErrorMessage(string errorCode)
        {
            string errorMessage = null;

            switch (errorCode)
            {
                case "0":
                    errorMessage = "The installation completed successfully.";
                    break;
                case "2":
                    errorMessage = "The system  cannot find the specified file.";
                    break;
                case "3":
                    errorMessage = "The system cannot find the path specified.";
                    break;
                case "1619":
                    errorMessage = "This installation package could not be opened, please  verify that it is accessible.";
                    break;
                case "1620":
                    errorMessage = "This installation package rcould not be opened, please verify that it is a valid MSI package.";
                    break;
                case "1259":
                    errorMessage = "The MSI is incompatible with current operating system installed on this machine.";
                    break;
                case "1601":
                    errorMessage = "Unable to access MSI service in this machine.";
                    break;
                case "1618":
                    errorMessage = "An installer already running on the machine.";
                    break;
                default:
                    errorMessage = "Unexpected error occured. Error Code:" + errorCode + "Please visit http://support.microsoft.com/kb/304888 to get additional details.";
                    break;
            }
            return errorMessage;
        }
    }
}
