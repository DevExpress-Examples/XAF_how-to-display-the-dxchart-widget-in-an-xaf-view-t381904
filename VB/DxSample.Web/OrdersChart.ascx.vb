Imports System
Imports System.Web.UI
Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Editors
Imports DxSample.Module.BusinessObjects
Imports System.Linq
Imports DevExpress.ExpressApp.Web

Namespace DxSample.Web
    Partial Public Class OrdersChart
        Inherits UserControl
        Implements IComplexControl

        Protected Overrides Sub OnLoad(ByVal e As EventArgs)
            MyBase.OnLoad(e)
            Dim url As String = Me.ResolveClientUrl("~/Scripts/Controls/orders-chart.js")
            WebWindow.CurrentRequestWindow.RegisterClientScriptInclude("orders-chart", url)
        End Sub

        Private Function GetChartData(ByVal objectSpace As IObjectSpace) As Object
            Dim countriesToDisplay() As String = {"Germany", "Mexico", "UK"}
            Return objectSpace.GetObjectsQuery(Of Order)() _
                .Where(Function(o) countriesToDisplay.Contains(o.Customer.Country)) _
                .ToArray() _
                .GroupBy(Function(o) New With { _
                             Key .date = New Date(o.OrderDate.Year, o.OrderDate.Month, 1), _
                                 Key .country = o.Customer.Country}) _
                         .Select(Function(og) New With { _
                                     Key .arg = og.Key.date, _
                                         Key .val = og.Sum(Function(o) o.UnitPrice), _
                                         Key .series = og.Key.country}) _
                                 .ToArray()
        End Function
#Region "IComplexControl Members"

        Private Sub IComplexControl_Refresh() Implements IComplexControl.Refresh
        End Sub

        Private Sub IComplexControl_Setup(ByVal objectSpace As IObjectSpace, ByVal application As XafApplication) Implements IComplexControl.Setup
            Me.ASPxPanel1.JSProperties.Add("cpChartData", Me.GetChartData(objectSpace))
        End Sub

#End Region
    End Class
End Namespace