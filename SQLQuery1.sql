CREATE DATABASE master
use master
CREATE TABLE ParkingList
(
	v_id int primary key identity,
	v_plate nvarchar(20) unique not null,
	v_type nvarchar(20) not null,
	v_brand nvarchar(20) not null,
	v_time DateTime not null
)
insert into ParkingList values ( '123abc', 'motor', 'bmw', GETDATE())
DELETE FROM ParkingList WHERE v_type = 'suv';

SELECT * FROM ParkingList;