Imports System
Imports System.Collections.Generic
Imports System.Data.Entity
Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Updating
Imports DxSample.Module.BusinessObjects

Namespace DxSample.Module
	Public NotInheritable Partial Class DxSampleModule
		Inherits ModuleBase

		Shared Sub New()
			DevExpress.Data.Linq.CriteriaToEFExpressionConverter.SqlFunctionsType = GetType(System.Data.Entity.SqlServer.SqlFunctions)
			DevExpress.Data.Linq.CriteriaToEFExpressionConverter.EntityFunctionsType = GetType(System.Data.Entity.DbFunctions)
#If DEBUG Then
			Database.SetInitializer(New DropCreateDatabaseIfModelChanges(Of DxSampleDbContext)())
#End If
		End Sub

		Public Sub New()
			InitializeComponent()
		End Sub

		Public Overrides Function GetModuleUpdaters(ByVal objectSpace As IObjectSpace, ByVal versionFromDB As Version) As IEnumerable(Of ModuleUpdater)
			Dim updater As ModuleUpdater = New DatabaseUpdate.Updater(objectSpace, versionFromDB)
			Return New ModuleUpdater() { updater }
		End Function
	End Class
End Namespace
