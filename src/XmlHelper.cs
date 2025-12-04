using System;
using System.Xml.Linq;

namespace XmlMesDemo
{
    public static class XmlHelper
    {
        public static XElement Parse(string xml)
        {
            try
            {
                return XElement.Parse(xml);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[XML] Parse failed: {ex.Message}");
                return null;
            }
        }

        public static string BuildAck(string status, string message)
        {
            return
$@"<Ack status=""{status}"" message=""{message}"" />";
        }
    }
}