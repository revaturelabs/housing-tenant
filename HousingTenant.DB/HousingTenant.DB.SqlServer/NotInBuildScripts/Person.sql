create table Person.Person
(
  PersonID int not null primary key identity
  ,ApartmentID int foreign key references Apartment.Apartment(ApartmentID)
  ,HomeAddressID int not null foreign key references Address.Address(AddressID)
  ,GenderID int not null foreign key references Person.Gender(GenderID)
  ,FirstName nvarchar(50) not null
  ,LastName nvarchar(50) not null
  ,PhoneNumber nvarchar(15) not null
  ,Email nvarchar(50) not null
  ,Active bit not null default(1)
)
