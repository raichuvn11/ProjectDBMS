--View NCC
CREATE VIEW ViewNhaCungCap AS
SELECT 
    MaNCC AS 'Mã Nhà Cung Cấp',
    TenNhaCungCap AS 'Tên Nhà Cung Cấp',
    SDT AS 'Số Điện Thoại',
    DiaChi AS 'Địa Chỉ'
FROM 
    NhaCungCap;
GO
--View Linh Kiện
CREATE VIEW ViewSanPham AS
SELECT 
    L.MaLK,
    L.TenLK,
    L.GiaTien,
    L.MoTa,
    L.TrangThai,
    L.SoLuong,
    N.TenNhaCungCap,
    NH.TenNhom,
	L.AnhLK
FROM 
    LinhKien L
JOIN 
    NhaCungCap N ON L.MaNCC = N.MaNCC
JOIN 
    NhomLinhKien NH ON L.MaNhom = NH.MaNhom;
GO
--View đơn nhập hàng
CREATE VIEW ViewDonNhapHang AS
SELECT 
    dn.MaDonNhap,
	dn.MaNCC,
    dn.NgayNhap,
    dn.GiaTriDonNhap,
    ncc.TenNhaCungCap,
    ncc.SDT
FROM 
    DonNhapHang dn
INNER JOIN 
    NhaCungCap ncc ON dn.MaNCC = ncc.MaNCC
GO
--View Nhập Hàng
CREATE VIEW ViewNhapHang AS
SELECT
	nh.MaDonNhap,
	nh.MaLK,
    lk.TenLK,
    nh.SoLuong,
    nh.DonGia,
    nh.TongTien
FROM 
    NhapHang nh
INNER JOIN 
    LinhKien lk ON nh.MaLK = lk.MaLK;
GO
--View Nhóm
CREATE VIEW ViewNhomLK AS
SELECT
	nh.MaNhom,
	nh.TenNhom,
	nh.SoLuongLK
FROM 
    NhomLinhKien nh
GO
--View Bảng ca
CREATE VIEW ViewCaLamViec AS
SELECT 
    MaCa,
    TenCa,
    Ngay,
    ThoiGianBD,
    ThoiGianKT
FROM 
    CaLamViec;
GO
--View Bảng phân ca
CREATE VIEW ViewPhanCa AS
SELECT 
    p.MaNhanVien,
    n.HoTen AS TenNhanVien,
	n.SDT,
    p.MaCa,
    c.TenCa,
    c.Ngay,
    c.ThoiGianBD,
    c.ThoiGianKT
FROM 
    PhanCa p
JOIN 
    NhanVien n ON p.MaNhanVien = n.MaNV
JOIN 
    CaLamViec c ON p.MaCa = c.MaCa;
GO
---------Nhân Viên---------
--View Linh Kiện--
CREATE VIEW LinhKienView AS
SELECT 
	LinhKien.MaLK,
    LinhKien.TenLK, 
	LinhKien.SoLuong,
    NhomLinhKien.TenNhom,	 
	LinhKien.TrangThai,
	LinhKien.GiaTien,
	LinhKien.AnhLK,
	LinhKien.MoTa
FROM 
    LinhKien join NhomLinhKien on LinhKien.MaNhom = NhomLinhKien.MaNhom
