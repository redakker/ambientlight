using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmbientLight
{
    internal class ColorEvent : EventArgs
    {   
        public Color color { get; set; }
        public ColorEvent(Color c)
        {
            this.color = c;
        }

    }
}
