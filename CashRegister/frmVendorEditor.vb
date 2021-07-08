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

        LoadVendor()

    End Sub

    Private Sub LoadVendor()
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

        ' Test permission
        If MyUser.CanEditVendors = True Then
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


                        ' Build the select statement using PK from name selected (Updated for injection attacks)
                        strSelect = "Update TVendors Set strVendorName = ?" &
                     " Where intVendorID = " & intCurrentlyEditingVendorPrimaryKey

                        ' uncomment out the following message box line to use as a tool to check your sql statement
                        ' remember anything not a numeric value going into SQL Server must have single quotes '
                        ' around it, including dates.

                        'MessageBox.Show(strSelect)


                        ' make the connection
                        cmdUpdate = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
                        cmdUpdate.Parameters.AddWithValue("@VendorName", strVendorName)

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
        Else
            MessageBox.Show("You do not have permission to edit vendors!", "Error")
        End If

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

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click


        Dim strDelete As String = ""
        Dim strSelect As String = String.Empty
        Dim strName As String = ""
        Dim intRowsAffected As Integer
        Dim cmdDelete As OleDb.OleDbCommand ' this will be used for our Delete statement
        Dim dt As DataTable = New DataTable ' this is the table we will load from our reader
        Dim result As DialogResult  ' this is the result of which button the user selects

        ' Test permission
        If MyUser.CanDeleteVendors = True Then
            Try
                ' open the database this is in module
                If OpenDatabaseConnectionSQLServer() = False Then

                    ' No, warn the user ...
                    MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                    "The application will now close.",
                                    Me.Text + " Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)

                    ' and close the form/application
                    Me.Close()

                End If

                ' always ask before deleting!!!!
                result = MessageBox.Show("Are you sure you want to Delete Vendor: " & txtVendor.Text & "?", "Confirm Deletion", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)

                ' this will figure out which button was selected. Cancel and No does nothing, Yes will allow deletion
                Select Case result
                    Case DialogResult.Cancel
                        MessageBox.Show("Action Canceled")
                    Case DialogResult.No
                        MessageBox.Show("Action Canceled")
                    Case DialogResult.Yes


                        ' Build the delete statement using PK from name selected
                        ' must delete any child records first
                        strDelete = "Delete FROM TItems Where intVendorID = " & intCurrentlyEditingVendorPrimaryKey

                        ' Delete the record(s) 
                        cmdDelete = New OleDb.OleDbCommand(strDelete, m_conAdministrator)
                        intRowsAffected = cmdDelete.ExecuteNonQuery()

                        ' delete the other child record

                        ' now we can delete the parent record
                        strDelete = "Delete FROM TVendors Where intVendorID = " & intCurrentlyEditingVendorPrimaryKey

                        ' Delete the record(s) 
                        cmdDelete = New OleDb.OleDbCommand(strDelete, m_conAdministrator)
                        intRowsAffected = cmdDelete.ExecuteNonQuery()

                        ' Did it work?
                        If intRowsAffected > 0 Then

                            ' Yes, success
                            MessageBox.Show("Delete successful")

                        End If

                End Select


                ' close the database connection
                CloseDatabaseConnection()

                ' call the go back to the vendor lookup after a delete
                Dim frmNewVendorLookup As New frmVendorLookup

                OpenFormKillParent(Me, frmNewVendorLookup)

            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        Else
            MessageBox.Show("You do not have permission to delete vendors!", "Error")
        End If

    End Sub

    Private Sub StepAction_Tick(sender As Object, e As EventArgs) Handles StepAction.Tick

        ButtonColor(MousePosition, btnDelete, Me, btmButtonShortGray, btmButtonShort)
        ButtonColor(MousePosition, btnExit, Me, btmButtonShortGray, btmButtonShort)
        ButtonColor(MousePosition, btnUpdate, Me, btmButtonShortGray, btmButtonShort)

    End Sub
End Class