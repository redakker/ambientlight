using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmbientLight
{
    public class Webhook
    {
        static readonly HttpClient client = new HttpClient();
        public bool enabled { get; set; } = false;
        public string url { get; set; } = "";

    }
}
