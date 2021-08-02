<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmItemEditor
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmItemEditor))
        Me.txtSKU = New System.Windows.Forms.TextBox()
        Me.lblSKU = New System.Windows.Forms.Label()
        Me.lblName = New System.Windows.Forms.Label()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.lblDescription = New System.Windows.Forms.Label()
        Me.txtDescription = New System.Windows.Forms.TextBox()
        Me.lblPrice = New System.Windows.Forms.Label()
        Me.txtPrice = New System.Windows.Forms.TextBox()
        Me.txtInventory = New System.Windows.Forms.TextBox()
        Me.lblInventory = New System.Windows.Forms.Label()
        Me.txtUPC = New System.Windows.Forms.TextBox()
        Me.lblUPC = New System.Windows.Forms.Label()
        Me.txtSafetytock = New System.Windows.Forms.TextBox()
        Me.lblSafetyStock = New System.Windows.Forms.Label()
        Me.cboVendor = New System.Windows.Forms.ComboBox()
        Me.cboCategory = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.btnChangeImage = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.picItemImage = New System.Windows.Forms.PictureBox()
        Me.StepAction = New System.Windows.Forms.Timer(Me.components)
        CType(Me.picItemImage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtSKU
        '
        Me.txtSKU.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtSKU.BackColor = System.Drawing.Color.White
        Me.txtSKU.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSKU.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSKU.ForeColor = System.Drawing.Color.Black
        Me.txtSKU.Location = New System.Drawing.Point(241, 18)
        Me.txtSKU.Name = "txtSKU"
        Me.txtSKU.Size = New System.Drawing.Size(182, 20)
        Me.txtSKU.TabIndex = 1
        '
        'lblSKU
        '
        Me.lblSKU.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblSKU.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSKU.Location = New System.Drawing.Point(154, 18)
        Me.lblSKU.Name = "lblSKU"
        Me.lblSKU.Size = New System.Drawing.Size(81, 20)
        Me.lblSKU.TabIndex = 70
        Me.lblSKU.Text = "SKU Number:"
        Me.lblSKU.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblName
        '
        Me.lblName.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblName.Location = New System.Drawing.Point(429, 18)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(50, 20)
        Me.lblName.TabIndex = 72
        Me.lblName.Text = "Name:"
        Me.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtName
        '
        Me.txtName.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtName.BackColor = System.Drawing.Color.White
        Me.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtName.ForeColor = System.Drawing.Color.Black
        Me.txtName.Location = New System.Drawing.Point(485, 18)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(248, 20)
        Me.txtName.TabIndex = 2
        '
        'lblDescription
        '
        Me.lblDescription.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblDescription.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescription.Location = New System.Drawing.Point(154, 43)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(81, 20)
        Me.lblDescription.TabIndex = 73
        Me.lblDescription.Text = "Description:"
        Me.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtDescription
        '
        Me.txtDescription.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtDescription.BackColor = System.Drawing.Color.White
        Me.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescription.ForeColor = System.Drawing.Color.Black
        Me.txtDescription.Location = New System.Drawing.Point(241, 45)
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(492, 20)
        Me.txtDescription.TabIndex = 3
        '
        'lblPrice
        '
        Me.lblPrice.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblPrice.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrice.Location = New System.Drawing.Point(185, 72)
        Me.lblPrice.Name = "lblPrice"
        Me.lblPrice.Size = New System.Drawing.Size(50, 20)
        Me.lblPrice.TabIndex = 75
        Me.lblPrice.Text = "Price:"
        Me.lblPrice.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtPrice
        '
        Me.txtPrice.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtPrice.BackColor = System.Drawing.Color.White
        Me.txtPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPrice.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrice.ForeColor = System.Drawing.Color.Black
        Me.txtPrice.Location = New System.Drawing.Point(241, 72)
        Me.txtPrice.Name = "txtPrice"
        Me.txtPrice.Size = New System.Drawing.Size(144, 20)
        Me.txtPrice.TabIndex = 4
        '
        'txtInventory
        '
        Me.txtInventory.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtInventory.BackColor = System.Drawing.Color.White
        Me.txtInventory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtInventory.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInventory.ForeColor = System.Drawing.Color.Black
        Me.txtInventory.Location = New System.Drawing.Point(241, 99)
        Me.txtInventory.Name = "txtInventory"
        Me.txtInventory.Size = New System.Drawing.Size(144, 20)
        Me.txtInventory.TabIndex = 6
        '
        'lblInventory
        '
        Me.lblInventory.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblInventory.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInventory.Location = New System.Drawing.Point(157, 99)
        Me.lblInventory.Name = "lblInventory"
        Me.lblInventory.Size = New System.Drawing.Size(78, 20)
        Me.lblInventory.TabIndex = 77
        Me.lblInventory.Text = "Inventory:"
        Me.lblInventory.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtUPC
        '
        Me.txtUPC.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtUPC.BackColor = System.Drawing.Color.White
        Me.txtUPC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUPC.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUPC.ForeColor = System.Drawing.Color.Black
        Me.txtUPC.Location = New System.Drawing.Point(241, 126)
        Me.txtUPC.Name = "txtUPC"
        Me.txtUPC.Size = New System.Drawing.Size(144, 20)
        Me.txtUPC.TabIndex = 8
        '
        'lblUPC
        '
        Me.lblUPC.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblUPC.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUPC.Location = New System.Drawing.Point(157, 126)
        Me.lblUPC.Name = "lblUPC"
        Me.lblUPC.Size = New System.Drawing.Size(78, 20)
        Me.lblUPC.TabIndex = 79
        Me.lblUPC.Text = "UPC:"
        Me.lblUPC.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtSafetytock
        '
        Me.txtSafetytock.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtSafetytock.BackColor = System.Drawing.Color.White
        Me.txtSafetytock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSafetytock.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSafetytock.ForeColor = System.Drawing.Color.Black
        Me.txtSafetytock.Location = New System.Drawing.Point(506, 99)
        Me.txtSafetytock.Name = "txtSafetytock"
        Me.txtSafetytock.Size = New System.Drawing.Size(227, 20)
        Me.txtSafetytock.TabIndex = 7
        '
        'lblSafetyStock
        '
        Me.lblSafetyStock.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblSafetyStock.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSafetyStock.Location = New System.Drawing.Point(390, 99)
        Me.lblSafetyStock.Name = "lblSafetyStock"
        Me.lblSafetyStock.Size = New System.Drawing.Size(110, 20)
        Me.lblSafetyStock.TabIndex = 81
        Me.lblSafetyStock.Text = "Safety Stock:"
        Me.lblSafetyStock.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboVendor
        '
        Me.cboVendor.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cboVendor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboVendor.FormattingEnabled = True
        Me.cboVendor.ItemHeight = 13
        Me.cboVendor.Location = New System.Drawing.Point(506, 72)
        Me.cboVendor.Name = "cboVendor"
        Me.cboVendor.Size = New System.Drawing.Size(227, 21)
        Me.cboVendor.TabIndex = 104
        '
        'cboCategory
        '
        Me.cboCategory.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCategory.FormattingEnabled = True
        Me.cboCategory.Location = New System.Drawing.Point(506, 126)
        Me.cboCategory.Name = "cboCategory"
        Me.cboCategory.Size = New System.Drawing.Size(227, 21)
        Me.cboCategory.TabIndex = 9
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(422, 72)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(78, 20)
        Me.Label3.TabIndex = 102
        Me.Label3.Text = "Vendor:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(422, 126)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(78, 20)
        Me.Label2.TabIndex = 103
        Me.Label2.Text = "Category:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnDelete.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.Image = Global.CashRegister.My.Resources.Resources.ButtonShort
        Me.btnDelete.Location = New System.Drawing.Point(621, 183)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(113, 42)
        Me.btnDelete.TabIndex = 13
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        Me.btnUpdate.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnUpdate.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnUpdate.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUpdate.Image = Global.CashRegister.My.Resources.Resources.Button
        Me.btnUpdate.Location = New System.Drawing.Point(241, 183)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(278, 42)
        Me.btnUpdate.TabIndex = 12
        Me.btnUpdate.Text = "Update"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'btnChangeImage
        '
        Me.btnChangeImage.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnChangeImage.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnChangeImage.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnChangeImage.Image = Global.CashRegister.My.Resources.Resources.SkinnyButton
        Me.btnChangeImage.Location = New System.Drawing.Point(12, 153)
        Me.btnChangeImage.Name = "btnChangeImage"
        Me.btnChangeImage.Size = New System.Drawing.Size(135, 29)
        Me.btnChangeImage.TabIndex = 10
        Me.btnChangeImage.Text = "Change Image"
        Me.btnChangeImage.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnExit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnExit.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExit.Image = Global.CashRegister.My.Resources.Resources.ButtonLittleLong
        Me.btnExit.Location = New System.Drawing.Point(12, 183)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(136, 42)
        Me.btnExit.TabIndex = 11
        Me.btnExit.Text = "Back"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'picItemImage
        '
        Me.picItemImage.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.picItemImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picItemImage.Location = New System.Drawing.Point(12, 12)
        Me.picItemImage.Name = "picItemImage"
        Me.picItemImage.Size = New System.Drawing.Size(135, 135)
        Me.picItemImage.TabIndex = 108
        Me.picItemImage.TabStop = False
        '
        'StepAction
        '
        Me.StepAction.Enabled = True
        '
        'frmItemEditor
        '
        Me.AcceptButton = Me.btnUpdate
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(746, 237)
        Me.Controls.Add(Me.picItemImage)
        Me.Controls.Add(Me.btnChangeImage)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.cboVendor)
        Me.Controls.Add(Me.cboCategory)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtSafetytock)
        Me.Controls.Add(Me.lblSafetyStock)
        Me.Controls.Add(Me.txtUPC)
        Me.Controls.Add(Me.lblUPC)
        Me.Controls.Add(Me.txtInventory)
        Me.Controls.Add(Me.lblInventory)
        Me.Controls.Add(Me.txtPrice)
        Me.Controls.Add(Me.lblPrice)
        Me.Controls.Add(Me.txtDescription)
        Me.Controls.Add(Me.lblDescription)
        Me.Controls.Add(Me.lblName)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.lblSKU)
        Me.Controls.Add(Me.txtSKU)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnUpdate)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmItemEditor"
        Me.Text = "Item Editor"
        CType(Me.picItemImage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnDelete As Button
	Friend WithEvents btnUpdate As Button
	Friend WithEvents txtSKU As TextBox
	Friend WithEvents lblSKU As Label
	Friend WithEvents lblName As Label
	Friend WithEvents txtName As TextBox
	Friend WithEvents lblDescription As Label
	Friend WithEvents txtDescription As TextBox
	Friend WithEvents lblPrice As Label
	Friend WithEvents txtPrice As TextBox
	Friend WithEvents txtInventory As TextBox
	Friend WithEvents lblInventory As Label
	Friend WithEvents txtUPC As TextBox
	Friend WithEvents lblUPC As Label
	Friend WithEvents txtSafetytock As TextBox
	Friend WithEvents lblSafetyStock As Label
	Friend WithEvents cboVendor As ComboBox
	Friend WithEvents cboCategory As ComboBox
	Friend WithEvents Label3 As Label
	Friend WithEvents Label2 As Label
	Friend WithEvents btnChangeImage As Button
	Friend WithEvents btnExit As Button
	Friend WithEvents picItemImage As PictureBox
    Friend WithEvents StepAction As Timer
End Class
