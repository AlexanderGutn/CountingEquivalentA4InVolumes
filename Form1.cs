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
using ProEngineering;

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
                
                Metric.MetricForTry(System.Reflection.Assembly.GetExecutingAssembly().ManifestModule.Name);
            }
            catch (Exception Ex)
            {
                Metric.MetricForCatch(System.Reflection.Assembly.GetExecutingAssembly().ManifestModule.Name, Ex.Message);
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

        private void bFeedBack_Click(object sender, EventArgs e)
        {
            _ = new FeedBackForm();
        }
    }
}
