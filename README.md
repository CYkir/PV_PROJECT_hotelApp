🏨 HotelApp - Aplikasi Pemesanan Kamar Hotel

Aplikasi desktop pemesanan kamar hotel berbasis **VB.NET (.NET 8)** dengan koneksi ke **SQL Server** dan tampilan antarmuka modern menggunakan **Guna UI2 Framework**.

---

📦 Fitur Utama

- Manajemen data kamar (tambah, lihat, dan ubah status)
- Check-In & Check-Out pengunjung
- Slip pembayaran otomatis
- Tampilan UI modern (card style layout)
- Koneksi ke database SQL Server

---

## 🔧 Langkah Setup Proyek

Ikuti langkah-langkah berikut untuk menjalankan project ini dari awal:

### 1. Clone Repository

```bash
git clone https://github.com/username/hotelApp.git
```

> Ganti `username` dengan nama pengguna GitHub kamu.

---

 2. Buka Project di Visual Studio

- Gunakan **Visual Studio 2022** atau lebih baru
- Target framework: **.NET 8 Windows Forms**

---

 3. Restore NuGet Package

Aplikasi ini menggunakan paket berikut:

- `Microsoft.Data.SqlClient`
- `Guna.UI2.WinForms`

Cara install melalui Package Manager Console:

```powershell
Install-Package Microsoft.Data.SqlClient
Install-Package Guna.UI2.WinForms
```

Atau gunakan GUI NuGet:
**Project > Manage NuGet Packages > Browse**

---

### 4. Setup Database SQL Server

Bagi yang tidak bisa melakukan restore database silahkan ikutin langkah berikut :

1. Buat database baru dengan nama: `dbHotel`
2. Jalankan SQL berikut di SSMS (SQL Server Management Studio) atau editor SQL lainnya:

```sql
-- Gunakan database
USE dbHotel;
GO

-- 1. Tabel TipeKamar
CREATE TABLE TipeKamar (
    KodeTipe NVARCHAR(10) PRIMARY KEY,
    NamaTipe NVARCHAR(50) NOT NULL,
    HargaPerMalam INT NOT NULL
);
GO

-- 2. Tabel Kamar
CREATE TABLE Kamar (
    KodeKamar NVARCHAR(10) PRIMARY KEY,
    NoKamar NVARCHAR(10) NOT NULL UNIQUE,
    KodeTipe NVARCHAR(10) NOT NULL,
    Status NVARCHAR(20) NOT NULL CHECK (Status IN ('Terisi', 'Kosong')),
    GambarPath NVARCHAR(255),
    FOREIGN KEY (KodeTipe) REFERENCES TipeKamar(KodeTipe)
);
GO

-- 3. Tabel Pengunjung
CREATE TABLE Pengunjung (
    IdPengunjung NVARCHAR(10) PRIMARY KEY,
    NoKTP NVARCHAR(20) NOT NULL UNIQUE,
    Nama NVARCHAR(100) NOT NULL,
    Alamat NVARCHAR(200),
    NoTelp NVARCHAR(20)
);
GO

-- 4. Tabel Transaksi
CREATE TABLE Transaksi (
    KodeTransaksi NVARCHAR(10) PRIMARY KEY,
    IdPengunjung NVARCHAR(10) NOT NULL,
    KodeKamar NVARCHAR(10) NOT NULL,
    TanggalMasuk DATE NOT NULL,
    TanggalKeluar DATE NOT NULL,
    Durasi INT NOT NULL,
    TotalBayar INT NOT NULL,
    FOREIGN KEY (IdPengunjung) REFERENCES Pengunjung(IdPengunjung),
    FOREIGN KEY (KodeKamar) REFERENCES Kamar(KodeKamar)
);
GO

```

---

# 5. Ubah String Koneksi

Pastikan string koneksi di `Form1.vb` disesuaikan dengan SQL Server kamu:

```vb
Dim koneksi As New SqlConnection("Data Source=CYKIR\SQLEXPRESS;Initial Catalog=dbHotel;Integrated Security=True;TrustServerCertificate=True")
```

Ganti `CYKIR\SQLEXPRESS` dengan nama instance server di perangkat kamu.

---

 6. Jalankan Aplikasi

- Tekan `F5` di Visual Studio untuk menjalankan aplikasi.
- Aplikasi akan menampilkan daftar kamar dari database dalam bentuk panel responsif.

---

## 🖼️ Screenshot (Opsional)

> Tambahkan tangkapan layar di folder `/screenshots` untuk dokumentasi

markdown
- [Tampilan Utama](screenshots/form_utama.png)


---

## 👤 Developer

- [Muzakir](https://github.com/CYkir)

---

## ⚠️ Catatan Penting

- Pastikan gambar yang dipilih di `GambarPath` tersedia dan valid.
- UI dirancang untuk tampilan skala **100%** (dalam pengaturan Windows Display).
- Tidak mendukung sistem operasi selain **Windows**.

---

## 💡 Lisensi

Proyek ini dikembangkan untuk tujuan pembelajaran dan bebas dimodifikasi sesuai kebutuhan pribadi atau akademik.

