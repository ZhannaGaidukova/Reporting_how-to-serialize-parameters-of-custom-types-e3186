Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.Xpo

Namespace AdvancedSupportForEnums
	Public Enum PersonGender
		Mr
		Mrs
	End Enum

	Public Class Person
		Inherits XPObject
		Private privateGender As PersonGender
		Public Property Gender() As PersonGender
			Get
				Return privateGender
			End Get
			Set(ByVal value As PersonGender)
				privateGender = value
			End Set
		End Property

		Private privateDateOfBirth As DateTime
		Public Property DateOfBirth() As DateTime
			Get
				Return privateDateOfBirth
			End Get
			Set(ByVal value As DateTime)
				privateDateOfBirth = value
			End Set
		End Property
		Private privateOwner As Person
		Public Property Owner() As Person
			Get
				Return privateOwner
			End Get
			Set(ByVal value As Person)
				privateOwner = value
			End Set
		End Property
		Private privateFirstName As String
		Public Property FirstName() As String
			Get
				Return privateFirstName
			End Get
			Set(ByVal value As String)
				privateFirstName = value
			End Set
		End Property

		Private privateTeam As Team
		Public Property Team() As Team
			Get
				Return privateTeam
			End Get
			Set(ByVal value As Team)
				privateTeam = value
			End Set
		End Property
	End Class

	Public Class Team
		Inherits XPObject
		Private privateName As String
		Public Property Name() As String
			Get
				Return privateName
			End Get
			Set(ByVal value As String)
				privateName = value
			End Set
		End Property
	End Class


End Namespace
