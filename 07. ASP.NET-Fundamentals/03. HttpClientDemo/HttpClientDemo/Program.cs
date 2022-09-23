using System.Net.Sockets;
using System.Net;
using System.Text;

namespace HttpClientDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;  // => to read cyrillic letters
            const string NewLine = "\r\n"; // => add new line

            TcpListener tcpListener = new TcpListener(IPAddress.Loopback, 80);  // => choice a port to listen
            tcpListener.Start();  // => start the listener

            while (true)  // => until the request is correct
            {
                var client = tcpListener.AcceptTcpClient(); // => add client

                using (var stream = client.GetStream())  // => open stream
                {
                    byte[] buffer = new byte[1000000]; // => add new byte[]
                    var lenght = stream.Read(buffer, 0, buffer.Length); // => calculate the byte[] length

                    string requestString = Encoding.UTF8.GetString(buffer, 0, lenght);  // => transform the byte[] into string
                    Console.WriteLine(requestString);

                    string html = $"<h1>Hello from Mihail_Server {DateTime.Now}</h1>" +
                        $"<form action=/tweet method=post><input name=username /><input name=password />" +
                        $"<input type=submit /></form>";

                    string response = "HTTP/1.1 200 OK" // => create reponse
                        + NewLine + "Server: MihailServer 2022"
                        + NewLine +
                        //"Location: https://www.google.com" + NewLine +
                        "Content-Type: text/html; charset=utf-8"
                        + NewLine +
                        // "Content-Disposition: attachment; filename=mike.txt" + NewLine +
                        "Content-Lenght: " + html.Length
                        + NewLine
                        + NewLine + html
                        + NewLine;

                    byte[] responseBytes = Encoding.UTF8.GetBytes(response); // => transform the response into byte[]
                    stream.Write(responseBytes);

                    Console.WriteLine(new string('=', 70));
                }
            }
        }

        public static async Task ReadData()
        {
            string url = "https://softuni.bg/courses/csharp-web-basics";
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetAsync(url);
            Console.WriteLine(response.StatusCode);
            Console.WriteLine(string.Join(Environment.NewLine, response.Headers.Select(x => x.Key + ": " + x.Value.First())));

            // var html = await httpClient.GetStringAsync(url);
            // Console.WriteLine(html);
        }
    }
}