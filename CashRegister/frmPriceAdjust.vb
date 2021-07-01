
' Database code adapted from Programming 2 homework

Public Class frmPriceAdjust
    Private Sub frmPriceAdjust_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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

        ' Load cboVendor with vendors
        LoadVendors()

    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click

        OpenFormKillParent(Me, frmInventory)

    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click

        ' declare variables
        Dim intAdjustmentAmount As Integer
        Dim dblAdjustmentAmount As Double
        Dim strVendorName As String
        Dim strAdjustmentType As String

        ' validate input
        If ValidateInput(txtAmount.Text) = True Then

            ' determine adjustment type (dollar amount or percent)
            If strAdjustmentType = "%" Then

                dblAdjustmentAmount = txtAmount.Text

                ' build and execute update statement
                Try






                Catch ex As Exception

                End Try

            ElseIf strAdjustmentType = "Dollars" Then

                dblAdjustmentAmount = txtAmount.Text

                ' build and execute update statement
                Try

                    Dim strUpdate As String = ""
                    Dim cmdUpdate As OleDb.OleDbCommand

                    ' open the DB
                    If OpenDatabaseConnectionSQLServer() = False Then

                        ' No, warn the user ...
                        MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                                "The application will now close.",
                                                Me.Text + " Error",
                                                MessageBoxButtons.OK, MessageBoxIcon.Error)

                        ' and close the form/application
                        Me.Close()

                    End If

                    ' build db insert string and command
                    strUpdate = "UPDATE TItems SET decItemPrice = decItemPrice + " & dblAdjustmentAmount & " WHERE intVendorID = " & cboVendor.SelectedIndex
                    cmdUpdate = New OleDb.OleDbCommand(strUpdate, m_conAdministrator)

                    ' insert the records
                    cmdUpdate.ExecuteNonQuery()

                    ' close the db connection
                    CloseDatabaseConnection()

                    ' display message box to notify of successful insert
                    MessageBox.Show("Prices successfully adjusted!")

                    ' clear textbox for next vendor
                    txtAmount.Clear()

                Catch ex As Exception

                End Try

            End If

        End If


    End Sub

    Private Sub LoadVendors()

        Try

            Dim strSelect As String = ""
            Dim cmdSelect As OleDb.OleDbCommand ' this will be used for our Select statement
            Dim drSourceTable As OleDb.OleDbDataReader ' this will be where our data is retrieved to
            Dim dt As DataTable = New DataTable ' this is the table we will load from our reader

            ' open the DB
            If OpenDatabaseConnectionSQLServer() = False Then

                ' No, warn the user ...
                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                    "The application will now close.",
                                    Me.Text + " Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)

                ' and close the form/application
                Me.Close()

            End If

            ' build the select statement
            strSelect = "SELECT intVendorID, strVendorName FROM TVendors ORDER BY strVendorName ASC"

            ' Retrieve all the records 
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            ' load table from data reader
            dt.Load(drSourceTable)

            ' Add the item to the combo box. We need the sponsor ID associated with the name so 
            ' when we click on the name we can then use the ID to pull the rest of the sponsors data.
            ' We are binding the column name to the combo box display and value members. 
            cboVendor.ValueMember = "intVendorID"
            cboVendor.DisplayMember = "strVendorName"
            cboVendor.DataSource = dt

            ' Select the first item in the list by default
            If cboVendor.Items.Count > 0 Then cboVendor.SelectedIndex = 0

            ' Clean up
            drSourceTable.Close()

            ' close the database connection
            CloseDatabaseConnection()

        Catch ex As Exception

            ' Log and display error message
            MessageBox.Show(ex.Message)

        End Try

    End Sub

    Private Function ValidateInput(ByVal strUserInput As String) As Boolean

        ' declare variable
        Dim blnResult As Boolean

        ' validate user input
        If strUserInput = "" Then

            MessageBox.Show("Please enter a dollar amount or percentage to adjust the price by.")
            blnResult = False

        ElseIf IsNumeric(strUserInput) = False Then

            MessageBox.Show("Please enter numbers only.")
            blnResult = False

        Else

            blnResult = True

        End If

        Return blnResult

    End Function

End Class