<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormRiwayat
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
        Dim DataGridViewCellStyle1 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim CustomizableEdges1 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges2 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        dgvRiwayat = New Guna.UI2.WinForms.Guna2DataGridView()
        btnTutup = New Guna.UI2.WinForms.Guna2Button()
        TableLayoutPanel1 = New TableLayoutPanel()
        CType(dgvRiwayat, ComponentModel.ISupportInitialize).BeginInit()
        TableLayoutPanel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' dgvRiwayat
        ' 
        DataGridViewCellStyle1.BackColor = Color.White
        dgvRiwayat.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        DataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = Color.FromArgb(CByte(100), CByte(88), CByte(255))
        DataGridViewCellStyle2.Font = New Font("Segoe UI", 9F)
        DataGridViewCellStyle2.ForeColor = Color.White
        DataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = DataGridViewTriState.True
        dgvRiwayat.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        dgvRiwayat.ColumnHeadersHeight = 4
        dgvRiwayat.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        DataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = Color.White
        DataGridViewCellStyle3.Font = New Font("Segoe UI", 9F)
        DataGridViewCellStyle3.ForeColor = Color.FromArgb(CByte(71), CByte(69), CByte(94))
        DataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(CByte(231), CByte(229), CByte(255))
        DataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(CByte(71), CByte(69), CByte(94))
        DataGridViewCellStyle3.WrapMode = DataGridViewTriState.False
        dgvRiwayat.DefaultCellStyle = DataGridViewCellStyle3
        dgvRiwayat.Dock = DockStyle.Fill
        dgvRiwayat.GridColor = Color.FromArgb(CByte(231), CByte(229), CByte(255))
        dgvRiwayat.Location = New Point(3, 3)
        dgvRiwayat.Name = "dgvRiwayat"
        dgvRiwayat.RowHeadersVisible = False
        dgvRiwayat.RowHeadersWidth = 51
        dgvRiwayat.Size = New Size(794, 391)
        dgvRiwayat.TabIndex = 0
        dgvRiwayat.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White
        dgvRiwayat.ThemeStyle.AlternatingRowsStyle.Font = Nothing
        dgvRiwayat.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty
        dgvRiwayat.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty
        dgvRiwayat.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty
        dgvRiwayat.ThemeStyle.BackColor = Color.White
        dgvRiwayat.ThemeStyle.GridColor = Color.FromArgb(CByte(231), CByte(229), CByte(255))
        dgvRiwayat.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(CByte(100), CByte(88), CByte(255))
        dgvRiwayat.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None
        dgvRiwayat.ThemeStyle.HeaderStyle.Font = New Font("Segoe UI", 9F)
        dgvRiwayat.ThemeStyle.HeaderStyle.ForeColor = Color.White
        dgvRiwayat.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        dgvRiwayat.ThemeStyle.HeaderStyle.Height = 4
        dgvRiwayat.ThemeStyle.ReadOnly = False
        dgvRiwayat.ThemeStyle.RowsStyle.BackColor = Color.White
        dgvRiwayat.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        dgvRiwayat.ThemeStyle.RowsStyle.Font = New Font("Segoe UI", 9F)
        dgvRiwayat.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(CByte(71), CByte(69), CByte(94))
        dgvRiwayat.ThemeStyle.RowsStyle.Height = 29
        dgvRiwayat.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(CByte(231), CByte(229), CByte(255))
        dgvRiwayat.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(CByte(71), CByte(69), CByte(94))
        ' 
        ' btnTutup
        ' 
        btnTutup.BorderRadius = 15
        btnTutup.CustomizableEdges = CustomizableEdges1
        btnTutup.DisabledState.BorderColor = Color.DarkGray
        btnTutup.DisabledState.CustomBorderColor = Color.DarkGray
        btnTutup.DisabledState.FillColor = Color.FromArgb(CByte(169), CByte(169), CByte(169))
        btnTutup.DisabledState.ForeColor = Color.FromArgb(CByte(141), CByte(141), CByte(141))
        btnTutup.FillColor = Color.Red
        btnTutup.Font = New Font("Poppins SemiBold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnTutup.ForeColor = Color.White
        btnTutup.Location = New Point(3, 400)
        btnTutup.Name = "btnTutup"
        btnTutup.ShadowDecoration.CustomizableEdges = CustomizableEdges2
        btnTutup.Size = New Size(184, 45)
        btnTutup.TabIndex = 1
        btnTutup.Text = "Tutup"
        ' 
        ' TableLayoutPanel1
        ' 
        TableLayoutPanel1.ColumnCount = 1
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        TableLayoutPanel1.Controls.Add(dgvRiwayat, 0, 0)
        TableLayoutPanel1.Controls.Add(btnTutup, 0, 1)
        TableLayoutPanel1.Dock = DockStyle.Fill
        TableLayoutPanel1.Location = New Point(0, 0)
        TableLayoutPanel1.Name = "TableLayoutPanel1"
        TableLayoutPanel1.RowCount = 2
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 50F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 53F))
        TableLayoutPanel1.Size = New Size(800, 450)
        TableLayoutPanel1.TabIndex = 2
        ' 
        ' FormRiwayat
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(TableLayoutPanel1)
        Name = "FormRiwayat"
        Text = "FormRiwayat"
        CType(dgvRiwayat, ComponentModel.ISupportInitialize).EndInit()
        TableLayoutPanel1.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents dgvRiwayat As Guna.UI2.WinForms.Guna2DataGridView
    Friend WithEvents btnTutup As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
End Class
