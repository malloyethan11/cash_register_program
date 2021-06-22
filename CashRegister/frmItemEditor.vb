Imports System.IO
Imports System.Data.SqlClient

Public Class frmItemEditor

    ' This public variable is set by the vendor lookup form when it opens this form
    Public intCurrentlyEditingVendorPrimaryKey As Integer

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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

        ' Load the Vendor and Category comboboxes
        LoadVendors()
        LoadCategories()

    End Sub


    Private Sub LoadVendors()

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
            strSelect = "SELECT intVendorID, strVendorName FROM TVendors"

            ' Retrieve all the records 
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            ' load table from data reader
            dt.Load(drSourceTable)

            ' Add the item to the combo box. We need the user ID associated with the name so 
            ' when we click on the name we can then use the ID to pull the rest of the user data.
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

        Catch excError As Exception

            ' Log and display error message
            MessageBox.Show(excError.Message)

        End Try

    End Sub

    Private Sub LoadCategories()

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
            strSelect = "SELECT intCategoryID, strCategory FROM TCategories"

            ' Retrieve all the records 
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            ' load table from data reader
            dt.Load(drSourceTable)

            ' Add the item to the combo box. 
            cboCategory.ValueMember = "intCategoryID"
            cboCategory.DisplayMember = "strCategory"
            cboCategory.DataSource = dt

            ' Select the first item in the list by default
            If cboCategory.Items.Count > 0 Then cboCategory.SelectedIndex = 0

            ' Clean up
            drSourceTable.Close()

            ' close the database connection
            CloseDatabaseConnection()

        Catch excError As Exception

            ' Log and display error message
            MessageBox.Show(excError.Message)

        End Try

    End Sub

    Private Sub btnChangeImage_Click(sender As Object, e As EventArgs) Handles btnChangeImage.Click

        ' Declare a new variable to open a file
        Dim opf As New OpenFileDialog

        ' Selectable image types
        opf.Filter = "Choose Image(*.jpg;*png;*gif)|*.jpg;*.png;*.gif"

        ' If true set the image as the user's image and fill in the picture box
        If opf.ShowDialog = DialogResult.OK Then
            picItemImage.Image = Image.FromFile(opf.FileName)
            picItemImage.SizeMode = PictureBoxSizeMode.Zoom
        End If

    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click

        Dim frmNewLookup As New frmItemLookup
        frmNewLookup.Type = "Standalone"
        OpenFormKillParent(Me, frmNewLookup)

    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click

        ' variables for new item data
        Dim strSKU As String = ""
        Dim strItemName As String = ""
        Dim strItemDesc As String = ""
        Dim decItemPrice As Decimal = 0
        Dim intInventoryAmt As Integer = 0
        Dim intSafetyStockAmt As Integer = 0
        Dim strUPC As String = ""


        ' validate data is entered
        If Validation() = True Then
            If VerifySKU(strSKU) = True Then
                If VerifyPrice(decItemPrice) = True Then
                    If VerifyInventory(intInventoryAmt) = True Then
                        If VerifySafetyStock(intSafetyStockAmt) = True Then
                            If VerifyUPC(strUPC) = True Then
                                If VerifyImage() = True Then


                                    strSKU = txtSKU.Text
                                    strItemName = txtName.Text
                                    strItemDesc = txtDescription.Text
                                    decItemPrice = txtPrice.Text
                                    intInventoryAmt = txtInventory.Text
                                    intSafetyStockAmt = txtSafetytock.Text
                                    strUPC = txtUPC.Text

                                    ' pass inputs, now validated to sub UpdateItem to enter in DB
                                    UpdateItem(strSKU, strItemName, strItemDesc, decItemPrice, intInventoryAmt, intSafetyStockAmt, strUPC)
                                End If
                            End If
                        End If
                    End If
                End If
            End If
        End If

    End Sub

    Private Sub UpdateItem(ByVal SKU As String, ByVal ItemName As String, ByVal ItemDesc As String, ByVal ItemPrice As Decimal, ByVal InventoryAmt As Integer, ByVal SafetyStockAmt As Integer,
                        ByVal UPC As String)

        ' create command object
        Dim Connection As New SqlConnection("Server=itd2.cincinnatistate.edu;" &
                                                      "Database=CPDM-GroupB;" &
                                                      "User ID=" & strConnectionUsername & ";" &
                                                      "Password=" & strConnectionPassword & ";")

        Dim cmdUpdateItem As New SqlCommand("UPDATE TItems SET strSKU = @strSKU, strItemName = @strItemName, strItemDesc = @strItemDesc, intCategoryID = @intCategoryID, intVendorID = @intVendorID,
                                            decItemPrice = @decItemPrice, intInventoryAmt = @intInventoryAmt, intSafetyStockAmt = @intSafetyStockAmt, strUPC = @strUPC, imgItemImage = @imgItemImage
                                            WHERE intItemID = " & intCurrentlyEditingVendorPrimaryKey)
        Dim ms As MemoryStream = New MemoryStream()

        picItemImage.Image.Save(ms, picItemImage.Image.RawFormat)

        cmdUpdateItem.Connection = Connection


        Try
            cmdUpdateItem.Parameters.AddWithValue("@strSKU", SKU)
            cmdUpdateItem.Parameters.AddWithValue("@strItemName", ItemName)
            cmdUpdateItem.Parameters.AddWithValue("@strItemDesc", ItemDesc)
            cmdUpdateItem.Parameters.AddWithValue("@intCategoryID", cboCategory.SelectedValue.ToString)
            cmdUpdateItem.Parameters.AddWithValue("@intVendorID", cboVendor.SelectedValue.ToString)
            cmdUpdateItem.Parameters.AddWithValue("@decItemPrice", ItemPrice)
            cmdUpdateItem.Parameters.AddWithValue("@intInventoryAmt", InventoryAmt)
            cmdUpdateItem.Parameters.AddWithValue("@intSafetyStockAmt", SafetyStockAmt)
            cmdUpdateItem.Parameters.AddWithValue("@strUPC", UPC)
            cmdUpdateItem.Parameters.AddWithValue("@imgItemImage", ms.ToArray())

            Connection.Open()

            ' have to let the user know what happened 
            If cmdUpdateItem.ExecuteNonQuery() = 1 Then
                MessageBox.Show("Update successful. Item " & ItemName & " has been updated.")

            Else
                MessageBox.Show("Update failed.")

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Close()
        End Try


    End Sub


    Private Sub txtSKU_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtSKU.TextChanged

        'Dim strSelect As String = ""
        'Dim strName As String = ""
        'Dim cmdSelect As OleDb.OleDbCommand ' this will be used for our Select statement
        'Dim drSourceTable As OleDb.OleDbDataReader ' this will be where our data is retrieved to
        'Dim dt As DataTable = New DataTable ' this is the table we will load from our reader
        'Dim intShirtSize As Integer
        'Dim intGender As Integer

        'Try



        '    ' open the database
        '    If OpenDatabaseConnectionSQLServer() = False Then

        '        ' No, warn the user ...
        '        MessageBox.Show(Me, "Database connection error." & vbNewLine &
        '                            "The application will now close.",
        '                            Me.Text + " Error",
        '                            MessageBoxButtons.OK, MessageBoxIcon.Error)

        '        ' and close the form/application
        '        Me.Close()

        '    End If

        '    ' Build the select statement using PK from name selected
        '    strSelect = "SELECT strFirstName, strLastName, strStreetAddress, strCity, strState, strZip, strPhoneNumber, strEmail, intShirtSizeID, intGenderID FROM TGolfers Where intGolferID = " & cboNames.SelectedValue.ToString

        '    ' Retrieve all the records 
        '    cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
        '    drSourceTable = cmdSelect.ExecuteReader

        '    ' load the data table from the reader
        '    dt.Load(drSourceTable)

        '    ' populate the text boxes with the data
        '    txtFirstName.Text = dt.Rows(0).Item(0).ToString
        '    txtLastName.Text = dt.Rows(0).Item(1).ToString
        '    txtAddress.Text = dt.Rows(0).Item(2).ToString
        '    txtCity.Text = dt.Rows(0).Item(3).ToString
        '    txtState.Text = dt.Rows(0).Item(4).ToString
        '    txtZip.Text = dt.Rows(0).Item(5).ToString
        '    txtPhoneNumber.Text = dt.Rows(0).Item(6).ToString
        '    txtEmail.Text = dt.Rows(0).Item(7).ToString

        '    intShirtSize = CInt(dt.Rows(0).Item(8)) 'put shirt size ID into variable
        '    cboShirtSize.SelectedValue = intShirtSize 'set selected value of shirt size combo box to correct size

        '    intGender = CInt(dt.Rows(0).Item(9)) 'put gender ID into variable
        '    cboGender.SelectedValue = intGender 'set selected value of gender combo box to correct gender

        '    ' close the database connection
        '    CloseDatabaseConnection()


        'Catch ex As Exception
        '    MessageBox.Show(ex.Message)
        'End Try
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
            If CDec(txtPrice.Text) > 0 Then 'convert to decimal and check for the range
                ItemPrice = CDec(txtPrice.Text) 'convert it to a decimal and set price
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

    Private Function VerifyUPC(ByRef UPC As String) As Boolean

        Dim intNumChars As Integer

        intNumChars = txtUPC.Text.Length

        If (intNumChars = 12) Then
            If IsNumeric(txtUPC.Text) Then
                UPC = txtUPC.Text 'convert it to a decimal and set price
            Else
                MessageBox.Show("Please enter numbers only for the UPC.") 'pop a message box if an error
                Return False
            End If
        Else
            MessageBox.Show("Please enter a 12 digit number for the UPC.") 'pop a message box if an error
            Return False
        End If
        Return True

    End Function

    Private Function VerifySKU(ByRef SKU As String) As Boolean

        Dim intNumChars As Integer

        intNumChars = txtSKU.Text.Length

        If (8 <= intNumChars <= 12) Then
            If IsNumeric(txtSKU.Text) Then
                SKU = txtSKU.Text 'convert it to a decimal and set price
            Else
                MessageBox.Show("Please enter numbers only for the SKU.") 'pop a message box if an error
                Return False
            End If
        Else
            MessageBox.Show("Please enter a number between 8 and 12 characters for the SKU.") 'pop a message box if an error
            Return False
        End If
        Return True

    End Function

    Private Function VerifyInventory(ByRef InventoryAmt As Integer) As Boolean
        If IsNumeric(txtInventory.Text) Then
            If CInt(txtInventory.Text) > 0 Then 'convert to decimal and check for the range
                InventoryAmt = CInt(txtInventory.Text) 'convert it to a decimal and set price
            Else
                MessageBox.Show("Please enter a number greater than 0 for the inventory.") 'pop a message box if an error
                Return False
            End If
        Else
            MessageBox.Show("Please enter numbers only for the inventory.") 'pop a message box if an error
            Return False
        End If
        Return True

    End Function

    Private Function VerifySafetyStock(ByRef SafetyStock As Integer) As Boolean
        If IsNumeric(txtSafetytock.Text) Then
            If CInt(txtSafetytock.Text) > 0 Then 'convert to int and check for the range
                SafetyStock = CInt(txtSafetytock.Text) 'convert it to an int and set safety stock
            Else
                MessageBox.Show("Please enter a number greater than 0 for the safety stock.") 'pop a message box if an error
                Return False
            End If
        Else
            MessageBox.Show("Please enter numbers only for the safety stock.") 'pop a message box if an error
            Return False
        End If
        Return True

    End Function

    Private Function VerifyImage() As Boolean

        If Not picItemImage.Image Is Nothing Then
            Return True
        Else
            MessageBox.Show("Please add an image.") 'pop a message box if an error
            Return False
        End If


    End Function

End Class