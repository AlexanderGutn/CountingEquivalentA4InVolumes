﻿namespace CountingEquivalentA4InVolumes.Model
{
    class Cipher
    {
        public string Title { get; }
        public int CountDrawing { get; set; }
        public int CountFormatA4 { get; set; }

        public Color Color { get; set; }

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

    enum Color
    {
        Black,
        Yellow,
        Red
    }
}
