Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.IO

Public Class frmCheckout
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
                myItem.strItemName = result.GetString(2)
                myItem.decPrice = result.GetDecimal(6) ' Need to Call one form frmLookup

                lstItems.Items.Add(myItem.strItemName + " X " + myItem.intQty.ToString)
                Items.Add(myItem)
                TextBox1.Text = (myItem.decPrice * myItem.intQty).ToString
            Else
                MessageBox.Show("No Item found in database")
            End If
        Catch ex As Exception
            MessageBox.Show("Database Error:" + ex.Message)
        End Try


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

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

        If IsNumeric(TextBox1.Text) Then
            TextBox2.Text = Convert.ToDecimal(TextBox1.Text) * 0.575
        Else
            TextBox2.Text = "NAN"
        End If
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click

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
            cmdAddItem.Parameters.AddWithValue("@intTransactionTypeID", 1)
            cmdAddItem.Parameters.AddWithValue("@intPaymentTypeID", ComboBox1.SelectedIndex)

            cmdAddItem.Parameters.AddWithValue("@strFirstName", TextBox3.Text)
            cmdAddItem.Parameters.AddWithValue("@strLastName", TextBox4.Text)
            cmdAddItem.Parameters.AddWithValue("@strAddress", TextBox9.Text)
            cmdAddItem.Parameters.AddWithValue("@intStateID", cboState.SelectedIndex)
            cmdAddItem.Parameters.AddWithValue("@strZip", TextBox8.Text)
            cmdAddItem.Parameters.AddWithValue("@strPhoneNumber", txtPhoneNumber.Text)
            cmdAddItem.Parameters.AddWithValue("@strEmail", txtEmail.Text)
            cmdAddItem.Parameters.AddWithValue("@strCreditCard", TextBox5.Text)
            cmdAddItem.Parameters.AddWithValue("@strExpirationDate", dtpExpirationDate)
            cmdAddItem.Parameters.AddWithValue("@strSecurityCode", TextBox6.Text)
            cmdAddItem.Parameters.AddWithValue("@decTotalPrice", Convert.ToDecimal(TextBox1.Text))
            cmdAddItem.Parameters.AddWithValue("@decSalesTax", Convert.ToDecimal(TextBox2.Text))
            cmdAddItem.Parameters.AddWithValue("@strDescription", "?")
            cmdAddItem.Parameters.AddWithValue("@strUsername", "")
            cmdAddItem.Parameters.AddWithValue("@dtTransactionDate", DateTime.Today.ToString)

            Connection.Open()
            Dim result As Integer = 0
            For Each item In Items
                result += addItems(item)
            Next
            ' have to let the user know what happened 
            If cmdAddItem.ExecuteNonQuery() = 1 Then
                MessageBox.Show("Insert successful. Transaction has been added.")

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

    Private Function addItems(item As ItemData) As Integer

        ' create command object
        Dim Connection As New SqlConnection("Server=itd2.cincinnatistate.edu;" &
                                                      "Database=CPDM-GroupB;" &
                                                      "User ID=" & strConnectionUsername & ";" &
                                                      "Password=" & strConnectionPassword & ";")
        Dim cmdAddItem As New SqlCommand

        cmdAddItem.Connection = Connection
        cmdAddItem.CommandText = "uspCheckoutItems"
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
        Dim delIt = Items.ElementAt(lstItems.SelectedIndex)
        TextBox1.Text = Convert.ToDecimal(TextBox1.Text) - (delIt.decPrice * delIt.intQty)
        Items.RemoveAt(lstItems.SelectedIndex)
        lstItems.Items.RemoveAt(lstItems.SelectedIndex)
        lstItems.Refresh()
    End Sub
End Class
