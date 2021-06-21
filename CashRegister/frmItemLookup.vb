
Public Class frmItemLookup

    Public intPrimaryKeyReturnValue As Integer
    Public Type As String = "Dialog"
    Dim intStartIndex As Integer = 0
    Dim drSet() As System.Data.DataRow
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
        LoadItems()
        txtSearch.Text = Trim(txtSearch.Text)

    End Sub

    Private Sub LoadItems()


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
            Dim strFilter As String
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
                Case Else
                    strFilter = "strUPC"
            End Select

            If (strFilter = "intCategoryID") Then

                strSelect = "SELECT intCategoryID, strCategory FROM TCategories
                WHERE strCategory Like '%" & txtSearch.Text & "%'"

                ' Retrieve all the records 
                cmdVenCatSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
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
                strSelect = "SELECT intItemID, strItemName, imgItemImage FROM TItems WHERE " & strSelectList

                ' Retrieve all the records 
                cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
                drSourceTable = cmdSelect.ExecuteReader

                ' load table from data reader
                dt.Load(drSourceTable)

                ' Populate the array based on search
                drSet = dt.Select("intItemID>0")

            ElseIf (strFilter = "intVendorID") Then

                strSelect = "SELECT intVendorID, strVendorName FROM TVendors WHERE strVendorName Like '%" & txtSearch.Text & "%'"

                ' Retrieve all the records 
                cmdVenCatSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
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
                strSelect = "SELECT intItemID, strItemName, imgItemImage FROM TItems WHERE " & strSelectList

                ' Retrieve all the records 
                cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
                drSourceTable = cmdSelect.ExecuteReader

                ' load table from data reader
                dt.Load(drSourceTable)

                ' Populate the array based on search
                drSet = dt.Select("intItemID>0")

            Else
                strSelect = "SELECT intItemID, strItemName, imgItemImage FROM TItems WHERE " & strFilter & " Like '%" & txtSearch.Text & "%'"

                ' Retrieve all the records 
                cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
                drSourceTable = cmdSelect.ExecuteReader

                ' load table from data reader
                dt.Load(drSourceTable)

                ' Populate the array based on search
                drSet = dt.Select("intItemID>0")
            End If

            ' Build the select statement
            'If (txtSearch.Text <> "*") Then
            'Else
            'strSelect = "SELECT intItemID, strItemName, imgItemImage FROM TItems
            '             WHERE " & strFIlter & " LIKE '%%'"
            'End If

            ' Calc total pages
            intTotalItems = drSet.Length
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

            ' Log and display error message
            MessageBox.Show(excError.Message)

        End Try

    End Sub

    Private Sub DisplayData()

        ' Set page number text
        If (intStartIndex < 9) Then
            lblPageNumber.Text = "Page " & (intStartIndex + 1) & " of " & (intPages)
        Else
            lblPageNumber.Text = "Page " & (intStartIndex + 10) / 10 & " of " & (intPages)
        End If

        ' Populate each
        If (drSet.Length >= intStartIndex + 1) Then
            lblItem1.Text = drSet(intStartIndex)("strItemName").ToString
            'Dim bytImageData(0) As Byte
            'bytImageData = CType(drSet(intStartIndex)("imgItemImage"), Byte())
            'Dim memData As System.IO.MemoryStream = New System.IO.MemoryStream(bytImageData)
            'picImage1.Image = Image.FromStream(memData)
        Else
            lblItem1.Text = ""
        End If

        If (drSet.Length >= intStartIndex + 2) Then
            lblItem2.Text = drSet(intStartIndex + 1)("strItemName").ToString
        Else
            lblItem2.Text = ""
        End If

        If (drSet.Length >= intStartIndex + 3) Then
            lblItem3.Text = drSet(intStartIndex + 2)("strItemName").ToString
        Else
            lblItem3.Text = ""
        End If

        If (drSet.Length >= intStartIndex + 4) Then
            lblItem4.Text = drSet(intStartIndex + 3)("strItemName").ToString
        Else
            lblItem4.Text = ""
        End If

        If (drSet.Length >= intStartIndex + 5) Then
            lblItem5.Text = drSet(intStartIndex + 4)("strItemName").ToString
        Else
            lblItem5.Text = ""
        End If

        If (drSet.Length >= intStartIndex + 6) Then
            lblItem6.Text = drSet(intStartIndex + 5)("strItemName").ToString
        Else
            lblItem6.Text = ""
        End If

        If (drSet.Length >= intStartIndex + 7) Then
            lblItem7.Text = drSet(intStartIndex + 6)("strItemName").ToString
        Else
            lblItem7.Text = ""
        End If

        If (drSet.Length >= intStartIndex + 8) Then
            lblItem8.Text = drSet(intStartIndex + 7)("strItemName").ToString
        Else
            lblItem8.Text = ""
        End If

        If (drSet.Length >= intStartIndex + 9) Then
            lblItem9.Text = drSet(intStartIndex + 8)("strItemName").ToString
        Else
            lblItem9.Text = ""
        End If

        If (drSet.Length >= intStartIndex + 10) Then
            lblItem10.Text = drSet(intStartIndex + 9)("strItemName").ToString
        Else
            lblItem10.Text = ""
        End If

    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click

        ' Go to next page
        If (drSet IsNot Nothing) Then
            If (drSet.Length > intStartIndex + 10) Then
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
            If (drSet.Length > intIndex) Then
                If (Type = "Dialog") Then
                    ' Close the form and return the primary key
                    intPrimaryKeyReturnValue = drSet(intIndex)("intItemID").ToString
                    Me.Close()
                Else
                    ' Open the editor form and pass on the primary key
                    Dim frmNewEditor As New frmItemEditor
                    frmNewEditor.intCurrentlyEditingVendorPrimaryKey = drSet(intIndex)("intItemID").ToString
                    OpenFormKillParent(Me, frmNewEditor)
                End If
            End If
        End If

    End Sub

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
End Class