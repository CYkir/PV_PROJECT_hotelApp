Imports Microsoft.Data.SqlClient
Imports System.Diagnostics



Public Class Form1
    Dim koneksi As New SqlConnection("Data Source=CYKIR\SQLEXPRESS;Initial Catalog=dbHotel;Integrated Security=True;TrustServerCertificate=True")

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.AutoScaleMode = AutoScaleMode.Dpi


        panelKamarContainer.Dock = DockStyle.Fill
        panelKamarContainer.AutoScroll = True


        TampilkanKamar()
    End Sub

    Private Sub TampilkanKamar()
        panelKamarContainer.Controls.Clear()

        Dim query As String = "
            SELECT K.KodeKamar, K.NoKamar, K.GambarPath, K.Status, T.NamaTipe 
            FROM Kamar K 
            JOIN TipeKamar T ON K.KodeTipe = T.KodeTipe
        "

        Dim cmd As New SqlCommand(query, koneksi)
        koneksi.Open()
        Dim reader = cmd.ExecuteReader()
        Dim Count As Integer = 0
        While reader.Read()
            Count += 1
            Debug.WriteLine($"Data ke-{Count}: {reader("NoKamar")} - {reader("GambarPath")}")
            ' Buat panel kartu kamar
            Dim panelKamar As New Guna.UI2.WinForms.Guna2ShadowPanel With {
                .Size = New Size(200, 240),
                .Margin = New Padding(10),
                .BackColor = Color.White
            }

            ' Gambar kamar
            Dim pb As New Guna.UI2.WinForms.Guna2PictureBox With {
    .Size = New Size(180, 100),
    .Location = New Point(10, 10),
    .SizeMode = PictureBoxSizeMode.StretchImage
}

            Dim pathGambar = reader("GambarPath").ToString()
            If IO.File.Exists(pathGambar) Then
                Try
                    Using img = Image.FromFile(pathGambar)
                        pb.Image = New Bitmap(img)
                    End Using
                Catch ex As Exception
                    ' Jika error (misal file corrupt), kosongkan gambar
                    pb.Image = Nothing
                End Try
            End If

            ' Label info kamar
            Dim lblInfo As New Label With {
                .Text = $"No: {reader("NoKamar")} ({reader("NamaTipe")})",
                .Location = New Point(10, 120),
                .Size = New Size(180, 20)
            }

            ' Label status
            Dim lblStatus As New Label With {
                .Text = $"Status: {reader("Status")}",
                .Location = New Point(10, 145),
                .Size = New Size(180, 20),
                .ForeColor = If(reader("Status").ToString().ToLower() = "kosong", Color.Green, Color.Red)
            }

            ' Tombol aksi (Check In / Check Out)
            Dim btnAksi As New Guna.UI2.WinForms.Guna2Button With {
                .Text = If(reader("Status").ToString().ToLower() = "kosong", "Check In", "Check Out"),
                .Size = New Size(160, 30),
                .Location = New Point(10, 180),
                .Tag = reader("KodeKamar").ToString()
            }
            AddHandler btnAksi.Click, AddressOf AksiKamar_Click

            ' Tambahkan semua komponen ke dalam panel kamar
            panelKamar.Controls.Add(pb)
            panelKamar.Controls.Add(lblInfo)
            panelKamar.Controls.Add(lblStatus)
            panelKamar.Controls.Add(btnAksi)

            ' Tambahkan panel kamar ke dalam container utama
            panelKamarContainer.Controls.Add(panelKamar)
        End While

        koneksi.Close()
    End Sub

    Private Sub AksiKamar_Click(sender As Object, e As EventArgs)
        Dim kodeKamar = CType(sender, Guna.UI2.WinForms.Guna2Button).Tag.ToString()
        Dim tombol = CType(sender, Guna.UI2.WinForms.Guna2Button)

        If tombol.Text = "Check In" Then
            Dim form As New FormPengunjung
            ' form.kodeKamarTerpilih = kodeKamar ' Jika pakai passing
            form.ShowDialog()
        Else
            Dim form As New FormTransaksi
            ' form.kodeKamarTerpilih = kodeKamar
            form.ShowDialog()
        End If

        ' Refresh ulang tampilan kamar
        TampilkanKamar()
    End Sub

    Private Sub btnTambahKamar_Click(sender As Object, e As EventArgs) Handles btnTambahKamar.Click
        FormKamar.ShowDialog()
        TampilkanKamar()
    End Sub

    Private Sub btnSlipPembayaran_Click(sender As Object, e As EventArgs) Handles btnSlipPembayaran.Click
        FormSlipPembayaran.ShowDialog()
    End Sub

    Private Sub btnDaftarPengunjung_Click(sender As Object, e As EventArgs) Handles btnDaftarPengunjung.Click
        FormPengunjung.ShowDialog()
    End Sub


End Class
