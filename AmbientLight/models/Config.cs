using AmbientLight.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmbientLight
{
    
    public class Config
    {
        public int refreshFrequency { get; set; } = 500;
        public bool minimizeToTray { get; set; } = true;
        public bool isRunning { get; set; } = false;
        public MQTT mqtt { get; set; }
        public Webhook webhook { get; set; }
        public bool skipDarkPixels { get; set; } = false;
        public bool skipCenter { get; set; } = false;        
        public int segmentHorizontal { get; set; } = Constants.DEFAULT_SEGMENT_NUMBER;
        public int segmentVertical { get; set; } = Constants.DEFAULT_SEGMENT_NUMBER;       
    }
}
