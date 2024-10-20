--Thêm Nhà Cung Cấp
CREATE PROCEDURE AddNhaCungCap
    @TenNhaCungCap NVARCHAR(100),
    @DiaChi NVARCHAR(200),
    @SoDienThoai NVARCHAR(10)
AS
BEGIN
    INSERT INTO NhaCungCap (TenNhaCungCap, DiaChi, SDT)
    VALUES (@TenNhaCungCap, @DiaChi, @SoDienThoai);
END
GO
--Sửa Nhà Cung Cấp
CREATE PROCEDURE UpdateNhaCungCap
    @MaNhaCungCap NVARCHAR(20),
    @TenNhaCungCap NVARCHAR(100),
    @DiaChi NVARCHAR(200),
    @SoDienThoai NVARCHAR(15)
AS
BEGIN
    UPDATE NhaCungCap
    SET TenNhaCungCap = @TenNhaCungCap,
        DiaChi = @DiaChi,
        SDT = @SoDienThoai
    WHERE MaNCC = @MaNhaCungCap;
END
GO

--Tìm Kiếm Nhà Cung Cấp
CREATE PROCEDURE SearchNhaCungCap
    @TenNhaCungCap NVARCHAR(100)
AS
BEGIN
    SELECT * FROM ViewNhaCungCap
    WHERE [Tên Nhà Cung Cấp] LIKE '%' + @TenNhaCungCap + '%';
END
GO
--Thêm Sản Phẩm
CREATE PROCEDURE sp_AddLinhKien
    @MaLK nchar(10),
    @TenLK nvarchar(50),
    @GiaTien float,
    @MoTa nvarchar(500),
    @TrangThai nvarchar(20),
    @SoLuong int,
    @HinhAnh varbinary(max),
    @MaNhom nchar(10),
    @MaNCC nchar(10)
AS
BEGIN
    INSERT INTO LinhKien (MaLK, TenLK, GiaTien, MoTa, TrangThai, SoLuong, AnhLK, MaNhom, MaNCC)
    VALUES (@MaLK, @TenLK, @GiaTien, @MoTa, @TrangThai, @SoLuong, @HinhAnh, @MaNhom, @MaNCC)
END
GO
--Update Linh Kiện
CREATE PROCEDURE sp_UpdateLinhKien
    @MaLK nchar(10),
    @TenLK nvarchar(50),
    @GiaTien float,
    @MoTa nvarchar(500),
    @TrangThai nvarchar(20),
    @SoLuong int,
    @MaNhom nchar(10),
    @MaNCC nchar(10),
    @HinhAnh varbinary(max) = NULL
AS
BEGIN
    UPDATE LinhKien
    SET TenLK = @TenLK,
        GiaTien = @GiaTien,
        MoTa = @MoTa,
        TrangThai = @TrangThai,
        SoLuong = @SoLuong,
        MaNhom = @MaNhom,
        MaNCC = @MaNCC,
        AnhLK = @HinhAnh
    WHERE MaLK = @MaLK;
END;
GO

CREATE FUNCTION fn_timTenLK(@TenLK NVARCHAR(50))
RETURNS TABLE 
AS
RETURN(
    SELECT *
    FROM ViewSanPham
    WHERE TenLK LIKE '%' + @TenLK + '%'
);
GO

-- Hàm tìm linh kiện theo giá tiền (<=)
CREATE FUNCTION fn_timTheoGiaLK(@GiaTien FLOAT)
RETURNS TABLE
AS
RETURN(
    SELECT *
    FROM LinhKien
    WHERE GiaTien <= @GiaTien
);
GO

-- Hàm tìm linh kiện theo nhóm LK
CREATE FUNCTION fn_timNhomLK(@TenNhom NVARCHAR(30))
RETURNS TABLE
AS
RETURN(
    SELECT *
    FROM ViewSanPham
    WHERE TenNhom LIKE '%' + @TenNhom + '%'
);
GO

-- Procedure thêm 1 đơn nhập hàng
CREATE PROCEDURE sp_InsertDonNhapHang
    @NgayNhap DATE,
    @MaNCC NVARCHAR(30),
    @GiaTriDonNhap FLOAT
AS
BEGIN
    INSERT INTO DonNhapHang (NgayNhap, MaNCC, GiaTriDonNhap)
    VALUES (@NgayNhap, @MaNCC, @GiaTriDonNhap);
END;
GO
--Xóa đơn nhập
CREATE PROCEDURE sp_DeleteDonNhapHang
    @MaDonNhap NCHAR(30)
AS
BEGIN
    BEGIN TRY
        
        BEGIN TRANSACTION;

        DELETE FROM NhapHang
        WHERE MaDonNhap = @MaDonNhap;

        DELETE FROM DonNhapHang
        WHERE MaDonNhap = @MaDonNhap;

        COMMIT TRANSACTION;

        PRINT 'Xóa đơn nhập hàng và các sản phẩm liên quan thành công!';
    END TRY
    BEGIN CATCH
        
        ROLLBACK TRANSACTION;

        PRINT 'Có lỗi xảy ra: ' + ERROR_MESSAGE();
    END CATCH
END;
GO
-- Procedure thêm vào bảng NhapHang
CREATE PROCEDURE sp_InsertNhapHang
    @MaLK NVARCHAR(30),
    @MaDonNhap NVARCHAR(30),
    @SoLuong INT,
    @DonGia FLOAT,
    @TongTien FLOAT
AS
BEGIN 
    INSERT INTO NhapHang(MaLK, MaDonNhap, SoLuong, DonGia, TongTien)
    VALUES(@MaLK, @MaDonNhap, @SoLuong, @DonGia, @TongTien);

END;
GO

--Update bảng NhapHang
CREATE PROCEDURE sp_UpdateNhapHang
    @MaLK NVARCHAR(30),
    @MaDonNhap NVARCHAR(30),
    @SoLuong INT,
    @DonGia FLOAT,
    @TongTien FLOAT
AS
BEGIN
    UPDATE NhapHang
    SET 
        SoLuong = @SoLuong,
        DonGia = @DonGia,
        TongTien = @TongTien
    WHERE 
        MaLK = @MaLK AND 
        MaDonNhap = @MaDonNhap;
END;
GO
--Xóa NhapHang
CREATE PROCEDURE sp_DeleteNhapHang
    @MaLK NVARCHAR(30),
    @MaDonNhap NVARCHAR(30)
AS
BEGIN
    DELETE NhapHang
    WHERE 
        MaLK = @MaLK AND 
        MaDonNhap = @MaDonNhap;
END;
GO

--Thêm Nhóm Linh Kiện
CREATE PROCEDURE sp_InsertNhomLinhKien
    @MaNhom NVARCHAR(10),
    @TenNhom NVARCHAR(50)
AS
BEGIN
    INSERT INTO NhomLinhKien (MaNhom, TenNhom, SoLuongLK)
    VALUES (@MaNhom, @TenNhom, 0);
END;
GO
--Sửa Nhóm Linh Kiện
CREATE PROCEDURE sp_UpdateNhomLinhKien
    @MaNhom NVARCHAR(10),
    @TenNhom NVARCHAR(50)
AS
BEGIN
    UPDATE NhomLinhKien
    SET TenNhom = @TenNhom
    WHERE MaNhom = @MaNhom;
END;
GO

--Thêm Ca Làm Việc
CREATE PROCEDURE sp_AddCaLamViec
    @Ngay DATE
AS
BEGIN

    INSERT INTO CaLamViec (TenCa, Ngay, ThoiGianBD, ThoiGianKT)
    VALUES 
	(N'Sáng', @Ngay, '07:00', '12:00'),
	(N'Chiều', @Ngay, '12:00', '17:00'),
	(N'Tối', @Ngay, '17:00', '22:00');
END;
GO
--Thêm Phân Ca
CREATE PROCEDURE sp_InsertPhanCa
    @MaNhanVien NCHAR(10),
    @MaCa NCHAR(10)
AS
BEGIN
    IF NOT EXISTS (SELECT 1 FROM PhanCa WHERE MaNhanVien = @MaNhanVien AND MaCa = @MaCa)
    BEGIN
        INSERT INTO PhanCa (MaNhanVien, MaCa)
        VALUES (@MaNhanVien, @MaCa);
    END
    ELSE
    BEGIN
        PRINT 'Phân ca đã tồn tại!';
    END
END;
GO
--Xóa phân ca
CREATE PROCEDURE sp_DeletePhanCa
    @MaNhanVien NCHAR(10),
    @MaCa NCHAR(10)
AS
BEGIN
    -- Xóa phân ca nếu tồn tại
    DELETE FROM PhanCa
    WHERE MaNhanVien = @MaNhanVien AND MaCa = @MaCa;

    -- Kiểm tra số hàng bị xóa
    IF @@ROWCOUNT = 0
    BEGIN
        PRINT 'Không tìm thấy phân ca để xóa!';
    END
    ELSE
    BEGIN
        PRINT 'Đã xóa phân ca thành công!';
    END
END;
GO
------------Thêm nhân viên--------------
CREATE PROC nv_InsertNhanVien
	@MaNV NVARCHAR(30),
    @HoTen NVARCHAR(50),
    @SDT CHAR(11), 
    @NgayBDLamViec DATE,
	@NgaySinh DATE,
	@GioiTinh NVARCHAR(3),
    @DiaChi NVARCHAR(100),
	@Luong FLOAT
AS
BEGIN
    INSERT INTO NhanVien(MaNV, HoTen, SDT, NgayBDLamViec, NgaySinh, GioiTinh, DiaChi, Luong)
    VALUES (@MaNV, @HoTen, @SDT, @NgayBDLamViec, @NgaySinh, @GioiTinh, @DiaChi, @Luong);
END;
GO
----------Sửa nhân viên--------------
CREATE PROC nv_updateNhanVien
    @MaNV NVARCHAR(30),
    @HoTen NVARCHAR(50),
    @SDT CHAR(11), 
    @NgayBDLamViec DATE,
	@NgaySinh DATE,
	@GioiTinh NVARCHAR(3),
    @DiaChi NVARCHAR(100),
	@Luong FLOAT
AS
BEGIN
    UPDATE NhanVien
    SET MaNV=@MaNV,
		HoTen=@HoTen,
		SDT=@SDT,
		NgayBDLamViec=@NgayBDLamViec,
		NgaySinh=@NgaySinh,
		GioiTinh=@GioiTinh,
		DiaChi=@DiaChi,
		Luong=@Luong
    WHERE MaNV=@MaNV
END;
GO
-------------Xoá nhân viên---------------

CREATE PROC nv_deleteNhanVien @MaNV nvarchar(30)
AS
BEGIN
	BEGIN TRANSACTION;
		BEGIN TRY
			DELETE FROM PhanCa WHERE MaNhanVien = @MaNV
			DELETE FROM NhanVien WHERE MaNV = @MaNV		
			COMMIT TRANSACTION
		END TRY
		BEGIN CATCH
			DECLARE @err nvarchar(MAX)
			SELECT @err = N'Xoá nhân viên thất bại' + ERROR_MESSAGE()
			RAISERROR (@err,16,1)
			ROLLBACK TRANSACTION
		END CATCH		
END
GO
--------------Tính tổng doanh thu from to --------------
CREATE FUNCTION fn_tongDoanhThu (@Start Date, @End Date) RETURNS MONEY
AS
BEGIN
	DECLARE @Total MONEY
	SELECT @Total  = sum(TongGiaTri)
	FROM HoaDon
	WHERE NgayXuat BETWEEN @Start AND @End
	RETURN ISNULL(@Total,0);
END;
GO
--------------Tính tổng doanh thu theo tháng----------------
CREATE FUNCTION fn_doanhThuTheoThang (@Month INT, @Year INT) RETURNS MONEY
AS
BEGIN
DECLARE @Start Date, @End Date, @Total MONEY
	SET @Start = DATEFROMPARTS(@Year, @Month, 1);
	SET @End = EOMONTH(@Start);
	SELECT @Total  = sum(TongGiaTri)
	FROM HoaDon
	WHERE NgayXuat >= @Start AND NgayXuat <= @End;
	RETURN ISNULL(@Total,0);
END;
GO
-----------Tổng tiền nhập hàng theo tháng----------------
CREATE FUNCTION fn_tongNhapHangTrongThang(@Month INT, @Year INT) RETURNS MONEY
AS
BEGIN
DECLARE @Start Date, @End Date, @Total MONEY
	SET @Start = DATEFROMPARTS(@Year, @Month, 1);
	SET @End = EOMONTH(@Start);
	SELECT @Total  = sum(GiaTriDonNhap)
	FROM DonNhapHang
	WHERE NgayNhap >= @Start AND NgayNhap <= @End;
	RETURN ISNULL(@Total,0);
END;
GO
--------------Lợi nhuận theo tháng---------------
CREATE FUNCTION fn_loiNhuanTheoThang(@Month INT, @Year INT) RETURNS MONEY
AS
BEGIN
DECLARE @Total MONEY
	SET @Total = (SELECT dbo.fn_doanhThuTheoThang(@Month, @Year)) - (SELECT dbo.fn_tongNhapHangTrongThang(@Month, @Year))
	RETURN ISNULL(@Total,0);
END;
GO
-----Nhân Viên------
-- Procedure thêm 1 khách hàng vào bảng KhachHang
CREATE PROCEDURE sp_InsertKhachHang
    @HoTen NVARCHAR(50),
    @Phone CHAR(11), 
    @Email NVARCHAR(50),
    @DiaChi NVARCHAR(100)
AS
BEGIN
    INSERT INTO KhachHang (HoTen, SDT, Email, DiaChi)
    VALUES (@HoTen, @Phone, @Email, @DiaChi);
END;
GO
-- Procedure thêm vào bảng HoaDon
CREATE PROCEDURE sp_insertHoaDon
    @NgayXuat DATE,
    @TongGiaTri FLOAT,
    @MaKH NVARCHAR(30),
    @MaNV NVARCHAR(30)
AS
BEGIN
    INSERT INTO HoaDon(NgayXuat, TongGiaTri, MaKH, MaNV)
    VALUES(@NgayXuat, @TongGiaTri, @MaKH, @MaNV);
END;
GO
-- Tạo function danh sách hóa đơn
Create Function fn_GetHoaDonByMaNV (@MaNV nvarchar(30))
Returns Table
As
Return 
(
    Select 
        HoaDon.MaKH,
        HoaDon.MaHD,
        HoaDon.NgayXuat,
        HoaDon.TongGiaTri,
        KhachHang.HoTen
    From HoaDon 
    Join KhachHang on HoaDon.MaKH = KhachHang.MaKH
    Where HoaDon.MaNV = @MaNV
);
Go
-- Hàm tìm hóa đơn theo giá trị hóa đơn
CREATE FUNCTION fn_timTheoGiaTri(@GiaTriMin FLOAT, @GiaTriMax FLOAT, @MaNV NVARCHAR(30))
RETURNS TABLE
AS
RETURN(
    SELECT 
        HoaDon.MaKH,
        HoaDon.MaHD,
        HoaDon.NgayXuat,
        HoaDon.TongGiaTri,
        KhachHang.HoTen
    FROM  HoaDon Join KhachHang on HoaDon.MaKH = KhachHang.MaKH
    WHERE HoaDon.MaNV = @MaNV AND TongGiaTri >= @GiaTriMin AND TongGiaTri <= @GiaTriMax
);
-- Hàm tìm hóa đơn theo ngày xuất hóa đơn
CREATE FUNCTION fn_timTheoNgayXuat(@NgayXuat DATE, @MaNV NVARCHAR(30))
RETURNS TABLE
AS
RETURN(
    SELECT * 
    FROM HoaDon
    WHERE MaNV = @MaNV AND NgayXuat = @NgayXuat
);
--Hàm load thông tin chi tiết hóa đơn
CREATE Function fn_loadChiTietHD(@MaHD NVARCHAR(30))
Returns Table
As
Return(
	Select ChiTietHD.MaHD,
			ChiTietHD.MaLK,
			LinhKien.TenLK,
			ChiTietHD.SoLuong,
			ChiTietHD.DonGia,
			ChiTietHD.TongTien
	From ChiTietHD join LinhKien on ChiTietHD.MaLK = LinhKien.MaLK
	Where ChiTietHD.MaHD = @MaHD
	);
GO
ALTER TABLE PhanCa
ADD TrangThai nvarchar(30);
drop PROCEDURE if exists sp_GetCaLamViecByNhanVien
drop FUNCTION if exists fn_GetDoanhThuByMaCaVaNhanVien
drop FUNCTION if exists fn_GetDoanhThuTheoNgay
--hàm load ca
CREATE PROCEDURE sp_GetCaLamViecByNhanVien
    @MaNV NVARCHAR(30)
AS
BEGIN
    SELECT 
        CL.MaCa, 
        CL.TenCa, 
        CL.Ngay, 
        CL.ThoiGianBD, 
        CL.ThoiGianKT
    FROM 
        PhanCa PC
        JOIN CaLamViec CL ON PC.MaCa = CL.MaCa
    WHERE 
        PC.MaNhanVien = @MaNV and
		pc.trangthai=1;
END;
GO

--Hàm Load doanh thu ca
CREATE FUNCTION fn_GetDoanhThuByMaCaVaNhanVien (
    @MaCa NVARCHAR(30),
    @MaNhanVien NVARCHAR(30)
)
RETURNS TABLE
AS
RETURN
(
    SELECT 
        PC.MaCa, 
        CL.Ngay, 
        ISNULL(COUNT(DISTINCT HD.MaHD), 0) AS SoLuongDonHang, 
        ISNULL(SUM(CTHD.SoLuong), 0) AS SoLuongLinhKien, 
        ISNULL(SUM(HD.TongGiaTri), 0) AS TongDoanhThu
    FROM PhanCa PC
    JOIN CaLamViec CL ON PC.MaCa = CL.MaCa
    LEFT JOIN HoaDon HD ON HD.MaNV = PC.MaNhanVien AND HD.NgayXuat = CL.Ngay
    LEFT JOIN ChiTietHD CTHD ON CTHD.MaHD = HD.MaHD
    WHERE PC.MaCa = @MaCa AND PC.MaNhanVien = @MaNhanVien
    GROUP BY PC.MaCa, CL.Ngay
);
GO
--Hàm Load Doanh thu ca theo ngày
Create   FUNCTION fn_GetDoanhThuTheoNgay (
    @MaNhanVien NVARCHAR(30),
    @NgayBatDau DATE,
    @NgayKetThuc DATE
)
RETURNS TABLE
AS
RETURN
(
    SELECT 
        PC.MaCa, 
        CL.Ngay, 
        COUNT(DISTINCT HD.MaHD) AS SoLuongDonHang, 
        ISNULL(SUM(CTHD.SoLuong), 0) AS SoLuongLinhKien, 
        ISNULL(SUM(HD.TongGiaTri), 0) AS TongDoanhThu
    FROM PhanCa PC
    JOIN CaLamViec CL ON PC.MaCa = CL.MaCa
    LEFT JOIN HoaDon HD ON HD.MaNV = PC.MaNhanVien AND HD.NgayXuat = CL.Ngay
    LEFT JOIN ChiTietHD CTHD ON CTHD.MaHD = HD.MaHD
    WHERE  
       PC.MaNhanVien = @MaNhanVien
      AND CL.Ngay BETWEEN @NgayBatDau AND @NgayKetThuc
    GROUP BY PC.MaCa, CL.Ngay
);
GO

-- thủ tục lấy ca làm việc được phân gần nhất để thực hiện chấm công 
Create  PROCEDURE sp_GetCaLamViec
    @MaNV NVARCHAR(30)
AS
BEGIN
    SELECT TOP 1 -- Chỉ lấy 1 phân ca gần nhất
        CL.MaCa, 
        CL.TenCa, 
        CL.Ngay, 
        CL.ThoiGianBD, 
        CL.ThoiGianKT
    FROM 
        PhanCa PC
        JOIN CaLamViec CL ON PC.MaCa = CL.MaCa
    WHERE 
        PC.MaNhanVien = @MaNV
        AND PC.TrangThai = 0 -- Chỉ lấy các phân ca chưa chấm công
        
    ORDER BY 
        DATEDIFF(MINUTE, GETDATE(), CAST(CONCAT(CL.Ngay, ' ', CL.ThoiGianBD) AS DATETIME)) ASC; -- Sắp xếp theo độ gần gũi với thời gian hiện tại
END;
GO
-- thủ tục thực hiện chấm công 
CREATE PROCEDURE sp_ChamCong
    @MaNV NVARCHAR(30),
    @MaCa NVARCHAR(30)
AS
BEGIN
    UPDATE PhanCa
    SET TrangThai = 1 -- 1 có thể đại diện cho "Đã Chấm Công"
    WHERE MaNhanVien = @MaNV AND MaCa = @MaCa;
END;
GO
-- procedure thêm vào chi tiết hóa đơn sau khi xuất hóa đơn
Create Procedure sp_insertChiTietHD
	@MaLK nvarchar(30),
	@MaHD nvarchar(30),
	@SoLuong int,
	@DonGia float,
	@TongTien float
As
Begin
	Insert into ChiTietHD(MaLK, MaHD, SoLuong, DonGia, TongTien)
	Values(@MaLK, @MaHD, @SoLuong, @DonGia, @TongTien)
End;



