create database laptop
use laptop

create table account
(
	IDaccount int identity primary key,
	accountname nvarchar(100),
	pass char(100),
	email char(100),
	phone int,
	address nvarchar(255)
)

create table intification
(
	IDintification int identity primary key,
	IDaccount int,
	content nvarchar
)

create table roleaccount
(
	IDrole int identity primary key,
	rolename nvarchar(30),
	IDaccount int
)

create table roledetail
(
	IDroledetail int identity primary key,
	IDrole int,
	note nvarchar
)

create table promotion
(
	IDpromotion int identity primary key,
	content nvarchar,
	linkIMG char,
	status nvarchar,
	createday date,
	linkimgpromotion char
)

create table cart
(
	IDcart int identity primary key,
	createday date,
	totalprice money,
	IDaccount int
)

create table cartdetail
(
	IDcartdetail int identity primary key,
	IDcart int,
	IDproduct int,
	quantity int,
	price money,
	note nvarchar
)

create table complain
(
	IDcomplain int identity primary key,
	IDaccount int,
	IDcartdetail int,
	createday date,
	status nvarchar
)

create table reviewproduct
(
	IDreview int identity primary key,
	startnum float,
	IDaccount int,
	createday date,
	IDcartdetail int,
	status nvarchar
)

create table orderproduct
(
	IDorder int identity primary key,
	createday date,
	totalprice money,
	shipaddress nvarchar,
	IDaccount int,
	statusorder nvarchar,
	IDstore int,
	IDvoucher int
)

create table product
(
	IDproduct int identity primary key,
	nameproduct nvarchar(255),
	description nvarchar,
	price money,
	IDstore int,
	linkIMG char,
	count int
)

create table voucher
(
	IDvoucher int identity primary key,
	content nvarchar,
	name nvarchar(255),
	discount int,
	startday date,
	finishday date
)

create table store
(
	IDstore int identity primary key,
	namestore nvarchar(255),
	phone int,
	address nvarchar,
	status nvarchar,
	shipping_service nvarchar,
	IDaccountOWN int,
	information nvarchar,
	bankinfo int,
	linkIMG char
)

ALTER TABLE intification
ADD FOREIGN KEY (IDaccount) REFERENCES account(IDaccount);

ALTER TABLE roleaccount
ADD FOREIGN KEY (IDaccount) REFERENCES account(IDaccount);

ALTER TABLE roledetail
ADD FOREIGN KEY (IDrole) REFERENCES roleaccount(IDrole);

ALTER TABLE cart
ADD FOREIGN KEY (IDaccount) REFERENCES account(IDaccount);

ALTER TABLE cartdetail
ADD FOREIGN KEY (IDcart) REFERENCES cart(IDcart);

ALTER TABLE cartdetail
ADD FOREIGN KEY (IDproduct) REFERENCES product(IDproduct);

ALTER TABLE complain
ADD FOREIGN KEY (IDaccount) REFERENCES account(IDaccount);

ALTER TABLE complain
ADD FOREIGN KEY (IDcartdetail) REFERENCES cartdetail(IDcartdetail);

ALTER TABLE reviewproduct
ADD FOREIGN KEY (IDaccount) REFERENCES account(IDaccount);

ALTER TABLE reviewproduct
ADD FOREIGN KEY (IDcartdetail) REFERENCES cartdetail(IDcartdetail);

ALTER TABLE orderproduct
ADD FOREIGN KEY (IDaccount) REFERENCES account(IDaccount);

ALTER TABLE orderproduct
ADD FOREIGN KEY (IDstore) REFERENCES store(IDstore);

ALTER TABLE orderproduct
ADD FOREIGN KEY (IDvoucher) REFERENCES voucher(IDvoucher);

ALTER TABLE product
ADD FOREIGN KEY (IDstore) REFERENCES store(IDstore);

ALTER TABLE store
ADD FOREIGN KEY (IDaccountOWN) REFERENCES account(IDaccount);

ALTER TABLE product
	ADD IDcategory int;

ALTER TABLE product
	ADD trademark nvarchar(255);

 create table category
 (
    IDcategory int primary key identity,
    namecategory nvarchar(255)
 )

 ALTER TABLE product
	ADD FOREIGN KEY (IDcategory) REFERENCES category(IDcategory);