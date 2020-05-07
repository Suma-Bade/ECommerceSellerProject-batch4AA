create database ECommerceDB
use ECommerceDB
create table Seller(sid int primary key,
username varchar(20) not null,
password varchar(20) not null,
companyname varchar(20) not null,
gst int not null,
aboutcmpy varchar(20),
address varchar(20) not null,
website varchar(20),
email varchar(20) not null,
mobileno varchar(20) not null)
select * from Seller
create table Category(cid int primary key,
cname varchar(20) not null,
cdetails varchar(20))
insert into Category values(1,'fashion','men fashion');
select * from Category
create table SubCategory(subid int primary key,
subname varchar(20) not null,
cname varchar(20),
sdetails varchar(20),
gst int)
select * from SubCategory
create table Items(id int primary key,
categoryname varchar(20),
subcategoryname varchar(20),
price varchar(20) not null,
itemname varchar(20) not null,
description varchar(20),
stockno int,
remarks varchar(20))
select * from Items