<!-- default file list -->
*Files to look at*:

* [OrdersChart.ascx](./CS/DxSample.Web/OrdersChart.ascx) (VB: [OrdersChart.ascx](./VB/DxSample.Web/OrdersChart.ascx))
* **[OrdersChart.ascx.cs](./CS/DxSample.Web/OrdersChart.ascx.cs) (VB: [OrdersChart.ascx.vb](./VB/DxSample.Web/OrdersChart.ascx.vb))**
* [orders-chart.js](./CS/DxSample.Web/Scripts/Controls/orders-chart.js) (VB: [orders-chart.js](./VB/DxSample.Web/Scripts/Controls/orders-chart.js))
<!-- default file list end -->
# How to display the dxChart widget in an XAF view


<p><strong>Scenario:</strong><br>It is necessary to show a chart control with a lot of points. The built-in <a href="https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument113302">Charts module</a> draws all points on the same screen at once, which may be inconvenient for an end-user. To achieve better usability, it is possible to implement real-time zooming and scrolling capabilities.<br><br>The <a href="http://js.devexpress.com/Documentation/ApiReference/Data_Visualization_Widgets/dxChart/">dxChart</a> widget from the DevExtreme library perfectly fits this scenario. This example demonstrates how to utilize this widget in an XAF application.<br><br><img src="https://raw.githubusercontent.com/DevExpress-Examples/how-to-display-the-dxchart-widget-in-an-xaf-view-t381904/15.2.10+/media/8c96f11b-1ea3-11e6-80bf-00155d62480c.png"><br><br><strong>Steps to implement</strong><strong>:<br></strong>The approach used in this example is based on the well-known technique of displaying a custom data bound control described in our online documentation: <a href="https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument114160">How to: Show a Custom Data-Bound Control in an XAF View (ASP.NET)</a>. The example demonstrates how to use this technique with client-side components that do not have server-side implementation. Refer to the following Knowledge Base article for more details and concepts: <a href="https://www.devexpress.com/Support/Center/p/T380965">How to use DevExtreme Widgets in an XAF application</a>.<strong><br></strong></p>
<p><br><strong>1.</strong> <em>Register client libraries </em><br>The details are provided in the corresponding section of the <a href="https://www.devexpress.com/Support/Center/p/T380965">How to: Use DevExtreme Widgets in an XAF Application</a> Knowledge Base article.<em><br><strong>2.</strong> Create content. <br></em>In the <em>YourSolutionName.Web</em> project, create <a href="https://msdn.microsoft.com/en-us/library/26db8ysc%28v=vs.85%29.aspx">a custom ASP.NET User Control (*.ascx)</a> and add <a href="https://documentation.devexpress.com/#AspNet/clsDevExpressWebASPxPaneltopic">ASPxPanel</a> to it. This panel will be a container for DevExtreme widgets. It is convenient to keep client-side scripts in a separate file. Add a JavaScript file and declare the <em>createWidgets </em>function in it. Implement this function using the approach described in the <a href="http://js.devexpress.com/Documentation/Guide/Data_Visualization/Charts/End-User_Interaction/#Zooming_and_Scrolling">Zooming and Scrolling</a> article.</p>


```js
window.DxSample = window.DxSample || {};
window.DxSample.OrdersChart = {
    createWidgets: function (panel) {
        var $mainElement = $(panel.GetMainElement());
		$mainElement.dxChart({..});
    }
};
```


<p>Using the client-side <a href="https://documentation.devexpress.com/#AspNet/DevExpressWebScriptsASPxClientControl_Inittopic">Init</a> event of the ASPxPanel component, call the <em>createWidgets </em>function passing the first event argument as a parameter. <br><br><em><strong>3.</strong> Register your JavaScript files. <br></em>In code behind for your UserControl (e.g., <em>YourSolutionName.Web/YourUserControlName.ascx.xx</em> file)<em>, </em>handle the <a href="https://msdn.microsoft.com/en-us/library/system.web.ui.control.load%28v=vs.100%29.aspx">UserControl.Load</a> event and call the <a href="https://documentation.devexpress.com/#eXpressAppFramework/DevExpressExpressAppWebWebWindow_RegisterClientScriptIncludetopic">WebWindow.RegisterClientScriptInclude</a> method to include your JavaScript file into the web page.<br><em><br><strong>4.</strong> Load data and pass it to the client side. <br></em>To provide data for client-side widgets, use the approach described in the following article: <a href="https://documentation.devexpress.com/#AspNet/CustomDocument11816">How to: Access Server Data on the Client Side</a>. For this purpose, implement the <a href="https://documentation.devexpress.com/#eXpressAppFramework/clsDevExpressExpressAppEditorsIComplexControltopic">IComplexControl</a> interface in your UserControl class. Within the <a href="https://documentation.devexpress.com/#eXpressAppFramework/DevExpressExpressAppEditorsIComplexControl_Setuptopic">IComplexControl.Setup</a> method, load data from the database, convert it into an array of plain objects (you can use anonymous types in <a href="https://msdn.microsoft.com/en-us/library/bb397696.aspx">C#</a> and <a href="https://msdn.microsoft.com/en-us/library/bb384767.aspx">VB.NET</a> for this purpose), and add it to the <a href="https://documentation.devexpress.com/#AspNet/DevExpressWebASPxPanelBase_JSPropertiestopic">JSProperties</a> dictionary.<br><br><strong>5.</strong> Add your UserControl to the Application Model using the approach demonstrated in the following article: <a href="https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument114160">How to: Show a Custom Data-Bound Control in an XAF View (ASP.NET)</a>.</p>

<br/>


