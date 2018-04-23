Imports System
Imports System.ComponentModel
Imports DevExpress.Persistent.Base

Namespace DxSample.Module.BusinessObjects
	<DefaultProperty("ShipName"), NavigationItem>
	Public Class Order
		Private privateID As Integer
		<Browsable(False)>
		Public Property ID() As Integer
			Get
				Return privateID
			End Get
			Protected Set(ByVal value As Integer)
				privateID = value
			End Set
		End Property
		Public Property OrderDate() As Date
		Public Property UnitPrice() As Decimal
		Public Overridable Property Customer() As Customer
	End Class
End Namespace
