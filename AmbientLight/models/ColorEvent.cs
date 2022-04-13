using AmbientLight.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmbientLight
{
    internal class ColorEvent : EventArgs
    {   
        public ScreenColor screenColor { get; set; }
        public ColorEvent(ScreenColor c)
        {
            this.screenColor = c;
        }

    }
}
