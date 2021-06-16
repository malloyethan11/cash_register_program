<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCheckout
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCheckout))
        Me.lstItems = New System.Windows.Forms.ListBox()
        Me.lblList = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblSalesTax = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.lblPaymentDetails = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtPhoneNumber = New System.Windows.Forms.TextBox()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.lblEmail = New System.Windows.Forms.Label()
        Me.lblZip = New System.Windows.Forms.Label()
        Me.TextBox8 = New System.Windows.Forms.TextBox()
        Me.TextBox6 = New System.Windows.Forms.TextBox()
        Me.lblSecurityCode = New System.Windows.Forms.Label()
        Me.dtpExpirationDate = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.lblLastName = New System.Windows.Forms.Label()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.lblFirstName = New System.Windows.Forms.Label()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.lblPaymentType = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.btnRemoveSelectedItem = New System.Windows.Forms.Button()
        Me.btnItemLookup = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnSubmit = New System.Windows.Forms.Button()
        Me.lblCity = New System.Windows.Forms.Label()
        Me.TextBox7 = New System.Windows.Forms.TextBox()
        Me.lblAddress = New System.Windows.Forms.Label()
        Me.TextBox9 = New System.Windows.Forms.TextBox()
        Me.cboState = New System.Windows.Forms.ComboBox()
        Me.lblState = New System.Windows.Forms.Label()
        Me.lblPaymentDetails.SuspendLayout()
        Me.SuspendLayout()
        '
        'lstItems
        '
        Me.lstItems.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstItems.FormattingEnabled = True
        Me.lstItems.Location = New System.Drawing.Point(504, 87)
        Me.lstItems.Name = "lstItems"
        Me.lstItems.Size = New System.Drawing.Size(270, 69)
        Me.lstItems.TabIndex = 49
        Me.lstItems.TabStop = False
        '
        'lblList
        '
        Me.lblList.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblList.Location = New System.Drawing.Point(504, 61)
        Me.lblList.Name = "lblList"
        Me.lblList.Size = New System.Drawing.Size(279, 23)
        Me.lblList.TabIndex = 50
        Me.lblList.Text = "Purchase List:"
        Me.lblList.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TextBox1
        '
        Me.TextBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox1.Location = New System.Drawing.Point(571, 225)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(203, 20)
        Me.TextBox1.TabIndex = 11
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.Location = New System.Drawing.Point(504, 223)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 23)
        Me.Label1.TabIndex = 52
        Me.Label1.Text = "Total Price:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblSalesTax
        '
        Me.lblSalesTax.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblSalesTax.Location = New System.Drawing.Point(504, 249)
        Me.lblSalesTax.Name = "lblSalesTax"
        Me.lblSalesTax.Size = New System.Drawing.Size(61, 23)
        Me.lblSalesTax.TabIndex = 54
        Me.lblSalesTax.Text = "Sales Tax:"
        Me.lblSalesTax.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TextBox2
        '
        Me.TextBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox2.Location = New System.Drawing.Point(571, 251)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.ReadOnly = True
        Me.TextBox2.Size = New System.Drawing.Size(203, 20)
        Me.TextBox2.TabIndex = 53
        Me.TextBox2.TabStop = False
        '
        'lblPaymentDetails
        '
        Me.lblPaymentDetails.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblPaymentDetails.Controls.Add(Me.Label4)
        Me.lblPaymentDetails.Controls.Add(Me.txtPhoneNumber)
        Me.lblPaymentDetails.Controls.Add(Me.TextBox9)
        Me.lblPaymentDetails.Controls.Add(Me.lblState)
        Me.lblPaymentDetails.Controls.Add(Me.lblAddress)
        Me.lblPaymentDetails.Controls.Add(Me.txtEmail)
        Me.lblPaymentDetails.Controls.Add(Me.lblEmail)
        Me.lblPaymentDetails.Controls.Add(Me.lblZip)
        Me.lblPaymentDetails.Controls.Add(Me.TextBox8)
        Me.lblPaymentDetails.Controls.Add(Me.TextBox7)
        Me.lblPaymentDetails.Controls.Add(Me.lblCity)
        Me.lblPaymentDetails.Controls.Add(Me.TextBox6)
        Me.lblPaymentDetails.Controls.Add(Me.lblSecurityCode)
        Me.lblPaymentDetails.Controls.Add(Me.dtpExpirationDate)
        Me.lblPaymentDetails.Controls.Add(Me.Label3)
        Me.lblPaymentDetails.Controls.Add(Me.Label2)
        Me.lblPaymentDetails.Controls.Add(Me.TextBox5)
        Me.lblPaymentDetails.Controls.Add(Me.lblLastName)
        Me.lblPaymentDetails.Controls.Add(Me.TextBox4)
        Me.lblPaymentDetails.Controls.Add(Me.lblFirstName)
        Me.lblPaymentDetails.Controls.Add(Me.TextBox3)
        Me.lblPaymentDetails.Controls.Add(Me.lblPaymentType)
        Me.lblPaymentDetails.Controls.Add(Me.cboState)
        Me.lblPaymentDetails.Controls.Add(Me.ComboBox1)
        Me.lblPaymentDetails.Location = New System.Drawing.Point(13, 12)
        Me.lblPaymentDetails.Name = "lblPaymentDetails"
        Me.lblPaymentDetails.Size = New System.Drawing.Size(485, 260)
        Me.lblPaymentDetails.TabIndex = 55
        Me.lblPaymentDetails.TabStop = False
        Me.lblPaymentDetails.Text = "Payment Details"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(3, 229)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(81, 13)
        Me.Label4.TabIndex = 73
        Me.Label4.Text = "Phone Number:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPhoneNumber
        '
        Me.txtPhoneNumber.Location = New System.Drawing.Point(90, 226)
        Me.txtPhoneNumber.Name = "txtPhoneNumber"
        Me.txtPhoneNumber.Size = New System.Drawing.Size(389, 20)
        Me.txtPhoneNumber.TabIndex = 9
        '
        'txtEmail
        '
        Me.txtEmail.Location = New System.Drawing.Point(90, 200)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(389, 20)
        Me.txtEmail.TabIndex = 8
        '
        'lblEmail
        '
        Me.lblEmail.AutoSize = True
        Me.lblEmail.Location = New System.Drawing.Point(8, 203)
        Me.lblEmail.Name = "lblEmail"
        Me.lblEmail.Size = New System.Drawing.Size(76, 13)
        Me.lblEmail.TabIndex = 70
        Me.lblEmail.Text = "Email Address:"
        Me.lblEmail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblZip
        '
        Me.lblZip.AutoSize = True
        Me.lblZip.Enabled = False
        Me.lblZip.Location = New System.Drawing.Point(31, 179)
        Me.lblZip.Name = "lblZip"
        Me.lblZip.Size = New System.Drawing.Size(53, 13)
        Me.lblZip.TabIndex = 69
        Me.lblZip.Text = "Zip Code:"
        Me.lblZip.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TextBox8
        '
        Me.TextBox8.Enabled = False
        Me.TextBox8.Location = New System.Drawing.Point(90, 176)
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.Size = New System.Drawing.Size(390, 20)
        Me.TextBox8.TabIndex = 7
        '
        'TextBox6
        '
        Me.TextBox6.Enabled = False
        Me.TextBox6.Location = New System.Drawing.Point(277, 98)
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.Size = New System.Drawing.Size(202, 20)
        Me.TextBox6.TabIndex = 5
        '
        'lblSecurityCode
        '
        Me.lblSecurityCode.AutoSize = True
        Me.lblSecurityCode.Enabled = False
        Me.lblSecurityCode.Location = New System.Drawing.Point(195, 101)
        Me.lblSecurityCode.Name = "lblSecurityCode"
        Me.lblSecurityCode.Size = New System.Drawing.Size(76, 13)
        Me.lblSecurityCode.TabIndex = 64
        Me.lblSecurityCode.Text = "Security Code:"
        Me.lblSecurityCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpExpirationDate
        '
        Me.dtpExpirationDate.Enabled = False
        Me.dtpExpirationDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpExpirationDate.Location = New System.Drawing.Point(90, 98)
        Me.dtpExpirationDate.Name = "dtpExpirationDate"
        Me.dtpExpirationDate.Size = New System.Drawing.Size(99, 20)
        Me.dtpExpirationDate.TabIndex = 4
        Me.dtpExpirationDate.Value = New Date(2021, 1, 21, 0, 0, 0, 0)
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Enabled = False
        Me.Label3.Location = New System.Drawing.Point(2, 101)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(82, 13)
        Me.Label3.TabIndex = 62
        Me.Label3.Text = "Expiration Date:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Enabled = False
        Me.Label2.Location = New System.Drawing.Point(6, 75)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(102, 13)
        Me.Label2.TabIndex = 60
        Me.Label2.Text = "Credit Card Number:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TextBox5
        '
        Me.TextBox5.Enabled = False
        Me.TextBox5.Location = New System.Drawing.Point(114, 72)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(365, 20)
        Me.TextBox5.TabIndex = 3
        '
        'lblLastName
        '
        Me.lblLastName.AutoSize = True
        Me.lblLastName.Location = New System.Drawing.Point(254, 49)
        Me.lblLastName.Name = "lblLastName"
        Me.lblLastName.Size = New System.Drawing.Size(61, 13)
        Me.lblLastName.TabIndex = 58
        Me.lblLastName.Text = "Last Name:"
        Me.lblLastName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(320, 46)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(159, 20)
        Me.TextBox4.TabIndex = 2
        '
        'lblFirstName
        '
        Me.lblFirstName.AutoSize = True
        Me.lblFirstName.Location = New System.Drawing.Point(24, 48)
        Me.lblFirstName.Name = "lblFirstName"
        Me.lblFirstName.Size = New System.Drawing.Size(60, 13)
        Me.lblFirstName.TabIndex = 58
        Me.lblFirstName.Text = "First Name:"
        Me.lblFirstName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(90, 46)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(158, 20)
        Me.TextBox3.TabIndex = 1
        '
        'lblPaymentType
        '
        Me.lblPaymentType.AutoSize = True
        Me.lblPaymentType.Location = New System.Drawing.Point(6, 22)
        Me.lblPaymentType.Name = "lblPaymentType"
        Me.lblPaymentType.Size = New System.Drawing.Size(78, 13)
        Me.lblPaymentType.TabIndex = 56
        Me.lblPaymentType.Text = "Payment Type:"
        Me.lblPaymentType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"Select a Payment Type", "Cash", "Credit"})
        Me.ComboBox1.Location = New System.Drawing.Point(90, 19)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(389, 21)
        Me.ComboBox1.TabIndex = 0
        '
        'btnRemoveSelectedItem
        '
        Me.btnRemoveSelectedItem.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRemoveSelectedItem.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRemoveSelectedItem.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRemoveSelectedItem.Image = Global.CashRegister.My.Resources.Resources.Button
        Me.btnRemoveSelectedItem.Location = New System.Drawing.Point(499, 172)
        Me.btnRemoveSelectedItem.Name = "btnRemoveSelectedItem"
        Me.btnRemoveSelectedItem.Size = New System.Drawing.Size(284, 42)
        Me.btnRemoveSelectedItem.TabIndex = 56
        Me.btnRemoveSelectedItem.Text = "Remove Selected Item"
        Me.btnRemoveSelectedItem.UseVisualStyleBackColor = True
        '
        'btnItemLookup
        '
        Me.btnItemLookup.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnItemLookup.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnItemLookup.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnItemLookup.Image = Global.CashRegister.My.Resources.Resources.Button
        Me.btnItemLookup.Location = New System.Drawing.Point(499, 12)
        Me.btnItemLookup.Name = "btnItemLookup"
        Me.btnItemLookup.Size = New System.Drawing.Size(284, 42)
        Me.btnItemLookup.TabIndex = 10
        Me.btnItemLookup.Text = "Item Lookup"
        Me.btnItemLookup.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnExit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnExit.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExit.Image = Global.CashRegister.My.Resources.Resources.ButtonShort
        Me.btnExit.Location = New System.Drawing.Point(12, 289)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(113, 42)
        Me.btnExit.TabIndex = 12
        Me.btnExit.Text = "Back"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'btnSubmit
        '
        Me.btnSubmit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSubmit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSubmit.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSubmit.Image = Global.CashRegister.My.Resources.Resources.Button
        Me.btnSubmit.Location = New System.Drawing.Point(499, 289)
        Me.btnSubmit.Name = "btnSubmit"
        Me.btnSubmit.Size = New System.Drawing.Size(284, 42)
        Me.btnSubmit.TabIndex = 13
        Me.btnSubmit.Text = "Submit"
        Me.btnSubmit.UseVisualStyleBackColor = True
        '
        'lblCity
        '
        Me.lblCity.AutoSize = True
        Me.lblCity.Enabled = False
        Me.lblCity.Location = New System.Drawing.Point(57, 153)
        Me.lblCity.Name = "lblCity"
        Me.lblCity.Size = New System.Drawing.Size(27, 13)
        Me.lblCity.TabIndex = 66
        Me.lblCity.Text = "City:"
        Me.lblCity.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TextBox7
        '
        Me.TextBox7.Enabled = False
        Me.TextBox7.Location = New System.Drawing.Point(90, 150)
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.Size = New System.Drawing.Size(158, 20)
        Me.TextBox7.TabIndex = 6
        '
        'lblAddress
        '
        Me.lblAddress.AutoSize = True
        Me.lblAddress.Enabled = False
        Me.lblAddress.Location = New System.Drawing.Point(5, 127)
        Me.lblAddress.Name = "lblAddress"
        Me.lblAddress.Size = New System.Drawing.Size(79, 13)
        Me.lblAddress.TabIndex = 70
        Me.lblAddress.Text = "Street Address:"
        Me.lblAddress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TextBox9
        '
        Me.TextBox9.Enabled = False
        Me.TextBox9.Location = New System.Drawing.Point(90, 124)
        Me.TextBox9.Name = "TextBox9"
        Me.TextBox9.Size = New System.Drawing.Size(389, 20)
        Me.TextBox9.TabIndex = 8
        '
        'cboState
        '
        Me.cboState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboState.Enabled = False
        Me.cboState.FormattingEnabled = True
        Me.cboState.Items.AddRange(New Object() {"Select a Payment Type", "Cash", "Credit"})
        Me.cboState.Location = New System.Drawing.Point(320, 149)
        Me.cboState.Name = "cboState"
        Me.cboState.Size = New System.Drawing.Size(159, 21)
        Me.cboState.TabIndex = 0
        '
        'lblState
        '
        Me.lblState.AutoSize = True
        Me.lblState.Enabled = False
        Me.lblState.Location = New System.Drawing.Point(280, 153)
        Me.lblState.Name = "lblState"
        Me.lblState.Size = New System.Drawing.Size(35, 13)
        Me.lblState.TabIndex = 70
        Me.lblState.Text = "State:"
        Me.lblState.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmCheckout
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(794, 343)
        Me.Controls.Add(Me.btnRemoveSelectedItem)
        Me.Controls.Add(Me.lblPaymentDetails)
        Me.Controls.Add(Me.lblSalesTax)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.lblList)
        Me.Controls.Add(Me.lstItems)
        Me.Controls.Add(Me.btnItemLookup)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnSubmit)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmCheckout"
        Me.Text = "Checkout"
        Me.lblPaymentDetails.ResumeLayout(False)
        Me.lblPaymentDetails.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnSubmit As Button
    Friend WithEvents btnExit As Button
    Friend WithEvents btnItemLookup As Button
    Friend WithEvents lstItems As ListBox
    Friend WithEvents lblList As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents lblSalesTax As Label
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents lblPaymentDetails As GroupBox
    Friend WithEvents dtpExpirationDate As DateTimePicker
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents TextBox5 As TextBox
    Friend WithEvents lblLastName As Label
    Friend WithEvents TextBox4 As TextBox
    Friend WithEvents lblFirstName As Label
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents lblPaymentType As Label
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents TextBox6 As TextBox
    Friend WithEvents lblSecurityCode As Label
    Friend WithEvents lblZip As Label
    Friend WithEvents TextBox8 As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtPhoneNumber As TextBox
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents lblEmail As Label
    Friend WithEvents btnRemoveSelectedItem As Button
    Friend WithEvents TextBox9 As TextBox
    Friend WithEvents lblState As Label
    Friend WithEvents lblAddress As Label
    Friend WithEvents TextBox7 As TextBox
    Friend WithEvents lblCity As Label
    Friend WithEvents cboState As ComboBox
End Class
