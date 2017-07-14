create table Request.Maintenance
(
  RequestID int not null primary key foreign key references Request.Request(RequestID)
  ,MaintenanceTypeID int not null foreign key references Request.MaintenanceLookup(MaintenanceTypeID)
  ,Content nvarchar(500) not null
  ,Active bit not null default(1)
)
