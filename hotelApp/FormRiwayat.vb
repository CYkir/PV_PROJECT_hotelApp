Imports Microsoft.Data.SqlClient

Public Class FormRiwayat
    Private Sub FormRiwayat_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadRiwayat()
    End Sub

    Private Sub LoadRiwayat()
        bukaKoneksi()

        Dim query As String = "
        SELECT 
            T.KodeTransaksi,
            P.Nama AS NamaPengunjung,
            K.NoKamar,
            TK.NamaTipe,
            T.TanggalMasuk,
            T.TanggalKeluar,
            T.Durasi,
            T.TotalBayar
        FROM Transaksi T
        JOIN Pengunjung P ON T.IdPengunjung = P.IdPengunjung
        JOIN Kamar K ON T.KodeKamar = K.KodeKamar
        JOIN TipeKamar TK ON K.KodeTipe = TK.KodeTipe
        ORDER BY T.TanggalKeluar DESC
    "

        Dim adapter As New SqlDataAdapter(query, koneksi)
        Dim ds As New DataSet()
        adapter.Fill(ds, "Riwayat")

        ' Tambahkan kolom baru: TotalBayarDisplay
        ds.Tables("Riwayat").Columns.Add("TotalBayarDisplay", GetType(String))
        For Each row As DataRow In ds.Tables("Riwayat").Rows
            Dim total As Integer = Convert.ToInt32(row("TotalBayar"))
            row("TotalBayarDisplay") = "Rp. " & total.ToString("N0")
        Next

        ' Tampilkan hanya kolom yang diperlukan
        dgvRiwayat.DataSource = Nothing
        dgvRiwayat.Columns.Clear()
        dgvRiwayat.DataSource = ds.Tables("Riwayat")

        ' Sembunyikan kolom TotalBayar asli
        dgvRiwayat.Columns("TotalBayar").Visible = False

        ' Ubah header kolom
        dgvRiwayat.Columns("KodeTransaksi").HeaderText = "Kode Transaksi"
        dgvRiwayat.Columns("NamaPengunjung").HeaderText = "Nama Pengunjung"
        dgvRiwayat.Columns("NoKamar").HeaderText = "No. Kamar"
        dgvRiwayat.Columns("NamaTipe").HeaderText = "Tipe Kamar"
        dgvRiwayat.Columns("TanggalMasuk").HeaderText = "Tgl Masuk"
        dgvRiwayat.Columns("TanggalKeluar").HeaderText = "Tgl Keluar"
        dgvRiwayat.Columns("Durasi").HeaderText = "Durasi (mlm)"
        dgvRiwayat.Columns("TotalBayarDisplay").HeaderText = "Total Bayar"

        dgvRiwayat.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        koneksi.Close()
    End Sub


    Private Sub btnTutup_Click(sender As Object, e As EventArgs) Handles btnTutup.Click
        Me.Close()
    End Sub

    Private Sub TableLayoutPanel1_Paint(sender As Object, e As PaintEventArgs) Handles TableLayoutPanel1.Paint

    End Sub
End Class