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
              
        public delegate bool EventHandlerConnectionStatus();
        public delegate void EventHandlerMetricTry();
        public delegate void EventHandlerMetricCatch(string exaption);
        public delegate void MyEventHandler(bool showEmpty);

        public event EventHandlerConnectionStatus EventConnectionStatus;
        public event EventHandlerMetricTry EventMetricTry;
        public event EventHandlerMetricCatch EventMetricCatch;
        public event EventHandler EventFeedBack;
        public event EventHandler EventClickLogo;
        public event MyEventHandler MyEventGetDrawingClick;

        public Form1()
        {
            InitializeComponent();
            new Presenter(this);

            try
            {
                bool successfulConnectionTekla = EventConnectionStatus.Invoke();

                EventMetricTry.Invoke();
                
            }
            catch (Exception Ex)
            {
                EventMetricCatch.Invoke(Ex.Message);
                
            }
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            MyEventGetDrawingClick.Invoke(cbShowEmpty.Checked);
        }

        private void bFeedBack_Click(object sender, EventArgs e)
        {
            EventFeedBack.Invoke(null,null);
        }

        private void bCalculate_Click(object sender, EventArgs e)
        {
            MyEventGetDrawingClick.Invoke(cbShowEmpty.Checked);
        }

        private void pictureBoxLogo_Click(object sender, EventArgs e)
        {
            EventClickLogo.Invoke(null,null);
        }
    }
}
