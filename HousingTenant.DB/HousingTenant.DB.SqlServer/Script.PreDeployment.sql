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

insert into [Tenant].[Address](Address1,Address2,ApartmentNumber,City,[State],Zip,Active)
values
    ('11180 Sunrise Valley','Suite 400','','Herndon','VA','20190',1), --BridgeStreet
    ('13000 Wilkes Way','','','Herndon','VA','20170',1), --Westerly at WorldGate
    ('508 Pride Avenue','','','Herndon','VA','20170',1), -- The Townes at Herndon Center
    ('2320 Dulles Station Blvd.','','','Herndon','VA','20171',1), --Camden Dulles Station
    ('11659 North Shore Drive','','','Herndon','VA','20190',1), --Fairway Apartments
    ('Sycamore Valley Drive','','','Herndon','VA','20190',1), --The Sycamores
    --7
    ('11180 Sunrise Valley','Suite 400','321','Herndon','VA','20190',1), --BridgeStreet Tenant
    ('11180 Sunrise Valley','Suite 400','322','Herndon','VA','20190',1), --BridgeStreet Tenant

    ('13000 Wilkes Way','','34','Herndon','VA','20170',1), --Westerly at WorldGate Tenant
    ('13000 Wilkes Way','','35','Herndon','VA','20170',1), --Westerly at WorldGate Tenant

    ('500 Pride Avenue','','633','Herndon','VA','20170',1), -- The Townes at Herndon Center Tenant
    ('500 Pride Avenue','','634','Herndon','VA','20170',1), -- The Townes at Herndon Center Tenant

    ('2320 Dulles Station Blvd.','','43','Herndon','VA','20171',1), --Camden Dulles Station Tenant
    ('2320 Dulles Station Blvd.','','44','Herndon','VA','20171',1), --Camden Dulles Station Tenant

    ('11659 North Shore Drive','','102','Herndon','VA','20190',1), --Fairway Apartments Tenant
    ('11659 North Shore Drive','','103','Herndon','VA','20190',1), --Fairway Apartments Tenant

    ('Sycamore Valley Drive','','7','Herndon','VA','20190',1), --The Sycamores Tenant
    ('Sycamore Valley Drive','','8','Herndon','VA','20190',1); --The Sycamores Tenant


insert into [Tenant].[Gender](Gender)
values
('Male'),
('Female'),
('Other')

insert into [Tenant].[ApartmentComplex](AddressId,isWalkingDistance,ComplexName)
values
(1,0,'BridgeStreet'),
(2,0,'Westerly at WorldGate'),
(3,0,'The Townes at Herndon Center'),
(4,0,'Camden Dulles Station'),
(5,1,'Fairway Apartments'),
(6,1,'The Sycamores');

insert into [Tenant].[Apartment](AddressId,ApartmentComplexId,NumberofBeds,NumberofBathroom)
values
(7,1,2,3),
(8,2,2,3),
(9,3,2,3),
(10,4,2,3),
(11,5,2,3),
(12,6,2,2);

insert into [Tenant].[Person](AddressId,GenderId,HasCar,FirstName,LastName,EmailAddress,ArrivalDate)
values

(7,1,0,'Curtis','Porterfield','CurtisJPorterfield@rhyta.com','2017-12-01 12:00:02'),
(7,1,1,'Gary','Paquette','GaryPPaquette@armyspy.com','2017-12-01 12:00:01'),
(8,2,0,'Sara','Williams','SaraMWilliams@teleworm.us','2017-12-01 12:00:02'),
(8,2,1,'Shelly','Douglas','ShellyADouglas@teleworm.us','2017-12-01 12:00:01'),

(9,1,1,'Carlos','Hervey','CarlosCHervey@armyspy.com','2017-12-01 12:00:01'),
(9,1,0,'Steve','Haines','SteveEHaines@dayrep.com','2017-12-01 12:00:02'),

(10,2,1,'Tenant1','Lastname1','tenant1@email.com','2017-12-01 12:00:01'),
(10,2,0,'Tenant2','Lastname2','tenant2@email.com','2017-12-01 12:00:02'),

(11,1,1,'George','White','GeorgeFWhite@jourrapide.com','2017-12-01 12:00:01'),
(11,1,0,'Roberto','Hildebrant','RobertoLHildebrant@rhyta.com','2017-12-01 12:00:02'),

(12,2,1,'Agnes','Bailey','AgnesSBailey@dayrep.com','2017-12-01 12:00:01'),
(12,2,0,'Mary','Criss','MaryMCriss@rhyta.com','2017-12-01 12:00:02'),

(13,1,1,'Daniel','Whitaker','DanielLWhitaker@armyspy.com','2017-12-01 12:00:01'),
(13,1,0,'Ronald','Moore','RonaldRMoore@armyspy.com','2017-12-01 12:00:02'),

(14,2,1,'Jennifer','Granier','JenniferAGranier@teleworm.us','2017-12-01 12:00:01'),
(14,2,0,'Rachel','Whelan','RachelJWhelan@teleworm.us','2017-12-01 12:00:02'),

(15,1,1,'Joel','Alford','JoelMAlford@jourrapide.com','2017-12-01 12:00:01'),
(15,1,0,'John','Wilt','JohnVWilt@jourrapide.com','2017-12-01 12:00:02'),

(16,2,1,'Margie','Banks','MargieRBanks@teleworm.us','2017-12-01 12:00:01'),
(16,2,0,'Susan','Davis','SusanBDavis@dayrep.com','2017-12-01 12:00:02'),

(17,1,1,'Gerald','Casey','GeraldRCasey@dayrep.com','2017-12-01 12:00:01'),
(17,1,0,'Pablo','Suazo','PabloSSuazo@armyspy.com','2017-12-01 12:00:02'),

(18,2,1,'Sherry','Partida','SherryKPartida@rhyta.com','2017-12-01 12:00:01'),
(18,2,0,'June','Cobbs','JuneRCobbs@rhyta.com','2017-12-01 12:00:02');


insert into [Request].[Status]([Status])
values
    ('PENDING'),
    ('INWORK'),
    ('COMPLETED'),
    ('REJECTED');

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
('MAINTENANCE'),
('SUPPLIES'),
('MOVE'),
('COMPLAINT');

insert into [Request].[Request](RequestTypeId,ApartmentId,isUrgent,[Initiator],[Description])
values
(1,1,1,18,'This is a Test Maintenance Request. The bathroom sink is leaking.');

insert into [Request].[Request](RequestTypeId,ApartmentId,isUrgent,[Initiator],[Description])
values
(2,1,1,17,'This is a Test Supplies Request');

insert into [Request].[SupplyRequest](SupplyTypeId,RequestId)
values
(1,1),
(2,1),
(3,1),
(1,2),
(2,2),
(3,2);

insert into [Request].[Request](RequestTypeId,ApartmentId,isUrgent,[Initiator],[Description])
values
(3,3,1,11,'This is a Test New Apartment Request. I want a new Appartment');

insert into [Request].[Request](RequestTypeId,ApartmentId,isUrgent,[Initiator],PersonIdAccused,[Description])
values
(4,6,1,10,2,'This is a Test Complain Request. I do not like my roommate.');