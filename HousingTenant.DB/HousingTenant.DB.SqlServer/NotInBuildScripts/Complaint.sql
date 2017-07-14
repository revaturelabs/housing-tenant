create table Request.Complaint
(
  RequestID int not null primary key identity
  ,Content nvarchar(500) not null
  ,Active bit not null default(1)
)