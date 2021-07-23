using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountingEquivalentA4InVolumes.Model
{
    class Cipher
    {
        public string Title { get; }
        public int CountDrawing { get; set; }
        public int CountFormatA4 { get; set; }

        public Cipher (string ciper, int countDrawing, int countFormatA4)
        {
            this.Title = ciper;
            this.CountDrawing = countDrawing;
            this.CountFormatA4 = countFormatA4;
        }
        public override string ToString()
        {
            return Title.ToString() + " | " + CountDrawing + " | " + CountFormatA4;
        }
    }
}
