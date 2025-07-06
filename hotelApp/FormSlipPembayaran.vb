Imports Microsoft.Data.SqlClient
Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf

Public Class FormSlipPembayaran
    Public Property KodeTransaksiTerpilih As String

    Private Sub FormSlipPembayaran_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadSlip()
    End Sub

    Private Sub LoadSlip()
        bukaKoneksi()
        Dim query As String = "
            SELECT T.KodeTransaksi, P.Nama, P.NoKTP, P.NoTelp, T.TanggalMasuk, T.TanggalKeluar, 
                   K.NoKamar, TK.NamaTipe, TK.HargaPerMalam, T.Durasi, T.TotalBayar
            FROM Transaksi T 
            JOIN Pengunjung P ON T.IdPengunjung = P.IdPengunjung
            JOIN Kamar K ON T.KodeKamar = K.KodeKamar
            JOIN TipeKamar TK ON K.KodeTipe = TK.KodeTipe
            WHERE T.KodeTransaksi = @Kode"
        Dim cmd As New SqlCommand(query, koneksi)
        cmd.Parameters.AddWithValue("@Kode", KodeTransaksiTerpilih)
        Dim reader = cmd.ExecuteReader()
        If reader.Read() Then
            lblKodeTransaksi.Text = reader("KodeTransaksi").ToString()
            lblNamaPengunjung.Text = reader("Nama").ToString()
            lblKTP.Text = reader("NoKTP").ToString()
            lblTelp.Text = reader("NoTelp").ToString()
            lblTglMasuk.Text = CDate(reader("TanggalMasuk")).ToShortDateString()
            lblTglKeluar.Text = CDate(reader("TanggalKeluar")).ToShortDateString()
            lblNoKamar.Text = reader("NoKamar").ToString()
            lblTipeKamar.Text = reader("NamaTipe").ToString()
            lblHarga.Text = "Rp " & Format(reader("HargaPerMalam"), "#,##0")
            lblDurasi.Text = reader("Durasi").ToString() & " malam"
            lblTotalBayar.Text = "Rp " & Format(reader("TotalBayar"), "#,##0")
        End If
        koneksi.Close()
    End Sub

    Private Sub btnCetakPDF_Click(sender As Object, e As EventArgs) Handles btnCetakPDF.Click
        Dim saveFile As New SaveFileDialog()
        saveFile.Filter = "PDF File|*.pdf"
        saveFile.Title = "Simpan Slip Pembayaran"
        saveFile.FileName = "Slip_" & KodeTransaksiTerpilih & ".pdf"

        If saveFile.ShowDialog() = DialogResult.OK Then
            Try
                ' Buat ukuran kertas kecil seperti struk mini market
                Dim ukuranKertas As New Rectangle(226, 500) ' 226 pt ≈ 8 cm, tinggi disesuaikan
                Dim doc As New Document(ukuranKertas, 10, 10, 10, 10)
                PdfWriter.GetInstance(doc, New FileStream(saveFile.FileName, FileMode.Create))
                doc.Open()

                ' === LOAD FONT Poppins ===
                Dim pathFontRegular = Path.Combine(Application.StartupPath, "fonts\Poppins-Regular.ttf")
                Dim pathFontBold = Path.Combine(Application.StartupPath, "fonts\Poppins-Bold.ttf")


                Dim baseFontRegular = BaseFont.CreateFont(pathFontRegular, BaseFont.IDENTITY_H, BaseFont.EMBEDDED)
                Dim baseFontBold = BaseFont.CreateFont(pathFontBold, BaseFont.IDENTITY_H, BaseFont.EMBEDDED)

                Dim fontIsi As New iTextSharp.text.Font(baseFontRegular, 8)
                Dim fontBold As New iTextSharp.text.Font(baseFontBold, 8)
                Dim fontJudul As New iTextSharp.text.Font(baseFontBold, 10)


                ' Header
                doc.Add(New Paragraph("AKIRA HOTEL", fontJudul) With {.Alignment = Element.ALIGN_CENTER})
                doc.Add(New Paragraph("Jl. Kayangan No.123, Kota Khayalan", fontIsi) With {.Alignment = Element.ALIGN_CENTER})
                doc.Add(New Paragraph("Telp: 0812-1263-1234", fontIsi) With {.Alignment = Element.ALIGN_CENTER})
                doc.Add(New Paragraph("===================================", fontIsi))

                ' Info transaksi
                Dim table As New PdfPTable(2)
                table.WidthPercentage = 100
                table.SetWidths({40, 60})

                table.AddCell(New PdfPCell(New Phrase("Kode Transaksi", fontIsi)) With {.Border = Rectangle.NO_BORDER})
                table.AddCell(New PdfPCell(New Phrase(lblKodeTransaksi.Text, fontIsi)) With {.Border = Rectangle.NO_BORDER})

                table.AddCell(New PdfPCell(New Phrase("Nama", fontIsi)) With {.Border = Rectangle.NO_BORDER})
                table.AddCell(New PdfPCell(New Phrase(lblNamaPengunjung.Text, fontIsi)) With {.Border = Rectangle.NO_BORDER})

                table.AddCell(New PdfPCell(New Phrase("No KTP", fontIsi)) With {.Border = Rectangle.NO_BORDER})
                table.AddCell(New PdfPCell(New Phrase(lblKTP.Text, fontIsi)) With {.Border = Rectangle.NO_BORDER})

                table.AddCell(New PdfPCell(New Phrase("No Telp", fontIsi)) With {.Border = Rectangle.NO_BORDER})
                table.AddCell(New PdfPCell(New Phrase(lblTelp.Text, fontIsi)) With {.Border = Rectangle.NO_BORDER})

                table.AddCell(New PdfPCell(New Phrase("No Kamar", fontIsi)) With {.Border = Rectangle.NO_BORDER})
                table.AddCell(New PdfPCell(New Phrase(lblNoKamar.Text, fontIsi)) With {.Border = Rectangle.NO_BORDER})

                table.AddCell(New PdfPCell(New Phrase("Tipe Kamar", fontIsi)) With {.Border = Rectangle.NO_BORDER})
                table.AddCell(New PdfPCell(New Phrase(lblTipeKamar.Text, fontIsi)) With {.Border = Rectangle.NO_BORDER})

                table.AddCell(New PdfPCell(New Phrase("Harga/Malam", fontIsi)) With {.Border = Rectangle.NO_BORDER})
                table.AddCell(New PdfPCell(New Phrase(lblHarga.Text, fontIsi)) With {.Border = Rectangle.NO_BORDER})

                table.AddCell(New PdfPCell(New Phrase("Durasi", fontIsi)) With {.Border = Rectangle.NO_BORDER})
                table.AddCell(New PdfPCell(New Phrase(lblDurasi.Text, fontIsi)) With {.Border = Rectangle.NO_BORDER})

                table.AddCell(New PdfPCell(New Phrase("Tgl Masuk", fontIsi)) With {.Border = Rectangle.NO_BORDER})
                table.AddCell(New PdfPCell(New Phrase(lblTglMasuk.Text, fontIsi)) With {.Border = Rectangle.NO_BORDER})

                table.AddCell(New PdfPCell(New Phrase("Tgl Keluar", fontIsi)) With {.Border = Rectangle.NO_BORDER})
                table.AddCell(New PdfPCell(New Phrase(lblTglKeluar.Text, fontIsi)) With {.Border = Rectangle.NO_BORDER})

                doc.Add(table)

                ' Garis pembatas
                doc.Add(New Paragraph("===================================", fontIsi))

                ' Total Bayar
                Dim paraTotal As New Paragraph("TOTAL BAYAR: " & lblTotalBayar.Text, fontBold)
                paraTotal.Alignment = Element.ALIGN_RIGHT
                doc.Add(paraTotal)

                ' Footer
                doc.Add(New Paragraph("===================================", fontIsi))
                doc.Add(New Paragraph("Terima kasih telah menginap!", fontIsi) With {.Alignment = Element.ALIGN_CENTER})
                doc.Add(New Paragraph("Slip ini adalah bukti pembayaran sah.", fontIsi) With {.Alignment = Element.ALIGN_CENTER})

                doc.Close()
                MsgBox("Slip PDF berhasil dicetak.")
            Catch ex As Exception
                MsgBox("Gagal mencetak slip: " & ex.Message)
                Process.Start(saveFile.FileName)
            End Try
        End If
    End Sub

End Class