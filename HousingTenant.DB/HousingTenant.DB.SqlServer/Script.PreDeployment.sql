/*
 Pre-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be executed before the build script.	
 Use SQLCMD syntax to include a file in the pre-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the pre-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
use master;
go

create database HousingTenantDB;
go

use HousingTenantDB;
go

create schema Tenant;
go

create schema Request;
go

create table [Tenant].[Address](
    AddressId int not null identity(1,1),
    Addressguid uniqueidentifier not null DEFAULT (newid()),
    Address1 NVARCHAR(150) not null,
    Address2 NVARCHAR(150),
    ApartmentNumber NVARCHAR(10),
    City NVARCHAR(50) NOT NULL,
    [State] NVARCHAR(50) NOT NULL,
    Zip NVARCHAR(11) NOT NULL,
    Active bit not null default(1)
);

create table [Tenant].[Apartment](
    ApartmentId int not null identity(1,1),
    Apartmentguid uniqueidentifier not null DEFAULT (newid()),
    AddressId int not null, --FK
    ApartmentComplexId int not null,--FK
    NumberofBeds int not null,
    NumberofBathroom int not null,
    Active bit not null default(1)
);

create table [Tenant].[ApartmentComplex](
    ApartmentComplexId int not null identity(1,1),
    ApartmentComplexguid uniqueidentifier not null DEFAULT (newid()),
    AddressId int not null,--FK
    isWalkingDistance bit Default(0),
    ComplexName nvarchar(50) not null,
    Active bit not null default(1)
);

create table [Tenant].[Gender](
    GenderId int not null identity(1,1),
    Gender NVARCHAR(20),
    Active bit not null default(1)
);

create table [Tenant].[Person](
    PersonId int not null identity(1,1),
    Personguid uniqueidentifier not null default (newid()),
    AddressId int,--FK
    GenderId int not null,--FK
    HasCar bit not null default(0),
    FirstName nvarchar(50) not null,
    LastName nvarchar(50) not null,
    EmailAddress nvarchar(100) not null,
    ArrivalDate datetime not null DEFAULT(getdate()),
    Active bit not null default(1)
);

create table [Request].[Status](
    StatusId int not null identity(1,1),
    [Status] nvarchar(50) not null,
    Active bit not null default(1)
);

create table [Request].[SupplyType](
    SupplyTypeId int not null identity(1,1),
    Supply nvarchar(50) not null,
    Active bit not null default(1)
);

create table [Request].[SupplyRequest](
    SupplyRequestId int not null identity(1,1),
    SupplyTypeId int not null,--FK
    RequestId int not null, --FK
    Active bit not null default(1)
);

create table [Request].[RequestType](
RequestTypeId int not null identity(1,1),
RequestType nvarchar(50) not null
);

create table [Request].[Request](
    RequestId int not null identity(1,1),
    Requestguid uniqueidentifier not null default (newid()),
    ApartmentId int not null,
    RequestTypeId int not null, --FK
    isUrgent bit not null default(0),
    [Initiator] int not null,--FK
    DateSubmitted datetime not null default(getdate()),
    PersonIdAccused int,--FK
    [Description] nvarchar(2048) not null,
    DateModified datetime, 
    StatusId int not null default(1),
    Active bit not null default(1)
);

-- alter tables PK.
alter table [Tenant].[Address]
  add constraint PK_Tenant_Address_AddressId primary key clustered (AddressId);

alter table [Tenant].[Apartment]
  add constraint PK_Tenant_Apartment_ApartmentId primary key clustered (ApartmentId);

alter table [Tenant].[ApartmentComplex]
  add constraint PK_Tenant_ApartmentComplex_ApartmentComplexId primary key clustered (ApartmentComplexId);

alter table [Tenant].[Person]
  add constraint PK_Tenant_Person_PersonId primary key clustered (PersonId);

alter table [Tenant].[Gender]
  add constraint PK_Tenant_Gender_GenderId primary key clustered (GenderId);

alter table [Request].[Status]
  add constraint PK_Request_Status_StatusId primary key clustered (StatusId);

alter table [Request].[SupplyType]
  add constraint PK_Request_SupplyType_SupplyTypeId primary key clustered (SupplyTypeId);

alter table [Request].[SupplyRequest]
  add constraint PK_Request_SupplyRequest_SupplyRequestId primary key clustered (SupplyRequestId);

alter table [Request].[RequestType]
  add constraint PK_Request_RequestType_RequestTypeId primary key clustered (RequestTypeId);

alter table [Request].[Request]
  add constraint PK_Request_Request_RequestId primary key clustered (RequestId);


-- alter tables FK.
alter table  [Tenant].[Apartment]
  add constraint FK_Tenant_Apartment_AddressId foreign key (AddressId) references [Tenant].[Address] (AddressId);

alter table  [Tenant].[Apartment]
  add constraint FK_Tenant_Apartment_ApartmentComplexId foreign key (ApartmentComplexId) references [Tenant].[ApartmentComplex] (ApartmentComplexId);

 alter table  [Tenant].[ApartmentComplex]
  add constraint FK_Tenant_ApartmentComplex_AddressId foreign key (AddressId) references [Tenant].[Address] (AddressId);

alter table  [Tenant].[Person]
  add constraint FK_Tenant_Person_AddressId foreign key (AddressId) references [Tenant].[Address] (AddressId);

alter table  [Tenant].[Person]
  add constraint FK_Tenant_Person_GenderId foreign key (GenderId) references [Tenant].[Gender] (GenderId);

alter table  [Request].[SupplyRequest]
  add constraint FK_Request_SupplyRequest_SuppyTypeId foreign key (SupplyTypeId) references [Request].[SupplyType] (SupplyTypeId);

alter table  [Request].[SupplyRequest]
  add constraint FK_Request_SupplyRequest_RequestId foreign key (RequestId) references [Request].[Request] (RequestId);

alter table  [Request].[Request]
  add constraint FK_Request_Request_PersonIdAccusedId foreign key (PersonIdAccused) references [Tenant].[Person] (PersonId);

alter table  [Request].[Request]
  add constraint FK_Request_Request_Initiator foreign key ([Initiator]) references [Tenant].[Person] (PersonId);

alter table  [Request].[Request]
  add constraint FK_Request_Request_RequestTypeId foreign key (RequestTypeId) references [Request].[RequestType] (RequestTypeId);

alter table  [Request].[Request]
  add constraint FK_Request_Request_ApartmentId foreign key (ApartmentId) references [Tenant].[Apartment] (ApartmentId);

insert into [Tenant].[Address](Address1,ApartmentNumber,City,[State],Zip)
values
('123 Main Street','101','Miami','FL','33161'),
('321 Main Street','102','Miami','FL','33162'),
('4321 Main Street','103','Miami','FL','33163');


insert into [Tenant].[Gender](Gender)
values
('Male'),
('Female'),
('Other')

insert into [Tenant].[ApartmentComplex](AddressId,isWalkingDistance,ComplexName)
values
(1,1,'ComplexName Demo'),
(1,1,'ComplexName2 Demo'),
(1,1,'ComplexName3 Demo');

insert into [Tenant].[Apartment](AddressId,ApartmentComplexId,NumberofBeds,NumberofBathroom)
values
(1,1,2,2),
(2,1,2,2),
(3,1,2,2);

insert into [Tenant].[Person](AddressId,GenderId,HasCar,FirstName,LastName,EmailAddress,ArrivalDate)
values
(1,1,1,'Tenant1','Lastname1','tenant1@email.com','2017-12-01 12:00:01'),
(1,1,0,'Tenant2','Lastname2','tenant2@email.com','2017-12-01 12:00:02'),
(1,1,1,'Tenant3','Lastname3','tenant3@email.com','2017-12-01 12:00:03');


insert into [Request].[Status]([Status])
values
    ('Pending'),
    ('Hold'),
    ('Completed'),
    ('Rejected');

insert into [Request].[SupplyType](Supply)
values
    ('Hand Soap'),
    ('Toilet Paper'),
    ('Paper Towels'),
    ('Dish Soap'),
    ('Trash Bags'),
    ('Dishwasher Detergent'),
    ('Sponges');


insert into [Request].[RequestType](RequestType)
values
('Maintenance'),
('Supplies'),
('New Apartment'),
('Complaint');

insert into [Request].[Request](RequestTypeId,ApartmentId,isUrgent,[Initiator],[Description])
values
(1,1,1,1,'This is a Test Maintenance Request');

insert into [Request].[Request](RequestTypeId,ApartmentId,isUrgent,[Initiator],[Description])
values
(2,1,1,1,'This is a Test Supplies Request');

insert into [Request].[SupplyRequest](SupplyTypeId,RequestId)
values
(1,2),
(2,2),
(3,2);

insert into [Request].[Request](RequestTypeId,ApartmentId,isUrgent,[Initiator],[Description])
values
(3,1,1,1,'This is a Test New Apartment Request');

insert into [Request].[Request](RequestTypeId,ApartmentId,isUrgent,[Initiator],PersonIdAccused,[Description])
values
(4,1,1,2,'This is a Test Complain Request');