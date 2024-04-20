#Region "ABOUT"
' / --------------------------------------------------------------------------------------------
' / Developer : Mr.Surapon Yodsanga (Thongkorn Tubtimkrob)
' / eMail : thongkorn@hotmail.com
' / URL: http://www.g2gnet.com (Khon Kaen - Thailand)
' / Facebook: https://www.facebook.com/g2gnet (For Thailand)
' / Facebook: https://www.facebook.com/commonindy (Worldwide)
' / More Info: http://www.g2gsoft.com/
' /
' / Purpose: KryptonDataGridView Validate Cell & Create Control Dynamic.
' / Microsoft Visual Basic .NET (2022) + KryptonToolkit.
' /
' / This is open source code under @Copyleft by Thongkorn Tubtimkrob.
' / You can modify and/or distribute without to inform the developer.
' / --------------------------------------------------------------------------------------------
#End Region

'// for .Net Framework 4.6.2+ (80.24.3.64)
'// https://www.nuget.org/packages/Krypton.Toolkit


Imports Krypton.Toolkit

Public Class frmKryptonToolkit
    Private Sub frmKryptonToolkit_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        '// The form must be set to Press KeyPreview = True.
        Select Case e.KeyCode
            Case Keys.F7
                Call AddRow()
            Case Keys.F8
                Call DeleteRow()
        End Select
    End Sub

    ' / --------------------------------------------------------------------------------------------
    ' / S T A R T ... H E R E
    ' / --------------------------------------------------------------------------------------------
    Private Sub frmKryptonToolkit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        Call InitializeGrid()
        Call AddRow()
        '// Set to KryptonDataGridView By changing the Palette according to the main form.
        Me.dgvData.PaletteMode = Krypton.Toolkit.PaletteMode.Global
    End Sub

    ' / --------------------------------------------------------------------------------------------
    ' / Initialized settings for DataGridView @Run Time.
    ' / --------------------------------------------------------------------------------------------
    Private Sub InitializeGrid()
        With dgvData
            .RowHeadersVisible = False
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .AllowUserToResizeRows = False
            .MultiSelect = False
            '// Need to modify each cell.
            .SelectionMode = DataGridViewSelectionMode.CellSelect
            .ReadOnly = False
            '// Automatically set the width.
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            '// Font for RowTemplate.
            .RowTemplate.DefaultCellStyle.Font = New Font("Tahoma", 11, FontStyle.Regular)
            .RowTemplate.MinimumHeight = 32
            '// Header.
            .ColumnHeadersDefaultCellStyle.Font = New Font("Tahoma", 11, FontStyle.Bold)
            '// Show alternating colors in even and odd rows.
            .AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue
            '// Set ColumnHeadersHeightSizeMode before adjusting row heights.
            'dgvData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing
            dgvData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
            dgvData.ColumnHeadersHeight = 36
            '// GridStyles
            '.GridStyles.Style = DataGridViewStyle.List
            '.GridStyles.Style = DataGridViewStyle.Mixed
            .GridStyles.Style = DataGridViewStyle.Sheet
        End With

        '// Create columns dynamically.
        Dim colString As New KryptonDataGridViewTextBoxColumn()
        dgvData.Columns.Add(colString)
        With dgvData.Columns(0) '// OR colString
            .Name = "colString"
            .HeaderText = "String"
        End With
        '//
        Dim colInteger As New KryptonDataGridViewTextBoxColumn()   '// Index 1
        dgvData.Columns.Add(colInteger)
        With colInteger
            .Name = "colInteger"
            .HeaderText = "Integer"
            .DefaultCellStyle.Format = "0"
        End With
        '//
        Dim colDouble As New KryptonDataGridViewTextBoxColumn()   '// Index 2
        dgvData.Columns.Add(colDouble)
        With colDouble
            .Name = "colDouble"
            .HeaderText = "Double"
            .DefaultCellStyle.Format = "0.00"
        End With
        '//
        Dim colCombo As New KryptonDataGridViewComboBoxColumn()   '// Index 3
        dgvData.Columns.Add(colCombo)
        With colCombo
            .Name = "colCombo"
            .HeaderText = "ComboBox"
            .DropDownStyle = ComboBoxStyle.DropDownList
            .ReadOnly = False
            .DisplayMember = "Name"
            .DataSource = GetDataTable()
        End With
        '//
        '// Create a KryptonDataGridViewDateTimePickerColumn
        Dim dateTimePickerColumn As New KryptonDataGridViewDateTimePickerColumn()  '// Index 4
        With dateTimePickerColumn
            .HeaderText = "Date"
            .Name = "colDate"
            '// Set the format of the DateTimePicker
            .Format = DateTimePickerFormat.Short
        End With
        '// Add the column to the KryptonDataGridView
        dgvData.Columns.Add(dateTimePickerColumn)
        '//
        Dim colCheckBox As New KryptonDataGridViewCheckBoxColumn()    '// Index 5
        dgvData.Columns.Add(colCheckBox)
        With colCheckBox
            .Name = "colCheckBox"
            .HeaderText = "CheckBox"
        End With
        '//
        Dim colUpDown As New KryptonDataGridViewNumericUpDownColumn()  '// Index 6
        dgvData.Columns.Add(colUpDown)
        With colUpDown
            .Name = "colUpDown"
            .HeaderText = "UpDown"
            .Maximum = 100
            .Minimum = 0
            .Increment = 1
        End With
        '// Add 8th column (Index = 7), It's Button.
        Dim btnAddRow As New KryptonDataGridViewButtonColumn()    '// Index 7
        dgvData.Columns.Add(btnAddRow)
        With btnAddRow
            .HeaderText = "Add-F7"
            .Text = "Add"
            .Name = "btnAddRow"
            .UseColumnTextForButtonValue = True
            .Width = 80
        End With
        '// Add 9th column (Index = 8), It's Button.
        Dim btnRemoveRow As New KryptonDataGridViewButtonColumn()     '// Index 8
        dgvData.Columns.Add(btnRemoveRow)
        With btnRemoveRow
            .HeaderText = "Del-F8"
            .Text = "Delete"
            .Name = "btnRemoveRow"
            .UseColumnTextForButtonValue = True
            .Width = 80
        End With
        '// Alignment header and cell any columns.
        For iCol As Byte = 1 To 8
            If iCol = 1 Or iCol = 2 Then
                dgvData.Columns(iCol).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
                dgvData.Columns(iCol).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            ElseIf iCol = 3 Or iCol = 4 Or iCol = 6 Then
                dgvData.Columns(iCol).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
                dgvData.Columns(iCol).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            Else
                dgvData.Columns(iCol).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                dgvData.Columns(iCol).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End If
        Next

    End Sub

    ' / --------------------------------------------------------------------------------------------
    ' / Sample DataTable for ComboBox.
    ' / --------------------------------------------------------------------------------------------
    Function GetDataTable() As DataTable
        Dim DT As DataTable = New DataTable
        With DT.Columns
            .Add("PK", GetType(Integer))
            .Add("Name", GetType(String))
        End With
        With DT.Rows
            .Add(1, "M100")
            .Add(2, "M150")
            .Add(3, "M16")
            .Add(4, "M4")
            .Add(5, "AK47")
            .Add(6, "RPG")
        End With
        Return DT
    End Function

    ' / --------------------------------------------------------------------------------------------
    ' / SAMPLE DATA FOR ADD TO ROW.
    ' / --------------------------------------------------------------------------------------------
    Private Sub AddRow()
        Dim RandGen As New Random()
        '// Random Double Value.
        Dim minValue As Double = 0.0 ' Minimum value for the range
        Dim maxValue As Double = 9999.0 ' Maximum value for the range
        '// Generate a random double between minValue and maxValue
        Dim randomDouble As Double = RandGen.NextDouble() * (maxValue - minValue) + minValue
        '// ComboBox.
        'Dim ls As New List(Of String) ({"M100", "M150", "M16", "M4", "AK47", "RPG"})
        Dim dt As DataTable = GetDataTable()
        Dim ls As New List(Of String)()
        For Each row As DataRow In dt.Rows
            ls.Add(row("Name").ToString())
        Next
        '// Random value from List.
        Dim RandArray As String = ls(RandGen.Next(0, ls.Count))
        '// String, Integer, Double, ComboBox, Date, CheckBox, UpDown
        dgvData.Rows.Add(
            "Product " & RandGen.Next(1, 999),
            RandGen.Next(1, 999),
            randomDouble,
            RandArray,
            DateTime.Today.AddDays(-RandGen.Next(365)),
            IIf(RandGen.Next(0, 2) > 0, "True", "False"),
            RandGen.Next(1, 100))
    End Sub

    ' / --------------------------------------------------------------------------------------------
    ' / Sub program to delete selected rows.
    ' / --------------------------------------------------------------------------------------------
    Private Sub DeleteRow()
        If dgvData.RowCount = 0 Then Return
        '// Delete selected row items.
        dgvData.Rows.Remove(dgvData.CurrentRow)
    End Sub

    ' / --------------------------------------------------------------------------------------------
    ' / Click mouse event in grid cell.
    ' / --------------------------------------------------------------------------------------------
    Private Sub dgvData_CellClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvData.CellClick
        Select Case e.ColumnIndex
            '// Add Row.
            Case 7
                Call AddRow()
                '// Delete Row.
            Case 8
                'MsgBox(("Row : " + e.RowIndex.ToString & "  Col : ") + e.ColumnIndex.ToString)
                Call DeleteRow()
        End Select
    End Sub

    ' / --------------------------------------------------------------------------------------------
    ' / Enter press event in grid cell.
    ' / --------------------------------------------------------------------------------------------
    Private Sub dgvData_CellEndEdit(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvData.CellEndEdit
        '/ change occurred in the 1st or 2nd index digit.
        Select Case e.ColumnIndex
            Case 1  '/ Integer Value.
                '/ Index = 1 (Integer)
                '/ To trap errors in the case of having a Null Value, enter the value 0 instead.
                If IsNothing(dgvData.Rows(e.RowIndex).Cells(1).Value) Then dgvData.Rows(e.RowIndex).Cells(1).Value = "0"
                '/ Handle the CellFormatting event to format numeric values.
                AddHandler dgvData.CellFormatting, AddressOf KryptonDataGridView_CellFormatting

            Case 2 '/ Double Value.
                '/ Index = 2 (Double)
                '/ If Null Value
                If IsNothing(dgvData.Rows(e.RowIndex).Cells(2).Value) Then dgvData.Rows(e.RowIndex).Cells(2).Value = "0.00"
                '/ Handle the CellFormatting event to format numeric values.
                AddHandler dgvData.CellFormatting, AddressOf KryptonDataGridView_CellFormatting
        End Select
    End Sub

    ' / --------------------------------------------------------------------------------------------
    ' / When you start pressing the keys in digits (Index) 1 and 2.
    ' / --------------------------------------------------------------------------------------------
    Private Sub dgvData_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dgvData.EditingControlShowing
        '// Or use the index columns of DataGridView.
        'Select Case dgvData.Columns(dgvData.CurrentCell.ColumnIndex).Index
        '    Case 1
        '
        'End Select

        '// Don't forget to specify the Column Name earlier as well (InitializeGrid sub program).
        Select Case dgvData.Columns(dgvData.CurrentCell.ColumnIndex).Name
            ' / Can use both Colume Index or Field Name
            Case "colInteger", "colDouble"
                If TypeOf e.Control Is Krypton.Toolkit.KryptonDataGridViewTextBoxEditingControl Then
                    Dim editingControl As Krypton.Toolkit.KryptonDataGridViewTextBoxEditingControl = TryCast(e.Control, Krypton.Toolkit.KryptonDataGridViewTextBoxEditingControl)
                    '// Event Handler for intercepts keystrokes.
                    AddHandler editingControl.KeyPress, AddressOf KryptonDataGridViewKeyPress
                End If
        End Select
    End Sub

    ' / --------------------------------------------------------------------------------------------
    ' / Intercepts keystrokes only with numeric and point (.) only one.
    ' / --------------------------------------------------------------------------------------------
    Private Sub KryptonDataGridViewKeyPress(sender As Object, e As KeyPressEventArgs)
        Select Case dgvData.CurrentCell.ColumnIndex
            Case 1, 6   '// Integer
                '// Allow numeric digits (0-9) in the TextBox.
                If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then e.Handled = True

            Case 2  '// Double
                '// Allow numeric digits (0-9) and the decimal point (.) only one in the TextBox.
                If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> "." Then e.Handled = True
                '// Check for an existing decimal point in the cell.
                Dim tb As KryptonDataGridViewTextBoxEditingControl = DirectCast(sender, KryptonDataGridViewTextBoxEditingControl)
                If e.KeyChar = "." AndAlso tb.Text.Contains(".") Then e.Handled = True
        End Select
    End Sub

    ' / --------------------------------------------------------------------------------------------
    ' / Event Handler from dgvData_CellEndEdit to format numbers.
    ' / --------------------------------------------------------------------------------------------
    Private Sub KryptonDataGridView_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs)
        If e.ColumnIndex = dgvData.Columns("colInteger").Index Then
            '// Format as an integer
            If Not e.Value Is Nothing AndAlso IsNumeric(e.Value) Then e.Value = CInt(e.Value)
        ElseIf e.ColumnIndex = dgvData.Columns("colDouble").Index Then
            '// Format as a double with two decimal places
            If Not e.Value Is Nothing AndAlso IsNumeric(e.Value) Then e.Value = CDbl(e.Value).ToString("0.00")
        End If
    End Sub

End Class
