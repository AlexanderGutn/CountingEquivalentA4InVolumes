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
using TSM = Tekla.Structures.Model;

namespace CountingEquivalentA4InVolumes
{
    public partial class Form1 : Form
    {
        //bool successfulConnectionTekla

        public delegate void MyEventHandler(bool showEmpty);
        public delegate bool EventHandlerConnectionStatus();

        public event MyEventHandler MyEventGetDrawingClick = null;
        public event EventHandlerConnectionStatus EventConnectionStatus = null;

        public Form1()
        {
            InitializeComponent();
            new Presenter(this);

            try
            {
                bool successfulConnectionTekla = EventConnectionStatus.Invoke();
                
                //Metric_Plugin(writePath, writePathStandby, true, "");
            }
            catch (Exception)
            {
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            MyEventGetDrawingClick.Invoke(cbShowEmpty.Checked);             
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            MyEventGetDrawingClick.Invoke(cbShowEmpty.Checked);
        }
    }
}
