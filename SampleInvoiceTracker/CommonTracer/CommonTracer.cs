using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;

[assembly: InternalsVisibleTo("CommonTracer.Unit")]
namespace InvoiceTracker.CommonTracer {

    /// <summary>
    /// Utility to trace the different types of messages to text files.
    /// </summary>
    public class CommonTracer {
        /// <summary>
        /// Represents the actual tracer instance
        /// </summary>
        internal static TracerBase TracerInstance { get; set; }

        private static object syncObject = new object();

        public CommonTracer(Type tracerType) {
            // Initialise the tracer only if not initialised previously.
            // Enables unit testing 
            if (TracerInstance == null) {
                lock (syncObject) {
                    if (TracerInstance == null) {
                        TracerInstance = new TracerImplementer(tracerType);
                    }
                }
            }
        }

        /// <summary>
        /// <inheritdoc cref="TracerImplementer.Trace"/>
        /// </summary>
        /// /// <param name="message">The Human Readable message to be traced</param>
        public void TraceInfo(string message) {
            TracerInstance.Trace(message);
        }

        /// <summary>
        /// <inheritdoc cref="TracerImplementer.TraceError"/>
        /// </summary>
        /// <param name="message">The error message to be traced</param>
        public void TraceError(string message) {
            TracerInstance.TraceError(message);
        }

        /// <summary>
        /// <inheritdoc cref="TracerImplementer.TraceWarning"/>
        /// </summary>
        /// <param name="message">The warning message to be traced</param>
        public void TraceWarning(string message){
            TracerInstance.TraceWarning(message);
        }
    }
}
