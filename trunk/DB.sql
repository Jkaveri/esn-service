
create database EVENT_SOCIAL_NETWORK
go

use EVENT_SOCIAL_NETWORK
go

--1----------------------------------------------------------
-- Bảng phân quyền cho tài khoản

create table [Role]
(
	RoleID int identity(1, 1) primary key,				-- Mã phân quyền (khóa chính)
	RoleName nvarchar(100) not null,					-- Loại tài khoản (Admin, Mode, Cong tac vien, ...)
	[Status] int not null								-- 0 = inactive, 1 = active
)
go


--2----------------------------------------------------------
-- Cách thức chia sẻ do người dùng chọn (public, private, only me)

create table ShareType
(
	ShareID int identity(1, 1) primary key,		-- Mã (khóa chính)
	TypeName nvarchar(100) not null,		-- Các cách thức chia sẻ (public, friends, only me)
	[Status] int not null						/* ẩn/ hiện chức năng 
												(Ví dụ admin mới đưa ra cách chia sẻ mới 
												nhưng chưa cho người dùng chọn thì cho ẩn)*/
)
go

--3----------------------------------------------------------
-- Bảng lưu thông tin đăng nhập

create table [Account]
(
	AccID int identity(1, 1) primary key,	-- Mã tài khoản (khóa chính)
	RoleID int not null,					-- Mã phân quyền (Bảng Roll)
	Email varchar(100) not null,		
	[Password] varchar(100)
)
go


--4----------------------------------------------------------
-- Bảng lưu thông tin cá nhân

create table AccountInfo
(
	AccID int unique,					-- Mã thông tin cá nhân (Khóa chính)	
	Name nvarchar(200) not null,				-- Tên người dùng
 	[Address] nvarchar(200),					-- Số nhà
	Street nvarchar(200),						-- Tên đường
	District nvarchar(200),						-- Quận
	City nvarchar(200),							-- Thành phố
	Country nvarchar(200),						-- Quốc gia
	Avatar varchar(255) default 'DefaultAvatar.jpg',
	Phone varchar(20),
	DateOfBirth	date,
	Gender bit,
	ShareID	int,								-- Chia sẻ thông tin (bảng Share_Category)
	Favorite nvarchar(max),
	AccessToken nvarchar(max),
	VerificationCode varchar(max),
	DayCreate date default getdate() not null,
	IsOnline bit,
	[Status] int not null,		
	primary key(AccID)			
)
go


--5----------------------------------------------------------
-- Bảng lưu tọa độ 

create table UserLocation
(
	LocationID int identity(1, 1) primary key,	-- Khóa chính
	AccID int unique not null,					-- Mã thông tin cá nhân (bảng thông tin cá nhân)
	Latitude float,								-- Tọa độ
	Longtitude float,							-- Tọa độ
)
go

--6----------------------------------------------------------
-- Bảng phân loại quan hệ (bạn bè, vợ chồng, người thân)

create table RelationType
(
	RelationTypeID int identity(1, 1) primary key,	-- Mã loại quan hệ (khóa chính)
	RelationTypeName nvarchar(500) not null,		-- Loại quan hệ (bạn bè, vợ chồng, người thân)
	ShareID	int,									-- Mã chia sẻ (Bảng chia sẻ Share_Category)
	[Status] int not null,	
)
go


--7----------------------------------------------------------
--Lưu thông tin quan hệ của người dùng

create table Relation
(
	RelationID	int identity(1, 1) primary key,			
	AccID int not null,								-- Mã tài khoản của người dùng (bảng Acc_Info)
	FriendID int not null,							-- Mã tài khoản người dùng có quan hệ (bảng Acc_Info)
	RelationTypeID	int,									-- Mã loại quan hệ (bảng Relation_Category)
	DayCreate datetime default getdate(),
	[Status] int not null,									-- Dang chờ, đã chấp nhận
	unique(AccID, FriendID)
)
go

--8----------------------------------------------------------
-- Bảng lưu danh sách nhãn sự kiện theo loại (hội họp, giao thông...)

create table EventType
(
	EventTypeID	int identity(1, 1) primary key,					-- Mã loại nhãn (khóa chính)
	EventTypeName nvarchar(500) not null,						-- Tên loại nhãn
	LabelImage	nvarchar(1000) default 'DefaultLabel.png',			-- Hình ảnh nhãn
	[Time] time not null	default '00:30:00',					-- Thời gian mặc định cho loại sự kiện
	[Status] int not null
)
go

--9----------------------------------------------------------
-- Thông tin sự kiện

create table EventInfo 
(
	EventID int identity(1, 1) primary key,					-- Mã số sự kiện
	AccID int not null,										-- Mã thông tin cá nhân (bảng Acc_Info)
	EventTypeID int,										-- Mã loại sự kiện
	Title nvarchar(100) not null,							-- Tieu de su kien
	[Description] nvarchar(100) not null,					-- Mô tả sự kiện
	DayCreate datetime not null default getdate(),			-- Thời gian tạo ra sự kiện
	EventLat float not null,								-- Tọa độ sự kiện
	EventLng float not null,								-- Tọa độ sự kiện
	ShareID	int,											-- Mã cách thức chia sẻ (bảng Share_Category)
	[Like] int not null default 0,
	Dislike int not null default 0,
	[Status] bit not null,
)
go

--12----------------------------------------------------------
-- Thông tin về LIKE / DISLIKE

create table EventTrustDetail
(
	EventID int,
	AccID int,		-- Mã thông tin cá nhân (bảng Acc_Info)
	[Like] int,		-- 
	Dislike int,
	primary key(EventID, AccID)
)
go

-- 10------------------------------------------------------------------
-- Lưu thông tin bình luận

create table Comment
(
	CommentID int identity(1, 1) primary key,		-- Mã (khóa chính)
	AccID int not null,								-- Mã thông tin cá nhân (bảng Acc_Info)
	EventID int not null,							-- Mã thông tin sự kiện (bảng EventInfo)
	Content	nvarchar(max) not null,					-- Nội dung bình luận
	DayCreate datetime default getdate(),
	[Status] bit not null							-- An / Hien
)
GO


-- 11--------------------------------------------------------------------
-- Thông tin về website/app

create table WebsiteInfo
(
	WebsiteID int identity(1, 1) primary key,	-- Mã (khóa chính)
	Name nvarchar(50),							-- Tên website
	[Address] nvarchar(4000),					-- Địa chỉ liên lạc
	Phone varchar(20),			
	Email varchar(50),
	WebsiteURL	nvarchar(1000),						-- Địa chỉ website
	Fax	varchar(20),
	Info ntext									-- Một vài thông tin thêm
)
GO

create table ActivityType
(
	ActiTypeID int identity primary key,
	ActiTypeName nvarchar(500) not null,
	[Description] nvarchar(500),
	[Status] int not null,
)

create table Activity
(
	ActiID int identity primary key,
	AccID int not null,
	FriendID int not null,
	EventID int,	
	CommentID int,
	ActiTypeID int not null,
	Content nvarchar(max),
	DayCreate datetime default getdate(),
	[Status] int not null,
)

create table Suggestion
(
	SuggestionID int identity primary key,
	AccID int not null,
	Title varchar(200) not null,
	Content ntext not null,
	DayCreate datetime default getdate(),
	[Status] int not null,
)


ALTER TABLE Account
ADD CONSTRAINT FK_1 FOREIGN KEY (RoleID) REFERENCES [Role](RoleID)
GO

-- Acc_Info(AccID) tham chi?u ??n Account(AccID)
ALTER TABLE AccountInfo
ADD CONSTRAINT FK_2 FOREIGN KEY (AccID) REFERENCES Account(AccID) 
GO

-- Comment(InfoID) tham chi?u ??n Acc_Info(InfoID)
ALTER TABLE Comment
ADD CONSTRAINT FK_3 FOREIGN KEY (AccID) REFERENCES Account(AccID) 
GO

ALTER TABLE EventInfo
ADD CONSTRAINT FK_4 FOREIGN KEY (AccID) REFERENCES Account(AccID) 
GO

ALTER TABLE Relation
ADD CONSTRAINT FK_9 FOREIGN KEY (AccID) REFERENCES Account(AccID) 
GO

ALTER TABLE Relation
ADD CONSTRAINT FK_21 FOREIGN KEY (FriendID) REFERENCES Account(AccID)
GO

ALTER TABLE EventTrustDetail
ADD CONSTRAINT FK_14 FOREIGN KEY (AccID) REFERENCES Account(AccID)
GO

ALTER TABLE UserLocation
ADD CONSTRAINT FK_19 FOREIGN KEY (AccID) REFERENCES Account(AccID)
GO

ALTER TABLE EventInfo
ADD CONSTRAINT FK_6 FOREIGN KEY (EventTypeID) REFERENCES EventType(EventTypeID)
GO

ALTER TABLE Relation
ADD CONSTRAINT FK_10 FOREIGN KEY (RelationTypeID) REFERENCES RelationType(RelationTypeID) 
GO

ALTER TABLE EventTrustDetail ADD CONSTRAINT FK_13 FOREIGN KEY (EventID) REFERENCES EventInfo(EventID)
GO

ALTER TABLE AccountInfo
ADD CONSTRAINT FK_15 FOREIGN KEY (ShareID) REFERENCES ShareType(ShareID) 
GO

ALTER TABLE EventInfo 
ADD CONSTRAINT FK_16 FOREIGN KEY (ShareID) REFERENCES ShareType(ShareID)
GO


ALTER TABLE RelationType
ADD CONSTRAINT FK_18 FOREIGN KEY (ShareID) REFERENCES ShareType(ShareID) 
GO

ALTER TABLE Comment
ADD CONSTRAINT FK_22 FOREIGN KEY (EventID) REFERENCES EventInfo(EventID)
GO


ALTER TABLE Activity
ADD CONSTRAINT FK_23 FOREIGN KEY (ActiTypeID) REFERENCES ActivityType(ActiTypeID)
GO

ALTER TABLE Activity
ADD CONSTRAINT FK_24 FOREIGN KEY (CommentID) REFERENCES Comment(CommentID)
GO

ALTER TABLE Activity
ADD CONSTRAINT FK_25 FOREIGN KEY (AccID) REFERENCES Account(AccID) 
GO

ALTER TABLE Activity
ADD CONSTRAINT FK_26 FOREIGN KEY (FriendID) REFERENCES Account(AccID) 
GO


ALTER TABLE Activity
ADD CONSTRAINT FK_27 FOREIGN KEY (EventID) REFERENCES [EventInfo](EventID)
GO

ALTER TABLE Suggestion
ADD CONSTRAINT FK_28 FOREIGN KEY (AccID) REFERENCES Account(AccID) 
GO

insert into [Role] values
('Admin', 1),
('Moderator', 1),
('User', 1)
go

insert into ActivityType values
(N'Kết bạn', N'Bạn nhận được một yêu cầu kết bạn từ', 1),
(N'Hủy kết bạn', N'đã hủy mối quan hệ với bạn', 1),
(N'Tạo sự kiện', N'vừa tạo một sự kiện', 1),
(N'Bình luận', N'vừa bình luận về sự kiện', 1),
(N'Không kết bạn', N'đã từ chối lời mời kết bạn', 1),
(N'Đồng ý kết bạn', N'đã chấp nhận lời mời kết bạn', 1)
go

insert into RelationType values
(N'Bạn bè', null, 1),
(N'Người thân', null, 1)
go

insert into EventType values
(N'Kẹt xe', 'ketxe.jpg', '01:00:00', 1),
(N'Tai nạn', 'tainan.jpg', '02:00:00', 1)
go


create proc CheckEmailAndPassword
@Email varchar(200),
@Password varchar(200)as
begin
	select AccountInfo.* from  AccountInfo, Account 
	where Email=@Email and Password=@Password and Account.AccID=AccountInfo.AccID
	
end
go

exec CheckEmailAndPassword 'nam', 'nam' 
go

create proc Register
@Name nvarchar(200),
@Email varchar(200),
@Pass varchar(200),
@Gender bit,
@BirthDay date,
@VerificationCode varchar(200) as
begin
	declare @ID int
	if not exists(select * from Account where Email=@Email ) 
	begin		
		insert into Account values (3, @Email, @Pass)
		select @ID = AccID from Account where Email=@Email
		insert into AccountInfo(AccID, Name, DateOfBirth, VerificationCode, DayCreate, [Status]) values(@ID, @Name, @BirthDay, @VerificationCode, GETDATE(), 0)
	end
end
go

declare @Diem int
exec @Diem=Register 'Hoang Nam', 'nam@gmailaaa.acom', 'aaaaaaaaaa', 'true', '12/29/1992', 'aaaaaaaaaaaaaaaa'
print @Diem
go

create proc CreateNewEvent
@AccID int,
@EventType int,
@Title nvarchar(500),
@Description nvarchar(500),
@Lat float,
@Lng float as
begin
	insert into EventInfo(AccID, EventTypeID, Title, Description, EventLat, EventLng, Status) values(@AccID, @EventType, @Title, @Description, @Lat, @Lng, 1)
	
end
go

exec CreateNewEvent '1', '2', 'tai nan tai cau sai gon', '2 nguoi khong chet', 10.1, 10.2
go

create proc LoadNewestEvent
as
begin
	select top 10 EventInfo.*, EventType.*, AccountInfo.Name, AccountInfo.Avatar from EventInfo,  EventType, AccountInfo, Account
	where EventInfo.EventTypeID = EventType.EventTypeID and Account.AccID=AccountInfo.AccID and Account.AccID=EventInfo.AccID
	order by EventInfo.DayCreate desc
end
go

exec LoadNewestEvent
go



create proc GetInvitation
@AccID int as
begin
	select Activity.ActiID, Activity.AccID, Name, Avatar, Activity.DayCreate
	from AccountInfo, Activity, ActivityType
	where Activity.ActiTypeID=ActivityType.ActiTypeID and Activity.AccID=AccountInfo.AccID 
	and Activity.FriendID=@AccID and Activity.[Status]=1 and AccountInfo.[Status]=1 and
	Activity.ActiTypeID=1
	order by Activity.DayCreate desc
end
go


create proc GetNotification
@AccID int as
begin
	select Activity.ActiID, Activity.AccID, Activity.ActiTypeID, Name, Avatar, Activity.DayCreate, [Description] 
	from AccountInfo, Activity, ActivityType
	where Activity.ActiTypeID=ActivityType.ActiTypeID and Activity.AccID=AccountInfo.AccID 
	and Activity.FriendID=@AccID and Activity.[Status]=1 and AccountInfo.[Status]=1
	and Activity.ActiTypeID!=1
	order by Activity.DayCreate desc
end
go

create proc GetFriendList
@AccID int as
begin
	select AccountInfo.AccID, Name, Avatar from AccountInfo where [Status]=1 and AccID in 
	(select FriendID from Relation where AccID=@AccID and [Status]=1)
	order by Name
end
go

