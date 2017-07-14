create table Batch.Batch
(
  BatchID int not null primary key identity
  ,BatchLookupID int not null foreign key references Batch.BatchLookup(BatchLookupID)
  ,StartDate date not null
  ,EndDate date not null
  ,Active bit not null default(1)
)