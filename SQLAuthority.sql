Create TRIGGER [dbo].[Trigger_CreateSQLAccount] ON [dbo].[NhanVien]
AFTER INSERT
AS
DECLARE @userName nvarchar(30), @passWord nvarchar(10)
SELECT @userName=nl.MaNV, @passWord=nl.SDT
FROM inserted nl
BEGIN
DECLARE @sqlString nvarchar(2000), @macv nvarchar(10)
----
SET @sqlString= 'CREATE LOGIN [' + @userName +'] WITH PASSWORD='''+
@passWord 
+''', DEFAULT_DATABASE=[LinhKienDienTu2], CHECK_EXPIRATION=OFF, 
CHECK_POLICY=OFF'
EXEC (@sqlString)
----
SET @sqlString= 'CREATE USER ' + @userName +' FOR LOGIN '+ @userName
EXEC (@sqlString)
----

SET @sqlString = 'ALTER ROLE NhanVien ADD MEMBER ' + @userName;
EXEC (@sqlString)
END;
GO
--hàm check login
CREATE FUNCTION [dbo].[sp_CheckLogin] (@MaNV NVARCHAR(MAX),@SDT NVARCHAR(MAX)) RETURNS BIT
AS
BEGIN
    DECLARE @result BIT;

    SELECT @result = CAST(COUNT(*) AS BIT)
    FROM NhanVien
    WHERE MaNV = @MaNV AND SDT = @SDT;

    RETURN @result;
END;
GO
--tạo role
create ROLE NhanVien

GRANT SELECT, REFERENCES ON CaLamViec TO NhanVien;
GRANT SELECT, REFERENCES ON ChiTietHD TO NhanVien;
GRANT SELECT, REFERENCES ON DonNhapHang TO NhanVien;
GRANT SELECT, REFERENCES ON HoaDon TO NhanVien;
GRANT SELECT, REFERENCES ON KhachHang TO NhanVien;
GRANT SELECT, REFERENCES ON LinhKien TO NhanVien;
GRANT SELECT, REFERENCES ON NhaCungCap TO NhanVien;
GRANT SELECT, REFERENCES ON NhanVien TO NhanVien;
GRANT SELECT, REFERENCES ON NhapHang TO NhanVien;
GRANT SELECT, REFERENCES ON NhomLinhKien TO NhanVien;
GRANT SELECT, REFERENCES ON PhanCa TO NhanVien;

GRANT EXECUTE TO NhanVien
GRANT SELECT TO NhanVien


DENY EXECUTE ON [dbo].[AddNhaCungCap] to NhanVien;
DENY EXECUTE ON [dbo].[nv_deleteNhanVien] to NhanVien;
DENY EXECUTE ON [dbo].[nv_InsertNhanVien] to NhanVien;
DENY EXECUTE ON [dbo].[nv_updateNhanVien] to NhanVien;
DENY EXECUTE ON [dbo].[sp_AddCaLamViec] to NhanVien;
DENY EXECUTE ON [dbo].[sp_AddLinhKien] to NhanVien;
DENY EXECUTE ON [dbo].[sp_DeletePhanCa] to NhanVien;
DENY EXECUTE ON [dbo].[sp_DeleteDonNhapHang] to NhanVien;
DENY EXECUTE ON [dbo].[sp_DeleteNhapHang] to NhanVien;
DENY EXECUTE ON [dbo].[sp_InsertNhapHang] to NhanVien;
DENY EXECUTE ON [dbo].[sp_InsertNhomLinhKien] to NhanVien;
DENY EXECUTE ON [dbo].[sp_InsertPhanCa] to NhanVien;
DENY EXECUTE ON [dbo].[sp_UpdateLinhKien] to NhanVien;
DENY EXECUTE ON [dbo].[sp_UpdateNhapHang] to NhanVien;
DENY EXECUTE ON [dbo].[sp_UpdateNhomLinhKien] to NhanVien;
DENY EXECUTE ON [dbo].[UpdateNhaCungCap] to NhanVien;
