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