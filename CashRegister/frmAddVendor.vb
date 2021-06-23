
' Database code adapted from Programming 2 homework

Public Class frmAddVendor
    Private Sub frmAddVendor_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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


    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click

        ' declare variables
        Dim strVendor As String = ""
        Dim strDbInsertString As String = ""
        Dim cmdInsert As OleDb.OleDbCommand

        ' get value from user entry
        strVendor = txtVendorName.Text

        ' validate user input
        If ValidateInput(strVendor) = True Then

            Try

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
                strDbInsertString = "INSERT INTO TVendors (strVendorName) VALUES ('" & strVendor & "');"
                cmdInsert = New OleDb.OleDbCommand(strDbInsertString, m_conAdministrator)

                ' insert the records
                cmdInsert.ExecuteNonQuery()

                ' close the db connection
                CloseDatabaseConnection()

                ' display message box to notify of successful insert
                MessageBox.Show("Vendor successfully added!")

                ' clear textbox for next vendor
                txtVendorName.Clear()


            Catch excError As Exception

                ' log and display error message
                MessageBox.Show(excError.Message)

            End Try

        End If


    End Sub


    Private Function ValidateInput(ByVal strInput As String) As Boolean

        ' declare variable
        Dim blnResult As Boolean

        If strInput = "" Then

            MessageBox.Show("Please enter a vendor name.")

        Else

            blnResult = True

        End If

        Return blnResult

    End Function


    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click

        OpenFormKillParent(Me, frmInventory)

    End Sub


End Class