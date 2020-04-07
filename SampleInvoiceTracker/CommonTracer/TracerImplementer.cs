using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Threading;

namespace InvoiceTracker.CommonTracer
{
    internal class TracerImplementer : TracerBase
    {
        private Type initialiser = null;
        public TracerImplementer(Type tracerType)
        {
            initialiser = tracerType;
            WriteHeaders();
        }
        public override void Trace(string message)
        {
            var traceEntry = GetTraceEntry(TraceLevel.Info, message);
            System.Diagnostics.Trace.TraceInformation(traceEntry);
        }

        public override void TraceError(string message)
        {
            var traceEntry = GetTraceEntry(TraceLevel.Error, message);
            System.Diagnostics.Trace.TraceInformation(traceEntry);
        }

        public override void TraceWarning(string message)
        {
            var traceEntry = GetTraceEntry(TraceLevel.Error, message);
            System.Diagnostics.Trace.TraceInformation(traceEntry);
        }

        //DateTime	»Namespace	»ClassName	»ProcessId	»ProcessName	»ThreadID
        //»TraceLevel »Description  »ExceptionInf »StackTrace	
        private string GetTraceEntry(TraceLevel level, string message, bool stackTraceReqd = false)
        {
            string delimeter = " »»» ";
            var builder = new StringBuilder();
            builder.Append(GetDateTime() + delimeter);
            builder.Append(initialiser.Namespace + delimeter);
            builder.Append(initialiser.Name + delimeter);
            builder.Append(Process.GetCurrentProcess().Id + delimeter);
            builder.Append(Process.GetCurrentProcess().ProcessName + delimeter);
            builder.Append(Thread.CurrentThread.ManagedThreadId + delimeter);
            builder.Append(level + delimeter);
            builder.Append(message + delimeter);
            if (stackTraceReqd)
            {
                builder.Append(Environment.StackTrace + "\n");
            }
            return builder.ToString();
        }

        private void WriteHeaders()
        {
            string delimeter = " »»» ";
            var builder = new StringBuilder();
            builder.Append("DateTime" + delimeter);
            builder.Append("Namespace" + delimeter);
            builder.Append("ClassName" + delimeter);
            builder.Append("ProcessID" + delimeter);
            builder.Append("Process Name" + delimeter);
            builder.Append("ThreadID" + delimeter);
            builder.Append("TraceLevel" + delimeter);
            builder.Append("Description" + delimeter);
            builder.Append("StackTrace" + "\n");
            System.Diagnostics.Trace.TraceInformation(builder.ToString());
        }
        private string GetDateTime()
        {
            var now = DateTime.Now;
            return now.ToString("dd/MM/yyyy HH:mm:ss.ffffff");
        }
    }
}
