using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmbientLight
{
    internal class Constants
    {
        public const int MQTT_DEFAULT_PORT = 1883;
        public const int DARK_PIXEL_LIMIT = 100;
        public const string CONFIG_DIR_NAME = "AmbientLight";
        public const string CONFIG_FILE_NAME = "config.json";

        public static readonly string configPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), CONFIG_DIR_NAME, CONFIG_FILE_NAME);

    }
}
