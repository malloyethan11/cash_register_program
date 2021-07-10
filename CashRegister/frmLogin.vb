Public Class frmLogin

    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' Prompt for database connection credentials
        strConnectionUsername = InputBox("Please provide database login username: ")
        strConnectionPassword = InputBox("Please provide database login password: ")

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

        SetImages()

    End Sub

    Private Sub SetImages()

        ' Change color - Cite: https://www.daniweb.com/programming/software-development/threads/486625/convert-color-image-to-grayscale
        Dim x As Integer = btmButtonDefault.Width
        Dim y As Integer = btmButtonDefault.Height
        btmButtonDefaultGray = New Bitmap(btmButtonDefault.Width, btmButtonDefault.Height)

        For x = 0 To (btmButtonDefault.Width) - 1
            For y = 0 To (btmButtonDefault.Height) - 1
                Dim c As Color = btmButtonDefault.GetPixel(x, y)
                Dim r As Integer = c.R
                Dim g As Integer = c.G
                Dim b As Integer = c.B
                Dim a As Integer = c.A
                Dim d As Integer = (r + g + b) \ 3
                btmButtonDefaultGray.SetPixel(x, y, Color.FromArgb(a, d, d, d))
            Next
        Next

        x = btmButtonLittleLong.Width
        y = btmButtonLittleLong.Height
        btmButtonLittleLongGray = New Bitmap(btmButtonLittleLong.Width, btmButtonLittleLong.Height)

        For x = 0 To (btmButtonLittleLong.Width) - 1
            For y = 0 To (btmButtonLittleLong.Height) - 1
                Dim c As Color = btmButtonLittleLong.GetPixel(x, y)
                Dim r As Integer = c.R
                Dim g As Integer = c.G
                Dim b As Integer = c.B
                Dim a As Integer = c.A
                Dim d As Integer = (r + g + b) \ 3
                btmButtonLittleLongGray.SetPixel(x, y, Color.FromArgb(a, d, d, d))
            Next
        Next

        x = btmButtonShort.Width
        y = btmButtonShort.Height
        btmButtonShortGray = New Bitmap(btmButtonShort.Width, btmButtonShort.Height)

        For x = 0 To (btmButtonShort.Width) - 1
            For y = 0 To (btmButtonShort.Height) - 1
                Dim c As Color = btmButtonShort.GetPixel(x, y)
                Dim r As Integer = c.R
                Dim g As Integer = c.G
                Dim b As Integer = c.B
                Dim a As Integer = c.A
                Dim d As Integer = (r + g + b) \ 3
                btmButtonShortGray.SetPixel(x, y, Color.FromArgb(a, d, d, d))
            Next
        Next

        x = btmSkinnyButton.Width
        y = btmSkinnyButton.Height
        btmSkinnyButtonGray = New Bitmap(btmSkinnyButton.Width, btmSkinnyButton.Height)

        For x = 0 To (btmSkinnyButton.Width) - 1
            For y = 0 To (btmSkinnyButton.Height) - 1
                Dim c As Color = btmSkinnyButton.GetPixel(x, y)
                Dim r As Integer = c.R
                Dim g As Integer = c.G
                Dim b As Integer = c.B
                Dim a As Integer = c.A
                Dim d As Integer = (r + g + b) \ 3
                btmSkinnyButtonGray.SetPixel(x, y, Color.FromArgb(a, d, d, d))
            Next
        Next

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