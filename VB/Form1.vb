Imports Microsoft.VisualBasic
Imports System
Imports System.IO
Imports System.Windows.Forms
Imports System.Collections.Generic
Imports DevExpress.Xpo
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraReports.Extensions
' ...

Namespace AdvancedSupportForEnums
	Partial Public Class Form1
		Inherits Form
		Shared Sub New()
			ReportDesignExtension.RegisterExtension(New CustomReportExtension(), TeamParameterName)
			CustomReportStorageExtension.RegisterExtensionGlobal(New CustomReportStorageExtension())
		End Sub

		Private report As XtraReport
		Private Const TeamParameterName As String = "Team"

		Public Sub New()
			InitializeComponent()

			FillDataSource()
			Dim dataSource As New XPCollection(Of Person)()

			report = New XtraReport()
			report.DataSource = dataSource

			ReportDesignExtension.AssociateReportWithExtension(report, TeamParameterName)
		End Sub

		Private Sub FillDataSource()

			If New XPCollection(Of Person)().Count < 6 Then
				Dim team1 As New Team() With {.Name = "Team 1"}
				team1.Save()
				Dim team2 As New Team() With {.Name = "Team 2"}
				team2.Save()
				Dim team3 As New Team() With {.Name = "Team 3"}
				team3.Save()

                Dim TempPerson As Person = New Person() With {
                    .FirstName = "Name 1, team1",
                    .Team = team1,
                    .DateOfBirth = DateTime.Now.AddYears(-1),
                    .Gender = PersonGender.Mr
                }
                TempPerson.Save()

                TempPerson = New Person() With {
                    .FirstName = "Name 1, team2",
                    .Team = team2,
                    .DateOfBirth = DateTime.Now,
                    .Gender = PersonGender.Mrs
                }
                TempPerson.Save()

                TempPerson = New Person() With {
                    .FirstName = "Name 1, team3",
                    .Team = team3,
                    .DateOfBirth = DateTime.Now,
                    .Gender = PersonGender.Mrs
                }
                TempPerson.Save()

                TempPerson = New Person() With {
                    .FirstName = "Name 2, team1",
                    .Team = team1,
                    .DateOfBirth = DateTime.Now.AddYears(-1),
                    .Gender = PersonGender.Mr
                }
                TempPerson.Save()

                TempPerson = New Person() With {
                    .FirstName = "Name 2, team2",
                    .Team = team2,
                    .DateOfBirth = DateTime.Now,
                    .Gender = PersonGender.Mrs
                }
                TempPerson.Save()

                TempPerson = New Person() With {
                    .FirstName = "Name 2, team3",
                    .Team = team3,
                    .DateOfBirth = DateTime.Now,
                    .Gender = PersonGender.Mrs
                }
                TempPerson.Save()
			End If
		End Sub

		Private Sub btnDesigner_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnDesigner.Click
			report.ShowDesignerDialog()
		End Sub

		Private Class CustomReportExtension
			Inherits ReportDesignExtension
			Public Sub New()
			End Sub

			Public Overrides Sub AddParameterTypes(ByVal dictionary As IDictionary(Of Type, String))
				dictionary.Add(GetType(PersonGender), "Person's Gender")
			End Sub

			Protected Overrides Function CanSerialize(ByVal data As Object) As Boolean
				Return TypeOf data Is PersonGender
			End Function
			Protected Overrides Function SerializeData(ByVal data As Object, ByVal report As XtraReport) As String
				Return System.Enum.GetName(GetType(PersonGender), data)
			End Function
			Protected Overrides Function CanDeserialize(ByVal value As String, ByVal typeName As String) As Boolean
				Return GetType(PersonGender).FullName = typeName
			End Function
			Protected Overrides Function DeserializeData(ByVal value As String, ByVal typeName As String, ByVal report As XtraReport) As Object
				Return System.Enum.Parse(GetType(PersonGender), value)
			End Function
		End Class

		Private Class CustomReportStorageExtension
			Inherits ReportStorageExtension
			Public Overrides Sub SetData(ByVal report As XtraReport, ByVal stream As Stream)
				report.SaveLayoutToXml(stream)
			End Sub
			Public Overrides Sub SetData(ByVal report As XtraReport, ByVal url As String)
				report.SaveLayoutToXml(url)
			End Sub
		End Class

	End Class
End Namespace
