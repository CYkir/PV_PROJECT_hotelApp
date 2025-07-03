Imports Microsoft.Data.SqlClient
Module ModuleKoneksi
    Public koneksi As SqlConnection

    Public Sub bukaKoneksi()
        koneksi = New SqlConnection("Data Source=CYKIR\SQLEXPRESS;Initial Catalog=dbHotel;Integrated Security=True; TrustServerCertificate=True")
        If koneksi.State = ConnectionState.Closed Then
            koneksi.Open()
        End If
    End Sub

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

