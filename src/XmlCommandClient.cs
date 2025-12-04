using System;
using System.Net.Http;
using System.Text;

namespace XmlMesDemo
{
    public class XmlCommandClient
    {
        private readonly string _url;
        private readonly HttpClient _client = new HttpClient();

        public XmlCommandClient(string url)
        {
            _url = url;
        }

        public bool Send(string xml)
        {
            try
            {
                Console.WriteLine($"[CLIENT] POST XML to {_url}");

                var content = new StringContent(xml, Encoding.UTF8, "text/xml");
                var resp = _client.PostAsync(_url, content).Result;

                string respXml = resp.Content.ReadAsStringAsync().Result;

                Console.WriteLine("===== [CLIENT] Response XML =====");
                Console.WriteLine(respXml);
                Console.WriteLine("=================================");

                return resp.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[CLIENT] Send failed: {ex.Message}");
                return false;
            }
        }
    }
}