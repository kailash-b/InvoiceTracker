using System;
using System.Diagnostics;

namespace SampleInvoiceTracker
{
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Hi There!");
            Console.WriteLine(
                "This is a sample Console Application just to know how to add stuff to GitHub");
            while (Show()) {
            }
            Console.ReadKey();
        }

        private static bool Show() {
            Console.WriteLine("Press K to open my GitHub profile...");
            Console.WriteLine("Press any other key to exit");
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
