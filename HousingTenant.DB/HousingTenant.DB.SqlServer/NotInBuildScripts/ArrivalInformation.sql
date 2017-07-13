create table Arrival.ArrivalInformation
(
  ArrivalInformationID int not null primary key identity
  ,BatchID int not null foreign key references Batch.Batch(BatchID)
  ,PersonID int not null foreign key references Person.Person(PersonID)
  ,ArrivalDate date not null
  ,ArrivalTime time
  ,HasCar bit not null
)
