Imports Microsoft.Data.SqlClient

Public Class FormPengunjung
    Public Property KodeKamarTerpilih As String

    Private Sub FormPengunjung_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtKodeKamar.Text = KodeKamarTerpilih
        AutoGenerateIdPengunjung()
    End Sub

    Private Sub AutoGenerateIdPengunjung()
        bukaKoneksi()
        Dim cmd As New SqlCommand("SELECT TOP 1 IdPengunjung FROM Pengunjung ORDER BY IdPengunjung DESC", koneksi)
        Dim lastId = cmd.ExecuteScalar()?.ToString()
        koneksi.Close()

        Dim nomor As Integer = 1
        If Not String.IsNullOrEmpty(lastId) AndAlso lastId.Length >= 5 Then
            Integer.TryParse(lastId.Substring(2), nomor)
            nomor += 1
        End If
        txtIdPengunjung.Text = "PG" & nomor.ToString("D3")
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        If txtNoKTP.Text = "" Or txtNama.Text = "" Then
            MsgBox("Lengkapi data terlebih dahulu!")
            Exit Sub
        End If

        ' Validasi tanggal
        Dim tanggalMasuk = dtpMasuk.Value.Date
        Dim tanggalKeluar = dtpKeluar.Value.Date
        Dim durasi = (tanggalKeluar - tanggalMasuk).Days
        If durasi <= 0 Then
            MsgBox("Tanggal keluar harus setelah tanggal masuk!")
            Exit Sub
        End If

        ' 1. Simpan data pengunjung
        bukaKoneksi()
        Dim cmdPengunjung As New SqlCommand("
        INSERT INTO Pengunjung (IdPengunjung, NoKTP, Nama, Alamat, NoTelp)
        VALUES (@Id, @KTP, @Nama, @Alamat, @Telp)", koneksi)
        cmdPengunjung.Parameters.AddWithValue("@Id", txtIdPengunjung.Text)
        cmdPengunjung.Parameters.AddWithValue("@KTP", txtNoKTP.Text)
        cmdPengunjung.Parameters.AddWithValue("@Nama", txtNama.Text)
        cmdPengunjung.Parameters.AddWithValue("@Alamat", txtAlamat.Text)
        cmdPengunjung.Parameters.AddWithValue("@Telp", txtNoTelp.Text)
        cmdPengunjung.ExecuteNonQuery()
        koneksi.Close()

        ' 2. Ambil harga kamar
        bukaKoneksi()
        Dim cmdHarga As New SqlCommand("
        SELECT T.HargaPerMalam 
        FROM Kamar K 
        JOIN TipeKamar T ON K.KodeTipe = T.KodeTipe
        WHERE K.KodeKamar = @Kode", koneksi)
        cmdHarga.Parameters.AddWithValue("@Kode", KodeKamarTerpilih)
        Dim harga = CInt(cmdHarga.ExecuteScalar())
        koneksi.Close()

        Dim total = harga * durasi

        ' 3. Simpan transaksi baru
        Dim kodeTransaksi = GenerateKodeTransaksiBaru()

        bukaKoneksi()
        Dim cmdTransaksi As New SqlCommand("
        INSERT INTO Transaksi (KodeTransaksi, IdPengunjung, KodeKamar, TanggalMasuk, TanggalKeluar, Durasi, TotalBayar, StatusTransaksi)
        VALUES (@KodeTrans, @IdPengunjung, @KodeKamar, @TglMasuk, @TglKeluar, @Durasi, @Total, 'Aktif')", koneksi)
        cmdTransaksi.Parameters.AddWithValue("@KodeTrans", kodeTransaksi)
        cmdTransaksi.Parameters.AddWithValue("@IdPengunjung", txtIdPengunjung.Text)
        cmdTransaksi.Parameters.AddWithValue("@KodeKamar", KodeKamarTerpilih)
        cmdTransaksi.Parameters.AddWithValue("@TglMasuk", tanggalMasuk)
        cmdTransaksi.Parameters.AddWithValue("@TglKeluar", tanggalKeluar)
        cmdTransaksi.Parameters.AddWithValue("@Durasi", durasi)
        cmdTransaksi.Parameters.AddWithValue("@Total", total)
        cmdTransaksi.ExecuteNonQuery()
        koneksi.Close()

        ' 4. Update status kamar
        bukaKoneksi()
        Dim cmdUpdate As New SqlCommand("
        UPDATE Kamar SET Status = 'Terisi' WHERE KodeKamar = @Kode", koneksi)
        cmdUpdate.Parameters.AddWithValue("@Kode", KodeKamarTerpilih)
        cmdUpdate.ExecuteNonQuery()
        koneksi.Close()

        MsgBox("Check-in berhasil!")
        Me.Close()
    End Sub


    Private Function GenerateKodeTransaksiBaru() As String
        bukaKoneksi()
        Dim today As String = DateTime.Now.ToString("ddMM")
        Dim cmd As New SqlCommand("
            SELECT TOP 1 KodeTransaksi FROM Transaksi 
            WHERE KodeTransaksi LIKE 'TR" & today & "%' 
            ORDER BY KodeTransaksi DESC", koneksi)
        Dim lastKode As String = cmd.ExecuteScalar()?.ToString()
        koneksi.Close()

        Dim nomor As Integer = 1
        If Not String.IsNullOrEmpty(lastKode) AndAlso lastKode.Length >= 9 Then
            Integer.TryParse(lastKode.Substring(6), nomor)
            nomor += 1
        End If

        Return "TR" & today & nomor.ToString("D3")
    End Function
End Class
