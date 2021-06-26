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
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.btnEmail = New System.Windows.Forms.Button()
        Me.btnPrintAndEmail = New System.Windows.Forms.Button()
        Me.btnNone = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnPrint
        '
        Me.btnPrint.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPrint.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrint.Image = Global.CashRegister.My.Resources.Resources.Button
        Me.btnPrint.Location = New System.Drawing.Point(12, 12)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(284, 42)
        Me.btnPrint.TabIndex = 7
        Me.btnPrint.Text = "Print"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'btnEmail
        '
        Me.btnEmail.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnEmail.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEmail.Image = Global.CashRegister.My.Resources.Resources.Button
        Me.btnEmail.Location = New System.Drawing.Point(12, 60)
        Me.btnEmail.Name = "btnEmail"
        Me.btnEmail.Size = New System.Drawing.Size(284, 42)
        Me.btnEmail.TabIndex = 6
        Me.btnEmail.Text = "Email"
        Me.btnEmail.UseVisualStyleBackColor = True
        '
        'btnPrintAndEmail
        '
        Me.btnPrintAndEmail.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPrintAndEmail.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrintAndEmail.Image = Global.CashRegister.My.Resources.Resources.Button
        Me.btnPrintAndEmail.Location = New System.Drawing.Point(12, 108)
        Me.btnPrintAndEmail.Name = "btnPrintAndEmail"
        Me.btnPrintAndEmail.Size = New System.Drawing.Size(284, 42)
        Me.btnPrintAndEmail.TabIndex = 5
        Me.btnPrintAndEmail.Text = "Print && Email"
        Me.btnPrintAndEmail.UseVisualStyleBackColor = True
        '
        'btnNone
        '
        Me.btnNone.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnNone.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNone.Image = Global.CashRegister.My.Resources.Resources.Button
        Me.btnNone.Location = New System.Drawing.Point(12, 156)
        Me.btnNone.Name = "btnNone"
        Me.btnNone.Size = New System.Drawing.Size(284, 42)
        Me.btnNone.TabIndex = 5
        Me.btnNone.Text = "None"
        Me.btnNone.UseVisualStyleBackColor = True
        '
        'frmInvoice
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(308, 211)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.btnEmail)
        Me.Controls.Add(Me.btnNone)
        Me.Controls.Add(Me.btnPrintAndEmail)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmInvoice"
        Me.Text = "Invoice"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnPrint As Button
    Friend WithEvents btnEmail As Button
    Friend WithEvents btnPrintAndEmail As Button
    Friend WithEvents btnNone As Button
End Class
