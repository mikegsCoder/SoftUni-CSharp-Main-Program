using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

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
                }
            }
        }
    }
}
