Imports Microsoft.Data.SqlClient
Imports System.IO


Public Class Form1

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

        bukaKoneksi() ' Panggil koneksi dari modul
        Dim cmd As New SqlCommand(query, koneksi)
        Dim reader = cmd.ExecuteReader()
        Dim Count As Integer = 0

        While reader.Read()
            Count += 1
            Debug.WriteLine($"Data ke-{Count}: {reader("NoKamar")} - {reader("GambarPath")}")

            ' Panel kamar
            Dim panelKamar As New Guna.UI2.WinForms.Guna2ShadowPanel With {
                .Size = New Size(200, 240),
                .Margin = New Padding(10),
                .BackColor = Color.White
            }

            ' Gambar
            Dim pb As New Guna.UI2.WinForms.Guna2PictureBox With {
                .Size = New Size(180, 100),
                .Location = New Point(10, 10),
                .SizeMode = PictureBoxSizeMode.StretchImage
            }

            Dim pathGambar = reader("GambarPath").ToString()
            If File.Exists(pathGambar) Then
                Try
                    Using img = Image.FromFile(pathGambar)
                        pb.Image = New Bitmap(img)
                    End Using
                Catch ex As Exception
                    pb.Image = Nothing
                End Try
            End If

            ' Info kamar
            Dim lblInfo As New Label With {
                .Text = $"No: {reader("NoKamar")} ({reader("NamaTipe")})",
                .Location = New Point(10, 120),
                .Size = New Size(180, 20)
            }

            ' Status
            Dim statusText = reader("Status").ToString()
            Dim lblStatus As New Label With {
                .Text = $"Status: {statusText}",
                .Location = New Point(10, 145),
                .Size = New Size(180, 20),
                .ForeColor = If(statusText.ToLower() = "kosong", Color.Green, Color.Red)
            }

            ' Tombol aksi
            Dim btnAksi As New Guna.UI2.WinForms.Guna2Button With {
                .Text = If(statusText.ToLower() = "kosong", "Check In", "Check Out"),
                .Size = New Size(160, 30),
                .Location = New Point(10, 180),
                .Tag = reader("KodeKamar").ToString()
            }
            AddHandler btnAksi.Click, AddressOf AksiKamar_Click

            ' Tambah ke panel
            panelKamar.Controls.Add(pb)
            panelKamar.Controls.Add(lblInfo)
            panelKamar.Controls.Add(lblStatus)
            panelKamar.Controls.Add(btnAksi)

            panelKamarContainer.Controls.Add(panelKamar)
        End While

        koneksi.Close()
    End Sub

    Private Sub AksiKamar_Click(sender As Object, e As EventArgs)
        Dim kodeKamar = CType(sender, Guna.UI2.WinForms.Guna2Button).Tag.ToString()
        Dim tombol = CType(sender, Guna.UI2.WinForms.Guna2Button)

        If tombol.Text = "Check In" Then
            Dim form As New FormPengunjung
            form.KodeKamarTerpilih = kodeKamar
            form.ShowDialog()
        Else
            Dim form As New FormTransaksi
            form.KodeKamarTerpilih = kodeKamar
            form.Mode = "CheckOut"
            form.ShowDialog()
        End If

        ' Refresh tampilan
        TampilkanKamar()
    End Sub
End Class
