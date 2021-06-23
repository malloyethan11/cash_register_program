<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPriceAdjust
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPriceAdjust))
        Me.btnExit = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.txtAmount = New System.Windows.Forms.TextBox()
        Me.lblAdjust = New System.Windows.Forms.Label()
        Me.cboUnitOfMeasure = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboVendor = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'btnExit
        '
        Me.btnExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnExit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnExit.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExit.Image = Global.CashRegister.My.Resources.Resources.ButtonShort
        Me.btnExit.Location = New System.Drawing.Point(12, 65)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(113, 42)
        Me.btnExit.TabIndex = 85
        Me.btnExit.Text = "Cancel"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Image = Global.CashRegister.My.Resources.Resources.ButtonShort
        Me.Button1.Location = New System.Drawing.Point(320, 65)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(113, 42)
        Me.Button1.TabIndex = 85
        Me.Button1.Text = "Submit"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'txtAmount
        '
        Me.txtAmount.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtAmount.Location = New System.Drawing.Point(143, 13)
        Me.txtAmount.Name = "txtAmount"
        Me.txtAmount.Size = New System.Drawing.Size(185, 20)
        Me.txtAmount.TabIndex = 86
        '
        'lblAdjust
        '
        Me.lblAdjust.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblAdjust.AutoSize = True
        Me.lblAdjust.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAdjust.Location = New System.Drawing.Point(12, 16)
        Me.lblAdjust.Name = "lblAdjust"
        Me.lblAdjust.Size = New System.Drawing.Size(125, 13)
        Me.lblAdjust.TabIndex = 87
        Me.lblAdjust.Text = "Adjustment Amount:"
        '
        'cboUnitOfMeasure
        '
        Me.cboUnitOfMeasure.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cboUnitOfMeasure.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboUnitOfMeasure.FormattingEnabled = True
        Me.cboUnitOfMeasure.Items.AddRange(New Object() {"%", "Dollars"})
        Me.cboUnitOfMeasure.Location = New System.Drawing.Point(334, 12)
        Me.cboUnitOfMeasure.Name = "cboUnitOfMeasure"
        Me.cboUnitOfMeasure.Size = New System.Drawing.Size(99, 21)
        Me.cboUnitOfMeasure.TabIndex = 88
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(87, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 13)
        Me.Label1.TabIndex = 87
        Me.Label1.Text = "Vendor:"
        '
        'cboVendor
        '
        Me.cboVendor.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cboVendor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboVendor.FormattingEnabled = True
        Me.cboVendor.Location = New System.Drawing.Point(143, 39)
        Me.cboVendor.Name = "cboVendor"
        Me.cboVendor.Size = New System.Drawing.Size(290, 21)
        Me.cboVendor.TabIndex = 88
        '
        'frmPriceAdjust
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(445, 119)
        Me.Controls.Add(Me.cboVendor)
        Me.Controls.Add(Me.cboUnitOfMeasure)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblAdjust)
        Me.Controls.Add(Me.txtAmount)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnExit)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmPriceAdjust"
        Me.Text = "Price Adjust"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnExit As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents txtAmount As TextBox
    Friend WithEvents lblAdjust As Label
    Friend WithEvents cboUnitOfMeasure As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents cboVendor As ComboBox
End Class
