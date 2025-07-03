<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
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
        Dim CustomizableEdges1 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges2 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        panelKamarContainer = New FlowLayoutPanel()
        btnTambahKamar = New Guna.UI2.WinForms.Guna2Button()
        TableLayoutPanel1 = New TableLayoutPanel()
        PictureBox1 = New PictureBox()
        TableLayoutPanel2 = New TableLayoutPanel()
        TableLayoutPanel3 = New TableLayoutPanel()
        txtDaftarKamar = New Guna.UI2.WinForms.Guna2HtmlLabel()
        TableLayoutPanel4 = New TableLayoutPanel()
        TableLayoutPanel1.SuspendLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        TableLayoutPanel2.SuspendLayout()
        TableLayoutPanel3.SuspendLayout()
        SuspendLayout()
        ' 
        ' panelKamarContainer
        ' 
        panelKamarContainer.AutoScroll = True
        panelKamarContainer.Dock = DockStyle.Fill
        panelKamarContainer.Location = New Point(3, 61)
        panelKamarContainer.Name = "panelKamarContainer"
        panelKamarContainer.Size = New Size(1089, 639)
        panelKamarContainer.TabIndex = 7
        ' 
        ' btnTambahKamar
        ' 
        btnTambahKamar.BorderRadius = 15
        btnTambahKamar.Cursor = Cursors.Hand
        btnTambahKamar.CustomizableEdges = CustomizableEdges1
        btnTambahKamar.DisabledState.BorderColor = Color.DarkGray
        btnTambahKamar.DisabledState.CustomBorderColor = Color.DarkGray
        btnTambahKamar.DisabledState.FillColor = Color.FromArgb(CByte(169), CByte(169), CByte(169))
        btnTambahKamar.DisabledState.ForeColor = Color.FromArgb(CByte(141), CByte(141), CByte(141))
        btnTambahKamar.Dock = DockStyle.Right
        btnTambahKamar.FillColor = Color.FromArgb(CByte(255), CByte(219), CByte(91))
        btnTambahKamar.Font = New Font("Poppins Medium", 9F, FontStyle.Bold)
        btnTambahKamar.ForeColor = Color.Black
        btnTambahKamar.HoverState.FillColor = Color.Gold
        btnTambahKamar.Location = New Point(840, 3)
        btnTambahKamar.Name = "btnTambahKamar"
        btnTambahKamar.ShadowDecoration.CustomizableEdges = CustomizableEdges2
        btnTambahKamar.Size = New Size(246, 46)
        btnTambahKamar.TabIndex = 3
        btnTambahKamar.Text = "Tambah Kamar"
        ' 
        ' TableLayoutPanel1
        ' 
        TableLayoutPanel1.AutoSize = True
        TableLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink
        TableLayoutPanel1.BackgroundImageLayout = ImageLayout.Stretch
        TableLayoutPanel1.ColumnCount = 2
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 19.974226F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 80.02577F))
        TableLayoutPanel1.Controls.Add(PictureBox1, 0, 0)
        TableLayoutPanel1.Controls.Add(TableLayoutPanel2, 1, 0)
        TableLayoutPanel1.Dock = DockStyle.Fill
        TableLayoutPanel1.Location = New Point(0, 0)
        TableLayoutPanel1.Name = "TableLayoutPanel1"
        TableLayoutPanel1.RowCount = 1
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        TableLayoutPanel1.Size = New Size(1377, 768)
        TableLayoutPanel1.TabIndex = 8
        ' 
        ' PictureBox1
        ' 
        PictureBox1.BackgroundImageLayout = ImageLayout.Center
        PictureBox1.Dock = DockStyle.Fill
        PictureBox1.ErrorImage = My.Resources.Resources.sidebarfix
        PictureBox1.Image = My.Resources.Resources.sidebarfix
        PictureBox1.Location = New Point(3, 3)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(269, 762)
        PictureBox1.TabIndex = 1
        PictureBox1.TabStop = False
        ' 
        ' TableLayoutPanel2
        ' 
        TableLayoutPanel2.ColumnCount = 1
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        TableLayoutPanel2.Controls.Add(TableLayoutPanel3, 0, 0)
        TableLayoutPanel2.Controls.Add(TableLayoutPanel4, 0, 2)
        TableLayoutPanel2.Controls.Add(panelKamarContainer, 0, 1)
        TableLayoutPanel2.Location = New Point(278, 3)
        TableLayoutPanel2.Name = "TableLayoutPanel2"
        TableLayoutPanel2.RowCount = 3
        TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Percent, 50F))
        TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Absolute, 645F))
        TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Absolute, 59F))
        TableLayoutPanel2.Size = New Size(1095, 762)
        TableLayoutPanel2.TabIndex = 0
        ' 
        ' TableLayoutPanel3
        ' 
        TableLayoutPanel3.BackgroundImageLayout = ImageLayout.Stretch
        TableLayoutPanel3.ColumnCount = 2
        TableLayoutPanel3.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        TableLayoutPanel3.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 310F))
        TableLayoutPanel3.Controls.Add(btnTambahKamar, 1, 0)
        TableLayoutPanel3.Controls.Add(txtDaftarKamar, 0, 0)
        TableLayoutPanel3.Dock = DockStyle.Fill
        TableLayoutPanel3.Location = New Point(3, 3)
        TableLayoutPanel3.Name = "TableLayoutPanel3"
        TableLayoutPanel3.RowCount = 1
        TableLayoutPanel3.RowStyles.Add(New RowStyle(SizeType.Percent, 50F))
        TableLayoutPanel3.RowStyles.Add(New RowStyle(SizeType.Absolute, 20F))
        TableLayoutPanel3.Size = New Size(1089, 52)
        TableLayoutPanel3.TabIndex = 0
        ' 
        ' txtDaftarKamar
        ' 
        txtDaftarKamar.AccessibleRole = AccessibleRole.TitleBar
        txtDaftarKamar.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        txtDaftarKamar.AutoSize = False
        txtDaftarKamar.AutoSizeHeightOnly = True
        txtDaftarKamar.BackColor = Color.Transparent
        txtDaftarKamar.Font = New Font("Roboto Slab Medium", 13.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        txtDaftarKamar.Location = New Point(3, 3)
        txtDaftarKamar.Name = "txtDaftarKamar"
        txtDaftarKamar.Size = New Size(773, 46)
        txtDaftarKamar.TabIndex = 4
        txtDaftarKamar.Text = "Daftar Kamar"
        txtDaftarKamar.TextAlignment = ContentAlignment.MiddleLeft
        ' 
        ' TableLayoutPanel4
        ' 
        TableLayoutPanel4.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        TableLayoutPanel4.BackgroundImageLayout = ImageLayout.Stretch
        TableLayoutPanel4.ColumnCount = 2
        TableLayoutPanel4.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        TableLayoutPanel4.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 545F))
        TableLayoutPanel4.Location = New Point(3, 706)
        TableLayoutPanel4.Name = "TableLayoutPanel4"
        TableLayoutPanel4.RowCount = 1
        TableLayoutPanel4.RowStyles.Add(New RowStyle(SizeType.Percent, 50F))
        TableLayoutPanel4.Size = New Size(1089, 53)
        TableLayoutPanel4.TabIndex = 8
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1377, 768)
        Controls.Add(TableLayoutPanel1)
        Name = "Form1"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Home Page"
        TableLayoutPanel1.ResumeLayout(False)
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        TableLayoutPanel2.ResumeLayout(False)
        TableLayoutPanel3.ResumeLayout(False)
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents panelKamarContainer As FlowLayoutPanel
    Friend WithEvents btnTambahKamar As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel4 As TableLayoutPanel
    Friend WithEvents txtDaftarKamar As Guna.UI2.WinForms.Guna2HtmlLabel

End Class
