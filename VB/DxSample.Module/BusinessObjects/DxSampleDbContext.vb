Imports System.Data.Common
Imports System.Data.Entity
Imports DevExpress.ExpressApp.EF.Updating

Namespace DxSample.Module.BusinessObjects
	Public Class DxSampleDbContext
		Inherits DbContext

		Public Sub New(ByVal connectionString As String)
			MyBase.New(connectionString)
		End Sub
		Public Sub New(ByVal connection As DbConnection)
			MyBase.New(connection, False)
		End Sub
		Public Sub New()
			MyBase.New("name=ConnectionString")
		End Sub
		Public Property ModulesInfo() As DbSet(Of ModuleInfo)
		Public Property Customers() As DbSet(Of Customer)
		Public Property Orders() As DbSet(Of Order)
	End Class
End Namespace