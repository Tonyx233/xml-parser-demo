using System;
using System.IO;
using System.Threading;

namespace XmlMesDemo
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("=== XML MES Demo ===");
            Console.WriteLine("Starting SERVER + CLIENT ...");


            var server = new XmlCommandServer();
            server.Start(5001); // Start server
            Console.WriteLine("[MAIN] Server started.");

            Thread.Sleep(1000);

            // Read XML Flie
            string xmlPath = Path.Combine(AppContext.BaseDirectory, "sample-checkin.xml");
            if (!File.Exists(xmlPath))
            {
                Console.WriteLine($"[ERROR] sample XML not found: {xmlPath}");
                return;
            }

            string xml = File.ReadAllText(xmlPath);
            // Start client 
            var client = new XmlCommandClient("http://localhost:5001/command");
            bool ok = client.Send(xml);

            Console.WriteLine(ok ? "[MAIN] XML command success." : "[MAIN] XML command failed.");

            Console.WriteLine("\nPress ENTER to stop server...");
            Console.ReadLine();

            server.Stop();
        }
    }
}