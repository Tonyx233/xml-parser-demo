using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace XmlMesDemo
{
    public class XmlCommandServer
    {
        private HttpListener _listener;
        private bool _running = false;

        public void Start(int port)
        {
            _listener = new HttpListener();
            _listener.Prefixes.Add($"http://+:{port}/command/");
            _listener.Start();
            _running = true;

            Console.WriteLine($"[SERVER] XML Server started at http://localhost:{port}/command");

            Task.Run(ListenLoop);
        }

        private async Task ListenLoop()
        {
            while (_running)
            {
                try
                {
                    var ctx = await _listener.GetContextAsync();
                    var req = ctx.Request;
                    var resp = ctx.Response;

                    if (req.HttpMethod != "POST")
                    {
                        resp.StatusCode = 405;
                        resp.Close();
                        continue;
                    }

                    using var reader = new System.IO.StreamReader(req.InputStream, req.ContentEncoding);
                    string xml = await reader.ReadToEndAsync();

                    Console.WriteLine("===== [SERVER] Received XML =====");
                    Console.WriteLine(xml);
                    Console.WriteLine("=================================");

                    // Analyze XML
                    var doc = XmlHelper.Parse(xml);

                    // Acquire attributes
                    string cmd = doc?.Attribute("name")?.Value ?? "";
                    string sn = doc?.Attribute("sn")?.Value ?? "";

                    Console.WriteLine($"[SERVER] Parsed name={cmd}, sn={sn}");

                    // Create ACK XML
                    string ack = XmlHelper.BuildAck("OK", $"Command '{cmd}' received.");

                    byte[] data = Encoding.UTF8.GetBytes(ack);
                    resp.ContentType = "text/xml";
                    resp.StatusCode = 200;
                    resp.OutputStream.Write(data, 0, data.Length);
                    resp.Close();
                }
                catch (HttpListenerException)
                {
                    if (!_running) return;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[SERVER] Error: {ex.Message}");
                }
            }
        }

        public void Stop()
        {
            Console.WriteLine("[SERVER] Stopping XML server...");
            _running = false;
            try { _listener?.Stop(); } catch { }
        }
    }
}