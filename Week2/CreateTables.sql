USE QuanLyNhanKhau01;

-- Thực thể TrangThai
CREATE TABLE TrangThai
(
	MaTrangThai CHAR(5) NOT NULL,
	TenTrangThai NVARCHAR(100),
	CONSTRAINT MaTrangThai_TrangThai_PrimaryKey PRIMARY KEY (MaTrangThai),
)

-- Thực thể CaNhan tượng trưng cho 1 người dân có danh tính đầy đủ
CREATE TABLE CaNhan
(
	SoCMND CHAR(12) NOT NULL,
	HoTen NVARCHAR(50),
	GioiTinh NVARCHAR(5),
	NgaySinh DATE,
	NoiSinh NVARCHAR(50),
	NguyenQuan NVARCHAR(50),
	NgayCap DATE,
	NoiCap NVARCHAR(50),
	HinhAnh	IMAGE,
	TrangThai CHAR(5),
	CONSTRAINT SoCMND_CaNhan_PrimaryKey PRIMARY KEY (SoCMND),
	CONSTRAINT TrangThai_CaNhan_ForeignKey FOREIGN KEY (TrangThai) REFERENCES TrangThai(MaTrangThai)
	ON DELETE SET NULL
	ON UPDATE CASCADE
);
-- thực thể QuanHe
CREATE TABLE QuanHe
(
	MaQuanHe CHAR(5) NOT NULL, 
	TenQuanHe NVARCHAR(100),
	CONSTRAINT MaQuanHe_QuanHe_PrimaryKey PRIMARY KEY (MaQuanHe)
);

-- thực thể HoKhau
CREATE TABLE HoKhau
(
	MaSoHoKhau CHAR(10) NOT NULL, 
	DiaChi NVARCHAR(200), 
	ChuHo CHAR(12), 
	CONSTRAINT MaSoHoKhau_HoKhau_PrimaryKey PRIMARY KEY (MaSoHoKhau),
	CONSTRAINT ChuHo_HoKhau_ForeignKey FOREIGN KEY (ChuHo) REFERENCES CaNhan(SoCMND)
	ON DELETE SET NULL
	ON UPDATE CASCADE
);

-- Thực thể NhanKhauThuongTru
CREATE TABLE NhanKhauThuongTru 
(
	NguoiThuongTru CHAR(12) NOT NULL,	
	QuanHeVoiChuHo CHAR(5),
	NgayDKTHTR DATE, 
	ThongTinHoKhau CHAR(10),
	GhiChu NVARCHAR(200),
	CONSTRAINT NguoiThuongTru_NhanKhauThuongTru_PrimaryKey PRIMARY KEY (NguoiThuongTru),
	CONSTRAINT NguoiThuongTru_NhanKhauThuongTru_ForeignKey FOREIGN KEY (NguoiThuongTru) REFERENCES CaNhan(SoCMND),
	CONSTRAINT ThongTinHoKhau_NhanKhauThuongTru_ForeignKey FOREIGN KEY (ThongTinHoKhau) REFERENCES HoKhau(MaSoHoKhau),
	CONSTRAINT QuanHeVoiChuHo_NhanKhauThuongTru_ForeignKey FOREIGN KEY (QuanHeVoiChuHo) REFERENCES QuanHe(MaQuanHe)
	ON DELETE SET NULL
	ON UPDATE CASCADE
);

-- thực thể KT3
CREATE TABLE KT3
(
	MaSoKT3 CHAR(10) NOT NULL, 
	ChuSoKT3 CHAR(12),
	NgayCapSo DATE,
	CONSTRAINT MaSoKT3_KT3_PrimaryKey PRIMARY KEY (MaSoKT3),
	CONSTRAINT ChuSoKT3_KT3_ForeignKey FOREIGN KEY (ChuSoKT3) REFERENCES CaNhan(SoCMND)
	ON DELETE SET NULL
	ON UPDATE CASCADE
);

-- thực thể NhanKhauTamTru
CREATE TABLE NhanKhauTamTru
(
	NguoiTamTru CHAR(12) NOT NULL, 
	ThongTinHoKhau CHAR(10), 
	QuanHeVoiChuHo CHAR(5), 
	NgayDKTTR DATE,
	DangKyTheoKT3 BIT, 
	ThongTinKT3 CHAR(10),
	GhiChu NVARCHAR(200),
	CONSTRAINT NguoiTamTru_NhanKhauTamTru_PrimaryKey PRIMARY KEY (NguoiTamTru),
	CONSTRAINT NguoiTamTru_NhanKhauTamTru_ForeignKey FOREIGN KEY (NguoiTamTru) REFERENCES CaNhan(SoCMND),
	CONSTRAINT ThongTinHoKhau_NhanKhauTamTru_ForeignKey FOREIGN KEY (ThongTinHoKhau) REFERENCES HoKhau(MaSoHoKhau),
	CONSTRAINT QuanHeVoiChuHoau_NhanKhauTamTru_ForeignKey FOREIGN KEY (QuanHeVoiChuHo) REFERENCES QuanHe(MaQuanHe)
	ON DELETE SET NULL
	ON UPDATE CASCADE,
	CONSTRAINT ThongTinKT3_NhanKhauTamTru_ForeignKey FOREIGN KEY (ThongTinKT3) REFERENCES KT3(MaSoKT3)
	ON DELETE SET NULL
	ON UPDATE CASCADE
);	

-- thực thể NhanKhauTamVang
CREATE TABLE NhanKhauTamVang
(
	NguoiTamVang CHAR(12) NOT NULL, 
	DiaChiTamVang CHAR(10), 
	DiaChiOTam NVARCHAR(200), 
	TamVangTu DATE, 
	TamVangDen DATE,
	GhiChu NVARCHAR(200),
	CONSTRAINT NguoiTamVang_NhanKhauTamVang_PrimaryKey PRIMARY KEY (NguoiTamVang),
	CONSTRAINT NguoiTamVang_NhanKhauTamVang_ForeignKey FOREIGN KEY (NguoiTamVang) REFERENCES CaNhan(SoCMND),
	CONSTRAINT DiaChiTamVang_NhanKhauTamVang_ForeignKey FOREIGN KEY (DiaChiTamVang) REFERENCES HoKhau(MaSoHoKhau)
);