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

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click



    End Sub

    Private Sub btnEmail_Click(sender As Object, e As EventArgs) Handles btnEmail.Click



    End Sub

    Private Sub btnPrintAndEmail_Click(sender As Object, e As EventArgs) Handles btnPrintAndEmail.Click



    End Sub

    Private Sub btnNone_Click(sender As Object, e As EventArgs) Handles btnNone.Click

        ' close the form
        Me.Close()

    End Sub
End Class