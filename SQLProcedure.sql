--Function tìm kiếm tên LK
CREATE FUNCTION fn_timTenLK(@TenLK NVARCHAR(50))
RETURNS TABLE 
AS
RETURN(
    SELECT *
    FROM LinhKienView
    WHERE TenLK LIKE '%' + @TenLK + '%'
);
GO
--Function tìm kiếm theo bộ lọc
CREATE FUNCTION fn_GetProductByFilter
(
    @TenNhom NVARCHAR(50) = NULL,
    @Gia FLOAT = NULL,
    @TrangThai NVARCHAR(50) = NULL
)
RETURNS TABLE
AS
RETURN
(
    SELECT *
    FROM LinhKienView
    WHERE ( @TenNhom IS NULL OR TenNhom = @TenNhom )
      AND ( @Gia IS NULL OR GiaTien <= @Gia )
      AND ( @TrangThai IS NULL OR TrangThai = @TrangThai )
);
GO

--Procedure lưu thông tin khách hàng
CREATE PROCEDURE sp_InsertKhachHang
    @HoTen NVARCHAR(50),
    @Phone CHAR(11), 
    @Email NVARCHAR(50),
    @DiaChi NVARCHAR(100)
AS
BEGIN
BEGIN TRANSACTION
	BEGIN TRY
		INSERT INTO KhachHang (HoTen, SDT, Email, DiaChi)
		VALUES (@HoTen, @Phone, @Email, @DiaChi);
		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		DECLARE @ErrorMessage NVARCHAR(4000) = N'Thêm khách hàng lỗi!' + ERROR_MESSAGE();
        RAISERROR (@ErrorMessage, 16, 1);
		ROLLBACK TRANSACTION;
	END CATCH
END;
GO
--Procedure insert hóa đơn
CREATE PROCEDURE sp_insertHoaDon
    @NgayXuat DATE,
    @TongGiaTri FLOAT,
    @MaKH NVARCHAR(30),
    @MaNV NVARCHAR(30)
AS
BEGIN
    BEGIN TRANSACTION;
    BEGIN TRY
        INSERT INTO HoaDon(NgayXuat, TongGiaTri, MaKH, MaNV)
        VALUES(@NgayXuat, @TongGiaTri, @MaKH, @MaNV);
		COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        DECLARE @ErrorMessage NVARCHAR(4000) = N'Xuất hóa đơn lỗi!' + ERROR_MESSAGE();
        RAISERROR (@ErrorMessage, 16, 1);
		ROLLBACK TRANSACTION;
    END CATCH
END;
GO
--Procedure insert chi tiết hóa đơn
CREATE PROCEDURE sp_insertChiTietHD
    @MaLK NVARCHAR(30),
    @MaHD NVARCHAR(30),
    @SoLuong INT,
    @DonGia FLOAT,
    @TongTien FLOAT
AS
BEGIN
BEGIN TRANSACTION
	BEGIN TRY
		INSERT INTO ChiTietHD(MaLK, MaHD, SoLuong, DonGia, TongTien)
		VALUES(@MaLK, @MaHD, @SoLuong, @DonGia, @TongTien);
		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		DECLARE @ErrorMessage NVARCHAR(4000) = N'Lỗi khi thêm chi tiết đơn hàng!' + ERROR_MESSAGE();
        RAISERROR (@ErrorMessage, 16, 1);
		ROLLBACK TRANSACTION;
	END CATCH
END;
GO
--Function lấy mã hóa đơn theo mã nv
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
GO
--Function tìm kiếm theo giá trị hóa đơn
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
GO
--Function Tìm kiếm theo ngày xuất hóa đơn
CREATE FUNCTION fn_timTheoNgayXuat(@NgayXuat DATE, @MaNV NVARCHAR(30))
RETURNS TABLE
AS
RETURN(
    SELECT * 
    FROM HoaDon
    WHERE MaNV = @MaNV AND NgayXuat = @NgayXuat
);
GO
--Function load chi tiết hóa đơn
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
-- Procedure get ca làm việc
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
-- procedure chấm công
Create PROCEDURE sp_ChamCong
    @MaNV NVARCHAR(30),
    @MaCa NVARCHAR(30)
AS
BEGIN
	BEGIN TRY
		UPDATE PhanCa
		SET TrangThai = 1 -- 1 có thể đại diện cho "Đã Chấm Công"
		WHERE MaNhanVien = @MaNV AND MaCa = @MaCa;
	END TRY
	BEGIN CATCH
		DECLARE @ErrorMessage NVARCHAR(4000) = N'Thực hiện chấm công lỗi!' + ERROR_MESSAGE();
        RAISERROR (@ErrorMessage, 16, 1);
	END CATCH
END;
GO
--Procedure load danh sách ca làm việc
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
--Procedure xe doanh thu theo ca
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
--Function xem doanh thu ca
Create FUNCTION fn_GetDoanhThuTheoNgay (
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
--Function tìm kiếm nhân viên
CREATE FUNCTION fn_timMaNV (@MaNV NVARCHAR(30))
RETURNS TABLE
AS
RETURN(
    SELECT * FROM NhanVien WHERE MaNV=@MaNV
);
GO
--Procedure insert nhân viên
ALTER PROC nv_InsertNhanVien
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
BEGIN TRANSACTION
	BEGIN TRY
		INSERT INTO [dbo].[NhanVien](MaNV, HoTen, SDT, NgayBDLamViec, NgaySinh, GioiTinh, DiaChi, Luong)
		VALUES (@MaNV, @HoTen, @SDT, @NgayBDLamViec, @NgaySinh, @GioiTinh, @DiaChi, @Luong);
		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		DECLARE @ErrorMessage NVARCHAR(4000) = N'Thêm nhân viên lỗi!' + ERROR_MESSAGE();
        RAISERROR (@ErrorMessage, 16, 1);
		ROLLBACK TRANSACTION;
	END CATCH 
END;
GO
--Procedure delete nhân viên
CREATE PROCEDURE [dbo].[nv_deleteNhanVien]
    @MaNV nvarchar(30)
AS
BEGIN
    DECLARE @sqlString nvarchar(2000);

    BEGIN TRANSACTION
    BEGIN TRY
        DELETE FROM PhanCa 
        WHERE MaNhanVien = @MaNV

        DELETE FROM NhanVien 
        WHERE MaNV = @MaNV

         SET @sqlString = 'ALTER ROLE NhanVien DROP MEMBER [' + @MaNV + ']'
        EXEC sp_executesql @sqlString;

        SET @sqlString = 'DROP USER [' + @MaNV + ']'
        EXEC sp_executesql @sqlString;

       SET @sqlString = 'DROP LOGIN [' + @MaNV + ']'
        EXEC sp_executesql @sqlString;

        COMMIT TRANSACTION;

        PRINT N'Đã xoá nhân viên ' + @MaNV+ N' thành công'

    END TRY
    BEGIN CATCH
			DECLARE @err nvarchar(MAX)
			SELECT @err = N'Xoá nhân viên ' + @MaNV + N' thất bại' + ERROR_MESSAGE()
			RAISERROR (@err,16,1)
			ROLLBACK TRANSACTION
		END CATCH
END;
GO
--Procedure update nhân viên
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
BEGIN TRANSACTION
	BEGIN TRY
    UPDATE [dbo].[NhanVien]
    SET MaNV =@MaNV,
		HoTen=@HoTen,
		SDT=@SDT,
		NgayBDLamViec=@NgayBDLamViec,
		NgaySinh=@NgaySinh,
		GioiTinh=@GioiTinh,
		DiaChi=@DiaChi,
		Luong=@Luong
    WHERE MaNV=@MaNV
	COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		DECLARE @ErrorMessage NVARCHAR(4000) = N'Sửa nhân viên lỗi!' + ERROR_MESSAGE();
        RAISERROR (@ErrorMessage, 16, 1);
		ROLLBACK TRANSACTION;
	END CATCH
END;
GO
--function tính tổng doanh thu
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
--function tinh doanh thu theo tháng
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
--function tính lợi nhuận theo tháng
CREATE FUNCTION fn_loiNhuanTheoThang(@Month INT, @Year INT) RETURNS MONEY
AS
BEGIN
DECLARE @Total MONEY
	SET @Total = (SELECT dbo.fn_doanhThuTheoThang(@Month, @Year)) - (SELECT dbo.fn_tongNhapHangTrongThang(@Month, @Year))
	RETURN ISNULL(@Total,0);
END;
GO
--Procedure add linh kiện**
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
    BEGIN TRANSACTION
    BEGIN TRY
	IF @MaLK IS NULL OR @MaLK = '' 
        BEGIN
            RAISERROR(N'Mã linh kiện không được để trống.', 16, 1);
            ROLLBACK TRANSACTION;
            RETURN;
        END
        IF @TenLK IS NULL OR @TenLK = '' 
        BEGIN
            RAISERROR(N'Tên linh kiện không được để trống.', 16, 1);
            ROLLBACK TRANSACTION;
            RETURN;
        END
        IF @GiaTien IS NULL OR @GiaTien <= 0
        BEGIN
            RAISERROR(N'Giá tiền không hợp lệ.', 16, 1);
            ROLLBACK TRANSACTION;
            RETURN;
        END
        IF @MoTa IS NULL OR @MoTa = ''
        BEGIN
            RAISERROR(N'Mô tả không được để trống.', 16, 1);
            ROLLBACK TRANSACTION;
            RETURN;
        END
        IF @TrangThai IS NULL OR @TrangThai = ''
        BEGIN
            RAISERROR(N'Trạng thái không được để trống.', 16, 1);
            ROLLBACK TRANSACTION;
            RETURN;
        END
        IF @MaNhom IS NULL OR @MaNhom = ''
        BEGIN
            RAISERROR(N'Mã nhóm không được để trống.', 16, 1);
            ROLLBACK TRANSACTION;
            RETURN;
        END
        IF @MaNCC IS NULL OR @MaNCC = ''
        BEGIN
            RAISERROR(N'Mã nhà cung cấp không được để trống.', 16, 1);
            ROLLBACK TRANSACTION;
            RETURN;
        END
		IF @HinhAnh = ''
        BEGIN
            RAISERROR(N'Hình ảnh không được để trống.', 16, 1);
            ROLLBACK TRANSACTION;
            RETURN;
        END
        IF EXISTS (SELECT 1 FROM LinhKien WHERE MaLK = @MaLK)
        BEGIN
            RAISERROR(N'Thêm linh kiện lỗi! Linh kiện với mã %s đã tồn tại.', 16, 1, @MaLK)
            ROLLBACK TRANSACTION;
            RETURN;
        END
        INSERT INTO LinhKien (MaLK, TenLK, GiaTien, MoTa, TrangThai, SoLuong, AnhLK, MaNhom, MaNCC)
        VALUES (@MaLK, @TenLK, @GiaTien, @MoTa, @TrangThai, @SoLuong, @HinhAnh, @MaNhom, @MaNCC);

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        DECLARE @ErrorMessage NVARCHAR(4000) = N'Thêm linh kiện lỗi! ';
        RAISERROR(@ErrorMessage, 16, 1);
        ROLLBACK TRANSACTION;
    END CATCH
END;
GO

--Procedure Sửa linh kiện**
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
    BEGIN TRANSACTION
    BEGIN TRY
        IF NOT EXISTS (SELECT 1 FROM LinhKien WHERE MaLK = @MaLK)
        BEGIN
            RAISERROR(N'Cập nhật lỗi! Linh kiện với mã %s không tồn tại.', 16, 1, @MaLK);
            ROLLBACK TRANSACTION;
            RETURN;
        END
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

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        DECLARE @ErrorMessage NVARCHAR(4000) = N'Cập nhật lỗi! ' + ERROR_MESSAGE();
        RAISERROR(@ErrorMessage, 16, 1);
        ROLLBACK TRANSACTION;
    END CATCH
END;
GO

--function tìm theo giá linh kiện
CREATE FUNCTION fn_timTheoGiaLK(@GiaTien FLOAT)
RETURNS TABLE
AS
RETURN(
    SELECT *
    FROM LinhKien
    WHERE GiaTien <= @GiaTien
);
GO
--funtion tìm theo nhóm linh kiện
CREATE FUNCTION fn_timNhomLK(@TenNhom NVARCHAR(30))
RETURNS TABLE
AS
RETURN(
    SELECT *
    FROM ViewSanPham
    WHERE TenNhom LIKE '%' + @TenNhom + '%'
);
GO
--Procedure Insert đơn nhập hàng**
CREATE PROCEDURE sp_InsertDonNhapHang
    @NgayNhap DATE,
    @MaNCC NVARCHAR(30),
    @GiaTriDonNhap FLOAT
AS
BEGIN
    BEGIN TRANSACTION
    BEGIN TRY
        INSERT INTO DonNhapHang (NgayNhap, MaNCC, GiaTriDonNhap)
        VALUES (@NgayNhap, @MaNCC, @GiaTriDonNhap);
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        DECLARE @ErrorMessage NVARCHAR(4000) = N'Lỗi thêm đơn nhập hàng! ' + ERROR_MESSAGE();
        RAISERROR(@ErrorMessage, 16, 1);
        ROLLBACK TRANSACTION;
    END CATCH
END;
GO

--Procedure Delete đơn nhập hàng**
CREATE PROCEDURE sp_DeleteDonNhapHang
    @MaDonNhap NCHAR(30)
AS
BEGIN
    BEGIN TRANSACTION
    BEGIN TRY
        IF NOT EXISTS (SELECT 1 FROM DonNhapHang WHERE MaDonNhap = @MaDonNhap)
        BEGIN
            RAISERROR(N'Lỗi xóa! Đơn nhập hàng với mã %s không tồn tại.', 16, 1, @MaDonNhap);
            ROLLBACK TRANSACTION;
            RETURN;
        END

        DELETE FROM NhapHang
        WHERE MaDonNhap = @MaDonNhap;

        DELETE FROM DonNhapHang
        WHERE MaDonNhap = @MaDonNhap;

        COMMIT TRANSACTION;

    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;

        DECLARE @ErrorMessage NVARCHAR(4000) = N'Lỗi xóa đơn nhập hàng! ' + ERROR_MESSAGE();
        RAISERROR(@ErrorMessage, 16, 1);
    END CATCH
END;
GO
--Procedure thêm linh kiện đơn nhập hàng **
CREATE PROCEDURE sp_InsertNhapHang
    @MaLK NVARCHAR(30),
    @MaDonNhap NVARCHAR(30),
    @SoLuong INT,
    @DonGia FLOAT,
    @TongTien FLOAT
AS
BEGIN
    BEGIN TRANSACTION
    BEGIN TRY

        INSERT INTO NhapHang (MaLK, MaDonNhap, SoLuong, DonGia, TongTien)
        VALUES (@MaLK, @MaDonNhap, @SoLuong, @DonGia, @TongTien);

        COMMIT TRANSACTION;

    END TRY
    BEGIN CATCH

        ROLLBACK TRANSACTION;

        DECLARE @ErrorMessage NVARCHAR(4000) = N'Lỗi thêm nhập hàng! ' + ERROR_MESSAGE();
        RAISERROR(@ErrorMessage, 16, 1);
    END CATCH
END;
GO

--Procedure delete đơn nhập**
CREATE PROCEDURE sp_DeleteNhapHang
    @MaLK NVARCHAR(30),
    @MaDonNhap NVARCHAR(30)
AS
BEGIN
    BEGIN TRANSACTION
    BEGIN TRY

        DELETE FROM NhapHang
        WHERE 
            MaLK = @MaLK AND 
            MaDonNhap = @MaDonNhap;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH

        ROLLBACK TRANSACTION;

        DECLARE @ErrorMessage NVARCHAR(4000) = N'Lỗi xóa nhập hàng! ' + ERROR_MESSAGE();
        RAISERROR(@ErrorMessage, 16, 1);
    END CATCH
END;
GO
--Procedure sửa đơn nhập hàng **
CREATE PROCEDURE sp_UpdateNhapHang
    @MaLK NVARCHAR(30),
    @MaDonNhap NVARCHAR(30),
    @SoLuong INT,
    @DonGia FLOAT,
    @TongTien FLOAT
AS
BEGIN
    BEGIN TRANSACTION
    BEGIN TRY

        UPDATE NhapHang
        SET 
            SoLuong = @SoLuong,
            DonGia = @DonGia,
            TongTien = @TongTien
        WHERE 
            MaLK = @MaLK AND 
            MaDonNhap = @MaDonNhap;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH

        ROLLBACK TRANSACTION;

        DECLARE @ErrorMessage NVARCHAR(4000) = N'Lỗi cập nhật nhập hàng! ' + ERROR_MESSAGE();
        RAISERROR(@ErrorMessage, 16, 1);
    END CATCH
END;
GO
--Procedure thêm nhóm linh kiện **

CREATE PROCEDURE sp_InsertNhomLinhKien
    @MaNhom NVARCHAR(10),
    @TenNhom NVARCHAR(50)
AS
BEGIN
    BEGIN TRANSACTION
    BEGIN TRY
        
        IF @MaNhom IS NULL OR LTRIM(RTRIM(@MaNhom)) = ''
        BEGIN
            RAISERROR(N'Lỗi thêm nhóm linh kiện! Mã nhóm không được để trống.', 16, 1);
            ROLLBACK TRANSACTION;
            RETURN;
        END

        -- Insert the new component group
        INSERT INTO NhomLinhKien (MaNhom, TenNhom, SoLuongLK)
        VALUES (@MaNhom, @TenNhom, 0);

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        -- Rollback the transaction and raise a custom error message
        ROLLBACK TRANSACTION;

        DECLARE @ErrorMessage NVARCHAR(4000) = N'Lỗi thêm nhóm linh kiện! ' + ERROR_MESSAGE();
        RAISERROR(@ErrorMessage, 16, 1);
    END CATCH
END;
GO

--Procedure sửa nhóm linh kiện**
CREATE PROCEDURE sp_UpdateNhomLinhKien
    @MaNhom NVARCHAR(10),
    @TenNhom NVARCHAR(50)
AS
BEGIN
    BEGIN TRANSACTION
    BEGIN TRY

        IF @MaNhom IS NULL OR LTRIM(RTRIM(@MaNhom)) = ''
        BEGIN
            RAISERROR(N'Lỗi cập nhật! Mã nhóm không được để trống.', 16, 1);
            ROLLBACK TRANSACTION;
            RETURN;
        END

        UPDATE NhomLinhKien
        SET TenNhom = @TenNhom
        WHERE MaNhom = @MaNhom;

        COMMIT TRANSACTION;

    END TRY
    BEGIN CATCH

        ROLLBACK TRANSACTION;

        DECLARE @ErrorMessage NVARCHAR(4000) = N'Lỗi cập nhật nhóm linh kiện! ' + ERROR_MESSAGE();
        RAISERROR(@ErrorMessage, 16, 1);
    END CATCH
END;
GO
--Procedure add nhà cung cấp **
CREATE PROCEDURE AddNhaCungCap
    @TenNhaCungCap NVARCHAR(100),
    @DiaChi NVARCHAR(200),
    @SoDienThoai NVARCHAR(10)
AS
BEGIN
    BEGIN TRANSACTION
    BEGIN TRY
        IF @TenNhaCungCap IS NULL OR LTRIM(RTRIM(@TenNhaCungCap)) = ''
        BEGIN
            RAISERROR(N'Lỗi thêm nhà cung cấp! Tên nhà cung cấp không được để trống.', 16, 1);
            ROLLBACK TRANSACTION;
            RETURN;
        END

        INSERT INTO NhaCungCap (TenNhaCungCap, DiaChi, SDT)
        VALUES (@TenNhaCungCap, @DiaChi, @SoDienThoai);

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;

        DECLARE @ErrorMessage NVARCHAR(4000) = N'Lỗi thêm nhà cung cấp! ' + ERROR_MESSAGE();
        RAISERROR(@ErrorMessage, 16, 1);
    END CATCH
END;
GO
--Procedure update nhà cung cấp**
CREATE PROCEDURE UpdateNhaCungCap
    @MaNhaCungCap NVARCHAR(20),
    @TenNhaCungCap NVARCHAR(100),
    @DiaChi NVARCHAR(200),
    @SoDienThoai NVARCHAR(15)
AS
BEGIN
    BEGIN TRANSACTION
    BEGIN TRY
        UPDATE NhaCungCap
        SET TenNhaCungCap = @TenNhaCungCap,
            DiaChi = @DiaChi,
            SDT = @SoDienThoai
        WHERE MaNCC = @MaNhaCungCap;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH

        ROLLBACK TRANSACTION;

        DECLARE @ErrorMessage NVARCHAR(4000) = N'Lỗi cập nhật nhà cung cấp! ' + ERROR_MESSAGE();
        RAISERROR(@ErrorMessage, 16, 1);
    END CATCH
END;
GO

--Procedure tìm kiếm tên nhà cung cấp
CREATE PROCEDURE SearchNhaCungCap
    @TenNhaCungCap NVARCHAR(100)
AS
BEGIN
    SELECT * FROM ViewNhaCungCap
    WHERE [Tên Nhà Cung Cấp] LIKE '%' + @TenNhaCungCap + '%';
END
GO

--Procedure thêm ca làm việc
CREATE PROCEDURE sp_AddCaLamViec
    @Ngay DATE
AS
BEGIN
    BEGIN TRANSACTION;
    BEGIN TRY
        IF EXISTS (SELECT 1 FROM CaLamViec WHERE Ngay = @Ngay)
        BEGIN
            RAISERROR(N'Đã tạo ca làm', 16, 1);
            ROLLBACK TRANSACTION;
            RETURN;
        END
        INSERT INTO CaLamViec (TenCa, Ngay, ThoiGianBD, ThoiGianKT)
        VALUES 
            (N'Sáng', @Ngay, '07:00', '12:00'),
            (N'Chiều', @Ngay, '12:00', '17:00'),
            (N'Tối', @Ngay, '17:00', '22:00');

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        DECLARE @ErrorMessage NVARCHAR(4000) = 'Lỗi phân ca';
        RAISERROR(@ErrorMessage, 16, 1);
    END CATCH
END;
GO

--Procedure thêm phân ca**

CREATE PROCEDURE sp_InsertPhanCa
    @MaNhanVien NCHAR(10),
    @MaCa NCHAR(10)
AS
BEGIN
    BEGIN TRANSACTION
    BEGIN TRY
        IF NOT EXISTS (SELECT 1 FROM PhanCa WHERE MaNhanVien = @MaNhanVien AND MaCa = @MaCa)
        BEGIN
            INSERT INTO PhanCa (MaNhanVien, MaCa, trangthai)
            VALUES (@MaNhanVien, @MaCa, 0);
        END
        ELSE
        BEGIN
            RAISERROR(N'Phân ca đã tồn tại cho nhân viên %s với mã ca %s.', 16, 1, @MaNhanVien, @MaCa);
        END

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        DECLARE @ErrorMessage NVARCHAR(4000) = N'Lỗi trong quá trình phân ca! ' + ERROR_MESSAGE();
        RAISERROR(@ErrorMessage, 16, 1);
    END CATCH
END;
GO

--Procedure xóa phân ca**
CREATE PROCEDURE sp_DeletePhanCa
    @MaNhanVien NCHAR(10),
    @MaCa NCHAR(10)
AS
BEGIN
    BEGIN TRANSACTION
    BEGIN TRY

        DELETE FROM PhanCa
        WHERE MaNhanVien = @MaNhanVien AND MaCa = @MaCa;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        -- Rollback transaction and raise error message
        ROLLBACK TRANSACTION;
        DECLARE @ErrorMessage NVARCHAR(4000) = N'Lỗi trong quá trình xóa phân ca! ' + ERROR_MESSAGE();
        RAISERROR(@ErrorMessage, 16, 1);
    END CATCH
END;
GO















