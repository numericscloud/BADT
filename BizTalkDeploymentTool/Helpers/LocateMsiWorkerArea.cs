using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;

namespace BizTalkDeploymentTool.Helpers
{
    public class LocateMsiWorkerArea
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

        private string _msiPath;
        private bool _result = false;
        private ManualResetEvent _doneEvents;

        public event EventHandler<CompletedEventArgs> Completed;

        public string MSIPath { get { return _msiPath; } }
        public bool Result { get { return _result; } }
        public string InstallGuid { get; set; }

        public LocateMsiWorkerArea(string msiPath, ManualResetEvent doneEvent)
        {
            _msiPath = msiPath;
            _doneEvents = doneEvent;
        }

        public void ThreadPoolCallback(Object threadContext)
        {
            try
            {
                int threadIndex = (int)threadContext;
                if (this.InstallGuid == new MsiPackage(_msiPath).GetMsiProperty("ProductCode"))
                {
                    _result = true;
                }
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
