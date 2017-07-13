create table Apartment.Apartment
(
  ApartmentID int not null primary key identity
  ,ApartmentComplexID int not null foreign key references Apartment.ApartmentComplex(ApartmentComplexID)
  ,AddressID int not null foreign key references Address.Address(AddressID)
  ,NumBeds int not null default(6)
  ,Gender nvarchar(20) not null
  ,Active bit not null default(1)
)