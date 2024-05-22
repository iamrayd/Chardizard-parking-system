CREATE DATABASE master
use master
use Users
CREATE TABLE ParkingList4
(
	v_id int primary key identity,
	v_plate nvarchar(20) unique not null,
	v_type nvarchar(20) not null,
	v_brand nvarchar(20) not null,
	v_time DateTime not null
)

insert into ParkingList2 values ( '123333abc', 'motor', 'bmw', GETDATE())
insert into ParkingList3 values ( '1241233abc', 'motor', 'bmw', GETDATE())
insert into ParkingList4 values ( '155553abc', 'motor', 'bmw', GETDATE())

DELETE FROM ParkingList WHERE v_type = 'suv';
DELETE FROM UserInfo WHERE u_pass = '123';
DELETE FROM UserInfo WHERE u_name = 'bob';


SELECT * FROM ParkingList;
SELECT * FROM ParkingList2;
SELECT * FROM ParkingList3;
SELECT * FROM ParkingList4;


SELECT * FROM UserInfo;