
Public Class frmItemLookup

    Public Type As String = "Dialog"

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.CenterToScreen()

        txtSearch.ForeColor = Color.DarkGray

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

    Private Sub TextBox1_GotFocus(sender As Object, e As EventArgs) Handles txtSearch.Enter
        txtSearch.ForeColor = Color.Black
    End Sub

    Private Sub TextBox1_LostFocus(sender As Object, e As EventArgs) Handles txtSearch.Leave
        txtSearch.ForeColor = Color.DarkGray
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        If (Type = "Dialog") Then
            Me.Close()
        Else
            OpenFormKillParent(Me, frmInventory)
        End If
    End Sub
End Class