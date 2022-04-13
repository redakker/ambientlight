using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmbientLight.models
{
    internal class Pixels
    {
        public int allPixels { get; set; }
        public int darkPixels { get; set; }
        public int brightPixels { get; set; }

        public RGB colorCollercor { get; } = new RGB();

        public void addPixel(Color pixelColor, Config config)
        {
            int r = pixelColor.R;
            int g = pixelColor.G;
            int b = pixelColor.B;

            bool addPixel = false;
            if (config.skipDarkPixels)
            {
                if (r < Constants.DARK_PIXEL_LIMIT && g < Constants.DARK_PIXEL_LIMIT && b < Constants.DARK_PIXEL_LIMIT)
                {
                    darkPixels++;
                }
                else
                {
                    brightPixels++;
                    addPixel = true;
                }

            }

            if (!config.skipDarkPixels || addPixel)
            {
                colorCollercor.red += r;
                colorCollercor.green += g;
                colorCollercor.blue += b;
                allPixels++;
            }
        }
        public Color getAverageColor()
        {
            RGB avgRGB = getAverageRGB();
            return Color.FromArgb(avgRGB.red, avgRGB.green, avgRGB.blue);
        }

        public RGB getAverageRGB()
        {
            
            double calculatedRed;
            double calculatedGreen;
            double calculatedBlue;

            if (allPixels == 0) { allPixels = 1; }

            calculatedRed = (double) colorCollercor.red / allPixels;
            calculatedGreen = (double) colorCollercor.green / allPixels;
            calculatedBlue = (double) colorCollercor.blue / allPixels;

            // Make darker color if most of the screen surface is black
            if (brightPixels * 2 < darkPixels)
            {
                double ratio = (double) brightPixels / darkPixels;

                calculatedRed = Convert.ToInt32(calculatedRed * ratio);
                calculatedGreen = Convert.ToInt32(calculatedGreen * ratio);
                calculatedBlue = Convert.ToInt32(calculatedBlue * ratio);
            }

            Debug.WriteLine("RGB color " + calculatedRed + ", " + calculatedGreen + ", " + calculatedBlue);

            return new RGB()
            {
                red = (int) calculatedRed,
                green = (int) calculatedGreen,
                blue = (int) calculatedBlue
            };
        }
    }
}
