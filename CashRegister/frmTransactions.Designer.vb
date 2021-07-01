<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTransactions
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTransactions))
        Me.picLogo = New System.Windows.Forms.PictureBox()
        Me.btnCheckout = New System.Windows.Forms.Button()
        Me.btnReturns = New System.Windows.Forms.Button()
        Me.btnViewTransactions = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnPayInPayOut = New System.Windows.Forms.Button()
        CType(Me.picLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'picLogo
        '
        Me.picLogo.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.picLogo.BackgroundImage = Global.CashRegister.My.Resources.Resources.Logo
        Me.picLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.picLogo.InitialImage = Global.CashRegister.My.Resources.Resources.Logo
        Me.picLogo.Location = New System.Drawing.Point(71, -8)
        Me.picLogo.Name = "picLogo"
        Me.picLogo.Size = New System.Drawing.Size(674, 190)
        Me.picLogo.TabIndex = 13
        Me.picLogo.TabStop = False
        '
        'btnCheckout
        '
        Me.btnCheckout.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnCheckout.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCheckout.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCheckout.Image = Global.CashRegister.My.Resources.Resources.Button
        Me.btnCheckout.Location = New System.Drawing.Point(120, 232)
        Me.btnCheckout.Name = "btnCheckout"
        Me.btnCheckout.Size = New System.Drawing.Size(284, 42)
        Me.btnCheckout.TabIndex = 11
        Me.btnCheckout.Text = "Checkout"
        Me.btnCheckout.UseVisualStyleBackColor = True
        '
        'btnReturns
        '
        Me.btnReturns.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnReturns.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnReturns.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReturns.Image = Global.CashRegister.My.Resources.Resources.Button
        Me.btnReturns.Location = New System.Drawing.Point(410, 232)
        Me.btnReturns.Name = "btnReturns"
        Me.btnReturns.Size = New System.Drawing.Size(284, 42)
        Me.btnReturns.TabIndex = 12
        Me.btnReturns.Text = "Returns"
        Me.btnReturns.UseVisualStyleBackColor = True
        '
        'btnViewTransactions
        '
        Me.btnViewTransactions.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnViewTransactions.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnViewTransactions.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnViewTransactions.Image = Global.CashRegister.My.Resources.Resources.Button
        Me.btnViewTransactions.Location = New System.Drawing.Point(266, 328)
        Me.btnViewTransactions.Name = "btnViewTransactions"
        Me.btnViewTransactions.Size = New System.Drawing.Size(284, 42)
        Me.btnViewTransactions.TabIndex = 10
        Me.btnViewTransactions.Text = "View Transactions"
        Me.btnViewTransactions.UseVisualStyleBackColor = True
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
        Me.btnExit.TabIndex = 9
        Me.btnExit.Text = "Back"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'btnPayInPayOut
        '
        Me.btnPayInPayOut.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnPayInPayOut.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPayInPayOut.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPayInPayOut.Image = Global.CashRegister.My.Resources.Resources.Button
        Me.btnPayInPayOut.Location = New System.Drawing.Point(266, 280)
        Me.btnPayInPayOut.Name = "btnPayInPayOut"
        Me.btnPayInPayOut.Size = New System.Drawing.Size(284, 42)
        Me.btnPayInPayOut.TabIndex = 10
        Me.btnPayInPayOut.Text = "Pay-Ins and Pay-Outs"
        Me.btnPayInPayOut.UseVisualStyleBackColor = True
        '
        'frmTransactions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.picLogo)
        Me.Controls.Add(Me.btnCheckout)
        Me.Controls.Add(Me.btnReturns)
        Me.Controls.Add(Me.btnPayInPayOut)
        Me.Controls.Add(Me.btnViewTransactions)
        Me.Controls.Add(Me.btnExit)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmTransactions"
        Me.Text = "Transactions"
        CType(Me.picLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents picLogo As PictureBox
    Friend WithEvents btnCheckout As Button
    Friend WithEvents btnReturns As Button
    Friend WithEvents btnViewTransactions As Button
    Friend WithEvents btnExit As Button
    Friend WithEvents btnPayInPayOut As Button
End Class
