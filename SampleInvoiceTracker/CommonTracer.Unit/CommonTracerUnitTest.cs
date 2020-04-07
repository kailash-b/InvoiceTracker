using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;

namespace InvoiceTracker.CommonTracer.Unit
{
    /// <summary>
    /// Verifies the basic functionality of the CommonTracer class
    /// </summary>
    [TestClass]
    public class CommonTracerUnitTest
    {
        [TestInitialize]
        public void TestSetup()
        {
            CommonTracer.TracerInstance = null;
        }

        [TestCleanup]
        public void TestTeardown()
        {
            CommonTracer.TracerInstance = null;
        }

        /// <summary>
        /// Verifies that the Info tracing is wired properly.
        /// </summary>
        [TestMethod]
        public void TraceInfoMethodShouldBeCalledWhenInfoTraceIsTraced()
        {
            var traceMessage = "Hi this is a sample Message";
            var mockTracerImpl = MockRepository.GenerateMock<TracerBase>();
            mockTracerImpl.Expect(
                x => x.Trace(traceMessage)).IgnoreArguments().Repeat.Once();
            CommonTracer.TracerInstance = mockTracerImpl;

            var tracer = new CommonTracer(typeof(CommonTracerUnitTest));
            tracer.TraceInfo(traceMessage);

            mockTracerImpl.VerifyAllExpectations();
        }

        /// <summary>
        /// Verifies that the Error message is traced properly 
        /// </summary>
        [TestMethod]
        public void TraceErrorMethodShouldBeCalledWhenErrorMessageIsTraced()
        {
            var traceMessage = "Hi this is a warning Message";
            var mockTracerImpl = MockRepository.GenerateMock<TracerBase>();
            mockTracerImpl.Expect(
                x => x.TraceError(traceMessage)).IgnoreArguments().Repeat.Once();
            CommonTracer.TracerInstance = mockTracerImpl;

            var tracer = new CommonTracer(typeof(CommonTracerUnitTest));
            tracer.TraceError(traceMessage);

            mockTracerImpl.VerifyAllExpectations();
        }

        /// Verifies that the Warning message is traced properly 
        [TestMethod]
        public void TraceWarningMethodShouldBeCalledWhenWarningMessageIsTraced()
        {
            var traceMessage = "Hi this is a sample warning message";
            var mockTracerImpl = MockRepository.GenerateMock<TracerBase>();
            mockTracerImpl.Expect(
                x => x.TraceWarning(traceMessage)).IgnoreArguments().Repeat.Once();
            CommonTracer.TracerInstance = mockTracerImpl;

            var tracer = new CommonTracer(typeof(CommonTracerUnitTest));
            tracer.TraceWarning(traceMessage);

            mockTracerImpl.VerifyAllExpectations();
        }
    }
}
