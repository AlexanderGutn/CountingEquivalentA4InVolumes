using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountingEquivalentA4InVolumes.Model
{
    class DrawCipherFormat
    {
        public string Cipher { get; }
        public int Height { get; }
        public int Width { get; }
        public int HeightDesign
        {
            get
            {
                switch (Height)
                {
                    case 1189: return 1188; break;
                    case 1486: return 1485; break;
                    case 1783: return 1782; break;
                    case 2080: return 2079; break;
                    case 2378: return 2376; break;
                    case 841: return 840; break;
                    case 1051: return 1050; break;                    
                    case 1261: return 1260; break;
                    case 1471: return 1470; break;
                    case 1682: return 1680; break;
                    case 1892: return 1890; break;
                    case 2102: return 2100; break;
                    case 2523: return 2520; break;
                    default: return Height; break;
                }
            }
        }
        public double WidthDesign
        {
            get
            {
                switch (Width)
                {
                    case 1189: return 1188; break;
                    case 1486: return 1485; break;
                    case 1783: return 1782; break;
                    case 2080: return 2079; break;
                    case 2378: return 2376; break;
                    case 841: return 840; break;
                    case 1051: return 1050; break;
                    case 1261: return 1260; break;
                    case 1471: return 1470; break;
                    case 1682: return 1680; break;
                    case 1892: return 1890; break;
                    case 2102: return 2100; break;
                    case 2523: return 2520; break;
                    default: return Width; break;
                }
            }
        }
        public int CountA4Temp;
        public int CountA4
        {
            get
            {
                double d1 = HeightDesign / 297;
                int h1 = (int)Math.Ceiling((double)(HeightDesign / 297));

                double d2 = WidthDesign / 210;
                int w1 = (int)Math.Ceiling((double)(WidthDesign / 210));

                double d3 = HeightDesign / 210;
                int h2 = (int)Math.Ceiling((double)(HeightDesign / 210));

                double d4 = WidthDesign / 297;
                int w2 = (int)Math.Ceiling((double)(WidthDesign / 297));

                int rez = Math.Min(h1 * w1, h2 * w2);
                return Math.Min(h1*w1,h2*w2);

            }
        }
            

        public DrawCipherFormat(string cipher, int height, int width)
        {
            this.Cipher = cipher;
            this.Height = height;
            this.Width = width;

            double d1 = (double) HeightDesign / 297;            
            int h1 = (int)Math.Ceiling(d1);

            double d2 = (double) WidthDesign / 210;
            int w1 = (int)Math.Ceiling(d2);

            double d3 = (double)HeightDesign / 210;
            int h2 = (int)Math.Ceiling(d3);

            double d4 = (double) WidthDesign / 297;
            int w2 = (int)Math.Ceiling(d4);

            int rez = Math.Min(h1 * w1, h2 * w2);
            CountA4Temp = Math.Min(h1 * w1, h2 * w2);
        }
    }
}
