Imports Microsoft.Data.SqlClient
Imports System.IO

Public Class FormKamar
    Dim adapter As SqlDataAdapter
    Dim dataset As DataSet
    Dim gambarDipilih As String = ""

    Private Sub GenerateKodeKamar()
        bukaKoneksi()
        Dim cmd As New SqlCommand("SELECT TOP 1 KodeKamar FROM Kamar ORDER BY KodeKamar DESC", koneksi)
        Dim lastKode As String = cmd.ExecuteScalar()?.ToString()
        koneksi.Close()

        Dim nomor As Integer = 1
        If Not String.IsNullOrEmpty(lastKode) AndAlso lastKode.Length >= 5 Then
            Integer.TryParse(lastKode.Substring(2), nomor)
            nomor += 1
        End If

        txtKodeKamar.Text = "KM" & nomor.ToString("D3")
    End Sub

    Private Sub FormKamar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadData()
        LoadTipeKamar()
        LoadStatus()
        GenerateKodeKamar()
    End Sub

    Private Sub LoadData()
        bukaKoneksi()
        Dim query As String = "
            SELECT K.KodeKamar, K.NoKamar, T.NamaTipe, K.Status, K.GambarPath 
            FROM Kamar K 
            JOIN TipeKamar T ON K.KodeTipe = T.KodeTipe"
        adapter = New SqlDataAdapter(query, koneksi)
        dataset = New DataSet()
        adapter.Fill(dataset, "Kamar")
        dgvKamar.DataSource = dataset.Tables("Kamar")
        koneksi.Close()
    End Sub

    Private Sub LoadTipeKamar()
        bukaKoneksi()
        cmbTipeKamar.Items.Clear()
        Dim cmd As New SqlCommand("SELECT NamaTipe FROM TipeKamar", koneksi)
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        While reader.Read()
            cmbTipeKamar.Items.Add(reader("NamaTipe").ToString())
        End While
        koneksi.Close()
    End Sub

    Private Sub LoadStatus()
        cmbStatus.Items.Clear()
        cmbStatus.Items.Add("Kosong")
        cmbStatus.Items.Add("Terisi")
        cmbStatus.SelectedIndex = 0
    End Sub

    Private Sub btnPilihGambar_Click(sender As Object, e As EventArgs) Handles btnPilihGambar.Click
        Dim ofd As New OpenFileDialog()
        ofd.Filter = "Gambar|*.jpg;*.png;*.jpeg"
        If ofd.ShowDialog() = DialogResult.OK Then
            gambarDipilih = ofd.FileName
            pictureBoxKamar.Image = Image.FromStream(New MemoryStream(File.ReadAllBytes(gambarDipilih)))
        End If
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        If txtKodeKamar.Text = "" Or txtNoKamar.Text = "" Or cmbTipeKamar.Text = "" Or cmbStatus.Text = "" Then
            MsgBox("Mohon lengkapi semua data!")
            Exit Sub
        End If

        bukaKoneksi()
        Dim cmd As New SqlCommand("
            INSERT INTO Kamar (KodeKamar, NoKamar, KodeTipe, Status, GambarPath)
            VALUES (@Kode, @No, (SELECT KodeTipe FROM TipeKamar WHERE NamaTipe=@Tipe), @Status, @Path)", koneksi)
        cmd.Parameters.AddWithValue("@Kode", txtKodeKamar.Text)
        cmd.Parameters.AddWithValue("@No", txtNoKamar.Text)
        cmd.Parameters.AddWithValue("@Tipe", cmbTipeKamar.Text)
        cmd.Parameters.AddWithValue("@Status", cmbStatus.Text)
        cmd.Parameters.AddWithValue("@Path", gambarDipilih)
        cmd.ExecuteNonQuery()
        MsgBox("Data berhasil disimpan")
        LoadData()
        Bersihkan()
        koneksi.Close()
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If txtKodeKamar.Text = "" Then
            MsgBox("Pilih data kamar yang akan diubah!")
            Exit Sub
        End If

        bukaKoneksi()
        Dim cmd As New SqlCommand("
            UPDATE Kamar 
            SET NoKamar=@No, 
                KodeTipe=(SELECT KodeTipe FROM TipeKamar WHERE NamaTipe=@Tipe), 
                Status=@Status, 
                GambarPath=@Path 
            WHERE KodeKamar=@Kode", koneksi)
        cmd.Parameters.AddWithValue("@Kode", txtKodeKamar.Text)
        cmd.Parameters.AddWithValue("@No", txtNoKamar.Text)
        cmd.Parameters.AddWithValue("@Tipe", cmbTipeKamar.Text)
        cmd.Parameters.AddWithValue("@Status", cmbStatus.Text)
        cmd.Parameters.AddWithValue("@Path", gambarDipilih)
        cmd.ExecuteNonQuery()
        MsgBox("Data berhasil diubah")
        LoadData()
        Bersihkan()
        koneksi.Close()
    End Sub

    Private Sub btnHapus_Click(sender As Object, e As EventArgs) Handles btnHapus.Click
        If txtKodeKamar.Text = "" Then
            MsgBox("Pilih data kamar yang akan dihapus!")
            Exit Sub
        End If

        bukaKoneksi()
        Dim cmd As New SqlCommand("DELETE FROM Kamar WHERE KodeKamar=@Kode", koneksi)
        cmd.Parameters.AddWithValue("@Kode", txtKodeKamar.Text)
        cmd.ExecuteNonQuery()
        MsgBox("Data berhasil dihapus")
        LoadData()
        Bersihkan()
        koneksi.Close()
    End Sub

    Private Sub dgvKamar_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvKamar.CellClick
        If e.RowIndex >= 0 Then
            Dim i As Integer = dgvKamar.CurrentRow.Index
            txtKodeKamar.Text = dgvKamar.Item(0, i).Value.ToString()
            txtNoKamar.Text = dgvKamar.Item(1, i).Value.ToString()
            cmbTipeKamar.Text = dgvKamar.Item(2, i).Value.ToString()
            cmbStatus.Text = dgvKamar.Item(3, i).Value.ToString()
            gambarDipilih = dgvKamar.Item(4, i).Value.ToString()

            If File.Exists(gambarDipilih) Then
                pictureBoxKamar.Image = Image.FromStream(New MemoryStream(File.ReadAllBytes(gambarDipilih)))
            Else
                pictureBoxKamar.Image = Nothing
            End If
        End If
    End Sub

    Private Sub Bersihkan()
        txtKodeKamar.Clear()
        txtNoKamar.Clear()
        cmbTipeKamar.SelectedIndex = -1
        cmbStatus.SelectedIndex = 0
        pictureBoxKamar.Image = Nothing
        gambarDipilih = ""
    End Sub
End Class
