using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

namespace BizTalkDeploymentTool.Actions
{
    public enum ActionStatusEnum
    {
        Executing,
        Succeeded,
        Failed
    }
    public class ActionExecutingEventArgs : EventArgs
    {
        public readonly ActionStatusEnum ActionStatus;
        public readonly string Message;
        public readonly DateTime RunTime;
        public readonly BaseAction Action;       

        public ActionExecutingEventArgs(ActionStatusEnum actionStatus, DateTime runtTime, string message, BaseAction action)
        {
            this.ActionStatus = actionStatus;
            this.Message = message;
            this.RunTime = runtTime;
            this.Action = action;            
        }
    }

    public class ActionExecutedEventArgs : ActionExecutingEventArgs
    {
        public readonly TimeSpan Elapsed;
        public bool Cancel;

        public ActionExecutedEventArgs(ActionStatusEnum actionStatus, DateTime runtTime, string message, BaseAction action, TimeSpan elapsed)
            : base(actionStatus, runtTime, message, action)
        {
            this.Elapsed = elapsed;
            this.Cancel = false;
        }
    }

    public class CompletedEventArgs : EventArgs
    {
        public readonly bool Canceled;

        public CompletedEventArgs(bool canceled)
        {
            this.Canceled = canceled;
        }
    }

    public class ThreadProcessor
    {

        public bool IsRunning
        {
            get;
            private set;
        }


        #region Events

        public event EventHandler<CompletedEventArgs> Completed;
        public event EventHandler<ActionExecutingEventArgs> ActionExecuting;
        public event EventHandler<ActionExecutedEventArgs> ActionExecuted;

        protected void OnCompleted(CompletedEventArgs e)
        {
            if (this.Completed != null)
            {
                this.Completed(this, e);
            }
        }

        protected void OnActionExecuting(ActionExecutingEventArgs e)
        {
            if (this.ActionExecuting != null)
            {
                this.ActionExecuting(this, e);
            }
        }

        protected void OnActionExecuted(ActionExecutedEventArgs e)
        {
            if (this.ActionExecuted != null)
            {
                this.ActionExecuted(this, e);
            }
        }

        #endregion


        #region Constructors
        public ThreadProcessor()
        {
        }
        #endregion

        #region Fields
        private Thread _actionThread = null;
        #endregion

        public void AsyncRun(object parameter)
        {
            if (_actionThread != null)
            {
                throw new InvalidOperationException("ThreadProcessor is already started.");
            }

            _actionThread = new Thread(new ThreadStart(() => this.Run(parameter)));
            _actionThread.IsBackground = true;
            _actionThread.Start();
        }

       public void Run(object parameter)
        {
            bool canceled = false;
            try
            {
                this.IsRunning = true;
                List<BaseAction> actions = (List<BaseAction>)parameter;

                foreach (BaseAction action in actions)
                {
                    Stopwatch stopwatch = new Stopwatch();                    
                    try
                    {
                        string message;

                        // Execution phase
                        ActionExecutingEventArgs eExecuting = new ActionExecutingEventArgs(ActionStatusEnum.Executing, DateTime.MinValue, "", action);
                        OnActionExecuting(eExecuting);

                        // Completion phase
                        stopwatch.Start();
                        bool actionResult = action.Execute(out message);
                        stopwatch.Stop();

                        ActionExecutedEventArgs eExecuted = new ActionExecutedEventArgs((actionResult ? ActionStatusEnum.Succeeded : ActionStatusEnum.Failed), DateTime.Now, message, action, stopwatch.Elapsed);
                        OnActionExecuted(eExecuted);

                        if (!actionResult) break;

                        if (eExecuted.Cancel)
                        {
                            canceled = true;
                            break;
                        }
                    }
                    catch (Exception ex)
                    {
                        if (stopwatch.IsRunning)
                        {
                            stopwatch.Stop();
                        }

                        ActionExecutedEventArgs eExecuted = new ActionExecutedEventArgs(ActionStatusEnum.Failed, DateTime.Now, "Deployment process terminated: " + ex.Message, action, stopwatch.Elapsed);
                        OnActionExecuted(eExecuted);
                        break;
                    }
                }
            }
            finally
            {
                OnCompleted(new CompletedEventArgs(canceled)); // Check if there are any subscripbers to this event.               
                _actionThread = null;
                this.IsRunning = false;
            }
        }

        public void AsyncRunWorkUnits(object parameter)
        {
            if (_actionThread != null)
            {
                throw new InvalidOperationException("ThreadProcessor is already started.");
            }

            _actionThread = new Thread(new ThreadStart(() => this.RunWorkUnits(parameter)));
            _actionThread.IsBackground = true;
            _actionThread.Start();
        }

        public void AsyncRunAllWorkUnits(object parameter)
        {
            if (_actionThread != null)
            {
                throw new InvalidOperationException("ThreadProcessor is already started.");
            }

            _actionThread = new Thread(new ThreadStart(() => this.RunAllWorkUnits(parameter)));
            _actionThread.IsBackground = true;
            _actionThread.Start();
        }

        public void AsyncRunControlledWorkUnits(object parameter, int parallelThreshold)
        {
            if (_actionThread != null)
            {
                throw new InvalidOperationException("ThreadProcessor is already started.");
            }

            _actionThread = new Thread(new ThreadStart(() => this.RunControlledWorkUnits(parameter, parallelThreshold)));
            _actionThread.IsBackground = true;
            _actionThread.Start();
        }

        protected void RunWorkUnits(object parameter)
        {
            bool canceled = false;
            try
            {
                this.IsRunning = true;
                List<BaseAction> actions = (List<BaseAction>)parameter;

                // Partition the list of actions into actions that can be run in parallel
                List<List<BaseAction>> workUnits = new List<List<BaseAction>>();
                List<BaseAction> workUnit = new List<BaseAction>();

                BaseAction previousAction = null;
                foreach (BaseAction action in actions)
                {
                    // Different types of actions are grouped in different work units
                    if (previousAction != null && action.GetType() != previousAction.GetType())
                    {
                        workUnits.Add(workUnit);
                        workUnit = new List<BaseAction>();
                    }

                    workUnit.Add(action);
                    previousAction = action;
                }
                if (workUnit.Count > 0)
                {
                    workUnits.Add(workUnit);
                }

                // Iterate over 
                foreach (List<BaseAction> partition in workUnits)
                {
                    ParallelLoopResult loopResult = Parallel.ForEach<BaseAction>(partition, (action, loopState) =>
                    {
                        Stopwatch stopwatch = new Stopwatch();                    
                        try
                        {
                            string message;

                            // Execution phase
                            ActionExecutingEventArgs eExecuting = new ActionExecutingEventArgs(ActionStatusEnum.Executing, DateTime.MinValue, "", action);
                            OnActionExecuting(eExecuting);

                            // Completion phase
                            stopwatch.Start();
                            bool actionResult = action.Execute(out message);
                            stopwatch.Stop();

                            ActionExecutedEventArgs eExecuted = new ActionExecutedEventArgs((actionResult ? ActionStatusEnum.Succeeded : ActionStatusEnum.Failed), DateTime.Now, message, action, stopwatch.Elapsed);
                            OnActionExecuted(eExecuted);

                            //if (!actionResult) break;
                            if (!actionResult) loopState.Break();

                            if (eExecuted.Cancel)
                            {
                                canceled = true;
                                loopState.Break();
                                //break;
                            }
                        }
                        catch (Exception ex)
                        {
                            if (stopwatch.IsRunning)
                            {
                                stopwatch.Stop();
                            }

                            ActionExecutedEventArgs eExecuted = new ActionExecutedEventArgs(ActionStatusEnum.Failed, DateTime.Now, "Deployment process terminated: " + ex.Message, action, stopwatch.Elapsed);
                            OnActionExecuted(eExecuted);
                            // break;
                            loopState.Break();
                        }
                    });
                    if (loopResult.LowestBreakIteration.HasValue)
                    {
                        break;
                    }
                }
            }
            finally
            {
                OnCompleted(new CompletedEventArgs(canceled)); // Check if there are any subscripbers to this event.               
                _actionThread = null;
                this.IsRunning = false;
            }
        }

        protected void RunAllWorkUnits(object parameter)
        {
            bool canceled = false;
            try
            {
                this.IsRunning = true;
                List<BaseAction> actions = (List<BaseAction>)parameter;

                // Partition the list of actions into actions that can be run in parallel
                List<List<BaseAction>> workUnits = new List<List<BaseAction>>();
                List<BaseAction> workUnit = new List<BaseAction>();

                BaseAction previousAction = null;
                foreach (BaseAction action in actions)
                {
                    // Different types of actions are grouped in different work units
                    if (previousAction != null && action.GetType() != previousAction.GetType())
                    {
                        workUnits.Add(workUnit);
                        workUnit = new List<BaseAction>();
                    }

                    workUnit.Add(action);
                    previousAction = action;
                }
                if (workUnit.Count > 0)
                {
                    workUnits.Add(workUnit);
                }

                // Iterate over 
                foreach (List<BaseAction> partition in workUnits)
                {
                    ParallelLoopResult loopResult = Parallel.ForEach<BaseAction>(partition, (action, loopState) =>
                    {
                        Stopwatch stopwatch = new Stopwatch();
                        try
                        {
                            string message;

                            // Execution phase
                            ActionExecutingEventArgs eExecuting = new ActionExecutingEventArgs(ActionStatusEnum.Executing, DateTime.MinValue, "", action);
                            OnActionExecuting(eExecuting);

                            // Completion phase
                            stopwatch.Start();
                            bool actionResult = action.Execute(out message);
                            stopwatch.Stop();

                            ActionExecutedEventArgs eExecuted = new ActionExecutedEventArgs((actionResult ? ActionStatusEnum.Succeeded : ActionStatusEnum.Failed), DateTime.Now, message, action, stopwatch.Elapsed);
                            OnActionExecuted(eExecuted);

                            //if (!actionResult) break;
                            //if (!actionResult) loopState.Break();

                            if (eExecuted.Cancel)
                            {
                                canceled = true;
                                loopState.Break();
                                //break;
                            }
                        }
                        catch (Exception ex)
                        {
                            if (stopwatch.IsRunning)
                            {
                                stopwatch.Stop();
                            }

                            ActionExecutedEventArgs eExecuted = new ActionExecutedEventArgs(ActionStatusEnum.Failed, DateTime.Now, "Deployment process terminated: " + ex.Message, action, stopwatch.Elapsed);
                            OnActionExecuted(eExecuted);
                            // break;
                            loopState.Break();
                        }
                    });
                    if (loopResult.LowestBreakIteration.HasValue)
                    {
                        break;
                    }
                }
            }
            finally
            {
                OnCompleted(new CompletedEventArgs(canceled)); // Check if there are any subscripbers to this event.               
                _actionThread = null;
                this.IsRunning = false;
            }
        }

        protected void RunControlledWorkUnits(object parameter,int maxDegreeOfParallelism)
        {
            bool canceled = false;
            try
            {
                this.IsRunning = true;
                List<BaseAction> actions = (List<BaseAction>)parameter;

                // Partition the list of actions into actions that can be run in parallel
                List<List<BaseAction>> workUnits = new List<List<BaseAction>>();
                List<BaseAction> workUnit = new List<BaseAction>();

                BaseAction previousAction = null;
                foreach (BaseAction action in actions)
                {
                    // Different types of actions are grouped in different work units
                    if (previousAction != null && action.GetType() != previousAction.GetType())
                    {
                        workUnits.Add(workUnit);
                        workUnit = new List<BaseAction>();
                    }

                    workUnit.Add(action);
                    previousAction = action;
                }
                if (workUnit.Count > 0)
                {
                    workUnits.Add(workUnit);
                }

                // Iterate over 
                foreach (List<BaseAction> partition in workUnits)
                {
                    ParallelLoopResult loopResult = Parallel.ForEach<BaseAction>(partition,new ParallelOptions{MaxDegreeOfParallelism = maxDegreeOfParallelism }, (action, loopState) =>
                    {
                        Stopwatch stopwatch = new Stopwatch();
                        try
                        {
                            string message;

                            // Execution phase
                            ActionExecutingEventArgs eExecuting = new ActionExecutingEventArgs(ActionStatusEnum.Executing, DateTime.MinValue, "", action);
                            OnActionExecuting(eExecuting);

                            // Completion phase
                            stopwatch.Start();
                            bool actionResult = action.Execute(out message);
                            stopwatch.Stop();

                            ActionExecutedEventArgs eExecuted = new ActionExecutedEventArgs((actionResult ? ActionStatusEnum.Succeeded : ActionStatusEnum.Failed), DateTime.Now, message, action, stopwatch.Elapsed);
                            OnActionExecuted(eExecuted);

                            //if (!actionResult) break;
                            //if (!actionResult) loopState.Break();

                            if (eExecuted.Cancel)
                            {
                                canceled = true;
                                loopState.Break();
                                //break;
                            }
                        }
                        catch (Exception ex)
                        {
                            if (stopwatch.IsRunning)
                            {
                                stopwatch.Stop();
                            }

                            ActionExecutedEventArgs eExecuted = new ActionExecutedEventArgs(ActionStatusEnum.Failed, DateTime.Now, "Deployment process terminated: " + ex.Message, action, stopwatch.Elapsed);
                            OnActionExecuted(eExecuted);
                            // break;
                            loopState.Break();
                        }
                    });
                    if (loopResult.LowestBreakIteration.HasValue)
                    {
                        break;
                    }
                }
            }
            finally
            {
                OnCompleted(new CompletedEventArgs(canceled)); // Check if there are any subscripbers to this event.               
                _actionThread = null;
                this.IsRunning = false;
            }
        }
    }
}
