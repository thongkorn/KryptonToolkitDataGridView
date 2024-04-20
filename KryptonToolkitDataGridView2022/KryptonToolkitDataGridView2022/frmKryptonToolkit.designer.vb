<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmKryptonToolkit
    'Inherits System.Windows.Forms.Form
    Inherits Krypton.Toolkit.KryptonForm

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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgvData = New Krypton.Toolkit.KryptonDataGridView()
        Me.KryptonThemeComboBox1 = New Krypton.Toolkit.KryptonThemeComboBox()
        CType(Me.dgvData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonThemeComboBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 524)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(131, 18)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Select PaletteMode"
        '
        'dgvData
        '
        Me.dgvData.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvData.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvData.Location = New System.Drawing.Point(1, 1)
        Me.dgvData.Name = "dgvData"
        Me.dgvData.Size = New System.Drawing.Size(952, 520)
        Me.dgvData.TabIndex = 5
        '
        'KryptonThemeComboBox1
        '
        Me.KryptonThemeComboBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.KryptonThemeComboBox1.DefaultPalette = Krypton.Toolkit.PaletteMode.Office2007Silver
        Me.KryptonThemeComboBox1.DropDownWidth = 265
        Me.KryptonThemeComboBox1.IntegralHeight = False
        Me.KryptonThemeComboBox1.Location = New System.Drawing.Point(12, 546)
        Me.KryptonThemeComboBox1.Name = "KryptonThemeComboBox1"
        Me.KryptonThemeComboBox1.Size = New System.Drawing.Size(265, 24)
        Me.KryptonThemeComboBox1.StateCommon.ComboBox.Content.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.KryptonThemeComboBox1.TabIndex = 0
        '
        'frmKryptonToolkit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(956, 579)
        Me.Controls.Add(Me.KryptonThemeComboBox1)
        Me.Controls.Add(Me.dgvData)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmKryptonToolkit"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "KryptonToolkit DataGridView (VB.NET 2022) - coDe bY: Thongkorn Tubtimkrob"
        CType(Me.dgvData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KryptonThemeComboBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As Label
    Friend WithEvents dgvData As Krypton.Toolkit.KryptonDataGridView
    Friend WithEvents KryptonThemeComboBox1 As Krypton.Toolkit.KryptonThemeComboBox
End Class
