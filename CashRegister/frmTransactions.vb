Public Class frmTransactions

    Private Sub frmTransactions_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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

        OpenFormKillParent(Me, frmMain)

    End Sub

    Private Sub btnCheckout_Click(sender As Object, e As EventArgs) Handles btnCheckout.Click

        OpenFormKillParent(Me, frmCheckout)

    End Sub

    Private Sub btnReturns_Click(sender As Object, e As EventArgs) Handles btnReturns.Click

        OpenFormKillParent(Me, frmReturn)

    End Sub

    Private Sub btnViewTransactions_Click(sender As Object, e As EventArgs) Handles btnViewTransactions.Click

        OpenFormKillParent(Me, frmViewTransactions)

    End Sub

End Class