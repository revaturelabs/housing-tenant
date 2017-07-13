if not exists(select * from sys.databases where name = 'TenantDB')
begin
create database "TenantDB"
END
GO