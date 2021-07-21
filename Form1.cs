using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tekla.Structures.Drawing;
using Tekla.Structures.Model;

namespace CountingEquivalentA4InVolumes
{
    public partial class Form1 : Form
    {
        DrawingHandler drawingHandler;
        Model model;
        Drawing drawing;
        List<Drawing> drawings = new List<Drawing>();

        public Form1()
        {
            InitializeComponent();

            try
            {
                drawingHandler = new DrawingHandler();
                model = new Model();

                if (model.GetConnectionStatus() &&
                    drawingHandler.GetConnectionStatus())
                {
                    //InitializeComponent();
                }
                else
                    MessageBox.Show("Tekla Structures должна быть открыта!");

                //if (drawingHandler.GetActiveDrawing() == null)
                //{
                //    MessageBox.Show("Откройте чертеж");
                //}


                //Metric_Plugin(writePath, writePathStandby, true, "");
            }
            catch (Exception)
            {
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DrawingEnumerator drawingEnumerator = drawingHandler.GetDrawings();

            while (drawingEnumerator.MoveNext())
            {
                //Drawing dr = drawingEnumerator.Current as Drawing;
                drawings.Add(drawingEnumerator.Current as Drawing);
            }

            string s="1";
        }
    }
}
