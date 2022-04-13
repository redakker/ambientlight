using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmbientLight.models
{
    public class ScreenColor
    {
        public Color mainColor { get; set; }
        public ConcurrentDictionary<int, Color> screenColors = new ConcurrentDictionary<int, Color>();
    }
}
