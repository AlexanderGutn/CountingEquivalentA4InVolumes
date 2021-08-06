using System;
using System.Threading.Tasks;
using System.Timers;

namespace CountingEquivalentA4InVolumes
{
    class Presenter
    {
        Model.DataModel model = null;
        Form1 form1 = null;
        delegate void Progress(int i);

        public Presenter(Form1 form1)
        {
            this.model = new Model.DataModel();
            this.form1 = form1;
            this.form1.EventConnectionStatus += form1_ConnectionStatusTekla;
            this.form1.EventGetDrawingClick += form1_MyEventGetDrawingClick;
            this.form1.EventMetricTry += Form1_EventMetricTry;
            this.form1.EventMetricCatch += Form1_EventMetricCatch;
            this.form1.EventFeedBack += Form1_EventFeedBack;
            this.form1.EventClickLogo += Form1_EventClickLogo;

            this.model.eventGetCountTotal += Model_eventGetCountTotal;
            this.model.eventGetCount += Model_eventGetCount;
        }

        private void Model_eventGetCount(int count)
        {            
            form1.progressBar.Invoke(new Progress((s) => form1.progressBar.Value = s), count);
        }

        private void Model_eventGetCountTotal(int count)
        {
            form1.progressBar.Invoke(new Progress((s) => form1.progressBar.Maximum = s), count);
        }

        private void Form1_EventClickLogo(object sender, EventArgs e)
        {
            model.OpenWebSite();
        }

        private void Form1_EventMetricTry()
        {
            model.MetricForTry();
        }


        private void Form1_EventMetricCatch(string exaption)
        {
            model.MetricForCatch(exaption);
        }

        private void Form1_EventFeedBack(object sender, EventArgs e)
        {
            model.FeedBack();
        }

        bool form1_ConnectionStatusTekla()
        {
            return model.TeklaConnectionStatusModelAndDrawingHandler();
        }

        async void form1_MyEventGetDrawingClick(bool showEmpty, bool stageProject)
        {
            form1.bCalculate.Enabled = false;
            form1.progressBar.Visible = true;
            form1.progressBar.Value = 0;
            DateTime start = DateTime.Now;
            this.form1.label1.Text = "0";

            Task task = new Task(() => model.GetListDrawings(showEmpty, stageProject));
            task.Start();            
            await task;

            //model.GetListDrawings(showEmpty, stageProject);
            //await Task.Run(() => model.GetListDrawings(showEmpty, stageProject));            
            CustomizationDataGridView();
            form1.Info = model.Info();
            this.form1.label1.Text = (DateTime.Now - start).TotalMilliseconds.ToString();
            form1.bCalculate.Enabled = true;
            form1.progressBar.Visible = false;
        }

        void CustomizationDataGridView()
        {
            if (model.ListCipers != null)
            {
                form1.dataGridView.DataSource = model.ListCipers;
                form1.dataGridView.Columns[0].HeaderText = "Шифр";
                form1.dataGridView.Columns[1].HeaderText = "Кол-во чертежей";
                form1.dataGridView.Columns[2].HeaderText = "Кол-во листов А4";
                form1.dataGridView.Columns[3].Visible = false;
                form1.dataGridView.Columns[0].SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
                form1.dataGridView.Columns[1].SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
                form1.dataGridView.Columns[2].SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;

                for (int i = 0; i < form1.dataGridView.Rows.Count; i++)
                {
                    var cipher = form1.dataGridView.Rows[i].DataBoundItem as Model.Cipher;
                    var color = cipher.Color;

                    if (color == Model.Color.Yellow)
                    {
                        form1.dataGridView.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.Yellow;
                    }
                    else if (color == Model.Color.Red)
                    {
                        form1.dataGridView.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.Red;
                    }
                }
            }                       
        }
    }
}
