create table Apartment.ApartmentComplex
(
  ApartmentComplexID int not null primary key identity
  ,AddressID int not null foreign key references Address.Address(AddressID)
  ,WalkingDistance bit not null
  ,ComplexName nvarchar(50) not null
  ,Active bit not null default(1) 
)