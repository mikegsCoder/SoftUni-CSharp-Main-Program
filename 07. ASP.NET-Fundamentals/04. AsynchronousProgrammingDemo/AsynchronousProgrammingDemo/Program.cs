namespace AsynchronousProgrammingDemo
{
    internal class Program
    {
        static async Task Main(string[] args)
        {

            HttpClient httpClient = new HttpClient();
            string url = "https://softuni.bg";
            HttpResponseMessage httpResponse = await httpClient.GetAsync(url);
            string result = await httpResponse.Content.ReadAsStringAsync();
            Console.WriteLine(result);
            Console.WriteLine("Control string");
        }
    }
}