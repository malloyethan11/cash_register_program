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

        If (MyUser.CanCheckout = True) Then
            OpenFormKillParent(Me, frmCheckout)
        Else
            MessageBox.Show("You do not have permission to access frmCheckout!", "Error")
        End If

    End Sub

    Private Sub btnReturns_Click(sender As Object, e As EventArgs) Handles btnReturns.Click

        If (MyUser.CanReturn = True) Then
            OpenFormKillParent(Me, frmReturn)
        Else
            MessageBox.Show("You do not have permission to access frmReturns!", "Error")
        End If

    End Sub

    Private Sub btnViewTransactions_Click(sender As Object, e As EventArgs) Handles btnViewTransactions.Click

        OpenFormKillParent(Me, frmViewTransactions)

    End Sub

    Private Sub btnPayInPayOut_Click(sender As Object, e As EventArgs) Handles btnPayInPayOut.Click

        If (MyUser.CanPayInPayOut = True) Then
            OpenFormKillParent(Me, frmPayInPayOut)
        Else
            MessageBox.Show("You do not have permission to access frmReturns!", "Error")
        End If

    End Sub

    Private Sub StepAction_Tick(sender As Object, e As EventArgs) Handles StepAction.Tick

        ButtonColor(MousePosition, btnCheckout, Me, btmButtonDefaultGray, btmButtonDefault)
        ButtonColor(MousePosition, btnExit, Me, btmButtonDefaultGray, btmButtonDefault)
        ButtonColor(MousePosition, btnReturns, Me, btmButtonDefaultGray, btmButtonDefault)
        ButtonColor(MousePosition, btnPayInPayOut, Me, btmButtonDefaultGray, btmButtonDefault)
        ButtonColor(MousePosition, btnViewTransactions, Me, btmButtonDefaultGray, btmButtonDefault)

    End Sub

End Class