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
        Dim CustomizableEdges3 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges4 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges5 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges6 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        txtDaftarKamar = New Guna.UI2.WinForms.Guna2HtmlLabel()
        btnTambahKamar = New Guna.UI2.WinForms.Guna2Button()
        panelKamarContainer = New FlowLayoutPanel()
        SplitContainer1 = New SplitContainer()
        btnSlipPembayaran = New Guna.UI2.WinForms.Guna2Button()
        btnDaftarPengunjung = New Guna.UI2.WinForms.Guna2Button()
        CType(SplitContainer1, ComponentModel.ISupportInitialize).BeginInit()
        SplitContainer1.Panel1.SuspendLayout()
        SplitContainer1.Panel2.SuspendLayout()
        SplitContainer1.SuspendLayout()
        SuspendLayout()
        ' 
        ' txtDaftarKamar
        ' 
        txtDaftarKamar.BackColor = Color.Transparent
        txtDaftarKamar.Dock = DockStyle.Left
        txtDaftarKamar.Font = New Font("Poppins Medium", 13.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        txtDaftarKamar.Location = New Point(0, 0)
        txtDaftarKamar.Name = "txtDaftarKamar"
        txtDaftarKamar.Size = New Size(175, 42)
        txtDaftarKamar.TabIndex = 2
        txtDaftarKamar.Text = "Daftar Kamar"
        txtDaftarKamar.TextAlignment = ContentAlignment.MiddleLeft
        ' 
        ' btnTambahKamar
        ' 
        btnTambahKamar.BorderRadius = 15
        btnTambahKamar.CustomizableEdges = CustomizableEdges1
        btnTambahKamar.DisabledState.BorderColor = Color.DarkGray
        btnTambahKamar.DisabledState.CustomBorderColor = Color.DarkGray
        btnTambahKamar.DisabledState.FillColor = Color.FromArgb(CByte(169), CByte(169), CByte(169))
        btnTambahKamar.DisabledState.ForeColor = Color.FromArgb(CByte(141), CByte(141), CByte(141))
        btnTambahKamar.Font = New Font("Poppins Medium", 9F, FontStyle.Bold)
        btnTambahKamar.ForeColor = Color.White
        btnTambahKamar.Location = New Point(16, 99)
        btnTambahKamar.Name = "btnTambahKamar"
        btnTambahKamar.ShadowDecoration.CustomizableEdges = CustomizableEdges2
        btnTambahKamar.Size = New Size(172, 54)
        btnTambahKamar.TabIndex = 3
        btnTambahKamar.Text = "Tambah Kamar"
        ' 
        ' panelKamarContainer
        ' 
        panelKamarContainer.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        panelKamarContainer.AutoScroll = True
        panelKamarContainer.Location = New Point(3, 60)
        panelKamarContainer.Name = "panelKamarContainer"
        panelKamarContainer.Size = New Size(576, 378)
        panelKamarContainer.TabIndex = 7
        ' 
        ' SplitContainer1
        ' 
        SplitContainer1.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        SplitContainer1.Location = New Point(0, 0)
        SplitContainer1.Name = "SplitContainer1"
        ' 
        ' SplitContainer1.Panel1
        ' 
        SplitContainer1.Panel1.Controls.Add(btnSlipPembayaran)
        SplitContainer1.Panel1.Controls.Add(btnTambahKamar)
        SplitContainer1.Panel1.Controls.Add(btnDaftarPengunjung)
        ' 
        ' SplitContainer1.Panel2
        ' 
        SplitContainer1.Panel2.Controls.Add(panelKamarContainer)
        SplitContainer1.Panel2.Controls.Add(txtDaftarKamar)
        SplitContainer1.Size = New Size(800, 450)
        SplitContainer1.SplitterDistance = 214
        SplitContainer1.TabIndex = 9
        ' 
        ' btnSlipPembayaran
        ' 
        btnSlipPembayaran.BorderRadius = 15
        btnSlipPembayaran.CustomizableEdges = CustomizableEdges3
        btnSlipPembayaran.DisabledState.BorderColor = Color.DarkGray
        btnSlipPembayaran.DisabledState.CustomBorderColor = Color.DarkGray
        btnSlipPembayaran.DisabledState.FillColor = Color.FromArgb(CByte(169), CByte(169), CByte(169))
        btnSlipPembayaran.DisabledState.ForeColor = Color.FromArgb(CByte(141), CByte(141), CByte(141))
        btnSlipPembayaran.Font = New Font("Poppins Medium", 9F, FontStyle.Bold)
        btnSlipPembayaran.ForeColor = Color.White
        btnSlipPembayaran.Location = New Point(16, 273)
        btnSlipPembayaran.Name = "btnSlipPembayaran"
        btnSlipPembayaran.ShadowDecoration.CustomizableEdges = CustomizableEdges4
        btnSlipPembayaran.Size = New Size(172, 64)
        btnSlipPembayaran.TabIndex = 6
        btnSlipPembayaran.Text = "Slip Pembayaran"
        ' 
        ' btnDaftarPengunjung
        ' 
        btnDaftarPengunjung.BorderRadius = 15
        btnDaftarPengunjung.CustomizableEdges = CustomizableEdges5
        btnDaftarPengunjung.DisabledState.BorderColor = Color.DarkGray
        btnDaftarPengunjung.DisabledState.CustomBorderColor = Color.DarkGray
        btnDaftarPengunjung.DisabledState.FillColor = Color.FromArgb(CByte(169), CByte(169), CByte(169))
        btnDaftarPengunjung.DisabledState.ForeColor = Color.FromArgb(CByte(141), CByte(141), CByte(141))
        btnDaftarPengunjung.Font = New Font("Poppins Medium", 9F, FontStyle.Bold)
        btnDaftarPengunjung.ForeColor = Color.White
        btnDaftarPengunjung.Location = New Point(16, 178)
        btnDaftarPengunjung.Name = "btnDaftarPengunjung"
        btnDaftarPengunjung.ShadowDecoration.CustomizableEdges = CustomizableEdges6
        btnDaftarPengunjung.Size = New Size(172, 67)
        btnDaftarPengunjung.TabIndex = 5
        btnDaftarPengunjung.Text = "Daftar Pengunjung"
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(SplitContainer1)
        Name = "Form1"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Home Page"
        SplitContainer1.Panel1.ResumeLayout(False)
        SplitContainer1.Panel2.ResumeLayout(False)
        SplitContainer1.Panel2.PerformLayout()
        CType(SplitContainer1, ComponentModel.ISupportInitialize).EndInit()
        SplitContainer1.ResumeLayout(False)
        ResumeLayout(False)
    End Sub
    Friend WithEvents txtDaftarKamar As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents btnTambahKamar As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents panelKamarContainer As FlowLayoutPanel
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents btnSlipPembayaran As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnDaftarPengunjung As Guna.UI2.WinForms.Guna2Button

End Class
