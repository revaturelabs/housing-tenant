create table Request.Request
(
  RequestID int not null primary key identity
  ,RequestLookupID int not null foreign key references Request.RequestLookup(RequestLookupID)
  ,PersonID int not null foreign key references Person.Person(PersonID)
  ,Time datetime2 not null
  ,Active bit not null default(1)
)