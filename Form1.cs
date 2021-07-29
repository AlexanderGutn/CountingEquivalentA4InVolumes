using System;
using System.Windows.Forms;

namespace CountingEquivalentA4InVolumes
{
    public partial class Form1 : Form
    {               
        public delegate bool EventHandlerConnectionStatus();
        public delegate void EventHandlerMetricTry();
        public delegate void EventHandlerMetricCatch(string exaption);
        public delegate void MyEventHandler(bool showEmpty);

        private event EventHandlerConnectionStatus eventConnectionStatus;
        private event EventHandlerMetricTry eventMetricTry;
        private event EventHandlerMetricCatch eventMetricCatch;
        private event EventHandler eventFeedBack;
        private event EventHandler eventClickLogo;
        private event MyEventHandler eventGetDrawingClick;

        public event EventHandlerConnectionStatus EventConnectionStatus
        {
            add => eventConnectionStatus += value;
            remove => eventConnectionStatus -= value;
        }
        public event EventHandlerMetricTry EventMetricTry
        {
            add => eventMetricTry += value;
            remove => eventMetricTry -= value;
        }
        public event EventHandlerMetricCatch EventMetricCatch
        {
            add => eventMetricCatch += value;
            remove => eventMetricCatch -= value;
        }
        public event EventHandler EventFeedBack
        {
            add => eventFeedBack += value;
            remove => eventFeedBack -= value;
        }
        public event EventHandler EventClickLogo
        {
            add => eventClickLogo += value;
            remove => eventClickLogo -= value;
        }

        public event MyEventHandler EventGetDrawingClick
        {
            add => eventGetDrawingClick += value;
            remove => eventGetDrawingClick -= value;
        }
        public Form1()
        {
            InitializeComponent();
            new Presenter(this);

            try
            {
                bool successfulConnectionTekla = eventConnectionStatus.Invoke();

                eventMetricTry.Invoke();
                
            }
            catch (Exception Ex)
            {
                //eventMetricCatch.Invoke(Ex.Message);                
            }
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            eventGetDrawingClick.Invoke(cbShowEmpty.Checked);
        }

        private void bFeedBack_Click(object sender, EventArgs e)
        {
            eventFeedBack.Invoke(null,null);
        }

        private void bCalculate_Click(object sender, EventArgs e)
        {
            eventGetDrawingClick.Invoke(cbShowEmpty.Checked);
        }

        private void pictureBoxLogo_Click(object sender, EventArgs e)
        {
            eventClickLogo.Invoke(null,null);
        }
    }
}
