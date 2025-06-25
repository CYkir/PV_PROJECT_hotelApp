Imports Microsoft.Data.SqlClient
Module ModuleKoneksi
    Public koneksi As SqlConnection

    Public Sub bukaKoneksi()
        koneksi = New SqlConnection("Data Source=CYKIR\SQLEXPRESS;Initial Catalog=dbHotel;Integrated Security=True; TrustServerCertificate=True")
        If koneksi.State = ConnectionState.Closed Then
            koneksi.Open()
        End If
    End Sub
End Module
