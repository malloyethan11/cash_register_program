Public Class frmVendorEditor

    ' This public variable is set by the vendor lookup form when it opens this form
    Public intCurrentlyEditingVendorPrimaryKey As Integer
    Public Type As String = "Dialog"

    Private Sub frmVendorEditor_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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

        Try

            Dim strSelect As String = ""
            Dim cmdSelect As OleDb.OleDbCommand ' this will be used for our Select statement
            Dim drSourceTable As OleDb.OleDbDataReader ' this will be where our data is retrieved to
            Dim dt As DataTable = New DataTable ' this is the table we will load from our reader

            ' loop through the textboxes and clear them in case they have data in them after a delete
            For Each cntrl As Control In Controls
                If TypeOf cntrl Is TextBox Then
                    cntrl.Text = String.Empty
                End If
            Next

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

            ' Build the select statement
            strSelect = "SELECT intVendorID, strVendorName FROM TVendors WHERE intVendorID = " & intCurrentlyEditingVendorPrimaryKey

            ' Retrieve all the records 
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            ' load table from data reader
            dt.Load(drSourceTable)

            ' Add the item to the combo box. We need the event ID associated with the year so 
            ' when we click on the year we can then use the ID to pull the rest of the event data.
            ' We are binding the column year to the combo box display and value members. 
            txtVendor.Text = dt.Rows(0).Item(1).ToString

            ' Clean up
            drSourceTable.Close()

            ' close the database connection
            CloseDatabaseConnection()

        Catch ex As Exception

            ' Log and display error message
            MessageBox.Show(ex.Message)

        End Try

    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click

        Dim strSelect As String = ""
        Dim strVendorName As String = ""
        Dim intRowsAffected As Integer

        Try



            ' thie will hold our Update statement
            Dim cmdUpdate As OleDb.OleDbCommand

            ' check to make sure all text boxes have data. No data no update!
            If Validation() = True Then
                ' open database
                If OpenDatabaseConnectionSQLServer() = False Then

                    ' No, warn the user ...
                    MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                        "The application will now close.",
                                        Me.Text + " Error",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error)

                    ' and close the form/application
                    Me.Close()

                End If

                ' after you validate there is data put values into variables
                If Validation() = True Then

                    strVendorName = txtVendor.Text


                    ' Build the select statement using PK from name selected
                    strSelect = "Update TVendors Set strVendorName = '" & strVendorName & "'" &
                     "Where intVendorID = " & intCurrentlyEditingVendorPrimaryKey

                    ' uncomment out the following message box line to use as a tool to check your sql statement
                    ' remember anything not a numeric value going into SQL Server must have single quotes '
                    ' around it, including dates.

                    MessageBox.Show(strSelect)


                    ' make the connection
                    cmdUpdate = New OleDb.OleDbCommand(strSelect, m_conAdministrator)

                    ' IUpdate the row with execute the statement
                    intRowsAffected = cmdUpdate.ExecuteNonQuery()

                    ' have to let the user know what happened 
                    If intRowsAffected = 1 Then
                        MessageBox.Show("Update successful")
                    Else
                        MessageBox.Show("Update failed")
                    End If

                    ' close the database connection
                    CloseDatabaseConnection()

                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Public Function Validation() As Boolean

        ' loop through the textboxes and check to make sure there is data in them
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

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Dim frmNewVendorLookup As New frmVendorLookup

        OpenFormKillParent(Me, frmNewVendorLookup)
    End Sub
End Class