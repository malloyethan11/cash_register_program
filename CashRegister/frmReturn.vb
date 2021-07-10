Imports System.Data.OleDb

Public Class frmReturn
    Private Class ItemData
        Public intItemID As Integer
        Public intQty As Integer
        Public strItemName As String
        Public decPrice As Decimal
    End Class

    Dim Items As List(Of ItemData)
    Private Sub frmReturn_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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

        dtpExpirationDate.Format = DateTimePickerFormat.Custom
        dtpExpirationDate.CustomFormat = "MM/yyyy"

    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click

        OpenFormKillParent(Me, frmTransactions)

    End Sub

    Private Sub btnItemLookup_Click(sender As Object, e As EventArgs) Handles btnItemLookup.Click

        Dim frmLookup As New frmItemLookup

        OpenFormMaintainParent(Me, frmLookup)

        Dim myItem = New ItemData
        ' Get the selected item
        myItem.intItemID = frmLookup.intPrimaryKeyReturnValue
        myItem.intQty = frmLookup.intQuantityToPurchase
        myItem.strItemName = frmLookup.intQuantityToPurchase.ToString
        myItem.decPrice = 399 ' Need to Call one form frmLookup

        lstItems.Items.Add(myItem.strItemName + " X " + myItem.intQty.ToString)
        Items.Add(myItem)

    End Sub

    Private Sub StepAction_Tick(sender As Object, e As EventArgs) Handles StepAction.Tick

        ButtonColor(MousePosition, btnExit, Me, btmButtonShortGray, btmButtonShort)
        ButtonColor(MousePosition, btnSubmit, Me, btmButtonDefaultGray, btmButtonDefault)
        ButtonColor(MousePosition, btnItemLookup, Me, btmButtonDefaultGray, btmButtonDefault)
        ButtonColor(MousePosition, btnRemoveSelectedItem, Me, btmButtonDefaultGray, btmButtonDefault)

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim roller As ComboBox = sender
        If roller.SelectedIndex = 2 Then
            TextBox5.Enabled = True
            TextBox6.Enabled = True
            dtpExpirationDate.Enabled = True
        Else
            TextBox5.Enabled = False
            TextBox6.Enabled = False
            dtpExpirationDate.Enabled = False
        End If

    End Sub

    Private Sub txtReturn_TextChanged(sender As Object, e As EventArgs) Handles txtReturn.TextChanged
        If IsNumeric(txtReturn.Text) Then
            txtSalesTax.Text = Convert.ToDecimal(txtReturn.Text) * 0.575
        Else
            txtSalesTax.Text = "NAN"
        End If
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        ' Validations
        If TextBox3.Text = "" Or ' For credit not added
                TextBox4.Text = "" Or 'TextBox5.Text = "" Or TextBox6.Text = "" Or
                TextBox7.Text = "" Or
                TextBox8.Text = "" Or
                txtEmail.Text = "" Or
                txtPhoneNumber.Text = "" Or
                txtReturn.Text = "" Or
                txtSalesTax.Text = "" Or
                TextBox9.Text = "" Then

            ' Some Things to show Error not making it compulsory as cash or credit will differ
        Else
            Try
                ' Open the DB
                If OpenDatabaseConnectionSQLServer() = False Then

                    ' The database is not open
                    MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                    "The form will now close.",
                                    Me.Text + " Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)

                    ' Close the form/application
                    Me.Close()

                End If
                Dim cmdInsert = New OleDbCommand("INSERT INTO TTransactions(intTransactionTypeID, intPaymentTypeID, strFirstName, strLastName, strAddress, strCity, intStateID, strZip, strPhoneNumber, strEmail, strCreditCard, strExpirationDate, strSecurityCode, decTotalPrice, decSalesTax, strDescription, strUserName) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)")
                cmdInsert.CommandType = CommandType.Text
                cmdInsert.Connection = m_conAdministrator
                ' Username Password
                cmdInsert.Parameters.AddWithValue("intTransactionTypeID", 2)
                cmdInsert.Parameters.AddWithValue("intPaymentTypeID", ComboBox1.SelectedIndex)
                ' UserData
                cmdInsert.Parameters.AddWithValue("strFirstName", TextBox3.Text)
                cmdInsert.Parameters.AddWithValue("strLastName", TextBox4.Text)
                cmdInsert.Parameters.AddWithValue("strAddress", TextBox9.Text)
                cmdInsert.Parameters.AddWithValue("strCity", TextBox7.Text)
                cmdInsert.Parameters.AddWithValue("intStateID", cboState.SelectedIndex)
                cmdInsert.Parameters.AddWithValue("strZip", TextBox8.Text)
                cmdInsert.Parameters.AddWithValue("strPhoneNumber", txtPhoneNumber.Text)
                cmdInsert.Parameters.AddWithValue("strEmail", txtEmail.Text)
                ' Credit Card
                cmdInsert.Parameters.AddWithValue("strCreditCard", TextBox5.Text)
                cmdInsert.Parameters.AddWithValue("strExpirationDate", dtpExpirationDate.Value)
                cmdInsert.Parameters.AddWithValue("strSecurityCode", TextBox6.Text)

                cmdInsert.Parameters.AddWithValue("decTotalPrice", Convert.ToDecimal(txtReturn.Text))
                cmdInsert.Parameters.AddWithValue("decSalesTax", txtSalesTax.Text)

                cmdInsert.Parameters.AddWithValue("strDescription", "?")
                cmdInsert.Parameters.AddWithValue("strUserName", "")
                Dim result = cmdInsert.ExecuteNonQuery()
                ' If result is one that means a row is added
                MessageBox.Show(result.ToString + "Returns Added successfully")
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If

    End Sub

    Private Sub btnRemoveSelectedItem_Click(sender As Object, e As EventArgs) Handles btnRemoveSelectedItem.Click
        Items.RemoveAt(lstItems.SelectedIndex)
        lstItems.Items.RemoveAt(lstItems.SelectedIndex)
        lstItems.Refresh()
    End Sub
End Class