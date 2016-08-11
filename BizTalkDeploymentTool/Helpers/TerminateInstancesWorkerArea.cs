using BizTalkDeploymentTool.Wmi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;

namespace BizTalkDeploymentTool.Helpers
{
    public class TerminateInstancesWorkerArea
    {

        public class CompletedEventArgs : EventArgs
        {
            public readonly bool Result;
            public CompletedEventArgs(bool result)
            {
                this.Result = result;
            }
        }

        protected void OnCompleted(CompletedEventArgs e)
        {
            if (this.Completed != null)
            {
                this.Completed(this, e);
            }
        }

        private string _instanceID;
        private bool _result = false;
        private ManualResetEvent _doneEvents;

        public event EventHandler<CompletedEventArgs> Completed;

        public string InstanceID { get { return _instanceID; } }
        public bool Result { get { return _result; } }

        public TerminateInstancesWorkerArea(string instanceId, ManualResetEvent doneEvent)
        {
            _instanceID = instanceId;
            _doneEvents = doneEvent;
        }

        public void ThreadPoolCallback(Object threadContext)
        {
            try
            {
                int threadIndex = (int)threadContext;
                   MSBTS_ServiceInstance.Terminate(_instanceID);
                    _result = true;
            }
            catch (Exception)
            {
                _result = false;
            }
            finally
            {
                _doneEvents.Set();
                OnCompleted(new CompletedEventArgs(_result));
            }

        }
    }
}
