Imports Microsoft.Data.SqlClient

Public Class FormTransaksi
    Public Property KodeKamarTerpilih As String
    Public Property Mode As String = "CheckIn"

    Private Sub FormTransaksi_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Mode = "CheckIn" Then
            GenerateKodeTransaksiBaru()

        ElseIf Mode = "CheckOut" Then
            Dim sukses = LoadDataTransaksi()

            If Not sukses Then
                MsgBox("Tidak ada transaksi aktif untuk kamar ini.", MsgBoxStyle.Exclamation)
                Me.Close()
            End If
        End If
    End Sub

    Private Function LoadDataTransaksi() As Boolean
        bukaKoneksi()
        Dim query As String = "
        SELECT TOP 1 T.KodeTransaksi, P.Nama, P.NoKTP, P.NoTelp, 
               T.TanggalMasuk, T.TanggalKeluar, T.Durasi, T.TotalBayar 
        FROM Transaksi T 
        JOIN Pengunjung P ON T.IdPengunjung = P.IdPengunjung
        WHERE T.KodeKamar = @KodeKamar AND T.StatusTransaksi = 'Aktif'
        ORDER BY T.TanggalMasuk DESC"
        Dim cmd As New SqlCommand(query, koneksi)
        cmd.Parameters.AddWithValue("@KodeKamar", KodeKamarTerpilih)
        Dim reader = cmd.ExecuteReader()

        If reader.Read() Then
            lblKodeTransaksi.Text = reader("KodeTransaksi").ToString()
            lblNamaPengunjung.Text = reader("Nama").ToString()
            lblKTP.Text = reader("NoKTP").ToString()
            lblTglMasuk.Text = CDate(reader("TanggalMasuk")).ToShortDateString()
            lblTglKeluar.Text = CDate(reader("TanggalKeluar")).ToShortDateString()
            lblDurasi.Text = reader("Durasi").ToString() & " malam"
            lblTotalBayar.Text = "Rp " & Format(reader("TotalBayar"), "#,##0")
            koneksi.Close()
            Return True
        Else
            koneksi.Close()
            Return False
        End If
    End Function


    Private Sub btnCheckOut_Click(sender As Object, e As EventArgs) Handles btnCheckout.Click
        ' Ubah status transaksi jadi selesai
        bukaKoneksi()
        Dim cmd1 As New SqlCommand("
        UPDATE Transaksi SET StatusTransaksi = 'Selesai' 
        WHERE KodeTransaksi = @Kode", koneksi)
        cmd1.Parameters.AddWithValue("@Kode", lblKodeTransaksi.Text)
        cmd1.ExecuteNonQuery()

        ' Ubah kamar jadi kosong
        Dim cmd2 As New SqlCommand("
        UPDATE Kamar SET Status = 'Kosong' 
        WHERE KodeKamar = @Kode", koneksi)
        cmd2.Parameters.AddWithValue("@Kode", KodeKamarTerpilih)
        cmd2.ExecuteNonQuery()
        koneksi.Close()

        ' Tampilkan slip pembayaran
        Dim form As New FormSlipPembayaran
        form.KodeTransaksiTerpilih = lblKodeTransaksi.Text
        form.ShowDialog()
        Me.Close()
    End Sub


    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        Me.Close()
    End Sub

End Class