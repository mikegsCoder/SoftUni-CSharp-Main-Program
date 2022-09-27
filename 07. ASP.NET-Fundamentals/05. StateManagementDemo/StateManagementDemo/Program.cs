using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;

namespace Demo_State_Management
{
    class Program
    {
        static Dictionary<string, int> SessionStorage = new Dictionary<string, int>();
        const string NewLine = "\r\n";

        static async Task Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            TcpListener tcpListener = new TcpListener(IPAddress.Loopback, 80);

            tcpListener.Start();

            while (true)
            {
                TcpClient client = await tcpListener.AcceptTcpClientAsync();
                await ProcessClientAsync(client);
            }

            static async Task ProcessClientAsync(TcpClient client)
            {
                await using (var stream = client.GetStream())
                {
                    byte[] buffer = new byte[1000000];
                    var lenght = stream.Read(buffer, 0, buffer.Length);

                    string requestString = Encoding.UTF8.GetString(buffer, 0, lenght);
                    Console.WriteLine(requestString);

                    var sid = Guid.NewGuid().ToString();
                    var match = Regex.Match(requestString, @"sid=[^\n]*\r\n]");

                    if (match.Success)
                    {
                        sid = match.Value.Substring(4);
                    }

                    if (!SessionStorage.ContainsKey(sid))
                    {
                        SessionStorage.Add(sid, 0);
                    }

                    SessionStorage[sid]++;

                    bool sessionSet = false;

                    if (requestString.Contains("sid ="))
                    {
                        sessionSet = true;
                    }

                    string html = $"<h1>Hello from My_Server {DateTime.Now} for the {SessionStorage[sid]} time</h1>" +
                    $"<form action=/tweet method=post><input name=username /><input name=password />" +
                    $"<input type=submit /></form>";

                    string response = "HTTP/1.1 200 OK"
                        + NewLine + "Server: MyServer 2022"
                        + NewLine +
                        //"Location: https://www.google.com" + NewLine +
                        "Content-Type: text/html; charset=utf-8"
                        + NewLine +
                        "X-Server-Version: 1.0"
                        + NewLine +
                        (!sessionSet ? ($"Set-Cookie: sid={sid}; lang=en; Expires: " + DateTime.UtcNow.AddHours(1).ToString("R")) : string.Empty)
                        + NewLine +
                        // "Content-Disposition: attachment; filename=test.txt" + NewLine +
                        "Content-Lenght: " + html.Length
                        + NewLine
                        + NewLine + html
                        + NewLine;

                    byte[] responseBytes = Encoding.UTF8.GetBytes(response);
                    await stream.WriteAsync(responseBytes, 0, responseBytes.Length);

                    Console.WriteLine($"sid={sid}");
                    Console.WriteLine(new string('=', 70));
                }
            }
        }
    }
}
