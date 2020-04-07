using System;
using System.Diagnostics;

namespace InvoiceTracker.SampleInvoiceTracker {
    public class Program {
        private static readonly CommonTracer.CommonTracer tracer = 
            new CommonTracer.CommonTracer(typeof(Program));
        static void Main(string[] args) {
            tracer.TraceInfo("Hi There!");
            tracer.TraceInfo(
                "This is a sample Console Application just to know how to add new stuff to GitHub");
            while (Show()) {
            }
            Console.ReadKey();
        }

        private static bool Show() {
            tracer.TraceInfo("Press K to open my GitHub profile...");
            tracer.TraceInfo("Press any other key to exit");
            var choice = Console.ReadLine();
            if (choice == "K") {
                Process.Start("https://github.com/kailash-b?tab=repositories");
                return true;
            } else {
                return false;
            }
        }
    }
}
