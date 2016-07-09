<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ResetOrderForm
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
        Me.OrderNumTB = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ResetToNew = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'OrderNumTB
        '
        Me.OrderNumTB.Location = New System.Drawing.Point(12, 25)
        Me.OrderNumTB.Name = "OrderNumTB"
        Me.OrderNumTB.Size = New System.Drawing.Size(100, 20)
        Me.OrderNumTB.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Order Number:"
        '
        'ResetToNew
        '
        Me.ResetToNew.Location = New System.Drawing.Point(118, 23)
        Me.ResetToNew.Name = "ResetToNew"
        Me.ResetToNew.Size = New System.Drawing.Size(121, 23)
        Me.ResetToNew.TabIndex = 0
        Me.ResetToNew.Text = "Reset Order To New"
        Me.ResetToNew.UseVisualStyleBackColor = True
        '
        'ResetOrderForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(257, 59)
        Me.Controls.Add(Me.ResetToNew)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.OrderNumTB)
        Me.Name = "ResetOrderForm"
        Me.Text = "Order Reset"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents OrderNumTB As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents ResetToNew As Button
End Class
