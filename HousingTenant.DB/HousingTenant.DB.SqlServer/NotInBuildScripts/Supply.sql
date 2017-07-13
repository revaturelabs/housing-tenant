create table Request.Supplies
(
  RequestID int not null primary key foreign key references Request.Request(RequestID)
  ,Soap bit not null
  ,PaperTowels bit not null
  ,TrashBags bit not null
  ,Sponges bit not null
  ,Content nvarchar(500)
  ,Active bit not null default(1)
)