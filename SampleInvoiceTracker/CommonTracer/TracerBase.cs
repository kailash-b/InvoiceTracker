namespace InvoiceTracker.CommonTracer {
    public abstract class TracerBase {
        public abstract void Trace(string message);
        public abstract void TraceError(string message);
        public abstract void TraceWarning(string message);
    }
}
