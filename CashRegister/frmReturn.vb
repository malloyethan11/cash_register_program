Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.IO

Public Class frmReturn

    'Private intWorkingTransactionID As Integer

    Private Class ItemData
        Public intItemID As Integer
        Public intQty As Integer
        Public strItemName As String
        Public decPrice As Decimal
    End Class

    Dim Items As List(Of ItemData) = New List(Of ItemData)
    Private Sub frmCheckout_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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

        ' Load all of the states
        LoadStates()
        LoadPaymentTypes()

    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click

        OpenFormKillParent(Me, frmTransactions)

    End Sub

    Private Sub btnItemLookup_Click(sender As Object, e As EventArgs) Handles btnItemLookup.Click

        Dim frmLookup As New frmItemLookup
        frmLookup.strCaller = "Return"

        OpenFormMaintainParent(Me, frmLookup)

        Dim myItem = New ItemData
        ' Get the selected item
        myItem.intItemID = frmLookup.intPrimaryKeyReturnValue
        myItem.intQty = frmLookup.intQuantityToPurchase

        If (myItem.intItemID <> -1) Then
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
                Dim cmdSelect = New OleDbCommand("SELECT * FROM TItems WHERE intItemID=" + myItem.intItemID.ToString, m_conAdministrator)
                Dim result = cmdSelect.ExecuteReader
                If result.Read Then

                    If (txtPrice.Text = "") Then
                        txtPrice.Text = 0
                    End If

                    myItem.strItemName = result.GetString(2)
                    myItem.decPrice = result.GetDecimal(6) ' Need to Call one form frmLookup

                    lstItems.Items.Add(myItem.strItemName + " X " + myItem.intQty.ToString)
                    Items.Add(myItem)
                    txtPrice.Text = Convert.ToDecimal(txtPrice.Text) + (myItem.decPrice * myItem.intQty)

                Else
                    MessageBox.Show("No Item found in database")
                End If
            Catch ex As Exception
                MessageBox.Show("Database Error:" + ex.Message)
            End Try
        End If


    End Sub

    Private Sub StepAction_Tick(sender As Object, e As EventArgs) Handles StepAction.Tick

        ButtonColor(MousePosition, btnExit, Me, btmButtonShortGray, btmButtonShort)
        ButtonColor(MousePosition, btnSubmit, Me, btmButtonDefaultGray, btmButtonDefault)
        ButtonColor(MousePosition, btnItemLookup, Me, btmButtonDefaultGray, btmButtonDefault)
        ButtonColor(MousePosition, btnRemoveSelectedItem, Me, btmButtonDefaultGray, btmButtonDefault)

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPayment.SelectedIndexChanged
        Dim roller As ComboBox = sender
        If roller.SelectedIndex = 1 Then
            txtCredit.Enabled = True
            txtSecurity.Enabled = True
            dtpExpirationDate.Enabled = True
            lblCred.Enabled = True
            lblExpDate.Enabled = True
            lblSecurityCode.Enabled = True
        Else
            txtCredit.Enabled = False
            txtSecurity.Enabled = False
            dtpExpirationDate.Enabled = False
            lblCred.Enabled = False
            lblExpDate.Enabled = False
            lblSecurityCode.Enabled = False
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles txtPrice.TextChanged

        If IsNumeric(txtPrice.Text) Then
            txtTax.Text = Convert.ToDecimal(txtPrice.Text) * 0.065
        Else
            txtTax.Text = "NAN"
        End If
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click

        If (ValidateForm()) Then
            ' create command object
            Dim Connection As New SqlConnection("Server=itd2.cincinnatistate.edu;" &
                                                      "Database=CPDM-GroupB;" &
                                                      "User ID=" & strConnectionUsername & ";" &
                                                      "Password=" & strConnectionPassword & ";")
            Dim cmdAddItem As New SqlCommand

            cmdAddItem.Connection = Connection
            cmdAddItem.CommandText = "uspTransaction"
            cmdAddItem.CommandType = CommandType.StoredProcedure

            Try

                Dim strGetTime As String = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss")
                Dim strExpDate As String = dtpExpirationDate.Value.ToString("MM/yy")

                cmdAddItem.Parameters.AddWithValue("@intTransactionTypeID", 2)
                cmdAddItem.Parameters.AddWithValue("@intPaymentTypeID", cboPayment.SelectedValue)

                cmdAddItem.Parameters.AddWithValue("@strFirstName", txtFirstName.Text)
                cmdAddItem.Parameters.AddWithValue("@strLastName", txtLastName.Text)
                cmdAddItem.Parameters.AddWithValue("@strAddress", txtAddress.Text)
                cmdAddItem.Parameters.AddWithValue("@intStateID", cboState.SelectedValue)
                cmdAddItem.Parameters.AddWithValue("@strZip", txtZip.Text)
                cmdAddItem.Parameters.AddWithValue("@strCity", txtCity.Text)
                cmdAddItem.Parameters.AddWithValue("@strPhoneNumber", txtPhoneNumber.Text)
                cmdAddItem.Parameters.AddWithValue("@strEmail", txtEmail.Text)
                cmdAddItem.Parameters.AddWithValue("@strCreditCard", txtCredit.Text)
                cmdAddItem.Parameters.AddWithValue("@strExpirationDate", strExpDate)
                cmdAddItem.Parameters.AddWithValue("@strSecurityCode", txtSecurity.Text)
                cmdAddItem.Parameters.AddWithValue("@decTotalPrice", Convert.ToDecimal(txtPrice.Text))
                cmdAddItem.Parameters.AddWithValue("@decSalesTax", Convert.ToDecimal(txtTax.Text))
                cmdAddItem.Parameters.AddWithValue("@strDescription", "N/A")
                cmdAddItem.Parameters.AddWithValue("@strUsername", MyUser.Username)
                cmdAddItem.Parameters.AddWithValue("@dtTransactionDate", strGetTime)

                Connection.Open()

                Dim intTransactionResult As Integer = cmdAddItem.ExecuteNonQuery()

                Dim result As Integer = 0
                For Each item In Items
                    result += addItems(item)
                Next

                ' Init message variable
                Dim strMessage As String = ""

                ' have to let the user know what happened 
                If intTransactionResult = 1 And result > 0 Then
                    strMessage = "Transaction inserted successfully."
                Else
                    strMessage = "Transaction insertion failed."
                End If

                MessageBox.Show(strMessage)

                Connection.Close()
                CloseDatabaseConnection()

                If intTransactionResult = 1 And result > 0 Then
                    OpenFormKillParent(Me, frmInvoice)
                End If

            Catch excError As SqlException

                ' Handle SQL errors
                MessageBox.Show(excError.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Catch ex As Exception

                ' Handle General errors
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try
        End If
    End Sub

    Private Function addItems(item As ItemData) As Integer

        ' create command object
        Dim Connection As New SqlConnection("Server=itd2.cincinnatistate.edu;" &
                                            "Database=CPDM-GroupB;" &
                                            "User ID=" & strConnectionUsername & ";" &
                                            "Password=" & strConnectionPassword & ";")
        Dim cmdAddItem As New SqlCommand

        cmdAddItem.Connection = Connection
        cmdAddItem.CommandText = "uspReturnItems"
        cmdAddItem.CommandType = CommandType.StoredProcedure

        Try
            cmdAddItem.Parameters.AddWithValue("@intItemID", item.intItemID)
            cmdAddItem.Parameters.AddWithValue("@intItemAmount", item.intQty)
            cmdAddItem.Parameters.AddWithValue("@decCurrentItemPrice", item.decPrice)
            cmdAddItem.Parameters.AddWithValue("@dtTransactionDate", DateTime.Today)

            Connection.Open()

            ' have to let the user know what happened 
            If cmdAddItem.ExecuteNonQuery() = 1 Then
                Return 0
            Else
                Return 1
            End If

        Catch excError As SqlException

            ' Handle SQL errors
            MessageBox.Show(excError.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch ex As Exception

            ' Handle General errors
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Close()

        End Try
        Return -10
    End Function

    Private Sub btnRemoveSelectedItem_Click(sender As Object, e As EventArgs) Handles btnRemoveSelectedItem.Click
        If (lstItems.Items.Count <> 0) Then
            If (lstItems.SelectedIndex >= 0 And lstItems.SelectedIndex < lstItems.Items.Count) Then
                Dim delIt = Items.ElementAt(lstItems.SelectedIndex)
                If IsNumeric(txtPrice.Text) Then
                    txtPrice.Text = Convert.ToDecimal(txtPrice.Text) - (delIt.decPrice * delIt.intQty)
                    If (txtPrice.Text < 0) Then
                        txtPrice.Text = 0
                    End If
                End If
                Items.RemoveAt(lstItems.SelectedIndex)
                lstItems.Items.RemoveAt(lstItems.SelectedIndex)
                lstItems.Refresh()
            End If
        End If
    End Sub

    Private Sub LoadStates()

        Try

            ' Init select statement string
            Dim strSelect As String = ""
            ' Init select statement Db command
            Dim cmdSelect As OleDb.OleDbCommand
            ' Init data reader
            Dim drSourceTable As OleDb.OleDbDataReader
            ' Init data table
            Dim dt As DataTable = New DataTable

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

            ' Build the select statement
            strSelect = "SELECT intStateID, strState FROM TStates"

            ' Retrieve all the records 
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            ' load table from data reader
            dt.Load(drSourceTable)

            ' Add the item to the combo box. We need the user ID associated with the name so 
            ' when we click on the name we can then use the ID to pull the rest of the user data.
            ' We are binding the column name to the combo box display and value members. 
            cboState.ValueMember = "intStateID"
            cboState.DisplayMember = "strState"
            cboState.DataSource = dt

            ' Select the first item in the list by default
            If cboState.Items.Count > 0 Then cboState.SelectedIndex = 0

            ' Clean up
            drSourceTable.Close()

            ' close the database connection
            CloseDatabaseConnection()

        Catch excError As Exception

            ' Log and display error message
            MessageBox.Show(excError.Message)

        End Try

    End Sub

    Private Sub LoadPaymentTypes()

        Try

            ' Init select statement string
            Dim strSelect As String = ""
            ' Init select statement Db command
            Dim cmdSelect As OleDb.OleDbCommand
            ' Init data reader
            Dim drSourceTable As OleDb.OleDbDataReader
            ' Init data table
            Dim dt As DataTable = New DataTable

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

            ' Build the select statement
            strSelect = "SELECT intPaymentTypeID, strPaymentType FROM TPaymentTypes"

            ' Retrieve all the records 
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            ' load table from data reader
            dt.Load(drSourceTable)

            ' Add the item to the combo box. We need the user ID associated with the name so 
            ' when we click on the name we can then use the ID to pull the rest of the user data.
            ' We are binding the column name to the combo box display and value members. 
            cboPayment.ValueMember = "intPaymentTypeID"
            cboPayment.DisplayMember = "strPaymentType"
            cboPayment.DataSource = dt

            ' Select the first item in the list by default
            If cboPayment.Items.Count > 0 Then cboPayment.SelectedIndex = 0

            ' Clean up
            drSourceTable.Close()

            ' close the database connection
            CloseDatabaseConnection()

        Catch excError As Exception

            ' Log and display error message
            MessageBox.Show(excError.Message)

        End Try

    End Sub

    ' Only allow numbers in the phone number field
    Private Sub txtPhoneNumber_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPhoneNumber.KeyPress, txtPrice.KeyPress, txtCredit.KeyPress, txtSecurity.KeyPress

        ' Only accept number keystrokes and backspace keystroke
        If Not Char.IsNumber(e.KeyChar) And e.KeyChar <> ControlChars.Back Then
            e.Handled = True
        End If

    End Sub

    Private Function ValidateForm() As Boolean

        Dim blnResult As Boolean = False

        ' Validate
        If Validation() = True Then
            If VerifyCreditCard() = True Then
                If VerifySecurityCode() = True Then
                    If VerifyPhoneNumber() = True Then
                        If VerifyPrice() = True Then
                            If VerifyItemList() = True Then
                                blnResult = True
                            End If
                        End If
                    End If
                End If
            End If
        End If

        Return blnResult

    End Function

    Private Function VerifyCreditCard() As Boolean

        Dim blnResult As Boolean

        If (txtCredit.Enabled = True) Then
            If Information.IsNumeric(txtCredit.Text) Then
                If txtCredit.Text.Length >= 15 And txtCredit.Text.Length <= 16 Then 'convert to decimal and check for the range
                    blnResult = True
                Else
                    MessageBox.Show("Please enter a number between 15 and 16 digits long for the credit card number.") 'pop a message box if an error
                    blnResult = False
                End If
            Else
                MessageBox.Show("Please enter numbers only for the credit card number.") 'pop a message box if an error
                blnResult = False
            End If
        Else
            blnResult = True
        End If

        Return blnResult

    End Function

    Private Function VerifySecurityCode() As Boolean

        Dim blnResult As Boolean

        If (txtCredit.Enabled = True) Then
            If Information.IsNumeric(txtSecurity.Text) Then
                If txtSecurity.Text.Length >= 3 And txtSecurity.Text.Length <= 4 Then 'convert to decimal and check for the range
                    blnResult = True
                Else
                    MessageBox.Show("Please enter a number between 3 and 4 digits long for the security code.") 'pop a message box if an error
                    blnResult = False
                End If
            Else
                MessageBox.Show("Please enter numbers only for the security code.") 'pop a message box if an error
                blnResult = False
            End If
        Else
            blnResult = True
        End If

        Return blnResult

    End Function

    Private Function VerifyPhoneNumber() As Boolean

        Dim blnResult As Boolean

        If Information.IsNumeric(txtPhoneNumber.Text) Then
            If txtPhoneNumber.Text.Length >= 10 And txtPhoneNumber.Text.Length <= 11 Then 'convert to decimal and check for the range
                blnResult = True
            Else
                MessageBox.Show("Please enter a number between 10 and 11 digits long for the phone number.") 'pop a message box if an error
                blnResult = False
            End If
        Else
            MessageBox.Show("Please enter numbers only for the phone number.") 'pop a message box if an error
            blnResult = False
        End If

        Return blnResult

    End Function

    Private Function VerifyPrice() As Boolean

        Dim blnResult As Boolean

        If Information.IsNumeric(txtPhoneNumber.Text) Then
            blnResult = True
        Else
            MessageBox.Show("Please enter numbers only for the phone number.") 'pop a message box if an error
            blnResult = False
        End If

        Return blnResult

    End Function

    Private Function VerifyItemList() As Boolean

        Dim blnResult As Boolean

        If (lstItems.Items.Count > 0) Then
            blnResult = True
        Else
            MessageBox.Show("Please add an item to the order.") 'pop a message box if an error
            blnResult = False
        End If

        Return blnResult

    End Function

    Public Function Validation() As Boolean

        ' loop through the textboxes and clear them in case they have data in them after a delete
        For Each cntrl As Control In Controls
            If TypeOf cntrl Is TextBox And cntrl.Name <> "txtTax" Then
                cntrl.BackColor = Color.White
                If cntrl.Text = String.Empty Then
                    cntrl.BackColor = Color.Yellow
                    cntrl.Focus()
                    Return False
                End If
            Else
                If TypeOf cntrl Is GroupBox Then
                    For Each grpcntrl As Control In cntrl.Controls
                        If TypeOf grpcntrl Is TextBox And grpcntrl.Enabled = True Then
                            grpcntrl.BackColor = Color.White
                            If grpcntrl.Text = String.Empty Then
                                grpcntrl.BackColor = Color.Yellow
                                grpcntrl.Focus()
                                Return False
                            End If
                        End If
                    Next
                End If
            End If
        Next

        'every this is good so return true
        Return True

    End Function
End Class