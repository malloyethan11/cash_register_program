Imports System.IO
Imports System.Data.SqlClient

Public Class frmItemEditor

    ' This public variable is set by the item lookup form when it opens this form
    Public intCurrentlyEditingItemPrimaryKey As Integer
    Public blnChangedData As Boolean = False

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
        LoadItems()

    End Sub


    Private Sub LoadItems()
        Dim strSelect As String = ""
        Dim strName As String = ""
        Dim cmdSelect As OleDb.OleDbCommand ' this will be used for our Select statement
        Dim drSourceTable As OleDb.OleDbDataReader ' this will be where our data is retrieved to
        Dim dt As DataTable = New DataTable ' this is the table we will load from our reader
        Dim intVendor As Integer
        Dim intCategory As Integer
        Dim imgItemImage As Byte()

        Try



            ' open the database
            If OpenDatabaseConnectionSQLServer() = False Then

                ' No, warn the user ...
                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                    "The application will now close.",
                                    Me.Text + " Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)

                ' and close the form/application
                Me.Close()

            End If

            ' Build the select statement using PK from name selected
            strSelect = "SELECT strSKU, strItemName, strItemDesc, intCategoryID, intVendorID, decItemPrice, intInventoryAmt, intSafetyStockAmt, strUPC, imgItemImage FROM TItems Where intItemID = " & intCurrentlyEditingItemPrimaryKey

            ' Retrieve all the records 
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            ' load the data table from the reader
            dt.Load(drSourceTable)


            ' populate the text boxes with the data
            txtSKU.Text = dt.Rows(0).Item(0).ToString
            txtName.Text = dt.Rows(0).Item(1).ToString
            txtDescription.Text = dt.Rows(0).Item(2).ToString
            intCategory = CInt(dt.Rows(0).Item(3))
            cboCategory.SelectedValue = intCategory
            intVendor = CInt(dt.Rows(0).Item(4))
            cboVendor.SelectedValue = intVendor
            txtPrice.Text = dt.Rows(0).Item(5).ToString
            txtInventory.Text = dt.Rows(0).Item(6).ToString
            txtSafetytock.Text = dt.Rows(0).Item(7).ToString
            txtUPC.Text = dt.Rows(0).Item(8).ToString
            imgItemImage = dt.Rows(0).Item(9)

            ' Retrieve the image from the database and convert it to the proper format to display in the picturebox
            Dim ms As New MemoryStream(imgItemImage)
            picItemImage.Image = Image.FromStream(ms)
            picItemImage.SizeMode = PictureBoxSizeMode.Zoom

            ' close the database connection
            CloseDatabaseConnection()


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
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
        Me.Close()

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
        If MyUser.CanEditItems = True Then
            If Validation() = True Then
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
        Else
            MessageBox.Show("You do not have permission to update items!", "Error")
        End If

    End Sub

    Private Sub UpdateItem(ByVal SKU As String, ByVal ItemName As String, ByVal ItemDesc As String, ByVal ItemPrice As Decimal, ByVal InventoryAmt As Integer, ByVal SafetyStockAmt As Integer,
                        ByVal UPC As String)

        ' create command object
        Dim Connection As New SqlConnection("Server=itd2.cincinnatistate.edu;" &
                                                      "Database=CPDM-GroupB;" &
                                                      "User ID=" & strConnectionUsername & ";" &
                                                      "Password=" & strConnectionPassword & ";")

        'Dim strSelect As String = "Update TItems Set strSKU = '" & SKU & "', " & "strItemName = '" & ItemName &
        '            "', " & "strItemDesc = '" & ItemDesc & "', " & "intCategoryID = '" & cboCategory.SelectedValue.ToString & "'," & "intVendorID = '" & cboVendor.SelectedValue.ToString & "'," &
        '             "decItemPrice = '" & ItemPrice & "', " & "intInventoryAmt = '" & InventoryAmt & "', " & "intSafetyStockAmt = '" & SafetyStockAmt & "', 
        '            " & "strUPC = '" & UPC & "', " & "imgitemImage = @imgItemImage WHERE intItemID = " & intCurrentlyEditingVendorPrimaryKey

        ' Update for handling SQL injection attacks
        Dim strSelect As String = "Update TItems Set strSKU = @strSKU, " & "strItemName = @strItemName" &
                    ", " & "strItemDesc = @strItemDesc, " & "intCategoryID = '" & cboCategory.SelectedValue.ToString & "'," & "intVendorID = '" & cboVendor.SelectedValue.ToString & "'," &
                     "decItemPrice = @decItemPrice, " & "intInventoryAmt = @intInventoryAmt, " & "intSafetyStockAmt = @intSafetyStockAmt," &
                    "strUPC = @strUPC, " & "imgitemImage = @imgItemImage WHERE intItemID = " & intCurrentlyEditingItemPrimaryKey

        Dim cmdUpdateItem As New SqlCommand(strSelect, Connection)
        Dim ms As MemoryStream = New MemoryStream()

        ' Save the image to a byte array
        picItemImage.Image.Save(ms, picItemImage.Image.RawFormat)

        cmdUpdateItem.Connection = Connection

        ' Testing purposes to make sure the command is correct
        'MessageBox.Show(strSelect)


        Try

            cmdUpdateItem.Parameters.AddWithValue("@strSKU", SKU)
            cmdUpdateItem.Parameters.AddWithValue("@strItemName", ItemName)
            cmdUpdateItem.Parameters.AddWithValue("@strItemDesc", ItemDesc)
            cmdUpdateItem.Parameters.AddWithValue("@decItemPrice", ItemPrice)
            cmdUpdateItem.Parameters.AddWithValue("@intInventoryAmt", InventoryAmt)
            cmdUpdateItem.Parameters.AddWithValue("@intSafetyStockAmt", SafetyStockAmt)
            cmdUpdateItem.Parameters.AddWithValue("@strUPC", UPC)
            cmdUpdateItem.Parameters.AddWithValue("@imgItemImage", ms.ToArray())

            Connection.Open()

            ' have to let the user know what happened 
            If cmdUpdateItem.ExecuteNonQuery() = 1 Then
                MessageBox.Show("Update successful. Item " & ItemName & " has been updated.")

                ' Mark flag to indicate reload on return to item lookup page
                blnChangedData = True

            Else
                MessageBox.Show("Update failed.")

            End If
        Catch excError As SqlException

            ' Handle SQL errors
            MessageBox.Show(excError.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch ex As Exception

            ' Handle general errors
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Close()

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
                UPC = txtUPC.Text 'set the UPC
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

    Private Function VerifyInventory(ByRef InventoryAmt As Integer) As Boolean
        If IsNumeric(txtInventory.Text) Then
            If CInt(txtInventory.Text) > 0 Then 'convert to int and check for the range
                InventoryAmt = CInt(txtInventory.Text) 'convert it to an int and set the inventory amount
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

        ' Check if the image box is empty
        If Not picItemImage.Image Is Nothing Then
            Return True
        Else
            MessageBox.Show("Please add an image.") 'pop a message box if an error
            Return False
        End If


    End Function

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click


        Dim strDelete As String = ""
        Dim strSelect As String = String.Empty
        Dim strName As String = ""
        Dim intRowsAffected As Integer
        Dim cmdDelete As OleDb.OleDbCommand ' this will be used for our Delete statement
        Dim dt As DataTable = New DataTable ' this is the table we will load from our reader
        Dim result As DialogResult  ' this is the result of which button the user selects

        ' Test permission
        If MyUser.CanDeleteItems = True Then
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
                result = MessageBox.Show("Are you sure you want to Delete Item: Item Name-" & txtName.Text & "?", "Confirm Deletion", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)

                ' this will figure out which button was selected. Cancel and No does nothing, Yes will allow deletion
                Select Case result
                    Case DialogResult.Cancel
                        MessageBox.Show("Action Canceled")
                    Case DialogResult.No
                        MessageBox.Show("Action Canceled")
                    Case DialogResult.Yes


                        ' Build the delete statement using PK from name selected
                        ' must delete any child records first
                        strDelete = "Delete FROM TTransactionItems Where intItemID = " & intCurrentlyEditingItemPrimaryKey

                        ' Delete the record(s) 
                        cmdDelete = New OleDb.OleDbCommand(strDelete, m_conAdministrator)
                        intRowsAffected = cmdDelete.ExecuteNonQuery()

                        ' now we can delete the parent record
                        strDelete = "Delete FROM TItems Where intItemID = " & intCurrentlyEditingItemPrimaryKey


                        ' Delete the record(s) 
                        cmdDelete = New OleDb.OleDbCommand(strDelete, m_conAdministrator)
                        intRowsAffected = cmdDelete.ExecuteNonQuery()

                        ' Did it work?
                        If intRowsAffected > 0 Then

                            ' Yes, success
                            MessageBox.Show("Delete successful")

                            ' Mark flag to indicate reload on return to item lookup page
                            blnChangedData = True

                        End If

                End Select


                ' close the database connection
                CloseDatabaseConnection()

                Dim frmNewItemLookup As New frmItemLookup

                Me.Close()

            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        Else
            MessageBox.Show("You do not have permission to delete items!", "Error")
        End If

    End Sub

    Private Sub StepAction_Tick(sender As Object, e As EventArgs) Handles StepAction.Tick

        ButtonColor(MousePosition, btnChangeImage, Me, btmSkinnyButtonGray, btmSkinnyButton, 0, 0)
        ButtonColor(MousePosition, btnExit, Me, btmButtonLittleLongGray, btmButtonLittleLong)
        ButtonColor(MousePosition, btnDelete, Me, btmButtonShortGray, btmButtonShort)
        ButtonColor(MousePosition, btnUpdate, Me, btmButtonDefaultGray, btmButtonDefault)

    End Sub
End Class