create table Address.Address
(
  AddressID int not null primary key identity
  ,Address1 nvarchar(50) not null
  ,Address2 nvarchar(50)
  ,City nvarchar(50) not null
  ,State nvarchar(30) not null
  ,Zip int not null
  ,Active bit not null default(1)
)
 