Imports System.Data.SqlClient
Imports System.IO

Public Class frmItemLookup

    Public intPrimaryKeyReturnValue As Integer = -1
    Public intQuantityToPurchase As Integer = -1
    Public Type As String = "Dialog"
    Dim intStartIndex As Integer = 0
    Dim drSet As System.Data.DataRowCollection
    Dim bytList As Byte()
    Dim intPages As Integer = 0
    Dim intTotalItems As Integer = 0

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.CenterToScreen()

        txtSearch.ForeColor = Color.DarkGray

        For Each Control In Controls
            If Control.GetType() = GetType(Button) Then
                Control.FlatStyle = FlatStyle.Flat
                Control.ForeColor = BackColor
                Control.FlatAppearance.BorderColor = BackColor
                Control.FlatAppearance.MouseOverBackColor = BackColor
                Control.FlatAppearance.MouseDownBackColor = BackColor
            End If
        Next

        ' Clear labels
        lblItem1.Text = ""
        lblItem2.Text = ""
        lblItem3.Text = ""
        lblItem4.Text = ""
        lblItem5.Text = ""
        lblItem6.Text = ""
        lblItem7.Text = ""
        lblItem8.Text = ""
        lblItem9.Text = ""
        lblItem10.Text = ""
        lblPrice1.Text = ""
        lblPrice2.Text = ""
        lblPrice3.Text = ""
        lblPrice4.Text = ""
        lblPrice5.Text = ""
        lblPrice6.Text = ""
        lblPrice7.Text = ""
        lblPrice8.Text = ""
        lblPrice9.Text = ""
        lblPrice10.Text = ""

        ' Make qty visible if dialog
        If (Type = "Dialog") Then
            lblQTY.Visible = True
            txtQTY.Visible = True
        End If

    End Sub

    Private Sub TextBox1_GotFocus(sender As Object, e As EventArgs) Handles txtSearch.Enter

        '  If the text box is selected
        txtSearch.ForeColor = Color.Black
        ' Remove the search text
        If (txtSearch.Text = "Type here to search...") Then
            txtSearch.Text = ""
        End If

    End Sub

    Private Sub TextBox1_LostFocus(sender As Object, e As EventArgs) Handles txtSearch.Leave

        ' If the text box is not selected 
        txtSearch.ForeColor = Color.DarkGray
        ' Add the search text
        If (String.IsNullOrEmpty(txtSearch.Text) Or String.IsNullOrWhiteSpace(txtSearch.Text)) Then
            txtSearch.Text = "Type here to search..."
        End If

    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        ' Handle close
        If (Type = "Dialog") Then
            Me.Close()
        Else
            OpenFormKillParent(Me, frmInventory)
        End If
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click

        ' If the search text is in there, remove it
        If (txtSearch.Text = "Type here to search...") Then
            txtSearch.Text = ""
        End If

        ' Load the items
        If (String.IsNullOrEmpty(cboFilter.Text) = False) Then
            LoadItems()
        End If
        txtSearch.Text = Trim(txtSearch.Text)

    End Sub

    Private Sub LoadItems()

        Cursor.Current = Cursors.WaitCursor

        Try

            ' Init select statement string
            Dim strSelect As String = ""

            'For cat or ven
            ' Init select statement Db command
            Dim cmdVenCatSelect As OleDb.OleDbCommand
            ' Init data reader
            Dim drVenCatSourceTable As OleDb.OleDbDataReader
            ' Init data table
            Dim dtVenCat As DataTable = New DataTable

            ' For item
            ' Init select statement Db command
            Dim cmdSelect As OleDb.OleDbCommand
            ' Init data reader
            Dim drSourceTable As OleDb.OleDbDataReader
            ' Init data table
            Dim dt As DataTable = New DataTable

            ' Filter string
            Dim strFilter As String = ""
            ' Cat ID
            Dim drCategorySet() As System.Data.DataRow
            ' Ven ID
            Dim drVendorSet() As System.Data.DataRow

            ' Reset number
            intPages = 0

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

            ' Get the filter
            Select Case cboFilter.Text
                Case "SKU"
                    strFilter = "strSKU"
                Case "Name"
                    strFilter = "strItemName"
                Case "Description"
                    strFilter = "strItemDesc"
                Case "Category"
                    strFilter = "intCategoryID"
                Case "Vendor"
                    strFilter = "intVendorID"
                Case "UPC"
                    strFilter = "strUPC"
            End Select

            If (strFilter = "intCategoryID") Then

                'strSelect = "SELECT intCategoryID, strCategory FROM TCategories
                'WHERE strCategory Like '%" & txtSearch.Text & "%'"
                strSelect = "SELECT intCategoryID, strCategory FROM TCategories WHERE strCategory Like '%' +" & "?" & "+ '%'"

                ' Retrieve all the records 
                cmdVenCatSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
                cmdVenCatSelect.Parameters.AddWithValue("SearchText", txtSearch.Text)
                drVenCatSourceTable = cmdVenCatSelect.ExecuteReader

                ' load table from data reader
                dtVenCat.Load(drVenCatSourceTable)

                ' Populate the array based on search
                drCategorySet = dtVenCat.Select("intCategoryID>0")

                ' init
                Dim strSelectList As String = "intCategoryID = -1"
                Dim blnFirst As Boolean = True
                Dim intCount As Integer = 0

                ' Gather
                For Each Row In drCategorySet
                    If (blnFirst = True) Then
                        strSelectList = "intCategoryID = " & drCategorySet(intCount)("intCategoryID").ToString
                        blnFirst = False
                    Else
                        strSelectList = strSelectList & " OR intCategoryID = " & drCategorySet(intCount)("intCategoryID").ToString
                    End If
                    intCount += 1
                Next

                ' Select all that apply
                strSelect = "SELECT intItemID, strItemName, imgItemImage, decItemPrice FROM TItems WHERE " & strSelectList

                ' Retrieve all the records 
                cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
                drSourceTable = cmdSelect.ExecuteReader

                ' load table from data reader
                dt.Load(drSourceTable)

                ' Populate the array based on search
                drSet = dt.Rows

                ' Clean up
                drVenCatSourceTable.Close()

            ElseIf (strFilter = "intVendorID") Then

                strSelect = "SELECT intVendorID, strVendorName FROM TVendors WHERE strVendorName Like '%'+" & "?" & "+'%'"

                ' Retrieve all the records 
                cmdVenCatSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
                cmdVenCatSelect.Parameters.AddWithValue("SearchText", txtSearch.Text)
                drVenCatSourceTable = cmdVenCatSelect.ExecuteReader

                ' load table from data reader
                dtVenCat.Load(drVenCatSourceTable)

                ' Populate the array based on search
                drVendorSet = dtVenCat.Select("intVendorID>0")

                ' init
                Dim strSelectList As String = "intVendorID = -1"
                Dim blnFirst As Boolean = True
                Dim intCount As Integer = 0

                ' Gather
                For Each Row In drVendorSet
                    If (blnFirst = True) Then
                        strSelectList = "intVendorID = " & drVendorSet(intCount)("intVendorID").ToString
                        blnFirst = False
                    Else
                        strSelectList = strSelectList & " OR intVendorID = " & drVendorSet(intCount)("intVendorID").ToString
                    End If
                    intCount += 1
                Next

                ' Select all that apply
                strSelect = "SELECT intItemID, strItemName, imgItemImage, decItemPrice FROM TItems WHERE " & strSelectList

                ' Retrieve all the records 
                cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
                drSourceTable = cmdSelect.ExecuteReader

                ' load table from data reader
                dt.Load(drSourceTable)

                ' Populate the array based on search
                drSet = dt.Rows

                ' Clean up
                drVenCatSourceTable.Close()

            Else
                strSelect = "SELECT intItemID, strItemName, imgItemImage, decItemPrice FROM TItems WHERE " & strFilter & " Like '%'+" & "?" & "+'%'"

                ' Retrieve all the records 
                cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
                cmdSelect.Parameters.AddWithValue("SearchText", txtSearch.Text)
                drSourceTable = cmdSelect.ExecuteReader

                ' load table from data reader
                dt.Load(drSourceTable)

                ' Populate the array based on search
                drSet = dt.Rows
            End If

            ' Build the select statement
            'If (txtSearch.Text <> "*") Then
            'Else
            'strSelect = "SELECT intItemID, strItemName, imgItemImage FROM TItems
            '             WHERE " & strFIlter & " LIKE '%%'"
            'End If

            ' Calc total pages
            intTotalItems = drSet.Count
            While (intTotalItems > 0)
                intPages += 1
                intTotalItems -= 10
            End While

            ' Set the page number to 1 if 0
            If (intPages = 0) Then intPages = 1

            ' Reset index
            intStartIndex = 0

            ' Display
            DisplayData()

            ' Clean up
            drSourceTable.Close()

            ' close the database connection
            CloseDatabaseConnection()

        Catch excError As Exception

            Cursor.Current = Cursors.Default

            ' Log and display error message
            MessageBox.Show(excError.Message)

        End Try

        Cursor.Current = Cursors.Default

    End Sub

    Private Sub DisplayData()

        ' Set page number text
        If (intStartIndex < 9) Then
            lblPageNumber.Text = "Page " & (intStartIndex + 1) & " of " & (intPages)
        Else
            lblPageNumber.Text = "Page " & (intStartIndex + 10) / 10 & " of " & (intPages)
        End If

        ' Image thing
        picImage1.Image = Nothing
        picImage2.Image = Nothing
        picImage3.Image = Nothing
        picImage4.Image = Nothing
        picImage5.Image = Nothing
        picImage6.Image = Nothing
        picImage7.Image = Nothing
        picImage8.Image = Nothing
        picImage9.Image = Nothing
        picImage10.Image = Nothing

        ' Populate each
        If (drSet.Count >= intStartIndex + 1) Then
            ' Get Name
            lblItem1.Text = drSet(intStartIndex)("strItemName").ToString
            lblPrice1.Text = FormatCurrency(drSet(intStartIndex)("decItemPrice").ToString, 2)
            ' Get image
            GetImage(intStartIndex, picImage1)
        Else
            lblPrice1.Text = ""
            lblItem1.Text = ""
        End If

        If (drSet.Count >= intStartIndex + 2) Then
            ' Get Name
            lblItem2.Text = drSet(intStartIndex + 1)("strItemName").ToString
            lblPrice2.Text = FormatCurrency(drSet(intStartIndex + 1)("decItemPrice").ToString, 2)
            ' Get image
            GetImage(intStartIndex + 1, picImage2)
        Else
            lblPrice2.Text = ""
            lblItem2.Text = ""
        End If

        If (drSet.Count >= intStartIndex + 3) Then
            ' Get Name
            lblItem3.Text = drSet(intStartIndex + 2)("strItemName").ToString
            lblPrice3.Text = FormatCurrency(drSet(intStartIndex + 2)("decItemPrice").ToString, 2)
            ' Get image
            GetImage(intStartIndex + 2, picImage3)
        Else
            lblPrice3.Text = ""
            lblItem3.Text = ""
        End If

        If (drSet.Count >= intStartIndex + 4) Then
            ' Get name
            lblItem4.Text = drSet(intStartIndex + 3)("strItemName").ToString
            lblPrice4.Text = FormatCurrency(drSet(intStartIndex + 3)("decItemPrice").ToString, 2)
            ' Get image
            GetImage(intStartIndex + 3, picImage4)
        Else
            lblPrice4.Text = ""
            lblItem4.Text = ""
        End If

        If (drSet.Count >= intStartIndex + 5) Then
            ' Get name
            lblItem5.Text = drSet(intStartIndex + 4)("strItemName").ToString
            lblPrice5.Text = FormatCurrency(drSet(intStartIndex + 4)("decItemPrice").ToString, 2)
            ' Get image
            GetImage(intStartIndex + 4, picImage5)
        Else
            lblPrice5.Text = ""
            lblItem5.Text = ""
        End If

        If (drSet.Count >= intStartIndex + 6) Then
            ' Get name
            lblItem6.Text = drSet(intStartIndex + 5)("strItemName").ToString
            lblPrice6.Text = FormatCurrency(drSet(intStartIndex + 5)("decItemPrice").ToString, 2)
            ' Get image
            GetImage(intStartIndex + 5, picImage6)
        Else
            lblPrice6.Text = ""
            lblItem6.Text = ""
        End If

        If (drSet.Count >= intStartIndex + 7) Then
            ' Get name
            lblItem7.Text = drSet(intStartIndex + 6)("strItemName").ToString
            lblPrice7.Text = FormatCurrency(drSet(intStartIndex + 6)("decItemPrice").ToString, 2)
            ' Get image
            GetImage(intStartIndex + 6, picImage7)
        Else
            lblPrice7.Text = ""
            lblItem7.Text = ""
        End If

        If (drSet.Count >= intStartIndex + 8) Then
            ' Get name
            lblItem8.Text = drSet(intStartIndex + 7)("strItemName").ToString
            lblPrice8.Text = FormatCurrency(drSet(intStartIndex + 7)("decItemPrice").ToString, 2)
            ' Get image
            GetImage(intStartIndex + 7, picImage8)
        Else
            lblPrice8.Text = ""
            lblItem8.Text = ""
        End If

        If (drSet.Count >= intStartIndex + 9) Then
            ' Get name
            lblItem9.Text = drSet(intStartIndex + 8)("strItemName").ToString
            lblPrice9.Text = FormatCurrency(drSet(intStartIndex + 8)("decItemPrice").ToString, 2)
            ' Get image
            GetImage(intStartIndex + 8, picImage9)
        Else
            lblPrice9.Text = ""
            lblItem9.Text = ""
        End If

        If (drSet.Count >= intStartIndex + 10) Then
            ' Get name
            lblItem10.Text = drSet(intStartIndex + 9)("strItemName").ToString
            lblPrice10.Text = FormatCurrency(drSet(intStartIndex + 9)("decItemPrice").ToString, 2)
            ' Get image
            GetImage(intStartIndex + 9, picImage10)
        Else
            lblPrice10.Text = ""
            lblItem10.Text = ""
        End If

        ' Trim
        TrimBoxes()

    End Sub

    Private Sub TrimBoxes()

        ' Trim the boxes
        TrimOneBox(lblItem1)
        TrimOneBox(lblItem2)
        TrimOneBox(lblItem3)
        TrimOneBox(lblItem4)
        TrimOneBox(lblItem5)
        TrimOneBox(lblItem6)
        TrimOneBox(lblItem7)
        TrimOneBox(lblItem8)
        TrimOneBox(lblItem9)
        TrimOneBox(lblItem10)

    End Sub

    Private Sub TrimOneBox(ByRef lblBox As Label)

        ' Trim length
        Dim intIndex As Integer = 50

        ' Truncate
        If (lblBox.Text.Length <= intIndex) And (lblBox.Text <> "") Then
            intIndex = lblBox.Text.Length - 1
        ElseIf (lblBox.Text <> "") Then
            lblBox.Text = lblBox.Text.Remove(intIndex)
            lblBox.Text += "..."
        End If

    End Sub

    Private Sub GetImage(ByVal intIndex As Integer, ByRef picImageBox As PictureBox)

        ' Get image
        Dim bytImageData(0) As Byte
        bytImageData = drSet(intIndex)("imgItemImage")
        Dim memData As System.IO.MemoryStream = New System.IO.MemoryStream(bytImageData)
        picImageBox.Image = Image.FromStream(memData)
        picImageBox.SizeMode = PictureBoxSizeMode.Zoom

    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click

        ' Go to next page
        If (drSet IsNot Nothing) Then
            If (drSet.Count > intStartIndex + 10) Then
                intStartIndex += 10
                DisplayData()
            End If
        End If

    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click

        ' Go to last page
        If (drSet IsNot Nothing) Then
            If (intStartIndex > 0) Then
                intStartIndex -= 10
                DisplayData()
            End If
        End If

    End Sub

    Private Sub OpenItem(ByVal intIndex As Integer)

        ' Open the item
        If (drSet IsNot Nothing) Then
            If (drSet.Count > intIndex) Then
                If (Type = "Dialog") Then
                    If (ValidateQTY() = True) Then
                        ' Close the form and return the primary key
                        intPrimaryKeyReturnValue = drSet(intIndex)("intItemID").ToString
                        intQuantityToPurchase = txtQTY.Text
                        Me.Close()
                    End If
                Else
                    ' Open the editor form and pass on the primary key
                    Dim frmNewEditor As New frmItemEditor
                    frmNewEditor.intCurrentlyEditingItemPrimaryKey = drSet(intIndex)("intItemID").ToString
                    OpenFormMaintainParent(Me, frmNewEditor)
                    ' If data change has occured, then load the items again
                    If (frmNewEditor.blnChangedData = True) Then
                        LoadItems()
                    End If
                End If
            End If
        End If

    End Sub

    Private Function ValidateQTY() As Boolean

        Dim blnResult As Boolean = False

        If (IsNumeric(txtQTY.Text) = True) Then
            If (CInt(txtQTY.Text) > 0) Then
                blnResult = True
                txtQTY.BackColor = Color.White
            Else
                MsgBox("Quantity must be greater than zero!", MsgBoxStyle.ApplicationModal, "Error!")
            End If
        Else
            txtQTY.BackColor = Color.Yellow
            MessageBox.Show("Quantity is required to select item.", "Error")
            txtQTY.Focus()
        End If

        Return blnResult

    End Function

    Private Sub picImage1_Click(sender As Object, e As EventArgs) Handles picImage1.Click

        OpenItem(intStartIndex)

    End Sub

    Private Sub picImage2_Click(sender As Object, e As EventArgs) Handles picImage2.Click

        OpenItem(intStartIndex + 1)

    End Sub

    Private Sub picImage3_Click(sender As Object, e As EventArgs) Handles picImage3.Click

        OpenItem(intStartIndex + 2)

    End Sub

    Private Sub picImage4_Click(sender As Object, e As EventArgs) Handles picImage4.Click

        OpenItem(intStartIndex + 3)

    End Sub

    Private Sub picImage5_Click(sender As Object, e As EventArgs) Handles picImage5.Click

        OpenItem(intStartIndex + 4)

    End Sub

    Private Sub picImage6_Click(sender As Object, e As EventArgs) Handles picImage6.Click

        OpenItem(intStartIndex + 5)

    End Sub

    Private Sub picImage7_Click(sender As Object, e As EventArgs) Handles picImage7.Click

        OpenItem(intStartIndex + 6)

    End Sub

    Private Sub picImage8_Click(sender As Object, e As EventArgs) Handles picImage8.Click

        OpenItem(intStartIndex + 7)

    End Sub

    Private Sub picImage9_Click(sender As Object, e As EventArgs) Handles picImage9.Click

        OpenItem(intStartIndex + 8)

    End Sub

    Private Sub picImage10_Click(sender As Object, e As EventArgs) Handles picImage10.Click

        OpenItem(intStartIndex + 9)

    End Sub

    ' Only allow numbers in the phone number field
    Private Sub txtQTY_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtQTY.KeyPress

        ' Only accept number keystrokes and backspace keystroke
        If Not Char.IsNumber(e.KeyChar) And e.KeyChar <> ControlChars.Back Then
            e.Handled = True
        End If

    End Sub

    Private Sub StepAction_Tick(sender As Object, e As EventArgs) Handles StepAction.Tick

        ButtonColor(MousePosition, btnExit, Me, btmButtonDefaultGray, btmButtonDefault)
        ButtonColor(MousePosition, btnBack, Me, btmButtonShortGray, btmButtonShort)
        ButtonColor(MousePosition, btnNext, Me, btmButtonShortGray, btmButtonShort)

    End Sub
End Class