Imports System
Imports System.Data
Imports System.Linq
Imports DevExpress.XtraCharts
Imports DevExpress.XtraCharts.Web

Namespace BoundDataChangedExample
    Partial Public Class WebForm1
        Inherits System.Web.UI.Page

        Private webChartControl As WebChartControl
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

            webChartControl = New WebChartControl With { _
                .Width = 640, _
                .Height = 360 _
            }
            Me.form1.Controls.Add(webChartControl)
            Dim seriesData As DataTable = GetData()
            webChartControl.DataSource = seriesData
            webChartControl.SeriesTemplate.SeriesDataMember = "Year"
            webChartControl.SeriesTemplate.ArgumentDataMember = "Region"
            webChartControl.SeriesTemplate.ValueDataMembers.AddRange(New String() { "Sales" })
            webChartControl.DataBind()
            webChartControl.SeriesTemplate.View = New SideBySideBarSeriesView()
            AddHandler webChartControl.BoundDataChanged, AddressOf WebChartControl_BoundDataChanged
        End Sub

        Private Sub WebChartControl_BoundDataChanged(ByVal sender As Object, ByVal e As EventArgs)
            Dim series As Series = TryCast(webChartControl.Series.Where(Function(s) s.Name = "2015").FirstOrDefault(), Series)
            If series IsNot Nothing Then
                Dim view As SideBySideBarSeriesView = TryCast(series.View, SideBySideBarSeriesView)
                If view IsNot Nothing Then
                    view.Color = System.Drawing.Color.Orange
                    view.FillStyle.FillMode = FillMode.Solid
                End If
            End If
        End Sub

        Public Function GetData() As DataTable
            Dim table As New DataTable()
            table.Columns.AddRange(New DataColumn() { _
                New DataColumn("Year", GetType(Integer)), _
                New DataColumn("Region", GetType(String)), _
                New DataColumn("Sales", GetType(Decimal)) _
            })

            table.Rows.Add(2015, "Asia", 4.23D)
            table.Rows.Add(2015, "North America", 3.485D)
            table.Rows.Add(2015, "Europe", 3.088D)
            table.Rows.Add(2015, "Australia", 1.78D)
            table.Rows.Add(2015, "South America", 1.602D)

            table.Rows.Add(2016, "Asia", 4.768D)
            table.Rows.Add(2016, "North America", 3.747D)
            table.Rows.Add(2016, "Europe", 3.357D)
            table.Rows.Add(2016, "Australia", 1.957D)
            table.Rows.Add(2016, "South America", 1.823D)

            table.Rows.Add(2017, "Asia", 5.289D)
            table.Rows.Add(2017, "North America", 4.182D)
            table.Rows.Add(2017, "Europe", 3.725D)
            table.Rows.Add(2017, "Australia", 2.272D)
            table.Rows.Add(2017, "South America", 2.117D)

            Return table
        End Function
    End Class
End Namespace