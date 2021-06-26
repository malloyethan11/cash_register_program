<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInvoice
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmInvoice))
        Me.btnCheckout = New System.Windows.Forms.Button()
        Me.btnInventory = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnCheckout
        '
        Me.btnCheckout.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCheckout.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCheckout.Image = Global.CashRegister.My.Resources.Resources.Button
        Me.btnCheckout.Location = New System.Drawing.Point(12, 12)
        Me.btnCheckout.Name = "btnCheckout"
        Me.btnCheckout.Size = New System.Drawing.Size(284, 42)
        Me.btnCheckout.TabIndex = 7
        Me.btnCheckout.Text = "Print"
        Me.btnCheckout.UseVisualStyleBackColor = True
        '
        'btnInventory
        '
        Me.btnInventory.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnInventory.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnInventory.Image = Global.CashRegister.My.Resources.Resources.Button
        Me.btnInventory.Location = New System.Drawing.Point(12, 60)
        Me.btnInventory.Name = "btnInventory"
        Me.btnInventory.Size = New System.Drawing.Size(284, 42)
        Me.btnInventory.TabIndex = 6
        Me.btnInventory.Text = "Email"
        Me.btnInventory.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnExit.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExit.Image = Global.CashRegister.My.Resources.Resources.Button
        Me.btnExit.Location = New System.Drawing.Point(12, 108)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(284, 42)
        Me.btnExit.TabIndex = 5
        Me.btnExit.Text = "Print && Email"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Image = Global.CashRegister.My.Resources.Resources.Button
        Me.Button1.Location = New System.Drawing.Point(12, 156)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(284, 42)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "None"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'frmInvoice
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(308, 211)
        Me.Controls.Add(Me.btnCheckout)
        Me.Controls.Add(Me.btnInventory)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnExit)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmInvoice"
        Me.Text = "Invoice"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnCheckout As Button
    Friend WithEvents btnInventory As Button
    Friend WithEvents btnExit As Button
    Friend WithEvents Button1 As Button
End Class
