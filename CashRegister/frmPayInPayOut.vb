Imports System.IO
Imports System.Data.SqlClient

Public Class frmPayInPayOut
    Private Sub frmPayInPayOut_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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

        cboType.SelectedIndex = 0

    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click


        ' variables for new item data
        Dim strDesc As String = ""
        Dim decPrice As Decimal = 0
        Dim strType As String = ""

        Try
            ' validate data is entered
            If Validation() = True Then
                If VerifyPrice(decPrice) = True Then

                    strDesc = txtDescription.Text
                    decPrice = txtPrice.Text
                    strType = cboType.Text

                    ' pass inputs, now validated to sub AddItem to enter in DB
                    AddPay(strDesc, decPrice, strType)

                    ' Clear all boxes
                    txtDescription.ResetText()
                    txtPrice.ResetText()
                End If
            End If
        Catch excError As Exception
            MessageBox.Show(excError.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Function Validation() As Boolean

        ' loop through the textboxes and clear them in case they have data in them after a delete
        For Each cntrl As Control In Controls
            If TypeOf cntrl Is TextBox Then
                cntrl.BackColor = Color.White
                If cntrl.Text = String.Empty Then
                    cntrl.BackColor = Color.Yellow
                    cntrl.Focus()
                    Return False
                End If
            End If
        Next

        'every this is good so return true
        Return True

    End Function

    Private Function VerifyPrice(ByRef ItemPrice As Decimal) As Boolean
        If IsNumeric(txtPrice.Text) Then
            If Convert.ToDecimal(txtPrice.Text) > 0 Then 'convert to decimal and check for the range
                ItemPrice = Convert.ToDecimal(txtPrice.Text) 'convert it to a decimal and set price
            Else
                MessageBox.Show("Please enter a number greater than 0 for the price.") 'pop a message box if an error
                Return False
            End If
        Else
            MessageBox.Show("Please enter numbers only for the price.") 'pop a message box if an error
            Return False
        End If
        Return True

    End Function

    Private Sub AddPay(ByVal strDesc As String, ByVal decPrice As Decimal, ByVal strType As String)

        ' create command object
        Dim Connection As New SqlConnection("Server=itd2.cincinnatistate.edu;" &
                                                      "Database=CPDM-GroupB;" &
                                                      "User ID=" & strConnectionUsername & ";" &
                                                      "Password=" & strConnectionPassword & ";")

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

        Dim cmdAddTransaction As New SqlCommand
        cmdAddTransaction.Connection = Connection
        cmdAddTransaction.CommandText = "uspTransaction"
        cmdAddTransaction.CommandType = CommandType.StoredProcedure


        Try

            ' Get transaction type
            ' Init select string
            Dim strSelectTransType As String
            ' Init command
            Dim cmdTransTypeSelect As OleDb.OleDbCommand
            ' Init data reader
            Dim drTransTypeSourceTable As OleDb.OleDbDataReader
            ' Init data table
            Dim dtTransType As DataTable = New DataTable
            ' Init row set
            Dim drTransTypeSet() As System.Data.DataRow

            ' Select statement
            strSelectTransType = "SELECT intTransactionTypeID FROM TTransactionTypes WHERE strTransactionType = '" & cboType.Text & "'"

            ' Retrieve all the records 
            cmdTransTypeSelect = New OleDb.OleDbCommand(strSelectTransType, m_conAdministrator)
            drTransTypeSourceTable = cmdTransTypeSelect.ExecuteReader

            ' load table from data reader
            dtTransType.Load(drTransTypeSourceTable)

            ' Populate the array based on search
            drTransTypeSet = dtTransType.Select()

            ' Get payment type
            ' Init select string
            Dim strSelectPayType As String
            ' Init command
            Dim cmdPayTypeSelect As OleDb.OleDbCommand
            ' Init data reader
            Dim drPayTypeSourceTable As OleDb.OleDbDataReader
            ' Init data table
            Dim dtPayType As DataTable = New DataTable
            ' Init row set
            Dim drPayTypeSet() As System.Data.DataRow

            ' Select statement
            strSelectPayType = "SELECT intPaymentTypeID FROM TPaymentTypes WHERE strPaymentType = 'Cash'"

            ' Retrieve all the records 
            cmdPayTypeSelect = New OleDb.OleDbCommand(strSelectPayType, m_conAdministrator)
            drPayTypeSourceTable = cmdPayTypeSelect.ExecuteReader

            ' load table from data reader
            dtPayType.Load(drPayTypeSourceTable)

            ' Populate the array based on search
            drPayTypeSet = dtPayType.Select()

            ' Add values
            cmdAddTransaction.Parameters.AddWithValue("@intTransactionTypeID", drTransTypeSet(0)("intTransactionTypeID"))
            cmdAddTransaction.Parameters.AddWithValue("@intPaymentTypeID", drPayTypeSet(0)("intPaymentTypeID"))
            cmdAddTransaction.Parameters.AddWithValue("@strDescription", strDesc)
            cmdAddTransaction.Parameters.AddWithValue("@decTotalPrice", decPrice)

            cmdAddTransaction.Parameters.AddWithValue("@strFirstName", "N/A")
            cmdAddTransaction.Parameters.AddWithValue("@strLastName", "N/A")
            cmdAddTransaction.Parameters.AddWithValue("@strAddress", "N/A")
            cmdAddTransaction.Parameters.AddWithValue("@strCity", "N/A")
            cmdAddTransaction.Parameters.AddWithValue("@intStateID", 0)
            cmdAddTransaction.Parameters.AddWithValue("@strZip", "N/A")
            cmdAddTransaction.Parameters.AddWithValue("@strPhoneNumber", "N/A")
            cmdAddTransaction.Parameters.AddWithValue("@strEmail", "N/A")
            cmdAddTransaction.Parameters.AddWithValue("@decSalesTax", 0)
            cmdAddTransaction.Parameters.AddWithValue("@strUsername", MyUser.Username)

            cmdAddTransaction.Parameters.AddWithValue("@strCreditCard", "")
            cmdAddTransaction.Parameters.AddWithValue("@strExpirationDate", "")
            cmdAddTransaction.Parameters.AddWithValue("@strSecurityCode", "")
            ' Citation https://stackoverflow.com/questions/13355638/get-the-current-date-and-time
            cmdAddTransaction.Parameters.AddWithValue("@dtTransactionDate", DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"))

            ' Close source table
            drTransTypeSourceTable.Close()
            drPayTypeSourceTable.Close()

            Connection.Open()

            ' have to let the user know what happened 
            If cmdAddTransaction.ExecuteNonQuery() = 1 Then
                MessageBox.Show("Insert successful. Transaction has been processed.")

            Else
                MessageBox.Show("Insert failed")

            End If

        Catch excError As SqlException

            ' Handle SQL errors
            MessageBox.Show(excError.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch ex As Exception

            ' Handle General errors
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Close()

        End Try


    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click

        OpenFormKillParent(Me, frmTransactions)

    End Sub

    Private Sub StepAction_Tick(sender As Object, e As EventArgs) Handles StepAction.Tick

        ButtonColor(MousePosition, btnExit, Me, btmButtonLittleLongGray, btmButtonLittleLong)
        ButtonColor(MousePosition, btnAdd, Me, btmButtonShortGray, btmButtonShort)

    End Sub
End Class