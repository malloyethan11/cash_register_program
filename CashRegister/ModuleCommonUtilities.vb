Imports Microsoft.Office.Interop

Module ModuleCommonUtilities

    Sub CreateWordDocument()

        ' START CITATION-----------------------
        ' CITE: https://support.microsoft.com/en-us/topic/how-to-automate-word-from-visual-basic-net-to-create-a-new-document-b954608e-2fb5-06d1-d747-e44724762417

        Dim oWord As Word.Application
        Dim oDoc As Word.Document
        Dim oTable As Word.Table
        Dim oPara1 As Word.Paragraph, oPara2 As Word.Paragraph
        Dim oPara3 As Word.Paragraph, oPara4 As Word.Paragraph
        Dim oRng As Word.Range
        Dim oShape As Word.InlineShape
        Dim oChart As Object
        Dim Pos As Double

        'Start Word and open the document template.
        oWord = CreateObject("Word.Application")
        oWord.Visible = False
        oDoc = oWord.Documents.Add

        'Insert a paragraph at the beginning of the document.
        oPara1 = oDoc.Content.Paragraphs.Add
        oPara1.Range.Text = "Heading 1"
        oPara1.Range.Font.Bold = True
        oPara1.Format.SpaceAfter = 24    '24 pt spacing after paragraph.
        oPara1.Range.InsertParagraphAfter()

        'Insert a paragraph at the end of the document.
        '** \endofdoc is a predefined bookmark.
        oPara2 = oDoc.Content.Paragraphs.Add(oDoc.Bookmarks.Item("\endofdoc").Range)
        oPara2.Range.Text = "Heading 2"
        oPara2.Format.SpaceAfter = 6
        oPara2.Range.InsertParagraphAfter()

        'Insert another paragraph.
        oPara3 = oDoc.Content.Paragraphs.Add(oDoc.Bookmarks.Item("\endofdoc").Range)
        oPara3.Range.Text = "This is a sentence of normal text. Now here is a table:"
        oPara3.Range.Font.Bold = False
        oPara3.Format.SpaceAfter = 24
        oPara3.Range.InsertParagraphAfter()

        'Insert a 3 x 5 table, fill it with data, and make the first row
        'bold and italic.
        Dim r As Integer, c As Integer
        oTable = oDoc.Tables.Add(oDoc.Bookmarks.Item("\endofdoc").Range, 3, 5)
        oTable.Range.ParagraphFormat.SpaceAfter = 6
        For r = 1 To 3
            For c = 1 To 5
                oTable.Cell(r, c).Range.Text = "r" & r & "c" & c
            Next
        Next
        oTable.Rows.Item(1).Range.Font.Bold = True
        oTable.Rows.Item(1).Range.Font.Italic = True

        'Add some text after the table.
        'oTable.Range.InsertParagraphAfter()
        oPara4 = oDoc.Content.Paragraphs.Add(oDoc.Bookmarks.Item("\endofdoc").Range)
        oPara4.Range.InsertParagraphBefore()
        oPara4.Range.Text = "And here's another table:"
        oPara4.Format.SpaceAfter = 24
        oPara4.Range.InsertParagraphAfter()

        'Insert a 5 x 2 table, fill it with data, and change the column widths.
        oTable = oDoc.Tables.Add(oDoc.Bookmarks.Item("\endofdoc").Range, 5, 2)
        oTable.Range.ParagraphFormat.SpaceAfter = 6
        For r = 1 To 5
            For c = 1 To 2
                oTable.Cell(r, c).Range.Text = "r" & r & "c" & c
            Next
        Next
        oTable.Columns.Item(1).Width = oWord.InchesToPoints(2)   'Change width of columns 1 & 2
        oTable.Columns.Item(2).Width = oWord.InchesToPoints(3)

        'Keep inserting text. When you get to 7 inches from top of the
        'document, insert a hard page break.
        Pos = oWord.InchesToPoints(7)
        oDoc.Bookmarks.Item("\endofdoc").Range.InsertParagraphAfter()
        Do
            oRng = oDoc.Bookmarks.Item("\endofdoc").Range
            oRng.ParagraphFormat.SpaceAfter = 6
            oRng.InsertAfter("A line of text")
            oRng.InsertParagraphAfter()
        Loop While Pos >= oRng.Information(Word.WdInformation.wdVerticalPositionRelativeToPage)
        oRng.Collapse(Word.WdCollapseDirection.wdCollapseEnd)
        oRng.InsertBreak(Word.WdBreakType.wdPageBreak)
        oRng.Collapse(Word.WdCollapseDirection.wdCollapseEnd)
        oRng.InsertAfter("We're now on page 2. Here's my chart:")
        oRng.InsertParagraphAfter()

        'Insert a chart and change the chart.
        oShape = oDoc.Bookmarks.Item("\endofdoc").Range.InlineShapes.AddOLEObject(
            ClassType:="MSGraph.Chart.8", FileName _
            :="", LinkToFile:=False, DisplayAsIcon:=False)
        oChart = oShape.OLEFormat.Object
        oChart.charttype = 4 'xlLine = 4how fast is a tick in VB.NET timer
        oChart.Application.Update()
        oChart.Application.Quit()
        'If desired, you can proceed from here using the Microsoft Graph 
        'Object model on the oChart object to make additional changes to the
        'chart.
        oShape.Width = oWord.InchesToPoints(6.25)
        oShape.Height = oWord.InchesToPoints(3.57)

        'Add text after the chart.
        oRng = oDoc.Bookmarks.Item("\endofdoc").Range
        oRng.InsertParagraphAfter()
        oRng.InsertAfter("THE END.")

        'All done. Close this form.
        'MsgBox(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase) + "\Form.docx")
        oDoc.SaveAs2(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase) + "\Form.docx")
        oDoc.Close()
        oWord.Quit()

        'Me.Close()

        ' END CITATION-----------------------

    End Sub

    ' Open a form and hide the current form
    Public Function OpenFormMaintainParent(ByRef frmSelf As Form, ByVal frmToOpen As Form) As DialogResult

        ' Init variables
        Dim dlgResult As DialogResult

        ' Make self invisible
        frmSelf.Visible = False

        ' Make new form
        dlgResult = frmToOpen.ShowDialog()

        ' Make self visible
        If (frmSelf.IsDisposed = False) Then
            frmSelf.Visible = True
        End If

        ' Return result
        Return dlgResult

    End Function

    ' Open a form and close the current form
    Public Function OpenFormKillParent(ByRef frmSelf As Form, ByVal frmToOpen As Form) As DialogResult

        ' Init variables
        Dim dlgResult As DialogResult

        ' Make new form
        frmToOpen.Show()

        ' Kill self
        frmSelf.Close()

        ' Return result
        Return dlgResult

    End Function

    Public Sub ButtonColor(ByVal pntPosition As Point, ByRef btnItemLookup As Button, ByVal frmMe As Form, ByVal btmButtonGray As Bitmap, ByVal btmButton As Bitmap, Optional ByVal intUpperOffset As Integer = -9, Optional ByVal intLowerOffset As Integer = -8)

        If (MouseIsHovering(pntPosition, btnItemLookup, frmMe, intUpperOffset, intLowerOffset) And frmMe.ContainsFocus = True) Then
            btnItemLookup.Image = btmButtonGray
        Else
            btnItemLookup.Image = btmButton
        End If

    End Sub

    Public Function MouseIsHovering(ByVal MousePosition As Point, ByRef ctlControl As Control, ByRef frmForm As Form, Optional ByVal intUpperOffset As Integer = -9, Optional ByVal intLowerOffset As Integer = -8)

        ' This if statement adapted from the Waveslash game launch I made for my latest game: https://gravityhamster.itch.io/waveslash
        If (MousePosition.X > ctlControl.Left + frmForm.Left And MousePosition.X < ctlControl.Right + frmForm.Left) And (MousePosition.Y > ctlControl.Top + frmForm.Top + ctlControl.Height + intUpperOffset And MousePosition.Y < ctlControl.Bottom + frmForm.Top + ctlControl.Height + intLowerOffset) Then
            Return True
        Else
            Return False
        End If

    End Function

    Public Function Clamp(ByVal intValue As Integer, ByVal intMin As Integer, ByVal intMax As Integer) As Integer

        ' Clamp into range
        If (intValue > intMax) Then
            intValue = intMax
        ElseIf (intValue < intMin) Then
            intValue = intMin
        End If

        ' Return
        Return intValue

    End Function

    Public Function CountCharacters(ByVal strString As String, ByVal chrToFind As Char) As Integer

        Dim intIndex As Integer = 0
        Dim intCount As Integer = 0

        While intIndex < strString.Length()

            If (GetChar(strString, intIndex + 1) = chrToFind) Then
                intCount += 1
            End If

            intIndex += 1

        End While

        Return intCount

    End Function

End Module
