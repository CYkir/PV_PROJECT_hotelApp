Imports Microsoft.Data.SqlClient
Module ModuleKoneksi
    Public koneksi As SqlConnection

    Public Sub bukaKoneksi()
        koneksi = New SqlConnection("Data Source=CYKIR\SQLEXPRESS;Initial Catalog=dbHotel;Integrated Security=True; TrustServerCertificate=True")
        If koneksi.State = ConnectionState.Closed Then
            koneksi.Open()
        End If
    End Sub

    'generate kode kamar
    Public Function GenerateKodeKamar()
        bukaKoneksi()
        Dim cmd As New SqlCommand("SELECT TOP 1 KodeKamar FROM Kamar ORDER BY KodeKamar DESC", koneksi)
        Dim lastKode As String = cmd.ExecuteScalar()?.ToString()
        koneksi.Close()

        Dim nomor As Integer = 1
        If Not String.IsNullOrEmpty(lastKode) AndAlso lastKode.Length >= 5 Then
            Integer.TryParse(lastKode.Substring(2), nomor)
            nomor += 1
        End If

        Return "KM" & nomor.ToString("D3")
    End Function

    'generate id pengunjung 
    Public Function GenerateIdPengunjung() As String
        bukaKoneksi()
        Dim cmd As New SqlCommand("SELECT TOP 1 IdPengunjung FROM Pengunjung ORDER BY IdPengunjung DESC", koneksi)
        Dim lastId As String = cmd.ExecuteScalar()?.ToString()
        koneksi.Close()

        Dim nomor As Integer = 1
        If Not String.IsNullOrEmpty(lastId) AndAlso lastId.Length >= 5 Then
            Integer.TryParse(lastId.Substring(2), nomor)
            nomor += 1
        End If
        Return "PG" & nomor.ToString("D3")
    End Function


    'generate kode transaksi
    Public Function GenerateKodeTransaksiBaru() As String
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

End Module

