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
        Drawing drawing;
        List<Drawing> drawings = new List<Drawing>();

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

            

            DrawCipherFormat drawCipherFormat = new DrawCipherFormat("КЖ", 840, 594);
            DrawCipherFormat drawCipherFormat1 = new DrawCipherFormat("КЖ", 297, 1051);
            DrawCipherFormat drawCipherFormat2 = new DrawCipherFormat("КЖ", 1261, 297);
            DrawCipherFormat drawCipherFormat3 = new DrawCipherFormat("КЖ", 1262, 297);


            string s = "1";
        }



    }
}
