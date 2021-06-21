Public Class frmItemEditor

    ' This public variable is set by the vendor lookup form when it opens this form
    Public intCurrentlyEditingVendorPrimaryKey As Integer

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.CenterToScreen()

        For Each Control In Controls
            If Control.GetType() = GetType(Button) Then
                Control.FlatStyle = FlatStyle.Flat
                Control.ForeColor = BackColor
                Control.FlatAppearance.BorderColor = BackColor
                Control.FlatAppearance.MouseOverBackColor = BackColor
                Control.FlatAppearance.MouseDownBackColor = BackColor
            End If
        Next

    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click

        Dim frmNewLookup As New frmItemLookup
        frmNewLookup.Type = "Standalone"
        OpenFormKillParent(Me, frmNewLookup)

    End Sub
End Class