Imports Microsoft.Office.Interop
Public Class frmInvoice
    Private Sub frmInvoice_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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

    Private Sub StepAction_Tick(sender As Object, e As EventArgs) Handles StepAction.Tick

        ButtonColor(MousePosition, btnPrint, Me, btmButtonDefaultGray, btmButtonDefault)
        ButtonColor(MousePosition, btnEmail, Me, btmButtonDefaultGray, btmButtonDefault)
        ButtonColor(MousePosition, btnPrintEmail, Me, btmButtonDefaultGray, btmButtonDefault)
        ButtonColor(MousePosition, btnNone, Me, btmButtonDefaultGray, btmButtonDefault)

    End Sub

    Private Sub btnNone_Click(sender As Object, e As EventArgs) Handles btnNone.Click

        OpenFormKillParent(Me, frmTransactions)

    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click

        ' declare variables
        Dim strSelect As String
        Dim cmdSelect As OleDb.OleDbCommand
        Dim dt As DataTable = New DataTable
        Dim drSourceTable As OleDb.OleDbDataReader
        Dim objResults As Object
        Dim strTransactionDate As String
        Dim intTransactionID As Integer
        Dim intQuantity As Integer
        Dim strItemName As String
        Dim dblPrice As Double
        Dim dblSubtotal As Double
        Dim dblSalesTax As Double
        Dim dblGrandTotal As Double

        ' create word document 
        Dim oWord As Word.Application
        Dim oDoc As Word.Document
        Dim oPara1 As Word.Paragraph
        Dim oPara2 As Word.Paragraph
        Dim oPara3 As Word.Paragraph
        Dim oPara4 As Word.Paragraph
        Dim oPara5 As Word.Paragraph
        Dim oPara6 As Word.Paragraph
        Dim oPara7 As Word.Paragraph
        Dim oPara8 As Word.Paragraph
        Dim oPara9 As Word.Paragraph
        Dim oPara10 As Word.Paragraph
        Dim oPara11 As Word.Paragraph
        Dim oPara12 As Word.Paragraph
        Dim oPara13 As Word.Paragraph
        Dim oPara14 As Word.Paragraph
        Dim oPara15 As Word.Paragraph
        Dim oPara16 As Word.Paragraph
        oWord = CreateObject("Word.Application")
        oWord.Visible = True ' for testing only, set to false for prod
        oDoc = oWord.Documents.Add

        ' get doc content and add content to doc
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

            ' add content to doc
            oPara1 = oDoc.Content.Paragraphs.Add
            oPara1.Range.Text = "Trinity Church Supply"
            oPara1.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter
            oPara1.Range.Font.Size = 36
            oPara1.Range.InsertParagraphAfter()

            oPara2 = oDoc.Content.Paragraphs.Add
            oPara2.Range.Text = "5479 North Bend Rd."
            oPara2.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter
            oPara2.Range.Font.Size = 20
            oPara2.Range.InsertParagraphAfter()

            oPara3 = oDoc.Content.Paragraphs.Add
            oPara3.Range.Text = "Cincinnati, OH 45247"
            oPara3.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter
            oPara3.Range.Font.Size = 20
            oPara3.Range.InsertParagraphAfter()

            oPara4 = oDoc.Content.Paragraphs.Add
            oPara4.Range.Text = "513-471-6626"
            oPara4.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter
            oPara4.Range.Font.Size = 14
            oPara4.Range.InsertParagraphAfter()

            oPara5 = oDoc.Content.Paragraphs.Add
            oPara5.Range.Text = ""
            oPara5.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter
            oPara5.Range.Font.Size = 14
            oPara5.Range.InsertParagraphAfter()

            oPara6 = oDoc.Content.Paragraphs.Add
            oPara6.Range.Text = "SALES INVOICE"
            oPara6.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft
            oPara6.Range.Font.Size = 14
            oPara6.Range.InsertParagraphAfter()


            ' get transaction date
            strSelect = "SELECT TOP 1 dtTransactionDate FROM TTransactions ORDER BY dtTransactionDate DESC"
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            objResults = cmdSelect.ExecuteNonQuery
            If IsDBNull(objResults) Then
                strTransactionDate = 0
            Else
                strTransactionDate = CDbl(objResults)
            End If
            oPara7 = oDoc.Content.Paragraphs.Add
            oPara7.Range.Text = "DATE: " & strTransactionDate
            oPara7.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft
            oPara7.Range.Font.Size = 14
            oPara7.Range.InsertParagraphAfter()


            ' get transaction ID
            strSelect = "SELECT MAX(intTransactionID) FROM TTransactions"
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            objResults = cmdSelect.ExecuteNonQuery
            If IsDBNull(objResults) Then
                intTransactionID = 0
            Else
                intTransactionID = CInt(objResults)
            End If
            oPara8 = oDoc.Content.Paragraphs.Add
            oPara8.Range.Text = "TRANSACTION ID: " & intTransactionID
            oPara8.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft
            oPara8.Range.Font.Size = 14
            oPara8.Range.InsertParagraphAfter()


            ' add rows for items
            ' Build the select statement based on user-selected time period
            strSelect = "SELECT intItemAmount, strItemName, decItemPrice FROM TTransactionItems, TItems, TTransactions WHERE TTransactionItems.intItemID = TItems.intItemID AND TTransactionItems.intTransactionID = TTransactions.intTransactionID AND TTransactions.intTransactionID = " & intTransactionID

            ' Retrieve all the records 
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            ' load table from data reader
            dt.Load(drSourceTable)

            ' add data to excel spreadsheet
            'intNumRecords = dt.Rows.Count

            'While intIndex <= (intNumRecords + 1)

            '    ExcelWkSht.Cells(intIndex, 1).Value = dt.Rows.Item(intRecordIndex).ItemArray(0)
            '    ExcelWkSht.Cells(intIndex, 2).Value = dt.Rows.Item(intRecordIndex).ItemArray(1)
            '    ExcelWkSht.Cells(intIndex, 3).Value = dt.Rows.Item(intRecordIndex).ItemArray(2)
            '    ExcelWkSht.Cells(intIndex, 4).Value = dt.Rows.Item(intRecordIndex).ItemArray(3)
            '    ExcelWkSht.Cells(intIndex, 5).Value = dt.Rows.Item(intRecordIndex).ItemArray(4)
            '    ExcelWkSht.Cells(intIndex, 6).Value = dt.Rows.Item(intRecordIndex).ItemArray(5)
            '    ExcelWkSht.Cells(intIndex, 7).Value = dt.Rows.Item(intRecordIndex).ItemArray(6)
            '    ExcelWkSht.Cells(intIndex, 8).Value = dt.Rows.Item(intRecordIndex).ItemArray(7).ToString() & "​" ' <- Whitespace character to trick excel formatting. DO NOT DELETE THIS
            '    intIndex += 1
            '    intRecordIndex += 1

            'End While


        Catch ex As Exception
            MessageBox.Show("Database Error:" + ex.Message)
        End Try





    End Sub

    Private Sub btnEmail_Click(sender As Object, e As EventArgs) Handles btnEmail.Click



    End Sub

    Private Sub btnPrintEmail_Click(sender As Object, e As EventArgs) Handles btnPrintEmail.Click



    End Sub
End Class