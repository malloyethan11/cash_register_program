<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmVendorLookup
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmVendorLookup))
        Me.btnOpen = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.lblVendorName = New System.Windows.Forms.Label()
        Me.cboVendors = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'btnOpen
        '
        Me.btnOpen.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOpen.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnOpen.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOpen.Image = Global.CashRegister.My.Resources.Resources.ButtonShort
        Me.btnOpen.Location = New System.Drawing.Point(166, 40)
        Me.btnOpen.Name = "btnOpen"
        Me.btnOpen.Size = New System.Drawing.Size(113, 42)
        Me.btnOpen.TabIndex = 96
        Me.btnOpen.Text = "Open"
        Me.btnOpen.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnExit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnExit.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExit.Image = Global.CashRegister.My.Resources.Resources.ButtonShort
        Me.btnExit.Location = New System.Drawing.Point(11, 40)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(113, 42)
        Me.btnExit.TabIndex = 95
        Me.btnExit.Text = "Back"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'lblVendorName
        '
        Me.lblVendorName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVendorName.Location = New System.Drawing.Point(6, 12)
        Me.lblVendorName.Name = "lblVendorName"
        Me.lblVendorName.Size = New System.Drawing.Size(93, 20)
        Me.lblVendorName.TabIndex = 98
        Me.lblVendorName.Text = "Vendor Name:"
        Me.lblVendorName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboVendors
        '
        Me.cboVendors.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboVendors.FormattingEnabled = True
        Me.cboVendors.Location = New System.Drawing.Point(105, 13)
        Me.cboVendors.Name = "cboVendors"
        Me.cboVendors.Size = New System.Drawing.Size(169, 21)
        Me.cboVendors.TabIndex = 99
        '
        'frmVendorLookup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(286, 94)
        Me.Controls.Add(Me.cboVendors)
        Me.Controls.Add(Me.lblVendorName)
        Me.Controls.Add(Me.btnOpen)
        Me.Controls.Add(Me.btnExit)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmVendorLookup"
        Me.Text = "Vendor Lookup"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnOpen As Button
    Friend WithEvents btnExit As Button
    Friend WithEvents lblVendorName As Label
    Friend WithEvents cboVendors As ComboBox
End Class
