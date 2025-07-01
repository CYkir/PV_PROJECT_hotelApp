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
-- Tabel TipeKamar
CREATE TABLE TipeKamar (
    KodeTipe VARCHAR(10) PRIMARY KEY,
    NamaTipe VARCHAR(50)
);

-- Tabel Kamar
CREATE TABLE Kamar (
    KodeKamar VARCHAR(10) PRIMARY KEY,
    NoKamar VARCHAR(10),
    KodeTipe VARCHAR(10),
    GambarPath VARCHAR(255),
    Status VARCHAR(20),
    FOREIGN KEY (KodeTipe) REFERENCES TipeKamar(KodeTipe)
);

-- Tabel Pengunjung
CREATE TABLE Pengunjung (
    KodePengunjung VARCHAR(10) PRIMARY KEY,
    NamaPengunjung VARCHAR(100),
    NoIdentitas VARCHAR(50),
    Alamat VARCHAR(255),
    NoTelepon VARCHAR(20)
);

-- Tabel Transaksi
CREATE TABLE Transaksi (
    KodeTransaksi VARCHAR(10) PRIMARY KEY,
    KodeKamar VARCHAR(10),
    KodePengunjung VARCHAR(10),
    TanggalCheckIn DATETIME,
    TanggalCheckOut DATETIME,
    TotalBayar DECIMAL(18,2),
    FOREIGN KEY (KodeKamar) REFERENCES Kamar(KodeKamar),
    FOREIGN KEY (KodePengunjung) REFERENCES Pengunjung(KodePengunjung)
);
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

