Public Class frmLogin

    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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

        txtPassword.PasswordChar = "*"
        txtPassword.MaxLength = 50

        txtUsername.MaxLength = 50

    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click

        If (ValidateUser(txtUsername.Text, txtPassword.Text)) Then

            OpenFormKillParent(Me, frmMain)

        End If

    End Sub

    ' Code in this procedure adapted from the GolfAThon program in Programming 2
    Private Function ValidateUser(ByVal strUsername As String, ByVal strPassword As String) As Boolean

        ' Validated
        Dim blnValid As Boolean = False

        Try

            ' Init select statement string
            Dim strSelect As String = ""
            ' Init select statement Db command
            Dim cmdSelect As OleDb.OleDbCommand
            ' Init data reader
            Dim drSourceTable As OleDb.OleDbDataReader
            ' Init data table
            Dim dt As DataTable = New DataTable
            ' Init results set array
            Dim drSet() As System.Data.DataRow

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
            strSelect = "SELECT * FROM TUsers"

            ' Retrieve all the records 
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            ' load table from data reader
            dt.Load(drSourceTable)

            ' Double all signle quotes
            strUsername = strUsername.Replace("'", "''")

            ' Populate the array based on search
            drSet = dt.Select("strUsername='" & strUsername & "'")

            ' Validate and create a user
            If (drSet.Length > 0) Then

                If (strPassword = drSet(0)("strPassword").ToString) Then
                    MyUser.Username = drSet(0)("strUsername").ToString
                    MyUser.CanCheckout = drSet(0)("blnCheckout").ToString
                    MyUser.CanReturn = drSet(0)("blnReturns").ToString
                    MyUser.CanAddItems = drSet(0)("blnAddItems").ToString
                    MyUser.CanEditItems = drSet(0)("blnEditItems").ToString
                    MyUser.CanDeleteItems = drSet(0)("blnDeleteItems").ToString
                    MyUser.CanAdjustPricing = drSet(0)("blnMassPricing").ToString
                    MyUser.CanAddVendors = drSet(0)("blnAddVendors").ToString
                    MyUser.CanEditVendors = drSet(0)("blnEditVendors").ToString
                    MyUser.CanDeleteVendors = drSet(0)("blnDeleteVendors").ToString
                    MyUser.CanPayInPayOut = drSet(0)("blnPayInPayOut").ToString
                    blnValid = True
                Else
                    MessageBox.Show("Incorrect username or password!", "Login Validation Failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
            Else
                MessageBox.Show("Incorrect username or password!", "Login Validation Failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If

            ' Clean up
            drSourceTable.Close()

            ' close the database connection
            CloseDatabaseConnection()

        Catch excError As Exception

            ' Log and display error message
            MessageBox.Show("Failed to attempt login to the system.", "Error")

        End Try

        Return blnValid

    End Function

    Private Sub StepAction_Tick(sender As Object, e As EventArgs) Handles StepAction.Tick

        ButtonColor(MousePosition, btnLogin, Me, btmButtonDefaultGray, btmButtonDefault)

    End Sub
End Class