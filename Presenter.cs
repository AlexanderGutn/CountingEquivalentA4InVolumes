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

        void form1_MyEventGetDrawingClick(bool showEmpty)
        {
            model.GetListDrawings(showEmpty);
            CustomizationDataGridView();
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
