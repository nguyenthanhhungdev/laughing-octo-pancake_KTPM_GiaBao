CREATE DATABASE Data
USE Data
GO

CREATE TABLE Taikhoan
(
	Id INT IDENTITY PRIMARY KEY,
	Tentk nvarchar(100),
	Mk nvarchar(100),
	Tenhienthi nvarchar(100),
	Loai nvarchar(100)
)
GO

CREATE TABLE DSban
(
	Id int,
	Tinhtrangban nvarchar(50),
	Tenban nvarchar(50),
	constraint PK_dsban primary key (Id)
)
GO

CREATE TABLE FoodCateGory
(
	id INT IDENTITY(1,1) PRIMARY KEY,
	name NVARCHAR(100) NOT NULL DEFAULT N'Chưa đặt tên'
)
GO

CREATE TABLE Food
(
	id INT IDENTITY PRIMARY KEY,
	name NVARCHAR(100) NOT NULL DEFAULT N'Chưa đặt tên',
	idCateGory INT NOT NULL,
	price FLOAT NOT NULL DEFAULT 0,
	FOREIGN KEY (idCateGory) REFERENCES FoodCateGory(id)
)
GO

CREATE TABLE Bill
(	id INT IDENTITY PRIMARY KEY,
	idNhanVien INT NOT NULL,
	status INT DEFAULT 0,
	discount INT DEFAULT 0,
	total FLOAT(53) DEFAULT 0,
	creation DATE DEFAULT GETDATE(),
	FOREIGN KEY (idNhanVien) REFERENCES dbo.Taikhoan(Id)
)
GO

CREATE TABLE BillDetail
(
	billId INT,
	foodId INT,
	Quantity INT,
	FOREIGN KEY (billId) REFERENCES dbo.Bill(id),
	FOREIGN KEY (foodId) REFERENCES dbo.Food(id)
)
GO


--INSERT

--Danh sách bàn
insert into Taikhoan(Tentk,Mk,Tenhienthi,Loai) values ('admin','admin','admin', 'admin')

insert into DSban(Id,Tinhtrangban,Tenban) values (1,'no','ban1')
insert into DSban(Id,Tinhtrangban,Tenban) values (2,'no','ban2')
insert into DSban(Id,Tinhtrangban,Tenban) values (3,'no','ban3')
insert into DSban(Id,Tinhtrangban,Tenban) values (4,'no','ban4')
insert into DSban(Id,Tinhtrangban,Tenban) values (5,'no','ban5')
insert into DSban(Id,Tinhtrangban,Tenban) values (6,'no','ban6')
insert into DSban(Id,Tinhtrangban,Tenban) values (7,'no','ban7')
insert into DSban(Id,Tinhtrangban,Tenban) values (8,' no','ban8')
insert into DSban(Id,Tinhtrangban,Tenban) values (9,'no','ban9')

select * from DSban 

--Category
INSERT INTO dbo.FoodCateGory
(
    name
)
VALUES
(
	N'Thức ăn nhanh' -- name - nvarchar(100)
)
INSERT INTO dbo.FoodCateGory
(
    name
)
VALUES
(
	N'Nước uống' -- name - nvarchar(100)
)
select * from FoodCateGory

--INSERT FOOD
INSERT INTO Food(name, idCateGory, price) VALUES (N'Hamburger', 1, 30000)
INSERT INTO Food(name, idCateGory, price) VALUES (N'Bánh mì', 1, 15000)
INSERT INTO Food(name, idCateGory, price) VALUES (N'Khoai Tây Chiên', 1, 15000)
INSERT INTO Food(name, idCateGory, price) VALUES (N'Há Cảo Hấp', 1, 20000)
INSERT INTO Food(name, idCateGory, price) VALUES ('Sushi', 1, 20000)
INSERT INTO Food(name, idCateGory, price) VALUES ('Bánh Chocolate', 1, 15000)
INSERT INTO Food(name, idCateGory, price) VALUES ('Bánh Flan', 1, 10000)
INSERT INTO Food(name, idCateGory, price) VALUES (N'Tokbokki Chả Cá Phô Mai', 1, 30000)
INSERT INTO Food(name, idCateGory, price) VALUES (N'Bánh Gạo Lắc Phô Mai', 1, 20000)

SELECT id as 'id', name AS 'Tên món', idCateGory AS 'Loại', price AS 'Đơn giá' FROM Food

--INSERT ACCCOUNT
INSERT INTO Taikhoan(Tentk, Mk, Tenhienthi, Loai) VALUES ('van_thanh_cong', 'cong', 'Van Thanh Cong', 'staff')
INSERT INTO Taikhoan(Tentk, Mk, Tenhienthi, Loai) VALUES ('ly_hong_duc', 'duc', 'Ly Hong Duc', 'staff')
INSERT INTO Taikhoan(Tentk, Mk, Tenhienthi, Loai) VALUES ('thao_ngoc_dung', 'dung', 'Thao Ngoc Dung', 'staff')
INSERT INTO Taikhoan(Tentk, Mk, Tenhienthi, Loai) VALUES ('dong_khac_duy', 'duy', 'Dong Khac Duy', 'staff')
INSERT INTO Taikhoan(Tentk, Mk, Tenhienthi, Loai) VALUES ('nham_anh_khoa', 'khoa', 'Nham Anh Khoa', 'staff')
INSERT INTO Taikhoan(Tentk, Mk, Tenhienthi, Loai) VALUES ('duy_quoc_hai', 'hai', 'Duy Quoc Hai', 'staff')
INSERT INTO Taikhoan(Tentk, Mk, Tenhienthi, Loai) VALUES ('cam_khanh_hoan', 'hoan', 'Cam Khanh Hoan', 'staff')
INSERT INTO Taikhoan(Tentk, Mk, Tenhienthi, Loai) VALUES ('doan_gia_huan', 'huan', 'Doan Gia Huan', 'staff')
INSERT INTO Taikhoan(Tentk, Mk, Tenhienthi, Loai) VALUES ('dieu_gia_huan', 'huan', 'Dieu Gia Huan', 'staff')
--INSERT BILL
INSERT INTO Bill(idNhanVien, status, discount, total, creation) VALUES ('8', '1', '20', '172500', '2022/12/17')
INSERT INTO Bill(idNhanVien, status, discount, total, creation) VALUES ('5', '1', '20', '297500', '2022/12/16')
INSERT INTO Bill(idNhanVien, status, discount, total, creation) VALUES ('2', '1', '10', '430500', '2022/12/17')
INSERT INTO Bill(idNhanVien, status, discount, total, creation) VALUES ('8', '1', '15', '374000', '2022/12/15')
INSERT INTO Bill(idNhanVien, status, discount, total, creation) VALUES ('6', '1', '20', '171000', '2022/12/17')
INSERT INTO Bill(idNhanVien, status, discount, total, creation) VALUES ('10', '1', '0', '417500', '2022/12/14')
INSERT INTO Bill(idNhanVien, status, discount, total, creation) VALUES ('3', '1', '25', '28000', '2022/12/14')
INSERT INTO Bill(idNhanVien, status, discount, total, creation) VALUES ('2', '1', '25', '287500', '2022/12/16')
INSERT INTO Bill(idNhanVien, status, discount, total, creation) VALUES ('5', '1', '10', '273500', '2022/12/17')
INSERT INTO Bill(idNhanVien, status, discount, total, creation) VALUES ('4', '1', '30', '333000', '2022/12/14')
INSERT INTO Bill(idNhanVien, status, discount, total, creation) VALUES ('9', '1', '5', '351500', '2022/12/18')
INSERT INTO Bill(idNhanVien, status, discount, total, creation) VALUES ('2', '1', '0', '435500', '2022/12/16')
INSERT INTO Bill(idNhanVien, status, discount, total, creation) VALUES ('5', '1', '10', '339500', '2022/12/18')
INSERT INTO Bill(idNhanVien, status, discount, total, creation) VALUES ('5', '1', '20', '138500', '2022/12/18')
INSERT INTO Bill(idNhanVien, status, discount, total, creation) VALUES ('2', '1', '25', '466500', '2022/12/18')
INSERT INTO Bill(idNhanVien, status, discount, total, creation) VALUES ('10', '1', '0', '406500', '2022/12/15')
INSERT INTO Bill(idNhanVien, status, discount, total, creation) VALUES ('6', '1', '5', '442000', '2022/12/17')
INSERT INTO Bill(idNhanVien, status, discount, total, creation) VALUES ('6', '1', '30', '312000', '2022/12/16')
INSERT INTO Bill(idNhanVien, status, discount, total, creation) VALUES ('6', '1', '20', '197500', '2022/12/18')
INSERT INTO Bill(idNhanVien, status, discount, total, creation) VALUES ('7', '1', '30', '423000', '2022/12/15')
INSERT INTO Bill(idNhanVien, status, discount, total, creation) VALUES ('8', '1', '10', '398000', '2022/12/15')
INSERT INTO Bill(idNhanVien, status, discount, total, creation) VALUES ('4', '1', '25', '291500', '2022/12/14')
INSERT INTO Bill(idNhanVien, status, discount, total, creation) VALUES ('2', '1', '25', '165000', '2022/12/18')
INSERT INTO Bill(idNhanVien, status, discount, total, creation) VALUES ('5', '1', '30', '140500', '2022/12/17')
INSERT INTO Bill(idNhanVien, status, discount, total, creation) VALUES ('10', '1', '25', '323500', '2022/12/15')
INSERT INTO Bill(idNhanVien, status, discount, total, creation) VALUES ('10', '1', '0', '318000', '2022/12/15')
INSERT INTO Bill(idNhanVien, status, discount, total, creation) VALUES ('2', '1', '15', '166500', '2022/12/16')
INSERT INTO Bill(idNhanVien, status, discount, total, creation) VALUES ('9', '1', '30', '270500', '2022/12/18')
INSERT INTO Bill(idNhanVien, status, discount, total, creation) VALUES ('4', '1', '0', '141000', '2022/12/16')
INSERT INTO Bill(idNhanVien, status, discount, total, creation) VALUES ('4', '1', '25', '265000', '2022/12/18')

SELECT * FROM dbo.Bill

INSERT INTO BillDetail(billId, foodId, quantity) VALUES ('1', '2', '1')
INSERT INTO BillDetail(billId, foodId, quantity) VALUES ('1', '2', '2')
INSERT INTO BillDetail(billId, foodId, quantity) VALUES ('1', '2', '2')
INSERT INTO BillDetail(billId, foodId, quantity) VALUES ('1', '2', '1')
INSERT INTO BillDetail(billId, foodId, quantity) VALUES ('1', '2', '1')
INSERT INTO BillDetail(billId, foodId, quantity) VALUES ('1', '1', '2')
INSERT INTO BillDetail(billId, foodId, quantity) VALUES ('2', '1', '1')
INSERT INTO BillDetail(billId, foodId, quantity) VALUES ('2', '2', '1')
INSERT INTO BillDetail(billId, foodId, quantity) VALUES ('2', '2', '1')
INSERT INTO BillDetail(billId, foodId, quantity) VALUES ('2', '2', '1')
INSERT INTO BillDetail(billId, foodId, quantity) VALUES ('2', '1', '1')
INSERT INTO BillDetail(billId, foodId, quantity) VALUES ('3', '2', '2')
INSERT INTO BillDetail(billId, foodId, quantity) VALUES ('3', '2', '2')
INSERT INTO BillDetail(billId, foodId, quantity) VALUES ('3', '1', '1')
INSERT INTO BillDetail(billId, foodId, quantity) VALUES ('3', '1', '2')
INSERT INTO BillDetail(billId, foodId, quantity) VALUES ('4', '1', '2')
INSERT INTO BillDetail(billId, foodId, quantity) VALUES ('5', '1', '1')
INSERT INTO BillDetail(billId, foodId, quantity) VALUES ('5', '1', '2')
INSERT INTO BillDetail(billId, foodId, quantity) VALUES ('5', '2', '2')
INSERT INTO BillDetail(billId, foodId, quantity) VALUES ('6', '2', '1')
INSERT INTO BillDetail(billId, foodId, quantity) VALUES ('7', '2', '1')
INSERT INTO BillDetail(billId, foodId, quantity) VALUES ('7', '2', '1')
INSERT INTO BillDetail(billId, foodId, quantity) VALUES ('7', '2', '1')
INSERT INTO BillDetail(billId, foodId, quantity) VALUES ('7', '1', '1')
INSERT INTO BillDetail(billId, foodId, quantity) VALUES ('7', '1', '1')
INSERT INTO BillDetail(billId, foodId, quantity) VALUES ('7', '1', '2')
INSERT INTO BillDetail(billId, foodId, quantity) VALUES ('8', '1', '1')
INSERT INTO BillDetail(billId, foodId, quantity) VALUES ('8', '1', '2')
INSERT INTO BillDetail(billId, foodId, quantity) VALUES ('8', '1', '1')
INSERT INTO BillDetail(billId, foodId, quantity) VALUES ('8', '1', '1')
INSERT INTO BillDetail(billId, foodId, quantity) VALUES ('8', '2', '2')
INSERT INTO BillDetail(billId, foodId, quantity) VALUES ('8', '1', '2')
INSERT INTO BillDetail(billId, foodId, quantity) VALUES ('8', '2', '1')
INSERT INTO BillDetail(billId, foodId, quantity) VALUES ('9', '1', '1')
INSERT INTO BillDetail(billId, foodId, quantity) VALUES ('9', '2', '1')
INSERT INTO BillDetail(billId, foodId, quantity) VALUES ('9', '1', '1')
INSERT INTO BillDetail(billId, foodId, quantity) VALUES ('9', '1', '1')
INSERT INTO BillDetail(billId, foodId, quantity) VALUES ('9', '1', '1')
INSERT INTO BillDetail(billId, foodId, quantity) VALUES ('10', '2', '1')
INSERT INTO BillDetail(billId, foodId, quantity) VALUES ('10', '1', '1')
INSERT INTO BillDetail(billId, foodId, quantity) VALUES ('10', '1', '1')
INSERT INTO BillDetail(billId, foodId, quantity) VALUES ('10', '2', '2')
INSERT INTO BillDetail(billId, foodId, quantity) VALUES ('10', '2', '1')
INSERT INTO BillDetail(billId, foodId, quantity) VALUES ('11', '1', '1')
INSERT INTO BillDetail(billId, foodId, quantity) VALUES ('11', '2', '1')
INSERT INTO BillDetail(billId, foodId, quantity) VALUES ('12', '2', '1')
INSERT INTO BillDetail(billId, foodId, quantity) VALUES ('13', '1', '2')
INSERT INTO BillDetail(billId, foodId, quantity) VALUES ('13', '1', '3')
INSERT INTO BillDetail(billId, foodId, quantity) VALUES ('13', '1', '1')
INSERT INTO BillDetail(billId, foodId, quantity) VALUES ('13', '2', '1')
INSERT INTO BillDetail(billId, foodId, quantity) VALUES ('14', '2', '2')
INSERT INTO BillDetail(billId, foodId, quantity) VALUES ('14', '2', '2')
INSERT INTO BillDetail(billId, foodId, quantity) VALUES ('14', '1', '1')
INSERT INTO BillDetail(billId, foodId, quantity) VALUES ('14', '2', '1')
INSERT INTO BillDetail(billId, foodId, quantity) VALUES ('15', '1', '2')
INSERT INTO BillDetail(billId, foodId, quantity) VALUES ('15', '2', '1')
INSERT INTO BillDetail(billId, foodId, quantity) VALUES ('16', '1', '1')
INSERT INTO BillDetail(billId, foodId, quantity) VALUES ('16', '1', '1')
INSERT INTO BillDetail(billId, foodId, quantity) VALUES ('16', '2', '2')
INSERT INTO BillDetail(billId, foodId, quantity) VALUES ('16', '2', '1')
INSERT INTO BillDetail(billId, foodId, quantity) VALUES ('17', '1', '1')
INSERT INTO BillDetail(billId, foodId, quantity) VALUES ('17', '1', '2')
INSERT INTO BillDetail(billId, foodId, quantity) VALUES ('17', '2', '2')
INSERT INTO BillDetail(billId, foodId, quantity) VALUES ('18', '2', '2')
INSERT INTO BillDetail(billId, foodId, quantity) VALUES ('18', '2', '1')
INSERT INTO BillDetail(billId, foodId, quantity) VALUES ('18', '2', '1')
INSERT INTO BillDetail(billId, foodId, quantity) VALUES ('18', '1', '1')
INSERT INTO BillDetail(billId, foodId, quantity) VALUES ('19', '1', '1')
INSERT INTO BillDetail(billId, foodId, quantity) VALUES ('19', '1', '2')
INSERT INTO BillDetail(billId, foodId, quantity) VALUES ('19', '1', '1')
INSERT INTO BillDetail(billId, foodId, quantity) VALUES ('19', '2', '1')
INSERT INTO BillDetail(billId, foodId, quantity) VALUES ('19', '1', '2')
INSERT INTO BillDetail(billId, foodId, quantity) VALUES ('19', '2', '1')
INSERT INTO BillDetail(billId, foodId, quantity) VALUES ('20', '2', '1')
INSERT INTO BillDetail(billId, foodId, quantity) VALUES ('21', '1', '1')
INSERT INTO BillDetail(billId, foodId, quantity) VALUES ('21', '1', '2')
INSERT INTO BillDetail(billId, foodId, quantity) VALUES ('21', '1', '1')
INSERT INTO BillDetail(billId, foodId, quantity) VALUES ('21', '2', '2')
INSERT INTO BillDetail(billId, foodId, quantity) VALUES ('21', '1', '1')
INSERT INTO BillDetail(billId, foodId, quantity) VALUES ('23', '2', '1')
INSERT INTO BillDetail(billId, foodId, quantity) VALUES ('24', '2', '1')
INSERT INTO BillDetail(billId, foodId, quantity) VALUES ('24', '1', '1')
INSERT INTO BillDetail(billId, foodId, quantity) VALUES ('24', '2', '2')
INSERT INTO BillDetail(billId, foodId, quantity) VALUES ('24', '2', '1')
INSERT INTO BillDetail(billId, foodId, quantity) VALUES ('25', '1', '2')
INSERT INTO BillDetail(billId, foodId, quantity) VALUES ('25', '2', '1')
INSERT INTO BillDetail(billId, foodId, quantity) VALUES ('25', '1', '2')
INSERT INTO BillDetail(billId, foodId, quantity) VALUES ('25', '2', '1')
INSERT INTO BillDetail(billId, foodId, quantity) VALUES ('25', '2', '1')
INSERT INTO BillDetail(billId, foodId, quantity) VALUES ('25', '2', '1')
INSERT INTO BillDetail(billId, foodId, quantity) VALUES ('26', '1', '1')
INSERT INTO BillDetail(billId, foodId, quantity) VALUES ('26', '2', '1')
INSERT INTO BillDetail(billId, foodId, quantity) VALUES ('26', '2', '2')
INSERT INTO BillDetail(billId, foodId, quantity) VALUES ('26', '2', '1')
INSERT INTO BillDetail(billId, foodId, quantity) VALUES ('27', '2', '2')
INSERT INTO BillDetail(billId, foodId, quantity) VALUES ('27', '1', '2')
INSERT INTO BillDetail(billId, foodId, quantity) VALUES ('27', '1', '2')
INSERT INTO BillDetail(billId, foodId, quantity) VALUES ('27', '2', '1')
INSERT INTO BillDetail(billId, foodId, quantity) VALUES ('27', '2', '1')
INSERT INTO BillDetail(billId, foodId, quantity) VALUES ('28', '1', '1')
INSERT INTO BillDetail(billId, foodId, quantity) VALUES ('28', '2', '1')
INSERT INTO BillDetail(billId, foodId, quantity) VALUES ('28', '1', '1')
INSERT INTO BillDetail(billId, foodId, quantity) VALUES ('28', '2', '3')
INSERT INTO BillDetail(billId, foodId, quantity) VALUES ('28', '1', '1')
INSERT INTO BillDetail(billId, foodId, quantity) VALUES ('28', '2', '2')
INSERT INTO BillDetail(billId, foodId, quantity) VALUES ('29', '2', '1')
INSERT INTO BillDetail(billId, foodId, quantity) VALUES ('29', '1', '1')
INSERT INTO BillDetail(billId, foodId, quantity) VALUES ('30', '2', '2')
INSERT INTO BillDetail(billId, foodId, quantity) VALUES ('30', '2', '1')
INSERT INTO BillDetail(billId, foodId, quantity) VALUES ('30', '1', '2')
INSERT INTO BillDetail(billId, foodId, quantity) VALUES ('30', '2', '1')

SELECT * FROM dbo.BillDetail
GO

CREATE PROC [dbo].[USP_GetListBillByDate]
@checkIn date, @checkOut date
AS 
BEGIN
	SELECT idNhanVien, discount AS [Giảm giá], creation AS [Ngày tạo], total AS [Tổng tiền]
	FROM dbo.Bill 
	WHERE creation >= @checkIn AND creation <= @checkOut AND status = 1
END
GO

CREATE PROC USP_GetListBillByDateAndPage
@checkIn date, @checkOut date, @page int
AS 
BEGIN
	DECLARE @pageRows INT = 10
	DECLARE @selectRows INT = @pageRows
	DECLARE @exceptRows INT = (@page - 1) * @pageRows
	
	;WITH BillShow AS( SELECT idNhanVien, discount AS [Giảm giá], creation AS [Ngày tạo], total AS [Tổng tiền]
	FROM Bill 
	WHERE creation >= @checkIn AND creation <= @checkOut AND status = 1 )
	
	SELECT TOP (@selectRows) * FROM BillShow
	EXCEPT 
	SELECT TOP (@exceptRows) * FROM BillShow
END
GO

CREATE PROC USP_GetNumBillByDate
@checkIn date, @checkOut date
AS 
BEGIN
	SELECT COUNT(*)
	FROM dbo.Bill 
	WHERE creation >= @checkIn AND creation <= @checkOut AND status = 1
END
GO

CREATE FUNCTION [dbo].[fuConvertToUnsign1] ( @strInput NVARCHAR(4000) ) RETURNS NVARCHAR(4000) AS BEGIN IF @strInput IS NULL RETURN @strInput IF @strInput = '' RETURN @strInput DECLARE @RT NVARCHAR(4000) DECLARE @SIGN_CHARS NCHAR(136) DECLARE @UNSIGN_CHARS NCHAR (136) SET @SIGN_CHARS = N'ăâđêôơưàảãạáằẳẵặắầẩẫậấèẻẽẹéềểễệế ìỉĩịíòỏõọóồổỗộốờởỡợớùủũụúừửữựứỳỷỹỵý ĂÂĐÊÔƠƯÀẢÃẠÁẰẲẴẶẮẦẨẪẬẤÈẺẼẸÉỀỂỄỆẾÌỈĨỊÍ ÒỎÕỌÓỒỔỖỘỐỜỞỠỢỚÙỦŨỤÚỪỬỮỰỨỲỶỸỴÝ' +NCHAR(272)+ NCHAR(208) SET @UNSIGN_CHARS = N'aadeoouaaaaaaaaaaaaaaaeeeeeeeeee iiiiiooooooooooooooouuuuuuuuuuyyyyy AADEOOUAAAAAAAAAAAAAAAEEEEEEEEEEIIIII OOOOOOOOOOOOOOOUUUUUUUUUUYYYYYDD' DECLARE @COUNTER int DECLARE @COUNTER1 int SET @COUNTER = 1 WHILE (@COUNTER <=LEN(@strInput)) BEGIN SET @COUNTER1 = 1 WHILE (@COUNTER1 <=LEN(@SIGN_CHARS)+1) BEGIN IF UNICODE(SUBSTRING(@SIGN_CHARS, @COUNTER1,1)) = UNICODE(SUBSTRING(@strInput,@COUNTER ,1) ) BEGIN IF @COUNTER=1 SET @strInput = SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)-1) ELSE SET @strInput = SUBSTRING(@strInput, 1, @COUNTER-1) +SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)- @COUNTER) BREAK END SET @COUNTER1 = @COUNTER1 +1 END SET @COUNTER = @COUNTER +1 END SET @strInput = replace(@strInput,' ','-') RETURN @strInput END

SELECT * FROM dbo.Food WHERE dbo.fuConvertToUnsign1(name) LIKE N'%' + dbo.fuConvertToUnsign1(N'chi') + '%'
SELECT * FROM dbo.Food WHERE name LIKE N'%mực%'