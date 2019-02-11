using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DevExpress.XtraCharts;
using DevExpress.XtraCharts.Web;

namespace BoundDataChangedExample {
    public partial class WebForm1 : System.Web.UI.Page {
        WebChartControl webChartControl;
        protected void Page_Load(object sender, EventArgs e) {

            webChartControl = new WebChartControl { Width = 640, Height = 360 };
            this.form1.Controls.Add(webChartControl);
            DataTable seriesData = GetData();
            webChartControl.DataSource = seriesData;
            webChartControl.SeriesTemplate.SeriesDataMember = "Year";
            webChartControl.SeriesTemplate.ArgumentDataMember = "Region";
            webChartControl.SeriesTemplate.ValueDataMembers.AddRange(new string[] { "Sales" });
            webChartControl.DataBind();
            webChartControl.SeriesTemplate.View = new SideBySideBarSeriesView();
            webChartControl.BoundDataChanged += WebChartControl_BoundDataChanged;
        }

        private void WebChartControl_BoundDataChanged(object sender, EventArgs e) {
            Series series = webChartControl.Series.Where(s => s.Name == "2015").FirstOrDefault() as Series;
            SideBySideBarSeriesView view = series?.View as SideBySideBarSeriesView;
            if(view != null) {
                view.Color = System.Drawing.Color.Orange;
                view.FillStyle.FillMode = FillMode.Solid;

            }
        }

        public DataTable GetData() {
            DataTable table = new DataTable();
            table.Columns.AddRange(new DataColumn[] {
            new DataColumn("Year", typeof(int)),
            new DataColumn("Region", typeof(string)),
            new DataColumn("Sales", typeof(decimal))
        });

            table.Rows.Add(2015, "Asia", 4.23M);
            table.Rows.Add(2015, "North America", 3.485M);
            table.Rows.Add(2015, "Europe", 3.088M);
            table.Rows.Add(2015, "Australia", 1.78M);
            table.Rows.Add(2015, "South America", 1.602M);

            table.Rows.Add(2016, "Asia", 4.768M);
            table.Rows.Add(2016, "North America", 3.747M);
            table.Rows.Add(2016, "Europe", 3.357M);
            table.Rows.Add(2016, "Australia", 1.957M);
            table.Rows.Add(2016, "South America", 1.823M);

            table.Rows.Add(2017, "Asia", 5.289M);
            table.Rows.Add(2017, "North America", 4.182M);
            table.Rows.Add(2017, "Europe", 3.725M);
            table.Rows.Add(2017, "Australia", 2.272M);
            table.Rows.Add(2017, "South America", 2.117M);

            return table;
        }
    }
}