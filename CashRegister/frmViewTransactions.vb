Public Class frmViewTransactions

    Dim intStartIndex As Integer = 0
    Dim drSet As System.Data.DataRowCollection
    Dim intPages As Integer = 0
    Dim intTotalTransactions As Integer = 0

    Private Sub frmViewTransactions_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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

        OpenFormKillParent(Me, frmTransactions)

    End Sub

    Private Sub txtSearch_GotFocus(sender As Object, e As EventArgs) Handles txtSearch.Enter

        '  If the text box is selected
        txtSearch.ForeColor = Color.Black
        ' Remove the search text
        If (txtSearch.Text = "Type here to search...") Then
            txtSearch.Text = ""
        End If

    End Sub

    Private Sub txtSearch_LostFocus(sender As Object, e As EventArgs) Handles txtSearch.Leave

        ' If the text box is not selected 
        txtSearch.ForeColor = Color.DarkGray
        ' Add the search text
        If (String.IsNullOrEmpty(txtSearch.Text) Or String.IsNullOrWhiteSpace(txtSearch.Text)) Then
            txtSearch.Text = "Type here to search..."
        End If

    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click

        ' If the search text is in there, remove it
        If (txtSearch.Text = "Type here to search...") Then
            txtSearch.Text = ""
        End If

        ' Load
        If (String.IsNullOrEmpty(cboFilter.Text) = False And String.IsNullOrEmpty(cboType.Text) = False) Then
            LoadTransactions()
        End If

    End Sub

    Private Sub LoadTransactions()

        Cursor.Current = Cursors.WaitCursor

        Try

            ' Init select statement string
            Dim strSelect As String = ""

            'For state or payment type
            ' Init select statement Db command
            Dim cmdStatePaySelect As OleDb.OleDbCommand
            ' Init data reader
            Dim drStatePaySourceTable As OleDb.OleDbDataReader
            ' Init data table
            Dim dtStatePay As DataTable = New DataTable

            ' For transaction
            ' Init select statement Db command
            Dim cmdSelect As OleDb.OleDbCommand
            ' Init data reader
            Dim drSourceTable As OleDb.OleDbDataReader
            ' Init data table
            Dim dt As DataTable = New DataTable

            ' Filter strings
            Dim strFilter As String
            ' Cat ID
            Dim drPaymentTypeSet() As System.Data.DataRow
            ' Ven ID
            Dim drStateSet() As System.Data.DataRow

            ' Reset number
            intPages = 0

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

            ' Get the filter
            Select Case cboFilter.Text
                Case "Payment Type"
                    strFilter = "intPaymentTypeID"
                Case "Sales Tax"
                    strFilter = "decSalesTax"
                Case "Last Name"
                    strFilter = "strLastName"
                Case "Address"
                    strFilter = "strAddress"
                Case "City"
                    strFilter = "strCity"
                Case "State"
                    strFilter = "intStateID"
                Case "Zip"
                    strFilter = "strZip"
                Case "Phone Number"
                    strFilter = "strPhoneNumber"
                Case "Email"
                    strFilter = "strEmail"
                Case "Total Price"
                    strFilter = "decTotalPrice"
                Case Else
                    strFilter = "strFirstName"
            End Select

            If (strFilter = "intPaymentTypeID") Then

                'strSelect = "SELECT intCategoryID, strCategory FROM TCategories
                'WHERE strCategory Like '%" & txtSearch.Text & "%'"
                strSelect = "SELECT intPaymentTypeID, strPaymentType FROM TPaymentTypes WHERE strPaymentType Like '%' +" & "?" & "+ '%'"

                ' Retrieve all the records 
                cmdStatePaySelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
                cmdStatePaySelect.Parameters.AddWithValue("SearchText", txtSearch.Text)
                drStatePaySourceTable = cmdStatePaySelect.ExecuteReader

                ' load table from data reader
                dtStatePay.Load(drStatePaySourceTable)

                ' Populate the array based on search
                drPaymentTypeSet = dtStatePay.Select()

                ' init
                Dim strSelectList As String = "intPaymentTypeID = -1"
                Dim blnFirst As Boolean = True
                Dim intCount As Integer = 0

                ' Gather
                For Each Row In drPaymentTypeSet
                    If (blnFirst = True) Then
                        strSelectList = "intPaymentTypeID = " & drPaymentTypeSet(intCount)("intPaymentTypeID").ToString
                        blnFirst = False
                    Else
                        strSelectList = strSelectList & " OR intPaymentTypeID = " & drPaymentTypeSet(intCount)("intPaymentTypeID").ToString
                    End If
                    intCount += 1
                Next

                ' Select all that apply
                strSelect = "SELECT intTransactionID, intPaymentTypeID, intTransactionTypeID, strFirstName, strLastName, strAddress, strCity, intStateID, strZip, strPhoneNumber, strEmail, strCreditCard, strExpirationDate, strSecurityCode, decTotalPrice, decSalesTax FROM TTransactions WHERE intTransactionTypeID = " & cboType.SelectedIndex + 1 & " AND (" & strSelectList & ")"

                ' Retrieve all the records 
                cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
                drSourceTable = cmdSelect.ExecuteReader

                ' load table from data reader
                dt.Load(drSourceTable)

                ' Populate the array based on search
                drSet = dt.Rows

                ' Clean up
                drStatePaySourceTable.Close()

            ElseIf (strFilter = "intStateID") Then

                'strSelect = "SELECT intCategoryID, strCategory FROM TCategories
                'WHERE strCategory Like '%" & txtSearch.Text & "%'"
                strSelect = "SELECT intStateID, strState FROM TStates WHERE strState Like '%' +" & "?" & "+ '%'"

                ' Retrieve all the records 
                cmdStatePaySelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
                cmdStatePaySelect.Parameters.AddWithValue("SearchText", txtSearch.Text)
                drStatePaySourceTable = cmdStatePaySelect.ExecuteReader

                ' load table from data reader
                dtStatePay.Load(drStatePaySourceTable)

                ' Populate the array based on search
                drStateSet = dtStatePay.Select()

                ' init
                Dim strSelectList As String = "intStateID = -1"
                Dim blnFirst As Boolean = True
                Dim intCount As Integer = 0

                ' Gather
                For Each Row In drStateSet
                    If (blnFirst = True) Then
                        strSelectList = "intStateID = " & drStateSet(intCount)("intStateID").ToString
                        blnFirst = False
                    Else
                        strSelectList = strSelectList & " OR intStateID = " & drStateSet(intCount)("intStateID").ToString
                    End If
                    intCount += 1
                Next

                ' Select all that apply
                strSelect = "SELECT intTransactionID, intPaymentTypeID, intTransactionTypeID, strFirstName, strLastName, strAddress, strCity, intStateID, strZip, strPhoneNumber, strEmail, strCreditCard, strExpirationDate, strSecurityCode, decTotalPrice, decSalesTax FROM TTransactions WHERE intTransactionTypeID = " & cboType.SelectedIndex + 1 & " AND (" & strSelectList & ")"

                ' Retrieve all the records 
                cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
                drSourceTable = cmdSelect.ExecuteReader

                ' load table from data reader
                dt.Load(drSourceTable)

                ' Populate the array based on search
                drSet = dt.Rows

                ' Clean up
                drStatePaySourceTable.Close()

            Else
                strSelect = "SELECT intTransactionID, intPaymentTypeID, intTransactionTypeID, strFirstName, strLastName, strAddress, strCity, intStateID, strZip, strPhoneNumber, strEmail, strCreditCard, strExpirationDate, strSecurityCode, decTotalPrice, decSalesTax FROM TTransactions WHERE intTransactionTypeID = " & cboType.SelectedIndex + 1 & " AND (" & strFilter & " Like '%'+" & "?" & "+'%')"

                ' Retrieve all the records 
                cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
                cmdSelect.Parameters.AddWithValue("SearchText", txtSearch.Text)
                drSourceTable = cmdSelect.ExecuteReader

                ' load table from data reader
                dt.Load(drSourceTable)

                ' Populate the array based on search
                drSet = dt.Rows

            End If

            ' Calc total pages
            intTotalTransactions = drSet.Count
            While (intTotalTransactions > 0)
                intPages += 1
                intTotalTransactions -= 5
            End While

            ' Set the page number to 1 if 0
            If (intPages = 0) Then intPages = 1

            ' Reset index
            intStartIndex = 0

            ' Display
            DisplayData()

            ' Clean up
            drSourceTable.Close()

            ' close the database connection
            CloseDatabaseConnection()

        Catch excError As Exception

            Cursor.Current = Cursors.Default

            ' Log and display error message
            MessageBox.Show(excError.Message)

        End Try

        Cursor.Current = Cursors.Default

    End Sub

    Private Sub DisplayData()

        ' Set page number text
        If (intStartIndex < 4) Then
            lblPageNumber.Text = "Page " & (intStartIndex + 1) & " of " & (intPages)
        Else
            lblPageNumber.Text = "Page " & (intStartIndex + 5) / 5 & " of " & (intPages)
        End If

        ' I wish there was a more iterative approach to this, but this was the best way to handle it because every control has its own unique name.
        ' Load transaction 1
        DisplayTransaction(intStartIndex,
                            txtCredit1,
                            txtFirstName1,
                            txtLastName1,
                            txtExpirationDate1,
                            txtSecurityCode1,
                            txtEmail1,
                            txtPhoneNumber1,
                            txtAddress1,
                            txtCity1,
                            txtZip1,
                            txtTotalPrice1,
                            txtSalesTax1,
                            txtTransactionType1,
                            txtPaymentType1,
                            txtState1,
                            lstItems1,
                            lblTransactionID1)

        ' Load transaction 2
        DisplayTransaction(intStartIndex + 1,
                            txtCredit2,
                            txtFirstName2,
                            txtLastName2,
                            txtExpirationDate2,
                            txtSecurityCode2,
                            txtEmail2,
                            txtPhoneNumber2,
                            txtAddress2,
                            txtCity2,
                            txtZip2,
                            txtTotalPrice2,
                            txtSalesTax2,
                            txtTransactionType2,
                            txtPaymentType2,
                            txtState2,
                            lstItems2,
                            lblTransactionID2)

        ' Load transaction 3
        DisplayTransaction(intStartIndex + 2,
                            txtCredit3,
                            txtFirstName3,
                            txtLastName3,
                            txtExpirationDate3,
                            txtSecurityCode3,
                            txtEmail3,
                            txtPhoneNumber3,
                            txtAddress3,
                            txtCity3,
                            txtZip3,
                            txtTotalPrice3,
                            txtSalesTax3,
                            txtTransactionType3,
                            txtPaymentType3,
                            txtState3,
                            lstItems3,
                            lblTransactionID3)

        ' Load transaction 4
        DisplayTransaction(intStartIndex + 3,
                            txtCredit4,
                            txtFirstName4,
                            txtLastName4,
                            txtExpirationDate4,
                            txtSecurityCode4,
                            txtEmail4,
                            txtPhoneNumber4,
                            txtAddress4,
                            txtCity4,
                            txtZip4,
                            txtTotalPrice4,
                            txtSalesTax4,
                            txtTransactionType4,
                            txtPaymentType4,
                            txtState4,
                            lstItems4,
                            lblTransactionID4)

        ' Load transaction 5
        DisplayTransaction(intStartIndex + 4,
                            txtCredit5,
                            txtFirstName5,
                            txtLastName5,
                            txtExpirationDate5,
                            txtSecurityCode5,
                            txtEmail5,
                            txtPhoneNumber5,
                            txtAddress5,
                            txtCity5,
                            txtZip5,
                            txtTotalPrice5,
                            txtSalesTax5,
                            txtTransactionType5,
                            txtPaymentType5,
                            txtState5,
                            lstItems5,
                            lblTransactionID5)

    End Sub

    Private Sub DisplayTransaction(ByVal intIndex As Integer, ByRef txtCredit As TextBox, ByRef txtFirstName As TextBox, ByRef txtLastName As TextBox, ByRef txtExpirationDate As TextBox,
                                    ByRef txtSecurityCode As TextBox, ByRef txtEmail As TextBox, ByRef txtPhoneNumber As TextBox, ByRef txtAddress As TextBox,
                                    ByRef txtCity As TextBox, ByRef txtZip As TextBox, ByRef txtTotalPrice As TextBox, ByRef txtSalesTax As TextBox, ByRef txtTransactionType As TextBox,
                                    ByRef txtPaymentType As TextBox, ByRef txtState As TextBox, ByRef lstItems As ListBox, ByRef lblPrimaryKey As Label)

        ' Populate each
        If (drSet.Count >= intIndex + 1) Then
            ' Get regular fields
            txtCredit.Text = drSet(intIndex)("strCreditCard").ToString
            txtFirstName.Text = drSet(intIndex)("strFirstName").ToString
            txtLastName.Text = drSet(intIndex)("strLastName").ToString
            txtExpirationDate.Text = drSet(intIndex)("strExpirationDate").ToString
            txtSecurityCode.Text = drSet(intIndex)("strSecurityCode").ToString
            txtEmail.Text = drSet(intIndex)("strEmail").ToString
            txtPhoneNumber.Text = drSet(intIndex)("strPhoneNumber").ToString
            txtAddress.Text = drSet(intIndex)("strAddress").ToString
            txtCity.Text = drSet(intIndex)("strCity").ToString
            txtZip.Text = drSet(intIndex)("strZip").ToString
            txtTotalPrice.Text = drSet(intIndex)("decTotalPrice").ToString
            txtSalesTax.Text = drSet(intIndex)("decSalesTax").ToString
            txtTransactionType.Text = cboType.Text
            lblPrimaryKey.Text = drSet(intIndex)("intTransactionID").ToString

            ' START ITEMS GET

            ' Get linked items
            ' Init select string
            Dim strSelectItems As String
            ' Init command
            Dim cmdItemsSelect As OleDb.OleDbCommand
            ' Init data reader
            Dim drItemSourceTable As OleDb.OleDbDataReader
            ' Init data table
            Dim dtItems As DataTable = New DataTable
            ' Init row set
            Dim drItemTypeSet() As System.Data.DataRow

            ' Select statement
            strSelectItems = "SELECT intItemID, intItemAmount FROM TTransactionItems WHERE intTransactionID = ?"

            ' Retrieve all the records 
            cmdItemsSelect = New OleDb.OleDbCommand(strSelectItems, m_conAdministrator)
            cmdItemsSelect.Parameters.AddWithValue("Type", drSet(intIndex)("intTransactionID").ToString)
            drItemSourceTable = cmdItemsSelect.ExecuteReader

            ' load table from data reader
            dtItems.Load(drItemSourceTable)

            ' Populate the array based on search
            drItemTypeSet = dtItems.Select()

            ' Display
            lstItems.Items.Clear()
            Dim intCount As Integer = 0
            For Each row In drItemTypeSet

                'lstItems.Items.Add(drItemTypeSet(intCount)("intItemID").ToString)

                ' Init select string
                Dim strSelectItemName As String
                ' Init command
                Dim cmdItemNameSelect As OleDb.OleDbCommand
                ' Init data reader
                Dim drItemNameSourceTable As OleDb.OleDbDataReader
                ' Init data table
                Dim dtItemNames As DataTable = New DataTable
                ' Init row set
                Dim drItemNameTypeSet() As System.Data.DataRow

                ' Select statement
                strSelectItemName = "SELECT strSKU, strItemName FROM TItems WHERE intItemID = ?"

                ' Retrieve all the records 
                cmdItemNameSelect = New OleDb.OleDbCommand(strSelectItemName, m_conAdministrator)
                cmdItemNameSelect.Parameters.AddWithValue("Type", drItemTypeSet(intCount)("intItemID").ToString)
                drItemNameSourceTable = cmdItemNameSelect.ExecuteReader

                ' load table from data reader
                dtItemNames.Load(drItemNameSourceTable)

                ' Populate the array based on search
                drItemNameTypeSet = dtItemNames.Select()

                ' Add record to the item list
                lstItems.Items.Add("SKU: " & drItemNameTypeSet(0)("strSKU").ToString & ", Name: " & drItemNameTypeSet(0)("strItemName").ToString & ", QTY: " & drItemTypeSet(intCount)("intItemAmount").ToString)

                ' Advance
                intCount += 1

            Next

            ' Clean up
            drItemSourceTable.Close()

            ' END ITEMS GET

            ' Get linked field payment type
            ' Init select string
            Dim strSelectForPaymentType As String
            ' Init command
            Dim cmdPaymentSelect As OleDb.OleDbCommand
            ' Init data reader
            Dim drPaymentSourceTable As OleDb.OleDbDataReader
            ' Init data table
            Dim dtPayment As DataTable = New DataTable
            ' Init row set
            Dim drPaymentTypeSet() As System.Data.DataRow

            ' Select statement
            strSelectForPaymentType = "SELECT intPaymentTypeID, strPaymentType FROM TPaymentTypes WHERE intPaymentTypeID = ?"

            ' Retrieve all the records 
            cmdPaymentSelect = New OleDb.OleDbCommand(strSelectForPaymentType, m_conAdministrator)
            cmdPaymentSelect.Parameters.AddWithValue("Type", drSet(intIndex)("intPaymentTypeID").ToString)
            drPaymentSourceTable = cmdPaymentSelect.ExecuteReader

            ' load table from data reader
            dtPayment.Load(drPaymentSourceTable)

            ' Populate the array based on search
            drPaymentTypeSet = dtPayment.Select()

            ' Display
            txtPaymentType.Text = drPaymentTypeSet(0)("strPaymentType").ToString

            ' Clean up
            drPaymentSourceTable.Close()

            ' Get linked field state
            ' Init select string
            Dim strSelectForState As String
            ' Init command
            Dim cmdStateSelect As OleDb.OleDbCommand
            ' Init data reader
            Dim drStateSourceTable As OleDb.OleDbDataReader
            ' Init data table
            Dim dtState As DataTable = New DataTable
            ' Init row set
            Dim drStateTypeSet() As System.Data.DataRow

            ' Select statement
            strSelectForState = "SELECT intStateID, strState FROM TStates WHERE intStateID = ?"

            ' Retrieve all the records 
            cmdStateSelect = New OleDb.OleDbCommand(strSelectForState, m_conAdministrator)
            cmdStateSelect.Parameters.AddWithValue("State", drSet(intIndex)("intStateID").ToString)
            drStateSourceTable = cmdStateSelect.ExecuteReader

            ' load table from data reader
            dtState.Load(drStateSourceTable)

            ' Populate the array based on search
            drStateTypeSet = dtState.Select()

            ' Display
            txtState.Text = drStateTypeSet(0)("strState").ToString

            ' Clean up
            drStateSourceTable.Close()
            drItemSourceTable.Close()

        Else
            txtCredit.Text = ""
            txtFirstName.Text = ""
            txtLastName.Text = ""
            txtExpirationDate.Text = ""
            txtSecurityCode.Text = ""
            txtEmail.Text = ""
            txtPhoneNumber.Text = ""
            txtAddress.Text = ""
            txtCity.Text = ""
            txtZip.Text = ""
            txtPaymentType.Text = ""
            txtTransactionType.Text = ""
            txtState.Text = ""
            txtTotalPrice.Text = ""
            txtSalesTax.Text = ""
            lstItems.Items.Clear()
        End If

    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click

        Cursor.Current = Cursors.WaitCursor

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

        ' Go to last page
        If (drSet IsNot Nothing) Then
            If (intStartIndex > 0) Then
                intStartIndex -= 5
                DisplayData()
            End If
        End If

        ' Close DB
        CloseDatabaseConnection()

        Cursor.Current = Cursors.Default

    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click

        Cursor.Current = Cursors.WaitCursor

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

        ' Go to next page
        If (drSet IsNot Nothing) Then
            If (drSet.Count > intStartIndex + 5) Then
                intStartIndex += 5
                DisplayData()
            End If
        End If

        ' Close DB
        CloseDatabaseConnection()

        Cursor.Current = Cursors.Default

    End Sub

End Class