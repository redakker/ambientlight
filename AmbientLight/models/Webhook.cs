using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmbientLight
{
    public class Webhook
    {
        public enum Method { GET = 0, POST = 1}

        static readonly HttpClient client = new HttpClient();
        public bool enabled { get; set; } = false;
        public string url { get; set; } = "";
        public Method HTTPMethod { get; set; } = Method.GET;
        public string HTTPDataType { get; set; } = "application/json";
        public string PostBody { get; set; } = "";

    }
}
