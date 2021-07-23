using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tekla.Structures.Model;
using TSM = Tekla.Structures.Model;
using Tekla.Structures.Drawing;


namespace CountingEquivalentA4InVolumes.Model
{
    class DataDrawing
    {
        DrawingHandler drawingHandler;
        TSM.Model model;
        
        List<Drawing> drawings = new List<Drawing>();
        List<DrawCipherFormat> ListDrawCipherFormats = new List<DrawCipherFormat>();
        List<Cipher> ListCipers = new List<Cipher>();

        public bool TeklaConnectionStatusModelAndDrawingHandler()
        {
            model = new TSM.Model();
            drawingHandler = new DrawingHandler();

            if (model.GetConnectionStatus() && drawingHandler.GetConnectionStatus())
            {
                return true;
                //InitializeComponent();
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Tekla Structures должна быть открыта!");
                return false;
            }
        }

        public void GetListDrawings()
        {
            if (model.GetConnectionStatus() && drawingHandler.GetConnectionStatus())
            {
                DrawingEnumerator drawingEnumerator = drawingHandler.GetDrawings();

                while (drawingEnumerator.MoveNext())
                {                    
                    drawings.Add(drawingEnumerator.Current as Drawing);
                }
            }

            

            DrawCipherFormat drawCipherFormat0 = new DrawCipherFormat("КЖ", 420, 1486);
            DrawCipherFormat drawCipherFormat1 = new DrawCipherFormat("КЖ", 594, 2102);
            DrawCipherFormat drawCipherFormat2 = new DrawCipherFormat("КЖ", 841, 2378);
            DrawCipherFormat drawCipherFormat3 = new DrawCipherFormat("КЖ", 1189, 1682);
            

            foreach (var draw in drawings)
            {
                ListDrawCipherFormats.Add(new DrawCipherFormat(draw.Title1, (int)draw.Layout.SheetSize.Height, (int)draw.Layout.SheetSize.Width));
            }

            foreach (var draw in ListDrawCipherFormats)
            {
                int index = ListCipers.FindIndex(x => x.Title == draw.Cipher);
                if (index == -1)
                {
                    ListCipers.Add(new Cipher(draw.Cipher, 1, draw.CountA4));
                }
                else
                {
                    ListCipers[index].CountDrawing += 1;
                    ListCipers[index].CountFormatA4 += draw.CountA4;
                }


            }


        }



    }
}
