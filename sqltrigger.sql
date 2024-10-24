-- Trigger tự động tạo mã khách hàng khi insert vào bảng 
CREATE TRIGGER tg_genCustomerID
ON KhachHang
INSTEAD OF INSERT
AS
BEGIN
    INSERT INTO KhachHang (MaKH, HoTen, SDT, Email, DiaChi)
    SELECT 'KH' + i.SDT, i.HoTen, i.SDT, i.Email, i.DiaChi
    FROM inserted i;
END;
GO
--Trigger tự động tạo mã ca làm việc
CREATE TRIGGER trg_AutoGenerateMaCa
ON CaLamViec
INSTEAD OF INSERT
AS
BEGIN
    INSERT INTO CaLamViec (MaCa, TenCa, Ngay, ThoiGianBD, ThoiGianKT)
    SELECT 
        -- Tạo mã ca làm việc với 10 ký tự: CA + ngày (yyMMdd) + chữ cái đầu tiên của TenCa
        LEFT(CONCAT('CA', FORMAT(i.Ngay, 'yyMMdd'), SUBSTRING(i.TenCa, 1, 1)), 10) AS MaCa,
        i.TenCa,
        i.Ngay,
        i.ThoiGianBD,
        i.ThoiGianKT
    FROM inserted i;
END;
GO
--Trigger cập nhập số lượng linh kiện của bảng nhóm linh kiện
CREATE TRIGGER trg_UpdateSoLuongNhomLK
ON LinhKien
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    UPDATE NhomLinhKien
    SET SoLuongLK = (
        SELECT ISNULL(SUM(lk.SoLuong), 0)
        FROM LinhKien lk
        WHERE lk.MaNhom = NhomLinhKien.MaNhom
    )
    WHERE MaNhom IN (
        SELECT MaNhom FROM inserted
        UNION
        SELECT MaNhom FROM deleted
    );
END;
GO
--Trigger tự động tạo mã nhà cung cấp
CREATE TRIGGER trg_genMaNCC
ON NhaCungCap
INSTEAD OF INSERT
AS
BEGIN
    DECLARE @MaNCC NVARCHAR(30);
    DECLARE @TenNhaCungCap NVARCHAR(50);
    DECLARE @SDT NCHAR(10);
    SELECT @TenNhaCungCap = TenNhaCungCap, @SDT = SDT
    FROM inserted;
    SET @MaNCC = LEFT(@TenNhaCungCap, 3) + RIGHT(@SDT, 4);
    INSERT INTO NhaCungCap (MaNCC, TenNhaCungCap, SDT, DiaChi)
    SELECT @MaNCC, TenNhaCungCap, SDT, DiaChi
    FROM inserted;
END;
GO
--Trigger Tự Động Cập Nhật Tổng Giá Trị Đơn Nhập khi xóa
CREATE TRIGGER trg_DeleteNhapHang
ON NhapHang
AFTER DELETE
AS
BEGIN
    UPDATE DonNhapHang
    SET GiaTriDonNhap = (SELECT ISNULL(SUM(TongTien), 1) FROM NhapHang WHERE MaDonNhap = d.MaDonNhap)
    FROM DonNhapHang d
    INNER JOIN deleted del ON d.MaDonNhap = del.MaDonNhap;
END;
GO
--Trigger Tự Động Cập Nhật Tổng Giá Trị Đơn Nhập khi thêm, sửa
CREATE TRIGGER trg_UpdateTongGiaTriDonNhap
ON NhapHang
AFTER INSERT, UPDATE
AS
BEGIN
    UPDATE DonNhapHang
    SET GiaTriDonNhap = (SELECT SUM(TongTien) FROM NhapHang WHERE MaDonNhap = u.MaDonNhap)
    FROM DonNhapHang d
    INNER JOIN inserted u ON d.MaDonNhap = u.MaDonNhap;
END
GO
-- Trigger tự động tạo mã đơn nhập khi thêm đơn nhập hàng
CREATE TRIGGER trg_genMaDonNhap
ON DonNhapHang
INSTEAD OF INSERT 
AS
BEGIN
    INSERT INTO DonNhapHang (MaDonNhap, NgayNhap, MaNCC, GiaTriDonNhap)
    SELECT RTRIM(i.MaNCC) + '_' + FORMAT(i.NgayNhap,'yyMMdd'), i.NgayNhap, i.MaNCC, i.GiaTriDonNhap
    FROM inserted i;
END;
GO
-- Trigger tự động tạo mã hóa đơn
CREATE TRIGGER trg_genMaHD
ON HoaDon
INSTEAD OF INSERT 
AS
BEGIN
    INSERT INTO HoaDon(MaHD, NgayXuat, TongGiaTri, MaKH, MaNV)
    SELECT RTRIM(i.MaKH) + '_' + RTRIM(i.MaNV) + '_' + FORMAT(i.NgayXuat,'yyMMdd'), i.NgayXuat, i.TongGiaTri, i.MaKH, i.MaNV
    FROM inserted i;
END;
GO
-- Trigger cập nhật số lượng linh kiện khi thêm, sửa, xóa dữ liệu vào bảng NhapHang
CREATE TRIGGER trg_UpdateSoLuongLinhKien_NhapHang
ON NhapHang
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    IF EXISTS (SELECT * FROM inserted)
    BEGIN
        UPDATE LinhKien
        SET SoLuong +=  ISNULL(i.SoLuong, 0)
        FROM LinhKien lk
        INNER JOIN inserted i ON lk.MaLK = i.MaLK;
    END

    IF EXISTS (SELECT * FROM deleted)
    BEGIN
        UPDATE LinhKien
        SET SoLuong -= ISNULL(d.SoLuong, 0)
        FROM LinhKien lk
        INNER JOIN deleted d ON lk.MaLK = d.MaLK;
    END
END;
GO
--Trigger cập nhật số lượng linh kiện khi xuất hóa đơn
CREATE TRIGGER trg_UpdateSoLuongLinhKien_XuatHoaDon
ON ChiTietHD
AFTER INSERT, UPDATE
AS
BEGIN
    IF EXISTS (SELECT * FROM inserted)
    BEGIN
        UPDATE LinhKien
        SET SoLuong -= ISNULL(i.SoLuong, 0)
        FROM LinhKien lk
        INNER JOIN inserted i ON lk.MaLK = i.MaLK;
    END

END;
GO

