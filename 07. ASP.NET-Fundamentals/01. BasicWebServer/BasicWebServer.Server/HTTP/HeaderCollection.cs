using System.Collections.Generic;

namespace BasicWebServer.Server.HTTP
{
    public class HeaderCollection
    {
        private readonly Dictionary<string, Header> headers;

        public HeaderCollection()
            => this.headers = new Dictionary<string, Header>();

        public int Count => this.headers.Count;

        public void Add(string name, string value)
        {
            var header = new Header(name, value);

            this.headers.Add(name, header);
        }
    }
}
