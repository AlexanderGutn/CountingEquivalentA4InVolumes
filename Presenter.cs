using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountingEquivalentA4InVolumes
{
    class Presenter
    {
        Model.DataDrawing model = null;
        Form1 form1 = null;

        public Presenter(Form1 form1)
        {
            this.model = new Model.DataDrawing();
            this.form1 = form1;
            this.form1.EventConnectionStatus += form1_ConnectionStatusTekla;
            this.form1.MyEventGetDrawingClick += form1_MyEventGetDrawingClick;
            
        }

        bool form1_ConnectionStatusTekla()
        {
            return model.TeklaConnectionStatusModelAndDrawingHandler();
        }

        void form1_MyEventGetDrawingClick()
        {
            model.GetListDrawings();
        }

    }
}
