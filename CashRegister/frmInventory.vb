Public Class frmInventory

    Private Sub frmInventory_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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

    Private Sub btnItemLookup_Click(sender As Object, e As EventArgs) Handles btnItemLookup.Click

        Dim frmNewItemLookup As New frmItemLookup
        frmNewItemLookup.Type = "Standalone"
        OpenFormKillParent(Me, frmNewItemLookup)

    End Sub

    Private Sub btnCheckout_Click(sender As Object, e As EventArgs) Handles btnAddItem.Click

        OpenFormKillParent(Me, frmAddItem)

    End Sub

    Private Sub btnPriceItems_Click(sender As Object, e As EventArgs) Handles btnPriceItems.Click

        OpenFormKillParent(Me, frmPriceAdjust)

    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click

        OpenFormKillParent(Me, frmMain)

    End Sub

End Class
