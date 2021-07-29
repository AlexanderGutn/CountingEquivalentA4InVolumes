using ProEngineering;
using System.Collections.Generic;
using System.Diagnostics;
using Tekla.Structures.Drawing;
using TSM = Tekla.Structures.Model;

namespace CountingEquivalentA4InVolumes.Model
{
    class DataModel
    {
        DrawingHandler drawingHandler;
        TSM.Model model;
        bool showEmpty;

        List<Drawing> drawings;
        List<DrawCipherFormat> ListDrawCipherFormats;
        public List<Cipher> ListCipers;

        public void MetricForTry()
        {
            Metric.MetricForTry(System.Reflection.Assembly.GetExecutingAssembly().ManifestModule.Name);
        }
        
        public void MetricForCatch(string exeption)
        {
            Metric.MetricForCatch(System.Reflection.Assembly.GetExecutingAssembly().ManifestModule.Name, exeption);
        }

        public void FeedBack()
        {
            _ = new FeedBackForm();
        }

        public void OpenWebSite()
        {
            Process.Start("https://pi21.ru/");
        }


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

        public void GetListDrawings(bool showEmpty)
        {
            if (model.GetConnectionStatus() && drawingHandler.GetConnectionStatus())
            {
                DrawingEnumerator drawingEnumerator = drawingHandler.GetDrawings();
                drawings = new List<Drawing>();

                while (drawingEnumerator.MoveNext())
                {                    
                    drawings.Add(drawingEnumerator.Current as Drawing);
                }
            }

            ListDrawCipherFormats = new List<DrawCipherFormat>();

            if (drawings != null)
            {
                foreach (var draw in drawings)
                {
                    if (draw.Title1 != "" || showEmpty)
                    {
                        string titleEdited = string.Empty;

                        ListDrawCipherFormats.Add(new DrawCipherFormat(draw.Title1, (int)draw.Layout.SheetSize.Height, (int)draw.Layout.SheetSize.Width));
                    }
                }

                ListCipers = new List<Cipher>();

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

                foreach (var item in ListCipers)
                {
                    if (item.CountFormatA4 < 249)
                    {
                        item.Color = Color.Black;
                    }
                    else if (item.CountFormatA4 > 250 && item.CountFormatA4 < 294)
                    {
                        item.Color = Color.Yellow;
                    }
                    else if (item.CountFormatA4 > 295)
                    {
                        item.Color = Color.Red;
                    }
                }
            } 
        }
    }
}
