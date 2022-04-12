using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmbientLight.models
{
    public class MQTT
    {
        public bool enabled { get; set; } = false;
        public string server { get; set; }
        public string topic { get; set; }
        public string clientId { get; set; }
        public int port { get; set; } = Constants.MQTT_DEFAULT_PORT;
        public string message { get; set; }
        public string username { get; set; }
        public string password { get; set; }

    }
}
