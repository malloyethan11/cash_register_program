Imports System.IO
Imports System.Data.SqlClient
Public Class frmAddItem
    Private Sub frmAddItem_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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
            cboVendors.ValueMember = "intVendorID"
            cboVendors.DisplayMember = "strVendorName"
            cboVendors.DataSource = dt

            ' Select the first item in the list by default
            If cboVendors.Items.Count > 0 Then cboVendors.SelectedIndex = 0

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

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click

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

                                    ' pass inputs, now validated to sub AddItem to enter in DB
                                    AddItem(strSKU, strItemName, strItemDesc, decItemPrice, intInventoryAmt, intSafetyStockAmt, strUPC)

                                    ' Clear all boxes
                                    txtSKU.ResetText()
                                    txtName.ResetText()
                                    txtDescription.ResetText()
                                    txtPrice.ResetText()
                                    txtInventory.ResetText()
                                    txtSafetytock.ResetText()
                                    txtUPC.ResetText()
                                    cboCategory.SelectedIndex = 0
                                    cboVendors.SelectedIndex = 0
                                    picItemImage.Image = Nothing
                                End If
                            End If
                        End If
                    End If
                End If
            End If
        End If

    End Sub

    Private Sub AddItem(ByVal SKU As String, ByVal ItemName As String, ByVal ItemDesc As String, ByVal ItemPrice As Decimal, ByVal InventoryAmt As Integer, ByVal SafetyStockAmt As Integer,
                        ByVal UPC As String)

        ' create command object
        Dim Connection As New SqlConnection("Server=itd2.cincinnatistate.edu;" &
                                                      "Database=CPDM-GroupB;" &
                                                      "User ID=" & strConnectionUsername & ";" &
                                                      "Password=" & strConnectionPassword & ";")
        Dim cmdAddItem As New SqlCommand
        Dim ms As MemoryStream = New MemoryStream()

        picItemImage.Image.Save(ms, picItemImage.Image.RawFormat)

        cmdAddItem.Connection = Connection
        cmdAddItem.CommandText = "uspAddItem"
        cmdAddItem.CommandType = CommandType.StoredProcedure


        Try
            cmdAddItem.Parameters.AddWithValue("@strSKU", SKU)
            cmdAddItem.Parameters.AddWithValue("@strItemName", ItemName)
            cmdAddItem.Parameters.AddWithValue("@strItemDesc", ItemDesc)
            cmdAddItem.Parameters.AddWithValue("@intCategoryID", cboCategory.SelectedValue.ToString)
            cmdAddItem.Parameters.AddWithValue("@intVendorID", cboVendors.SelectedValue.ToString)
            cmdAddItem.Parameters.AddWithValue("@decItemPrice", ItemPrice)
            cmdAddItem.Parameters.AddWithValue("@intInventoryAmt", InventoryAmt)
            cmdAddItem.Parameters.AddWithValue("@intSafetyStockAmt", SafetyStockAmt)
            cmdAddItem.Parameters.AddWithValue("@strUPC", UPC)
            cmdAddItem.Parameters.AddWithValue("@imgItemImage", ms.ToArray())

            Connection.Open()

            ' have to let the user know what happened 
            If cmdAddItem.ExecuteNonQuery() = 1 Then
                MessageBox.Show("Insert successful. Item " & ItemName & " has been added.")

            Else
                MessageBox.Show("Insert failed")

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Close()
        End Try


    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click

        OpenFormKillParent(Me, frmInventory)

    End Sub

    Private Sub btnAddImage_Click(sender As Object, e As EventArgs) Handles btnAddImage.Click

        ' Declare a new variable to open a file
        Dim ofd As New OpenFileDialog

        ' Selectable image types
        ofd.Filter = "Choose Image(*.jpg;*png;*gif)|*.jpg;*.png;*.gif"

        ' If true set the image as the user's image and fill in the picture box
        If ofd.ShowDialog = DialogResult.OK Then
            picItemImage.Image = Image.FromFile(ofd.FileName)
            picItemImage.SizeMode = PictureBoxSizeMode.Zoom
        End If

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

    Private Function VerifySKU(ByRef SKU As String) As Boolean

        Dim intNumChars As Integer

        intNumChars = txtSKU.Text.Length

        If (8 <= intNumChars <= 12) Then
            SKU = txtSKU.Text 'set the SKU
        Else
            MessageBox.Show("Please enter an 8 to 12 character string for the SKU.") 'pop a message box if an error
            Return False
        End If
        Return True

    End Function

    Private Function VerifyInventory(ByRef InventoryAmt As Integer) As Boolean
        If IsNumeric(txtInventory.Text) Then
            If CInt(txtInventory.Text) > 0 Then 'check the range
                InventoryAmt = CInt(txtInventory.Text) 'convert it to an int and set the inventory
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
            If CInt(txtSafetytock.Text) > 0 Then 'check the range
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