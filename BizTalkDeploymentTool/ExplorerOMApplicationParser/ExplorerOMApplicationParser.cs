using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.BizTalk.ExplorerOM;

namespace BizTalkDeploymentTool.Report
{
    public static class ExplorerOMApplicationParser
    {
        public static BTApplication ParseExplorerOMApplication(Application app)
        {
            BTApplication application = new BTApplication();
            application.Name = app.Name;
            application.Description = app.Description;
            application.IsConfigured = app.IsConfigured;
            application.IsDefaultApplication = app.IsDefaultApplication;
            application.IsSystem = app.IsSystem;

            //Parse Orchestration
            List<BTApplicationBtsOrchestration> applicationOrchColl = new List<BTApplicationBtsOrchestration>();
            foreach (BtsOrchestration item in app.Orchestrations)
            {
                BTApplicationBtsOrchestration applicationOrch = new BTApplicationBtsOrchestration();
                applicationOrch.FullName = item.FullName;
                applicationOrch.AssemblyQualifiedName = item.AssemblyQualifiedName;
                applicationOrch.Status = item.Status.ToString();
                applicationOrch.Tracking = item.Tracking.ToString();
                if (item.Host != null)
                {
                    applicationOrch.HostName = item.Host.Name;
                }
                applicationOrchColl.Add(applicationOrch);
            }
            BTApplicationBtsOrchestrationCollection orchColl = new BTApplicationBtsOrchestrationCollection();
            orchColl.BTApplicationBtsOrchestrations = applicationOrchColl;
            application.BTApplicationBtsOrchestrationCollection = orchColl;

            //Parse Recieve Ports

            List<BTApplicationReceivePort> applicationRcvPortColl = new List<BTApplicationReceivePort>();
            foreach (ReceivePort item in app.ReceivePorts)
            {
   
                BTApplicationReceivePort applicationRcvPort = new BTApplicationReceivePort();
                applicationRcvPort.IsTwoWay = item.IsTwoWay;
                applicationRcvPort.Name = item.Name;
                applicationRcvPort.RouteFailedMessage = item.RouteFailedMessage;
                applicationRcvPort.SendPipelineData = item.SendPipelineData;
                applicationRcvPort.Tracking = item.Tracking.ToString();
                List<BTApplicationReceiveLocation> applicationRcvLocColl = new List<BTApplicationReceiveLocation>();
                foreach (ReceiveLocation itemRcvLoc in item.ReceiveLocations)
                {
                    BTApplicationReceiveLocation applicationRcvLoc = new BTApplicationReceiveLocation();
                    applicationRcvLoc.Address = itemRcvLoc.Address;
                    applicationRcvLoc.CustomData = itemRcvLoc.CustomData;
                    applicationRcvLoc.Description = itemRcvLoc.Description;
                    applicationRcvLoc.Enable = itemRcvLoc.Enable;
                    applicationRcvLoc.EndDate = itemRcvLoc.EndDate;
                    applicationRcvLoc.EndDateEnabled = itemRcvLoc.EndDateEnabled;
                    applicationRcvLoc.FromTime = itemRcvLoc.FromTime;
                    applicationRcvLoc.IsPrimary = itemRcvLoc.IsPrimary;
                    applicationRcvLoc.Name = itemRcvLoc.Name;
                    applicationRcvLoc.PublicAddress = itemRcvLoc.PublicAddress;
                    applicationRcvLoc.ReceivePipelineData = itemRcvLoc.ReceivePipelineData;
                    applicationRcvLoc.SendPipelineData = itemRcvLoc.SendPipelineData;
                    applicationRcvLoc.ServiceWindowEnabled = itemRcvLoc.ServiceWindowEnabled;
                    applicationRcvLoc.StartDate = itemRcvLoc.StartDate;
                    applicationRcvLoc.StartDateEnabled = itemRcvLoc.StartDateEnabled;
                    applicationRcvLoc.ToTime = itemRcvLoc.ToTime;
                    applicationRcvLoc.TransportTypeData = itemRcvLoc.TransportTypeData;
                    applicationRcvLoc.TransportTypeName = itemRcvLoc.TransportType.Name;
                    applicationRcvLoc.ReceiveHandlerHostName = itemRcvLoc.ReceiveHandler.Host.Name;
                    applicationRcvLoc.ReceiveHandlerName = itemRcvLoc.ReceiveHandler.Name;
                    applicationRcvLoc.ReceivePipelineTracking = itemRcvLoc.ReceivePipeline.Tracking.ToString();
                    applicationRcvLoc.ReceivePipelineFullName = itemRcvLoc.ReceivePipeline.FullName;
                    applicationRcvLocColl.Add(applicationRcvLoc);
                }               
                applicationRcvPort.BTApplicationReceiveLocation = applicationRcvLocColl;
                applicationRcvPortColl.Add(applicationRcvPort);
            }
            BTApplicationReceivePortCollection rcvPortColl = new BTApplicationReceivePortCollection();
            rcvPortColl.BTApplicationReceivePorts = applicationRcvPortColl;
            application.BTApplicationReceivePortCollection = rcvPortColl;


            //Parse Send Ports
            List<BTApplicationSendPort> applicationSndPortColl = new List<BTApplicationSendPort>();
            foreach (SendPort item in app.SendPorts)
            {
                BTApplicationSendPort applicationSndPort = new BTApplicationSendPort();
                applicationSndPort.Tracking = item.Tracking.ToString();
                applicationSndPort.CustomData = item.CustomData;
                applicationSndPort.Description = item.Description;
                applicationSndPort.Filter = item.Filter;
                applicationSndPort.IsDynamic = item.IsDynamic;
                applicationSndPort.IsTwoWay = item.IsTwoWay;
                applicationSndPort.Name = item.Name;
                applicationSndPort.OrderedDelivery = item.OrderedDelivery;
                if (item.ReceivePipeline != null)
                {
                    applicationSndPort.ReceivePipelineFullName = item.ReceivePipeline.FullName;
                    applicationSndPort.ReceivePipelineTracking = item.ReceivePipeline.Tracking.ToString();
                    applicationSndPort.ReceivePipelineData = item.ReceivePipelineData;
                }
                if (item.SendPipeline != null)
                {
                    applicationSndPort.SendPipelineFullName = item.SendPipeline.FullName;
                    applicationSndPort.SendPipelineTracking = item.SendPipeline.Tracking.ToString();
                    applicationSndPort.SendPipelineData = item.SendPipelineData;
                }
                if (item.PrimaryTransport != null)
                {
                    applicationSndPort.PrimaryAddress = item.PrimaryTransport.Address;
                    if (item.PrimaryTransport.SendHandler != null)
                    {
                        applicationSndPort.SendHandlerName = item.PrimaryTransport.SendHandler.Name;
                    }
                }
                applicationSndPort.RouteFailedMessage = item.RouteFailedMessage;
                applicationSndPort.Status = item.Status.ToString();
                applicationSndPort.StopSendingOnFailure = item.StopSendingOnFailure;
                applicationSndPort.Tracking = item.Tracking.ToString();
                applicationSndPortColl.Add(applicationSndPort);
            }
            BTApplicationSendPortCollection sndPrtColl = new BTApplicationSendPortCollection();
            sndPrtColl.BTApplicationSendPorts = applicationSndPortColl;
            application.BTApplicationSendPortCollection = sndPrtColl;

            return application;
        }
    }
}
