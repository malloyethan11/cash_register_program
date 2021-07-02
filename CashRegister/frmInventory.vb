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

        If (MyUser.CanAddItems = True) Then
            OpenFormKillParent(Me, frmAddItem)
        Else
            MessageBox.Show("You do not have permission to access frmAddItem!", "Error")
        End If

    End Sub

    Private Sub btnPriceItems_Click(sender As Object, e As EventArgs) Handles btnPriceItems.Click

        If (MyUser.CanAdjustPricing = True) Then
            OpenFormKillParent(Me, frmPriceAdjust)
        Else
            MessageBox.Show("You do not have permission to access frmPriceAdjust!", "Error")
        End If

    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click

        OpenFormKillParent(Me, frmMain)

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles btnVendorLookup.Click

        OpenFormKillParent(Me, frmVendorLookup)

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnAddVendor.Click

        If (MyUser.CanAdjustPricing = True) Then
            OpenFormKillParent(Me, frmAddVendor)
        Else
            MessageBox.Show("You do not have permission to access frmAddVendor!", "Error")
        End If

    End Sub
End Class
