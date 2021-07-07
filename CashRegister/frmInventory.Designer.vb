<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInventory
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmInventory))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btnItemLookup = New System.Windows.Forms.Button()
        Me.btnAddItem = New System.Windows.Forms.Button()
        Me.btnPriceItems = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnAddVendor = New System.Windows.Forms.Button()
        Me.btnVendorLookup = New System.Windows.Forms.Button()
        Me.StepAction = New System.Windows.Forms.Timer(Me.components)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.PictureBox1.BackgroundImage = Global.CashRegister.My.Resources.Resources.Logo
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PictureBox1.InitialImage = Global.CashRegister.My.Resources.Resources.Logo
        Me.PictureBox1.Location = New System.Drawing.Point(71, -8)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(674, 190)
        Me.PictureBox1.TabIndex = 8
        Me.PictureBox1.TabStop = False
        '
        'btnItemLookup
        '
        Me.btnItemLookup.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnItemLookup.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnItemLookup.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnItemLookup.Image = Global.CashRegister.My.Resources.Resources.Button
        Me.btnItemLookup.Location = New System.Drawing.Point(120, 232)
        Me.btnItemLookup.Name = "btnItemLookup"
        Me.btnItemLookup.Size = New System.Drawing.Size(284, 42)
        Me.btnItemLookup.TabIndex = 7
        Me.btnItemLookup.Text = "Item Lookup"
        Me.btnItemLookup.UseVisualStyleBackColor = True
        '
        'btnAddItem
        '
        Me.btnAddItem.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnAddItem.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAddItem.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddItem.Image = Global.CashRegister.My.Resources.Resources.Button
        Me.btnAddItem.Location = New System.Drawing.Point(120, 280)
        Me.btnAddItem.Name = "btnAddItem"
        Me.btnAddItem.Size = New System.Drawing.Size(284, 42)
        Me.btnAddItem.TabIndex = 7
        Me.btnAddItem.Text = "Add Item"
        Me.btnAddItem.UseVisualStyleBackColor = True
        '
        'btnPriceItems
        '
        Me.btnPriceItems.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnPriceItems.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPriceItems.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPriceItems.Image = Global.CashRegister.My.Resources.Resources.Button
        Me.btnPriceItems.Location = New System.Drawing.Point(266, 328)
        Me.btnPriceItems.Name = "btnPriceItems"
        Me.btnPriceItems.Size = New System.Drawing.Size(284, 42)
        Me.btnPriceItems.TabIndex = 6
        Me.btnPriceItems.Text = "Mass Pricing Form"
        Me.btnPriceItems.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnExit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnExit.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExit.Image = Global.CashRegister.My.Resources.Resources.Button
        Me.btnExit.Location = New System.Drawing.Point(266, 376)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(284, 42)
        Me.btnExit.TabIndex = 5
        Me.btnExit.Text = "Back"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'btnAddVendor
        '
        Me.btnAddVendor.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnAddVendor.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAddVendor.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddVendor.Image = Global.CashRegister.My.Resources.Resources.Button
        Me.btnAddVendor.Location = New System.Drawing.Point(410, 280)
        Me.btnAddVendor.Name = "btnAddVendor"
        Me.btnAddVendor.Size = New System.Drawing.Size(284, 42)
        Me.btnAddVendor.TabIndex = 7
        Me.btnAddVendor.Text = "Add Vendor"
        Me.btnAddVendor.UseVisualStyleBackColor = True
        '
        'btnVendorLookup
        '
        Me.btnVendorLookup.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnVendorLookup.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnVendorLookup.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVendorLookup.Image = Global.CashRegister.My.Resources.Resources.Button
        Me.btnVendorLookup.Location = New System.Drawing.Point(410, 232)
        Me.btnVendorLookup.Name = "btnVendorLookup"
        Me.btnVendorLookup.Size = New System.Drawing.Size(284, 42)
        Me.btnVendorLookup.TabIndex = 7
        Me.btnVendorLookup.Text = "Vendor Lookup"
        Me.btnVendorLookup.UseVisualStyleBackColor = True
        '
        'StepAction
        '
        Me.StepAction.Enabled = True
        Me.StepAction.Interval = 1
        '
        'frmInventory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.btnVendorLookup)
        Me.Controls.Add(Me.btnAddVendor)
        Me.Controls.Add(Me.btnItemLookup)
        Me.Controls.Add(Me.btnAddItem)
        Me.Controls.Add(Me.btnPriceItems)
        Me.Controls.Add(Me.btnExit)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmInventory"
        Me.Text = "Inventory"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents btnAddItem As Button
    Friend WithEvents btnPriceItems As Button
    Friend WithEvents btnExit As Button
    Friend WithEvents btnItemLookup As Button
    Friend WithEvents btnAddVendor As Button
    Friend WithEvents btnVendorLookup As Button
    Friend WithEvents StepAction As Timer
End Class
