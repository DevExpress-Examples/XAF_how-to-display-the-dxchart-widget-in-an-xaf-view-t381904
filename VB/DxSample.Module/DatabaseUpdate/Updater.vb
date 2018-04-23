Imports System
Imports System.IO
Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Updating
Imports DxSample.Module.BusinessObjects

Namespace DxSample.Module.DatabaseUpdate
	Public Class Updater
		Inherits ModuleUpdater

		Public Sub New(ByVal objectSpace As IObjectSpace, ByVal currentDBVersion As Version)
			MyBase.New(objectSpace, currentDBVersion)
		End Sub

		Public Overrides Sub UpdateDatabaseAfterUpdateSchema()
			MyBase.UpdateDatabaseAfterUpdateSchema()
			Me.CreateCustomers()
			Me.CreateOrders()
		End Sub

		Private Sub CreateObjects(Of TEntity)(ByVal resourceName As String, ByVal updateEntity As Action(Of TEntity, String()))
			Dim objectsCnt As Integer = Me.ObjectSpace.GetObjectsCount(GetType(TEntity), Nothing)
			If objectsCnt > 0 Then
				Return
			End If
			Dim stream As Stream = GetType(TEntity).Assembly.GetManifestResourceStream(resourceName)
			Using reader As TextReader = New StreamReader(stream)
				Dim line As String = String.Empty
                line = reader.ReadLine()
                Do While Not String.IsNullOrEmpty(line)
                    Dim data() As String = line.Split(";"c)
                    Dim entity As TEntity = Me.ObjectSpace.CreateObject(Of TEntity)()
                    updateEntity(entity, data)
                    line = reader.ReadLine()
                Loop
			End Using
			Me.ObjectSpace.CommitChanges()
		End Sub

		Private Sub UpdateCustomer(ByVal customer As Customer, ByVal data() As String)
			customer.FirstName = data(0)
			customer.LastName = data(1)
			customer.Country = data(2)
		End Sub

		Private Sub UpdateOrder(ByVal order As Order, ByVal customer As Customer, ByVal data() As String)
			order.Customer = customer
			order.OrderDate = Date.Parse(data(0))
			order.UnitPrice = Decimal.Parse(data(1))
		End Sub

        Private Sub CreateCustomers()
            Me.CreateObjects(Of Customer)("Customers.csv", AddressOf Me.UpdateCustomer)
        End Sub

		Private Sub CreateOrders()
			Dim customers = Me.ObjectSpace.GetObjects(Of Customer)()
			Dim randomizer As New Random(Date.Now.Millisecond)
            Me.CreateObjects(Of Order)("Orders.csv", Sub(order, data) Me.UpdateOrder(order, customers(randomizer.Next(customers.Count)), data))
		End Sub
	End Class
End Namespace
