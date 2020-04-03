using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleInvoiceTracker
{
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Hi There!");
            Console.WriteLine(
                "This is a sample Console Application just to know how to add stuff to GitHub");
            while (true) {
                Console.WriteLine("Press K to open my GitHub profile...");
                Console.WriteLine("Press any other key to exit");
                var choice = Console.ReadLine();
                if (choice == "K") {
                    Process.Start("https://github.com/kailash-b?tab=repositories");
                } else {
                    break;
                }
                Console.ReadKey();
            }
        }
    }
}
