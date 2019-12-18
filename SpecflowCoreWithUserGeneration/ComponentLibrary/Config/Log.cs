using System;
using System.Diagnostics;
using NLog;

namespace ComponentLibrary.Config
{
    public class Log
    {
        public Log()
        {

        }

        // For all possible object constructor options
        public static T InstanceOfs<T>(params object[] paramArray)
        {
            T obj = (T)Activator.CreateInstance(typeof(T), args: paramArray);

            StackTrace stackTrace = new StackTrace();
            Console.WriteLine($"{obj.GetType().Name} {stackTrace.GetFrame(1).GetMethod().Name}"); // gets task name and method name

            //step name
            var fc = stackTrace.FrameCount;
            StackFrame sf = stackTrace.GetFrame(0);
            sf = stackTrace.GetFrame(fc - 24);

            Logger logger = LogManager.GetLogger(sf.GetMethod().Name);
            logger.Info($"{obj.GetType().Name} {stackTrace.GetFrame(1).GetMethod().Name}");
            return obj;
        }

        public static void Debug(string message,
        [System.Runtime.CompilerServices.CallerFilePath] string sourceFilePath = "", 
        [System.Runtime.CompilerServices.CallerMemberName] string memberName = "",
        [System.Runtime.CompilerServices.CallerLineNumber] int callerLineNumber = 0)
        {
            Logger logger = LogManager.GetLogger($"Debug");

            string className = $"Class: {sourceFilePath.Substring(sourceFilePath.IndexOf("ComponentLibrary"))}";
            string methodName = $"Method: {memberName}";
            string lineNumber = $"line({callerLineNumber}) ";

            logger.Debug($"{className} {methodName} {lineNumber} {message}");
        }

        public static Exception Exception(string exceptionString)
        {
            Console.WriteLine("THIS IS THE EXCEPTION : " + exceptionString);

            StackTrace stackTrace = new StackTrace();

            //step name
            var fc = stackTrace.FrameCount;
            StackFrame sf = stackTrace.GetFrame(0);
            sf = stackTrace.GetFrame(fc - 24);

            Logger logger = LogManager.GetLogger(sf.GetMethod().Name);
            logger.Debug(exceptionString);

            return new Exception(exceptionString);
        }
        
        public static void Action(string message)
        {
            StackTrace stackTrace = new StackTrace();
            //step name
            var fc = stackTrace.FrameCount;
            StackFrame sf = stackTrace.GetFrame(0);
            sf = stackTrace.GetFrame(fc - 24);

            Logger logger = LogManager.GetLogger(sf.GetMethod().Name);

            logger.Info($"               by {message}");
        }

        public static void Task(string message)
        {
            StackTrace stackTrace = new StackTrace();
            //step name
            var fc = stackTrace.FrameCount;
            StackFrame sf = stackTrace.GetFrame(0);
            sf = stackTrace.GetFrame(fc - 24);

            Logger logger = LogManager.GetLogger(sf.GetMethod().Name);

            logger.Info($"User attempts to {message}");
        }

        public static void Observation(string message)
        {
            StackTrace stackTrace = new StackTrace();
            //step name
            var fc = stackTrace.FrameCount;
            StackFrame sf = stackTrace.GetFrame(0);
            sf = stackTrace.GetFrame(fc - 24);

            Logger logger = LogManager.GetLogger(sf.GetMethod().Name);
            logger.Info($"User should see {message}");
        }
        public static void MetaData(string message)
        {
            StackTrace stackTrace = new StackTrace();
            //step name
            var fc = stackTrace.FrameCount;
            StackFrame sf = stackTrace.GetFrame(0);
            sf = stackTrace.GetFrame(fc - 24);

            Logger logger = LogManager.GetLogger(sf.GetMethod().Name);
            logger.Info($"{message}");
        }

        public static void ObservationOutcome(string message)
        {
            StackTrace stackTrace = new StackTrace();
            //step name
            var fc = stackTrace.FrameCount;
            StackFrame sf = stackTrace.GetFrame(0);
            sf = stackTrace.GetFrame(fc - 24);

            Logger logger = LogManager.GetLogger(sf.GetMethod().Name);
            logger.Info($"User found {message}");
        }

    }
}
