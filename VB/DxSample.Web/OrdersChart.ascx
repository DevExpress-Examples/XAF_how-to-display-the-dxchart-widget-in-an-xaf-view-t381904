<%@ Control Language="vb" AutoEventWireup="true" CodeBehind="OrdersChart.ascx.vb" Inherits="DxSample.Web.OrdersChart" %>
<%@ Register assembly="DevExpress.Web.v16.1, Version=16.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>
<dx:ASPxPanel ID="ASPxPanel1" runat="server" Height="500px">
	<ClientSideEvents Init="function(s, e) { DxSample.OrdersChart.createWidgets(s); }" />
	<PanelCollection>
		<dx:PanelContent runat="server">
			<div class="dxsample-orderschart-chart"></div>
			<div class="dxsample-orderschart-range"></div>
		</dx:PanelContent>
	</PanelCollection>
</dx:ASPxPanel>