Public Class frmInvoice
    Private Sub frmInvoice_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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

    Private Sub StepAction_Tick(sender As Object, e As EventArgs) Handles StepAction.Tick

        ButtonColor(MousePosition, btnPrint, Me, btmButtonDefaultGray, btmButtonDefault)
        ButtonColor(MousePosition, btnEmail, Me, btmButtonDefaultGray, btmButtonDefault)
        ButtonColor(MousePosition, btnPrintEmail, Me, btmButtonDefaultGray, btmButtonDefault)
        ButtonColor(MousePosition, btnNone, Me, btmButtonDefaultGray, btmButtonDefault)

    End Sub
End Class