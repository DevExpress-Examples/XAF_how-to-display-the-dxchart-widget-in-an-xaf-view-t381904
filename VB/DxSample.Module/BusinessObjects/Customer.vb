Imports System.ComponentModel
Imports System.Globalization
Imports DevExpress.Persistent.Base

Namespace DxSample.Module.BusinessObjects
	<DefaultProperty("FullName"), NavigationItem>
	Public Class Customer
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
		Public Property FirstName() As String
		Public Property LastName() As String
		Public Property Country() As String

		Public ReadOnly Property FullName() As String
			Get
				Return String.Format(CultureInfo.CurrentUICulture, "{0} {1}", Me.FirstName, Me.LastName)
			End Get
		End Property
	End Class
End Namespace
