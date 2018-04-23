Imports Microsoft.VisualBasic
Imports System
Namespace AdvancedSupportForEnums
	Partial Public Class Form1
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.btnDesigner = New DevExpress.XtraEditors.SimpleButton()
			Me.SuspendLayout()
			' 
			' btnDesigner
			' 
			Me.btnDesigner.Location = New System.Drawing.Point(73, 75)
			Me.btnDesigner.Name = "btnDesigner"
			Me.btnDesigner.Size = New System.Drawing.Size(124, 75)
			Me.btnDesigner.TabIndex = 0
			Me.btnDesigner.Text = "Report Designer"
'			Me.btnDesigner.Click += New System.EventHandler(Me.btnDesigner_Click);
			' 
			' Form1
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(284, 262)
			Me.Controls.Add(Me.btnDesigner)
			Me.Name = "Form1"
			Me.Text = "Form1"
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private WithEvents btnDesigner As DevExpress.XtraEditors.SimpleButton
	End Class
End Namespace

