using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;

namespace BizTalkDeploymentTool
{
    interface ILogger
    {
        void Log(string text);
    }

    public class FileLogger
        : ILogger
    {
        public string FileName { get; private set; }

        public FileLogger(string fileName)
        {
            this.FileName = fileName;
        }

        public void Log(string message)
        {
            File.AppendAllLines(this.FileName, new[] { message });
        }
    }

    public struct FunctionEntry
    {
        public string FunctionName;
        public TimeSpan StartedAt;
    }

    public static class OurStopWatch
    {
        #region Const values
        static string _INDENTATION_STRING = "   ";
        #endregion

        #region Private properties
        private static Stopwatch _stopWatch;        
        private static Stack<FunctionEntry> _functionStack;
        private static ILogger _logger;
        //private static TimeSpan _latestTime;
        #endregion

        #region Constructor
        static OurStopWatch()
        {
            _functionStack = new Stack<FunctionEntry>();
            _stopWatch = new Stopwatch();
            _logger = new FileLogger(@"C:\Temp\BTDT.log");
        }
        #endregion

        private static void FreezeTime()
        {
            _stopWatch.Stop();
        }

        private static void UnfreezeTime()
        {
            _stopWatch.Start();
        }

        public static void Enter(string functionName)
        {
            FreezeTime();
            string message = string.Format("Enter {0}", functionName);
            Write(message);

            _functionStack.Push(new FunctionEntry() { FunctionName = functionName, StartedAt = _stopWatch.Elapsed });
            UnfreezeTime();
        }

        public static void Exit()
        {
            FreezeTime();
            FunctionEntry functionEntry = _functionStack.Pop();
            TimeSpan functionExecutionTime = _stopWatch.Elapsed - functionEntry.StartedAt;

            string message = string.Format("Exit {0} after {1}", functionEntry.FunctionName, functionExecutionTime);
            Write(message);
            UnfreezeTime();
        }

        private static int StackCount
        {
            get
            {
                return _functionStack.Count;
            }
        }

        public static void Start()
        {
            Write("--Start--");
            _stopWatch.Restart();
        }

        //public static void Record(string text)
        //{
        //    _stopWatch.Stop();
        //    string message = string.Format("{0} {1}", _stopWatch.Elapsed, text);
        //    Write(message);
        //    _stopWatch.Start();
        //}

        public static void Write(string message)
        {            
            string padLeft = String.Concat(Enumerable.Repeat<string>(_INDENTATION_STRING, StackCount));
            _logger.Log(padLeft + message);            
        }
        
    }
}
